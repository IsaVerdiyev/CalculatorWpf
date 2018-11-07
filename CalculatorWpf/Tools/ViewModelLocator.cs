using Autofac;
using Autofac.Configuration;
using CalculatorWpf.Navigation;
using CalculatorWpf.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpf.Tools
{
    class ViewModelLocator
    {
        INavigator navigator = new Navigator();

        public AppViewModel AppViewModel { get; }

        public StandardCalcViewModel StandardCalcViewModel { get; }

        public ViewModelLocator()
        {
            try
            {
                var config = new ConfigurationBuilder();
                config.AddJsonFile("autofac.json");
                var module = new ConfigurationModule(config.Build());
                var builder = new ContainerBuilder();
                builder.RegisterModule(module);
                builder.RegisterInstance(navigator).As<INavigator>().SingleInstance();
                var container = builder.Build();

                using(var scope = container.BeginLifetimeScope())
                {
                    AppViewModel = scope.Resolve<AppViewModel>();
                    StandardCalcViewModel = scope.Resolve<StandardCalcViewModel>();
                }

                navigator.AddPage(StandardCalcViewModel, VM.Standard);
                navigator.NavigateTo(VM.Standard);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
