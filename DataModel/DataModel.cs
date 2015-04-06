using PurdueDiningRT.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace PurdueDiningRT.DataModel
{
    public class DataModel
    {
        public static readonly string BASEURL = "http://api.hfs.purdue.edu/menus/v1/";
        
        /// <summary>
        /// The date this menu represents
        /// </summary>
        public DateTime MenuDate {
            get
            {
                if (_MenuDate == null)
                {
                    _MenuDate = DateTime.Now;
                }
                return (DateTime)(_MenuDate);
            }
            set
            {
                _MenuDate = value;
            }
        }
        protected DateTime? _MenuDate;

        /// <summary>
        /// List of dining locations containing menu information
        /// </summary>
        public ObservableCollection<Location> Locations { get; set; }
        
        public DataModel()
        {
            Locations = new ObservableCollection<Location>();
        }

        public async void Fetch()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(BASEURL + "/locations");
                if (response.IsSuccessStatusCode)
                {
                    var locationNames = await response.Content.ReadAsAsync<List<string>>();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        Locations.Clear(); // TODO: Update existing instead of clearing
                    });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    foreach (var locationName in locationNames)
                    {
                        var locationUri = String.Format(BASEURL + "/locations/{0}/{1}-{2}-{3}", locationName, MenuDate.Month.ToString("D2"), MenuDate.Day.ToString("D2"), MenuDate.Year);
                        var locationResponse = await client.GetAsync(locationUri);
                        if (locationResponse.IsSuccessStatusCode)
                        {
                            var locationInfo = await locationResponse.Content.ReadAsAsync<Dictionary<string, List<Station>>>();
                            var location = new Location()
                            {
                                Name = locationName,
                                Meals = locationInfo.Keys.Where(k => locationInfo[k].Count > 0).Select(i => new Meal()
                                {
                                    Name = i,
                                    Stations = locationInfo[i]
                                }).ToList()
                            };
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                            {
                                Locations.Add(location);
                            });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                        }
                    }
                } else
                {
                    throw new Exception("Could not fetch dining court listing.");
                }
            }
        }
    }
}
