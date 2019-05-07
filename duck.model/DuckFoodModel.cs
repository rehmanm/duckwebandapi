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
    public class DuckFoodModel
    {

        public List<DuckFood> GetDuckFoods() {

            List<DuckFood> duckFoods = new List<DuckFood>();

            using (SqlConnection connection = new SqlConnection(DuckConnection.Connection)) {
                
                SqlCommand command = new SqlCommand("Select * from DuckFood");
                command.CommandType = System.Data.CommandType.Text;

                command.Connection = connection;

                connection.Open();

                SqlDataReader dr = command.ExecuteReader();



                while (dr.Read()) {


                    duckFoods.Add(
                            new DuckFood {
                                FoodID = Convert.ToInt32(dr["FoodID"].ToString()),
                                FoodName = dr["FoodName"].ToString()
                            }
                        );

                }


                dr.Close();
            }


            return duckFoods;

        }

    }
}
