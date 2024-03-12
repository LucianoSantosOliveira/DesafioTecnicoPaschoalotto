using DesafioTecnicoPaschoalotto.objetos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesafioTecnicoPaschoalotto.Utilitarios
{
    internal class BancoDeDados
    {
        string conectionString = ConfigurationManager.AppSettings["StringBd"];
        public BancoDeDados()
        {
            var query = "USE DesafioPaschoalotto";
            using var sqlCon = new SqlConnection(conectionString);
            {
                sqlCon.Open();
            }
        }        
        public void InserirResultadosNoBD(Resultado resultado)
        {
            var query = $"INSERT INTO dbo.Resultados VALUES ('{resultado.wordsPerMinute}','{resultado.keyStrokes}',{resultado.correctWords},{resultado.WrongWords})";
            using var sqlCon = new SqlConnection(conectionString);
            {
                sqlCon.Open();
                using var sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
