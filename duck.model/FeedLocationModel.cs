using duck.model.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duck.model
{
    public class FeedLocationModel
    {
        public List<FeedLocation> GetFeedLocations()
        {

            List<FeedLocation> FeedLocations = new List<FeedLocation>();

            using (SqlConnection connection = new SqlConnection(DuckConnection.Connection))
            {

                SqlCommand command = new SqlCommand("Select * from FeedLocation");
                command.CommandType = System.Data.CommandType.Text;

                command.Connection = connection;

                connection.Open();

                SqlDataReader dr = command.ExecuteReader();



                while (dr.Read())
                {


                    FeedLocations.Add(
                            new FeedLocation
                            {
                                FeedLocationID = Convert.ToInt32(dr["FeedLocationID"].ToString()),
                                FeedLocationName = dr["FeedLocationName"].ToString()
                            }
                        );

                }


                dr.Close();
            }


            return FeedLocations;

        }

    }
}
