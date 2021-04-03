using AltNav.Core.ViewModels;
using MvvmCross.ViewModels;

namespace AltNav.Core.Services
{
    public interface IMvxNavigationView
    {
        public IMvxInteraction<MvxNavigateInteractionParameter> NavigateToInteraction { get; }
        
        public IMvxInteraction<MvxCloseInteractionParameter> CloseInteraction { get; }
    }
}