using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ILTQuizV2.Desk
{
    class DB
    {
        #region ATRIBUTOS
        private MySqlConnection _conexao;
        private MySqlCommand _comando;
        private MySqlDataAdapter _adaptador;
        private DataSet _dados;
        #endregion
        #region GET & SET
        public string Host { get; set; } = "localhost";
        public string DBName { get; set; } = "";
        public string User { get; set; } = "root";
        public string Password { get; set; } = "";
        #endregion
        #region CONSTRUTOR
        public DB() { }
        #endregion
        #region MÉTODOS
        public void Connect()
        {
            string Conexao = "Server=" + Host;
            Conexao += ";Database=" + DBName;
            Conexao += ";Uid=" + User;
            Conexao += ";Pwd=" + Password;
            Conexao += ";SSL Mode=None";

            try
            {
                _conexao = new MySqlConnection(Conexao);
                if (_conexao.State.Equals(ConnectionState.Closed))
                {
                    _conexao.Open();
                }
            }
            catch (MySqlException erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                _conexao.Dispose();
            }
        }

        public DataSet Search(string strSQL)
        {
            if (_conexao.State.Equals(ConnectionState.Closed))
            {
                _conexao.Open();
            }
            try
            {
                _dados = new DataSet();
                _adaptador = new MySqlDataAdapter(strSQL, _conexao);
                _adaptador.Fill(_dados, "tbl_resultado");

                return _dados;
            }
            catch (MySqlException erro)
            {
                _dados = null;
                return _dados;
            }
            finally
            {
                
            }
        }

        public void Inserir(string strSQL)
        {

            try
            {
                if (_conexao.State.Equals(ConnectionState.Closed))
                {
                    _conexao.Open();
                }

                _comando = _conexao.CreateCommand();
                _comando.CommandText = strSQL;

                if (_comando.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Falha ao inserir");
                }
            }
            catch (MySqlException erro)
            {
                throw new Exception("Erro ao inserir: " + erro.Message);
            }
        }
        #endregion
    }
}
