using System.Collections.Generic;

namespace Tests.Models
{
    public class ResponseModel
    {
        public object error { get; set; }
        public List<Result> result { get; set; }

        public class Result
        {
            public string name { get; set; }
            public string type { get; set; }
            public string country { get; set; }
            public string city { get; set; }
        }
    }
}