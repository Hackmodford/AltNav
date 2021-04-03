using System.Threading.Tasks;
using AltNav.Core.ViewModels.Main;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace AltNav.iOS.Views
{
    public class TestViewController : BaseViewController<TestViewModel>
    {
        private UILabel _testLabel;

        protected override void CreateView()
        {
            _testLabel = new UILabel();
            Add(_testLabel);
        }

        protected override void LayoutView()
        {
            View.AddConstraints(_testLabel.AtTopOfSafeArea(View, 16),
                _testLabel.AtLeftOfSafeArea(View, 16),
                _testLabel.AtRightOfSafeArea(View, 16));
        }

        protected override void BindView()
        {
            base.BindView();
            var set = CreateBindingSet();
            set.Bind(_testLabel).To(vm => vm.TestLabel);
            set.Apply();
        }

        protected override Task<bool> Close()
        {
            // var tcs = new TaskCompletionSource<bool>();
            // DismissViewController(true, () =>
            // {
            //     tcs.SetResult(true);
            // });
            // return tcs.Task;
            NavigationController.PopViewController(true);
            return Task.FromResult(true);
        }
    }
}