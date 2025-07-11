using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CalculatorMVC.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(decimal a, decimal b, string operation)
        {
           
            decimal result = 0;
            switch (operation)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    if (b == 0)
                        return View("Calculate", "Infinite");
                    result = a / b;
                    break;
                default:
                    return View("Calculate", "Incorrect Input");
            }

            string message = $"{a} {operation} {b} = {result}";
            
            return View("Calculate", message);
        }
    }
}
