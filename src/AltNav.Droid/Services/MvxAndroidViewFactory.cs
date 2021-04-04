#nullable enable
using System;
using System.Threading.Tasks;
using AltNav.Core.Services;
using Android.Content;
using Android.OS;
using MvvmCross;
using MvvmCross.Exceptions;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace AltNav.Droid.Services
{
    public class MvxAndroidViewFactory : IMvxViewFactory
    {
        public const string ViewModelRequestBundleKey = "__mvxViewModelRequest";
        
        private readonly IMvxViewFinder _viewFinder;
        
        private readonly Lazy<IMvxNavigationSerializer> _navigationSerializer =
            new Lazy<IMvxNavigationSerializer>(() => Mvx.IoCProvider.Resolve<IMvxNavigationSerializer>());
        
        protected IMvxNavigationSerializer NavigationSerializer =>
            _navigationSerializer.Value;
        
        public MvxAndroidViewFactory(IMvxViewFinder viewFinder)
        {
            _viewFinder = viewFinder;
        }
        
        public async Task<object> ViewForViewModel(IMvxViewModel viewModel)
        {
            var request = new MvxViewModelInstanceRequest(viewModel);
            var view = CreateView(request);
            
            if (view is MvxFragment fragment)
            {
                // save MvxViewModelRequest in the Fragment's Arguments
#pragma warning disable CA2000 // Dispose objects before losing scope
                var bundle = new Bundle();
#pragma warning restore CA2000 // Dispose objects before losing scope
                var serializedRequest = NavigationSerializer.Serializer.SerializeObject(request);
                bundle.PutString(ViewModelRequestBundleKey, serializedRequest);
                
                fragment.ViewModel = viewModel;
                
                if (fragment.Arguments == null)
                {
                    fragment.Arguments = bundle;
                }
                else
                {
                    fragment.Arguments.Clear();
                    fragment.Arguments.PutAll(bundle);
                }
            }
            
            return await Task.FromResult(view);
        }
        
        private object CreateView(MvxViewModelRequest request)
        {
            var viewType = _viewFinder.GetViewType(request.ViewModelType);
            if (viewType == null)
                throw new MvxException("View Type not found for " + request.ViewModelType);

            object? view = null;
            
            if (viewType.IsSubclassOf(typeof(MvxActivity)))
            {
                view = CreateIntentForRequest(request);
            }

            if (viewType.IsSubclassOf(typeof(MvxFragment)))
            {
                view = CreateFragmentOfType(viewType);
            }
            
            if (view == null)
                throw new MvxException("Failed to create view for " + request.ViewModelType);
            
            return view;
        }

        private static object CreateFragmentOfType(Type viewType)
        {
            var view = Activator.CreateInstance(viewType);
            if (view == null)
                throw new MvxException("Failed to create fragment " + viewType);
            return view;
        }
        
        protected virtual Intent CreateIntentForRequest(MvxViewModelRequest? request)
        {
            var requestTranslator = Mvx.IoCProvider.Resolve<IMvxAndroidViewModelRequestTranslator>();

            if (request is MvxViewModelInstanceRequest viewModelInstanceRequest)
            {
                var intentWithKey = requestTranslator.GetIntentWithKeyFor(
                    viewModelInstanceRequest.ViewModelInstance,
                    viewModelInstanceRequest
                );

                return intentWithKey.intent;
            }

            return requestTranslator.GetIntentFor(request);
        }
    }
}