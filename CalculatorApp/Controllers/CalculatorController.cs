using CalculatorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Index()
        {
            var model = new CalculatorModel
            {
                Result = 0 // Initialize Result with a default value
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalculatorModel model)
        {
            switch (model.Operation)
            {
                case "Add":
                    model.Result = model.Number1 + model.Number2;
                    break;
                case "Subtract":
                    model.Result = model.Number1 - model.Number2;
                    break;
                case "Multiply":
                    model.Result = model.Number1 * model.Number2;
                    break;
                case "Divide":
                    if (model.Number2 != 0)
                        model.Result = model.Number1 / model.Number2;
                    else
                        ViewBag.Error = "Cannot divide by zero";
                    break;
            }
            return View(model);
        }
    }
}
