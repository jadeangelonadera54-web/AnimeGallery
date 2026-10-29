# Anime Codex - .NET MAUI CollectionView Mobile Application

A mobile application developed with **C#** and **.NET MAUI** featuring the `CollectionView` control to showcase a collection of anime characters in a dark violet themed interface.

---

## 🎨 Theme & Palette
- **Deep Neutral Dark Violet Gradients**: `#0B0715` → `#160E2A` → `#22153F`
- **Card Surfaces**: Translucent dark violet gradient (`#231644` → `#180E2F`) with `#3B2666` borders and drop shadows
- **Accents**: Radiant Amethyst (`#7B2CBF`, `#9D4EDD`, `#C77DFF`, `#E0AAFF`)
- **Typography**: High-contrast pure white headers with soft lavender-gray body text (`#D5D1E8`)

---

## 🚀 Key Features

1. **CollectionView Implementation**:
   - Displays all 8 attached anime characters with custom `DataTemplate` styling.
   - Dynamic **Grid View (2 columns)** and **List View (1 column)** switcher.
   - Interactive `SelectionChanged` and card tap navigation.
   - Custom `EmptyView` with a quick "Reset Filters" action when queries yield no results.

2. **Real-time Search & Category Filtering**:
   - Instant search by character name, anime series, role, or abilities.
   - Interactive category filter pills (*All*, *Dark Fantasy*, *Action*, *Supernatural*, *Adventure*).

3. **Separate Comprehensive Details Page (`CharacterDetailPage`)**:
   - Hero header with character portrait and gradient overlay.
   - Anime series, role, and affiliation badges.
   - Full lore and biography.
   - Signature ability card with itemized technique list.
   - Styled iconic character quote card.
   - Combat attribute meters (Power, Agility, Tactics/Intelligence, Durability) with animated visual progress bars.
   - Interactive Favorite / Bookmark button with status alert feedback.
   - Custom top navigation bar with back button (`Shell.Current.GoToAsync("..")`).

---

## 📁 Included Anime Characters & Image Assets

All characters utilize the images from `Resources/Images/`:
- **Eren Yeager** (`eren.jpg`) - *Attack on Titan*
- **Ichigo Kurosaki** (`ichigo.jpg`) - *Bleach*
- **Manjiro Sano "Mikey"** (`mickey.jpg`) - *Tokyo Revengers*
- **Sasuke Uchiha** (`sasuke.jpg`) - *Naruto Shippuden*
- **Ryomen Sukuna** (`sukuna.jpg`) - *Jujutsu Kaisen*
- **Sung Jin-Woo** (`sungjinwoo.jpg`) - *Solo Leveling*
- **Tanjiro Kamado** (`tanjiru.png`) - *Demon Slayer*
- **Roronoa Zoro** (`zoro.jpg`) - *One Piece*

---

## 🛠️ Project Structure
```
collectionview/
├── Models/
│   └── AnimeCharacter.cs          # Character data model with attributes & stats
├── Services/
│   └── AnimeCharacterService.cs   # Roster provider & category definitions
├── ViewModels/
│   ├── BaseViewModel.cs           # INotifyPropertyChanged base implementation
│   └── MainViewModel.cs           # Search, category filters, and layout management
├── Views/
│   ├── CharacterDetailPage.xaml   # Dossier / Detail view with stats & abilities
│   └── CharacterDetailPage.xaml.cs# IQueryAttributable navigation logic
├── Resources/
│   └── Images/                    # Attached anime character images
├── MainPage.xaml                  # CollectionView layout with header & search
├── MainPage.xaml.cs
├── AppShell.xaml                  # Shell navigation & route registration
├── AppShell.xaml.cs
└── AnimeGallery.csproj            # .NET 10 MAUI Multi-platform Project
```

---

## 💻 How to Run the App

### Windows:
```powershell
dotnet build -f net10.0-windows10.0.19041.0
.\bin\Debug\net10.0-windows10.0.19041.0\win-x64\AnimeGallery.exe
```
Or launch directly with:
```powershell
dotnet run -f net10.0-windows10.0.19041.0
```

### Android:
```powershell
dotnet build -f net10.0-android
```
