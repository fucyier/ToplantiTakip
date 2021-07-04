using System.Collections.Generic;
using System.Linq;
using ToplantiTakip.DataAccess.Abstract;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal : IDepartmentDal
    {
        public List<Department> GetAll()
        {
            using (var context = new ToplantiTakipContext())
            {
                var tag = context.Departments.ToList();
                return tag;
            }
        }

        public Department Get(int id)
        {
            using (var context = new ToplantiTakipContext())
            {
                var tag = context.Departments.Where(t => t.DepartmentId == id).SingleOrDefault();
                return tag;
            }
        }

        public Department Add(Department entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                context.Departments.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Department entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                var tag = context.Departments.Find(entity.DepartmentId);
                if (tag != null)
                {
                    context.Departments.Remove(tag);
                    context.SaveChanges();
                }
            }
        }

        public Department Update(Department entity)
        {
            using (var context = new ToplantiTakipContext())
            {
                var tag = context.Departments.FirstOrDefault(d => d.DepartmentId == entity.DepartmentId);
                tag.DepartmentAddress = entity.DepartmentAddress;
                tag.DepartmentInfo = entity.DepartmentInfo;
                tag.DepartmentStatus = entity.DepartmentStatus;


                //context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return tag;
            }
        }
    }
}
