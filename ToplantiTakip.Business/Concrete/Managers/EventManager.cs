using System.Collections.Generic;
using System.Linq;
using ToplantiTakip.Business.Abstract;
using ToplantiTakip.DataAccess.Abstract;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.Business.Concrete.Managers
{
    public class EventManager : IEventService
    {
        private readonly IEventDal _postDal;
        public EventManager(IEventDal postDal)
        {
            _postDal = postDal;
        }

        public List<Event> GetAll()
        {
            return _postDal.GetAll();
        }
        public List<Event> GetAllwithRooms()
        {
            return _postDal.GetAllwithRooms();
        }
        public List<Event> GetByRoomId(int? roomId)
        {
            return _postDal.GetByRoomId(roomId);
        }
        public Event Get(int id)
        {
            return _postDal.Get(id);
        }
        public Event GetNewObject()
        {
            return new Event();
        }
        public Event Add(Event entity)
        {
            if (EventConflict(entity))
            {
                return entity;
            }
            return _postDal.Add(entity);
        }

        public void Delete(Event entity)
        {
            _postDal.Delete(entity);
        }

        public Event Update(Event entity)
        {
            if (EventConflict(entity))
            {
                return entity;
            }
            return _postDal.Update(entity);
        }
        private bool EventConflict(Event e)
        {
            IEnumerable<Event> eventList = GetAll()
                .Where(x => x.RoomId == e.RoomId && x.EventId!=e.EventId&&
                ((e.StartDate >= x.StartDate && e.StartDate <= x.EndDate) || (e.EndDate >= x.StartDate && e.EndDate <= x.EndDate)));

            return eventList.Count()>0;
        }
    }
}
