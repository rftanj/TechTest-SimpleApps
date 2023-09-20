using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Models.DataTable;

namespace TechnicalTest.Helper
{
    public class DataConversion
    {
        public static Dictionary<string, string> FromDataTableColumnSearches(List<DataTableParam.Column> columns)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            columns.ForEach(column =>
            {
                if (column.data != null) result.Add(column.data, column.search.value);
            });
            return result;
        }

       /* public static Dictionary<string, string> FromCognitoUserAttributes(List<AttributeType> attributes)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            attributes.ForEach(attribute =>
            {
                string key = attribute.Name.ToLower();
                if (!result.ContainsKey(key))
                    result.Add(key, attribute.Value);
            });

            return result;
        }*/
    }
}
