using CalculatorForInterviewPrep.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using CalculatorForInterviewPrep.Services;
using CalculatorForInterviewPrep.Operations;
using CalculatorForInterviewPrep.Repositories;

namespace CalculatorForInterviewPrep.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorController(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        // GET: /Calculator/Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Calculator/Calculate
        [HttpPost]
        public async Task<IActionResult> Calculate(string operation, double operand1, double operand2)
        {
            try
            {
                // using PATTERN MATCHING - switch expression
                CalculationOperation calculation = operation.ToLower() switch
                {
                    "add" => new Addition(),
                    "subtract" => new Subtraction(),
                    "multiply" => new Multiplication(),
                    "divide" => new Division(),
                    _ => throw new ArgumentException("Invalid operation")
                };

                double result = await _calculatorService.PerformCalculationAsync(calculation, operand1, operand2);

                return View("Result", result);
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View("Error");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }

}