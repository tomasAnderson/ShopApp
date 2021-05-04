using System;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace ShopApp
{
    public class OutputToExcel
    {
        /*public void ImportToExcel(ref DataGrid dataGrid)
        {
            Application app = null;
            Workbook wb = null;
            Worksheet ws = null;
            var process = Process.GetProcessesByName("EXCEL");

            SaveFileDialog openDlg = new SaveFileDialog();
            openDlg.FileName = "Пользователи без leader-id";
            openDlg.Filter = "Excel (.xls)|*.xls |Excel (.xlsx)|*.xlsx |All files (*.*)|*.*";
            openDlg.FilterIndex = 2;
            openDlg.RestoreDirectory = true;
            string path = openDlg.FileName;

            if (openDlg.ShowDialog() == true)
            {
                app = new Application();
                app.Visible = true;
                app.DisplayAlerts = false;
                wb = app.Workbooks.Add();
                ws = wb.ActiveSheet as Worksheet;
                dataGrid.SelectAllCells();
                dataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dataGrid);
                ws.Paste();
                ws.Range["A1", "B1"].Font.Bold = true;
                int number1 = ws.UsedRange.Rows.Count;
                Range myRange = ws.Range["A1", "B" + number1];
                myRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                myRange.WrapText = false;
                ws.Columns.EntireColumn.AutoFit();
                wb.SaveAs(path);

            }
        }*/

        public void CreateReport(string header, string data)
        {
            SaveFileDialog openDlg = new SaveFileDialog();
            openDlg.FileName = "Отчёт о прибыли магазина";
            openDlg.Filter = "Excel (.xls)|*.xls |Excel (.xlsx)|*.xlsx |All files (*.*)|*.*";
            openDlg.FilterIndex = 2;
            openDlg.RestoreDirectory = true;
            string path = openDlg.FileName;

            if (openDlg.ShowDialog() == true)
                ZAZ2();
            //CreateAndInputInFile(path, header, data);
        }

        private static void CreateAndInputInFile(string filePath, string header, string data)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 0] = header;
            xlWorkSheet.Cells[1, 1] = data;

            xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            Console.Write("Excel file created , you can find the file c:\\csharp-Excel.xls");
        }

        private static void ZAZ(string filePath, string header, string data)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel._Workbook) (oXL.Workbooks.Add(""));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet) oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "First Name";
                oSheet.Cells[1, 2] = header;
                oSheet.Cells[1, 3] = data;
                oSheet.Cells[1, 4] = "Salary";

                oXL.Visible = false;
                oXL.UserControl = false;
                oWB.SaveAs(filePath, XlFileFormat.xlWorkbookDefault,
                    Type.Missing,
                    Type.Missing,
                    false, false, XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();
                oXL.Quit();
            }
            catch (Exception)
            {
                
            }
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.Write("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        
        
        private void ZAZ2()
        {
            UpdateExcel("Sheet3", 4, 7, "Namachi@gmail");
        }

        private static void UpdateExcel(string sheetName, int row, int col, string data)
        {
            var zzz = 55;
            Application oXL = null;
            _Workbook oWB = null;
            _Worksheet oSheet = null;

            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oWB = oXL.Workbooks.Open("MyExcel.xlsx");
                oSheet = String.IsNullOrEmpty(sheetName) ? (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet : (Microsoft.Office.Interop.Excel._Worksheet)oWB.Worksheets[sheetName];

                oSheet.Cells[row, col] = data;

                oWB.Save();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (oWB != null)
                    oWB.Close();
            }
        }
    }
}