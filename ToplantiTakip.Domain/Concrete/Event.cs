using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToplantiTakip.Core.Utilities;
using static ToplantiTakip.Core.Utilities.Enums;

namespace ToplantiTakip.Domain.Concrete
{
   
    public class Event
    {
        public Event()
        {
            new List<EventDocument>();
        }
        public int EventId { get; set; }

        [Display(Name = "Toplantı Konusu")]
        [Required(ErrorMessage = "Toplantı Konusu Boş Geçilemez...")]
        public string EventSubject { get; set; }

        [Display(Name = "Toplantı Açıklama")]
      
        public string EventInfo { get; set; }

        [Display(Name = "Başlangıç Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy HH:mm}")]

        public DateTime StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy HH:mm}")]

        public DateTime EndDate { get; set; }

        [Display(Name = "Tema Rengi")]
        public string ThemeColor { get; set; }

        [Display(Name = "Toplantı Durumu")]
     
        public string StatusString
        {
            get { return Status.ToString(); }
            private set { Status = value.ParseEnum<EventStatus>(); }
        }
        [NotMapped]
        public EventStatus Status { get; set; }
        [Display(Name = "Tüm Gün")]
        public bool IsFullDay { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Display(Name = "Talep Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime ReservationDate { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        //[NotMapped]
        //public string RoomName { set { } get { return Room.RoomName; } }
        public string ApproveUserId { get; set; }
        public virtual ApplicationUser ApproveUser { get; set; }
        [Display(Name = "Onay Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime? ApproveDate { get; set; }
        [Display(Name ="Toplantı Dokümanı")]
        public List<EventDocument> EventDocument { get; set; }
        
    }
}
