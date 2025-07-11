namespace CalculatorMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllerRoute("default", "{controller=Calculator}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
