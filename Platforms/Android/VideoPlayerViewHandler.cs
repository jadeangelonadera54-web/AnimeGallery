using System;
using System.IO;
using System.Threading.Tasks;
using Android.Widget;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Storage;
using AnimeGallery.Controls;

namespace AnimeGallery.Platforms.Android;

public class VideoPlayerViewHandler : ViewHandler<VideoPlayerView, VideoView>
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

    protected override VideoView CreatePlatformView()
    {
        var videoView = new VideoView(Context);
        videoView.Completion += (s, e) =>
        {
            VirtualView?.OnPlaybackCompleted();
        };
        videoView.Error += (s, e) =>
        {
            e.Handled = true;
            VirtualView?.OnPlaybackCompleted();
        };
        return videoView;
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

            handler.PlatformView.SetVideoPath(targetPath);
            handler.PlatformView.Start();
        }
        catch
        {
            virtualView.OnPlaybackCompleted();
        }
    }
}
