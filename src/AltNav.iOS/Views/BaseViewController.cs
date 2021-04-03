using System;
using System.Threading.Tasks;
using AltNav.Core.Services;
using AltNav.Core.ViewModels;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using AltNav.iOS.Styles;
using MvvmCross.Base;
using MvvmCross.Exceptions;
using UIKit;
using MvxNavigationViewModel = AltNav.Core.ViewModels.MvxNavigationViewModel;

namespace AltNav.iOS.Views
{
    public abstract class BaseViewController<TViewModel> : MvxViewController<TViewModel>, IMvxNavigationView
        where TViewModel : MvxNavigationViewModel
    {
        
        private IMvxInteraction<MvxNavigateInteractionParameter> _navigateToInteraction;
        public IMvxInteraction<MvxNavigateInteractionParameter> NavigateToInteraction
        {
            get => _navigateToInteraction;
            set
            {
                if (_navigateToInteraction != null)
                    _navigateToInteraction.Requested -= OnNavigateToInteractionRequested;
            
                _navigateToInteraction = value;
                _navigateToInteraction.Requested += OnNavigateToInteractionRequested;
            }
        }
        
        private IMvxInteraction<MvxCloseInteractionParameter> _closeInteraction;
        public IMvxInteraction<MvxCloseInteractionParameter> CloseInteraction
        {
            get => _closeInteraction;
            set
            {
                if (_closeInteraction != null)
                    _closeInteraction.Requested -= OnCloseInteractionRequested;
            
                _closeInteraction = value;
                _closeInteraction.Requested += OnCloseInteractionRequested;
            }
        }
        
        private async void OnNavigateToInteractionRequested(object sender, MvxValueEventArgs<MvxNavigateInteractionParameter> eventArgs)
        {
            var viewController = (UIViewController) eventArgs.Value.View;

            var didNavigate = await NavigateTo(viewController);

            eventArgs.Value.DidNavigate(didNavigate);
        }
        
        private async void OnCloseInteractionRequested(object sender, MvxValueEventArgs<MvxCloseInteractionParameter> eventArgs)
        {
            var didClose = await Close();

            eventArgs.Value.DidClose(didClose);
        }

        protected virtual Task<bool> NavigateTo(UIViewController viewController)
        {
            throw new MvxException("Parent ViewController's navigation not implemented.");
        }
        
        protected virtual Task<bool> Close()
        {
            throw new MvxException("Parent ViewController's close navigation not implemented.");
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View!.BackgroundColor = UIColor.White;

            if (NavigationController != null)
            {
                NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
                NavigationController.NavigationBar.Translucent = false;
                NavigationController.NavigationBar.Hidden = false;
                NavigationController.NavigationBar.BarTintColor = ColorPalette.Primary;
                NavigationController.NavigationBar.TintColor = UIColor.White;
                NavigationController.SetNeedsStatusBarAppearanceUpdate();
            }
            
            CreateView();

            LayoutView();

            BindView();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        protected virtual void CreateView()
        {
        }

        protected virtual void LayoutView()
        {
        }

        protected virtual void BindView()
        {
            var set = CreateBindingSet();
            set.Bind(this).For(view => view.NavigateToInteraction)
                .To(viewModel => viewModel.NavigateToInteraction)
                .OneWay();
            set.Bind(this).For(view => view.CloseInteraction)
                .To(viewModel => viewModel.CloseInteraction)
                .OneWay();
            set.Apply();
        }
    }
}
