using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgreementManagement.Data;
using AgreementManagement.Data.Entities;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using AgreementManagement.Models;
using AgreementManagement.Services;

namespace AgreementManagement.Controllers
{
    public class AgreementsController : Controller
    {
        private readonly IAgreementService _agreementService;

        public AgreementsController(IAgreementService agreementService)
        {
            _agreementService = agreementService;
        }

        // GET: Agreements
        public async Task<IActionResult> Index()
            => View(await _agreementService.GetAgreementListAsync());

        // GET: Agreements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agreement = await _agreementService.GetAgreementAsync(id.Value);

            if (agreement == null)
            {
                return NotFound();
            }

            return View(agreement);
        }

        //// GET: Agreements/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
        //    ViewData["ProductGroupId"] = new SelectList(_context.ProductGroups, "Id", "Id");
        //    return View();
        //}

        //// POST: Agreements/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserId,ProductId,ProductGroupId,EffectiveDate,ExpirationDate,ProductPrice,NewPrice,Id,IsDeleted,CreatedOn,UpdatedOn")] Agreement agreement)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(agreement);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", agreement.UserId);
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", agreement.ProductId);
        //    ViewData["ProductGroupId"] = new SelectList(_context.ProductGroups, "Id", "Id", agreement.ProductGroupId);
        //    return View(agreement);
        //}

        //// GET: Agreements/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var agreement = await _context.Agreements.FindAsync(id);
        //    if (agreement == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", agreement.UserId);
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", agreement.ProductId);
        //    ViewData["ProductGroupId"] = new SelectList(_context.ProductGroups, "Id", "Id", agreement.ProductGroupId);
        //    return View(agreement);
        //}

        //// POST: Agreements/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("UserId,ProductId,ProductGroupId,EffectiveDate,ExpirationDate,ProductPrice,NewPrice,Id,IsDeleted,CreatedOn,UpdatedOn")] Agreement agreement)
        //{
        //    if (id != agreement.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(agreement);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AgreementExists(agreement.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", agreement.UserId);
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", agreement.ProductId);
        //    ViewData["ProductGroupId"] = new SelectList(_context.ProductGroups, "Id", "Id", agreement.ProductGroupId);
        //    return View(agreement);
        //}

        //// GET: Agreements/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var agreement = await _context.Agreements
        //        .Include(a => a.IdentityUser)
        //        .Include(a => a.Product)
        //        .Include(a => a.ProductGroup)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (agreement == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(agreement);
        //}

        //// POST: Agreements/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var agreement = await _context.Agreements.FindAsync(id);
        //    _context.Agreements.Remove(agreement);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AgreementExists(int id)
        //{
        //    return _context.Agreements.Any(e => e.Id == id);
        //}
    }
}
