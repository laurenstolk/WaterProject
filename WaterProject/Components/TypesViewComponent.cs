using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WaterProject.Models;

namespace WaterProject.Components
{
    public class TypesViewComponent : ViewComponent
    {

        private IWaterProjectRepository repo { get; set; }

        public TypesViewComponent (IWaterProjectRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            // the ? makes it nullable
            ViewBag.SelectedType = RouteData?.Values["projectType"];

            var types = repo.Projects
                .Select(x => x.ProjectType)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }


    }
}
