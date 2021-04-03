using System;
using System.Threading.Tasks;
using AltNav.Core.Services;
using MvvmCross.ViewModels;

namespace AltNav.Core.ViewModels
{
    public abstract class MvxNavigationViewModel : MvxViewModel, IMvxNavigationViewModel {
        
        private readonly MvxInteraction<MvxNavigateInteractionParameter> _navigateToInteraction = new MvxInteraction<MvxNavigateInteractionParameter>();
        public MvxInteraction<MvxNavigateInteractionParameter> NavigateToInteraction => _navigateToInteraction;
        
        private readonly MvxInteraction<MvxCloseInteractionParameter> _closeInteraction = new MvxInteraction<MvxCloseInteractionParameter>();
        public MvxInteraction<MvxCloseInteractionParameter> CloseInteraction => _closeInteraction;
    }
    
    public abstract class MvxNavigationViewModel<TParameter> : MvxNavigationViewModel, IMvxNavigationViewModel<TParameter>
        where TParameter : class
    {
        public abstract void Prepare(TParameter? parameter);
    }

    public abstract class MvxNavigationViewModelResult<TResult> : MvxNavigationViewModel, IMvxNavigationViewModelResult<TResult>
        where TResult : class
    {
        public TaskCompletionSource<object?>? CloseCompletionSource { get; set; }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource != null &&
                !CloseCompletionSource.Task.IsCompleted &&
                !CloseCompletionSource.Task.IsFaulted)
            {
                CloseCompletionSource.TrySetCanceled();
            }

            base.ViewDestroy(viewFinishing);
        }
    }

    public abstract class MvxNavigationViewModel<TParameter, TResult> : MvxNavigationViewModelResult<TResult>, IMvxNavigationViewModel<TParameter, TResult>
        where TParameter : class
        where TResult : class
    {
        public abstract void Prepare(TParameter? parameter);
    }
    
    public class MvxNavigateInteractionParameter
    {
        public Action<bool> DidNavigate { get; set; }
        public object View { get; set; }
    }
    
    public class MvxCloseInteractionParameter
    {
        public Action<bool> DidClose { get; set; }
    }
}
