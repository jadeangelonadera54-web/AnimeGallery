using System;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

namespace AnimeGallery.Views;

public partial class LoadingPage : ContentPage
{
    private bool _hasNavigated;

    public LoadingPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Safety timeout to guarantee transition even if video playback has issues
        Dispatcher.StartTimer(TimeSpan.FromSeconds(5), () =>
        {
            NavigateToMain();
            return false;
        });
    }

    private void OnVideoCompleted(object? sender, EventArgs e)
    {
        NavigateToMain();
    }

    private void NavigateToMain()
    {
        if (_hasNavigated)
            return;

        _hasNavigated = true;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            try
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
            catch
            {
                // Fallback navigation
                if (Shell.Current != null)
                {
                    Shell.Current.CurrentItem = Shell.Current.Items[1];
                }
            }
        });
    }
}
