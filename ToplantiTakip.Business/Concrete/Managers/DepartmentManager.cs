using System.Collections.Generic;
using ToplantiTakip.Business.Abstract;
using ToplantiTakip.DataAccess.Abstract;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.Business.Concrete.Managers
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public List<Department> GetAll()
        {
            return _departmentDal.GetAll();
        }

        public Department Get(int id)
        {
            return _departmentDal.Get(id);
        }

        public Department Add(Department entity)
        {
            return _departmentDal.Add(entity);
        }

        public void Delete(Department entity)
        {
            _departmentDal.Delete(entity);
        }

        public Department Update(Department entity)
        {
            return _departmentDal.Update(entity);
        }
    }
}
