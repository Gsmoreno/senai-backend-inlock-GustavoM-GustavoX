using Domains;
using Senai.InLock.WebApi.Interfaces;
<<<<<<< HEAD
using Senai.InLock.WebApi.ViewModel;
=======
>>>>>>> cbfcb0183feaad0320512b3ebcef5d27bddd47d9
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
<<<<<<< HEAD
        private string stringConexao = "Data Source=DEV15\\SQLEXPRESS; initial catalog=InLock_Games_Tarde ;user Id=sa; pwd=sa@132";

        public UsuariosDomain BuscarPorEmailSenha(LoginViewModel login)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string busca = $"SELECT U.IdUsuario, U.Email , U.Senha , U.IdTipoUsuario, T.Titulo FROM Usuarios U INNER JOIN" +
                    $" TipoUsuarios T ON U.IdTipoUsuario = T.IdTipoUsuario WHERE Email = '{login.Email}' AND Senha = '{login.Senha}'";

                using (SqlCommand cmd = new SqlCommand(busca, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if(rdr.HasRows)
                    {
                        while(rdr.Read())
                        {
                            UsuariosDomain user = new UsuariosDomain
                            {
                                IdUsuario = Convert.ToInt32(rdr[0]),
                                Email = rdr[1].ToString(),
                                Senha = rdr[2].ToString(),
                                IdTipoUsuario = Convert.ToInt32(rdr[3]),
                                TipoUsuario =
                                {
                                    Titulo = rdr[4].ToString(),
                                    IdTipoUsuario = Convert.ToInt32(rdr[3])
                                }
                            };

                            return user;
                        }
                    }
                    return null;
=======
        private string stringConexao = "Data Source=DEV501\\SQLEXPRESS; initial catalog=Peoples; user Id=sa; pwd=sa@132";

        public void Cadastrar(UsuariosDomain novoUsuario)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Usuarios(Email, Senha, IdTipoUsuario) " +
                                     "VALUES (@Email, @Senha, @IdTipoUsuario)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", novoUsuario.IdTipoUsuario);


                    con.Open();


                    cmd.ExecuteNonQuery();
>>>>>>> cbfcb0183feaad0320512b3ebcef5d27bddd47d9
                }
            }
        }

        public List<UsuariosDomain> Listar()
        {
            List<UsuariosDomain> usuarios = new List<UsuariosDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuarios";


                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {


                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {

                        UsuariosDomain usuario = new UsuariosDomain
                        {

                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"])


                            ,
<<<<<<< HEAD
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
=======
                            Email = rdr["@Email"].ToString(),
                            Senha = rdr["@Senha"].ToString(),
>>>>>>> cbfcb0183feaad0320512b3ebcef5d27bddd47d9
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])



                        };


                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }
    }
}

