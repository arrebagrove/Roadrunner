﻿using System.Reflection;
using System.Runtime.CompilerServices;
using Android.App;

using System.Reflection;
using System.Runtime.CompilerServices;

using Android;

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle ("RoadRunner.Android")]
[assembly: AssemblyDescription ("")]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyCompany ("")]
[assembly: AssemblyProduct ("")]
[assembly: AssemblyCopyright ("ryan")]
[assembly: AssemblyTrademark ("")]
[assembly: AssemblyCulture ("")]



// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion ("1.0.0")]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

[assembly:UsesPermission(Manifest.Permission.AccessFineLocation)]
[assembly:UsesPermission(Manifest.Permission.AccessCoarseLocation)]
[assembly:UsesPermission(Manifest.Permission.AccessWifiState)]
[assembly:UsesPermission(Manifest.Permission.AccessNetworkState)]
[assembly:UsesPermission(Manifest.Permission.Internet)]
[assembly:UsesPermission(Manifest.Permission.WriteExternalStorage)]

[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.Camera)]
[assembly: UsesPermission(Android.Manifest.Permission.Vibrate)]

[assembly: UsesFeature("android.hardware.camera", Required = false)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]
[assembly: UsesFeature("android.hardware.camera.flash", Required = false)]
