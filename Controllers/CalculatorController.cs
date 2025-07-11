using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CalculatorMVC.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        [ActionName("Index")]
        public IActionResult Index()
        {
            string html = @"
                <form method=""post"">
                    <label for=""a"">First number:</label>
                    <br />
                    <input  name=""a""/>
                    <br />
                    <br />
                    <label for=""b"">Second number:</label>
                    <br />
                    <input name=""b""/>
                    <br />
                    <br />
                    <label for=""operation"">Arithmetic operation</label>
                    <select name=""operation"">
                        <option value=""+"">Addition</option>
                        <option value=""-"">Subtraction</option>
                        <option value=""*"">Multiplication</option>
                        <option value=""/"">Division</option>
                    </select>
                    <br />
                    <br />
                    <button type=""submit"">Calculate</button>
                </form>
            ";
            return Content(html, "text/html", Encoding.UTF8);
        }
        [HttpPost]
        [ActionName("Index")]
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
                        return Content("<h1>Infinite</h1>", "text/html", Encoding.UTF8);
                    result = a / b;
                    break;
                default:
                    return Content("<h1>Incorrect input</h1>", "text/html", Encoding.UTF8);
            }
            
            string html = $"<p>{a} {operation} {b} = {result}</p>";
            return Content(html, "text/html", Encoding.UTF8);
        }
    }
}
