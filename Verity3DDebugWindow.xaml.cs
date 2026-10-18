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
}