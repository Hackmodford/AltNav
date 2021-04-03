using MvvmCross.IoC;
using MvvmCross.ViewModels;
using AltNav.Core.ViewModels.Main;

namespace AltNav.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
