using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Tools.Generator;

namespace DesignPatternASP.Controllers
{
    public class GeneratorFileController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratorConcreteBuilder _generatorConcreteBuilder;

        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
        {
            _unitOfWork = unitOfWork;
            _generatorConcreteBuilder = generatorConcreteBuilder;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateFile(int optionFile)
        {
            try
            {
                var beers = _unitOfWork.Beers.GetAll();
                List<string> content = beers.Select(d => d.Name).ToList();
                string path = "file"+DateTime.Now.Ticks+new Random().Next(0, 1000)+".txt";

                var generatorDirector = new GeneratorDirector(_generatorConcreteBuilder);

                if (optionFile == 1)               
                    generatorDirector.CreateSimpleJsonGenerator(content, path);
                else 
                    generatorDirector.CreateSimplePipeGenerator(content, path);

                var generator = _generatorConcreteBuilder.GetGenerator();
                generator.Save();

                return Json("Archivo generado correctamente");
            } catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
