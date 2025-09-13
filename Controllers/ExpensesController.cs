using financeGuide.Data;
using financeGuide.Data.Service;
using financeGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace financeGuide.Controllers
{
    public class ExpensesController(IExpensesService expensesService) : Controller
    {
        private readonly IExpensesService _expensesService = expensesService;

        public async Task<IActionResult> Index()
        {
            var expenses = await _expensesService.GetAll();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expensesService.Add(expense);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetChart()
        {
            var data = _expensesService.GetChartData();
            return Json(data);
        }
    }
}
