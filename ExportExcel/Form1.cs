
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using ExportExcel.common;

namespace ExportExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取数据库数据
            DataTable dataTable = new DataTable();
            string saveFileName = "拌合站Excel";

            /*新建表；新建Sheet并命名；设定cellStyle*/
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet sheet1 = book.CreateSheet("Sheet1");
            IRow headerRow4Sheet1 = sheet1.CreateRow(0);
            ExcelCellStyle cellStyle = new ExcelCellStyle(book);

            ICell cell;
            try
            {
                if ("sqlserver".Equals(dbType.Text))
                {
                    DBHelp db = new DBHelp();
                    db.Url = @"Data Source=" + url.Text + "," + port.Text + ";Initial Catalog=" + dbName.Text + ";User ID=" + username.Text + ";pwd=" + password.Text + "";
                    dataTable = db.adapterFind(sql.Text);
                }
                if ("mysql".Equals(dbType.Text))
                {
                    MySqlUtil db = new MySqlUtil();
              //      db.Url = @"server=" + url.Text + ";port=" + port.Text + ";user=" + username.Text + ";password=" + password.Text + "; database=" + dbName.Text + ";";
              //      db.Url = @"data source=" + url.Text + ";database=" + dbName.Text + ";user id=" + username.Text + ";password=" + password.Text + ";pooling=false;charset=utf8;";
                    db.Url = @"Server=" + url.Text + ";port=" + port.Text + ";Database=" + dbName.Text + ";Uid=" + username.Text + ";Pwd=" + password.Text + ";CharSet=utf8;";
                    dataTable = db.adapterFind(sql.Text);
                }
                if ("oracle".Equals(dbType.Text))
                {
                    OracleUtil db = new OracleUtil();
                    db.Url = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + url.Text + ")(PORT=" + port.Text + ")))(CONNECT_DATA=(SERVICE_NAME=" + dbName.Text + ")));User ID=" + username.Text + ";Password=" + password.Text + ";";
                    dataTable = db.adapterFind(sql.Text);
                }

                /*设定标题行*/
                int columnNum = 0;
                columnNum = dataTable.Columns.Count;
                string[] colNames = new string[columnNum];
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    colNames[i] = dataTable.Columns[i].ColumnName;
                }
                for (int i = 0; i < colNames.Length; i++)
                {
                    cell = headerRow4Sheet1.CreateCell(i);
                    cell.CellStyle = cellStyle.style;
                    cell.SetCellValue(colNames[i]);
                }

                /*设定内容行*/
                int sheet1RowID = 1;//从表格的第二2行开始进行循环

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    IRow r = sheet1.CreateRow(sheet1RowID);
                    for (int i = 0; i < colNames.Length; i++)
                    {
                        cell = r.CreateCell(i);
                        cell.SetCellValue(dataRow[i].ToString().Trim());
                        cell.CellStyle = cellStyle.style;
                    }
                    sheet1RowID = sheet1RowID + 1;

                }

                /*单元格长度格式化*/
                ChangeStyle(book, sheet1);
            }
            catch (Exception ex)
            {
                cell = headerRow4Sheet1.CreateCell(0);
                cell.CellStyle = cellStyle.style;
                cell.SetCellValue(string.Format("异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                                        ex.GetType().Name, ex.Message, ex.StackTrace));
                saveFileName = "查询出错请检查填写信息";
            }

            /*IO流输出保存*/
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xlsx";
            saveDialog.Filter = "Excel文件|*.xlsx";
            saveDialog.FileName = saveFileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;

            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            FileStream file = new FileStream(saveFileName, FileMode.Create);
            book.Write(file);
            file.Close();
            book = null;
            ms.Close();
            ms.Dispose();
        }

        private void ChangeStyle(IWorkbook hssfworkbook, ISheet sheet)
        {
            int columnWidth = 0;
            IRow currentRow = null;
            ICell currentCell = null;
            int length = 0;
            for (int columnNum = 0; columnNum <= sheet.GetRow(0).LastCellNum + 12; columnNum++) //columnNum为列的数量
            {
                columnWidth = sheet.GetColumnWidth(columnNum) / 256; //获取当前列宽度
                for (int rowNum = 0; rowNum <= sheet.LastRowNum; rowNum++) //在这一列上循环行
                {
                    currentRow = sheet.GetRow(rowNum);
                    if (currentRow != null)
                    {
                        currentCell = currentRow.GetCell(columnNum);
                        if (currentCell != null)
                        {
                            length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            //单元格的宽度
                            if (columnWidth < length + 1)
                            {
                                columnWidth = length + 1;
                            }
                            //若当前单元格内容宽度大于列宽，则调整列宽为当前单元格宽度，后面的+1是我人为的操作
                        }
                    }
                }
                if (columnWidth > 255)
                {
                    columnWidth = 255;//由于最大宽度是255，所以这里需要判断下，否则会报错
                }
                sheet.SetColumnWidth(columnNum, columnWidth * 256);//设置最终宽度
            }
        }
    }
}
