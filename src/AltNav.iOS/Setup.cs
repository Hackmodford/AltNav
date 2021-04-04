using MvvmCross.Platforms.Ios.Core;
using AltNav.Core;
using AltNav.Core.Services;
using AltNav.iOS.Services;
using AltNav.iOS.Views;
using MvvmCross;
using MvvmCross.IoC;

namespace AltNav.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMvxViewFactory, MvxIosViewFactory>();
        }
    }
}
