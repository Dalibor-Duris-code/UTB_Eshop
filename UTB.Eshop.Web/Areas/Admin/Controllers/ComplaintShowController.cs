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
        

    }
}
