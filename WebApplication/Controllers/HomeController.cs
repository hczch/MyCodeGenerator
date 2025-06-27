using IOStreamProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCodeGenerator.Com;
using MyCodeGenerator.Config;
using MyCodeGenerator.Decorator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Info;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfigurationRoot _Config;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _Config = ConfigurationHelper.GetInstance();
        }


        public IActionResult Index()
        {
            ModelDetail modelDetail = new ModelDetail();
            return View(modelDetail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CreateModel(ModelDetail detail)
        {
            Component properties = new PropertyComponent(detail.PropertyList);
            Decorator model = new ModelDecorator(properties, detail.Name);
            Decorator nameSpace = new NameSpaceDecorator(model, detail.NameSpace);

            var codeTxt = nameSpace.GenerateCode();

            var filePath = _Config["ProjectPath:BasePath"] + _Config["ProjectPath:ModelPath"];
            FileStreamer.CreateFile(filePath, $"{detail.Name}.cs", codeTxt);

            return View("Index", detail);
        }

        [HttpGet]
        public IActionResult CreateBLL()
        {
            var bll = new BLLDetail();

            return View(bll);
        }

        [HttpPost]
        public IActionResult CreateBLL(BLLDetail detail)
        {
            Component methods = new MethodComponent(detail.MethodList);
            Decorator decorator;
            Decorator nameSpace;
            string codeTxt = string.Empty;
            string filePath = string.Empty;

            if (detail.FileOutput != FileOutputEnum.Interface)
            {
                (methods as MethodComponent).SetClassMethodMode();
                decorator = new BLLDecorator(methods, detail.Name);
                nameSpace = new NameSpaceDecorator(decorator, detail.NameSpace);

                codeTxt = nameSpace.GenerateCode();

                filePath = _Config["ProjectPath:BasePath"] + _Config["ProjectPath:BLLPath"];
                FileStreamer.CreateFile(filePath, $"{detail.Name}BLL.cs", codeTxt);
            }

            if (detail.FileOutput != FileOutputEnum.BLL)
            {
                (methods as MethodComponent).SetInterfaceMethodMode();
                Decorator inter = new InterfaceDecorator(methods, detail.Name);
                nameSpace = new NameSpaceDecorator(inter, detail.NameSpace);

                codeTxt = nameSpace.GenerateCode();
                filePath = _Config["ProjectPath:BasePath"] + _Config["ProjectPath:InterfacePath"];
                FileStreamer.CreateFile(filePath, $"I{detail.Name}.cs", codeTxt);

            }
            return View(detail);
        }

        [HttpGet]
        public IActionResult CreateController()
        {
            var controller = new ControllerDetail();

            return View(controller);
        }

        [HttpPost]
        public IActionResult CreateController(ControllerDetail detail)
        {
            Component methods = new MethodComponent(detail.MethodList);
            Decorator controller = new ControllerDecorator(methods, detail.Name, detail.Attributes);
            Decorator nameSpace = new NameSpaceDecorator(controller, detail.NameSpace);

            var codeTxt = nameSpace.GenerateCode();

            var filePath = _Config["ProjectPath:BasePath"] + _Config["ProjectPath:ControllerPath"];
            FileStreamer.CreateFile(filePath, $"{detail.Name}Controller.cs", codeTxt);

            return View(detail);
        }
    }
}
