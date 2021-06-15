using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoesWebsite.Models;
using ShoesWebsite.Providers;

namespace ShoesWebsite.Controllers
{
    public class ShoesController : Controller
    {
        private readonly IManageProvider _shoesProvider;

        public ShoesController(IManageProvider manageProvider)
        {
            _shoesProvider = manageProvider;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _shoesProvider.GetAll());
        }

        public async Task<IActionResult> AddOrEdit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View(new ShoesModel());
            }
            else
            {
                return View(await _shoesProvider.Get(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(ShoesModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == Guid.Empty)
                {
                    await _shoesProvider.Create(model);
                }
                else
                {
                    await _shoesProvider.Update(model);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _shoesProvider.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
