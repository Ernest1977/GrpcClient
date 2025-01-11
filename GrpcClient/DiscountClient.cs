using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Stripe;

namespace GrpcClient
{
    //internal class DiscountClient
    //{
        public class DiscountClient
            {
                private class GenerateRequest {
                    public int Count { get; set; }
                }

                private class UseRequest
                {
                    public int Count { get; set; }
                    public string Code { get; internal set; }
                }


                private readonly Discount.DiscountClient _client;

                public DiscountClient(string address)
                {
                    var channel = GrpcChannel.ForAddress(address);
                    _client = new Discount.DiscountClient(channel);
                }

                public async Task GenerateDiscountCodesAsync(int count)
                {
                    var request = new GenerateRequest { Count = count };
                    var response = await _client.GenerateDiscountCodesAsync(request);

                    Console.WriteLine("Generated Discount Codes:");
                    foreach (var code in response.Codes)
                    {
                        Console.WriteLine(code);
                    }
                }

                public async Task UseDiscountCodeAsync(string code)
                {
                    var request = new UseRequest { Code = code };
                    var response = await _client.UseDiscountCodeAsync(request);

                    Console.WriteLine(response.Success ? "Code used successfully" : "Code already used");
                }
            }
    //}
}
