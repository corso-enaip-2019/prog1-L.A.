using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P19_Web_Dynamic_07_FullStack.Controllers;
using P19_Web_Dynamic_07_FullStack.DataAccess;
using P19_Web_Dynamic_07_FullStack.Infrastructure;
using P19_Web_Dynamic_07_FullStack.Infrastructure.Exceptions;
using P19_Web_Dynamic_07_FullStack_ANTONELLI.ViewModels;

namespace P19_Web_Dynamic_07_FullStack_ANTONELLI.Controllers
{
    public class SupportersController : BaseController
    {

        private static bool _firstTime = true;

        public SupportersController(AppDbContext context)
           : base(context)
        { }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (_firstTime)
            {
                ViewData["InitialMessage"] = "Welcome to the supporters management!";
                _firstTime = false;
            }

            var vms = await _context
                .Supporters
                .Select(x => new SupporterRowViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Birth = x.Birth,
                    SupportedHero = x.SupportedHero
                })
                .ToListAsync();

            return View(vms);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SupporterEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var toUpdate = await _context.Supporters
                        .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

                    toUpdate.Name = viewModel.Name;
                    toUpdate.Surname = viewModel.Surname;
                    toUpdate.Birth = viewModel.Birth;
                    toUpdate.SupportedHero = viewModel.SupportedHero;
                    await _context.SaveChangesAsync();
                    TempData["MessageText"] = "Supporter successfully updated!";
                    TempData["MessageSeverity"] = MessageSeverity.Ok;
                }
                catch (NotFoundException)
                {
                    TempData["MessageText"] = "Supporter not found!";
                    TempData["MessageSeverity"] = MessageSeverity.Error;
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(viewModel);
            }
        }


    }
}