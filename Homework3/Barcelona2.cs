using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace Homework3
{
    public class Barcelona2
    {
        [Name("listing_url")]
        public string Url { get; set; }

        [Ignore]
        public int Id
        {
            get
            {
                return int.Parse(Url.Substring(Url.LastIndexOf('/') + 1), CultureInfo.InvariantCulture);
            }
        }

        [Name("name")]
        public string Name { get; set; }

        [Name("zipcode")]
        public string ZipCode { get; set; }

        [Name("smart_location")]
        public string SmartLocation { get; set; }

        [Name("country")]
        public string Country { get; set; }

        [Name("latitude")]
        public string Latitude { get; set; }

        [Name("longitude")]
        public string Longitude { get; set; }
    }
}
