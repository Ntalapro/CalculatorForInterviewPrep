using CalculatorForInterviewPrep.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using CalculatorForInterviewPrep.Services;
using CalculatorForInterviewPrep.Operations;
using CalculatorForInterviewPrep.Repositories;
using CalculatorForInterviewPrep.Models.Services;
using CalculatorForInterviewPrep.Models.Operations;

namespace CalculatorForInterviewPrep.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ILogger<CalculatorController> _logger;
        private readonly IFilteredResultsDisplayService _filteredResultsDisplayService;
        private readonly IOperationFactory _operationFactory;

        public CalculatorController(ICalculatorService calculatorService, ILogger<CalculatorController> logger
                                    , IFilteredResultsDisplayService filteredResultsDisplayService, IOperationFactory operationFactory)
        {
            _calculatorService = calculatorService;
            _logger = logger;
            _filteredResultsDisplayService = filteredResultsDisplayService;
            _operationFactory = operationFactory;
        }

        // GET: /Calculator/Index
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation($"Index(Action) -> Calculation results view, running filter methods");
                var positiveResults = await _filteredResultsDisplayService.GetPositiveResultsAsync();
                var negativeResults = await _filteredResultsDisplayService.GetNegativeResultsAsync(); ;
                var zeroResults = await _filteredResultsDisplayService.GetZeroResultsAsync();

                ViewData["PositiveResults"] = positiveResults;
                ViewData["NegativeResults"] = negativeResults;
                ViewData["ZeroResults"] = zeroResults;
                _logger.LogInformation($"Index(Action) -> Filtered results displayed");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Index(Action) -> Filter display error: {ex.Message}");
                ViewData["Error"] = ex.Message;
                return View("Error");
            }

            return View();
        }

        // POST: /Calculator/Calculate
        [HttpPost]
        public async Task<IActionResult> Calculate(string operation, double operand1, double operand2)
        {
            try // addiion 1 2 = 3
            {
                _logger.LogInformation($"Calculate(Action) -> Calculation requested: {operand1} {operation} {operand2}");

                double result = await _calculatorService.PerformCalculationAsync(_operationFactory.GetCalculationStratey(operation), operand1, operand2);

                return View("Result", result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Calculate(Action) -> Calculation error: {ex.Message}");
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