using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace eleave_c
{
    public class datamapper
    {
        public const char ColumnDelemiter = '\t';
        public const char RowDelemiter = '\n';

        public static List<T> GetData<T>(string content)
        {
            List<T> value = new List<T>();
            T obj;
            string[] rowValues;
            string[] colValues;
            int colIndex = 0;
            PropertyInfo pInfo;

            if (string.IsNullOrEmpty(content) || content == "null")
                return null;

            content = content.Replace("\r", "");
            rowValues = content.Split(RowDelemiter);

            foreach (string rowItem in rowValues)
            {
                if (string.IsNullOrEmpty(rowItem))
                    continue;

                colValues = new string[rowItem.Split(ColumnDelemiter).Length];
                colIndex = 0;
                obj = (T)Activator.CreateInstance(typeof(T));

                foreach (string colItem in rowItem.Split(ColumnDelemiter))
                {
                    pInfo = obj.GetType().GetProperties()[colIndex];
                    pInfo.SetValue(obj, colItem, null);
                    colIndex++;
                }
                value.Add(obj);
            }

            return value;
        }



        public static DataTable GetDataTable(string content, bool IsFirstColumnHeader)
        {
            DataTable value = new DataTable();
            string[] rowValues;
            string[] colValues;
            int colIndex = 0;
            int rowIndex = 0;

            if (string.IsNullOrEmpty(content) || content == "null")
                return null;

            content = content.Replace("\r", "");
            rowValues = content.Split(RowDelemiter);

            foreach (string rowItem in rowValues)
            {
                if (string.IsNullOrEmpty(rowItem))
                    continue;

                colValues = new string[rowItem.Split(ColumnDelemiter).Length];
                colIndex = 0;

                foreach (string colItem in rowItem.Split(ColumnDelemiter))
                {
                    if (rowIndex == 0 && IsFirstColumnHeader)
                        value.Columns.Add(colItem);
                    else if (rowIndex == 0)
                        value.Columns.Add();

                    if ((rowIndex == 0 && !IsFirstColumnHeader) || rowIndex != 0)
                        colValues[colIndex] = colItem;

                    colIndex++;
                }
                if ((rowIndex == 0 && !IsFirstColumnHeader) || rowIndex != 0)
                    value.Rows.Add(colValues);

                rowIndex++;
            }

            return value;
        }
    }
}
