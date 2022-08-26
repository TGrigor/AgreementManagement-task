using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgreementManagement.Data;
using AgreementManagement.Data.Entities;
using AgreementManagement.Services;
using AgreementManagement.Models;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;

namespace AgreementManagement.Controllers
{
    public class AgreementsController : Controller
    {
        private readonly IAgreementService _agreementService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly AgreementManagementDbContext _context;

        public AgreementsController(IAgreementService agreementService, IProductService productService, IMapper mapper, AgreementManagementDbContext context)
        {
            _agreementService = agreementService;
            _productService = productService;
            _mapper = mapper;
            _context = context;
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

        // GET: Agreements/Create
        [Authorize]
        public async Task<IActionResult> Create()
            => View(new AgreementCreateModel(_mapper.Map<List<SelectListItem>>(await _productService.GetProductsSimpleData()),
                                             _mapper.Map<List<SelectListItem>>(await _productService.GetProductGroupsSimpleData())));

        // POST: Agreements/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgreementCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                await _agreementService.CreateAgreementAsync(currentUserId, model);
                return RedirectToAction(nameof(Index));
            }

            model.Products = _mapper.Map<List<SelectListItem>>(await _productService.GetProductsSimpleData());
            model.ProductGroups = _mapper.Map<List<SelectListItem>>(await _productService.GetProductGroupsSimpleData());
            return View(model);
        }



        // GET: Agreements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agreement = await _context.Agreements.FindAsync(id);
            if (agreement == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", agreement.UserId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", agreement.ProductId);
            ViewData["ProductGroupId"] = new SelectList(_context.ProductGroups, "Id", "Id", agreement.ProductGroupId);
            return View(agreement);
        }

        // POST: Agreements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,ProductId,ProductGroupId,EffectiveDate,ExpirationDate,ProductPrice,NewPrice,Id,IsDeleted,CreatedOn,UpdatedOn")] Agreement agreement)
        {
            if (id != agreement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agreement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgreementExists(agreement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", agreement.UserId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", agreement.ProductId);
            ViewData["ProductGroupId"] = new SelectList(_context.ProductGroups, "Id", "Id", agreement.ProductGroupId);
            return View(agreement);
        }

        // GET: Agreements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agreement = await _context.Agreements
                .Include(a => a.IdentityUser)
                .Include(a => a.Product)
                .Include(a => a.ProductGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agreement == null)
            {
                return NotFound();
            }

            return View(agreement);
        }

        // POST: Agreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agreement = await _context.Agreements.FindAsync(id);
            _context.Agreements.Remove(agreement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgreementExists(int id)
        {
            return _context.Agreements.Any(e => e.Id == id);
        }
    }
}
