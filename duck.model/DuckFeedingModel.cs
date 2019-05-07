using duck.model.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duck.model
{
    public class DuckFeedingModel
    {

        public int SaveDuckFeeding(DuckFeeding df) {

            int result = 0;
            using (SqlConnection connection = new SqlConnection(DuckConnection.Connection))
            {

                SqlCommand command = new SqlCommand("USP_INSERT_DUCKFEEDING");
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection = connection;

                SqlParameter email = new SqlParameter();
                email.ParameterName = "@EmailAddress";
                email.Value = df.EmailAddress;
                command.Parameters.Add(email);

                SqlParameter time = new SqlParameter();
                time.ParameterName = "@Time";
                time.Value = df.Time;
                command.Parameters.Add(time);

                SqlParameter duckFoodID = new SqlParameter();
                duckFoodID.ParameterName = "@DuckFoodID";
                duckFoodID.Value = df.DuckFoodID;
                command.Parameters.Add(duckFoodID);

                SqlParameter feedLocationID = new SqlParameter();
                feedLocationID.ParameterName = "@FeedLocationID";
                feedLocationID.Value = df.FeedLocationID;
                command.Parameters.Add(feedLocationID);

                SqlParameter numberOfDucks = new SqlParameter();
                numberOfDucks.ParameterName = "@NumberOfDucks";
                numberOfDucks.Value = df.NumberOfDucks;
                command.Parameters.Add(numberOfDucks);

                SqlParameter foodType = new SqlParameter();
                foodType.ParameterName = "@FoodType";
                foodType.Value = df.FoodType;
                command.Parameters.Add(foodType);

                SqlParameter amountOfFood = new SqlParameter();
                amountOfFood.ParameterName = "@AmountOfFood";
                amountOfFood.Value = df.AmountOfFood;
                command.Parameters.Add(amountOfFood);

                SqlParameter isRecurring = new SqlParameter();
                isRecurring.ParameterName = "@IsRecurring";
                isRecurring.Value = df.IsRecurring;
                command.Parameters.Add(isRecurring);

                connection.Open();

                result = command.ExecuteNonQuery();
                
            }

            return result;

        }


    }
}
