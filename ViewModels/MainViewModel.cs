using System.Collections.ObjectModel;
using System.Windows.Input;
using AnimeGallery.Models;
using AnimeGallery.Services;
using AnimeGallery.Views;

namespace AnimeGallery.ViewModels;

public class CategoryFilterItem : BaseViewModel
{
    public string Name { get; set; } = string.Empty;

    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (SetProperty(ref _isSelected, value))
            {
                OnPropertyChanged(nameof(BgColor));
                OnPropertyChanged(nameof(TxtColor));
                OnPropertyChanged(nameof(StrokeColor));
            }
        }
    }

    public Color BgColor => IsSelected ? Color.FromArgb("#7B2CBF") : Color.FromArgb("#21143D");
    public Color TxtColor => IsSelected ? Color.FromArgb("#FFFFFF") : Color.FromArgb("#BA94D1");
    public Color StrokeColor => IsSelected ? Color.FromArgb("#C77DFF") : Color.FromArgb("#3F2A6E");
}

public class MainViewModel : BaseViewModel
{
    private readonly AnimeCharacterService _characterService;
    private readonly List<AnimeCharacter> _allCharacters;

    public ObservableCollection<AnimeCharacter> FilteredCharacters { get; } = new();
    public ObservableCollection<CategoryFilterItem> CategoryFilters { get; } = new();

    private string _selectedCategory = "All";
    public string SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (SetProperty(ref _selectedCategory, value))
            {
                UpdateCategorySelectionStates();
                FilterCharacters();
            }
        }
    }

    private string _searchText = string.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                FilterCharacters();
            }
        }
    }

    private bool _isGridView = true;
    public bool IsGridView
    {
        get => _isGridView;
        set
        {
            if (SetProperty(ref _isGridView, value))
            {
                OnPropertyChanged(nameof(CurrentItemsLayout));
                OnPropertyChanged(nameof(ViewModeIcon));
                OnPropertyChanged(nameof(ViewModeLabel));
            }
        }
    }

    public ItemsLayout CurrentItemsLayout => IsGridView
        ? new GridItemsLayout(2, ItemsLayoutOrientation.Vertical) { HorizontalItemSpacing = 12, VerticalItemSpacing = 12 }
        : new LinearItemsLayout(ItemsLayoutOrientation.Vertical) { ItemSpacing = 12 };

    public string ViewModeIcon => IsGridView ? "☰" : "☷";
    public string ViewModeLabel => IsGridView ? "List View" : "Grid View";

    private AnimeCharacter? _selectedCharacter;
    public AnimeCharacter? SelectedCharacter
    {
        get => _selectedCharacter;
        set
        {
            if (SetProperty(ref _selectedCharacter, value) && value != null)
            {
                _ = NavigateToDetails(value);
                _selectedCharacter = null;
                OnPropertyChanged(nameof(SelectedCharacter));
            }
        }
    }

    public string CharacterCountText => $"{FilteredCharacters.Count} Characters";

    public ICommand SelectCategoryCommand { get; }
    public ICommand SelectCharacterCommand { get; }
    public ICommand ToggleViewModeCommand { get; }
    public ICommand RefreshCommand { get; }

    public MainViewModel()
    {
        _characterService = new AnimeCharacterService();
        _allCharacters = _characterService.GetAllCharacters();

        foreach (var cat in _characterService.GetCategories())
        {
            CategoryFilters.Add(new CategoryFilterItem
            {
                Name = cat,
                IsSelected = string.Equals(cat, "All", StringComparison.OrdinalIgnoreCase)
            });
        }

        SelectCategoryCommand = new Command<CategoryFilterItem>(item =>
        {
            if (item != null)
            {
                SelectedCategory = item.Name;
            }
        });

        SelectCharacterCommand = new Command<AnimeCharacter>(async character =>
        {
            if (character != null)
            {
                await NavigateToDetails(character);
            }
        });

        ToggleViewModeCommand = new Command(() =>
        {
            IsGridView = !IsGridView;
        });

        RefreshCommand = new Command(() =>
        {
            SearchText = string.Empty;
            SelectedCategory = "All";
        });

        FilterCharacters();
    }

    private void UpdateCategorySelectionStates()
    {
        foreach (var item in CategoryFilters)
        {
            item.IsSelected = string.Equals(item.Name, SelectedCategory, StringComparison.OrdinalIgnoreCase);
        }
    }

    private void FilterCharacters()
    {
        var filtered = _allCharacters.AsEnumerable();

        if (!string.Equals(SelectedCategory, "All", StringComparison.OrdinalIgnoreCase))
        {
            filtered = filtered.Where(c => string.Equals(c.Category, SelectedCategory, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var query = SearchText.Trim().ToLowerInvariant();
            filtered = filtered.Where(c =>
                c.Name.ToLowerInvariant().Contains(query) ||
                c.AnimeSeries.ToLowerInvariant().Contains(query) ||
                c.Role.ToLowerInvariant().Contains(query) ||
                c.SignatureAbility.ToLowerInvariant().Contains(query) ||
                c.Category.ToLowerInvariant().Contains(query));
        }

        FilteredCharacters.Clear();
        foreach (var character in filtered)
        {
            FilteredCharacters.Add(character);
        }

        OnPropertyChanged(nameof(CharacterCountText));
    }

    private async Task NavigateToDetails(AnimeCharacter character)
    {
        var parameters = new Dictionary<string, object>
        {
            { "Character", character }
        };

        await Shell.Current.GoToAsync(nameof(CharacterDetailPage), parameters);
    }
}
