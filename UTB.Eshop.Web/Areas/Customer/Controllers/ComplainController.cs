using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entity;
using UTB.Eshop.Web.Models.Identity;
using System;

namespace UTB.Eshop.Web.Areas.Customer.Controllers
{

    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class ComplainController : Controller
    {

        readonly EshopDbContext eshopDbContext;


        public ComplainController(EshopDbContext eshopDB)
        {
            eshopDbContext = eshopDB;
        }


        [HttpGet]
        public IActionResult ComplainIt(int productID,string OrderNumber)
        {
            ViewData["ProductID"] = productID;
            ViewData["OrderNumber"] = OrderNumber;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ComplainIt(Complain complaint)
        {
            eshopDbContext.Complaints.Add(complaint);
            await eshopDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(CustomerOrdersController.Index),
                nameof(CustomerOrdersController).Replace("Controller", String.Empty),
                new { area = "Customer" });
        }


        public IActionResult Complain()
        {
            return View();
        }
    }
}

