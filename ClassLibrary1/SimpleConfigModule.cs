using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Model;
using Ninject.Modules;

namespace BusinessLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            // Регистрируем зависимость IRepository<Anime> -> EntityRepository<Anime> как Singleton
            Bind<IRepository<Anime>>().To<EntityRepository<Anime>>().InSingletonScope();
        }
    }

    // Дополнительный модуль для Dapper (если нужно сохранить выбор)
    public class DapperConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Anime>>().To<DapperRepository<Anime>>().InSingletonScope();
        }
    }
}
