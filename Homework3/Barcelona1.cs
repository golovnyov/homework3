using CsvHelper.Configuration.Attributes;

namespace Homework3
{
    public class Barcelona1
    {
        [Name("id")]
        public int Id { get; set; }

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