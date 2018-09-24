namespace Etraining.Sql
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using SqlToCode.Models;

    public class CodeGenerator
    {
        private const string ClassTemplateFilename = "ClassTemplate";
        private const string PropertyTemplateFilename = "PropertyTemplate";
        private const string ClassNameKey = "$ClassName$";
        private const string PropsKey = "$Props$";
        private const string NameKey = "$Name$";
        private const string TypeKey = "$Type$";

        public static string GenerateCsharpClass(string connectionString, string sqlQuery, string classname, bool normalizeNames)
        {
            var classTemplate = File.ReadAllText($@"{Application.StartupPath}\templates\{ClassTemplateFilename}.txt");

            var sqlService = new SqlService(connectionString);

            var columns = sqlService.GetQueryColumns(sqlQuery);

            if (columns == null || !columns.Any())
            {
                return string.Empty;
            }

            return classTemplate.Replace(ClassNameKey, classname)
                                .Replace(PropsKey, GetCSharpProperties(columns, normalizeNames));
        }

        private static string GetCSharpProperties(IEnumerable<Column> columns, bool normalizNames)
        {
            if (columns == null || !columns.Any())
            {
                return string.Empty;
            }

            var propertyTemplate = File.ReadAllText($@"{Application.StartupPath}\templates\{PropertyTemplateFilename}.txt");

            return columns.Select(m => propertyTemplate
                              .Replace(NameKey, normalizNames ? m.NormalizedName : m.Name)
                              .Replace(TypeKey, m.NormalizedType)
                          ).Aggregate((m1, m2) => m1 + Environment.NewLine + m2);
        }
    }
}
