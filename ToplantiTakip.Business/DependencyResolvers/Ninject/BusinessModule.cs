using Ninject.Modules;
using ToplantiTakip.Business.Abstract;
using ToplantiTakip.Business.Concrete.Managers;
using ToplantiTakip.DataAccess.Abstract;
using ToplantiTakip.DataAccess.Concrete.EntityFramework;

namespace ToplantiTakip.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventService>().To<EventManager>();
            Bind<IEventDal>().To<EfEventDal>();
            Bind<IDepartmentService>().To<DepartmentManager>();
            Bind<IDepartmentDal>().To<EfDepartmentDal>();
            Bind<IRoomService>().To<RoomManager>();
            Bind<IRoomDal>().To<EfRoomDal>();
            Bind<IEventDocumentService>().To<EventDocumentManager>();
            Bind<IEventDocumentDal>().To<EfEventDocumentDal>();
        }
    }
}
