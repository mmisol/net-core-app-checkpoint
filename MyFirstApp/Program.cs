using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace MyFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            //configBuilder.AddJsonFile("appsettings.json");
            var inMemoryConfig = new Dictionary<string, string>()
            {
                ["AppConfiguration:MainWindow:Width"] = "70",
                ["AppConfiguration:MainWindow:Height"] = "10"
            };
            configBuilder.AddInMemoryCollection(inMemoryConfig);
            IConfiguration config = configBuilder.Build();
            //Not supported on Mac https://github.com/dotnet/runtime/issues/27216
            Console.SetWindowSize(int.Parse(config["AppConfiguration:MainWindow:Width"]), int.Parse(config["AppConfiguration:MainWindow:Height"]));
            Console.WriteLine($"Width={Console.WindowWidth}, Height={Console.WindowHeight}");
            Console.WriteLine("Hello World!");
            
        }
    }
}
