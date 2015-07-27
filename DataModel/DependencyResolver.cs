
using System.ComponentModel.Composition;
using Resolver;
using DataModel.UnitOfWork;
namespace DataModel
{
    public class DependencyResolver:IComponent
    {
        [Export(typeof(IComponent))]
        public void SetUp(IRegisterComponent registerComponenet)
        {
            registerComponenet.RegisterType<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
