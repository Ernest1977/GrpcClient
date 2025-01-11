// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Threading.Tasks;
using GrpcClient;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new DiscountClient("https://localhost:5001");

        await client.GenerateDiscountCodesAsync(10);
        await client.UseDiscountCodeAsync("ABC12345");
    }
}
