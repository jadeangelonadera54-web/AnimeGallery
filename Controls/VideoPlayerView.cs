using System;
using Microsoft.Maui.Controls;

namespace AnimeGallery.Controls;

public class VideoPlayerView : View
{
    public static readonly BindableProperty SourceProperty =
        BindableProperty.Create(
            nameof(Source),
            typeof(string),
            typeof(VideoPlayerView),
            default(string));

    public string? Source
    {
        get => (string?)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public event EventHandler? PlaybackCompleted;

    public void OnPlaybackCompleted()
    {
        PlaybackCompleted?.Invoke(this, EventArgs.Empty);
    }
}
