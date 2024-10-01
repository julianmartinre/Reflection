using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public static class FileManager
    {
        public static void ExportCsv<T>(List<T> list, string path)
        {
            byte[] data = null;
            StringBuilder result = new StringBuilder();

            PropertyInfo[] properties = typeof(T).GetProperties();
            var lastProp = properties[properties.Length - 1];

            for (int i = 0; i < properties.Length - 1; i++)
            {
                result.Append(properties[i].Name).Append(";");
            }
            result.Append(lastProp.Name).Append(Environment.NewLine);

            foreach (var item in list)
            {
                for (int i = 0; i < properties.Length - 1; i++)
                {
                    var prop = properties[i];
                    result.Append(EscapeCsvValue(prop.GetValue(item)?.ToString())).Append(";");
                }
                result.Append(EscapeCsvValue(lastProp.GetValue(item)?.ToString())).Append(Environment.NewLine);
            }

            data = Encoding.UTF8.GetBytes(result.ToString());

            File.WriteAllText(path, result.ToString(), Encoding.UTF8);
        }

        private static string EscapeCsvValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            if (value.Contains(";") || value.Contains("\n") || value.Contains("\r") || value.Contains("\""))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }

            return value;
        }
    }
}
