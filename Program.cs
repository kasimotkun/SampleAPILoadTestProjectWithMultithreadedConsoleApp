using System;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;


namespace SampleAPILoadTestProjectWithMultithreadedConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string methodName = args[0].Split("=")[1];



            if (IsMethodExists((typeof(APIMethods)), methodName) == false)
            {
                Console.Write("\n" + methodName + " is not in the list. Please enter the correct method name!!\n");
                return;
            }


            int threadCount = 0;

            try
            {
                threadCount = Int32.Parse(args[1].Split("=")[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("treadCount value that you entered is not a numeric value. Please type a numeric value");
            }



            Parallel.For(1, threadCount + 1, (i, state) =>
              {
                  if (methodName == "GetEmployees")
                      APIMethods.GetEmployees();
                  else if (methodName == "UpdateEmployeeById")
                      APIMethods.UpdateEmployeeById();


                  Console.WriteLine(methodName + " is running. ThreadId=" + i);


              });
        }

        private static bool IsMethodExists(Type myType, string methodName)
        {
            bool isMethodExists = false;



            MethodInfo[] myArrayMethodInfo = myType.GetMethods();

            Console.WriteLine("METHOD LIST:");

            foreach (MethodInfo method in myArrayMethodInfo)
            {
                Console.WriteLine(method.Name);

                if (method.Name == methodName)
                {
                    isMethodExists = true;
                    break;
                }

            }


            return isMethodExists;

        }


    }
}
