using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToplantiTakip.DataAccess.Abstract;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Concrete.EntityFramework
{
    public class EfEventDal : IEventDal
    {
        public List<Event> GetByRoomId(int? roomId)
        {
            using (var _context = new ToplantiTakipContext())
            {
                var Event = (from p in _context.Events
                             where p.RoomId == roomId
                             orderby p.EventId descending
                             select p).ToList();

                return Event;
            }
        }
        public List<Event> GetAll()
        {
            using (var _context = new ToplantiTakipContext())
            {

                List<Event> Event = (from p in _context.Events.Include(p => p.Room).Include(p => p.Room.Department)
                                         //   where p.EventStatus == true
                                     orderby p.EventId descending
                                     select p).ToList();

                return Event;
            }

        }
        public List<Event> GetAllwithRooms()
        {
            using (var _context = new ToplantiTakipContext())
            {

                List<Event> Event = (from p in _context.Events
                                         //   where p.EventStatus == true
                                     orderby p.EventId descending
                                     select p).ToList();

                return Event;
            }

        }
        //public List<Event> GetMostCommentedEvents()
        //{
        //    using (var _context = new ToplantiTakipContext())
        //    {
        //        var Events = (from p in _context.Events.Include(c => c.Comments)
        //                     where p.EventStatus == true
        //                     orderby p.Comments.Count() descending
        //                     select p).Take(5).ToList();
        //        return Events;
        //    }

        //}
        //public List<Event> GetMostViewedEvents()
        //{
        //    using (var _context = new ToplantiTakipContext())
        //    {

        //        List<Event> Event = (from p in _context.Events.Include(p => p.Tags).Include(p => p.Author)
        //                           where p.EventStatus == true
        //                           orderby p.ViewCount descending
        //                           select p).ToList();

        //        return Event;
        //    }
        //}
        public Event Get(int EventId)
        {
            using (var _context = new ToplantiTakipContext())
            {
                Event Event = (from p in _context.Events.Include(p => p.Room).Include(p => p.EventDocument).Include(p => p.User)
                               where p.EventId == EventId
                               select p).Single();
                return Event;
            }

        }

        public Event Add(Event entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                context.Events.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Event entity)
        {
            using (var _context = new ToplantiTakipContext())
            {
                var Event = _context.Events.Include(p => p.Room).First(x => x.EventId == entity.EventId);
                if (Event != null)
                {
                    _context.Events.Remove(Event);
                    _context.SaveChanges();
                }
            }
        }

        public Event Update(Event entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                var _event = context.Events.Include(x => x.EventDocument).FirstOrDefault(d => d.EventId == entity.EventId);

                _event.EventInfo = entity.EventInfo;
                _event.EventSubject = entity.EventSubject;
                _event.StartDate = entity.StartDate;
                _event.EndDate = entity.EndDate;
                _event.RoomId = entity.RoomId;
                _event.ReservationDate = entity.ReservationDate;
                _event.ApproveDate = entity.ApproveDate;
                _event.ApproveUserId = entity.ApproveUserId;
                _event.UserId = entity.UserId;
                _event.Status = entity.Status;
                _event.ThemeColor = entity.ThemeColor;

                if (entity.EventDocument != null && entity.EventDocument.Count > 0)
                {
                    _event.EventDocument.AddRange(entity.EventDocument);
                }
                // context.Entry(entity.EventDocument).State = EntityState.Added;
                //context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return _event;
            }
        }


    }
}
