using System.Threading.Tasks;
using AltNav.Core.ViewModels.Main;

namespace AltNav.Droid.Views.Main
{
    public class TestFragment : BaseFragment<TestViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_test;

        protected override Task<bool> Close()
        {
            Activity.SupportFragmentManager.PopBackStack();
            return Task.FromResult(true);
        }
    }
}