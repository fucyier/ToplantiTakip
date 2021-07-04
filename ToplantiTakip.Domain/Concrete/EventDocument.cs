using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplantiTakip.Domain.Concrete
{
    public class EventDocument
    {
        public int EventDocumentId { get; set; }
        public byte[] Document { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
