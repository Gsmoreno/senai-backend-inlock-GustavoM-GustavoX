using Domains;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DEV15\\SQLEXPRESS; initial catalog=InLock_Games_Tarde ;user Id=sa; pwd=sa@132";

        public void Cadastrar(JogosDomain novoJogo)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string queryInsert = "INSERT INTO Jogos(NomeJogo, Descricao, DataLancamento, Valor , IdEstudio ) VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor , @IdEstudio)";

                
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    
                    cmd.Parameters.AddWithValue("@NomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue( "@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);


                    con.Open();

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> jogos = new List<JogosDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "SELECT IdJogo, NomeJogo , Descricao , DataLancamento , Valor , IdEstudio FROM Jogos";


                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {


                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {

                        JogosDomain Jogo = new JogosDomain
                        {

                            IdJogo = Convert.ToInt32(rdr["IdJogo"])
                            ,

                            NomeJogo = rdr[1].ToString()
                            ,
                            Descricao = rdr[1].ToString()
                            ,
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"])
                            ,
                            Valor = Convert.ToDecimal (rdr["Valor"])
                             ,
                            IdEstudio = Convert.ToInt32(rdr["Idestudio"])



                        };


                        jogos.Add(Jogo);
                    }
                }
            }

            return jogos;
        }
    }
}
