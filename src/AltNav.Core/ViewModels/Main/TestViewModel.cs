using System;
using System.Threading.Tasks;
using AltNav.Core.Services;

namespace AltNav.Core.ViewModels.Main
{
    public class TestViewModel : MvxNavigationViewModelResult<string>
    {
        public string TestLabel { get; set; }

        private readonly IMvxAltNavigationService _altNavigationService;

        public TestViewModel(IMvxAltNavigationService altNavigationService)
        {
            _altNavigationService = altNavigationService;
            TestLabel = "This is a test for binding";
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();
            await Task.Delay(TimeSpan.FromSeconds(3));
            await _altNavigationService.Close(this, "example result");
        }
    }
}