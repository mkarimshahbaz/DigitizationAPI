using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizationAPI.Entities
{
    [Table("Individuals", Schema = "NSIA")]
    public class Individual
    {
        [Key]
        public int ID { get; set; }
        public int? RecordNumber { get; set; }
        public int? RecordQuality { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string FName { get; set; }
        [Required]
        [MaxLength(100)]
        public string GName { get; set; }
        [Required]
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
        
        public Nullable<DateTime> FaceDetectionProcessedOn { get; set; }
        public Int16? FacesCount { get; set; }
    }
}
