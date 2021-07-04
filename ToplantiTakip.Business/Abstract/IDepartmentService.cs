using ToplantiTakip.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplantiTakip.Business.Abstract
{
   public interface IDepartmentService
    {      
           List<Department> GetAll();

        Department Get(int id);

        Department Add(Department entity);

           void Delete(Department entity);

        Department Update(Department entity);
          
    }
}
