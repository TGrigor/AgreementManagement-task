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
    [Authorize]
    public class AgreementsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAgreementService _agreementService;
        private readonly IProductService _productService;

        public AgreementsController(IMapper mapper, IProductService productService, IAgreementService agreementService)
        {
            _mapper = mapper;
            _agreementService = agreementService;
            _productService = productService;
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

            var agreement = await _agreementService.GetAgreementAsync<AgreementModel>(id.Value);

            if (agreement == null)
            {
                return NotFound();
            }

            return View(agreement);
        }

        // GET: Agreements/Create
        
        public async Task<IActionResult> Create()
            => View(new AgreementCreateModel(_mapper.Map<List<SelectListItem>>(await _productService.GetProductsSimpleData()),
                                             _mapper.Map<List<SelectListItem>>(await _productService.GetProductGroupsSimpleData())));

        // POST: Agreements/Create
        [HttpPost]
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

            var model = await _agreementService.GetAgreementAsync<AgreementEditModel>(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            model.Products = _mapper.Map<List<SelectListItem>>(await _productService.GetProductsSimpleData());
            model.ProductGroups = _mapper.Map<List<SelectListItem>>(await _productService.GetProductGroupsSimpleData());
            return View(model);
        }

        // POST: Agreements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AgreementEditModel model)
        {
            if (!await _agreementService.IsAgreementExist(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                await _agreementService.UpdateAgreementAsync(currentUserId, model);
                return RedirectToAction(nameof(Index));
            }

            model.Products = _mapper.Map<List<SelectListItem>>(await _productService.GetProductsSimpleData());
            model.ProductGroups = _mapper.Map<List<SelectListItem>>(await _productService.GetProductGroupsSimpleData());
            return View(model);
        }

        // GET: Agreements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _agreementService.GetAgreementAsync<AgreementDeleteModel>(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Agreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _agreementService.GetAgreementAsync<AgreementDeleteModel>(id);
            if (model == null)
            {
                return NotFound();
            }
            await _agreementService.RemoveAgreementAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
