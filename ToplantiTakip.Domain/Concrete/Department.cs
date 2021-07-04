using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToplantiTakip.Domain.Concrete
{
    public class Department
    {
        public Department()
        {
            new List<Room>();
        }
        public int DepartmentId { get; set; }

        [Display(Name = "Birim Adı")]
        [Required(ErrorMessage = "Birim Adı Boş Geçilemez...")]
        public string DepartmentName { get; set; }

        [Display(Name = "Birim Adresi")]
        [Required(ErrorMessage = "Birim Adresi Boş Geçilemez...")]
        public string DepartmentAddress { get; set; }

        [Display(Name = "Birim Bilgisi")]
        [Required(ErrorMessage = "Birim Bilgisi Boş Geçilemez...")]
        public string DepartmentInfo { get; set; }

        [Display(Name = "Birim Durumu")]
        public bool DepartmentStatus { get; set; }

        public List<Room> Rooms { get; set; }

    }
}
