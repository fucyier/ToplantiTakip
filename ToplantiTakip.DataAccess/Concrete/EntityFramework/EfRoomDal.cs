using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToplantiTakip.DataAccess.Abstract;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Concrete.EntityFramework
{
    public class EfRoomDal : IRoomDal
    {
        public List<Room> GetAll()
        {
            using (var context = new ToplantiTakipContext())
            {
                return context.Rooms.Include(c => c.Department).Where(c => c.RoomStatus == true).ToList();
            }
        }

        public Room Get(int id)
        {
            using (var context = new ToplantiTakipContext())
            {
                return context.Rooms.Include(c => c.Department).SingleOrDefault(c => c.RoomStatus == true && c.RoomId == id);
            }
        }

        public Room Add(Room entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                context.Rooms.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Room entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                var room = context.Rooms.Find(entity.RoomId);
                if (room != null)
                {
                    context.Rooms.Remove(room);
                    context.SaveChanges();
                }
            }
        }

        public Room Update(Room entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                var room = context.Rooms.FirstOrDefault(d => d.RoomId == entity.RoomId);
                room.RoomInfo = entity.RoomInfo;
                room.RoomName = entity.RoomName;
                room.RoomStatus = entity.RoomStatus;
                room.RoomAddress = entity.RoomAddress;
                room.RoomInfo = entity.RoomInfo;
                room.RoomCapacity = entity.RoomCapacity;
                room.DepartmentId = entity.DepartmentId;

                if (entity.RoomImage != null && room.RoomImage != entity.RoomImage)
                {
                    room.RoomImage = entity.RoomImage;
                    room.ImageType = entity.ImageType;
                }

                //context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return room;
            }
        }
    }
}
