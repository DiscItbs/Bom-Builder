using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Builder.DL
{
    public class ModeladoDL : DataAccessSQL
    {
        private readonly string _BaseDatos = null;

        public List<ModeladoBomModel> GetBomModels(string modelComplete, string finish, out string errorMethod)
        {
            SqlDataReader data_reader = null;
            List<ModeladoBomModel> data_list = new List<ModeladoBomModel>();
            ModeladoBomModel data_model = new ModeladoBomModel();
            string error = string.Empty;

            try
            {
                switchConexion(_BaseDatos);
                strCadenaSQL = @"
                    SELECT DISTINCT
	                    T1.Id, T1.Combinacion_Bom AS Combinacion, T0.Id, T2.Itemno AS Itemno, T2.Class_IQMS AS Class, T2.Nombre_Componente AS NombreComponente, T3.Formula AS FormulaMd, T4.Formula AS FormulaQty, T5.Formula AS FormulaTotal, 
                        T0.IdCondicionalQty, T0.IdCondicionalMd, T10.Id AS IdCondicionalTotal, T0.TypeConditionalQty, T0.TypeConditionalMd, T0.IdCompuestoQty, T0.IdCompuestoMd, T8.NombreCondicional AS NombreMasterQty, T9.NombreCondicional AS NombreMasterMd,
                        T0.Seccion AS Seccion, T0.Linea AS Linea, T0.Descripcion, T0.IdFormulaPeso AS FormulaPeso
                    FROM 
	                    NM_Detalle_Combinacion_Componentes_Formulas AS T0 (NOLOCK)
	                    INNER JOIN NM_Combinaciones AS T1 (NOLOCK) ON T1.Id = T0.IdCombinacion
	                    --INNER JOIN NM_Detalle_Combinaciones_Componentes AS T2 (NOLOCK) ON T2.Id_Arinvt = T0.IdComponente AND T2.Id_Combinacion = T1.Id AND T2.Id_Combinacion = T0.IdCombinacion
	                    INNER JOIN NM_Detalle_Combinaciones_Componentes AS T2 (NOLOCK) ON T2.Id = T0.IdDetalleComp AND T2.Id_Combinacion = T1.Id AND T2.Id_Combinacion = T0.IdCombinacion
	                    LEFT JOIN NM_Formulas AS T3 (NOLOCK) ON T3.Id = T0.IdFormulaMd
	                    LEFT JOIN NM_Formulas AS T4 (NOLOCK) ON T4.Id = T0.IdFormulaQty
	                    LEFT JOIN NM_Formulas AS T5 (NOLOCK) ON T5.Id = T0.IdFormulaTotal
	                    LEFT JOIN NM_CondicionalMaster AS T6 (NOLOCK) ON T6.IdCondicionalMaster = T0.IdCondicionalQty
	                    LEFT JOIN NM_CondicionalMaster AS T7 (NOLOCK) ON T7.IdCondicionalMaster = T0.IdCondicionalMd
	                    LEFT JOIN NM_Condicionales AS T8 (NOLOCK) ON T8.Id = T0.IdCondicionalQty
	                    LEFT JOIN NM_Condicionales AS T9 (NOLOCK) ON T9.Id = T0.IdCondicionalMd
                        LEFT JOIN NM_Condicionales AS T10 (NOLOCK) ON T10.Id = T0.IdFormulaTotal
                    WHERE 
                        T1.Combinacion_Bom = '" + modelComplete + @"'
                        AND T1.Acabado = '" + finish + @"'
                    ORDER BY 
						T2.Itemno DESC";

                data_reader = funConsultaSQL();

                if (data_reader != null)
                {
                    while (data_reader.Read())
                    {
                        data_model = new ModeladoBomModel();
                        data_model.Combination = Convert.ToString(data_reader["Combinacion"]);
                        data_model.Class = Convert.ToString(data_reader["Class"]);
                        data_model.Itemno = Convert.ToString(data_reader["Itemno"]);
                        data_model.Nombre_Componente = Convert.ToString(data_reader["NombreComponente"]);
                        data_model.IdCondicionalQty = Convert.ToInt32(data_reader["IdCondicionalQty"]);
                        data_model.Type_ConditionalQty = Convert.ToString(data_reader["TypeConditionalQty"]);
                        data_model.Type_ConditionalMd = Convert.ToString(data_reader["TypeConditionalMd"]);
                        data_model.IdCompuestoMd = Convert.ToString(data_reader["IdCompuestoMd"]);
                        data_model.IdCompuestoQty = Convert.ToString(data_reader["IdCompuestoQty"]);
                        data_model.IdCondicionalMd = Convert.ToInt32(data_reader["IdCondicionalMd"]);

                        if (data_reader["FormulaMd"] != DBNull.Value)
                        {
                            data_model.FormulaMd = Convert.ToString(data_reader["FormulaMd"]);
                        }
                        else
                        {
                            data_model.FormulaMd = "";
                        }

                        if (data_reader["FormulaQty"] != DBNull.Value)
                        {
                            data_model.FormulaQty = Convert.ToString(data_reader["FormulaQty"]);
                        }
                        else
                        {
                            data_model.FormulaQty = "";
                        }

                        if (data_reader["FormulaTotal"] != DBNull.Value)
                        {
                            data_model.FormulaTotal = Convert.ToString(data_reader["FormulaTotal"]);
                        }
                        else
                        {
                            data_model.FormulaTotal = "";
                        }
                        if (data_reader["FormulaPeso"] != DBNull.Value)
                        {
                            data_model.FormulaPeso = Convert.ToString(data_reader["FormulaPeso"]);
                        }
                        else
                        {
                            data_model.FormulaPeso = "";
                        }

                        if (data_reader["IdCondicionalTotal"] != DBNull.Value)
                        {
                            data_model.IdCondicionalTotal = Convert.ToInt32(data_reader["IdCondicionalTotal"]);
                        }
                        else
                        {
                            data_model.IdCondicionalTotal = 0;
                        }

                        if (data_reader["NombreMasterQty"] != DBNull.Value)
                        {
                            data_model.NombreMasterQty = Convert.ToString(data_reader["NombreMasterQty"]);
                        }
                        else
                        {
                            data_model.NombreMasterQty = "";
                        }

                        if (data_reader["NombreMasterMd"] != DBNull.Value)
                        {
                            data_model.NombreMasterMd = Convert.ToString(data_reader["NombreMasterMd"]);
                        }
                        else
                        {
                            data_model.NombreMasterMd = "";
                        }
                        if (data_reader["Seccion"] != DBNull.Value)
                        {
                            data_model.Seccion = Convert.ToString(data_reader["Seccion"]);
                        }
                        else
                        {
                            data_model.Seccion = "";
                        }
                        if (data_reader["Linea"] != DBNull.Value)
                        {
                            data_model.Linea = Convert.ToInt32(data_reader["Linea"]);
                        }
                        else
                        {
                            data_model.Linea = 0;
                        }
                        if (data_reader["Descripcion"] != DBNull.Value)
                        {
                            data_model.Descripcion = Convert.ToString(data_reader["Descripcion"]);
                        }
                        else
                        {
                            data_model.Descripcion = "";
                        }

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
