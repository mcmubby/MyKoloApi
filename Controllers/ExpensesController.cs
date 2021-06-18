using System;
using Microsoft.AspNetCore.Mvc;
using MyKoloApi.Data;
using MyKoloApi.DTOs;
using MyKoloApi.Models;

namespace MyKoloApi.Controllers
{
    [ApiController]
    [Route("Expenses")]
    public class ExpensesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddExpense(AddExpenseDto requestBody)
        {
            Expense expense = new Expense()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = requestBody.UserId,
                Amount = requestBody.Amount,
                Description = requestBody.Description
            };

            _context.Set<Expense>().Add(expense);
            _context.SaveChanges();

            return Ok(expense.Id);
        }
    }
}