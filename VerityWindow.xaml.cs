using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace DesktopVerity;

/**
 * Implements the window for the 3D verity model.
 */
public partial class VerityWindow
{
    private Verity3DDebugWindow? _debugWindow;

    public Vector3D LightPosition
    {
        get => (Vector3D)GetValue(LightPositionProperty);
        set => SetValue(LightPositionProperty, value);
    }

    public static readonly DependencyProperty LightPositionProperty = DependencyProperty.Register(
        name: nameof(LightPosition),
        propertyType: typeof(Vector3D),
        ownerType: typeof(VerityWindow),
        typeMetadata: new FrameworkPropertyMetadata(
            defaultValue: new Vector3D(1.6421, 10, 0.8302)));

    public double LightPositionX
    {
        get => ((Vector3D)GetValue(LightPositionProperty)).X;
        set
        {
            Vector3D vector = (Vector3D)GetValue(LightPositionProperty);
            vector.X = value;
            SetValue(LightPositionProperty, vector);
        }
    }

    public double LightPositionY
    {
        get => ((Vector3D)GetValue(LightPositionProperty)).Y;
        set
        {
            Vector3D vector = (Vector3D)GetValue(LightPositionProperty);
            vector.Y = value;
            SetValue(LightPositionProperty, vector);
        }
    }

    public double LightPositionZ
    {
        get => ((Vector3D)GetValue(LightPositionProperty)).Z;
        set
        {
            Vector3D vector = (Vector3D)GetValue(LightPositionProperty);
            vector.Z = value;
            SetValue(LightPositionProperty, vector);
        }
    }

    public double CameraPositionX
    {
        get => (double)GetValue(CameraPositionXProperty);
        set => SetValue(CameraPositionXProperty, value);
    }
    public double CameraPositionY
    {
        get => (double)GetValue(CameraPositionYProperty);
        set => SetValue(CameraPositionYProperty, value);
    }
    public double CameraPositionZ
    {
        get => (double)GetValue(CameraPositionZProperty);
        set => SetValue(CameraPositionZProperty, value);
    }

    public static readonly DependencyProperty CameraPositionXProperty = DependencyProperty.Register(
        name: nameof(CameraPositionX),
        propertyType: typeof(double),
        ownerType: typeof(VerityWindow),
        typeMetadata: new FrameworkPropertyMetadata(
            defaultValue: 0.0,
            propertyChangedCallback: OnCameraAngleChangedCallback));

    public static readonly DependencyProperty CameraPositionYProperty = DependencyProperty.Register(
        name: nameof(CameraPositionY),
        propertyType: typeof(double),
        ownerType: typeof(VerityWindow),
        typeMetadata: new FrameworkPropertyMetadata(
            defaultValue: 0.0,
            propertyChangedCallback: OnCameraAngleChangedCallback));

    public static readonly DependencyProperty CameraPositionZProperty = DependencyProperty.Register(
        name: nameof(CameraPositionZ),
        propertyType: typeof(double),
        ownerType: typeof(VerityWindow),
        typeMetadata: new FrameworkPropertyMetadata(
            defaultValue: 0.0,
            propertyChangedCallback: OnCameraAngleChangedCallback));

    public VerityWindow()
    {
        // XXX: This was crashing under VMware for me without this line of code.
        if (Utility.IsRunningInVirtualMachine())
        {
            RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
        }

        InitializeComponent();

        VerityModel.Geometry = SphereGenerator.CreateSphere(30, 30);
    }

    private static void OnCameraAngleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not VerityWindow verityWindow) return;

        double x = verityWindow.CameraPositionX;
        double y = verityWindow.CameraPositionY;
        double z = verityWindow.CameraPositionZ;

        verityWindow.Camera.Position = new(x, y, z);
        verityWindow.Camera.LookDirection = new(-x, -y, -z);
        verityWindow.Camera.UpDirection = new(0, 1, 0);
    }

    private void OpenDebugWindow(object sender, RoutedEventArgs e)
    {
        _debugWindow = new(this);
        _debugWindow.Show();
    }

    private void CloseMenuItemOnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}