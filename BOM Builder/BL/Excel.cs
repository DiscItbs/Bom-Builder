using BOM_Builder.DL;
using ExcelDataReader;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BOM_Builder.Controllers
{
    public class Excel
    {
        DataAccessSQL dataAccessSQL = new DataAccessSQL();
        private readonly string _BaseDatos = null;

        public Workbook ReadExcel(string path)
        {
            Workbook workbook = new Workbook();
            try
            {
                workbook.LoadFromFile(path);
                return workbook;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public string ReadCell(Worksheet sheet, int row, int column)
        {
            try
            {
                return sheet.Rows[row].Columns[column].DisplayedText;
            }
            catch (Exception e)
            {
                string message = e.Message;
            }

            return null;
        }

        public int GetLastRow(Worksheet worksheet)
        {
            int rows = 1;
            int count = 0;
            //while (true)
            //{
            //    string value = ReadCell(worksheet, rows, 0);

            //    if (value == "")
            //    {
            //        break;
            //    }

            //    rows++;
            //    count = count + 1;
            //}

            string error = string.Empty;
            decimal affected = 0;
            bool is_inserted = false;

            try
            {
                dataAccessSQL.switchConexion(_BaseDatos);
                dataAccessSQL.iniciarTransaccion();

                while (true)
                {
                    dataAccessSQL.strCadenaSQL = "";

                    string value = ReadCell(worksheet, rows, 2);
                    string value1 = ReadCell(worksheet, rows, 3);
                    string value2 = ReadCell(worksheet, rows, 4);
                    string value3 = ReadCell(worksheet, rows, 5);
                    string value4 = ReadCell(worksheet, rows, 6);
                    string value5 = ReadCell(worksheet, rows, 8);
                    string value6 = ReadCell(worksheet, rows, 9);
                    string value7 = ReadCell(worksheet, rows, 10);

                    dataAccessSQL.strCadenaSQL =  @"
                INSERT INTO NM_TempData ([Itemno], [Class], [Largo], [Ancho], [Acabado], [Rev], [Descrip1], [Descrip2]) VALUES('" + value + "', '" + value1 + "', '" + value2 + "', '" + value3 + "', '" + value4 + "', '" + value5 + "', '" + value6 + "', '" + value7 + "')" + Environment.NewLine;

                    affected = dataAccessSQL.funGuardarSQL(false);

                    if (value == "")
                    {
                        break;
                    }

                    rows++;
                    count = count + 1;
                }

                //dataAccessSQL.strCadenaSQL = dataAccessSQL.strCadenaSQL + @"
                //INSERT INTO NM_TempData ([Itemno], [Class], [Largo], [Ancho], [Acabado], [Rev], [Descrip1], [Descrip2]) 
                //VALUES('', '', '', '', '', '', '', '')" + Environment.NewLine;

                //affected = dataAccessSQL.funGuardarSQL(false);
                dataAccessSQL.commitTransaction();

                if (affected != 0)
                {
                    is_inserted = false;
                }
                else
                {
                    is_inserted = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return rows;
        }
    }
}
