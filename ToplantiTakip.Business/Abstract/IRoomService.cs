using ToplantiTakip.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplantiTakip.Business.Abstract
{
   public interface IRoomService
    {

        List<Room> GetAll();
        Room GetNewObject();
        Room Get(int id);

        Room Add(Room entity);

        void Delete(Room entity);

        Room Update(Room entity);
    }
}
