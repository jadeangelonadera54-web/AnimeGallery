using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Storage;
using Microsoft.UI.Xaml.Controls;
using Windows.Media.Core;
using Windows.Media.Playback;
using AnimeGallery.Controls;

namespace AnimeGallery.Platforms.Windows;

public class VideoPlayerViewHandler : ViewHandler<VideoPlayerView, MediaPlayerElement>
{
    public static IPropertyMapper<VideoPlayerView, VideoPlayerViewHandler> PropertyMapper =
        new PropertyMapper<VideoPlayerView, VideoPlayerViewHandler>(ViewMapper)
        {
            [nameof(VideoPlayerView.Source)] = MapSource,
        };

    public VideoPlayerViewHandler() : base(PropertyMapper)
    {
    }

    public VideoPlayerViewHandler(IPropertyMapper? mapper) : base(mapper ?? PropertyMapper)
    {
    }

    protected override MediaPlayerElement CreatePlatformView()
    {
        return new MediaPlayerElement
        {
            AutoPlay = true,
            AreTransportControlsEnabled = false
        };
    }

    public static async void MapSource(VideoPlayerViewHandler handler, VideoPlayerView virtualView)
    {
        if (handler.PlatformView == null || string.IsNullOrWhiteSpace(virtualView.Source))
            return;

        try
        {
            var fileName = virtualView.Source;
            var targetPath = Path.Combine(FileSystem.CacheDirectory, fileName);

            if (!File.Exists(targetPath))
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
                using var output = File.Create(targetPath);
                await stream.CopyToAsync(output);
            }

            var player = new MediaPlayer { AutoPlay = true };
            player.MediaEnded += (s, e) =>
            {
                MainThread.BeginInvokeOnMainThread(() => virtualView.OnPlaybackCompleted());
            };
            player.MediaFailed += (s, e) =>
            {
                MainThread.BeginInvokeOnMainThread(() => virtualView.OnPlaybackCompleted());
            };

            player.Source = MediaSource.CreateFromUri(new Uri(targetPath));
            handler.PlatformView.SetMediaPlayer(player);
        }
        catch
        {
            virtualView.OnPlaybackCompleted();
        }
    }
}
