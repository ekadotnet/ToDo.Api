using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.Interfaces;
using ToDo.Core.Services;
using ToDo.Data;

namespace ToDo.Core.Modules
{
    public class ToDoTaskModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ToDoTaskService>().As<IToDoTaskService>().InstancePerDependency();
        }
    }
}
