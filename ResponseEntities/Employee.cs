using Newtonsoft.Json;

namespace SampleAPILoadTestProjectWithMultithreadedConsoleApp
{

    public class Employee
    {
            [JsonProperty("id")]
            public string id { get; set; }

             [JsonProperty("employee_name")]
            public string employee_name { get; set; }

             [JsonProperty("employee_salary")]
            public string employee_salary { get; set; }

             [JsonProperty("employee_age")]
            public string employee_age { get; set; }

             [JsonProperty("profile_image")]
            public string profile_image { get; set; }


        
    }
}