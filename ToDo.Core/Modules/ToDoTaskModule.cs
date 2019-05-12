using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.Interfaces;
using ToDo.Core.Services;

namespace ToDo.Core.Modules
{
    public class ToDoTaskModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IToDoTaskService>().As<ToDoTaskService>().InstancePerDependency();
        }
    }
}
