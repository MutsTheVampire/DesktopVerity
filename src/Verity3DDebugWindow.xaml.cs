namespace DesktopVerity;

public partial class Verity3DDebugWindow
{
    private VerityWindow _verityWindow;

    public Verity3DDebugWindow(VerityWindow verityWindow)
    {
        _verityWindow = verityWindow;
        DataContext = _verityWindow;
        InitializeComponent();
    }

    private void EmotionHappy_Selected(object sender, System.Windows.RoutedEventArgs e)
    {
        _verityWindow.Verity.Emotion.SimpleEmotion = SimpleEmotion.Happy;
    }

    private void EmotionNeutral_Selected(object sender, System.Windows.RoutedEventArgs e)
    {
        _verityWindow.Verity.Emotion.SimpleEmotion = SimpleEmotion.Neutral;
    }

    private void EmotionCrazy_Selected(object sender, System.Windows.RoutedEventArgs e)
    {
        _verityWindow.Verity.Emotion.SimpleEmotion = SimpleEmotion.Crazy;
    }

    private void EmotionSerious_Selected(object sender, System.Windows.RoutedEventArgs e)
    {
        _verityWindow.Verity.Emotion.SimpleEmotion = SimpleEmotion.Serious;
    }

    private void EmotionEvil_Selected(object sender, System.Windows.RoutedEventArgs e)
    {
        _verityWindow.Verity.Emotion.SimpleEmotion = SimpleEmotion.Evil;
    }

    private void EmotionHurt_Selected(object sender, System.Windows.RoutedEventArgs e)
    {
        _verityWindow.Verity.Emotion.SimpleEmotion = SimpleEmotion.Hurt;
    }
}