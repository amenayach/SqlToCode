using SqlToCode.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SqlToCode.ConnectionDialog
{
    public partial class SqlConnectionDialog : Form
    {

        private const string RegServers = "servers";
        private const string RegUsers = "users";

        /// <summary>
        /// The selected connection string
        /// </summary>
        public string ConnectionString { get; set; }

        public SqlConnectionDialog()
        {
            InitializeComponent();
        }

        private void SqlConnectionDialog_Load(object sender, EventArgs e)
        {

            LoadRegistry();

        }

        private void LoadRegistry()
        {
            object[] servers = (RegistryManager.GetRegistryValue(RegServers) as string ?? "").Split(';');

            object[] users = (RegistryManager.GetRegistryValue(RegUsers) as string ?? "").Split(';');

            cmbServer.Items.Clear();
            cmbServer.Items.AddRange(servers);

            cmbUsers.Items.Clear();
            cmbUsers.Items.AddRange(users);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectionString = GetConnection(false);
            UpdateRegistry();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateRegistry()
        {
            var servers = (RegistryManager.GetRegistryValue(RegServers) as string ?? "").Split(';').ToList();

            var users = (RegistryManager.GetRegistryValue(RegUsers) as string ?? "").Split(';').ToList();

            if (!servers.Contains(cmbServer.Text))
            {
                servers.Add(cmbServer.Text);
                RegistryManager.SetRegistryValue(RegServers, servers.Aggregate((m1, m2) => m1 + ";" + m2));
            }

            if (!users.Contains(cmbUsers.Text))
            {
                users.Add(cmbUsers.Text);
                RegistryManager.SetRegistryValue(RegUsers, users.Aggregate((m1, m2) => m1 + ";" + m2));
            }
        }

        private string GetConnection(bool loadMasterData)
        {
            var result = string.Empty;

            try
            {

                if (cmbDatabase.Text.IsEmpty() && loadMasterData)
                {
                    cmbDatabase.Text = @"master";
                }

                if (cmbServer.Text.NotEmpty() && cmbDatabase.Text.NotEmpty())
                {

                    if (cmbUsers.Text.NotEmpty() && tbPassword.Text.NotEmpty())
                    {

                        result =
                            string.Format(
                                "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                                cmbServer.Text, cmbDatabase.Text, cmbUsers.Text, tbPassword.Text);

                    }
                    else
                    {

                        result = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", cmbServer.Text, cmbDatabase.Text);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        private void cmbDatabase_Enter(object sender, EventArgs e)
        {

            try
            {

                if (cmbDatabase.Items.Count == 0)
                {

                    var connectionString = GetConnection(true);
                    cmbDatabase.Items.Clear();
                    GetDatabases(connectionString).ForEach(m => cmbDatabase.Items.Add(m));

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<string> GetDatabases(string connectionString)
        {
            var result = new List<string>();

            try
            {

                using (var con = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand(@"select name from sys.databases", con))
                    {

                        con.Open();

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            result.Add(reader[0] as string);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        public static string Connect()
        {
            var result = string.Empty;

            try
            {

                using (var dialog = new SqlConnectionDialog())
                {

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                            result = dialog.ConnectionString;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        private void SqlConnectionDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
