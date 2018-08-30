using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILTQuizV2.Desk
{
    class Usuario
    {
        private string _user;
        private string _password;
        private bool _login;

        #region ATRIBUTOS
        public string User
        {
            set
            {
                if ((value.Trim().Length > 0) && (value.Trim().Length <= 12))
                {
                    _user = value;
                }
                else
                {
                    throw new Exception("O nome de usuário deve ter entre 1 e 12 caracteres.");
                }
            }
            get
            {
                return _user;
            }
        }

        public string Password
        {
            set
            {
                if ((value.Trim().Length >= 4) && (value.Trim().Length <= 15))
                {
                    _password = value;
                }
                else
                {
                    throw new Exception("A senha deve ter entre 4 e 15 caracteres.");
                }
            }
            get
            {
                return _password;
            }
        }
        #endregion

        #region METODOS
        public void CriarUsuario(string nome, string senha)
        {
            User = nome;
            Password = senha;
        }

        public void LogarUsuario(string nome, string senha)
        {
            User = nome;
            Password = senha;
        }
        #endregion
    }
}
