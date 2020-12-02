using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New([FromServices] IWebHostEnvironment env)
        {
            var fileName = Path.Combine("upload");
            var stream = new FileStream(Path.Combine(env.WebRootPath, fileName), FileMode.CreateNew);
            return RedirectToAction(nameof(Index));
        }
    }
}
