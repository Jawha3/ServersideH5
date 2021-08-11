using JwhH5.Areas.Identity.Codes;
using JwhH5.Codes;
using JwhH5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JwhH5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Class1 _class1;
        private readonly HashingExample _hashingExample;
        private readonly IServiceProvider _serviceProvider;
        private readonly UserRoleHandler _userRoleHandler;

        public HomeController(ILogger<HomeController> logger, 
            Class1 class1, 
            HashingExample hashingExample, 
            IServiceProvider serviceProvider, 
            UserRoleHandler userRoleHandler)
        {
            _logger = logger;
            _class1 = class1;
            _serviceProvider = serviceProvider;
            _userRoleHandler = userRoleHandler;
        }

        [Authorize("RequireAuthenticatedUser")]
        public async Task <IActionResult> Index()
        {
           await _userRoleHandler.CreateRole("jannie.11@hotmail.com", "Admin", _serviceProvider);

            //string txt = "Hello World";
            //string txt1 = "Testing";

            //string myText1 = _class1.GetText();
            //string myText2 = _class1.GetMoreText();

            //string myHashedText = _hashingExample.GetHashedText_MD5(txt);
            //string bcryptText = _hashingExample.GetEncryptedText_BCrypt(txt1);

            IndexModel myModel = new IndexModel() { };
            //IndexModel myModel = new IndexModel() { Text1 = myText1, Text2 = myHashedText, Text3 = bcryptText};
            return View(model: myModel);
        }

        [Authorize(Policy = "RequireAdminUser")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
