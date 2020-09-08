using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace MyFitnessApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA1NjgzQDMxMzgyZTMyMmUzMFo5M0FhUkRIOXZuVVhGOThMMWlEYm93dUtaWG1Vb3UzckJucEFYTVBya1U9");

            string fileName = "myFitness_db.db3";
            string folderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
            string completePath = System.IO.Path.Combine(folderPath, fileName);

            Syncfusion.SfChart.XForms.iOS.Renderers.SfChartRenderer.Init();
            Syncfusion.XForms.iOS.ProgressBar.SfCircularProgressBarRenderer.Init();

            LoadApplication(new App(completePath));

            return base.FinishedLaunching(app, options);
        }
    }
}
