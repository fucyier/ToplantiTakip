using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToplantiTakip.DataAccess.Abstract;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Concrete.EntityFramework
{
    public class EfEventDocumentDal : IEventDocumentDal
    {
        public List<EventDocument> GetAll()
        {
            using (var context = new ToplantiTakipContext())
            {
                return context.EventDocuments.Include(c => c.Event).ToList();
            }
        }

        public EventDocument Get(int id)
        {
            using (var context = new ToplantiTakipContext())
            {
                return context.EventDocuments.Include(c => c.Event).SingleOrDefault(c =>c.EventDocumentId == id);
            }
        }

        public EventDocument Add(EventDocument entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                context.EventDocuments.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(EventDocument entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                var room = context.EventDocuments.Find(entity.EventDocumentId);
                if (room != null)
                {
                    context.EventDocuments.Remove(room);
                    context.SaveChanges();
                }
            }
        }

        public EventDocument Update(EventDocument entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                var room = context.EventDocuments.FirstOrDefault(d => d.EventDocumentId == entity.EventDocumentId);
                room.Document = entity.Document;
                room.DocumentName = entity.DocumentName;
                room.DocumentType = entity.DocumentType;
              
                room.EventId = entity.EventId;


                //context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return room;
            }
        }
    }
}
