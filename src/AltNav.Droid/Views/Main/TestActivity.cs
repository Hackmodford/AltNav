using System.Threading.Tasks;
using AltNav.Core.ViewModels.Main;
using Android.App;
using Android.Views;

namespace AltNav.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class TestActivity : BaseActivity<TestViewModel2>
    {
        protected override int ActivityLayoutId => Resource.Layout.fragment_test;
        
        protected override Task<bool> Close()
        {
            Finish();
            return Task.FromResult(true);
        }
    }
}