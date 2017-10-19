using EFBF9.Abstract;
using EFBF9.Concrete;
using EFTReports.Abstract;
using EFTReports.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI.Infrastructure
{

    // реализация пользовательской фабрики контроллеров,
    // наследуясь от фабрики используемой по умолчанию
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера
            // используя его тип
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // конфигурирование контейнера
            ninjectKernel.Bind<IBF9UnloadBunker>().To<EFBF9.Concrete.EFBF9>();
            ninjectKernel.Bind<IBF9UnloadMaterial>().To<EFBF9.Concrete.EFBF9>();
            ninjectKernel.Bind<IAccess>().To<EFAccess>();
        }
    }

}