using Domains;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
<<<<<<< HEAD
        private string stringConexao = "Data Source=DEV15\\SQLEXPRESS\\SQLDEVELOPER; initial catalog=InLock_Games_Tarde; integrated security=true;";
=======
        private string stringConexao = "Data Source=DEV501\\SQLEXPRESS; initial catalog=Peoples; user Id=sa; pwd=sa@132";
>>>>>>> cbfcb0183feaad0320512b3ebcef5d27bddd47d9

        public void Cadastrar(EstudiosDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
<<<<<<< HEAD
               
                string queryInsert = "INSERT INTO Estudios(NomeEstudio) VALUES (@NomeEstudio)";

                
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                  
                    cmd.Parameters.AddWithValue("@NomeEstudio", novoEstudio.NomeEstudio);
                    

                    
                    con.Open();

                   
                    cmd.ExecuteNonQuery();
                }
            }

        }
=======
>>>>>>> cbfcb0183feaad0320512b3ebcef5d27bddd47d9

                string queryInsert = "INSERT INTO Estudios(NomeEstudio) " +
                                     "VALUES (@NomeEstudio)";

<<<<<<< HEAD
           
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudios";
=======
>>>>>>> cbfcb0183feaad0320512b3ebcef5d27bddd47d9

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@NomeEstudio", novoEstudio.NomeEstudio);

                    con.Open();


                    cmd.ExecuteNonQuery();
                }
            }
        }

            public List<EstudiosDomain> Listar()
            {
                List<EstudiosDomain> estudios = new List<EstudiosDomain>();


                using (SqlConnection con = new SqlConnection(stringConexao))
                {

                    string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudios";


                    con.Open();


                    SqlDataReader rdr;


                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {


                        rdr = cmd.ExecuteReader();


                        while (rdr.Read())
                        {
<<<<<<< HEAD
                            
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
=======
>>>>>>> cbfcb0183feaad0320512b3ebcef5d27bddd47d9

                            EstudiosDomain estudio = new EstudiosDomain
                            {

                                IdEstudio = Convert.ToInt32(rdr["Idestudio"])


                                ,
                                NomeEstudio = rdr[1].ToString()



                            };


                            estudios.Add(estudio);
                        }
                    }
                }

                return estudios;
            }

        
    }
}


