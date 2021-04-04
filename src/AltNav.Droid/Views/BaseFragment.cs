using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltNav.Core.Services;
using AltNav.Core.ViewModels;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Base;
using MvvmCross.Exceptions;
using MvvmCross.ViewModels;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Views.Fragments;

namespace AltNav.Droid.Views
{
    public abstract class BaseFragment<TViewModel> : MvxFragment<TViewModel>, IMvxNavigationView
        where TViewModel : class, IMvxNavigationViewModel
    {
        protected abstract int FragmentLayoutId { get; }
        
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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            BindNavigation();
            
            return this.BindingInflate(FragmentLayoutId, container, false);
        }

        private void BindNavigation()
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
        
        private async void OnNavigateToInteractionRequested(object sender, MvxValueEventArgs<MvxNavigateInteractionParameter> eventArgs)
        {
            var didNavigate = false;
            if (eventArgs.Value.View is MvxFragment fragment)
            {
                didNavigate = await NavigateToFragment(fragment);
            }
            if (eventArgs.Value.View is Intent intent)
            {
                didNavigate = await NavigateToIntent(intent);
            }
            eventArgs.Value.DidNavigate(didNavigate);
        }
        
        private async void OnCloseInteractionRequested(object sender, MvxValueEventArgs<MvxCloseInteractionParameter> eventArgs)
        {
            var didClose = await Close();

            eventArgs.Value.DidClose(didClose);
        }

        protected virtual Task<bool> NavigateToFragment(MvxFragment fragment)
        {
            throw new MvxException("Parent ViewController's navigation not implemented.");
        }
        
        protected virtual Task<bool> NavigateToIntent(Intent intent)
        {
            throw new MvxException("Parent ViewController's navigation not implemented.");
        }
        
        protected virtual Task<bool> Close()
        {
            throw new MvxException("Parent ViewController's close navigation not implemented.");
        }
    }
}
