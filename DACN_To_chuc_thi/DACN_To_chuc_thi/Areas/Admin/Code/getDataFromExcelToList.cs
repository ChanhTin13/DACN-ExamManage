using DACN_To_chuc_thi.Areas.Admin.CusModel.File;
using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;

namespace DACN_To_chuc_thi.Areas.Admin.Code
{
    public class getDataFromExcelToList
    {
        private static getDataFromExcelToList thuc_Thi;
        public static getDataFromExcelToList Thuc_Thi
        {
            get
            {
                if (thuc_Thi == null)
                {
                    thuc_Thi = new getDataFromExcelToList();
                }
                return thuc_Thi;
            }
        }
        public FileInfo getExcelFile(string path)
        {
            List<string> list = new List<string>();
            FileInfo fileInfo = new FileInfo();

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                String str = "";
                for (int j = 1; j <= colCount; j++)
                { 
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        str = str + xlRange.Cells[i, j].Value2.ToString() + "_";
                }
                list.Add(str);
            }
            fileInfo.colCount = colCount;
            fileInfo.data = list;
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return fileInfo;
        }
    }
}