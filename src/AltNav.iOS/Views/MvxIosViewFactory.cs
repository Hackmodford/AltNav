using System.Threading.Tasks;
using AltNav.Core.Services;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;

namespace AltNav.iOS.Views
{
    public class MvxIosViewFactory : IMvxViewFactory
    {
        private readonly IMvxIosViewCreator _viewCreator;

        public MvxIosViewFactory(IMvxIosViewCreator viewCreator)
        {
            _viewCreator = viewCreator;
        }

        public Task<object> ViewForViewModel(IMvxViewModel viewModel)
        {
            return Task.FromResult((object) _viewCreator.CreateView(viewModel));
        }
    }
}