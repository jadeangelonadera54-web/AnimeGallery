using AnimeGallery.ViewModels;

namespace AnimeGallery;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}
