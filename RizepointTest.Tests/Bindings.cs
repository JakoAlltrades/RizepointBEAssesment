using Ninject.Modules;
using Ninject;
using RizepointBEAssesment.Models;

namespace RizepointBEAssesment
{
    public class Bindings: NinjectModule
    {
        public override void Load()
        {
            Bind<ISerializer>().To<Serializer>();
        }
    }
}