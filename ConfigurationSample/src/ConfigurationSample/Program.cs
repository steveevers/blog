using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("Config.json")
                .AddJsonFile("Config.Debug.json", optional: true)
                //  .AddJsonFile("Config.[anything].json", optional: true)
                .Build()
                .GetSection("Config")
                .Bind(new Config());

            Console.WriteLine(Config.MyNumber);
            Console.ReadKey();
        }
    }
}
