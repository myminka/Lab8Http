using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Server
{
    public class Server
    {
        static void Main(string[] args)
        {
            Thread.Sleep(1000);
            HttpListener listener = new HttpListener();

            // установка адресов прослушки
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Waiting connection...");

            while (true)
            {
                HttpListenerContext context = listener.GetContextAsync().Result;
                
                //запрос
                HttpListenerRequest request = context.Request;
                
                //ответ
                HttpListenerResponse response = context.Response;

                Console.WriteLine("Status code: " + response.StatusCode);
                Console.WriteLine("Headers: " + response.Headers);

                string responseString = "<html><head><meta charset='utf8'></head><body>Привет мир!</body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                // закрываем поток
                output.Close();

                // останавливаем прослушивание подключений
                Console.WriteLine("End...");
            }
        }
    }
}