using NPOI.SS.UserModel;
using NPOI.XSSF;
using NPOI.HSSF;
using System.Data;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Diagnostics.Metrics;

namespace MyWork
{
    public enum CompareFlag{
        noCompare = 1,
        Compare = 2
    }
    public class Excel2HTML{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="compareFlag">if compare the header of table have 2 lines</param>
        /// <returns></returns>
        public static DataTable Excel2Table(string file, CompareFlag compareFlag = CompareFlag.noCompare){
            DataTable dt = new DataTable();
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();

            // 1.open file
            using(FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read)){
                if(fileExt == ".xlsx"){
                    workbook = new XSSFWorkbook(fs);
                }else if(fileExt == ".xls"){
                    workbook = new HSSFWorkbook(fs);
                }else{
                    Console.WriteLine("error:file extension is not xls or xlsx.");
                    return null;
                }

                // 2. get sheet 
                ISheet sheet1 = workbook.GetSheetAt(0);

                IRow header = sheet1.GetRow(sheet1.FirstRowNum);
                IRow header2 = null;
                // if compare then do
                if(compareFlag == CompareFlag.Compare){
                    header2 = sheet1.GetRow(sheet1.FirstRowNum + 1);
                }
                String tmpColName = "";


                List<int> columns = new List<int>();
                // 2.1 get col1
                for (int i = 0; i < header.LastCellNum; i++){
                    object obj = GetValueType(header.GetCell(i));
                    if(obj == null || obj.ToString() == string.Empty){
                        if(compareFlag == CompareFlag.noCompare && tmpColName == ""){
                            dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                        }else if(compareFlag == CompareFlag.Compare && tmpColName != ""){
                            dt.Columns.Add(new DataColumn(tmpColName + GetValueType(header2.GetCell(i)).ToString()));
                        }
                    }
                    else{
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                        tmpColName = obj.ToString();
                    }
                    columns.Add(i);
                }
                // 2.2 get data 数据
                for (int i = sheet1.FirstRowNum + (int)compareFlag; i <= sheet1.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueType(sheet1.GetRow(i).GetCell(j));
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
        }


        private static object GetValueType(ICell cell)
        {
            if(cell == null){
                return null;
            }
            switch(cell.CellType){
                case CellType.Blank:
                    return null;
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Numeric:
                    return cell.NumericCellValue;
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Error:
                    return cell.ErrorCellValue;
                case CellType.Formula:
                default:
                    return "=" + cell.CellFormula;
            }
        }

        public static void TestPathStr(){
            string path1 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //获取和设置当前目录(该进程从中启动的目录)的完全限定目录
            string path2 = System.Environment.CurrentDirectory;
            //获取应用程序的当前工作目录
            string path3 = System.IO.Directory.GetCurrentDirectory();
            //获取程序的基目录
            string path4 = System.AppDomain.CurrentDomain.BaseDirectory;
            //获取和设置包括该应用程序的目录的名称
            string path5 = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            Console.WriteLine(path1);
            Console.WriteLine(path2);
            Console.WriteLine(path3);
            Console.WriteLine(path4);
            Console.WriteLine(path5);
        }
    }
}