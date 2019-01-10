using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;

namespace ProofOfConcept
{
    class ExcelLiabrary
    {
        private static DataTable ExcelToDataTable(string fileName)
        {
            //open file and returns as stream
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            //CreateOpenXMLReader via ExcelReaderLiabrary
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx
            //Set the first Row as Column Name  
            //Return as DataSet
            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            //Get all the tables
            DataTableCollection table = result.Tables;
            //Store it in DataTable
            DataTable resultTable = table["TestCases"];

            //Return
            return resultTable;
        }
        static List<Datacollection> dataCol = new List<Datacollection>();
        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //Iterate through the rows and columns of the Table
            for(int row = 1; row <= table.Rows.Count; row++)
            {
                for(int col=0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dtTable);
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retrieving data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static string fileName()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string excelPath = projectPath + @"TestData\ExcelFile.xlsx";
            return excelPath;
        }
    }
    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}
