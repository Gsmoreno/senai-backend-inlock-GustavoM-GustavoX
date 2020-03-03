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
        public void Cadastrar(EstudiosDomain novoEstudio)
        {
            
        }

        public List<EstudiosDomain> Listar()
        {
            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

           
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                
                string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudios";

            
                con.Open();

                
                SqlDataReader rdr;

               
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    
                    rdr = cmd.ExecuteReader();

                    
                    while (rdr.Read())
                    {
                       
                        EstudiosDomain estudio= new EstudiosDomain
                        {
                            
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"])

                           
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
