using System.Collections.Generic;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.Business.Abstract
{
    public interface IEventService
    {
        List<Event> GetAll();
        List<Event> GetAllwithRooms();
        List<Event> GetByRoomId(int? roomId);
        Event Get(int id);
        Event GetNewObject();
        Event Add(Event entity);
        void Delete(Event entity);
        Event Update(Event entity);
    }
}
