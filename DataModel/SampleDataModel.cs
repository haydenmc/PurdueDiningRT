using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurdueDiningRT.DataModel
{
    class SampleDataModel : DataModel
    {
        public SampleDataModel()
        {
            Locations.Add(new Models.Location()
            {
                Name = "Test Location 1",
                Meals = new List<Models.Meal>()
                {
                    new Models.Meal()
                    {
                        Name = "Breakfast",
                        Stations = new List<Models.Station>()
                    },
                    new Models.Meal()
                    {
                        Name = "Lunch",
                        Stations = new List<Models.Station>()
                    }
                }
            });
        }

        public new void Fetch()
        {
            return;
        }
    }
}
