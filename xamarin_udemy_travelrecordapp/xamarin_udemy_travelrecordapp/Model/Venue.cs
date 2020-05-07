using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using xamarin_udemy_travelrecordapp.Helpers;

namespace xamarin_udemy_travelrecordapp.Model
{
    public class Venue
    {
        public static string GenerateURL(double latitude, double longitude)
        {
            string strLatitude = latitude.ToString(CultureInfo.InvariantCulture);
            string strLongitude = longitude.ToString(CultureInfo.InvariantCulture);
            return string.Format(Constants.VENUE_SEARCH, strLatitude, strLongitude, Constants.CLIENT_ID, Constants.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
