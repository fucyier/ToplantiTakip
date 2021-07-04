using ToplantiTakip.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplantiTakip.Business.Abstract
{
   public interface IEventDocumentService
    {

        List<EventDocument> GetAll();
        EventDocument GetNewObject();
        EventDocument Get(int id);

        EventDocument Add(EventDocument entity);

        void Delete(EventDocument entity);

        EventDocument Update(EventDocument entity);
    }
}
