namespace YoutubeExplode.Exceptions;

/// <summary>
/// Exception thrown when the requested video is unplayable.
/// </summary>
public class VideoUnplayableException : YoutubeExplodeException
{
    public string? VideoId { get; }
    public string? Reason { get; }

    public enum ReasonType
    {
        Generic,
        NoStream
    }
    
    /// <summary>
    /// Initializes an instance of <see cref="VideoUnplayableException" />.
    /// </summary>
    protected VideoUnplayableException(string message) : base(message) {}

    /// <summary>
    /// Initializes an instance of <see cref="VideoUnplayableException" />.
    /// </summary>
    public VideoUnplayableException(string videoId, string? reason, ReasonType type) : base(
        type == ReasonType.NoStream
            ? $"Video '{videoId}' does not contain any playable streams. Reason: '{reason}'."
            : $"Video '{videoId}' is unplayable. Reason: '{reason}'.")
    {
        VideoId = videoId;
        Reason = reason;
    }
}