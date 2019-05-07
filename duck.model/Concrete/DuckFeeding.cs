using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duck.model.Concrete
{
    public class DuckFeeding
    {

        public string EmailAddress {get; set;}
	    public string Time {get; set;}
        public int DuckFoodID {get; set;}
	    public int FeedLocationID { get; set;}
	    public int NumberOfDucks {get; set;}
        public string FoodType{get; set;}
	    public float AmountOfFood{get; set;}
        public bool IsRecurring { get; set; }
    }
}
