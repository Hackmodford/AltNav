# AltNav 
*Work In Progress*

An alternative navigation method for MvvmCross applications

## Introduction

AltNav is a simpler approach to navigation in an MvvmCross project. 
It is the opinion of AltNav that the view layer is in the best
position to decide how to navigate to the next view. Essentially
this is a navigation approach that does not use a platform view presenter.

The goal is to provide all the benefits of ViewModel to ViewModel navigation while allowing the view layer to worry about presentation.

#How to Use

Implement `IMvxNavigationViewModel` in your Views.

```
public interface IMvxNavigationView
{
    public IMvxInteraction<MvxNavigateInteractionParameter> NavigateToInteraction { get; }
        
    public IMvxInteraction<MvxCloseInteractionParameter> CloseInteraction { get; }
}
```

Implement `IMvxNavigationViewModel` in your ViewModels.
```
public interface IMvxNavigationViewModel : IMvxViewModel
{
    public MvxInteraction<MvxNavigateInteractionParameter> NavigateToInteraction { get; }
        
    public MvxInteraction<MvxCloseInteractionParameter> CloseInteraction { get; }
}
```

*The current example project has base ViewModels and Views that already do this with some fancy extra sauce.*

Call navigate/close in your view models as you would expect while also passing in the current ViewModel.

`var result = await AltNavigationService.Navigate<TestViewModel, string>(this);`

The `AltNavigationService` will handle creating the ViewModel and View (just as you'd expect from the `MvxNavigationService`
but will not actually present the view.

Instead the `AltNavigationService` will Raise the NavigationInteractions in the View layer.

From there, it is up to the view to decide how to present the new view.


