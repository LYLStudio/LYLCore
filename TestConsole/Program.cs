using System;

using TestConsole.Services;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestModelDataServiceTest dataServiceTest = new TestModelDataServiceTest();

            dataServiceTest.Create();

            dataServiceTest.Fetch();

            dataServiceTest.Update();

            dataServiceTest.Delete();

            dataServiceTest.IsExist();

            Console.ReadLine();
        }
    }
    

}
