using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SampleAPILoadTestProjectWithMultithreadedConsoleApp
{

    public static class APIMethods
    {

        public static void GetEmployees()
        {

            var client = new RestClient("http://dummy.restapiexample.com/api/v1/employees");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);



            List<Employee> Employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content.Replace("{\"status\":\"success\",\"data\":", "").Replace("]}", "]"));


        }

        public static void UpdateEmployeeById()
        {
            Random rand = new Random();



            NewEmployee newEmployee = new NewEmployee();
            newEmployee.name = "test_gk_unique" + rand.Next(100, 1000);
            newEmployee.age = rand.Next(1, 100).ToString();
            newEmployee.salary = rand.Next(100, 1000).ToString();

            var client = new RestClient("http://dummy.restapiexample.com/api/v1/update/" + rand.Next(1, 1000));
            var request = new RestRequest(Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(JsonConvert.SerializeObject(newEmployee));
            IRestResponse response = client.Execute(request);






        }


    }
}