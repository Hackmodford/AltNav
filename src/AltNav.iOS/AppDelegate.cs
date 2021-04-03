using Foundation;
using MvvmCross.Platforms.Ios.Core;
using AltNav.Core;

namespace AltNav.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
