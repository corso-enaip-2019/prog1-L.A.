using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P19_Web_Dynamic_07_FullStack.DataAccess;
using P19_Web_Dynamic_07_FullStack.Infrastructure;
using P19_Web_Dynamic_07_FullStack.Infrastructure.Exceptions;
using P19_Web_Dynamic_07_FullStack.Models;
using P19_Web_Dynamic_07_FullStack.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P19_Web_Dynamic_07_FullStack.Controllers
{
    public class VillainsController : BaseController
    {
        private static bool _firstTime = true;

        public VillainsController(AppDbContext context)
            : base(context)
        { }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (_firstTime)
            {
                ViewData["InitialMessage"] = "Welcome to the villains management!";
                _firstTime = false;
            }

            var vms = await _context
                .Villains
                .Include(x => x.Nemesis)
                .Select(x => new VillainRowViewModel
                    {
                        Id = x.Id,
                        VillainName = x.VillainName,
                        KilledPeople = x.KilledPeople,
                        KidnappedPeople = x.KidnappedPeople,
                        Nemesis = x.Nemesis.HeroName,
                        Characteristics = x.Characteristics,
                    })
                .ToListAsync();

            return View(vms);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["superheroes"] = await GetSuperheroNamesAsync();

            var viewModel = await GetViewModelAsync(id);

            if (viewModel == null)
            {
                TempData["MessageText"] = "Villain not found!";
                TempData["MessageSeverity"] = MessageSeverity.Error;
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VillainEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var toUpdate = await _context.Villains
                        .Include(x => x.Nemesis)
                        .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

                    toUpdate.Characteristics = viewModel.Characteristics;
                    toUpdate.KilledPeople = viewModel.KilledPeople;
                    toUpdate.KidnappedPeople = viewModel.KidnappedPeople;
                    toUpdate.NemesisId = viewModel.NemesisId;
                    toUpdate.SecretName = viewModel.SecretName;
                    toUpdate.Strength = viewModel.Strength;
                    toUpdate.VillainName = viewModel.VillainName;

                    await _context.SaveChangesAsync();

                    TempData["MessageText"] = "Villain successfully updated!";
                    TempData["MessageSeverity"] = MessageSeverity.Ok;
                }
                catch (NotFoundException)
                {
                    TempData["MessageText"] = "Villain not found!";
                    TempData["MessageSeverity"] = MessageSeverity.Error;
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["nemesis"] = await GetSuperheroNamesAsync();
                return View(viewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewData["superheroes"] = await GetSuperheroNamesAsync();
            var viewModel = new VillainAddViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(VillainAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new Villain();

                model.SecretName = viewModel.SecretName;
                model.VillainName = viewModel.VillainName;
                model.KilledPeople = viewModel.KilledPeople;
                model.KidnappedPeople = viewModel.KidnappedPeople;
                model.Characteristics = viewModel.Characteristics;
                model.Strength = viewModel.Strength;
                model.NemesisId = viewModel.NemesisId;

                _context.Villains.Add(model);

                await _context.SaveChangesAsync();

                TempData["MessageText"] = "Villain successfully updated!";
                TempData["MessageSeverity"] = MessageSeverity.Ok;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["superheroes"] = await GetSuperheroNamesAsync();
                return View(viewModel);
            }
        }

        private async Task<List<SelectListItem>> GetSuperheroNamesAsync()
        {
            return await _context
                .Superheroes
                .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.HeroName,
                    })
                .ToListAsync();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await GetViewModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var toRemove = await _context.Villains.FirstOrDefaultAsync(x => x.Id == id);
                _context.Villains.Remove(toRemove);
                await _context.SaveChangesAsync();

                TempData["MessageText"] = "Villain successfully deleted!";
                TempData["MessageSeverity"] = MessageSeverity.Ok;
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                TempData["MessageText"] = "Villain not found!";
                TempData["MessageSeverity"] = MessageSeverity.Error;
                return RedirectToAction(nameof(VillainNotFound));
            }
        }

        [HttpGet]
        public IActionResult VillainNotFound()
        {
            return View();
        }

        private async Task<VillainEditViewModel> GetViewModelAsync(int id)
        {
            return await _context
                .Villains
                .Select(x => new VillainEditViewModel
                    {
                        Id = x.Id,
                        Characteristics = x.Characteristics,
                        KilledPeople = x.KilledPeople,
                        KidnappedPeople = x.KidnappedPeople,
                        NemesisId = x.NemesisId,
                        VillainName = x.VillainName,
                        SecretName = x.SecretName,
                        Strength = x.Strength,
                    })
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
