using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AltNav.Core.ViewModels;
using MvvmCross;
using MvvmCross.Logging;
using MvvmCross.Navigation.EventArguments;
using MvvmCross.ViewModels;

namespace AltNav.Core.Services
{
    public interface IMvxAltNavigationService
    {
        /// <summary>
        /// Event that triggers right before navigation happens
        /// </summary>
        event EventHandler<IMvxNavigateEventArgs>? WillNavigate;

        /// <summary>
        /// Event that triggers right after navigation did occur
        /// </summary>
        event EventHandler<IMvxNavigateEventArgs>? DidNavigate;

        /// <summary>
        /// Event that triggers right before Closing
        /// </summary>
        event EventHandler<IMvxNavigateEventArgs>? WillClose;

        /// <summary>
        /// Event that triggers right after did happen
        /// </summary>
        event EventHandler<IMvxNavigateEventArgs>? DidClose;
        
        /// <summary>
        /// Navigates to an instance of a ViewModel
        /// </summary>
        /// <param name="fromViewModel"></param>
        /// <param name="toViewModel">ViewModel to navigate to</param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <returns>Boolean indicating successful navigation</returns>
        Task<bool> Navigate(IMvxNavigationViewModel fromViewModel, IMvxViewModel toViewModel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Navigates to an instance of a ViewModel and passes TParameter
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="fromViewModel"></param>
        /// <param name="toViewModel">ViewModel to navigate to</param>
        /// <param name="param">ViewModel parameter</param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <returns>Boolean indicating successful navigation</returns>
        Task<bool> Navigate<TParameter>(IMvxNavigationViewModel fromViewModel, IMvxViewModel<TParameter> toViewModel, TParameter param,
            CancellationToken cancellationToken = default)
            where TParameter : class;

        /// <summary>
        /// Navigates to an instance of a ViewModel and returns TResult
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="fromViewModel"></param>
        /// <param name="toViewModel"></param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <returns></returns>
        Task<TResult?> Navigate<TResult>(IMvxNavigationViewModel fromViewModel,
            IMvxNavigationViewModelResult<TResult> toViewModel,
            CancellationToken cancellationToken = default)
            where TResult : class;

        /// <summary>
        /// Navigates to an instance of a ViewModel passes TParameter and returns TResult
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="fromViewModel"></param>
        /// <param name="toViewModel"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <returns></returns>
        Task<TResult?> Navigate<TParameter, TResult>(IMvxNavigationViewModel fromViewModel,
            IMvxNavigationViewModel<TParameter, TResult> toViewModel, TParameter param,
            CancellationToken cancellationToken = default)
            where TParameter : class
            where TResult : class;

        /// <summary>
        /// Navigates to a ViewModel Type
        /// </summary>
        /// <param name="fromViewModel"></param>
        /// <param name="toViewModel"></param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <returns>Boolean indicating successful navigation</returns>
        Task<bool> Navigate(IMvxNavigationViewModel fromViewModel, Type toViewModel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Navigates to a ViewModel Type and passes TParameter
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="fromViewModel"></param>
        /// <param name="toViewModel"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <returns>Boolean indicating successful navigation</returns>
        Task<bool> Navigate<TParameter>(IMvxNavigationViewModel fromViewModel, Type toViewModel, TParameter param, CancellationToken cancellationToken = default)
            where TParameter : class;

        /// <summary>
        /// Navigates to a ViewModel Type passes and returns TResult
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="fromViewModel"></param>
        /// <param name="toViewModel"></param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <returns></returns>
        Task<TResult?> Navigate<TResult>(IMvxNavigationViewModel fromViewModel, Type toViewModel, CancellationToken cancellationToken = default)
            where TResult : class;

        /// <summary>
        /// Navigates to a ViewModel Type passes TParameter and returns TResult
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="fromViewModel"></param>
        /// <param name="toViewModel"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <returns></returns>
        Task<TResult?> Navigate<TParameter, TResult>(IMvxNavigationViewModel fromViewModel, Type toViewModel, TParameter param,
            CancellationToken cancellationToken = default)
            where TParameter : class
            where TResult : class;

        

        // /// <summary>
        // /// Navigate to a ViewModel determined by its type
        // /// </summary>
        // /// <param name="presentationBundle">(optional) presentation bundle</param>
        // /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        // /// <typeparam name="TViewModel">Type of <see cref="IAltMvxViewModel"/></typeparam>
        // /// <returns>Boolean indicating successful navigation</returns>
        // Task<bool> Navigate<TViewModel>(IMvxNavigationViewModel fromViewModel, CancellationToken cancellationToken = default)
        //     where TViewModel : IMvxViewModel;

        /// <summary>
        /// Navigate to a ViewModel determined by its type, with parameter
        /// </summary>
        /// <param name="fromViewModel"></param>
        /// <param name="param">ViewModel parameter</param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <typeparam name="TViewModel">Type of <see cref="IAltMvxViewModel{Parameter}"/></typeparam>
        /// <typeparam name="TParameter">Parameter passed to ViewModel</typeparam>
        /// <returns>Boolean indicating successful navigation</returns>
        Task<bool> Navigate<TViewModel, TParameter>(
            IMvxNavigationViewModel fromViewModel, TParameter param, CancellationToken cancellationToken = default)
            where TViewModel : IMvxViewModel<TParameter>
            where TParameter : class;

        /// <summary>
        /// Navigate to a ViewModel determined by its type, which returns a result.
        /// </summary>
        /// <param name="fromViewModel"></param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <typeparam name="TViewModel">Type of <see cref="IMvxViewModel"/></typeparam>
        /// <typeparam name="TResult">Result from the ViewModel</typeparam>
        /// <returns>Returns a <see cref="Task{Task}"/> with <see cref="TResult"/></returns>
        Task<TResult?> Navigate<TViewModel, TResult>(
            IMvxNavigationViewModel fromViewModel, CancellationToken cancellationToken = default)
            where TViewModel : IMvxViewModelResult<TResult>
            where TResult : class;

        /// <summary>
        /// Navigate to a ViewModel determined by its type, with parameter and which returns a result.
        /// </summary>
        /// <param name="fromViewModel"></param>
        /// <param name="param">ViewModel parameter</param>
        /// <param name="cancellationToken">CancellationToken to cancel the navigation</param>
        /// <typeparam name="TParameter">Parameter passed to ViewModel</typeparam>
        /// <typeparam name="TResult">Result from the ViewModel</typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns>Returns a <see cref="Task{Task}"/> with <see cref="TResult"/></returns>
        Task<TResult?> Navigate<TViewModel, TParameter, TResult>(
            IMvxNavigationViewModel fromViewModel, TParameter param, CancellationToken cancellationToken = default)
            where TViewModel : IMvxViewModel<TParameter, TResult>
            where TParameter : class
            where TResult : class;


        public Task<bool> Navigate<TViewModel>(
            IMvxNavigationViewModel fromViewModel, CancellationToken cancellationToken = default)
            where TViewModel : IMvxNavigationViewModel;

        /// <summary>
        /// Closes the View attached to the ViewModel
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> Close(IMvxNavigationViewModel viewModel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Closes the View attached to the ViewModel and returns a result to the underlying ViewModel
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="viewModel"></param>
        /// <param name="result"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> Close<TResult>(IMvxNavigationViewModelResult<TResult> viewModel, TResult? result, CancellationToken cancellationToken = default)
            where TResult : class;

        // /// <summary>
        // /// Dispatches a ChangePresentation with Hint
        // /// </summary>
        // /// <param name="hint"></param>
        // /// <param name="cancellationToken"></param>
        // /// <returns></returns>
        // Task<bool> ChangePresentation(MvxPresentationHint hint, CancellationToken cancellationToken = default);
    }
    
    public class MvxAltNavigationService : IMvxAltNavigationService
    {
        private readonly Lazy<IMvxLog> _log = new Lazy<IMvxLog>(() =>
            Mvx.IoCProvider.Resolve<IMvxLogProvider>().GetLogFor<MvxAltNavigationService>());
        
        protected IMvxViewModelLoader ViewModelLoader { get; }
        
        protected IMvxViewFactory ViewFactory { get; }

        protected ConditionalWeakTable<IMvxViewModel, TaskCompletionSource<object?>> TaskCompletionResults { get; } =
            new ConditionalWeakTable<IMvxViewModel, TaskCompletionSource<object?>>();

        public event EventHandler<IMvxNavigateEventArgs>? WillNavigate;

        public event EventHandler<IMvxNavigateEventArgs>? DidNavigate;

        public event EventHandler<IMvxNavigateEventArgs>? WillClose;

        public event EventHandler<IMvxNavigateEventArgs>? DidClose;
        
        public MvxAltNavigationService(IMvxViewModelLoader viewModelLoader,
            IMvxViewFactory viewFactory)
        {
            ViewModelLoader = viewModelLoader;
            ViewFactory = viewFactory;
            // ViewsContainer = new Lazy<IMvxViewsContainer>(() => Mvx.IoCProvider.Resolve<IMvxViewsContainer>());
        }
        
        protected virtual void OnWillNavigate(object sender, IMvxNavigateEventArgs e)
        {
            WillNavigate?.Invoke(sender, e);
        }

        protected virtual void OnDidNavigate(object sender, IMvxNavigateEventArgs e)
        {
            DidNavigate?.Invoke(sender, e);
        }

        protected virtual void OnWillClose(object sender, IMvxNavigateEventArgs e)
        {
            WillClose?.Invoke(sender, e);
        }

        protected virtual void OnDidClose(object sender, IMvxNavigateEventArgs e)
        {
            DidClose?.Invoke(sender, e);
        }
        
        /////////////////////
        // Navigate by ViewModel
        ////////////////////
        
        public async Task<bool> Navigate(IMvxNavigationViewModel fromViewModel, IMvxViewModel toViewModel,
            CancellationToken cancellationToken = default)
        {
            var args = new MvxNavigateEventArgs(toViewModel, NavigationMode.Show, cancellationToken);
            OnWillNavigate(this, args);

            if (args.Cancel)
                return false;
            
            var request = new MvxViewModelInstanceRequest(toViewModel);
            ViewModelLoader.ReloadViewModel(toViewModel, request, null);
            var view = ViewFactory.ViewForViewModel(toViewModel).Result;

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            var navigationParameter = new MvxNavigateInteractionParameter
            {
                View = view,
                DidNavigate = result =>
                {
                    tcs.SetResult(result);
                }
            };
            
            fromViewModel.NavigateToInteraction.Raise(navigationParameter);

            var hasNavigated = await tcs.Task;
            if (!hasNavigated)
                return false;
            
            if (toViewModel.InitializeTask.Task != null)
                await toViewModel.InitializeTask.Task.ConfigureAwait(false);

            OnDidNavigate(this, args);
            return true;
        }
        
        public async Task<bool> Navigate<TParameter>(IMvxNavigationViewModel fromViewModel, IMvxViewModel<TParameter> toViewModel, TParameter param,
            CancellationToken cancellationToken = default) where TParameter : class
        {
            //Todo: Make Async
            var args = new MvxNavigateEventArgs(toViewModel, NavigationMode.Show, cancellationToken);
            OnWillNavigate(this, args);

            if (args.Cancel)
                return false;
            
            var request = new MvxViewModelInstanceRequest(toViewModel);
            ViewModelLoader.ReloadViewModel(toViewModel, param, request, null);
            var view = ViewFactory.ViewForViewModel(toViewModel).Result;
            
            TaskCompletionSource<bool> navigationTaskSource = new TaskCompletionSource<bool>();

            var navigationParameter = new MvxNavigateInteractionParameter
            {
                View = view,
                DidNavigate = result =>
                {
                    navigationTaskSource.SetResult(result);
                }
            };
            
            fromViewModel.NavigateToInteraction.Raise(navigationParameter);

            var hasNavigated = await navigationTaskSource.Task;
            if (!hasNavigated)
                return false;
            
            if (toViewModel.InitializeTask.Task != null)
                await toViewModel.InitializeTask.Task.ConfigureAwait(false);

            OnDidNavigate(this, args);
            return true;
        }

        public async Task<TResult?> Navigate<TResult>(IMvxNavigationViewModel fromViewModel,
            IMvxNavigationViewModelResult<TResult> toViewModel,
            CancellationToken cancellationToken = default) where TResult : class
        {
            var hasNavigated = false;
            var tcs = new TaskCompletionSource<object?>();

            if (cancellationToken != default)
            {
                cancellationToken.Register(() =>
                {
                    // ReSharper disable once AccessToModifiedClosure
                    if (hasNavigated && !tcs.Task.IsCompleted)
                        Task.Run(() => Close(toViewModel, default, CancellationToken.None), CancellationToken.None);
                });
            }

            var args = new MvxNavigateEventArgs(toViewModel, NavigationMode.Show, cancellationToken);
            OnWillNavigate(this, args);

            toViewModel.CloseCompletionSource = tcs;
            TaskCompletionResults.Add(toViewModel, tcs);

            cancellationToken.ThrowIfCancellationRequested();

            var request = new MvxViewModelInstanceRequest(toViewModel);
            ViewModelLoader.ReloadViewModel(toViewModel, request, null);
            var view = ViewFactory.ViewForViewModel(toViewModel).Result;
            
            TaskCompletionSource<bool> navigationTaskSource = new TaskCompletionSource<bool>();

            var navigationParameter = new MvxNavigateInteractionParameter
            {
                View = view,
                DidNavigate = result =>
                {
                    navigationTaskSource.SetResult(result);
                }
            };
            
            fromViewModel.NavigateToInteraction.Raise(navigationParameter);

            hasNavigated = await navigationTaskSource.Task;
            if (!hasNavigated)
                return default;
            
            if (toViewModel.InitializeTask?.Task != null)
                await toViewModel.InitializeTask.Task.ConfigureAwait(false);

            OnDidNavigate(this, args);

            try
            {
                return (TResult?)await tcs.Task.ConfigureAwait(false);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<TResult?> Navigate<TParameter, TResult>(IMvxNavigationViewModel fromViewModel,
            IMvxNavigationViewModel<TParameter, TResult> toViewModel, TParameter param,
            CancellationToken cancellationToken = default) where TParameter : class where TResult : class
        {
            var hasNavigated = false;
            var tcs = new TaskCompletionSource<object?>();

            if (cancellationToken != default)
            {
                cancellationToken.Register(() =>
                {
                    // ReSharper disable once AccessToModifiedClosure
                    if (hasNavigated && !tcs.Task.IsCompleted)
                        Task.Run(() => Close(toViewModel, default, CancellationToken.None), CancellationToken.None);
                });
            }

            var args = new MvxNavigateEventArgs(toViewModel, NavigationMode.Show, cancellationToken);
            OnWillNavigate(this, args);

            toViewModel.CloseCompletionSource = tcs;
            TaskCompletionResults.Add(toViewModel, tcs);

            cancellationToken.ThrowIfCancellationRequested();

            var request = new MvxViewModelInstanceRequest(toViewModel);
            ViewModelLoader.ReloadViewModel(toViewModel, param, request, null);
            var view = ViewFactory.ViewForViewModel(toViewModel).Result;
            
            TaskCompletionSource<bool> navigationTaskSource = new TaskCompletionSource<bool>();

            var navigationParameter = new MvxNavigateInteractionParameter
            {
                View = view,
                DidNavigate = result =>
                {
                    navigationTaskSource.SetResult(result);
                }
            };
            
            fromViewModel.NavigateToInteraction.Raise(navigationParameter);

            hasNavigated = await navigationTaskSource.Task;
            if (!hasNavigated)
                return default;
            
            if (toViewModel.InitializeTask?.Task != null)
                await toViewModel.InitializeTask.Task.ConfigureAwait(false);

            OnDidNavigate(this, args);

            try
            {
                return (TResult?)await tcs.Task.ConfigureAwait(false);
            }
            catch (Exception)
            {
                return default;
            }
        }
        
        /////////////////////
        // Navigate by Type
        ////////////////////
        
        public virtual Task<bool> Navigate(IMvxNavigationViewModel fromViewModel, Type toViewModelType,
            CancellationToken cancellationToken = default)
        {
            var request = new MvxViewModelInstanceRequest(toViewModelType);
            var toViewModel = ViewModelLoader.LoadViewModel(request, null);
            return Navigate(fromViewModel, toViewModel, cancellationToken);
        }

        public Task<bool> Navigate<TParameter>(IMvxNavigationViewModel fromViewModel, Type toViewModelType, TParameter param,
            CancellationToken cancellationToken = default) where TParameter : class
        {
            var request = new MvxViewModelInstanceRequest(toViewModelType);
            var toViewModel = (IMvxViewModel<TParameter>) ViewModelLoader.LoadViewModel(request, param, null);
            return Navigate(fromViewModel, toViewModel, param, cancellationToken);
        }
        
        public Task<TResult?> Navigate<TResult>(IMvxNavigationViewModel fromViewModel, Type toViewModelType,
            CancellationToken cancellationToken = default) where TResult : class
        {
            var request = new MvxViewModelInstanceRequest(toViewModelType);
            var toViewModel = (IMvxNavigationViewModelResult<TResult>) ViewModelLoader.LoadViewModel(request, null);
            return Navigate(fromViewModel, toViewModel, cancellationToken);
        }

        public Task<TResult?> Navigate<TParameter, TResult>(IMvxNavigationViewModel fromViewModel, Type toViewModelType, TParameter param,
            CancellationToken cancellationToken = default) where TParameter : class where TResult : class
        {
            var request = new MvxViewModelInstanceRequest(toViewModelType);
            var toViewModel = (IMvxNavigationViewModel<TParameter, TResult>) ViewModelLoader.LoadViewModel(request, param, null);
            return Navigate(fromViewModel, toViewModel, param, cancellationToken);
        }
        
        ////////////////////////////
        // Navigate by Generic Type
        ///////////////////////////
        
        public virtual Task<bool> Navigate<TViewModel>(
            IMvxNavigationViewModel fromViewModel, CancellationToken cancellationToken = default)
            where TViewModel : IMvxNavigationViewModel
        {
            return Navigate(fromViewModel, typeof(TViewModel), cancellationToken);
        }
        
        public Task<bool> Navigate<TViewModel, TParameter>(IMvxNavigationViewModel fromViewModel, TParameter param,
            CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel<TParameter> where TParameter : class
        {
            return Navigate(fromViewModel, typeof(TViewModel), param, cancellationToken);
        }

        public Task<TResult?> Navigate<TViewModel, TResult>(IMvxNavigationViewModel fromViewModel,
            CancellationToken cancellationToken = default) where TViewModel : IMvxViewModelResult<TResult> where TResult : class
        {
            return Navigate<TResult>(fromViewModel, typeof(TViewModel), cancellationToken);
        }

        public Task<TResult?> Navigate<TViewModel, TParameter, TResult>(IMvxNavigationViewModel fromViewModel, TParameter param,
            CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel<TParameter, TResult> where TParameter : class where TResult : class
        {
            return Navigate<TParameter, TResult>(fromViewModel, typeof(TViewModel), param, cancellationToken);
        }
        
        //////////
        // Close
        //////////
        
        public async Task<bool> Close(IMvxNavigationViewModel viewModel, CancellationToken cancellationToken = default)
        {
            var args = new MvxNavigateEventArgs(viewModel, NavigationMode.Close, cancellationToken);
            OnWillClose(this, args);

            if (args.Cancel)
                return false;
            
            TaskCompletionSource<bool> navigationTaskSource = new TaskCompletionSource<bool>();

            var closeParameter = new MvxCloseInteractionParameter()
            {
                DidClose = result =>
                {
                    navigationTaskSource.SetResult(result);
                }
            };
            
            viewModel.CloseInteraction.Raise(closeParameter);

            var close = await navigationTaskSource.Task;
            OnDidClose(this, args);

            return close;
        }

        public async Task<bool> Close<TResult>(IMvxNavigationViewModelResult<TResult> viewModel, TResult? result, CancellationToken cancellationToken = default) where TResult : class
        {
            TaskCompletionResults.TryGetValue(viewModel, out var tcs);

            //Disable cancelation of the Task when closing ViewModel through the service
            viewModel.CloseCompletionSource = null;

            try
            {
                var closeResult = await Close(viewModel, cancellationToken).ConfigureAwait(false);
                if (closeResult)
                {
                    tcs?.TrySetResult(result);
                    TaskCompletionResults.Remove(viewModel);
                }
                else
                    viewModel.CloseCompletionSource = tcs;
                return closeResult;
            }
            catch (Exception ex)
            {
                tcs?.TrySetException(ex);
                return false;
            }
        }
    }
}