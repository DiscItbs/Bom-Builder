using BOM_Builder.Helpers;
using BOM_Builder.Models;
using BOM_Builder.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BOM_Builder.Controllers
{
  class SQLServer
  {
    private readonly string strConn = ConfigurationSettings.AppSettings.Get("connectionSQL");
    Conexion oracle = new Conexion();

    #region GET

    public string Select(string query, string data)
    {
      string value = "";

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = query;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                value = reader[data].ToString();
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return value;
    }

    public string GetPathLogs()
    {
      string GET_PATHLOGS = string.Format("SELECT Detalle FROM T_Configuracion WHERE Nombre_configuracion = 'Path logs'");

      return Select(GET_PATHLOGS, "Detalle");
    }

    public List<string> GetSectionFromModel(string model)
    {
      string GET_SECTION = string.Format("SELECT DISTINCT NM_Combinaciones.Id, NM_Detalle_Combinacion_Componentes_Formulas.Seccion " +
                                         "FROM NM_Combinaciones INNER JOIN NM_Detalle_Combinacion_Componentes_Formulas " +
                                         "ON NM_Combinaciones.Id = NM_Detalle_Combinacion_Componentes_Formulas.IdCombinacion " +
                                         "WHERE NM_Combinaciones.Combinacion_Bom = '{0}' and Seccion <> ''", model);

      return selectList(GET_SECTION, "Seccion");
    }



    public string GetNameDirectoryLogs()
    {
      string GET_DIRECTORY_LOGS = string.Format("SELECT Detalle From T_Configuracion WHERE Nombre_configuracion = 'Name directory logs'");

      return Select(GET_DIRECTORY_LOGS, "Detalle");
    }

    public bool Login(string user, string password)
    {
      //string pass = sys.hash(password);

      string GET_LOG = string.Format("SELECT User FROM T_User WHERE User = '{0}' AND Password = '{1}'", user, password);

      string _user = Select(GET_LOG, "User");

      if (_user.Equals(user))
      {
        return true;
      }

      return false;
    }

    public string GetRoll(string user)
    {
      string GET_ROLL = string.Format("SELECT Roll FROM T_User WHERE User = '{0}'", user);

      return Select(GET_ROLL, "Roll");
    }

    public List<NM_Formula> GetFormulasIn(List<string> ids)
    {
      string GET_IN = "SELECT * FROM NM_Formulas WHERE Id IN (";

      foreach (var id in ids)
      {
        GET_IN += id + ",";
      }

      GET_IN = GET_IN.Substring(0, GET_IN.Length - 1);

      GET_IN += ")";

      return GetGeneralFormulas(GET_IN);
    }

    public List<NM_Formula> GetFormulasLike(string columna, string dato)
    {
      string GET_LIKE = string.Format("SELECT * FROM NM_Formulas WHERE {0} LIKE '%{1}%'", columna, dato);

      return GetGeneralFormulas(GET_LIKE);
    }

    public List<NM_Formula> GetFormulasLikeTwoColumns(string columna1, string columna2, string dato)
    {
      string GET_LIKE = string.Format("SELECT * FROM NM_Formulas WHERE {0} LIKE '%{1}%' or {2} LIKE '%{1}%'", columna1, dato, columna2);

      return GetGeneralFormulas(GET_LIKE);
    }

    public List<NM_Condicional> GetCondicionalesLike(string columna, string dato)
    {
      string GET_LIKE = string.Format("SELECT * FROM NM_Condicionales WHERE {0} LIKE '%{1}%'", columna, dato);

      return GetGeneralCondicionales(GET_LIKE);
    }

    public List<NM_Condicional> GetCondicionalesLikeMoreColumns(List<string> columns, string dato)
    {
      string GET_LIKE = string.Format("SELECT * FROM NM_Condicionales WHERE {0} LIKE '%{1}%' or {2} LIKE '%{1}%' " +
                                      "or {3} LIKE '%{1}%' or {4} LIKE '%{1}%'",
                                      columns[0], dato, columns[1], columns[2], columns[3]);

      return GetGeneralCondicionales(GET_LIKE);
    }

    public NM_Formula GetFormula(string id)
    {
      string GET_FORMULA = string.Format("SELECT * FROM NM_Formulas WHERE Id = '{0}'", id);

      return GetGeneralFormulas(GET_FORMULA)[0];
    }

    public List<NM_Formula> GetGeneralFormulas(string query)
    {
      string GET_FORMULAS = string.Format("SELECT * FROM NM_Formulas");
      List<NM_Formula> formulas = new List<NM_Formula>();

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {

          conn.Open();
          cmd.CommandText = query;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                NM_Formula formula = new NM_Formula();
                formula.Id = Convert.ToInt32(reader["Id"]);
                formula.NombreFormula = reader["NombreFormula"].ToString();
                formula.Tipo = reader["Tipo"].ToString();
                formula.Formula = reader["Formula"].ToString();
                formula.FechaCreacion = reader["FechaCreacion"].ToString();
                formulas.Add(formula);
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return formulas;
    }

    public List<string> GetMasterCondicional(string masterCondicional)
    {
      string MASTER_CONDICIONAL = string.Format("SELECT IdCondicional FROM CondicionalesDetail" +
                                                " INNER JOIN Condicionales " +
                                                "ON CondicionalesDetail.IdCondicional = Condicionales.Id" +
                                                " WHERE IdMasterCondicional = '{0}'", masterCondicional);
      return selectList(MASTER_CONDICIONAL, "IdCondicional");
    }

    public NM_Condicional GetCondicional(string idCondicional)
    {
      string GET_CONDICIONAL = string.Format("SELECT * FROM NM_Condicionales WHERE Id = '{0}'", idCondicional);

      return GetGeneralCondicionales(GET_CONDICIONAL)[0];
    }

    public List<NM_CombinacionesModel> GetBoms()
    {
      List<NM_CombinacionesModel> boms = new List<NM_CombinacionesModel>();
      NM_CombinacionesModel bom;

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = "SELECT * FROM NM_Combinaciones where Acabado = 'AL'";
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                bom = new NM_CombinacionesModel();
                bom.Id = Convert.ToInt32(reader["Id"]);
                bom.Combinacion = reader["Combinacion_bom"].ToString();
                if (reader["Approved"] != DBNull.Value)
                  if (Convert.ToInt32(reader["Approved"]) == 1)
                    bom.Approved = true;
                  else
                    bom.Approved = false;
                else
                  bom.Approved = false;
                if (reader["Phantom"] != DBNull.Value)
                  if (Convert.ToInt32(reader["Phantom"].ToString()) == 1)
                    bom.Phantom = true;
                  else
                    bom.Phantom = false;
                else
                  bom.Phantom = false;

                boms.Add(bom);
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }
      return boms;
    }

    public async Task<List<NMSecuenciasDto>> GetNMSecuences()
    {
      var nMSecuencias = new List<NMSecuenciasDto>();

      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        cmd.CommandText = @"SELECT id, Descripcion, pk_hide FROM NM_Secuencias";
        cmd.CommandType = CommandType.Text;

        try
        {
          await conn.OpenAsync().ConfigureAwait(false);

          using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
          {
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
              nMSecuencias.Add(new NMSecuenciasDto
              {
                ID = reader.GetDecimal(reader.GetOrdinal("id")),
                Descripcion = NotNullHelper.NotNullString(reader["Descripcion"]).Trim(),
                PKHide = NotNullHelper.NotNullString(reader["pk_hide"]).Trim()
              });
            }
          }
        }
        catch (SqlException ex)
        {
          throw new Exception("Error trying to obtain NM_Secuencias", ex);
        }
      }

      return nMSecuencias;
    }

    public async Task<List<FamilysDto>> GetFamilys()
    {
      var familys = new List<FamilysDto>();

      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        cmd.CommandText = @"Select id, Nombre_Familia From NM_Familias";
        cmd.CommandType = CommandType.Text;
        try
        {
          await conn.OpenAsync().ConfigureAwait(false);
          using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
          {
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
              familys.Add(new FamilysDto
              {
                ID = reader.GetInt32(reader.GetOrdinal("id")),
                Nombre = NotNullHelper.NotNullString(reader["Nombre_Familia"]).Trim()
              });
            }
          }
          return familys;
        }
        catch (SqlException ex)
        {
          throw new Exception("Error trying to get families", ex);
        }
      }
    }



    public async Task<List<SecuenceDetailSecuence>> GetSecuenceDetailSecuences()
    {
      var secuencesDetailSecuence = new List<SecuenceDetailSecuence>();

      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        cmd.CommandText = @"
          SELECT id, Secuencias_id, familia_id, Sec_det_id, Bom_Seq
          FROM NM_Secuencia_Detalle_secuencia";
        cmd.CommandType = CommandType.Text;

        try
        {
          await conn.OpenAsync().ConfigureAwait(false);

          using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
          {
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
              secuencesDetailSecuence.Add(new SecuenceDetailSecuence
              {
                ID = reader.GetInt32(reader.GetOrdinal("id")),
                Secuencia = await GetSequence(reader.GetInt32(reader.GetOrdinal("Secuencias_id"))).ConfigureAwait(false),
                Familia = await GetFamily(reader.GetInt32(reader.GetOrdinal("familia_id"))).ConfigureAwait(false),
                Proceso = await GetProceso(reader.GetInt32(reader.GetOrdinal("Sec_det_id"))).ConfigureAwait(false),
                PosBom = reader.GetInt32(reader.GetOrdinal("Bom_seq")).ToString(),
                
              });
            }
          }
        }
        catch (SqlException ex)
        {
          Console.WriteLine(ex.Message);
          throw;
        }
      }
      return secuencesDetailSecuence;
    }

    private async Task<string> GetFamily(int familyId)
    {

      return await GetStringFromQuery(
        @"SELECT Nombre_Familia 
        FROM NM_Familias 
        WHERE id = @familyId",
        "@familyId",
        familyId
        );
    }

    private async Task<string> GetSequence(int sequenceId)
    {
      return await GetStringFromQuery(
          @"SELECT Descripcion 
          FROM NM_Secuencias 
          WHERE id = @sequenceId",
          "@sequenceId",
          sequenceId
      );
    }

    private async Task<string> GetProceso(int processId)
    {
      return await GetStringFromQuery(
          @"SELECT Detalle_Secuencias 
          FROM NM_Detalle_Secuencias 
          WHERE id = @processId",
          "@processId",
          processId
      );
    }

    private async Task<string> GetStringFromQuery(
        string query,
        string parameterName,
        int parameterValue)
    {
      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        cmd.CommandText = query;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(parameterName, SqlDbType.Int).Value = parameterValue;

        await conn.OpenAsync().ConfigureAwait(false);

        return NotNullHelper.NotNullString(
            await cmd.ExecuteScalarAsync().ConfigureAwait(false)
        );
      }
    }


    public async Task<List<SecuenceDetailDto>> GetSecuenceDetails()
    {
      var secuenceDetail = new List<SecuenceDetailDto>();

      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        cmd.CommandText = @"SELECT id, Detalle_Secuencias, pk_hide FROM NM_Detalle_Secuencias";
        cmd.CommandType = CommandType.Text;
        try
        {
          await conn.OpenAsync().ConfigureAwait(false);

          using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
          {
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
              secuenceDetail.Add(new SecuenceDetailDto
              {
                ID = reader.GetInt32(reader.GetOrdinal("id")),
                Detalle = NotNullHelper.NotNullString(reader["Detalle_Secuencias"]).Trim(),
                PK = NotNullHelper.NotNullString(reader["pk_hide"]).Trim()
              });
            }
          }
        }
        catch (SqlException ex)
        {
          throw new Exception("Errror trying to get the SecuencesDetail");
        }
        return secuenceDetail;
      }
    }

    public async Task<bool> ValidateSequenceProcessRelation(
    decimal sequenceId,
    decimal processId,
    int familyId,
    string sequenceBom)
    {
      if (string.IsNullOrWhiteSpace(sequenceBom))
        return false;

      const string QUERY = @"
        SELECT 1
        FROM NM_Secuencia_Detalle_secuencia
        WHERE Sec_det_id = @sequenceId
          AND id = @processId
          AND familia_id = @familyId
          AND BOM_Seq = @sequenceBom";

      using (var conn = new SqlConnection(strConn))
      using (var cmd = new SqlCommand(QUERY, conn))
      {
        cmd.Parameters.Add("@sequenceId", SqlDbType.Decimal).Value = sequenceId;
        cmd.Parameters.Add("@processId", SqlDbType.Decimal).Value = processId;
        cmd.Parameters.Add("@familyId", SqlDbType.Int).Value = familyId;
        cmd.Parameters.Add("@sequenceBom", SqlDbType.VarChar, 50)
                      .Value = sequenceBom.Trim();

        try
        {
          await conn.OpenAsync().ConfigureAwait(false);
          return await cmd.ExecuteScalarAsync().ConfigureAwait(false) != null;
        }
        catch (SqlException ex)
        {
          throw new Exception(
              "Error validating sequence-process-family relation",
              ex);
        }
      }
    }

    public async Task<bool> InsertSequenceProcessRelation(
    decimal sequenceId,
    decimal processId,
    int familyId,
    string sequenceBom)
    {
      if (string.IsNullOrWhiteSpace(sequenceBom))
        throw new ArgumentException("sequenceBom is required", nameof(sequenceBom));

      const string QUERY = @"
        INSERT INTO NM_Secuencia_Detalle_secuencia
        (
            Secuencias_id,
            Sec_det_id,
            familia_id,
            BOM_Seq,
            Fecha_Creacion
        )
        VALUES
        (
            @sequenceId,
            @processId,
            @familyId,
            @sequenceBom,
            @date
        )";

      using (var conn = new SqlConnection(strConn))
      using (var cmd = new SqlCommand(QUERY, conn))
      {
        cmd.Parameters.Add("@sequenceId", SqlDbType.Decimal).Value = sequenceId;
        cmd.Parameters.Add("@processId", SqlDbType.Decimal).Value = processId;
        cmd.Parameters.Add("@familyId", SqlDbType.Int).Value = familyId;
        cmd.Parameters.Add("@sequenceBom", SqlDbType.VarChar, 50)
                      .Value = sequenceBom.Trim();
        cmd.Parameters.Add("@date", SqlDbType.DateTime)
                      .Value = DateTime.Now;

        try
        {
          await conn.OpenAsync().ConfigureAwait(false);
          await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
          return true;
        }
        catch (SqlException ex)
        {
          throw new Exception(
              "Error inserting sequence-process-family relation",
              ex);
        }
      }
    }


    public async Task<Tuple<decimal, decimal, int, string>> GetSequenceProcessRelationById(int id)
    {
       using (var conn = new SqlConnection(strConn))
       using (var cmd = conn.CreateCommand())
       {
          cmd.CommandText = @"
             SELECT Secuencias_id, Sec_det_id, familia_id, BOM_Seq 
             FROM NM_Secuencia_Detalle_secuencia 
             WHERE id = @id";
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("@id", id);
          
          try
          {
             await conn.OpenAsync().ConfigureAwait(false);
             using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
             {
                if (await reader.ReadAsync().ConfigureAwait(false))
                {
                   var seqId = reader.GetDecimal(reader.GetOrdinal("Secuencias_id"));
                   var procId = reader.GetDecimal(reader.GetOrdinal("Sec_det_id"));
                   var famId = reader.GetInt32(reader.GetOrdinal("familia_id"));
                   var bomSeq = NotNullHelper.NotNullString(reader["BOM_Seq"]).Trim();
                   
                   return new Tuple<decimal, decimal, int, string>(seqId, procId, famId, bomSeq);
                }
             }
          }
          catch (SqlException ex)
          {
             throw new Exception("Error obtaining sequence relation by id", ex);
          }
       }
       return null;
    }

    public async Task<bool> UpdateSequenceProcessRelation(int id, decimal sequenceId, decimal processId, int familyId, string sequenceBom)
    {
      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        cmd.CommandText = @"
          UPDATE NM_Secuencia_Detalle_secuencia 
          SET Secuencias_id = @sequenceId, 
              id_detalle_secuencia = @processId, 
              familia_id = @familyId, 
              Secuencia = @sequenceBom
          WHERE id = @id";
        
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@sequenceId", sequenceId);
        cmd.Parameters.AddWithValue("@processId", processId);
        cmd.Parameters.AddWithValue("@familyId", familyId);
        cmd.Parameters.AddWithValue("@sequenceBom", sequenceBom);

        try
        {
           await conn.OpenAsync().ConfigureAwait(false);
           await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
           return true;
        }
        catch (SqlException ex)
        {
          throw new Exception("Error updating sequence process relation", ex);
        }
      }
    }

    public NM_Detalle_Combinaciones_ComponentesModel GetCombinacionComponente(string itemno)
    {
      string query = string.Format("SELECT * FROM NM_Detalle_Combinaciones_Componentes WHERE Itemno = '{0}'", itemno);
      NM_Detalle_Combinaciones_ComponentesModel componente = new NM_Detalle_Combinaciones_ComponentesModel();

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = query;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                componente.Id = Convert.ToInt32(reader["Id"]);
                componente.IdCombinacion = Convert.ToInt32(reader["Id_Combinacion"]);
                componente.Id_Arinvt = reader["Id_Arinvt"].ToString();
                componente.Itemno = reader["Itemno"].ToString();
                componente.Nombre_Componente = reader["Nombre_Componente"].ToString();
                componente.Class = reader["Class_IQMS"].ToString();
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return componente;
    }

    public List<NM_Detalle_Combinaciones_ComponentesModel> GetDetalleComponente(string idCombinacion)
    {
      string query = string.Format("SELECT * FROM NM_Detalle_Combinaciones_Componentes WHERE Id_Combinacion = '{0}'", idCombinacion);
      List<NM_Detalle_Combinaciones_ComponentesModel> componentes = new List<NM_Detalle_Combinaciones_ComponentesModel>();
      NM_Detalle_Combinaciones_ComponentesModel componente;

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = query;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                componente = new NM_Detalle_Combinaciones_ComponentesModel();
                componente.Id = Convert.ToInt32(reader["Id"]);
                componente.IdCombinacion = Convert.ToInt32(reader["Id_Combinacion"]);
                componente.Id_Arinvt = reader["Id_Arinvt"].ToString();
                componente.Itemno = reader["Itemno"].ToString();
                componente.Nombre_Componente = reader["Nombre_Componente"].ToString();
                componente.Class = reader["Class_IQMS"].ToString();
                componente.isUsed = false;
                componentes.Add(componente);
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return componentes;
    }

    public List<NM_Condicional> GetCondicionales()
    {
      string GET_Condicional = string.Format("SELECT * FROM NM_Condicionales");

      return GetGeneralCondicionales(GET_Condicional);
    }

    public void GetPathAndFatherCondicional(string idMaster, string idCompuesto, ref NM_Condicional condicional)
    {
      string path = string.Empty;
      string nodoPadre = string.Empty;
      string QUERY_PATH = string.Format("SELECT Path FROM NM_CondicionalMaster WHERE IdCondicionalMaster = '{0}' AND IdCompuesto = '{1}' AND " +
                                   "IdElemento = '{2}'", idMaster, idCompuesto, condicional.Id);
      string QUERY_FATHER = string.Format("SELECT NodoPadre FROM NM_CondicionalMaster WHERE IdCondicionalMaster = '{0}' AND IdCompuesto = '{1}' AND " +
                                   "IdElemento = '{2}'", idMaster, idCompuesto, condicional.Id);


      path = Select(QUERY_PATH, "Path");
      nodoPadre = Select(QUERY_FATHER, "NodoPadre");

      condicional.Path = path;
      condicional.NodoPadre = nodoPadre;
    }

    public List<NM_Condicional> GetGeneralCondicionales(string query)
    {
      List<NM_Condicional> condicionales = new List<NM_Condicional>();

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = query;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                NM_Condicional condicional = new NM_Condicional();
                condicional.Id = Convert.ToInt32(reader["Id"]);
                condicional.NombreCondicional = reader["NombreCondicional"].ToString();
                condicional.Condicional = reader["Condicional"].ToString();
                //condicional.Tipo = reader["Tipo"].ToString();
                condicional.Verdadero = reader["Verdadero"].ToString();
                condicional.Falso = reader["Falso"].ToString();
                condicional.Tipo = reader["Tipo"].ToString();
                condicionales.Add(condicional);
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }
      return condicionales;
    }

    public List<NM_CondicionalMaster> GetElementsMasterCondicional(string idMaster, string idCompuesto, string nombreMaster)
    {
      //string GET_ELEMENTS = string.Format("SELECT * " +
      //                                    "FROM NM_CondicionalMaster " +
      //                                    "WHERE T0.IdCondicionalMaster = '{0}' AND T0.IdCompuesto = '{1}'", idMaster, idCompuesto);
      //string GET_ELEMENTS = string.Format("SELECT * FROM NM_CondicionalMaster AS T0 INNER JOIN NM_Condicionales T1 ON T1.Id = T0.IdCondicionalMaster WHERE T0.IdCondicionalMaster = '{0}' AND T0.IdCompuesto = '{1}'", idMaster,idCompuesto);
      //string.Format("SELECT * FROM NM_CondicionalMaster AS T0 INNER JOIN NM_Condicionales T1 ON T1.Id = T0.IdCondicionalMaster WHERE T0.IdCondicionalMaster = '{0}' AND T0.IdCompuesto = '{1}' AND t1.nOMBRE = '{2}'", idMaster, idCompuesto, nombreMaster);
      List<NM_CondicionalMaster> nodos = new List<NM_CondicionalMaster>();
      string GET_ELEMENTS = string.Format("SELECT * FROM NM_CondicionalMaster WHERE IdCondicionalMaster = '{0}' AND IdCompuesto = '{1}'", idMaster, idCompuesto);

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = GET_ELEMENTS;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                NM_CondicionalMaster nodo = new NM_CondicionalMaster();
                nodo.Nombre = reader["Nombre"].ToString();
                nodo.IdCondicionalMaster = Convert.ToInt32(reader["IdCondicionalMaster"].ToString());
                nodo.IdElemento = Convert.ToInt32(reader["IdElemento"].ToString());
                nodo.Nivel = Convert.ToInt32(reader["Nivel"].ToString());
                nodo.Posicion = reader["Posicion"].ToString();
                nodo.Tipo = reader["Tipo"].ToString();
                nodo.NodoPadre = reader["NodoPadre"].ToString();
                nodo.Path = reader["Path"].ToString();
                nodos.Add(nodo);
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return nodos;
    }

    public NM_CondicionalMaster GetCondicionalMasterInfo(string idCondicional)
    {
      string GET_MASTER = string.Format("SELECT * FROM NM_CondicionalMaster where id = '{0}'", idCondicional);
      NM_CondicionalMaster master = new NM_CondicionalMaster();

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = GET_MASTER;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                master.IdCondicionalMaster = Convert.ToInt32(reader["IdCondicionalMaster"].ToString());
                master.IdCompuesto = reader["IdCompuesto"].ToString();
                master.Nombre = reader["Nombre"].ToString();
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return master;
    }

    public NM_CondicionalMaster GetCondicionalMasterById(string idCondicionalMaster)
    {
      string GET_MASTER = string.Format("SELECT * FROM NM_CondicionalMaster where IdCondicionalMaster = '{0}'", idCondicionalMaster);
      NM_CondicionalMaster master = new NM_CondicionalMaster();

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = GET_MASTER;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                master.IdCondicionalMaster = Convert.ToInt32(reader["IdCondicionalMaster"].ToString());
                master.IdCompuesto = reader["IdCompuesto"].ToString();
                master.Nombre = reader["Nombre"].ToString();
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return master;
    }

    public NM_CondicionalMaster GetCondicionalMasterById(string idCondicionalMaster, string nameCondicional)
    {
      string GET_MASTER = string.Format("SELECT * FROM NM_CondicionalMaster where IdCondicionalMaster = '{0}' and Nombre='{1}'", idCondicionalMaster, nameCondicional);
      NM_CondicionalMaster master = new NM_CondicionalMaster();

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = GET_MASTER;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                master.IdCondicionalMaster = Convert.ToInt32(reader["IdCondicionalMaster"].ToString());
                master.IdCompuesto = reader["IdCompuesto"].ToString();
                master.Nombre = reader["Nombre"].ToString();
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return master;
    }

    public List<string> selectList(string query, string data)
    {
      string value = "";
      List<string> values = new List<string>();

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = query;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                value = reader[data].ToString();
                values.Add(value);
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return values;
    }

    public string GetDataFromElement(string id, string tipo)
    {
      string GET_VALUE = string.Empty;
      string result = string.Empty;

      if (tipo == "Formula")
      {
        GET_VALUE = string.Format("SELECT Formula FROM NM_Formulas WHERE ID = '{0}'", id);
        result = Select(GET_VALUE, "Formula");
      }
      else
      {
        GET_VALUE = string.Format("SELECT Condicional FROM NM_Condicionales WHERE ID = '{0}'", id);
        result = Select(GET_VALUE, "Condicional");
      }

      return result;
    }

    public double GetPesoTeorico(string itemno)
    {
      string QUERY = string.Format("SELECT conv_value FROM arinvt_uom_conv " +
                                   "INNER JOIN arinvt " +
                                   "ON arinvt_uom_conv.arinvt_id = arinvt.id " +
                                   "WHERE arinvt.itemno = '{0}' " +
                                   "AND arinvt_uom_conv.UOM = 'KG'", itemno);
      return Convert.ToDouble(Select(QUERY, "conv_value"));
    }

    public List<NM_CondicionalMaster> GetMasterCondicional()
    {
      List<NM_CondicionalMaster> condicionales = new List<NM_CondicionalMaster>();

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = "SELECT * FROM NM_CondicionalMaster";
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                NM_CondicionalMaster nodo = new NM_CondicionalMaster();
                nodo.Id = Convert.ToInt32(reader["Id"].ToString());
                nodo.Nombre = reader["Nombre"].ToString();
                nodo.IdCondicionalMaster = Convert.ToInt32(reader["IdCondicionalMaster"].ToString());
                nodo.IdCompuesto = reader["IdCompuesto"].ToString();
                nodo.IdElemento = Convert.ToInt32(reader["IdElemento"].ToString());
                nodo.Posicion = reader["Posicion"].ToString();
                nodo.Nivel = Convert.ToInt32(reader["Nivel"].ToString());
                nodo.Tipo = reader["Tipo"].ToString();
                nodo.TipoMaster = reader["TipoMaster"].ToString();

                condicionales.Add(nodo);
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }
      return condicionales.GroupBy(x => x.IdCompuesto).Select(x => x.First()).ToList();
    }

    public string GetIdCombinacion(string modelo, string acabado)
    {
      string GET_IDCOMBINACION = string.Format("SELECT Id FROM NM_Combinaciones WHERE Combinacion_Bom = '{0}' AND Acabado = '{1}'", modelo, acabado);

      return Select(GET_IDCOMBINACION, "Id");
    }

    public List<string> GetIdCombinacionList(string modelo)
    {
      string GET_IDCOMBINACION = string.Format("SELECT Id FROM NM_Combinaciones WHERE Combinacion_Bom = '{0}'", modelo);

      return selectList(GET_IDCOMBINACION, "Id");
    }

    public List<NM_Detalle_Combinacion_Componentes_FormulasModel> GetComponentsFromClon(string modelo, string seccion = null)
    {
      string query = string.Empty;
      string idCombinacion = GetIdCombinacion(modelo, "AL");

      if (string.IsNullOrEmpty(seccion))
      {
        query = string.Format("SELECT * FROM NM_Detalle_Combinacion_Componentes_Formulas WHERE " +
                              "idCombinacion = '{0}'", idCombinacion);
      }
      else
      {
        query = string.Format("SELECT * FROM NM_Detalle_Combinacion_Componentes_Formulas WHERE " +
                              "idCombinacion = '{0}' AND Seccion = '{1}'", idCombinacion, seccion);
      }
      return GetComponentesFormulasFromQuery(query);
    }

    public List<NM_Detalle_Combinacion_Componentes_FormulasModel> GetComponentesFormulas(string idCombinacion)
    {
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> formulas = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      NM_Detalle_Combinacion_Componentes_FormulasModel registro;


      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = string.Format("SELECT * FROM NM_Detalle_Combinacion_Componentes_Formulas where IdCombinacion = '{0}'", idCombinacion);
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                registro = new NM_Detalle_Combinacion_Componentes_FormulasModel();
                registro.Id = Convert.ToInt32(reader["Id"].ToString());
                registro.IdCombinacion = Convert.ToInt32(reader["IdCombinacion"].ToString());
                registro.IdDetalleComponente = Convert.ToInt32(reader["IdDetalleComp"].ToString());
                registro.Itemno = reader["Itemno"].ToString();
                registro.IdComponente = Convert.ToInt32(reader["IdComponente"].ToString());
                registro.IdFormulaQty = Convert.ToInt32(reader["IdFormulaQty"].ToString());
                registro.IdFormulaMd = Convert.ToInt32(reader["IdFormulaMd"].ToString());
                registro.IdFormulaTotal = Convert.ToInt32(reader["IdFormulaTotal"].ToString());
                registro.IdCondicionalQty = Convert.ToInt32(reader["IdCondicionalQty"].ToString());
                registro.IdCondicionalMd = Convert.ToInt32(reader["IdCondicionalMd"].ToString());
                registro.TypeConditionalQty = reader["TypeConditionalQty"].ToString();
                registro.TypeConditionalMd = reader["TypeConditionalMd"].ToString();
                registro.IdCompuestoQty = reader["IdCompuestoQty"].ToString();
                registro.IdCompuestoMd = reader["IdCompuestoMd"].ToString();
                if (reader["Seccion"] != DBNull.Value)
                  registro.Seccion = reader["Seccion"].ToString();
                else
                  registro.Seccion = "";

                if (reader["Linea"] != DBNull.Value)
                  registro.Linea = Convert.ToInt32(reader["Linea"]);
                else
                  registro.Linea = 0;

                if (reader["Descripcion"] != DBNull.Value)
                  registro.Descripcion = reader["Descripcion"].ToString();
                else
                  registro.Descripcion = "";
                registro.IsUsed = false;

                formulas.Add(registro);
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return formulas;
    }

    public List<NM_Detalle_Combinacion_Componentes_FormulasModel> GetComponentesFormulasFromQuery(string query)
    {
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> formulas = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      NM_Detalle_Combinacion_Componentes_FormulasModel registro;


      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = query;
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                registro = new NM_Detalle_Combinacion_Componentes_FormulasModel();
                registro.Id = Convert.ToInt32(reader["Id"].ToString());
                registro.IdCombinacion = Convert.ToInt32(reader["IdCombinacion"].ToString());
                registro.IdDetalleComponente = Convert.ToInt32(reader["IdDetalleComp"].ToString());
                registro.Itemno = reader["Itemno"].ToString();
                registro.IdComponente = Convert.ToInt32(reader["IdComponente"].ToString());
                registro.IdFormulaQty = Convert.ToInt32(reader["IdFormulaQty"].ToString());
                registro.IdFormulaMd = Convert.ToInt32(reader["IdFormulaMd"].ToString());
                registro.IdFormulaTotal = Convert.ToInt32(reader["IdFormulaTotal"].ToString());
                if (reader["IdFormulaPeso"] != DBNull.Value)
                  registro.IdFormulaPeso = Convert.ToInt32(reader["IdFormulaPeso"].ToString());
                else
                  registro.IdFormulaPeso = 0;
                registro.IdCondicionalQty = Convert.ToInt32(reader["IdCondicionalQty"].ToString());
                registro.IdCondicionalMd = Convert.ToInt32(reader["IdCondicionalMd"].ToString());
                registro.TypeConditionalQty = reader["TypeConditionalQty"].ToString();
                registro.TypeConditionalMd = reader["TypeConditionalMd"].ToString();
                registro.IdCompuestoQty = reader["IdCompuestoQty"].ToString();
                registro.IdCompuestoMd = reader["IdCompuestoMd"].ToString();
                if (reader["Seccion"] != DBNull.Value)
                  registro.Seccion = reader["Seccion"].ToString();
                else
                  registro.Seccion = "";

                if (reader["Linea"] != DBNull.Value)
                  registro.Linea = Convert.ToInt32(reader["Linea"]);
                else
                  registro.Linea = 0;

                if (reader["Descripcion"] != DBNull.Value)
                  registro.Descripcion = reader["Descripcion"].ToString();
                else
                  registro.Descripcion = "";
                registro.IsUsed = false;

                formulas.Add(registro);
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return formulas;
    }

    public string GetIdCondicional(string nombreCondicional)
    {
      string GET_ID = string.Format("SELECT Id FROM NM_Condicionales WHERE Condicional='{0}'", nombreCondicional);

      return Select(GET_ID, "Id");
    }

    public string GetIdFormula(string formula)
    {
      string GET_ID = string.Format("SELECT Id FROM NM_Formulas WHERE Formula = '{0}'", formula);

      return Select(GET_ID, "Id");
    }

    public List<string> GetBomsFromComponents(string itemno)
    {
      List<string> boms = new List<string>();

      if (!string.IsNullOrEmpty(itemno))
      {
        itemno = itemno.ToUpper();
        //string QUERY = string.Format("SELECT DISTINCT Combinacion_Bom FROM NM_Detalle_Combinaciones_Componentes " +
        //                             "RIGHT JOIN NM_Combinaciones ON NM_Detalle_Combinaciones_Componentes.Id_Combinacion = NM_Combinaciones.Id " +
        //                             "where Itemno = '{0}'", itemno);
        string QUERY = string.Format("SELECT DISTINCT Combinacion_Bom FROM NM_Detalle_Combinaciones_Componentes " +
                                     "RIGHT JOIN NM_Combinaciones ON NM_Detalle_Combinaciones_Componentes.Id_Combinacion = NM_Combinaciones.Id " +
                                     "where Itemno = '{0}'", itemno);
        boms = selectList(QUERY, "Combinacion_Bom");
      }

      return boms;
    }

    public string GetIdCombinacionByName(string bomName, string acabado)
    {
      string QUERY = string.Format("SELECT Id FROM NM_Combinaciones WHERE Combinacion_Bom = '{0}' AND Acabado = '{1}'", bomName, acabado);

      return Select(QUERY, "Id");
    }
    public List<NM_ModeloL1> GetModel1()
    {
      List<NM_ModeloL1> modelos = new List<NM_ModeloL1>();
      NM_ModeloL1 model;

      using (var conn = new SqlConnection(strConn))
      {
        using (var cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = "SELECT * FROM NM_ModeloL1";
          try
          {
            using (var reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                model = new NM_ModeloL1();
                model.Id = Convert.ToInt32(reader["Id"]);
                model.IdModeloL0 = Convert.ToInt32(reader["Id_ModeloL0"]);
                model.Nombre = reader["Nombre_Modelo"].ToString();
                model.Descripcion = reader["Descripcion_Modelo"].ToString();
                model.MfgCell = reader["Mfg_Cell"].ToString();
                if (Convert.ToInt32(reader["Approved"]) == 1)
                {
                  model.Approved = true;
                }
                else
                {
                  model.Approved = false;
                }
                modelos.Add(model);
              }
            }
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return modelos;
    }
    #endregion

    #region INSERT

    public bool ExecuteQuery(string query)
    {
      using (SqlConnection conn = new SqlConnection(strConn))
      {
        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = System.Data.CommandType.Text;
          cmd.CommandText = query;

          try
          {
            conn.Open();
            cmd.ExecuteNonQuery();
          }
          catch (SqlException e)
          {
            string exe = e.ToString();
            return false;
          }
          finally
          {
            conn.Close();
          }
        }
      }

      return true;
    }

    public bool RegisterUser(string user, string password, string roll)
    {
      string INSERT_USER = string.Format("INSERT INTO T_User VALUES ('{0}',ENCRYPTBYPASSPHRASE('password', '{1}'),ENCRYPTBYPASSPHRASE('password', '{2}'))", user, password, roll);

      bool response = ExecuteQuery(INSERT_USER);

      return response;
    }

    public bool InsertFormula(NM_Formula formula)
    {

      string INSERT_FORMULA = string.Format("INSERT INTO NM_Formulas(NombreFormula,Tipo,Formula,FechaCreacion)" +
                                             " VALUES('{0}','{1}','{2}',GetDate())", formula.NombreFormula, formula.Tipo, formula.Formula);

      return ExecuteQuery(INSERT_FORMULA);
    }

    public bool InsertCondicional(NM_Condicional condicional)
    {
      string INSERT_CONDICIONAL = string.Format("INSERT INTO NM_Condicionales(NombreCondicional,Condicional,Tipo,Verdadero,Falso) " +

                                               //"VALUES('{0}','{1}','{2}','{3}','{4}')",condicional.NombreCondicional,condicional.Condicional,

                                               "VALUES('{0}','{1}','{2}','{3}', '{4}')", condicional.NombreCondicional, condicional.Condicional,

                                               condicional.Tipo, condicional.Verdadero, condicional.Falso);

      return ExecuteQuery(INSERT_CONDICIONAL);
    }

    public bool InsertCondicionalMaster(NM_CondicionalMaster master, string idCompuesto, string nombre, string tipo)
    {
      // Buscar nombre de condicional por idmaster
      string CONDICIONAL_MASTER = "";
      string query = string.Empty;
      string name = string.Empty;

      if (!string.Equals(tipo, "Formula"))
      {
        query = string.Format("SELECT NombreCondicional FROM NM_Condicionales WHERE Id = '{0}'", master.IdElemento);
        name = Select(query, "NombreCondicional");
      }
      else
      {
        query = string.Format("SELECT NombreFormula FROM NM_Formulas WHERE Id = '{0}'", master.IdElemento);
        name = Select(query, "NombreFormula");
      }

      CONDICIONAL_MASTER = string.Format("INSERT INTO NM_CondicionalMaster (Nombre,IdCondicionalMaster,IdCompuesto,IdElemento,NodoPadre,Path,Posicion,Nivel,Tipo) " +
                                                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", nombre, master.IdCondicionalMaster, idCompuesto,
                                                master.IdElemento, master.NodoPadre, master.Path, master.Posicion, master.Nivel, master.Tipo);

      return ExecuteQuery(CONDICIONAL_MASTER);
    }

    public bool InsertLooseWeight(string value, string arinvt_id)
    {
      string QUERY = string.Format("INSERT INTO arinvt (LOOSE_WEIGHT) VALUES('{0}') WHERE arinvt_id = '{1}'", value, arinvt_id);

      return ExecuteQuery(QUERY);
    }

    public void InsertCombinacion(string nombre, string idFamilia, string acabado)
    {
      string INSERT_COMBINACION = string.Format("INSERT INTO NM_Combinaciones(Id_Modelo_Base,Combinacion_BOM,Acabado,Completado,Fecha_Creacion) " +
                                                "VALUES('{0}','{1}','{2}','0',GETDATE())", idFamilia, nombre, acabado);

      ExecuteQuery(INSERT_COMBINACION);
    }

    #endregion

    #region UPDATE

    public bool UpdatePathLog(string pathLog)
    {
      string QUERY_UPDATE_PATHLOGS = string.Format("UPDATE T_Configuracion SET Detalle = '{0}' WHERE Nombre_configuracion = 'Path logs'", pathLog);

      return ExecuteQuery(QUERY_UPDATE_PATHLOGS);
    }

    public bool UpdateDirectoryLog(string pathDirectoryLogs)
    {
      string QUERY_UPDATE_PATHDIRECTORYLOGS = string.Format("UPDATE T_Configuracion SET Detalle = '{0}' WHERE Nombre_configuracion = 'Name directory logs'", pathDirectoryLogs);

      return ExecuteQuery(QUERY_UPDATE_PATHDIRECTORYLOGS);
    }

    public bool UpdateFormula(NM_Formula formula, NM_Formula oldFormula)
    {
      string UPDATE_FORMULA = string.Format("UPDATE NM_Formulas SET NombreFormula = '{0}', Tipo='{1}'," +
                                             " Formula = '{2}' WHERE NombreFormula = '{3}' AND Tipo ='{4}' AND Formula = '{5}'"
                                             , formula.NombreFormula, formula.Tipo, formula.Formula, oldFormula.NombreFormula,
                                             oldFormula.Tipo, oldFormula.Formula);

      return ExecuteQuery(UPDATE_FORMULA);
    }

    public void UpdateComponentesFormulas(List<NM_Detalle_Combinacion_Componentes_FormulasModel> formulas)
    {

      foreach (var formula in formulas)
      {
        string[] ids = new string[] { formula.IdFormulaQty.ToString(), formula.IdFormulaMd.ToString(), formula.IdFormulaTotal.ToString(),
                                              formula.IdCondicionalQty.ToString(),formula.IdCondicionalMd.ToString(),formula.TypeConditionalMd,
                                              formula.TypeConditionalQty,formula.IdCompuestoQty.ToString(),formula.IdCompuestoMd.ToString(),
                                              formula.IdCombinacion.ToString(),formula.IdDetalleComponente.ToString()};

        string UPDATE_FORMULAS = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaQty='{0}',IdFormulaMd='{1}'," +
                                               "IdFormulaTotal='{2}',IdCondicionalQty='{3}', IdCondicionalMd='{4}',TypeConditionalMd='{5}'," +
                                               "TypeConditionalQty='{6}',IdCompuestoQty='{7}',IdCompuestoMd='{8}' WHERE IdCombinacion='{9}' " +
                                               "AND IdDetalleComp='{10}'", ids);

        ExecuteQuery(UPDATE_FORMULAS);
      }

    }

    public void UpdateCombinacionCompletada(string idCombinacion)
    {
      string UPDATE_COMBINACION = string.Format("UPDATE NM_Combinaciones SET Completado = '1' WHERE Id = '{0}'", idCombinacion);

      ExecuteQuery(UPDATE_COMBINACION);
    }

    public bool UpdateCondicional(string condicional, string verdadero, string falso, string tipo, string nombre, string id)
    {
      string UPDATE_CONDICIONAL = string.Format("UPDATE NM_Condicionales SET Condicional = '{0}', Verdadero='{1}', " +
                                                "Falso='{2}', Tipo='{3}', NombreCondicional = '{4}' WHERE Id='{5}'",
                                                condicional, verdadero, falso, tipo, nombre, id);
      return ExecuteQuery(UPDATE_CONDICIONAL);
    }

    public void UpdateComponentes(string itemno, string idCombinacion, string oldItemno)
    {
      NM_ComponentesModel componente = oracle.GetComponente(itemno);

      string UPDATE_COMPONENTES = string.Format("UPDATE NM_Detalle_Combinaciones_Componentes SET " +
                                                "Id_Arinvt = '{0}', Itemno = '{1}', Nombre_Componente = '{2}', Class_IQMS = '{3}' " +
                                                "Where Id_Combinacion = '{4}' AND Itemno = '{5}'",
                                                componente.Id_Arinvt, itemno, componente.Nombre_Componente, componente.Class, idCombinacion, oldItemno);

      string UPDATE_COMPONENTES_FORMULAS = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET " +
                                                         "IdComponente = '{0}', Itemno = '{1}' " +
                                                         "Where IdCombinacion = '{2}' AND Itemno = '{3}'", componente.Id_Arinvt, itemno, idCombinacion, oldItemno);

      ExecuteQuery(UPDATE_COMPONENTES);
      ExecuteQuery(UPDATE_COMPONENTES_FORMULAS);
    }

    public void UpdateModeloL1(List<NM_ModeloL1> models)
    {
      string UPDATE = string.Empty;
      int appr = 0;

      foreach (var model in models)
      {
        if (model.Approved == true)
        {
          appr = 1;
        }

        UPDATE = string.Format("UPDATE NM_ModeloL1 SET Approved = '{0}' WHERE ID={1}", appr, model.Id);
        ExecuteQuery(UPDATE);
      }
    }

    public void UpdateCombinacionesApproved(List<NM_CombinacionesModel> boms)
    {
      string UPDATE = string.Empty;
      int appr = 0;

      foreach (var bom in boms)
      {
        if (bom.Approved == true)
        {
          appr = 1;
        }

        UPDATE = string.Format("UPDATE NM_Combinaciones SET Approved = '{0}' WHERE ID={1}", appr, bom.Id);
        ExecuteQuery(UPDATE);
      }
    }

    public void UpdateCombinacionesPhantom(List<NM_CombinacionesModel> boms)
    {
      string UPDATE = string.Empty;
      int appr = 0;

      foreach (var bom in boms)
      {
        if (bom.Phantom == true)
        {
          appr = 1;
        }

        UPDATE = string.Format("UPDATE NM_Combinaciones SET Phantom = '{0}' WHERE ID={1}", appr, bom.Id);
        ExecuteQuery(UPDATE);
      }
    }

    #endregion

    #region DELETE

    public bool DeleteFormula(string id)
    {
      string DELETE_FORMULA = string.Format("DELETE FROM NM_Formulas WHERE Id = '{0}'", id);

      return ExecuteQuery(DELETE_FORMULA);
    }

    public bool DeleteCondicional(string id, string nombreCondicional)
    {
      string DELETE_CONDICIONAL = string.Format("DELETE FROM NM_Condicionales WHERE Id = '{0}' AND NombreCondicional = '{1}'", id, nombreCondicional);

      return ExecuteQuery(DELETE_CONDICIONAL);
    }

    public bool DeleteCondicionalMaster(string id, string nombreCondicional, string idCompuesto)
    {
      string DELETE_CONDICIONAL = string.Format("DELETE FROM NM_CondicionalMaster WHERE IdCondicionalMaster = '{0}' AND Nombre = '{1}' AND " +
                                                "IdCompuesto='{2}'", id, nombreCondicional, idCompuesto);

      return ExecuteQuery(DELETE_CONDICIONAL);
    }

    public bool DeleteNM_Combinacion(string combinacion_bom_id)
    {
      string QUERY = string.Format("DELETE FROM NM_Combinaciones WHERE Id = {0}", combinacion_bom_id);

      return ExecuteQuery(QUERY);
    }

    public bool DeleteNM_Detalle_Combinacion_Componentes_Formulas(string combinacion_bom_id)
    {
      string QUERY = string.Format("DELETE FROM NM_Detalle_Combinacion_Componentes_Formulas WHERE IdCombinacion = {0}",
                                   combinacion_bom_id);

      return ExecuteQuery(QUERY);
    }

    public bool DeleteNM_Detalle_Combinaciones_Componentes(string combinacion_bom_id)
    {
      string QUERY = string.Format("DELETE FROM NM_Detalle_Combinaciones_Componentes WHERE Id_Combinacion = {0}",
                                   combinacion_bom_id);

      return ExecuteQuery(QUERY);
    }

    #endregion

    #region CHECK

    public bool ExistConditionalName(string name)
    {
      string CHECK_NAME = string.Format("SELECT NombreCondicional FROM NM_Condicionales" +
                                        " WHERE NombreCondicional = '{0}'", name);

      List<string> condicionales = selectList(CHECK_NAME, "NombreCondicional");

      if (condicionales.Count > 0)
      {
        return true;
      }

      return false;
    }

    public bool ExistConditional(string conditional)
    {
      string EXIST_CONDITIONAL = string.Format("SELECT Condicional FROM NM_Condicional " +
                                               "WHERE Condicional = '{0}'", conditional);

      List<string> condicionales = selectList(EXIST_CONDITIONAL, "Condicional");

      if (condicionales.Count > 0)
      {
        return true;
      }

      return false;
    }

    public bool ExistMasterConditional(string idMaster, string idCompuesto, string nombreMaster)
    {
      string error = string.Empty;

      try
      {
        NM_CondicionalMaster master = GetElementsMasterCondicional(idMaster, idCompuesto, nombreMaster)[0];

      }
      catch (Exception ex)
      {
        error = ex.Message;
        return false;
      }

      return true;
    }

    public bool ExistIdCompuesto(string idCompuesto)
    {
      string GET_ID = string.Format("SELECT IdCondicionalMaster FROM NM_CondicionalMaster WHERE IdCompuesto = '{0}'", idCompuesto);

      string value = Select(GET_ID, "IdCondicionalMaster");

      if (string.IsNullOrEmpty(value))
      {
        return false;
      }

      return true;
    }

    public bool ExistMasterConditionalName(string name)
    {
      string GET_NAME = string.Format("SELECT Nombre FROM NM_CondicionalMaster WHERE Nombre = '{0}'", name);
      List<string> masters = selectList(GET_NAME, "Nombre");

      if (masters.Count > 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool ExistPreAssy(string idCombinacion)
    {
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> registros = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();

      registros = GetComponentesFormulas(idCombinacion);

      if (registros.Count > 0)
      {
        return true;
      }
      return false;
    }

    public bool ExistConditionalReferentInMaster(string idCondicional, string tipo)
    {
      string PART_OF = string.Format("SELECT Id FROM NM_CondicionalMaster WHERE IdElemento = '{0}' AND Tipo = '{1}'", idCondicional, tipo);

      string value = Select(PART_OF, "Id");

      if (!string.IsNullOrEmpty(value))
      {
        return true;
      }

      return false;
    }

    public bool ExistAssyWithMaster(string idMaster, string idCompuesto)
    {
      string GET_MASTERS = string.Format("select Id from NM_Detalle_Combinacion_Componentes_Formulas where (IdCondicionalMd = '{0}' OR IdCondicionalQty = '{0}')" +
                                         " AND (IdCompuestoMd='{1}' OR IdCompuestoQty ='{1}')");
      List<string> idsMaster = selectList(GET_MASTERS, "Id");

      if (idsMaster.Count > 0)
      {
        return true;
      }

      return false;
    }

    public bool ExisteBOMOnModeloL1(string nombreModelo)
    {
      string QUERY_EXIST = string.Format("SELECT Id FROM NM_ModeloL1 WHERE Nombre_Modelo = '{0}'", nombreModelo);
      string value = Select(QUERY_EXIST, "Id");

      if (string.IsNullOrEmpty(value))
      {
        return false;
      }

      return true;
    }

    public bool ExistModelOnCombinaciones(string nombreModelo)
    {
      string GET_MODELO = string.Format("SELECT Id FROM NM_Combinaciones WHERE Combinacion_Bom = '{0}'", nombreModelo);

      string value = Select(GET_MODELO, "Id");

      if (string.IsNullOrEmpty(value))
      {
        return false;
      }

    return true;
    }

    /// <summary>
    /// Validates if a sequence with the same description already exists
    /// </summary>
    public bool ValidateSequenceExists(string descripcion)
    {
      string QUERY = "SELECT COUNT(*) FROM NM_Secuencias WHERE Descripcion = @descripcion";
      int count = 0;

      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = QUERY;
        cmd.Parameters.AddWithValue("@descripcion", descripcion);

        try
        {
          count = (int)cmd.ExecuteScalar();
        }
        catch (SqlException ex)
        {
          throw new Exception("Error validando la secuencia", ex);
        }
      }

      return count > 0;
    }

    public bool ValidateProccessExists(string descripcion)
    {
      if (string.IsNullOrWhiteSpace(descripcion))
        return false;

      const string QUERY = @"
        SELECT 1
        FROM NM_Detalle_Secuencias
        WHERE Detalle_secuencias = @detail";

      using (var conn = new SqlConnection(strConn))
      using (var cmd = new SqlCommand(QUERY, conn))
      {
        cmd.Parameters.Add("@detail", SqlDbType.VarChar, 255)
                       .Value = descripcion.Trim();

        conn.Open();
        return cmd.ExecuteScalar() != null;
      }
    }

    /// <summary>
    /// Inserts a new sequence with automatic creation date
    /// </summary>
    public bool InsertSequence(string descripcion)
    {
      string INSERT_QUERY = "INSERT INTO NM_Secuencias (Descripcion, Fecha_Creacion, pk_hide) VALUES (@descripcion, @fechaCreacion, 'N')";
      bool success = false;

      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = INSERT_QUERY;
        cmd.Parameters.AddWithValue("@descripcion", descripcion);
        cmd.Parameters.AddWithValue("@fechaCreacion", DateTime.Now);

        try
        {
          int rowsAffected = cmd.ExecuteNonQuery();
          success = rowsAffected > 0;
        }
        catch (SqlException ex)
        {
          throw new Exception("Error inserting sequence", ex);
        }
      }

      return success;
    }

    public bool InsertSequenceDetail(string detail)
    {
      const string insertQuery = @"
        INSERT INTO NM_DETALLE_SECUENCIAS
        (Detalle_Secuencias, Fecha_Creacion)
        VALUES (@detail, @date)";

      using (var conn = new SqlConnection(strConn))
      using (var cmd = new SqlCommand(insertQuery, conn))
      {
        cmd.Parameters.Add("@detail", SqlDbType.VarChar).Value = detail;
        cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;

        try
        {
          conn.Open();
          int rowsAffected = cmd.ExecuteNonQuery();
          return rowsAffected > 0;
        }
        catch (SqlException ex)
        {
          throw new Exception("Error inserting detail sequence", ex);
        }
      }
    }


    /// <summary>
    /// Updates the description of an existing sequence
    /// </summary>
    public bool UpdateSequenceDescription(decimal id, string nuevaDescripcion)
    {
      string UPDATE_QUERY = "UPDATE NM_Secuencias SET Descripcion = @descripcion WHERE id = @id";
      bool success = false;

      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = UPDATE_QUERY;
        cmd.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
          int rowsAffected = cmd.ExecuteNonQuery();
          success = rowsAffected > 0;
        }
        catch (SqlException ex)
        {
          throw new Exception("Error updating sequence description", ex);
        }
      }

      return success;
    }

    /// <summary>
    /// Marks a sequence as hidden (soft delete)
    /// </summary>
    public bool MarkSequenceAsHidden(decimal id)
    {
      string UPDATE_QUERY = "UPDATE NM_Secuencias SET pk_hide = 'Y' WHERE id = @id";
      bool success = false;

      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = UPDATE_QUERY;
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
          int rowsAffected = cmd.ExecuteNonQuery();
          success = rowsAffected > 0;
        }
        catch (SqlException ex)
        {
          throw new Exception("Error marking sequence as hidden", ex);
        }
      }

      return success;
    }

    /// <summary>
    /// Validates if a sequence is being used in NM_Detalle_Secuencias
    /// </summary>
    public bool ValidateSequenceInUse(decimal id)
    {
      string QUERY = "SELECT COUNT(*) FROM NM_Secuencia_Detalle_Secuencia WHERE secuencias_id = @id";
      int count = 0;

      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = QUERY;
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
          count = (int)cmd.ExecuteScalar();
        }
        catch (SqlException ex)
        {
          throw new Exception("Error validating sequence usage", ex);
        }
      }

      return count > 0;
    }

    /// <summary>
    /// Deletes a sequence from the database (physical delete)
    /// </summary>
    public bool DeleteSequence(decimal id)
    {
      string DELETE_QUERY = "DELETE FROM NM_Secuencias WHERE id = @id";
      bool success = false;

      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = DELETE_QUERY;
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
          int rowsAffected = cmd.ExecuteNonQuery();
          success = rowsAffected > 0;
        }
        catch (SqlException ex)
        {
          throw new Exception("Error deleting sequence", ex);
        }
      }

      return success;
    }

    #region Process Management Methods (Additional)

    public bool UpdateSequenceDetail(decimal id, string description)
    {
      string query = "UPDATE NM_Detalle_Secuencias SET Detalle_Secuencias = @description WHERE id = @id";
      
      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@description", description);
        cmd.Parameters.AddWithValue("@id", id);
        
        try
        {
          int rows = cmd.ExecuteNonQuery();
          return rows > 0;
        }
        catch (SqlException ex)
        {
          throw new Exception("Error updating sequence detail", ex);
        }
      }
    }

    public bool MarkSequenceDetailAsHidden(decimal id)
    {
      string query = "UPDATE NM_Detalle_Secuencias SET pk_hide = 'Y' WHERE id = @id";
      
      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@id", id);
        
        try
        {
          int rows = cmd.ExecuteNonQuery();
          return rows > 0;
        }
        catch (SqlException ex)
        {
          throw new Exception("Error hiding sequence detail", ex);
        }
      }
    }

    public bool ValidateProcessInUse(decimal id)
    {
      
      string query = "SELECT COUNT(*) FROM NM_Secuencia_Detalle_secuencia WHERE Sec_det_id = @id";
      
      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@id", id);
        
        try
        {
          int count = (int)cmd.ExecuteScalar();
          return count > 0;
        }
        catch (SqlException ex)
        {
           throw new Exception("Error checking process usage in NM_Secuencia_Detalle_secuencia", ex);
        }
      }
    }

    public bool DeleteSequenceDetail(decimal id)
    {
      string query = "DELETE FROM NM_Detalle_Secuencias WHERE id = @id";
      
      using (var conn = new SqlConnection(strConn))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@id", id);
        
        try
        {
          int rows = cmd.ExecuteNonQuery();
          return rows > 0;
        }
        catch (SqlException ex)
        {
          throw new Exception("Error deleting sequence detail", ex);
        }
      }
    }

    #endregion

    #region 
    
    #endregion


    #endregion


  }
}
