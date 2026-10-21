namespace DesktopVerity;

public class Verity
{
    public VerityEmotion Emotion { get; private set; }

    public Friend Friend
    {
        get;
        set
        {
            field = value;
            Relationship = new(this, value);
        }
    }

    public VerityRelationship Relationship { get; private set; }

    public Verity()
    {
        Emotion = new(this);
    }

    public void Think()
    {
        // Perform Verity AI behavior: thinking about where to move, what to feel, etc. This will be run every tick.
    }
}