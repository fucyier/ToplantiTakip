using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToplantiTakip.Domain.Concrete
{
    public class Room
    {
        public Room()
        {
            new List<Event>();
        }
        public int RoomId { get; set; }

        [Display(Name = "Toplantı Salonu Adı")]
        [Required(ErrorMessage = "Salon Adı Boş Geçilemez...")]
        public string RoomName { get; set; }

        [Display(Name = "Salon Adresi")]
        [Required(ErrorMessage = "Salon Adresi Boş Geçilemez...")]
        public string RoomAddress { get; set; }


        [Display(Name = "Salon Kapasitesi")]
        [Required(ErrorMessage = "Salon Kapasitesi Boş Geçilemez...")]
        public int RoomCapacity { get; set; }

        [Display(Name = "Salon Bilgisi")]
        [Required(ErrorMessage = "Salon Bilgisi Boş Geçilemez...")]
        public string RoomInfo { get; set; }

        [Display(Name = "Salon Durumu")]
        public bool RoomStatus { get; set; }
        public byte[] RoomImage { get; set; }
        public string ImageType { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public List<Event> Events { get; set; }
    }
}
