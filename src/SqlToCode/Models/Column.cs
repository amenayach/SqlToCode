namespace SqlToCode.Models
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents a SQL column
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Gets or sets the name of the column
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the column
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets the normalized name of the column
        /// </summary>
        public string NormalizedName
        {
            get { return GetNormalizedName(Name); }
        }

        /// <summary>
        /// Gets the normalized type of the column
        /// </summary>
        public string NormalizedType
        {
            get { return GetNormalizedType(Type); }
        }

        private string GetNormalizedType(string type)
        {
            switch (Type)
            {
                case "Int16":
                    return "short";
                case "Int32":
                    return "int";
                case "Int64":
                    return "long";
                case "Decimal":
                    return "decimal";
                case "Float":
                    return "float";
                case "Boolean":
                    return "bool";
                default:
                    return Type;
            }
        }

        /// <summary>
        /// Gets the normalized name of a string
        /// </summary>
        private string GetNormalizedName(string name)
        {
            name = name == null ? string.Empty : name.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                return name;
            }

            var underscoreSplit = name.Split(new[] { "_", " ", "-", "[", "]" }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, string> normalizeWord = (string word) =>
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    return string.Empty;
                }

                return word.First().ToString().ToUpper() + (word.Length > 1 ? word.Substring(1) : string.Empty);
            };

            return string.Join(string.Empty, underscoreSplit.Select(normalizeWord));
        }
    }
}
