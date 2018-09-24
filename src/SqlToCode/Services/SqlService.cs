namespace Etraining.Sql
{
    using SqlToCode.Models;
    using SqlToCode.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    public class SqlService
    {
        private readonly string _connectionString;

        public SqlService(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// Execute sql query and fill the result against the generic type T
        /// </summary>
        public async Task<List<T>> ExecuteQuery<T>(string query, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            List<T> result = new List<T>();
            SqlDataReader reader = null;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.CommandType = commandType;

                        if (sqlParameters.Length > 0)
                        {
                            command.Parameters.AddRange(sqlParameters);
                        }

                        if (command.Connection.State != ConnectionState.Open)
                        {
                            await command.Connection.OpenAsync();
                        }

                        reader = await command.ExecuteReaderAsync();

                        var properties = typeof(T).GetProperties();

                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                if (typeof(T).FullName.Contains("System."))
                                {
                                    result.Add((T)reader[0]);
                                }
                                else
                                {
                                    var record = (T)Activator.CreateInstance(typeof(T));

                                    for (int j = 0; j <= reader.FieldCount - 1; j++)
                                    {
                                        var jj = j;

                                        var fieldname = reader.GetName(j).ToString();

                                        var fieldType = reader.GetProviderSpecificFieldType(j).ToString().ToLower();

                                        var property = properties.Where(f => f.Name.Trim().ToLower() == fieldname.ToLower()).ToList();

                                        if (property.Count > 0)
                                        {
                                            //Date or DateTime
                                            if (fieldType.Contains("date"))
                                            {
                                                if (!property[0].PropertyType.FullName.ToLower().Contains("system.nullable") && (reader[fieldname] == null || reader[fieldname].Equals(System.DBNull.Value)))
                                                {
                                                    property[0].SetValue(record, DateTime.Now, null);
                                                }
                                                else
                                                {
                                                    if (!(property[0].PropertyType.FullName.ToLower().Contains("system.nullable") && (reader[fieldname] == null || reader[fieldname].Equals(System.DBNull.Value))))
                                                    {
                                                        property[0].SetValue(record, reader[fieldname], null);
                                                    }
                                                }
                                                //String
                                            }
                                            else if (fieldType.Contains("string"))
                                            {
                                                if (reader[fieldname] == null || reader[fieldname].Equals(System.DBNull.Value))
                                                {
                                                    property[0].SetValue(record, "", null);
                                                }
                                                else
                                                {
                                                    property[0].SetValue(record, reader[fieldname], null);
                                                }
                                            }
                                            else
                                            {
                                                if (!(property[0].PropertyType.FullName.ToLower().Contains("system.nullable") && (reader[fieldname] == null || reader[fieldname].Equals(System.DBNull.Value))))
                                                {
                                                    property[0].SetValue(record, reader[fieldname], null);
                                                }
                                            }
                                        }
                                    }
                                    result.Add(record);
                                }
                            }
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }

                Logger.Log(ex);

                throw;
            }

            return result;
        }

        public DataTable ExecuteCrmQuery(string query, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var dataAdapter = new SqlDataAdapter())
                    {
                        var dataTable = new DataTable();

                        dataAdapter.SelectCommand = new SqlCommand(query, connection);

                        if (sqlParameters?.Any() ?? false)
                        {
                            dataAdapter.SelectCommand.Parameters.AddRange(sqlParameters);
                        }

                        dataAdapter.Fill(dataTable);

                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);

                throw;
            }
        }

        public async Task<bool> ExecuteProcedure(string query, params SqlParameter[] sqlParameters)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        if (sqlParameters.Length > 0)
                        {
                            command.Parameters.AddRange(sqlParameters);
                        }

                        if (command.Connection.State != ConnectionState.Open)
                        {
                            await command.Connection.OpenAsync();
                        }

                        await command.ExecuteNonQueryAsync();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);

                throw;
            }
        }

        public IEnumerable<Column> GetQueryColumns(string query)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var dataAdapter = new SqlDataAdapter())
                    {
                        var dataTable = new DataTable();

                        dataAdapter.SelectCommand = new SqlCommand($"select top(1) * from ({query}) as tbl{Guid.NewGuid().ToString().Replace("-", "_")}", connection);

                        dataAdapter.Fill(dataTable);

                        return dataTable.Columns.Cast<DataColumn>().Select(m => new Column {
                            Name = m.ColumnName,
                            Type = m.DataType.Name
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);

                throw;
            }
        }
    }
}
