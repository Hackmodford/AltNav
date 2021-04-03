using System.Threading.Tasks;
using AltNav.Core.ViewModels;
using MvvmCross.ViewModels;

namespace AltNav.Core.Services
{
    public interface IMvxNavigationViewModel : IMvxViewModel
    {
        public MvxInteraction<MvxNavigateInteractionParameter> NavigateToInteraction { get; }
        
        public MvxInteraction<MvxCloseInteractionParameter> CloseInteraction { get; }
    }
    
    public interface IMvxNavigationViewModelResult<TResult> : IMvxViewModelResult<TResult>, IMvxNavigationViewModel 
        where TResult : class
    {
        // TaskCompletionSource<object>? CloseCompletionSource { get; set; }
    }
    
    public interface IMvxNavigationViewModel<TParameter> : IMvxViewModel<TParameter>, IMvxNavigationViewModel     
        where TParameter : class
    {
        
    }
    
    public interface IMvxNavigationViewModel<TParameter, TResult> : 
        IMvxNavigationViewModel<TParameter>,
        IMvxNavigationViewModelResult<TResult>
        where TParameter : class
        where TResult : class
    {
    }
}