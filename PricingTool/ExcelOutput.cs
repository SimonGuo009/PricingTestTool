using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Collections;

namespace PricingTool
{
    using static Condition.Currencies;

    public class ExcelOutput
    {
        //private void CreateExcelFile(string FileName)
        //{
        //    //create  
        //    object Nothing = System.Reflection.Missing.Value;
        //    var app = new Excel.Application();
        //    app.Visible = false;
        //    Excel.Workbook workBook = app.Workbooks.Add(Nothing);
        //    Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[1];
        //    worksheet.Name = "Work";
        //    //headline  
        //    worksheet.Cells[1, 1] = "FileName";
        //    worksheet.Cells[1, 2] = "FindString";
        //    worksheet.Cells[1, 3] = "ReplaceString";

        //    worksheet.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
        //    workBook.Close(false, Type.Missing, Type.Missing);
        //    app.Quit();
        //}

        public static void CreateExcelFile()
        {
            //create  
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[1];
            worksheet.Name = "PricingInfo";
            //headline  
            worksheet.Cells[1, 1] = "Product-Region-Currency";
            worksheet.Cells[1, 2] = "ExpectPricing";
            worksheet.Cells[1, 3] = "ActualPricing";
            worksheet.Cells[1, 4] = "OffsetPercentage";

            worksheet.SaveAs(ExcelFilePath(), Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit();
        }

        ///// <summary>  
        ///// open an excel file,then write the content to file  
        ///// </summary>  
        ///// <param name="FileName">file name</param>  
        ///// <param name="findString">first cloumn</param>  
        ///// <param name="replaceString">second cloumn</param>  
        //private void WriteToExcel(string excelName, string filename, string findString, string replaceString)
        //{
        //    //open  
        //    object Nothing = System.Reflection.Missing.Value;
        //    var app = new Excel.Application();
        //    app.Visible = false;
        //    Excel.Workbook mybook = app.Workbooks.Open(excelName, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);
        //    Excel.Worksheet mysheet = (Excel.Worksheet)mybook.Worksheets[1];
        //    mysheet.Activate();
        //    //get activate sheet max row count  
        //    int maxrow = mysheet.UsedRange.Rows.Count + 1;
        //    mysheet.Cells[maxrow, 1] = filename;
        //    mysheet.Cells[maxrow, 2] = findString;
        //    mysheet.Cells[maxrow, 3] = replaceString;
        //    mybook.Save();
        //    mybook.Close(false, Type.Missing, Type.Missing);
        //    mybook = null;
        //    //quit excel app  
        //    app.Quit();
        //}

        public static void WriteToExcel(string conditionInfo, List<double> list1, List<double> list2)
        {
            //open  
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook mybook = app.Workbooks.Open(ExcelFilePath(), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);
            Excel.Worksheet mysheet = (Excel.Worksheet)mybook.Worksheets[1];
            mysheet.Activate();
            //get activate sheet max row count  
            int maxrow = 0;
            if (list1.Count != list2.Count) throw new Exception("Expect & Actual data list do not have equivalent amount of data.");

            for (int i = 0; i < list1.Count; i++)
            {
                //get offset percentage (considering divide by zero exception)
                double offset = CalculateOffset(list1[i], list2[i]);
                string offsetPercentage = offset.ToString("0.0%");

                maxrow = mysheet.UsedRange.Rows.Count + 1;
                mysheet.Cells[maxrow, 1] = conditionInfo;
                mysheet.Cells[maxrow, 2] = list1[i];
                mysheet.Cells[maxrow, 3] = list2[i];
                mysheet.Cells[maxrow, 4] = offsetPercentage;
            }
            mybook.Save();
            mybook.Close(false, Type.Missing, Type.Missing);
            mybook = null;
            //quit excel app  
            app.Quit();
        }

        private static double CalculateOffset(double num1, double num2)
        {
            double offset = 0;
            //  |expect-actual|/expect * 100%
            try { offset = System.Math.Abs(num1 - num2) / num2; }
            catch (DivideByZeroException) { offset = 0; }

            return offset;
        }

        private void AddRowToExcel(string excelName, string PRCInfo, double expectValue, double actualValue)
        {
            //get offset percentage (considering divide by zero exception)
            double offset = 0;
            try { offset = System.Math.Abs(expectValue - actualValue) / expectValue; }
            catch (DivideByZeroException) { offset = 0; }

            string offsetPercentage = offset.ToString("0.0%");

            //open  
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook mybook = app.Workbooks.Open(excelName, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);
            Excel.Worksheet mysheet = (Excel.Worksheet)mybook.Worksheets[1];
            mysheet.Activate();
            //get activate sheet max row count  
            int maxrow = mysheet.UsedRange.Rows.Count + 1;
            mysheet.Cells[maxrow, 1] = PRCInfo;
            mysheet.Cells[maxrow, 2] = expectValue;
            mysheet.Cells[maxrow, 3] = actualValue;
            mysheet.Cells[maxrow, 4] = offsetPercentage;


            mybook.Save();
            mybook.Close(false, Type.Missing, Type.Missing);
            mybook = null;
            //quit excel app  
            app.Quit();
        }

        private static string ExcelFilePath()
        {
            string Current = "";
            Current = Directory.GetCurrentDirectory();//获取当前根目录
            return Current + "\\test.xls";
        }

        //引用方法
        //static void Main(string[] args)
        //{
        //    string Current;
        //    Current = Directory.GetCurrentDirectory();//获取当前根目录
        //    CreateExcelFile(Current + "\\test.xls");
        //}

    }
}
