using System.Collections.Generic;

namespace Tests.Models
{
    public class ResponseModel
    {
        public object error { get; set; }
        public List<Result> result { get; set; }

        public class Result
        {
            public int id { get; set; }
            public int city_id { get; set; }
            public string timezone { get; set; }
            public int timezone_gmt { get; set; }
            public string name { get; set; }
            public string name_orig { get; set; }
            public string name_ascii { get; set; }
            public string city_slug { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
            public int hotels { get; set; }
            public int population { get; set; }
            public string fcode { get; set; }
            public string type { get; set; }
            public string country_code { get; set; }
            public string country_slug { get; set; }
            public string admin1 { get; set; }
            public string admin2 { get; set; }
            public string currency { get; set; }
            public object stars { get; set; }
            public string country { get; set; }
            public string admin1code { get; set; }
            public object admin2code { get; set; }
            public object map_view { get; set; }
            public int rel { get; set; }
            public int? fr_stars { get; set; }
            public int? type_id { get; set; }
            public string city_name_ascii { get; set; }
            public string city_name { get; set; }
            public object state { get; set; }
            public string iata { get; set; }
            public string city { get; set; }
            public int? weight { get; set; }
        }
    }
}