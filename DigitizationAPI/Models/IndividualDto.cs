using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizationAPI.Models
{
    public class IndividualDto
    {
        public int ID { get; set; }
        public int? RecordNumber { get; set; }
        public int? RecordQuality { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string GName { get; set; }
        public int DoBYear { get; set; }
        public int? DoBMonth { get; set; }
        public int? DoBDay { get; set; }
        public int? Age { get; set; }
        public int? AgeYear { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }
        public int? BookID { get; set; }
        public int? PageID { get; set; }
        public string? CroppedPath { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public Boolean? IsRejected { get; set; }
        public int? ApprovedCount { get; set; }
        public int? RejectedCount { get; set; }
        public int? NotSureCount { get; set; }
        public int? QualityControlCount { get; set; }
        public Boolean? IsComplete { get; set; }
        public Int16? FacesCount { get; set; }
    }
}
