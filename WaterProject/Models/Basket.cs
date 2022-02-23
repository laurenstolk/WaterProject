using System;
using System.Collections.Generic;
using System.Linq;

namespace WaterProject.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Project Proj, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Project.ProjectID == Proj.ProjectID)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Project = Proj,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }

        }


        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);

            return sum;
        }

    }

    


    public class BasketLineItem
    {
        public int LineID { get; set; }

        public Project Project { get; set; }

        public int Quantity { get; set; }

    }

}
