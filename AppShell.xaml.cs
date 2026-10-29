using AnimeGallery.Views;

namespace AnimeGallery;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// Register navigation routes
		Routing.RegisterRoute(nameof(CharacterDetailPage), typeof(CharacterDetailPage));
	}
}
