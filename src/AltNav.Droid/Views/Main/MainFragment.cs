using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AltNav.Core.ViewModels.Main;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Views.Fragments;

namespace AltNav.Droid.Views.Main
{
    [MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.content_frame)]
    public class MainFragment : BaseFragment<MainViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_main;
        
        protected override Task<bool> NavigateToFragment(MvxFragment fragment)
        {
            Activity.SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .AddToBackStack(null)
                .Commit();

            return Task.FromResult(true);
        }

        protected override Task<bool> NavigateToIntent(Intent intent)
        {
            StartActivity(intent);
            return Task.FromResult(true);
        }
    }
}