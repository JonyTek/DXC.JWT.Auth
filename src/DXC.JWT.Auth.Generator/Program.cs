using System;
using DXC.JWT.Auth.Core;
using Newtonsoft.Json;

namespace DXC.JWT.Auth.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = JwtProviderFactory.Create()
                .CreateToken(
                    "jonathontek@gmail.com", "p@ssw0rd"
                );

            Console.WriteLine(
                JsonConvert.SerializeObject(token, Formatting.Indented)
            );

            Console.ReadKey();
        }
    }
}
