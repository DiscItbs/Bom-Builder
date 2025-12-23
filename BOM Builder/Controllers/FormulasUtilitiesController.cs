using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOM_Builder.Controllers
{
    public class FormulasUtilitiesController
    {
        SQLServer sql = new SQLServer();
        public void UpdateFormulasFromCombo(string condCantidad, string condMedida, string formCantidad,
                                            string formMedida, string formTotal, string formPeso, NM_Detalle_Combinacion_Componentes_FormulasModel currentEdit,
                                            string idCombinacion, string idDetalleComp, string seccion, string linea, string descripcion)
        {
            string update = string.Empty;

            string condicionalQty = condCantidad;
            string condicionalMd = condMedida;
            string formulaQty = formCantidad;
            string formulaMd = formMedida;
            string formulaTotal = formTotal;
            string formulaPeso = formPeso;
            string id = string.Empty;
            int opt = 1;

            if (!string.IsNullOrEmpty(condicionalQty) && !string.IsNullOrEmpty(formulaQty))
            {
                MessageBox.Show("Solo puede seleccionarse una formula o condicional en el calculo de cantidad");
            }
            else if (!string.IsNullOrEmpty(condicionalMd) && !string.IsNullOrEmpty(formulaMd))
            {
                MessageBox.Show("Solo puede seleccionarse una formula o condicional en el calculo de la medida");
            }
            else
            {
                while (opt < 6)
                {
                    switch (opt)
                    {
                        case 1:
                            //CONDICIONALES
                            if (!string.Equals(condicionalQty, currentEdit.NombreCondicionalQty))
                            {
                                if (!string.IsNullOrEmpty(condicionalQty) && !string.Equals(condicionalQty, "** CONDICIONALES MASTER **") && !string.Equals(condicionalQty, "** CONDICIONALES SIMPLES **"))
                                {
                                    id = FindIdByName(condicionalQty, "Condicional");
                                    string[] split = id.Split('|');
                                    //Condicional Simple
                                    if (string.Equals(split[1], "Condicional"))
                                    {
                                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaQty = '0', IdCompuestoQty = '',IdCondicionalQty = '{0}'," +
                                                               " TypeConditionalQty = 'C', Seccion = '{1}', Linea = '{2}', Descripcion = '{3}' WHERE IdCombinacion = '{4}' AND IdDetalleComp = '{5}'",
                                                               split[0],seccion,linea,descripcion, idCombinacion, idDetalleComp);
                                    }
                                    //Condicional Master
                                    else
                                    {
                                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaQty = '0', IdCondicionalQty = '{0}', TypeConditionalQty = 'M', " +
                                                               "IdCompuestoQty = '{1}', Seccion = '{2}', Linea = '{3}', Descripcion = '{4}' WHERE IdCombinacion = '{5}' AND IdDetalleComp = '{6}'", 
                                                               split[0], split[1], seccion, linea, descripcion, idCombinacion, idDetalleComp);
                                    }

                                    sql.ExecuteQuery(update);
                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdCondicionalQty = '0', TypeConditionalQty = '', " +
                                                                   "IdCompuestoQty = '', Seccion = '{0}', Linea = '{1}', Descripcion = '{2}' WHERE IdCombinacion = '{3}' AND IdDetalleComp = '{4}'",
                                                                   seccion, linea, descripcion, idCombinacion, idDetalleComp);
                                    sql.ExecuteQuery(update);
                                }
                            }
                            opt++;
                            break;

                        case 2:
                            if (!string.Equals(condicionalMd, currentEdit.NombreCondicionalMd))
                            {
                                if (!string.IsNullOrEmpty(condicionalMd) && !string.Equals(condicionalQty, "** CONDICIONALES MASTER **") && !string.Equals(condicionalQty, "** CONDICIONALES SIMPLES **"))
                                {
                                    id = FindIdByName(condicionalMd, "Condicional");
                                    string[] split = id.Split('|');
                                    if (string.Equals(split[1], "Condicional"))
                                    {
                                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaMd = '0', IdCompuestoMd = '',IdCondicionalMd = '{0}'," +
                                                               " TypeConditionalMd = 'C', Seccion = '{1}', Linea = '{2}', Descripcion = '{3}' WHERE IdCombinacion = '{4}' AND IdDetalleComp = '{5}'",
                                                               split[0], seccion, linea, descripcion, idCombinacion, idDetalleComp);
                                    }
                                    else
                                    {
                                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaMd = '0', IdCondicionalMd = '{0}', TypeConditionalMd = 'M', IdCompuestoMd = '{1}', " +
                                                               "Seccion = '{2}', Linea = '{3}', Descripcion = '{4}' WHERE IdCombinacion = '{5}' AND IdDetalleComp = '{6}'",
                                                               split[0], split[1], seccion, linea, descripcion, idCombinacion, idDetalleComp);
                                    }

                                    sql.ExecuteQuery(update);
                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdCondicionalMd = '0', TypeConditionalMd = '', IdCompuestoMd = '0', " +
                                                           "Seccion = '{0}', Linea = '{1}', Descripcion = '{2}' WHERE IdCombinacion = '{3}' AND IdDetalleComp = '{4}'", seccion, linea, descripcion, idCombinacion, idDetalleComp);
                                }
                            }
                            opt++;
                            break;

                        case 3:
                            //FORMULAS
                            if (!string.Equals(formulaQty, currentEdit.NombreFormulaQty))
                            {
                                if (!string.IsNullOrEmpty(formulaQty))
                                {
                                    id = FindIdByName(formulaQty, "Formula");
                                    string[] split = id.Split('|');
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdCompuestoQty = '',IdCondicionalQty = '0'," +
                                                           " TypeConditionalQty = '', IdFormulaQty = '{0}', Seccion = '{1}', Linea = '{2}', Descripcion = '{3}'" +
                                                           " WHERE IdCombinacion = '{4}' AND IdDetalleComp = '{5}'", split[0], seccion, linea, descripcion, idCombinacion, idDetalleComp);
                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaQty = '0', Seccion = '{0}', Linea = '{1}', Descripcion = '{2}'" +
                                                           " WHERE IdCombinacion = '{3}' AND IdDetalleComp = '{4}'", seccion, linea, descripcion, idCombinacion, idDetalleComp);

                                }
                                sql.ExecuteQuery(update);
                            }
                            if (!string.Equals(formulaMd, currentEdit.NombreFormulaMd))
                            {
                                if (!string.IsNullOrEmpty(formulaMd))
                                {
                                    id = FindIdByName(formulaMd, "Formula");
                                    string[] split = id.Split('|');
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdCondicionalMd = '0', IdCompuestoMd = '' ," +
                                                           " TypeConditionalMd = '', IdFormulaMd = '{0}', Seccion = '{1}', Linea = '{2}', Descripcion = '{3}'" +
                                                           " WHERE IdCombinacion = '{4}' AND IdDetalleComp = '{5}'", split[0], seccion, linea, descripcion, idCombinacion, idDetalleComp);
                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaMd = '0', Seccion = '{0}', Linea = '{1}', Descripcion = '{2}'" +
                                                           " WHERE IdCombinacion = '{3}' AND IdDetalleComp = '{4}'", seccion, linea, descripcion, idCombinacion, idDetalleComp);

                                }

                                sql.ExecuteQuery(update);
                            }
                            if (!string.Equals(formulaPeso, currentEdit.NombreFormulaPeso))
                            {
                                if (!string.IsNullOrEmpty(formulaPeso))
                                {
                                    id = FindIdByName(formulaPeso, "Formula");
                                    string[] split = id.Split('|');
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET  IdFormulaPeso = '{0}', Seccion = '{1}', Linea = '{2}', Descripcion = '{3}'" +
                                                           " WHERE IdCombinacion = '{4}' AND IdDetalleComp = '{5}'", split[0], seccion, linea, descripcion, idCombinacion, idDetalleComp);
                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaPeso = '0', Seccion = '{0}', Linea = '{1}', Descripcion = '{2}'" +
                                                           " WHERE IdCombinacion = '{3}' AND IdDetalleComp = '{4}'", seccion, linea, descripcion, idCombinacion, idDetalleComp);

                                }

                                sql.ExecuteQuery(update);
                            }
                            opt++;
                            break;

                        case 4:
                            //TOTAL
                            if (!string.Equals(formulaTotal, currentEdit.NombreFormulaTotal))
                            {
                                if (!string.IsNullOrEmpty(formulaTotal))
                                {
                                    id = FindIdByName(formulaTotal, "Formula");
                                    string[] split = id.Split('|');
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaTotal = '{0}',Seccion = '{1}', Linea = '{2}', Descripcion = '{3}'" +
                                                           " WHERE IdCombinacion = '{4}' AND IdDetalleComp = '{5}'", split[0], seccion, linea, descripcion, idCombinacion, idDetalleComp);

                                    sql.ExecuteQuery(update);
                                }
                            }
                            opt++;
                            break;

                        case 5:
                            // SECCION, LINEA Y DESCRIPCION
                            if(!string.Equals(seccion,currentEdit.Seccion))
                            {
                                 update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET Seccion = '{0}' " +
                                                               " WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", seccion, idCombinacion, idDetalleComp);

                                 sql.ExecuteQuery(update);
                            }

                            if (!string.Equals(linea, currentEdit.Linea))
                            {
                                 update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET Linea = '{0}' " +
                                                               " WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", linea, idCombinacion, idDetalleComp);

                                 sql.ExecuteQuery(update);
                            }

                            if (!string.Equals(descripcion, currentEdit.Descripcion))
                            {
                                update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET Descripcion = '{0}' " +
                                                               " WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", descripcion, idCombinacion, idDetalleComp);

                                sql.ExecuteQuery(update);
                            }

                            opt++;
                            break;
                    }
                }
            }

        }

        public bool IsMaster(string nameCondicional)
        {
            List<NM_CondicionalMaster> masters = sql.GetMasterCondicional();
            NM_CondicionalMaster master = masters.Find(x => x.Nombre == nameCondicional);

            if (master!=null)
            {
                return true;
            }

            return false;
        }
        public string FindIdByName(string name, string type)
        {
            string id = string.Empty;
            List<string> aux = new List<string>();
            List<int> auxInt = new List<int>();
            NM_CondicionalMaster cond = new NM_CondicionalMaster();

            if (string.Equals(type, "Condicional"))
            {
                List<NM_CondicionalMaster> master = sql.GetMasterCondicional();
                List<NM_Condicional> condicionales = sql.GetCondicionales();
                aux = (from condicional in condicionales where condicional.NombreCondicional == name select condicional.Id.ToString()).ToList();

                if (aux.Count > 0)
                {
                    id = aux[0];
                    id += "|Condicional";
                }
                else
                {
                    cond = (from condicional in master where condicional.Nombre == name select condicional).ToList()[0];
                    id = cond.IdCondicionalMaster + "|" + cond.IdCompuesto + "|CondicionalMaster";
                }
            }
            else
            {
                List<NM_Formula> formulas = sql.GetGeneralFormulas("SELECT * from NM_Formulas");
                id = (from formula in formulas where formula.NombreFormula == name select formula.Id).ToList()[0].ToString();
                id += "|Formula";
            }

            return id;
        }

        public void ShowFormula(string nombreComponente, TextBox tb)
        {
            if (!string.IsNullOrEmpty(nombreComponente))
            {
                string QUERY = string.Format("SELECT Formula FROM NM_Formulas WHERE NombreFormula = '{0}'", nombreComponente);
                string formula = sql.Select(QUERY, "Formula");
                tb.Text = formula;
            }
        }

        public void ShowCondicional(string nameCondicional, TreeView tree)
        {
            if (!string.IsNullOrEmpty(nameCondicional))
            {
                bool isMaster = IsMaster(nameCondicional);
                string id = FindIdByName(nameCondicional, "Condicional");
                string[] split = id.Split('|');

                if (!isMaster)
                {
                    NM_Condicional condicional = sql.GetCondicional(split[0]);
                    tree.Nodes.Clear();
                    AddRootBack(condicional, tree);
                }
                else
                {
                    GetCondicionalesFromMaster(split[0], nameCondicional, tree);
                }
            }
        }

        public TreeNode AddRootBack(NM_Condicional condicional, TreeView tree)
        {
            tree.Nodes.Add("Raiz", "Raiz - " + condicional.Condicional);
            TreeNode raiz = tree.Nodes[0];
            NM_CondicionalMaster master = new NM_CondicionalMaster();
            raiz.Tag = condicional.Id;
            raiz.ForeColor = Color.Blue;
            raiz.Name = "Raiz - " + condicional.Condicional;
            raiz.Nodes.Add("Verdadero", "Verdadero");
            raiz.Nodes.Add("Falso", "Falso");

            TreeNode verdadero = raiz.Nodes[0];
            verdadero.ForeColor = Color.Green;
            TreeNode falso = raiz.Nodes[1];
            falso.ForeColor = Color.Red;

            verdadero.Nodes.Add(condicional.Verdadero);
            falso.Nodes.Add(condicional.Falso);

            TreeNode valorVerdadero = verdadero.Nodes[0];
            TreeNode valorFalso = falso.Nodes[0];

            raiz.ExpandAll();
            return raiz;
        }

        public TreeNode AddNodoCondicionalBack(TreeNode node, NM_Condicional condicional)
        {
            if (node.Nodes.Count > 0)
            {
                node.Nodes.Remove(node.FirstNode);
            }
            node.Nodes.Add("Condicional - " + condicional.Condicional);
            TreeNode nodoCondicional = node.FirstNode;
            nodoCondicional.Tag = "Condicional";
            TreeNode verdadero = new TreeNode();
            TreeNode falso = new TreeNode();
            nodoCondicional.ForeColor = Color.Blue;
            nodoCondicional.Nodes.Add("Verdadero");
            nodoCondicional.Nodes.Add("Falso");
            nodoCondicional.Name = "Condicional - " + condicional.Condicional;

            verdadero = nodoCondicional.Nodes[0];
            falso = nodoCondicional.Nodes[1];

            verdadero.ForeColor = Color.Green;
            falso.ForeColor = Color.Red;

            verdadero.Nodes.Add(condicional.Verdadero);
            falso.Nodes.Add(condicional.Falso);
            return nodoCondicional;
        }

        public TreeNode AddNodoFormulaBack(TreeNode node, NM_Formula formula)
        {
            NM_CondicionalMaster master = new NM_CondicionalMaster();
            if (node.Nodes.Count > 0)
            {
                node.Nodes.Remove(node.Nodes[0]);
            }
            node.Nodes.Add("Formula");
            TreeNode Nodotipo = node.Nodes[0];

            Nodotipo.Tag = formula.Id + "|Formula";
            Nodotipo.Name = formula.Id + "|Formula";
            Nodotipo.ForeColor = Color.Blue;
            Nodotipo.Nodes.Add(formula.Formula);
            return Nodotipo;
        }

        public string FindNodoPadre(string fullPath)
        {
            string[] split = fullPath.Split('\\');
            return split[split.Count() - 3];
        }

        public void GetCondicionalesFromMaster(string idMaster, string nameCondicional, TreeView tree)
        {
            NM_CondicionalMaster _master = sql.GetCondicionalMasterById(idMaster, nameCondicional);
            List<NM_CondicionalMaster> masters = sql.GetElementsMasterCondicional(idMaster, _master.IdCompuesto, _master.Nombre).OrderBy(x => x.Nivel).ToList();
            List<NM_Condicional> condicionales = new List<NM_Condicional>();
            List<NM_CondicionalMaster> mastersAux = new List<NM_CondicionalMaster>();
            NM_Formula formula;
            TreeNode[] arrayMaster = new TreeNode[] { };
            NM_Condicional condicional;
            TreeNode _base = new TreeNode();
            TreeNode currentNode = new TreeNode();
            TreeNode Verdadero = new TreeNode();
            TreeNode Falso = new TreeNode();
            TreeNode nodoAuxiliar = new TreeNode();
            List<TreeNode> listas = new List<TreeNode>();
            TreeNode[] auxiliares = new TreeNode[] { };
            int level = 2;
            string nodoPadre = string.Empty;

            tree.Nodes.Clear();

            foreach (var master in masters)
            {
                if (string.Equals(master.Tipo, "Raiz"))
                {
                    condicional = new NM_Condicional();
                    condicional = sql.GetCondicional(master.IdElemento.ToString());
                    currentNode = AddRootBack(condicional, tree);
                    _base = currentNode;
                    Verdadero = currentNode.FirstNode;
                    Falso = currentNode.LastNode;
                    master.IsUsed = true;
                }
                else if (string.Equals(master.Tipo, "Condicional"))
                {
                    if (string.Equals(master.Posicion, "Verdadero"))
                    {
                        condicional = new NM_Condicional();
                        condicional = sql.GetCondicional(master.IdElemento.ToString());

                        if (!string.IsNullOrEmpty(master.NodoPadre))
                        {
                            auxiliares = tree.Nodes.Find(master.NodoPadre, true);
                            if(auxiliares.Length>0)
                            {
                                nodoAuxiliar = auxiliares[0];
                                AddNodoCondicionalBack(nodoAuxiliar.FirstNode, condicional);
                            }
                        }
                        else
                        {
                            nodoAuxiliar = AddNodoCondicionalBack(Verdadero, condicional);
                            mastersAux = (from list in masters where list.IsUsed == false && list.Nivel.ToString() == level.ToString() select list).ToList();
                            if (mastersAux.Count > 0)
                            {
                                Verdadero = currentNode.FirstNode;
                                Falso = currentNode.LastNode;
                            }
                            else
                            {
                                Verdadero = nodoAuxiliar.FirstNode;
                                Falso = nodoAuxiliar.LastNode;
                                level += 2;
                            }
                        }
                        master.IsUsed = true;

                    }
                    else
                    {
                        condicional = new NM_Condicional();
                        condicional = sql.GetCondicional(master.IdElemento.ToString());

                        if (!string.IsNullOrEmpty(master.NodoPadre))
                        {
                            auxiliares = tree.Nodes.Find(master.NodoPadre, true);
                            if(auxiliares.Length>0)
                            {
                                nodoAuxiliar = auxiliares[0];
                                AddNodoCondicionalBack(nodoAuxiliar.LastNode, condicional);
                            }
                        }
                        else
                        {
                            nodoAuxiliar = AddNodoCondicionalBack(Falso, condicional);
                            mastersAux = (from list in masters where list.IsUsed == false && list.Nivel.ToString() == level.ToString() select list).ToList();
                            if (mastersAux.Count > 0)
                            {
                                Verdadero = currentNode.FirstNode;
                                Falso = currentNode.LastNode;
                            }
                            else
                            {
                                Verdadero = nodoAuxiliar.FirstNode;
                                Falso = nodoAuxiliar.LastNode;
                                level += 2;
                            }
                        }
                        master.IsUsed = true;
                    }
                }
                else
                {
                    formula = sql.GetFormula(master.IdElemento.ToString());

                    if (string.Equals(master.Posicion, "Verdadero"))
                    {
                        AddNodoFormulaBack(Verdadero, formula);
                    }
                    else
                    {
                        AddNodoFormulaBack(Falso, formula);
                    }
                }
                _base.ExpandAll();
            }
        }
    }
}
