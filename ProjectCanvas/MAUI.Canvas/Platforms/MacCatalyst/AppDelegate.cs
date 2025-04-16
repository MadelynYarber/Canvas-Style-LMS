using Foundation;

namespace MAUI.Canvas
{
    [Register("AppDelegate")]
    public class AppDelegates : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
