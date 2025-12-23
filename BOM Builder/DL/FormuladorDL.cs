using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.DL
{
    public class FormuladorDL : DataAccessSQL
    {
        private readonly string _BaseDatos = null;

        public bool CreateFormulaQty(string nameFormula, string formula, out string errorMethod)
        {
            string error = string.Empty;
            decimal affect = 0;
            bool affected = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();

                strCadenaSQL = "INSERT INTO NM_FormulaQty ([Nombre_Formula], [Formula], [Fecha_Creacion]) VALUES ('" + nameFormula + "', '" + formula + "', GETDATE())";

                affect = funGuardarSQL(false);
                commitTransaction();

                if (affect != 0)
                {
                    affected = false;
                }
                else
                {
                    affected = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return affected;
        }

        public bool CreateFormulaMd(string nameFormula, string formula, out string errorMethod)
        {
            string error = string.Empty;
            decimal affect = 0;
            bool affected = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();

                strCadenaSQL = "INSERT INTO NM_FormulaMd ([Nombre_Formula], [Formula], [Fecha_Creacion]) VALUES ('" + nameFormula + "', '" + formula + "', GETDATE())";

                affect = funGuardarSQL(false);
                commitTransaction();

                if (affect != 0)
                {
                    affected = false;
                }
                else
                {
                    affected = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return affected;
        }

        public bool CreateFormulaTotal(string nameFormula, string formula, out string errorMethod)
        {
            string error = string.Empty;
            decimal affect = 0;
            bool affected = false;

            try
            {
                switchConexion(_BaseDatos);
                iniciarTransaccion();

                strCadenaSQL = "INSERT INTO NM_FormulaTotal ([Nombre_Formula], [Formula], [Fecha_Creacion]) VALUES ('" + nameFormula + "', '" + formula + "', GETDATE())";

                affect = funGuardarSQL(false);
                commitTransaction();

                if (affect != 0)
                {
                    affected = false;
                }
                else
                {
                    affected = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return affected;
        }

        public List<NM_Formula> GetListFormulas(out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<NM_Formula> data_list = new List<NM_Formula>();
            NM_Formula data_model = new NM_Formula();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);

                strCadenaSQL = "SELECT * FROM NM_Formulas ORDER BY NombreFormula ASC";

                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    data_model = new NM_Formula
                    {
                        Id = 0,
                        NombreFormula = "Seleccione una opción..."
                    };

                    data_list.Add(data_model);

                    while (data_reader.Read())
                    {
                        data_model = new NM_Formula
                        {
                            Id = Convert.ToInt32(data_reader["Id"]),
                            NombreFormula = Convert.ToString(data_reader["NombreFormula"]),
                            Formula = Convert.ToString(data_reader["Formula"]),
                            Tipo = Convert.ToString(data_reader["Tipo"])
                        };
                        data_list.Add(data_model);
                    }

                    data_reader.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                data_list = null;
            }

            errorMethod = error;
            return data_list;
        }
    }
}
