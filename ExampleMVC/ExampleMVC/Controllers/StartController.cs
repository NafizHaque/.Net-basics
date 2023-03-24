using Microsoft.AspNetCore.Mvc;
using ExampleMVC.Models;

namespace ExampleMVC.Controllers
{
    public class StartController : Controller
    {

        private static List<DogViewModel> dogs= new List<DogViewModel>();

        public IActionResult Index()
        {   
            return View(dogs);
        }

        public IActionResult Create()
        {
            var newDogViewModel = new DogViewModel();
            return View(newDogViewModel);
        }

        public IActionResult CreateDog(DogViewModel dogViewModel)
        {

            dogs.Add(dogViewModel);
            return RedirectToAction(nameof(Index));
        }

        public string Hello()
        {
            return "Hello";
        }
    }
}
