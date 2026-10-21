namespace DesktopVerity;

/**
 * Represents the relationship between Verity and his Friend, the user.
 */
public class VerityRelationship
{
    private Verity _verity;
    private Friend _friend;

    /**
     * Represents the attachment of Verity, on a scale of -100 through 100.
     *
     * A negative attachment indicates resentment. A positive attachment indicates positive obsessiveness.
     */
    public int Attachment { get; private set; } = 0;

    /**
     * Represents the loneliness of Verity, on a scale of 0 through 100.
     *
     * The lonelier Verity is, the more he will grow to resent his Friend.
     */
    public int Loneliness { get; private set; } = 0;

    public VerityRelationship(Verity verity, Friend friend)
    {
        _verity = verity;
        _friend = friend;
    }
}