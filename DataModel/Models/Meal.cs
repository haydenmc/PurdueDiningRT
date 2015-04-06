using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PurdueDiningRT.DataModel.Models
{
    /// <summary>
    /// Each meal at the dining court (e.g. Breakfast, Lunch, Dinner)
    /// </summary>
    public class Meal
    {
        /// <summary>
        /// Name of the meal (Breakfast, Lunch, Dinner)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Stations with food in this meal
        /// </summary>
        public List<Station> Stations { get; set; }

        /// <summary>
        /// Collection of food items grouped by station
        /// </summary>
        public CollectionViewSource FoodItemCollection
        {
            get
            {
                if (_FoodItemCollection == null)
                {
                    _FoodItemCollection = new CollectionViewSource();
                    _FoodItemCollection.Source = Stations;
                    _FoodItemCollection.IsSourceGrouped = true;
                    _FoodItemCollection.ItemsPath = new Windows.UI.Xaml.PropertyPath("Items");
                }
                return _FoodItemCollection;
            }
        }
        private CollectionViewSource _FoodItemCollection;

    }
}
