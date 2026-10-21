using System.Drawing;
using System.Windows;
using System.Windows.Interop;

namespace DesktopVerity;

public partial class IntroductionWindow : Window
{
    public IntroductionWindow()
    {
        InitializeComponent();
        Closed += OnClosed;

        PartMessageIcon.Source = Imaging.CreateBitmapSourceFromHIcon(SystemIcons.Question.Handle, Int32Rect.Empty, null);

        string?[] names = [
            System.DirectoryServices.AccountManagement.UserPrincipal.Current.GivenName?.Trim(),
            System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName?.Trim(),
            Environment.UserName.Trim(),
        ];

        PartFriendName.Text = names.First(name => !string.IsNullOrEmpty(name)) ?? string.Empty;
    }

    private static void OnClosed(object? sender, EventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        ConfigManager.Config.FriendName = PartFriendName.Text;
        Closed -= OnClosed;
        Close();
    }

    private void QuitButton_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}