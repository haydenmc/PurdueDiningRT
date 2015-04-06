using PurdueDiningRT.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PurdueDiningRT.TemplateSelectors
{
    public class LocationPivotTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LocationOverviewTemplate { get; set; }
        public DataTemplate StationListTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item.GetType() == typeof(Location))
            {
                return LocationOverviewTemplate;
            }
            return StationListTemplate;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
    }
}
