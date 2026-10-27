using System.Windows.Controls;

namespace DesktopVerity;

public partial class Verity3DDebugWindow
{
    private VerityWindow _verityWindow;

    public Verity3DDebugWindow(VerityWindow verityWindow)
    {
        _verityWindow = verityWindow;
        DataContext = _verityWindow;
        InitializeComponent();

        foreach (string enumName in typeof(SimpleEmotion).GetEnumNames())
        {
            ComboBoxItem item = new()
            {
                Content = enumName,
            };

            item.Selected += (sender, args) =>
            {
                _verityWindow.Verity.Emotion.SimpleEmotion = Enum.Parse<SimpleEmotion>(enumName);
            };

            PART_EmotionComboBox.Items.Add(item);
        }

        PART_EmotionComboBox.SelectedIndex = 0;
    }
}