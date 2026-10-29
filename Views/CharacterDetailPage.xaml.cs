using AnimeGallery.Models;

namespace AnimeGallery.Views;

public partial class CharacterDetailPage : ContentPage, IQueryAttributable
{
    private bool _isFavorite = false;

    public CharacterDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Character", out var characterObj) && characterObj is AnimeCharacter character)
        {
            BindingContext = character;
        }
    }

    private async void OnBackButtonClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnFavoriteClicked(object? sender, EventArgs e)
    {
        _isFavorite = !_isFavorite;
        
        FavoriteLabel.Text = _isFavorite ? "♥" : "♡";
        FavoriteLabel.TextColor = _isFavorite ? Color.FromArgb("#FF5C8A") : Color.FromArgb("#E0AAFF");
        FavoriteBorder.Stroke = _isFavorite ? Color.FromArgb("#FF5C8A") : Color.FromArgb("#4A3477");

        if (BindingContext is AnimeCharacter character)
        {
            var status = _isFavorite ? "added to" : "removed from";
            await DisplayAlertAsync("Favorites", $"{character.Name} has been {status} your favorites!", "OK");
        }
    }
}
