using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterProject.Models;

namespace WaterProject.Pages
{
    public class DonateModel : PageModel
    {
        private IWaterProjectRepository repo { get; set; }

        public DonateModel (IWaterProjectRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost(int projectID)
        {
            Project p = repo.Projects.FirstOrDefault(x => x.ProjectID == projectID);

            basket = new Basket();

            basket.AddItem(p, 1);

            return RedirectToPage();

        }

    }
}
