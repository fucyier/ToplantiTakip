using System.Collections.Generic;
using ToplantiTakip.Business.Abstract;
using ToplantiTakip.DataAccess.Abstract;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.Business.Concrete.Managers
{
    public class EventDocumentManager : IEventDocumentService
    {
        private IEventDocumentDal _eventDocumentDal;
        public EventDocumentManager(IEventDocumentDal eventDocumentDal)
        {
            _eventDocumentDal = eventDocumentDal;
        }

        public List<EventDocument> GetAll()
        {
            return _eventDocumentDal.GetAll();
        }

        public EventDocument GetNewObject()
        {
            return new EventDocument();
        }

        public EventDocument Get(int id)
        {
            return _eventDocumentDal.Get(id);
        }

        public EventDocument Add(EventDocument entity)
        {
            return _eventDocumentDal.Add(entity);
        }

        public void Delete(EventDocument entity)
        {
            _eventDocumentDal.Delete(entity);
        }

        public EventDocument Update(EventDocument entity)
        {
            return _eventDocumentDal.Update(entity);
        }

    }
}

