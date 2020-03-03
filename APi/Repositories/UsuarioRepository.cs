﻿using Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV501\\SQLEXPRESS; initial catalog=Peoples; user Id=sa; pwd=sa@132";

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
                            Email = rdr["@Email"].ToString(),
                            Senha = rdr["@Senha"].ToString(),
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

