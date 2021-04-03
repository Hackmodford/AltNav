using System.Threading.Tasks;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using AltNav.Core.ViewModels.Main;
using UIKit;

namespace AltNav.iOS.Views.Main
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class MainViewController : BaseViewController<MainViewModel>
    {
        private UILabel _labelWelcome, _labelMessage;

        protected override void CreateView()
        {
            _labelWelcome = new UILabel
            {
                Text = "Welcome!!",
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelWelcome);

            _labelMessage = new UILabel
            {
                Text = "App scaffolded with MvxScaffolding",
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelMessage);
        }

        protected override void LayoutView()
        {
            View.AddConstraints(new FluentLayout[]
           {
                _labelWelcome.WithSameCenterX(View),
                _labelWelcome.WithSameCenterY(View),

                _labelMessage.Below(_labelWelcome, 10f),
                _labelMessage.WithSameWidth(View)
           });
        }

        protected override Task<bool> NavigateTo(UIViewController viewController)
        {
            NavigationController.PushViewController(viewController, true);
            // PresentModalViewController(viewController, true);
            return Task.FromResult(true);
        }
    }
}
