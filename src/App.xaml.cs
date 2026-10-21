using System.Configuration;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace DesktopVerity;

/**
 * Insertion point for the application.
 */
public partial class App : Application
{
    internal AppConfig Config { get; private set; } = ConfigManager.Load();
    internal Friend Friend { get; private set; }
    internal Verity Verity { get; private set; }

    [Experimental("WPF0001")]
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ThemeMode = ThemeMode.System;

        // No friend name = friend not introduced. So, begin the introduction process.
        if (Config.FriendName == string.Empty)
        {
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            IntroductionWindow introductionWindow = new();
            introductionWindow.ShowDialog();

            if (Config.FriendName == string.Empty)
            {
                throw new("This should not happen");
            }

            ConfigManager.Save(Config);
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        Friend = new(Config.FriendName);

        Verity = new();

        VerityWindow verityWindow = new(Verity);
        MainWindow = verityWindow;
        verityWindow.Show();
    }
}