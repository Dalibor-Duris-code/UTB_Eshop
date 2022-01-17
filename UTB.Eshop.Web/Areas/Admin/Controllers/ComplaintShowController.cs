using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entity;
using UTB.Eshop.Web.Models.Identity;

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class ComplaintShowController : Controller
    {
        readonly EshopDbContext eshopDbContext;
        readonly IWebHostEnvironment webHostEnv;
        public ComplaintShowController(EshopDbContext eshopDB, IWebHostEnvironment webHostEnvironment)
        {
            eshopDbContext = eshopDB;
            webHostEnv = webHostEnvironment;
        }

        public IActionResult Select()
        {
            IList<Complain> complains = eshopDbContext.Complaints.ToList();

            return View(complains);
        }

        public IActionResult Edit(int ID)
        {
            Complain prodFromDatabase = eshopDbContext.Complaints.FirstOrDefault(com => com.ID == ID);

            if (prodFromDatabase != null)
            {
                return View(prodFromDatabase);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Complain complain)
        {
            Complain prodFromDatabase = eshopDbContext.Complaints.FirstOrDefault(com => com.ID == complain.ID);

            if (prodFromDatabase != null)
            {
                prodFromDatabase.OrderNumber = complain.OrderNumber;
                prodFromDatabase.Reason = complain.Reason;
                prodFromDatabase.ProductID = complain.ProductID;

                await eshopDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Select));
            }
            else
            {
                return NotFound();
            }

        }
    }
}
