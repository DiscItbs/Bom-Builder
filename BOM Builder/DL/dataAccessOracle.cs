using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace BOM_Builder.DL
{
   public class DataAccessOracle
   {
      #region VARIABLES GLOBALES

      private string connectionORACLE = ConfigurationSettings.AppSettings.Get("connectionORACLE");
      protected internal string strCadenaSQL = "";
      private OracleDataAdapter oDataAdapter = new OracleDataAdapter();
      private OracleDataReader oDataReader;
      private OracleConnection _Conexion;
      private OracleTransaction objTransaccion;
      private bool useTransaccion = false;
      private bool _isTransaction = false;
      public string cadConexionGenerica = ConfigurationSettings.AppSettings.Get("connectionORACLE");
      public string BaseDatos = null;

      #endregion

      /// <summary>
      /// 
      /// </summary>
      public bool isTransaction
      {
         get { return _isTransaction; }
         set { _isTransaction = value; }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public OracleConnection Conexion()
      {
         if (_Conexion == null)
         {
            _Conexion = new OracleConnection(cadenaConexion());
         }

         if (_Conexion.State == ConnectionState.Closed)
         {
            _Conexion.Open();
         }

         return _Conexion;
      }

      /// <summary>
      /// 
      /// </summary>
      public void cerrarConexion()
      {
         try
         {
            if (_Conexion.State != ConnectionState.Closed)
            {
               rollbackTransaction();
            }
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="tempBaseDatos"></param>
      public void switchConexion(string tempBaseDatos)
      {
         if (_Conexion != null)
         {
            _Conexion.Close();
            _Conexion = null;
         }

         BaseDatos = tempBaseDatos;
      }

      /// <summary>
      /// 
      /// </summary>
      public void iniciarTransaccion()
      {
         if (isTransaction)
         {
            throw new Exception("Ya hay una transacción activa");
         }
         else
         {
            OracleConnection cn = Conexion();
            objTransaccion = cn.BeginTransaction();
            isTransaction = true;
         }
      }

      /// <summary>
      /// 
      /// </summary>
      public void commitTransaction()
      {
         if (isTransaction == false)
         {
            throw new Exception("No hay una transacción activa");
         }
         else
         {
            objTransaccion.Commit();
            isTransaction = false;
            objTransaccion = null;
            _Conexion.Close();
            _Conexion = null;
         }
      }

      /// <summary>
      /// 
      /// </summary>
      private void rollbackTransaction()
      {
         objTransaccion.Rollback();
         isTransaction = false;
         objTransaccion = null;
         _Conexion.Close();
         OracleConnection.ClearPool(_Conexion); //Libera el pool del iis
         _Conexion.Dispose();
         _Conexion = null;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public object ExecuteEscalar()
      {
         object objScalar = null;
         OracleCommand oCommand = new OracleCommand();

         try
         {
            oCommand.CommandType = CommandType.Text;

            if (isTransaction == true)
            {
               oCommand.Connection = this.objTransaccion.Connection;
               oCommand.Transaction = this.objTransaccion;
               oCommand.CommandText = strCadenaSQL;
               oCommand.CommandTimeout = 5000;
               objScalar = oCommand.ExecuteScalar();
            }
            else
            {
               oCommand.Connection = this.Conexion();
               oCommand.CommandText = strCadenaSQL;
               oCommand.CommandTimeout = 5000;
               objScalar = oCommand.ExecuteScalar();
               this.cerrarConexion();
            }

            if ((oCommand != null))
            {
               oCommand.Dispose();
               GC.Collect();
            }

            return objScalar;
         }
         catch (Exception ex)
         {
            if (!isTransaction)
            {
               this.cerrarConexion();
            }

            throw new Exception("Error al Ejecutar el Commnado ExecuteEscalar  , " + ex.Message);
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="SP"></param>
      /// <param name="parametros"></param>
      /// <returns></returns>
      public int funConsultaSQLSPScalar(string SP, ArrayList parametros)
      {
         try
         {
            OracleCommand oCommand = new OracleCommand(SP);
            oCommand.CommandType = CommandType.StoredProcedure;

            if (isTransaction == true)
            {
               oCommand.Connection = this.objTransaccion.Connection;
               oCommand.Transaction = this.objTransaccion;
            }
            else
            {
               oCommand.Connection = Conexion();
            }

            oCommand.CommandTimeout = 5000;

            for (int i = 0; i <= parametros.Count - 1; i++)
            {
               oCommand.Parameters.Add(parametros[i]);
            }

            return Convert.ToInt32(oCommand.ExecuteScalar());
         }
         catch (Exception ex)
         {
            if (!isTransaction)
            {
               rollbackTransaction();
            }

            throw new Exception("Error al Ejecutar la Consulta , " + ex.Message);
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="SP"></param>
      /// <param name="parametros"></param>
      /// <returns></returns>
      public OracleDataReader funConsultaSQLSP(string SP, ArrayList parametros)
      {
         try
         {
            OracleCommand oCommand = new OracleCommand(SP);
            oCommand.CommandType = CommandType.StoredProcedure;

            if (isTransaction == true)
            {
               oCommand.Connection = this.objTransaccion.Connection;
               oCommand.Transaction = this.objTransaccion;
            }
            else
            {
               oCommand.Connection = Conexion();
            }

            oCommand.CommandTimeout = 5000;

            for (int i = 0; i <= parametros.Count - 1; i++)
            {
               oCommand.Parameters.Add(parametros[i]);
            }

            oDataReader = oCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return oDataReader;
         }
         catch (Exception ex)
         {
            if (!isTransaction)
            {
               rollbackTransaction();
            }

            throw new Exception("Error al Ejecutar la Consulta , " + ex.Message);
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="strSQL"></param>
      /// <param name="dtResultado"></param>
      public void ConsultaSQL(string strSQL, ref DataTable dtResultado)
      {
         OracleDataAdapter oDataAdapter = new OracleDataAdapter();
         OracleCommand oCommand = new OracleCommand(strSQL);
         DataSet oDs = new DataSet();

         try
         {
            oCommand.CommandType = CommandType.Text;

            if (isTransaction == true)
            {
               oCommand.Connection = this.objTransaccion.Connection;
               oCommand.CommandTimeout = 5000;
               oCommand.Transaction = this.objTransaccion;
               oDataAdapter.SelectCommand = oCommand;
               oDs.Tables.Add("TableData");
               oDs.EnforceConstraints = false;
               oDs.Tables["TableData"].BeginLoadData();
               oDataAdapter.Fill(oDs.Tables["TableData"]);
               oDs.Tables["TableData"].EndLoadData();
               dtResultado = oDs.Tables["TableData"];
            }
            else
            {
               oCommand.Connection = Conexion();
               oCommand.CommandTimeout = 5000;
               oDataAdapter.SelectCommand = oCommand;
               oDs.Tables.Add("TableData");
               oDs.EnforceConstraints = false;
               oDs.Tables["TableData"].BeginLoadData();
               oDataAdapter.Fill(oDs.Tables["TableData"]);
               oDs.Tables["TableData"].EndLoadData();
               dtResultado = oDs.Tables["TableData"];
               this.cerrarConexion();
            }
         }
         catch (Exception ex)
         {
            throw new Exception("Error al Ejecutar la Consulta , " + ex.Message);
         }
         finally
         {
            oDs.Dispose();

            if ((oDataAdapter != null))
            {
               oDataAdapter.Dispose();
               oCommand.Dispose();
               GC.Collect();
            }
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      protected internal OracleDataReader funConsultaSQL()
      {
         try
         {
            OracleCommand oCommand = new OracleCommand(strCadenaSQL);
            oCommand.CommandType = CommandType.Text;
            oCommand.Connection = Conexion();
            oCommand.CommandTimeout = 5000;
            oCommand.Transaction = this.objTransaccion;
            oDataReader = oCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return oDataReader;
         }
         catch (OracleException ex)
         {
            MessageBox.Show(ex.Message);
            rollbackTransaction();
            throw new Exception(ex.Message);
         }
         finally
         {
            if ((oDataReader != null))
            {
               GC.Collect();
            }
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      protected internal int funGuardarSQL()
      {
         try
         {
            int recAfectados = 0;
            OracleCommand oCommand = new OracleCommand(strCadenaSQL);

            oCommand.CommandType = CommandType.Text;
            oCommand.Connection = Conexion();
            oCommand.CommandTimeout = 5000;
            oCommand.CommandText = strCadenaSQL;
            oCommand.Transaction = objTransaccion;
            recAfectados = (int)oCommand.ExecuteScalar();

            if ((oCommand != null))
            {
               oCommand.Dispose();
               GC.Collect();
            }

            return recAfectados;
         }
         catch (Exception ex)
         {
            rollbackTransaction();
            throw new Exception(ex.Message);
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="Accion"></param>
      /// <returns></returns>
      protected internal decimal funGuardarSQL(bool Accion)
      {
         try
         {
            decimal recAfectados = 0;
            OracleCommand oCommand = new OracleCommand(strCadenaSQL);
            oCommand.CommandType = CommandType.Text;
            oCommand.Connection = Conexion();
            oCommand.CommandTimeout = 5000;
            oCommand.CommandText = strCadenaSQL;
            oCommand.Transaction = objTransaccion;

            if (Accion == true)
            {
               recAfectados = (decimal)oCommand.ExecuteScalar();
            }
            else
            {
               oCommand.ExecuteScalar();
            }

            if ((oCommand != null))
            {
               oCommand.Dispose();
               GC.Collect();
            }

            return recAfectados;
         }
         catch (Exception ex)
         {
            rollbackTransaction();
            throw new Exception(ex.Message);
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public string cadenaConexion()
      {
         if (this.BaseDatos == null)
         {
            return this.connectionORACLE;
         }
         else
         {
            string temp = this.cadConexionGenerica;
            return temp;
         }
      }
   }
}
