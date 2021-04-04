using MvvmCross.Platforms.Android.Core;
using AltNav.Core;
using AltNav.Core.Services;
using Android.Content;
using MvvmCross;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Views;
using MvxAndroidViewFactory = AltNav.Droid.Services.MvxAndroidViewFactory;

namespace AltNav.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override IMvxAndroidViewsContainer CreateViewsContainer(Context applicationContext)
        {
            var container = base.CreateViewsContainer(applicationContext);
            var viewsContainer = container as MvxViewsContainer;
            var factory = new MvxAndroidViewFactory(viewsContainer);
            Mvx.IoCProvider.RegisterSingleton<IMvxViewFactory>(factory);
            return container;
        }
    }
}
