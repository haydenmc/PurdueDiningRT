using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurdueDiningRT.DataModel.Models
{
    /// <summary>
    /// Represents a food item, (e.g. Breakfast Enchiladas)
    /// </summary>
    public class FoodItem
    {
        /// <summary>
        /// Name of the food item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Whether or not the food item is vegetarian
        /// </summary>
        public bool IsVegetarian { get; set; }
    }
}
