using System.Threading.Tasks;
using AltNav.Core.ViewModels;
using MvvmCross.ViewModels;

namespace AltNav.Core.Services
{
    public interface IMvxViewFactory
    {
        Task<object> ViewForViewModel(IMvxViewModel viewModel);
    }
}