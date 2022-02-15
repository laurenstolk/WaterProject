using System;
using System.ComponentModel.DataAnnotations;

namespace WaterProject.Models
{
    public partial class Project
    {
        [Key]
        [Required]
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public string ProjectType { get; set; }

        // saying string? would make it a nullable field
        public string ProjectRegionalProgram { get; set; }

        public int ProjectImpact { get; set; }

        public string ProjectPhase { get; set; }

        public string ProjectFunctionalityStatus { get; set; }

    }
}
