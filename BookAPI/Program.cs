namespace BookAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //adding services
            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();

            //app.MapGet("/", () => "Hello World!");

            app.MapGet("/", () => { 
            
                return Results.Redirect("api/books");
            
            });

            app.Run();
        }
    }
}
