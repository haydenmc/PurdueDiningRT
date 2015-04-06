using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurdueDiningRT.DataModel.Models
{
    /// <summary>
    /// Represents a serving station in a dining court
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Name of the serving station (e.g. Granite Grill)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Food items served at this station
        /// </summary>
        public List<FoodItem> Items { get; set; }
    }
}
