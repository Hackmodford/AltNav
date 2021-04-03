using System;
using System.Threading.Tasks;
using AltNav.Core.Services;

namespace AltNav.Core.ViewModels.Main
{
    public class MainViewModel : MvxNavigationViewModel
    {
        private readonly IMvxAltNavigationService _altNavigationService;

        public MainViewModel(IMvxAltNavigationService altNavigationService)
        {
            _altNavigationService = altNavigationService;
        }

        public override async void ViewAppeared()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            var result = await _altNavigationService.Navigate<TestViewModel, string>(this);
            var a = result;
        }
    }
}
