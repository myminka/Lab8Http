using System;
using System.Net.Http;

namespace Lab8Http
{
    internal class Client
    {
        static void Main(string[] args)
        {
            Console.Write("Write Uri-address: ");
            string uriAddress = Console.ReadLine();
            HttpClient client = new HttpClient();

            Uri uri = new Uri(uriAddress);

            string result = client.GetStringAsync(uri).Result;

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
