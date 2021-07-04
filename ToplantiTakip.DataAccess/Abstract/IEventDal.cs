using System.Collections.Generic;
using ToplantiTakip.Core;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Abstract
{
    public interface IEventDal : IEntityRepository<Event>
    {
        List<Event> GetAllwithRooms();
        List<Event> GetByRoomId(int? roomId);
    }
}
