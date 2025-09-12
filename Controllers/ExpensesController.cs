using financeGuide.Data;
using financeGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace financeGuide.Controllers
{
    public class ExpensesController(FinanceAppContext context) : Controller
    {
        private readonly FinanceAppContext _context = context;

        public async Task<IActionResult> Index()
        {
            var expenses = await _context.Expenses.ToListAsync();
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
                _context.Expenses.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
