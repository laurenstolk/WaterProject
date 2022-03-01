using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WaterProject.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem(Project Proj, int qty)
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


        public virtual void RemoveItem(Project proj)
        {
            Items.RemoveAll(x => x.Project.ProjectID == proj.ProjectID);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }


        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);

            return sum;
        }

    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }

        public Project Project { get; set; }

        public int Quantity { get; set; }

    }

}
