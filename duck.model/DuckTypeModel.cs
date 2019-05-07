using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using duck.model.Concrete;
using System.Data.SqlClient;

namespace duck.model
{
    public class DuckTypeModel
    {
        
        public List<DuckType> GetDuckTypes() {

            List<DuckType> duckTypes = new List<DuckType>();

            using (SqlConnection connection = new SqlConnection(DuckConnection.Connection)) {

                
                SqlCommand command = new SqlCommand("Select * from DuckType");
                command.CommandType = System.Data.CommandType.Text;

                command.Connection = connection;

                connection.Open();

                SqlDataReader dr = command.ExecuteReader();



                while (dr.Read()) {


                    duckTypes.Add(
                            new DuckType {
                                DuckTypeID = Convert.ToInt32(dr["DuckTypeID"].ToString()),
                                DuckTypeName = dr["DuckTypeName"].ToString()
                            }
                        );

                }


                dr.Close();
            }


            return duckTypes;

        }

    }
}
