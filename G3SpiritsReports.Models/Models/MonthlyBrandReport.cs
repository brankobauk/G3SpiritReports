using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3SpiritsReports.Models.Models
{
    public class MonthlyBrandReport
    {
        [Key]
        public int MonthlyBrandReportId { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int SoldPieces { get; set; }

        public virtual Country Country { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
