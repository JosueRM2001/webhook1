using System.Security.Cryptography.X509Certificates;

namespace webhook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapPost("/webhook", async contex =>
            {
                var requestBody = await contex.Request.ReadFromJsonAsync<WebhookPayload>();
                Console.WriteLine($"Header: {requestBody.Header},Body:{requestBody.Body}");
                contex.Response.StatusCode = 200;
                await contex.Response.WriteAsync("Webhook Ack!");
            });

            app.Run();
            
        }
        public record WebhookPayload(string Header, string Body);
    }
}
