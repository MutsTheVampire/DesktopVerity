namespace DesktopVerity;

/**
 * Represents a basic emotion.
 */
public enum SimpleEmotion
{
    Happy,
    Neutral,
    Crazy,
    Serious,
    Evil,
    Hurt,
}

public class VerityEmotion
{
    private Verity _verity;

    public SimpleEmotion SimpleEmotion
    {
        get;
        internal set
        {
            field = value;
            EmotionChanged?.Invoke(this, EventArgs.Empty);
        }
    } = SimpleEmotion.Happy;

    /**
     * Represents the intensity of the emotion on a scale of 0-100.
     *
     * The more intense the emotion is felt, the more agitated Verity will seem.
     */
    public int Intensity { get; private set; } = 50;

    public event EventHandler EmotionChanged;

    public VerityEmotion(Verity verity)
    {
        _verity = verity;
    }
}