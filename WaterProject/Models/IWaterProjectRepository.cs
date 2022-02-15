using System;
using System.Linq;

namespace WaterProject.Models
{
    public interface IWaterProjectRepository
    {
        IQueryable<Project> Projects { get; }

    }
}
