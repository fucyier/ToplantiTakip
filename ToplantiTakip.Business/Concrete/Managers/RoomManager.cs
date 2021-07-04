using System.Collections.Generic;
using ToplantiTakip.Business.Abstract;
using ToplantiTakip.DataAccess.Abstract;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.Business.Concrete.Managers
{
    public class RoomManager : IRoomService
    {
        private IRoomDal _roomDal;
        public RoomManager(IRoomDal RoomDal)
        {
            _roomDal = RoomDal;
        }

        public List<Room> GetAll()
        {
            return _roomDal.GetAll();
        }

        public Room GetNewObject()
        {
            return new Room();
        }

        public Room Get(int id)
        {
            return _roomDal.Get(id);
        }

        public Room Add(Room entity)
        {
            return _roomDal.Add(entity);
        }

        public void Delete(Room entity)
        {
            _roomDal.Delete(entity);
        }

        public Room Update(Room entity)
        {
            return _roomDal.Update(entity);
        }

    }
}

