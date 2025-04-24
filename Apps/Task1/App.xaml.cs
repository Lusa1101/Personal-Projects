using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;

namespace Task1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            //Licensing
            SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBPh8sVXJ9S0d+X1JPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9mSXpSckVhXXhcdHBSRmhXU00=;NRAiBiAaIQQuGjN/V09+XU9HdVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3tTckRnWX1ad3ZRQ2lZWU90Vg==;Mgo+DSMBMAY9C3t2XFhhQlJHfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTH5Xd0FjW3tZcnBSRGFcWkZ/;MzgxNDIwMEAzMjM5MmUzMDJlMzAzYjMyMzkzYmJPcTJuRjR1b3pUaUc1TStlVlpCR3BmVEhON1hDMGhzN2V2cFVtZjAxbTA9;MzgxNDIwMUAzMjM5MmUzMDJlMzAzYjMyMzkzYkxHMHR0bnBDeFJRbUpkMXRPTUNGM2xHZHBLN1VFV1E4RytuQ09mSEN5aUk9");
        }
    }
}
