using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurdueDiningRT.DataModel.Models
{
    /// <summary>
    /// Each dining court location (e.g. Ford, Wiley, etc)
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Friendly name of the location (Ford, Wiley, etc)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Meals available at this location
        /// </summary>
        public List<Meal> Meals { get; set; }

        /// <summary>
        /// Overview list including this location and all meals available here
        /// </summary>
        public List<object> StationOverview
        {
            get
            {
                var overviewList = new List<object>();
                overviewList.Add(this);
                overviewList.AddRange(Meals);
                return overviewList;
            }
        }
    }
}
