using Microsoft.AspNetCore.Mvc;
using Shop.WebApp.Interfaces;
using Shop.WebApp.Models.Suppliers;
using Shop.WebApp.Services;
using Newtonsoft.Json;

namespace Shop.WebApp.Controllers
{
    public class SuppliersController : Controller

    {
        HttpClientHandler httpHandler = new HttpClientHandler();
        private readonly ISuppliersServices suppliersServices;

        public SuppliersController(ISuppliersServices suppliersServices)
        {
            this.suppliersServices = suppliersServices;
            this.httpHandler = new HttpClientHandler();
            this.httpHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

         // GET: SuppliersController
        public async Task<ActionResult> Index()
        {
            var suppliersGetList = await suppliersServices.GetSuppliers();
            if (!suppliersGetList.success)
            {
                ViewBag.Message = suppliersGetList.message;
                return View();
            }
            return View(suppliersGetList.result);
        }

        // GET: SuppliersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var suppliersGetById = await suppliersServices.GetSuppliersById(id);
            if (!suppliersGetById.success)
            {
                ViewBag.Message = suppliersGetById.message;
                return View();
            }

            return View(suppliersGetById.result);
        }

        // GET: SuppliersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SuppliersSaveModel suppliersSaveModel)
        {
            try
            {
               var suppliersGetResult = await suppliersServices.SuppliersSave(suppliersSaveModel);
                if (!suppliersGetResult.success)
                {
                    ViewBag.Messafe = suppliersGetResult.message;
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuppliersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var suppliersGetById = await suppliersServices.GetSuppliersById(id);
            if (!suppliersGetById.success)
            {
                ViewBag.Message = suppliersGetById.message;
                return View();
            }
            return View(suppliersGetById.result);
        }

        // POST: SuppliersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SuppliersUpdateModel suppliersUpdate)
        {
            {
                var result = await suppliersServices.SuppliersUpdate(suppliersUpdate);
                if (!result.success)
                {
                    ViewBag.Message = result.message;
                    return View(suppliersUpdate);
                }
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
