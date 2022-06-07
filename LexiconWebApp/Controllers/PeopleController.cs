using WebApp.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;

namespace WebApp.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult PeopleList()
        { 
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            PeopleViewModel peopleViewModel = new PeopleViewModel() { PeopleListViewModel = createPersonViewModel.GetListPerson() };
            if (peopleViewModel.PeopleListViewModel.Count == 0)
                createPersonViewModel.MockPersonRepo();

            return View(peopleViewModel);
        }

        public IActionResult DeletePerson(int id)
        {

            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            Person person = createPersonViewModel.GetPersonById(id);
            createPersonViewModel.DeletePerson(person);

            return RedirectToAction("PeopleList");
        }

        [HttpPost]
        public IActionResult PeopleList(PeopleViewModel peopleViewModel)
        {
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            peopleViewModel.PeopleListViewModel.Clear();

            foreach (Person person in createPersonViewModel.GetListPerson())  // search by name or city
            {
                if (person.Name.Contains(peopleViewModel.Filter, StringComparison.OrdinalIgnoreCase)||
                    person.City.Contains(peopleViewModel.Filter, StringComparison.OrdinalIgnoreCase))
                {
                    peopleViewModel.PeopleListViewModel.Add(person);
                }
            }
            return View(peopleViewModel);
        }


        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel addPersonViewModel)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();

            if (ModelState.IsValid)
            {
                peopleViewModel.Name = addPersonViewModel.Name;
                peopleViewModel.PhoneNumber = addPersonViewModel.PhoneNumber;
                peopleViewModel.City = addPersonViewModel.City;
                peopleViewModel.PeopleListViewModel = addPersonViewModel.GetListPerson();
                createPersonViewModel.CreatePerson(addPersonViewModel.Name, addPersonViewModel.PhoneNumber, addPersonViewModel.City);
                ViewBag.Message = "Person Added Successfully ";

                return View("PeopleList", peopleViewModel);
            }

            ViewBag.Message = "Error While Adding A Person" + ModelState.Values;
            return View("PeopleList", peopleViewModel);
        }

    }
}
