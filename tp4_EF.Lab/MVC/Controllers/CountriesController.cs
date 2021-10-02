using Logic.EF;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CountriesController : Controller
    {
        private CountriesLogic logic;
        public CountriesController()
        {
            logic = new CountriesLogic(new ApiClient());
        }
        public ActionResult Index()
        {
            try
            {
                var countries = logic.GetCountries();
                var countriesViews = from c in countries
                                     select new CountriesView
                                     {
                                         Name = c.Name,
                                         Capital = c.Capital,
                                         Region = c.Region,
                                     };
                return View(countriesViews.ToList());
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "Error", new { mssg = ex.Message });
            }
        }
    }
}