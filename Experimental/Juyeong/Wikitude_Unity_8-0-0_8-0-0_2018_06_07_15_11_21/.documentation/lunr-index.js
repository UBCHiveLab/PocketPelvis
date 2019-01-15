
var index = lunr(function () {
    this.field('body');
    this.ref('url');
});

var documentTitles = {};



documentTitles["gettingstartedunity.html#getting-started"] = "Getting started";
index.add({
    url: "gettingstartedunity.html#getting-started",
    title: "Getting started",
    body: "# Getting started  "
});

documentTitles["gettingstartedunity.html#introduction-to-the-wikitude-sdk"] = "Introduction to the Wikitude SDK";
index.add({
    url: "gettingstartedunity.html#introduction-to-the-wikitude-sdk",
    title: "Introduction to the Wikitude SDK",
    body: "## Introduction to the Wikitude SDK  &lt;p class='intro' markdown='1'&gt;Welcome to the Wikitude SDK. This document is designed to help you from your very first steps with the Wikitude SDK all the way through to advanced concepts and examples for developing your augmented reality project.&lt;/p&gt;  &lt;div class=\&quot;warning\&quot;&gt;  Please note that the Wikitude Unity Plugin currently supports &lt;br /&gt; &lt;ul&gt; &lt;li&gt;&lt;strong&gt;Unity&amp;nbsp; 5.4.5&lt;/strong&gt; or higher&lt;/li&gt; &lt;li&gt;Rendering engines&lt;/li&gt; &lt;ul&gt; &lt;li&gt;OpenGL ES 2&lt;/li&gt; &lt;li&gt;OpenGL ES 3.x&lt;/li&gt; &lt;li&gt;Metal (iOS only)&lt;/li&gt; &lt;/ul&gt;  &lt;li&gt;Because Unity currently doesn't support 64 bit libraries on Android, performance on such devices might be lower than similar devices running iOS 64 bit.&lt;/li&gt; &lt;/ul&gt;  &lt;/div&gt;     "
});

documentTitles["gettingstartedunity.html#recommended-usage-of-this-documentation"] = "Recommended Usage of this Documentation";
index.add({
    url: "gettingstartedunity.html#recommended-usage-of-this-documentation",
    title: "Recommended Usage of this Documentation",
    body: "### Recommended Usage of this Documentation  The documentation is arranged in a way to guide you through the various steps in your development process. We recommend following each of the steps outlined below and reading the documentation in the order displayed.  &lt;div class=\&quot;bigNumbers\&quot; markdown='1'&gt; &lt;div class='number'&gt;1&lt;/div&gt; "
});

documentTitles["gettingstartedunity.html#setup-your-project-with-the-unity-pluginsetupguideunityhtml"] = "[Setup your project with the Unity Plugin](setupguideunity.html)";
index.add({
    url: "gettingstartedunity.html#setup-your-project-with-the-unity-pluginsetupguideunityhtml",
    title: "[Setup your project with the Unity Plugin](setupguideunity.html)",
    body: "#### [Setup your project with the Unity Plugin](setupguideunity.html) In this section we describe the necessary steps to setup a project in a detailed guide.  &lt;div class='number'&gt;2&lt;/div&gt; "
});

documentTitles["gettingstartedunity.html#view-the-sample-applicationsampleunityhtml"] = "[View the sample application](sampleunity.html)";
index.add({
    url: "gettingstartedunity.html#view-the-sample-applicationsampleunityhtml",
    title: "[View the sample application](sampleunity.html)",
    body: "#### [View the sample application](sampleunity.html) Viewing the sample requires the corresponding reference image. It is available directly in the description of the sample. You can either view it on your monitor or print it. &lt;/div&gt;  "
});

documentTitles["gettingstartedunity.html#the-wikitude-native-sdk-augmented-reality-for-your-own-app"] = "The Wikitude Native SDK - Augmented Reality for your own app";
index.add({
    url: "gettingstartedunity.html#the-wikitude-native-sdk-augmented-reality-for-your-own-app",
    title: "The Wikitude Native SDK - Augmented Reality for your own app",
    body: "### The Wikitude Native SDK - Augmented Reality for your own app  The Wikitude Native SDK is a software library and framework for mobile apps used to create augmented reality experiences. The Native SDK supports use cases which require image recognition and tracking technology (vision based augmented reality).  To use the Wikitude Native SDK within a Unity project, simply import the Wikitude.unitypackage into a existing Unity project and import all assets that are part of the .unitypackage. After the import is done, use the `WikitudeCamera` prefab in combination with one of the `Tracker` prefabs.  "
});

documentTitles["gettingstartedunity.html#architecture-of-the-wikitude-sdk"] = "Architecture of the Wikitude SDK";
index.add({
    url: "gettingstartedunity.html#architecture-of-the-wikitude-sdk",
    title: "Architecture of the Wikitude SDK",
    body: "### Architecture of the Wikitude SDK  ![](images/sdk7_architecture.png)  The image above shows the different components of the Wikitude SDK and possible approaches for creating augmented reality apps. Each of these approaches are based on a certain development environments (IDE) and platforms:  * **Computer Vision Engine:** The computer vision engine is a core component of the Wikitude SDK and used by all platforms. It includes three major parts in its own: **SLAM Engine**, **Image Recognition Engine** and the **Cloud Recognition engine** It is not directly accessible, but wrapped either by the Native API (Java, Obj-C) or the JavaScript API. * **Wikitude SDK  - Native API:** Provides access to the Wikitude computer vision engine natively for Android (Java) and iOS (ObjC). It also can load plugins via the Wikitude Plugins API.  * **Wikitude SDK  - JavaScript API:** Allows to build augmented reality worlds on basis of HTML and JavaScript. It is available for Android and iOS. The JavaScript API provides access to the functionality of the computer vision engine, location based AR, the Plugins API and dedicated rendering functionality. * **Wikitude SDK  - Plugins API:** An API to connect your own plugins to the Wikitude SDK. (NOTE: Wikitude SDK plugins have nothing to do with the Cordova or Unity Plugin concept.) * **Wikitude SDK  - Cordova Plugin:** On top of the JavaScript API the Cordova plugin allows to use the Wikitude SDK in combination with Apache Cordova. * **Wikitude SDK  - Titanium Module:** On top of the JavaScript API the Titanium module allows to use the Wikitude SDK in combination with Titanium. * **Wikitude SDK  - Unity3D Plugin:** On top of the Native API the Unity plugin allows to use the Wikitude SDK in combination with Unity. * **Wikitude SDK  - Xamarin Component:** On top of the JavaScript API the Xamarin component allows to use the Wikitude SDK in combination with Xamarin.   "
});

documentTitles["gettingstartedunity.html#the-wikitude-developer-portal"] = "The Wikitude Developer Portal";
index.add({
    url: "gettingstartedunity.html#the-wikitude-developer-portal",
    title: "The Wikitude Developer Portal",
    body: "### The Wikitude Developer Portal The Wikitude Developer Section should be your first stop when you have specific development related questions. The portal hosts a very active &lt;a href=\&quot;https://support.wikitude.com/support/home\&quot; target=\&quot;_top\&quot;&gt;Developer Community Forum&lt;/a&gt; where Wikitude staff members are constantly assisting other developers with helpful tips and advice. You can find How-To's and a constantly evolving FAQ section there as well.  "
});

documentTitles["gettingstartedunity.html#feedback-and-contact"] = "Feedback and Contact";
index.add({
    url: "gettingstartedunity.html#feedback-and-contact",
    title: "Feedback and Contact",
    body: "### Feedback and Contact We are always interested in your feedback and suggestions how we can improve this documentation. Please use the &lt;a href=\&quot;http://www.wikitude.com/contact\&quot; target=\&quot;_top\&quot;&gt;contact form&lt;/a&gt; on our website or visit us on &lt;a href=\&quot;https://plus.google.com/103004921345651739447/\&quot; target=\&quot;_top\&quot;&gt;Google+&lt;/a&gt;,  &lt;a href=\&quot;https://www.facebook.com/WIKITUDE\&quot; target=\&quot;_top\&quot;&gt;Facebook&lt;/a&gt; or &lt;a href=\&quot;https://www.twitter.com/wikitude\&quot; target=\&quot;_top\&quot;&gt;Twitter&lt;/a&gt;.  "
});



documentTitles["setupguideunity.html#setup-guide-unity-plugin"] = "Setup Guide Unity Plugin";
index.add({
    url: "setupguideunity.html#setup-guide-unity-plugin",
    title: "Setup Guide Unity Plugin",
    body: "## Setup Guide Unity Plugin There are only a few steps necessary to add the Wikitude Unity Plugin to your existing Unity project. This guide will explain them in detail. In general the steps are  * Import the Wikitude.unitypackage into your project * Add the `WikitudeCamera` and one of the `Tracker` prefabs to the Unity scene hierarchy and configure their properties * Add a custom augmentation to the tracker as child GameObject to the `Trackable` * Export your project and change Xcode Build Settings in order to fully integrate the Wikitude Native API in your Unity project  "
});

documentTitles["setupguideunity.html#import-the-wikitudeunitypackage"] = "Import the Wikitude.unitypackage";
index.add({
    url: "setupguideunity.html#import-the-wikitudeunitypackage",
    title: "Import the Wikitude.unitypackage",
    body: "### Import the Wikitude.unitypackage The Wikitude Unity Plugin comes as a standard .unitypackage and can be imported through the usual Unity package import procedure. In your Assets inspector, right click and choose `Import Package -&gt; Custom Package`.  ![](images/unity_import_package_menu.png) Select the downloaded Wikitude.unitypackage in the presented open file browser and click `open`. You should import all items that are part of the Wikitude.unitypackage. ![](images/unity_import_package_button.png)  "
});

documentTitles["setupguideunity.html#use-the-wikitude-unity-plugin"] = "Use the Wikitude Unity plugin";
index.add({
    url: "setupguideunity.html#use-the-wikitude-unity-plugin",
    title: "Use the Wikitude Unity plugin",
    body: "### Use the Wikitude Unity plugin After the Wikitude.unitypackage was imported, its components and scripts can be used to define a custom augmented reality experience. The [example section](sampleunity.html) describes in more detail how those prefabs and scripts can be used to do so.  "
});

documentTitles["setupguideunity.html#export-and-xcode-build-settings-changes"] = "Export and Xcode Build Settings Changes";
index.add({
    url: "setupguideunity.html#export-and-xcode-build-settings-changes",
    title: "Export and Xcode Build Settings Changes",
    body: "### Export and Xcode Build Settings Changes Once the application is setup in Unity and ready for testing on a real device, it needs to be exported as an Xcode project for iOS or built for Android either directly by creating an .apk file using Unity or by exporting an Android Studio project.  "
});

documentTitles["setupguideunity.html#export-to-xcode"] = "Export to Xcode";
index.add({
    url: "setupguideunity.html#export-to-xcode",
    title: "Export to Xcode",
    body: "#### Export to Xcode   iOS developers need to open the exported project and manually do the steps listed below. * Before exporting, make sure the `Target minimum iOS version` is set to 9.0 or later in the Unity in Player Settings. This can also be done in the Xcode project, but setting it in Unity will ensure it doesn't get overwritten when rebuilding your project. * The `WikitudeNativeSDK` framework has to be added as an `Embedded Binary`. Please refer to the [Wikitude iOS Native SDK](http://www.wikitude.com/external/doc/documentation/latest/iosnative/setupguideiosnative.html#setup-guide-ios-native-api) setup guide for more information. * In the `Info.plist` file, make sure there is an entry for `NSCameraUsageDescription` with an appropriate value if you plan to deploy to iOS 10 or higher. Not doing so will lead to a runtime crash on the device. If you are using Unity 5.4.2 or higher, this setting can be done directly in Player Settings.  After these steps are done once, building with `Append` or by pressing `Cmd + B` will ensure that the settings are kept.  "
});

documentTitles["setupguideunity.html#export-an-apk-file"] = "Export an .apk file";
index.add({
    url: "setupguideunity.html#export-an-apk-file",
    title: "Export an .apk file",
    body: "#### Export an .apk file  If you don't need an Android Studio project, building directly from Unity is the fastest way to run your app on an Android device.  1. In Unity open `File | Build Settings...` ![](images/unity_build_settings_menu.png) 2. Make sure `Android` is the current build target. If not, select `Android` from the list and click `Switch Platform` 3. Click `Build And Run` and choose where to save the .apk file. If you have an Android device connected, it will also install the app on it. ![](images/unity_build_settings_run.png)  After this is done once, pressing `Ctrl + B` (Windows) or `Cmd + B` (Mac) will automatically create the .apk file and install it on your device, if it is connected.  "
});

documentTitles["setupguideunity.html#export-to-android-studio"] = "Export to Android Studio";
index.add({
    url: "setupguideunity.html#export-to-android-studio",
    title: "Export to Android Studio",
    body: "#### Export to Android Studio  Unfortunately Unity projects exported as Android Studio projects do not work out of the box. Some manual work is required which we described in detail below:  1. In Unity open `File | Build Settings...`, check `Google Android Project` and click `Export` ![](images/unity_build_settings_export.png) 2. Open Android Studio and click `Import Project (Eclipse ADT, Gradle, etc.)` ![](images/unity_android_import.png) 3. Within the file selection dialog, navigate to the folder where you exported the project and select the folder named after your app 4. In the next step choose a new, empty folder to import and click on `Next` 5. Finish importing by clicking `Finish` on the next screen 6. In Android Studio open `File | New | New Module ...` ![](images/unity_android_new_module.png) 7. Select `Import .JAR/.AAR Package` and click on `Next` ![](images/unity_android_import_aar.png) 8. For `File name:` navigate to the folder where you originally exported the project from Unity and then to the sub-folder named after your app 9. Select the file `wikitude-unity-bridge.aar` under libs and click on `Finish` ![](images/unity_android_path_aar.png) 10. Open the file `build.gradle (Module: YOUR_APP_NAME)` and add the line `compile project(':wikitude-unity-bridge')` under dependencies ![](images/unity_android_gradle.png) 11. The project is now running in Android Studio   "
});

documentTitles["setupguideunity.html#unity-requirements-and-supported-versions"] = "Unity Requirements and supported versions";
index.add({
    url: "setupguideunity.html#unity-requirements-and-supported-versions",
    title: "Unity Requirements and supported versions",
    body: "### Unity Requirements and supported versions  &lt;div class=\&quot;warning\&quot;&gt;  Please note that the Wikitude Unity Plugin currently supports &lt;br /&gt; &lt;ul&gt; &lt;li&gt;&lt;strong&gt;Unity&amp;nbsp; 5.4.5&lt;/strong&gt; or higher&lt;/li&gt; &lt;li&gt;Rendering engines&lt;/li&gt; &lt;ul&gt; &lt;li&gt;OpenGL ES 2&lt;/li&gt; &lt;li&gt;OpenGL ES 3.x&lt;/li&gt; &lt;li&gt;Metal (iOS only)&lt;/li&gt; &lt;/ul&gt;  &lt;li&gt;Because Unity currently doesn't support 64 bit libraries on Android, performance on such devices might be lower than similar devices running iOS 64 bit.&lt;/li&gt; &lt;/ul&gt;  &lt;/div&gt;   "
});



documentTitles["supporteddevicesunity.html#supported-devices"] = "Supported Devices";
index.add({
    url: "supporteddevicesunity.html#supported-devices",
    title: "Supported Devices",
    body: "## Supported Devices  Wikitude SDK is running on devices fulfilling the following requirements:  &lt;table class=\&quot;supported-devices-table\&quot;&gt; 		&lt;tr&gt; 		&lt;th class=\&quot;hide-on-mobile\&quot;&gt;&lt;/th&gt; 		&lt;th&gt;Sensor-based AR (Geo-AR)&lt;/th&gt; 		&lt;th&gt;Image recognition and tracking&lt;/th&gt; 		&lt;th&gt;Instant and Object tracking&lt;/th&gt; 	&lt;/tr&gt; 	&lt;tr class=\&quot;table-mobile-subheader\&quot;&gt;      &lt;td colspan=\&quot;3\&quot;&gt;&lt;h4&gt;Android (Native API)&lt;/h4&gt;&lt;/td&gt; &lt;/tr&gt;  &lt;tr&gt; &lt;td class=\&quot;table-vertical-subheader\&quot;&gt;&lt;h4 class=\&quot;rotate\&quot;&gt;Android (Native API)&lt;/h4&gt;&lt;/td&gt; &lt;td&gt;  &lt;ul&gt;  	&lt;li&gt;not available&lt;/li&gt;  &lt;/ul&gt; &lt;/td&gt; &lt;td&gt;  &lt;ul&gt;  &lt;li&gt;Android 4.4+ (API Level 19+)&lt;/li&gt;   &lt;li&gt;&lt;a href=\&quot;http://developer.android.com/guide/practices/screens_support.html\&quot; target=\&quot;_top\&quot;&gt;High resolution devices (hdpi)&lt;/a&gt;&lt;/li&gt;    &lt;li&gt;Camera&lt;/li&gt;  &lt;li&gt;Devices with a capable CPU (armv7a with NEON support or armv8a) e.g.&lt;/li&gt;  &lt;ul&gt;&lt;li&gt;Samsung Galaxy S3 or newer&lt;/li&gt;  &lt;li&gt;Nexus 4 or newer&lt;/li&gt;  &lt;li&gt;Nexus 10 (2012) or newer&lt;/li&gt; &lt;/ul&gt;  &lt;/ul&gt;  &lt;/td&gt; &lt;td&gt;  &lt;ul&gt;   &lt;li&gt;Android 4.4+ (API Level 19+)&lt;/li&gt;   &lt;li&gt;&lt;a href=\&quot;http://developer.android.com/guide/practices/screens_support.html\&quot; target=\&quot;_top\&quot;&gt;High resolution devices (hdpi)&lt;/a&gt;&lt;/li&gt;   &lt;li&gt;Camera&lt;/li&gt;   &lt;li&gt;Devices with a quad-core CPU (armv7a with NEON support or armv8a) e.g.&lt;/li&gt;   &lt;ul&gt;&lt;li&gt;Samsung Galaxy S3 or newer&lt;/li&gt;    &lt;li&gt;Nexus 4 or newer&lt;/li&gt;    &lt;li&gt;Nexus 7 (2013)&lt;/li&gt;   &lt;/ul&gt;  &lt;/ul&gt;    __Additional for Instant Tracking:__  &lt;ul&gt;   &lt;li&gt;Compass&lt;/li&gt;   &lt;li&gt;Accelerometer&lt;/li&gt;  &lt;/ul&gt;  &lt;/td&gt; &lt;/tr&gt; 	&lt;tr class=\&quot;table-mobile-subheader\&quot;&gt;      &lt;td colspan=\&quot;3\&quot;&gt;&lt;h4&gt;iOS (Native API)&lt;/h4&gt;&lt;/td&gt; &lt;/tr&gt;  &lt;tr&gt; &lt;td class=\&quot;table-vertical-subheader\&quot;&gt;&lt;h4 class=\&quot;rotate\&quot;&gt;iOS (Native API)&lt;/h4&gt;&lt;/td&gt; &lt;td&gt;  &lt;ul&gt;  	&lt;li&gt;not available&lt;/li&gt;  &lt;/ul&gt;  &lt;/td&gt; &lt;td&gt;  &lt;ul&gt;  &lt;li&gt;Devices running iOS 9.0 and up&lt;/li&gt;   &lt;li&gt;Camera&lt;/li&gt;  &lt;li&gt;Devices with a capable CPU (minimum Apple A4 SoC) e.g.&lt;/li&gt;  &lt;ul&gt;&lt;li&gt;iPhone 4 or newer&lt;/li&gt;  &lt;li&gt;iPad2 or newer&lt;/li&gt;  &lt;li&gt;iPod Touch 5th gen&lt;/li&gt;&lt;/ul&gt;  &lt;/ul&gt; &lt;/td&gt; &lt;td&gt;  &lt;ul&gt;  &lt;li&gt;Devices running iOS 9.0 and up&lt;/li&gt;   &lt;li&gt;Camera&lt;/li&gt;  &lt;li&gt;Devices with a capable CPU (minimum Apple A4 SoC) e.g.&lt;/li&gt;  &lt;ul&gt;&lt;li&gt;iPhone 4 or newer&lt;/li&gt;  &lt;li&gt;iPad2 or newer&lt;/li&gt;  &lt;li&gt;iPod Touch 5th gen&lt;/li&gt;&lt;/ul&gt;  &lt;/ul&gt; &lt;/td&gt; &lt;/tr&gt;  				 &lt;/table&gt; "
});



documentTitles["triallicense.html#how-to-obtain-a-free-trial-license"] = "How to obtain a free trial license";
index.add({
    url: "triallicense.html#how-to-obtain-a-free-trial-license",
    title: "How to obtain a free trial license",
    body: "## How to obtain a free trial license  The Wikitude SDK requires a valid license key to be able to run properly. An empty or missing license key will block the augmented reality view from showing any meaningful content. You will see a watermark across the screen with the words `License Key Missing`. All JavaScript API calls will be ignored and not interpreted.  When downloading the Wikitude SDK you will be forwarded to the [license generation page](http://www.wikitude.com/developer/licenses), where a trial license key is automatically generated for you.   ![](images/trial_key_license_page.png)  Copy the key into your app, which will unlock the trial mode of the Wikitude SDK. The trial mode of the Wikitude SDK contains the full feature set of the Wikitude SDK but will show a `Trial` watermark across the screen.  Each trial license key is valid for every application ID on every operating system. You can use the same trial license key in multiple apps.   "
});

documentTitles["triallicense.html#where-should-i-enter-the-license-key"] = "Where should I enter the license key";
index.add({
    url: "triallicense.html#where-should-i-enter-the-license-key",
    title: "Where should I enter the license key",
    body: "## Where should I enter the license key "
});

documentTitles["triallicense.html#unity-plugin"] = "Unity Plugin";
index.add({
    url: "triallicense.html#unity-plugin",
    title: "Unity Plugin",
    body: "### Unity Plugin To use the Wikitude Unity Plugin with a certain license key, paste your license key into the text field of the WikitudeCamera prefab. ![](images/unity_license_key_field.png)   "
});



documentTitles["ios-framework-scripts-native.html#ios-app-store-submissions"] = "iOS App Store submissions";
index.add({
    url: "ios-framework-scripts-native.html#ios-app-store-submissions",
    title: "iOS App Store submissions",
    body: "## iOS App Store submissions "
});

documentTitles["ios-framework-scripts-native.html#removing-simulator-architectures"] = "Removing simulator architectures";
index.add({
    url: "ios-framework-scripts-native.html#removing-simulator-architectures",
    title: "Removing simulator architectures",
    body: "### Removing simulator architectures To work around an Xcode &lt;a href='http://www.openradar.me/radar?id=6409498411401216' target='_blank'&gt;App Store submission bug&lt;/a&gt;, the WikitudeNativeSDK.framework contains a shell script that removes the simulator architectures from the .framework. This script can either be run from the `Terminal` application or a `Run Script Phase` in Xcode.  Here is a snippet for the `Terminal` application. Note that the path to the script and the path to the WikitudeNativeSDK.framework needs to be known.  ```sh sh *PATH/TO/THE/WIKITUDE/SDK/PACKAGE*/Tools/Scripts/strip_wikitude_framework.sh -s -p *PATH/TO/THE/WikitudeNativeSDK.framework ```  To run this script in a `Run Script Phase`, simply copy the following snippet into a new `Run Script Phase` text field. Please make sure that the `Run Script Phase` is positioned right after the `Embed Frameworks` build phase (You can reorder individual build phases).  ```sh sh \&quot;${BUILT_PRODUCTS_DIR}/${FRAMEWORKS_FOLDER_PATH}/WikitudeNativeSDK.framework/strip_wikitude_framework.sh\&quot; -s -p \&quot;${BUILT_PRODUCTS_DIR}/${FRAMEWORKS_FOLDER_PATH}/WikitudeNativeSDK.framework\&quot; ```  ![ ](images/ios_setup_6__run_script_text_field.png)  "
});

documentTitles["ios-framework-scripts-native.html#bitcode"] = "Bitcode";
index.add({
    url: "ios-framework-scripts-native.html#bitcode",
    title: "Bitcode",
    body: "### Bitcode The WikitudeNativeSDK.framework contains `Bitcode` information to support &lt;a href=\&quot;https://developer.apple.com/library/content/documentation/IDEs/Conceptual/AppDistributionGuide/AppThinning/AppThinning.html\&quot; target=\&quot;_blank\&quot;&gt;App Thinning&lt;/a&gt;. Building a .framework with bitcode enabled leads to a larger file size. In case the application that uses the WikitudeNativeSDK.framework does not support bitcode and file size is a problem, bitcode information can be removed using the `wikitude_bitcode.sh` shell script. This script can either be run from the `Terminal` application or a `Run Script Phase` in Xcode. Wikitude recommends to use the `Terminal` application to not unnecessarily increase build time.  Here is a snippet for the `Terminal` application. Note that the path to the script and the path to the WikitudeNativeSDK.framework needs to be known.  ```sh sh *PATH/TO/THE/WIKITUDE/SDK/PACKAGE*/Tools/Scripts/wikitude_bitcode.sh -s -p *PATH/TO/THE/WikitudeNativeSDK.framework ```  Here is a snippet for the `Run Script Phase`. Simply copy this snippet into the script phase text field:  ```sh sh \&quot;${BUILT_PRODUCTS_DIR}/${FRAMEWORKS_FOLDER_PATH}/WikitudeNativeSDK.framework/wikitude_bitcode.sh\&quot; -s -p \&quot;${BUILT_PRODUCTS_DIR}/${FRAMEWORKS_FOLDER_PATH}/WikitudeNativeSDK.framework\&quot; ``` "
});



documentTitles["sampleunity.html#examples-tutorials"] = "Examples &amp; Tutorials";
index.add({
    url: "sampleunity.html#examples-tutorials",
    title: "Examples &amp; Tutorials",
    body: "## Examples &amp; Tutorials  The Wikitude Unity example project gives you a quick overview of the capabilities offered by the Wikitude Native SDK in combination with Unity. You can find the project in the Wikitude Unity download package. Once the .zip file is extracted, the project is located in the `/Examples` folder. In the `Assets/Wikitude/Samples/Scenes` folder you will find scenes focused on specific parts of the SDK. The examples are also included in the Unity package located in the `/Package` folder.  "
});

documentTitles["sampleunity.html#structure"] = "Structure";
index.add({
    url: "sampleunity.html#structure",
    title: "Structure",
    body: "### Structure  Each example focuses on a part of the SDK specified by its name. Each example follows a similar structure. They all include the `WikitudeCamera` prefab, a `UI` root GameObject and a `Controller` GameObject with a corresponding script used to provide the custom behaviour for each sample. Most samples also include an `ImageTracker`, `CloudTracker`, `ObjectTracker` or `InstantTracker` prefab, while some create them it during runtime.  "
});

documentTitles["sampleunity.html#usage"] = "Usage";
index.add({
    url: "sampleunity.html#usage",
    title: "Usage",
    body: "### Usage  To run the application, open the Unity scene called `Main Menu` which is located in the `Assets/Scenes` folder. Once the project is loaded, it needs to be exported as either Xcode project (iOS) or Android Studio project (Android). Alternatively, you can build an Android .apk directly.  Please see the [Setup Guide](setupguideunity.html) page for more info on the build steps required for each platform. "
});



documentTitles["targetimages.html#target-images"] = "Target Images";
index.add({
    url: "targetimages.html#target-images",
    title: "Target Images",
    body: "## Target Images  "
});

documentTitles["targetimages.html#image-recognition-samples"] = "Image recognition samples";
index.add({
    url: "targetimages.html#image-recognition-samples",
    title: "Image recognition samples",
    body: "### Image recognition samples   &lt;a href='images/wikitude_sample_app_target_images.zip'&gt;Click here to download all target images&lt;/a&gt;  &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/magazine_page_one.jpeg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group1\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='imagerecognitionnative.html'&gt;Image Recognition&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/magazine_page_two.jpeg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group1\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='imagerecognitionnative.html'&gt;Image Recognition&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/target_face.jpeg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group1\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='advancedimagerecognitionnative.html'&gt;Image Recognition&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/iot_target.jpg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group1\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='imagerecognitionnative.html'&gt;Client Extended Recognition&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/multiple-targets.jpg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group1\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='imagerecognitionnative.html'&gt;Multiple Targets&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/schloss_johannisberg.jpg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group1\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='cloudrecognitionnative.html'&gt;Cloud Recognition&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/brazil.jpg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group1\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='cloudrecognitionnative.html'&gt;Cloud Recognition&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/barone.jpg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group1\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='cloudrecognitionnative.html'&gt;Cloud Recognition&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/etiquette_ermitage.jpg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group1\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='cloudrecognitionnative.html'&gt;Cloud Recognition&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/gw_bf2011.jpg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group1\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='cloudrecognitionnative.html'&gt;Cloud Recognition&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/barcode_wikitude.png\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group2\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='pluginsapi.html'&gt;Plugins API barcode reader&lt;/a&gt;\&quot;&gt; &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/hello_wikitude_qr.png\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group2\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='pluginsapi.html'&gt;Plugins API QR reader&lt;/a&gt;\&quot;&gt;  "
});

documentTitles["targetimages.html#object-recognition-samples"] = "Object recognition samples";
index.add({
    url: "targetimages.html#object-recognition-samples",
    title: "Object recognition samples",
    body: "### Object recognition samples  &lt;img class=\&quot;jslghtbx-thmb\&quot; src=\&quot;images/firetruck.jpg\&quot; data-jslghtbx data-jslghtbx-group=\&quot;group2\&quot; data-jslghtbx-caption=\&quot;Sample: &lt;a href='objecttrackingnative.html'&gt;Object recognition&lt;/a&gt;&amp;nbsp;&lt;a href='http://www.wikitude.com/external/doc/samples/fire_truck/' target='_blank'&gt;360° view of the truck&lt;/a&gt;\&quot;&gt; &lt;br /&gt; &lt;a href='http://www.wikitude.com/external/doc/samples/fire_truck/' target='_blank'&gt;360° view of the truck&lt;/a&gt;"
});



documentTitles["imagerecognitionnative.html#image-recognition"] = "Image Recognition";
index.add({
    url: "imagerecognitionnative.html#image-recognition",
    title: "Image Recognition",
    body: "# Image Recognition  This example shows how to recognize images in the viewfinder and overlay it with images.   For a better understanding, here are some terms that will be used in the following and other section of this documentation related to vision-based augmented reality.  - **Target**: A 2D target image and its associated extracted data that is used by the tracker to recognize an image.  - **Target Collection**: An archive storing a collection of 2D targets that can be recognized by the tracker. A target collection can hold up to 1000 targets. Target collections are stored as `.wtc` files  - **ImageTracker**: The tracker analyzes the live camera image and detects the 2D targets stored in its associated target collection. Multiple trackers can be created, however only one tracker can be active for recognition at any given time.  &lt;a id=\&quot;SimpleImageRecognitionUnity\&quot;&gt;&lt;/a&gt; "
});

documentTitles["imagerecognitionnative.html#simple-image-recognition-in-unity"] = "Simple Image Recognition in Unity";
index.add({
    url: "imagerecognitionnative.html#simple-image-recognition-in-unity",
    title: "Simple Image Recognition in Unity",
    body: "## Simple Image Recognition in Unity  The Wikitude Unity Plugin is based on pre-configured prefabs. There are two types of prefabs available. One is the `WikitudeCamera` prefab and the other ones are tracker prefabs.  "
});

documentTitles["imagerecognitionnative.html#wikitudecamera-prefab"] = "WikitudeCamera Prefab";
index.add({
    url: "imagerecognitionnative.html#wikitudecamera-prefab",
    title: "WikitudeCamera Prefab",
    body: "### WikitudeCamera Prefab The `WikitudeCamera` prefab takes care about rendering the live camera stream fullscreen behind all your augmentations. Attached to this prefab is a script component which has one parameter that is not pre filled. This parameter is for the Wikitude SDK license key and has to be filled with your very own license key. You can either buy a commercial license from our webpage or [download a free trial license key](triallicense.html) and play around with our Native SDK in combination with Unity.    "
});

documentTitles["imagerecognitionnative.html#imagetracker-prefab"] = "ImageTracker Prefab";
index.add({
    url: "imagerecognitionnative.html#imagetracker-prefab",
    title: "ImageTracker Prefab",
    body: "### ImageTracker Prefab To add a tracker prefab to the scene, simply drag the `ImageTracker` prefab into the scene hierarchy.  An `ImageTracker` itself needs a Wikitude Target Collection (.wtc file) which contains information needed to detect those reference images. Target collections can be generated and downloaded from the &lt;a href=\&quot;https://targetmanager.wikitude.com\&quot; target=\&quot;_top\&quot;&gt;Wikitude Target Manager&lt;/a&gt; - a free web based tool, that you can access with your developer account. You can also generate .wtc files right inside Unity with the [WTC Editor](unitywtceditor.html). Place the .wtc file into the `StreamingAssets` folder, so that the Wikitude Native SDK can load them at runtime. To specify which .wtc file should be used, select the `ImageTracker` game object in the scene. Make sure that the `Target Source` is set to `Target Collection Resource` and using the dropdown next to `Target Collection` you can choose the desired one.  To react on events like successfully loading of a .wtc file, you can use the Unity Events listed in in the inspector of the `ImageTracker`. These events are split into two groups. The first group contains events triggered by the `TargetCollectionResource` when the wtc file was loaded of if there was an error. The second group are events triggered by the `ImageTracker` itself if it was successfully initialized with the desired .wtc file or not. On the desired event, click the plus sign to add a new subscriber, drag the GameObject that should receive the event over the `None (Object)` field and select the function you want to be called from the `No Function` dropdown.   When subscribing to events that have a single basic parameter type, make sure to select your function from top list marked with `Dynamic`, rather than the static version from the bottom. This ensures that the parameters are passed correctly from the Wikitude plugin and are not overwritten by Unity.  ![Setting callbacks](images/select_callback.png)  For more information on working with Unity Events, please check the &lt;a href=\&quot;http://docs.unity3d.com/Manual/UnityEvents.html\&quot; target=\&quot;_top\&quot;&gt;Unity Manual&lt;/a&gt;  and &lt;a href=\&quot;https://unity3d.com/learn/tutorials/modules/intermediate/live-training-archive/events-creating-simple-messaging-system\&quot; target=\&quot;_top\&quot;&gt;Events Tutorial&lt;/a&gt;.  "
});

documentTitles["imagerecognitionnative.html#define-custom-augmentations"] = "Define custom augmentations";
index.add({
    url: "imagerecognitionnative.html#define-custom-augmentations",
    title: "Define custom augmentations",
    body: "### Define custom augmentations Also part of the `ImageTracker` prefab is an `ImageTrackable` object. A trackable defines which targets from your collection you want to be tracked. If the tracker is using a .wtc file located in the `StreamingAssets` folder, the `ImageTrackable` inspector will show a list of all the targets in the .wtc file. By toggling the `Active` button, you can select which targets will be tracked by this trackable, or you can choose `Select All` at the top to include all the targets. You can similarly choose which targets should use extended tracking.  &lt;img style=\&quot;width: 350px\&quot; src=\&quot;images/unity_trackable_interface.png\&quot;&gt;  By pressing the `Preview` button, the target will be displayed in the 3D view of the scene, providing a convenient way to place your augmentation relative to the target.  &lt;img style=\&quot;width: 350px\&quot; src=\&quot;images/unity_trackable_target_preview.png\&quot;&gt;  If the .wtc file is located somewhere else, for example if you are downloading it at runtime, or when using `CloudRecognitionService` instead, you can still select which targets will be included by entering the target name into the `TargetPattern` text field. Possible values are full target image names (e.g. `pageOne`, `pageTwo`) or wildcards (`page*`). You can use `*` if you want to include all targets.  &lt;div class=\&quot;warning\&quot;&gt;  If the .wtc file you are using is not located in the StreamingAssets folder, kindly make sure that the `targetName` used with the `ImageTrackable` component correspond to one of the target names in your target collection. You can also use wildcards to match any target or only a specific subset of targets. &lt;/div&gt;  In order to place 3D objects at the location where the reference image was found in the camera stream, add any GameObject as a child to the `ImageTrackable` object. During runtime, only the transform of the camera will be changed, so you can place and scale the `ImageTrackable` GameObject and its children however it is most convenient for you. Keep in mind that if you move the `ImageTrackable` GameObject during runtime, the camera will follow it, so you won't see any effective changes. If you need to move augmentations relative to the camera, for example when dragging augmentations based on user input, please make sure not to move `Trackable` GameObject, but its children.  The `Auto Toggle Visibility` toggle is enabled by default. When this is checked, the `ImageTrackable` GameObject will be automatically disabled when the target is out of view and enabled back when a target is tracked again.  To handle visibility manually, you can turn this toggle off and subscribe to the `OnImageRecognized` and `OnImageLost` events on the trackable. This can be useful when you want to show different augmentations based on which target was tracked. The string parameter of these events will indicate which target was tracked or lost.  The `OnImageRecognized` and `OnImageLost` events are called even when the `Auto Toggle Visibility` toggle is turned on. As an example, the `Image Recognition - Extended Tracking` updates the UI when the target is lost by handling `OnImageLost`.  &lt;a id=\&quot;MultipleTargetsUnity\&quot;&gt;&lt;/a&gt; "
});

documentTitles["imagerecognitionnative.html#multiple-targets"] = "Multiple Targets";
index.add({
    url: "imagerecognitionnative.html#multiple-targets",
    title: "Multiple Targets",
    body: "## Multiple Targets An image tracker can track multiple targets at the same time. This can be configured in the `ImageTracker` inspector, by setting the `Concurrent Targets` to a value larger than 1. However, keep in mind that if you don't plan to use multiple targets, it is best to leave the value at 1 for optimal performance.  To define augmentations for multiple targets, you will need to set a prefab to the `Drawable` field in the `ImageTrackable` inspector. At runtime, when a new target is recognized the `Drawable` prefab will be instantiated and placed in the scene as a child of the `Trackable` and when the target is lost, it will be destroyed. When multiple targets are being tracked, their corresponding `Drawables` are positioned in the game world to match what the camera sees. This also means that you can infer the relative positions between targets directly in the game world.  This behaviour was designed to allow easy setup for simple use cases, but if you may need more control over the lifetime of the augmentations. If that is the case, you can leave the `Drawable` field empty in the `ImageTrackable` inspector and add callbacks to the `OnImageRecognized` and `OnImageLost` events. When `OnImageRecognized` is called, the `ImageTarget` that is passed as a parameter will contain a `Drawable` GameObject property. This empty GameObject behaves the same way as the `Drawable` described above and you should use it as a parent for your augmentations, to make sure they are positioned properly.  ```csharp public void OnImageRecognized(ImageTarget recognizedTarget) { 	// Create the custom augmentation. 	// You can use recognizedTarget.Name and recognizedTarget.ID  	// if you need custom augmentations for each target and instance. 	GameObject newAugmentation = GameObject.CreatePrimitive(PrimitiveType.Sphere);  	// Set the newAugmentation to be a child of the Drawable. 	newAugmentation.transform.parent = recognizedTarget.Drawable.transform;  	// Position the augmentation relative to the Drawable by using the localPosition. 	newAugmentation.transform.localPosition = Vector3.zero; } ```  Keep in mind that the `Drawable` is still destroyed when the target is lost, so if you still have the augmentations attached to it, they will be destroyed as well. The `OnImageLost` event is called before the `Drawable` is destroyed, so you can use that event to move the augmentations somewhere else if they need to persist after the target was lost.  In case the same target is detected multiple times simultaneously, the ID property in the `ImageTarget` parameter will help you distinguish between them.   &lt;a id=\&quot;ExtendedImageTrackingUnity\&quot;&gt;&lt;/a&gt; "
});

documentTitles["imagerecognitionnative.html#extended-tracking"] = "Extended Tracking";
index.add({
    url: "imagerecognitionnative.html#extended-tracking",
    title: "Extended Tracking",
    body: "## Extended Tracking Extended tracking is an optional mode you can set for each target separately. In this mode the Wikitude SDK will continue to scan the environment even if the original target image is not in view anymore. So the tracking extends beyond the limits of the original target image. The performance of this feature depends on various factors like computing power of the device, background texture and objects.  If the .wtc file containing the targets is located in the `StreamingAssets` folder, you should be able to see a list of all the targets in the inspector of the `Image Trackable`. To enable extended tracking, simply tick the `Extended tracking` option next to each target you want to extend, or select `Extend All` at the top of the list to extend all the targets. If the .wtc file is loaded at runtime from a custom location, the `Image Trackable` will have a simpler interface, that will allow you to enable extended tracking manually and specify the names of the targets you would want to be extended. You can set the first name in the list to the wildcard `*` to extend all targets in the collection.  When Extended Tracking is enabled, the `ImageTracker` will fire `OnExtendedTrackingQualityChangedEvents`, which will let you know how well extended tracking is working based on the factors mentioned above.  &lt;a id=\&quot;RuntimeTrackerUnity\&quot;&gt;&lt;/a&gt; "
});

documentTitles["imagerecognitionnative.html#runtime-tracker"] = "Runtime Tracker";
index.add({
    url: "imagerecognitionnative.html#runtime-tracker",
    title: "Runtime Tracker",
    body: "## Runtime Tracker Image trackers can be created at runtime with no restrictions on the location of the target collection used. To do this, simply create a new GameObject and add the `ImageTracker` component to it, select `TargetCollectionResource` as the `TargetSourceType` and create a new `TargetCollectionResource` object. If you are using a collection located in the `StreamingAssets` folder, the `TargetPath` property should be the path relative to the `StreamingAssets` folder and `UseCustomUrl` property should be false.    If you want to use a collection located elsewhere on the device or on the web, the `TargetPath` property should be set to the absolute path to the target, prefixed by the protocol `file://`, `http://` or `https://` as appropriate. The `UseCustomUrl` in this case should be set to true. Please see the sample `Client Tracker - Runtime Tracker` as an example of how to set this up.  Trackables can also be created at runtime, but make sure to add them as a child of the tracker before the `Start()` method is called on the parent tracker, otherwise it won't get registered in time. ```csharp GameObject trackerObject = new GameObject(\&quot;ImageTracker\&quot;); ImageTracker imageTracker = trackerObject.AddComponent&lt;ImageTracker&gt;();  imageTracker.TargetSourceType = TargetSourceType.TargetCollectionResource; imageTracker.TargetCollectionResource = new TargetCollectionResource(); imageTracker.TargetCollectionResource.UseCustomURL = true; imageTracker.TargetCollectionResource.TargetPath = \&quot;https://url.to.your.collection/collection.wtc\&quot;;  GameObject trackableObject = GameObject.Instantiate(TrackablePrefab); trackableObject.transform.SetParent(imageTracker.transform, false); ``` Creating trackers at runtime is also possible when using the `CloudRecognitionService` instead of a `TargetCollectionResource`  &lt;a id=\&quot;MultipleTrackersUnity\&quot;&gt;&lt;/a&gt; "
});

documentTitles["imagerecognitionnative.html#multiple-trackers"] = "Multiple Trackers";
index.add({
    url: "imagerecognitionnative.html#multiple-trackers",
    title: "Multiple Trackers",
    body: "## Multiple Trackers You can have multiple trackers in the same scene, but only one can be active at a time. If you enable a second one, the first one will be automatically disabled by the plugin.  "
});



documentTitles["instanttrackingnative.html#instant-tracking"] = "Instant Tracking";
index.add({
    url: "instanttrackingnative.html#instant-tracking",
    title: "Instant Tracking",
    body: "# Instant Tracking  The following sections detail the instant tracking feature of the Wikitude Native SDK by introducing a minimal implementation, showcasing the simplicity the Wikitude Native SDK provides.  "
});

documentTitles["instanttrackingnative.html#smart-seamless-ar-tracking"] = "SMART - Seamless AR Tracking";
index.add({
    url: "instanttrackingnative.html#smart-seamless-ar-tracking",
    title: "SMART - Seamless AR Tracking",
    body: "## SMART - Seamless AR Tracking  SMART is a seamless API which integrates ARKit, ARCore and Wikitude’s SLAM in a single augmented reality SDK, cross-platform, for any device. It ensures the delivery of the best possible augmented reality experience on a wider range of devices, covering 92,6% of iOS devices and about 35% of Android devices available in the market.   SMART is enabled by default but can be disabled by unchecking the `SMART Enabled` checkbox located at the top of the `Instant Tracker` inspector. Alternatively, it can be disabled in code using the `SMARTEnabled` property on the `InstantTracker`. Please keep in mind that this needs to happen before the `InstantTracker` initializes its native counterpart, which happens during the `OnEnable` method.  ```csharp public InstantTracker tracker;  void Awake() {     tracker.SMARTEnabled = false; } ```  To check if the device supports platform assistance for tracking, `WikitudeSDK.IsPlatformAssistedTrackingSupported` can be called. Please keep in mind that this needs to be called after the `Start` method of the `WikitudeCamera` was executed, to make sure that the native components are properly initialized.  ```csharp if (WikitudeCamera.IsPlatformAssistedTrackingSupported) {     // Device offers platform tracking capabilities (ARKit or ARCore) } ```  SMART provides improved tracking capabilities at the expense of control. Because of that some Wikitude SDK features are not available when platform tracking capabilities are used by enabling SMART.  | Features 				| SMART ON and &lt;br&gt; platform assisted tracking supported	| SMART OFF | | ---------------------	|:----------:	|:---------:| | Improved Tracking		| ✓				|	x        | | Plane Orientation		| x				|	✓        | | Camera Control    	| x				|	✓        |   &lt;a id=\&quot;introduction\&quot;&gt;&lt;/a&gt; "
});

documentTitles["instanttrackingnative.html#introduction"] = "Introduction";
index.add({
    url: "instanttrackingnative.html#introduction",
    title: "Introduction",
    body: "## Introduction   Instant tracking is an algorithm that, contrary to those previously introduced in the Wikitude SDK, does not aim to recognize a predefined target and start the tracking procedure thereafter, but immediately start tracking in an arbitrary environment. This enables very specific use cases to be implemented.  The algorithm works in two distinct states; the first of which is the initialization state. In this state the user is required to define the origin of the tracking procedure by simply pointing the device and thereby aligning an indicator. Once the alignment is found to be satisfactory by the user (which the users needs to actively confirm), a transition to the tracking state is performed. In this state, the environment is being tracked, which allows for augmentations to be placed within the scene.   The instant tracking algorithm requires another input value to be provided in the initialization state. Specifically, the height of the tracking device above ground is required in order to accurately adjust the scale of augmentations within the scene. To this end, the example features a range input element that allows the height to be set in meters.  During the initialization, another parameter can be set which influences the alignment of the instant tracking ground plane. This ground plane is represented by the initialization indicator and can be rotated in order to start instant tracking at e.g. a wall instead of the floor.   &lt;a id=\&quot;basicinstanttracking\&quot;&gt;&lt;/a&gt; "
});

documentTitles["instanttrackingnative.html#basic-instant-tracking"] = "Basic Instant Tracking";
index.add({
    url: "instanttrackingnative.html#basic-instant-tracking",
    title: "Basic Instant Tracking",
    body: "## Basic Instant Tracking  The *Instant Tracking* example provides a simple implementation of an application that allows users to place furniture in their environment.  "
});

documentTitles["instanttrackingnative.html#scene-setup"] = "Scene Setup";
index.add({
    url: "instanttrackingnative.html#scene-setup",
    title: "Scene Setup",
    body: "#### Scene Setup  The scene consists mainly of the following parts: * `WikitudeCamera`: the standard prefab for the `WikitudeCamera` is used, with the exception that it is running in SD at 30 FPS. This is the recommended setup for `Instant Tracking`, as the algorithm is computationally intense and users might experience slowdowns on older devices. * `UI`: the root of the `UI` we will be using in this sample. Since `Instant Tracking` works in two distinct phases, the `UI` is also split in two, allowing to completely switch the interface. When the `Instant Tracker` is in `Initializing` mode, the `UI` only displays a slider to control the height, as explained previously and a button to switch to `Tracking` mode. After the switch is done, the `UI` will display a button for each furniture model that can be added to the scene. Each button has an `OnBeginDrag` event trigger on it that notifies the controller when a new furniture model needs to be added to the scene. The event trigger also has an `int` parameter, specifying which model should be created. * `Controller`: container for multiple custom script components:     * `InstantTrackerController`: coordinates the activity between the `Instant Tracker`, the `UI`, the augmentations and the touch input.     * `Gesture Controllers`: react to touch input events and move or scale the augmentations accordingly.     * `Grid Renderer`: renders a grid with 25 cm spacing that can be helpful during initialization and tracking * `Ground`: a simple transparent plane with a custom shader that enables shadows on it. The plane also has a collider on it and can be used for physics interaction. * `Instant Tracker`: the component that actually does all the tracking.  ![Instant Tracker scene](images/unity_instant_tracker_scene.png)  "
});

documentTitles["instanttrackingnative.html#instant-tracker-controller"] = "Instant Tracker Controller";
index.add({
    url: "instanttrackingnative.html#instant-tracker-controller",
    title: "Instant Tracker Controller",
    body: "#### Instant Tracker Controller The controller script coordinates all the other components of the scene. It contains references to all the UI elements and responds to events from them.   In the `Awake` function, the `Application.targetFrameRate` is set to 60. Even though the camera and tracking is running only at 30 FPS, having Unity running at a higher FPS allows for smoother user interaction.  When a drag is detected and the `OnBeginDrag` callback is called, we create a new model based on the index we receive and place it at the touch position, facing the camera.  ```csharp // Select the correct prefab based on the modelIndex passed by the Event Trigger. GameObject modelPrefab = Models[modelIndex]; // Instantiate that prefab into the scene and add it in our list of visible models. Transform model = Instantiate(modelPrefab).transform; _activeModels.Add(model.gameObject); // Set model position by casting a ray from the touch position and finding where it intersects with the ground plane var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); Plane p = new Plane(Vector3.up, Vector3.zero); float enter; if (p.Raycast(cameraRay, out enter)) {     model.position = cameraRay.GetPoint(enter); }  // Set model orientation to face toward the camera Quaternion modelRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(-Camera.main.transform.forward, Vector3.up), Vector3.up); model.rotation = modelRotation; ```  When the tracker loses the scene, which can happen when moving the device too fast, we make sure that all the models and the grid are hidden. Because the camera is not moved anymore when tracking is lost, the augmentations would appear to be frozen on the screen if they were not hidden. We also need to disable the furniture buttons, to prevent users from adding new objects.   While the SDK doesn't currently work in Edit Mode, you can still test the demo in the Editor by using &lt;a href=\&quot;https://docs.unity3d.com/Manual/UnityRemote5.html\&quot; target=\&quot;_top\&quot;&gt;Unity Remote&lt;/a&gt;. The SDK will also send most of the callbacks you expect in Edit Mode as well, allowing you to prototype gesture interaction without constantly building on a device.  ![Instant Tracker sample running on a device](images/unity_instant_tracker_sample.png)   &lt;a id=\&quot;instantscenepicking\&quot;&gt;&lt;/a&gt; "
});

documentTitles["instanttrackingnative.html#instant-scene-picking"] = "Instant Scene Picking";
index.add({
    url: "instanttrackingnative.html#instant-scene-picking",
    title: "Instant Scene Picking",
    body: "## Instant Scene Picking   The *Scene Picking* example how you can convert a touch position to a 3D position that maps to the environment. When using this API, users could for example place objects not only on the ground plane, but also on top of real world objects.  "
});

documentTitles["instanttrackingnative.html#scene-setup"] = "Scene Setup";
index.add({
    url: "instanttrackingnative.html#scene-setup",
    title: "Scene Setup",
    body: "#### Scene Setup  The scene structure is similar to the one described in the *Instant Tracking* example, but has been simplified a bit. Specifically, the UI doesn't contain any furniture related controls, and there are no Gesture Controllers anymore.  "
});

documentTitles["instanttrackingnative.html#scene-picking-controller"] = "Scene Picking Controller";
index.add({
    url: "instanttrackingnative.html#scene-picking-controller",
    title: "Scene Picking Controller",
    body: "#### Scene Picking Controller  The controller script is also much simpler than that of the *Instant Tracking* example. Its main concerns are listening for touch inputs, converting those inputs to 3D coordinates and placing an augmentation there. It is also responsible for the managing the state of the `InstantTracker`.  To convert input touch positions to 3D coordinates, the script calls the `ConvertScreenCoordinate` method on the `InstantTracker`, passing it the touch position as Unity provides it.  ```csharp void Update() { 	if (_isTracking &amp;&amp; Input.GetMouseButtonUp(0)) { 		Tracker.ConvertScreenCoordinate(Input.mousePosition); 	} } ``` Because the conversion can take a long time, it is done on a separate thread and a callback event is provided in the `InstantTracker` to let you know when the results are available. The example script registers to this event in the `Awake` method.  ```csharp void Awake() { 	Tracker.OnScreenConversionComputed.AddListener(OnScreenConversionComputed); } ```  Finally, when the conversion was computed, it adds the augmentation to the specified location. It firsts needs to check if the conversion was successful, as it can fail if there is not enough information in the point cloud where the touch event happened. It adds the augmentation as a child of the _trackable, because the coordinates are in the local space of the `InstantTrackable`.  ```csharp public void OnScreenConversionComputed(bool success, Vector2 screenCoordinate, Vector3 pointCloudCoordinate) { 	if (success) { 		var newAugmentation = GameObject.Instantiate(Augmentation, _trackable.transform) as GameObject; 		// The pointCloudCoordinate values are in the local space of the trackable. 		newAugmentation.transform.localPosition = pointCloudCoordinate; 		_augmentations.Add(newAugmentation); 	} } ```  "
});



documentTitles["objecttrackingnative.html#object-tracking"] = "Object Tracking";
index.add({
    url: "objecttrackingnative.html#object-tracking",
    title: "Object Tracking",
    body: "# Object Tracking "
});

documentTitles["objecttrackingnative.html#introduction-to-object-tracking"] = "Introduction to Object Tracking";
index.add({
    url: "objecttrackingnative.html#introduction-to-object-tracking",
    title: "Introduction to Object Tracking",
    body: "## Introduction to Object Tracking  Object Recognition and Tracking extends the capabilities of the Wikitude SDK to recognize and track arbitrary objects for augmented reality experiences. The feature is based on Wikitude's SLAM engine that is also used for Instant Tracking.  Object Tracking let you detect objects, that were pre-defined by you. Suitable objects include * Toys * Monuments and statues * Industrial objects * Tools * Household supplies  Objects can be best successfully recongnized if they don't consist of many dynamic parts.  &lt;a id=\&quot;ObjectTrackingUnity\&quot;&gt;&lt;/a&gt; "
});

documentTitles["objecttrackingnative.html#object-tracking-in-unity"] = "Object Tracking in Unity";
index.add({
    url: "objecttrackingnative.html#object-tracking-in-unity",
    title: "Object Tracking in Unity",
    body: "## Object Tracking in Unity  Before proceeding with the Object Tracking sample, please make sure you are familiar with how Image Tracking works first by reading about the [Image Tracking](imagerecognitionnative.html) samples. Most concepts described there work in a similar way for Object Tracking.  "
});

documentTitles["objecttrackingnative.html#objecttracker-prefab"] = "ObjectTracker Prefab";
index.add({
    url: "objecttrackingnative.html#objecttracker-prefab",
    title: "ObjectTracker Prefab",
    body: "### ObjectTracker Prefab To add a tracker prefab to the scene, simply drag the `ObjectTracker` prefab into the scene hierarchy.  An `ObjectTracker` itself needs a Wikitude Object Collection (.wto file) which contains information needed to detect the reference objects. Target collections can be generated and downloaded from the &lt;a href=\&quot;https://targetmanager.wikitude.com\&quot; target=\&quot;_top\&quot;&gt;Wikitude Target Manager&lt;/a&gt; - a free web based tool, that you can access with your developer account. You can use the .wto file in the same way as .wtc files are used for the `ImageTracker`.  Recognition events also work exactly like recognition events for the `ImageTracker`.  "
});

documentTitles["objecttrackingnative.html#define-custom-augmentations"] = "Define custom augmentations";
index.add({
    url: "objecttrackingnative.html#define-custom-augmentations",
    title: "Define custom augmentations",
    body: "### Define custom augmentations Because an `ObjectTracker` can only recognize and track a single object at a time, you can define augmentations either by defining a `Drawable` prefab in the `ObjectTrackable`, or by placing them directly as child objects to the trackable and enabling `Auto Toggle Visibility`.  In the `Object Tracking - Object Tracking` scene, the `Drawable` prefab workflow is illustrated. A `FiretruckAugmentation` prefab was created in the `SamplePrefabs` folder and assigned to the `ObjectTrackable`. The transform of the prefab has been modified so that the augmentations will match the real object during tracking.   Within the `FiretruckAugmentation` prefab you will also find the `FiretruckOccluder` GameObject which contains two meshes that are used as occluders. You can read more about occluders and how they work in Unity [here](occludersunity.html).  "
});



documentTitles["gettingstartedcloudrecognition.html#cloud-recognition"] = "Cloud Recognition";
index.add({
    url: "gettingstartedcloudrecognition.html#cloud-recognition",
    title: "Cloud Recognition",
    body: "# Cloud Recognition  &lt;p class='intro' markdown='1'&gt;The Wikitude Cloud Recognition service is a cloud-based service provided by Wikitude, which recognizes images sent from Android and iOS apps using the Wikitude SDK. The recognized images are then tracked in the live camera feed and can be used for augmented reality experiences.&lt;/p&gt;  This documentation focuses on the RESTful API called Manager API, which is used to interact on a backend level with the Cloud Recognition service.   "
});

documentTitles["gettingstartedcloudrecognition.html#general-definitions"] = "General Definitions";
index.add({
    url: "gettingstartedcloudrecognition.html#general-definitions",
    title: "General Definitions",
    body: "## General Definitions  - **Target**: An image and its associated extracted data that is used to recognize an image.  - **Target Collection**: A group of `targets` that are searched together. Think of it as a directory, which contains all your images you want to search. The Wikitude SDK can work with two different sorts of `TargetCollections` 	+ On-device Target Collection: a static `wtc` file containing the extracted data of your images. Can consist of up to 1,000 images. 	+ Cloud Target Collection: A target collection stored on the Wikitude server. See `Cloud Archive` below.   - **Cloud Archive**: An archive stored on the server that is optimized for cloud-based recognition. It is generated from a `TargetCollection` and is used in combination with the Wikitude SDK [`AR.CloudRecognitionService`](architectapi://reference/classes/CloudRecognitionService.html).  - **ImageTracker**: Instead of analysing and computing the live camera feed directly on the device like the combination of [`AR.ImageTracker`](architectapi://reference/classes/ImageTracker.html) and [`AR.TargetCollectionResource`](architectapi://reference/classes/TargetCollectionResource.html), the combination of [`AR.ImageTracker`](architectapi://reference/classes/ImageTracker.html) and [`AR.CloudRecognitionService`](architectapi://reference/classes/CloudRecognitionService.html) will send the image(s) taken by the camera to the Wikitude Cloud Recognition server. The server will then do the hard work of trying to match the image with your targets in the specified cloud archive. Beside the benefit of searching in large image database using the [`AR.CloudRecognitionService`](architectapi://reference/classes/CloudRecognitionService.html) instead of [`AR.TargetCollectionResource`](architectapi://reference/classes/TargetCollectionResource.html) has also a positive impact on the general performance in most cases. Especially when using a large target collection and on older devices.   - **Manager API**: A RESTful web API allowing developers to interact with the Cloud Recognition server for managing `Targets`, `TargetCollections` and `Cloud Archives`. Only you as a developer uses this API. None of your users of your app will interact with this API.  - **Client API**: The Client API is the interface between the Wikitude SDK and the Cloud Recognition Service. The API itself is encapsulated in the Wikitude SDK class [`AR.CloudRecognitionService`](architectapi://reference/classes/CloudRecognitionService.html) and not directly accessible. Calls on the client API are called `Scans`.  - **Region**: Wikitude is providing several hosting locations for its Cloud Recognition services to cut down unwanted network latency. As a developer you need to choose on which `Region` you and your customers want to operate.   "
});

documentTitles["gettingstartedcloudrecognition.html#getting-started-with-the-cloud-recognition-service"] = "Getting Started with the Cloud Recognition Service";
index.add({
    url: "gettingstartedcloudrecognition.html#getting-started-with-the-cloud-recognition-service",
    title: "Getting Started with the Cloud Recognition Service",
    body: "## Getting Started with the Cloud Recognition Service  "
});

documentTitles["gettingstartedcloudrecognition.html#regional-availability-of-wikitude-cloud-recognition-service"] = "Regional availability of Wikitude Cloud Recognition Service";
index.add({
    url: "gettingstartedcloudrecognition.html#regional-availability-of-wikitude-cloud-recognition-service",
    title: "Regional availability of Wikitude Cloud Recognition Service",
    body: "### Regional availability of Wikitude Cloud Recognition Service  As as a developer using Wikitude Cloud Recognition Service you need to choose which server location you want to use for your projects. Wikitude operates several servers running Wikitude Cloud Recognition Service in different locations world-wide.  As the region servers are separated, content which is stored on one region server is only available on this particular server. **Content is not synced across regions**. You can choose from the following `Regions`  - `Americas` - `Europe`  The servers for each region have separate dedicated domain names and therefore different configurations.   &lt;a id=\&quot;targetmanagerregional\&quot;&gt;&lt;/a&gt;  | Region | Target Manager | Manager API| SDK Setting | | :------------------ |:---------------:| ------ | ---- | |Americas|[targetmanager&amp;#8209;us.wikitude.com](https://targetmanager-us.wikitude.com)|[https://api-us.wikitude.com](https://api-us.wikitude.com)|`Americas`| |Europe|[targetmanager.wikitude.com](https://targetmanager.wikitude.com)|[https://api.wikitude.com](https://api.wikitude.com) or [https://api-eu.wikitude.com](https://api-eu.wikitude.com)|`Europe`|  "
});

documentTitles["gettingstartedcloudrecognition.html#preparation"] = "Preparation";
index.add({
    url: "gettingstartedcloudrecognition.html#preparation",
    title: "Preparation",
    body: "### Preparation   1. [Create a free](http://www.wikitude.com/c/portal/login?p_l_id=533165) Wikitude developer account or [log-in](http://www.wikitude.com/c/portal/login?p_l_id=533165) if you are a returning developer 2. Get the [API tokens](http://www.wikitude.com/developer/licenses) for the Manager API and the Client API to start your project. [Read more on authentication](#authentication) 3. Test the API for free using Wikitude's [sample integrations](https://github.com/Wikitude/wikitude-cloud-recognition-api-samples) 4. Once you finished your integration, [purchase](https://www.wikitude.com/products/wikitude-cloud-recognition/) a commercial token.    "
});

documentTitles["gettingstartedcloudrecognition.html#first-steps-and-general-usage"] = "First Steps and General Usage";
index.add({
    url: "gettingstartedcloudrecognition.html#first-steps-and-general-usage",
    title: "First Steps and General Usage",
    body: "### First Steps and General Usage   1. Get familiar with the Manager API calls in the [API Reference](cloudrecoapi://index.html).  2. Create a first Target Collection using the [`Create Target Collection`](cloudrecoapi://index.html#api-TargetCollection-CreateTargetCollection) endpoint and note down the ID of the Target Collection	 3. Create targets using the [`Create Target`](cloudrecoapi://index.html#api-Target-CreateTarget) endpoint for that particular Target Collection 4. Important: [`Generate a Cloud Archive`](index.html#api-TargetCollection-GenerateCloudArchive) for your Target Collection 4. Go to the Wikitude SDK and create an Android or iOS project 5. Use the Client API token to authenticate your Android or iOS project 6. Use your Target Collection ID to recognize images  For more information on the available endpoints and how to work with the Manager API see the [workflow section](cloudrecognitionworkflow.html).  Instead of creating a `TargetCollection`, adding one or more `Targets`, and generating a `Cloud Archive` by calling the REST API, the [Wikitude Targetmanager](#targetmanagerregional) can be used to perform these steps (1-4) in the browser alternatively.  In case you would like to immediately test the API calls we recommend the tool [Postman](https://www.getpostman.com/). It helps you to quickly construct the requests and analyze the responses.  "
});

documentTitles["gettingstartedcloudrecognition.html#authentication"] = "Authentication";
index.add({
    url: "gettingstartedcloudrecognition.html#authentication",
    title: "Authentication",
    body: "## Authentication  The Cloud Recognition Service knows two authentication tokens, that you need in order to work with the service  * **Manager API token** You need this token to authenticate yourself against the RESTful Manager API. The Manager API is used to create, add and delete targets and target collections. The token identifies your developer account. Calls to the Manager API do not count towards your quota limits.  * **Client API token** You need this token to authenticate calls from the Wikitude SDK to the Cloud Recognition services. It again authenticates calls as legitimate. The token is bound to your developer account. Calls from the Wikitude SDK to the service with a wrong or missing token can not access your target collections.   "
});

documentTitles["gettingstartedcloudrecognition.html#authentication-on-the-manager-api"] = "Authentication on the Manager API";
index.add({
    url: "gettingstartedcloudrecognition.html#authentication-on-the-manager-api",
    title: "Authentication on the Manager API",
    body: "### Authentication on the Manager API  The **Manager API token** must be added to each call towards the Wikitude Cloud Recognition Manager API. The token authenticates the user account that is using the API.   "
});

documentTitles["gettingstartedcloudrecognition.html#authentication-on-the-client-api"] = "Authentication on the Client API";
index.add({
    url: "gettingstartedcloudrecognition.html#authentication-on-the-client-api",
    title: "Authentication on the Client API",
    body: "### Authentication on the Client API The **Client API token** must be added to your app project using the Wikitude SDK. This token is needed additionally beside the SDK license key when working with the [`AR.CloudRecognitionService`](architectapi://reference/classes/CloudRecognitionService.html) class.  "
});

documentTitles["gettingstartedcloudrecognition.html#quota-and-limits"] = "Quota and Limits";
index.add({
    url: "gettingstartedcloudrecognition.html#quota-and-limits",
    title: "Quota and Limits",
    body: "## Quota and Limits  "
});

documentTitles["gettingstartedcloudrecognition.html#general-upload-limit"] = "General Upload Limit";
index.add({
    url: "gettingstartedcloudrecognition.html#general-upload-limit",
    title: "General Upload Limit",
    body: "### General Upload Limit The Wikitude Cloud Recognition **will not accept images bigger than 1024kB** (1 MB). Trying to upload images exceeding this file size will result in a HTTP status code `400` together with an error message `FILE_SIZE_LIMIT_EXCEED`.  "
});

documentTitles["gettingstartedcloudrecognition.html#limits-for-the-wikitude-cloud-recognition-service"] = "Limits for the Wikitude Cloud Recognition Service";
index.add({
    url: "gettingstartedcloudrecognition.html#limits-for-the-wikitude-cloud-recognition-service",
    title: "Limits for the Wikitude Cloud Recognition Service",
    body: "### Limits for the Wikitude Cloud Recognition Service  There are two main limitations for the Wikitude Cloud Recognition service that you need to be aware of:  * **Targets** Your token has a certain number of targets that you can upload and store on the cloud service under your developer account. The limit is always counted for your entire developer account and not for a single target collection. The service is not counting single uploads, but how many targets are currently stored in target collections under your account.   * **Scans** Scans are in effect calls from the Wikitude SDK via the Client API to the Cloud Recognition servers. All commercial license come with an allowance of 1,000,000 scans per month per developer account. **Note:** When using Continuous Search mode multiple calls are made to the server.  "
});

documentTitles["gettingstartedcloudrecognition.html#maximum-number-of-targets-in-a-target-collection"] = "Maximum Number of Targets in a Target Collection";
index.add({
    url: "gettingstartedcloudrecognition.html#maximum-number-of-targets-in-a-target-collection",
    title: "Maximum Number of Targets in a Target Collection",
    body: "### Maximum Number of Targets in a Target Collection A target collection can't exceed 50,000 targets.  "
});

documentTitles["gettingstartedcloudrecognition.html#free-trial-license-for-cloud-recognition"] = "Free Trial License for Cloud Recognition";
index.add({
    url: "gettingstartedcloudrecognition.html#free-trial-license-for-cloud-recognition",
    title: "Free Trial License for Cloud Recognition",
    body: "### Free Trial License for Cloud Recognition  Wikitude provides a trial token for each developer account to try out the Cloud Recognition for free. This trial token has set a quota limit that allows developers to try and test the functionality of the service. Limitations for trial accounts  * Targets: 50,000 * Scans: 1,000 per month  To get your trial token for the REST API, please visit the [License page](http://www.wikitude.com/developer/licenses). The trial token is directly integrated into the Studio Manager.  "
});

documentTitles["gettingstartedcloudrecognition.html#commercial-licenses"] = "Commercial Licenses";
index.add({
    url: "gettingstartedcloudrecognition.html#commercial-licenses",
    title: "Commercial Licenses",
    body: "### Commercial Licenses For production systems, we offer commercial licenses with various quota limits for [purchase](https://www.wikitude.com/store).   "
});



documentTitles["cloudrecognitionworkflow.html#your-first-target-collections"] = "Your first Target Collections";
index.add({
    url: "cloudrecognitionworkflow.html#your-first-target-collections",
    title: "Your first Target Collections",
    body: "## Your first Target Collections Target Collections are central to working with Cloud Recognition service. They keep all your target images and are the base for the cloud archive.  Think of TargetCollection as a directory, where your images are stored. A TargetCollection forms a logical group, which is searched as a whole. Of course you can have several TargetCollections in your account, each consisting up to 50,000 images each.     "
});

documentTitles["cloudrecognitionworkflow.html#what-is-the-difference-between-cloud-archive-and-target-collection"] = "What is the difference between Cloud Archive and Target Collection";
index.add({
    url: "cloudrecognitionworkflow.html#what-is-the-difference-between-cloud-archive-and-target-collection",
    title: "What is the difference between Cloud Archive and Target Collection",
    body: "### What is the difference between Cloud Archive and Target Collection  &lt;div class=\&quot;warning\&quot;&gt;A Cloud Archive is an optimized version of your Target Collection for cloud-based recognition. Cloud Archives are in internal structure, that keeps all necessary data for performing image recognition on the server. &lt;/div&gt;  "
});

documentTitles["cloudrecognitionworkflow.html#structure-of-a-targetcollection"] = "Structure of a TargetCollection";
index.add({
    url: "cloudrecognitionworkflow.html#structure-of-a-targetcollection",
    title: "Structure of a TargetCollection",
    body: "### Structure of a TargetCollection  | Property | Type | Description| | :------------------ |:---------------| ------ | |**id**| (String)| An ID that uniquely identifies the TargetCollection| | **name** | (String) | The Name of the TargetCollection, as defined by the user| | **creDat** | (Number)| A timestamp when the TargetCollection was created (as returned by JavaScript's `Date.now()` function)| | **modDat** | (Number)| A timestamp when the TargetCollection was last modified (as returned by JavaScript's `Date.now()` function)|   "
});

documentTitles["cloudrecognitionworkflow.html#create-a-target-collection"] = "Create a Target Collection";
index.add({
    url: "cloudrecognitionworkflow.html#create-a-target-collection",
    title: "Create a Target Collection",
    body: "### Create a Target Collection  Creating a Target Collection is easy and can be done without any prerequisites in your account. In general it is your starting point and most likely your very first action.  Call the endpoint (using the domain of one of the [regional servers](gettingstartedcloudrecognition.html#targetmanagerregional))  	/cloudrecognition/targetCollection  with the mandatory `name` field as a `POST` request and you will create a new TargetCollection. The response will contain a TargetCollection object, where the ID is most important parameter. You can also add `metadata` to a TargetCollection in case you want to some additional descriptive information. The next step is to add images to your TargetCollection, so they can be recognized.  "
});

documentTitles["cloudrecognitionworkflow.html#add-target-images"] = "Add Target Images";
index.add({
    url: "cloudrecognitionworkflow.html#add-target-images",
    title: "Add Target Images",
    body: "## Add Target Images  A Target is an plain image that can be recognized by the Wikitude Cloud Recognition service. Adding or creating a target means to provide a URL to your image to the server, which then downloads the image, analyzes it  and adds it to the TargetCollection. To add an image call the endpoint  	/cloudrecognition/targetCollection/:tcId/target  with the `ID` of the TargetCollection, where you want to add the image. You need to add the a field `imageUrl` to your request. The image must be publicly accessible.  Pay attention to the optional fields `name` and `metadata`. `name` is a unique identifier for your target within the TargetCollection. It is up to you to set and use this. The same is true for the `metadata` object, which takes a full JSON object and can be filled with any value you like. The `metadata` object will be present in the recognition response.   &lt;div class=\&quot;tip\&quot;&gt;&lt;strong&gt;Important: &lt;/strong&gt;You are not done yet. As a next step you need to Generate the Cloud Archive of your TargetCollection.&lt;/div&gt;  "
});

documentTitles["cloudrecognitionworkflow.html#structure-of-a-target"] = "Structure of a Target";
index.add({
    url: "cloudrecognitionworkflow.html#structure-of-a-target",
    title: "Structure of a Target",
    body: "### Structure of a Target  | Property | Type | Description| | :------------------ |:---------------| ------ | |id |(String)| An ID that uniquely identifies the Target| |name |(String)| The Name of the Target, as defined by the user| |imageUrl |(String)| The URL pointing to the original, uncompressed and uncropped Target binary file| |thumbnailUrl| (String)| The URL pointing to a thumbnail representation of the Target| |rating |(Number)| The rating (from 0 to 3) of the Target| |fileSize |(Number)| The file size of the original Target binary image file, in bytes| |physicalHeight |(Number)| The physical (real world) height of the target, in millimeters| |creDat| (Number)| A timestamp when the Target was created (as returned by JavaScript's Date.now() function)| |modDat |(Number)| A timestamp when the Target was last modified (as returned by JavaScript's Date.now() function)| |metadata| (JSON)| Arbitrary JSON data that is stored together with the target.|   "
});

documentTitles["cloudrecognitionworkflow.html#generate-a-cloud-archive"] = "Generate a Cloud Archive";
index.add({
    url: "cloudrecognitionworkflow.html#generate-a-cloud-archive",
    title: "Generate a Cloud Archive",
    body: "## Generate a Cloud Archive  Once you are done with adding targets you need to tell the server that it should generate your TargetCollection into a Cloud Archive. Call  	/cloudrecognition/targetCollection/:tcId/generation 	 again with the `ID` of your TargetCollection and the process will be started. Since this call is asynchronous you will receive the response immediately with a path in the Location-property in the header of the response. By calling the url with the path, for example 	 	/cloudrecognition/targetCollection/:tcId/generation/wtc/:generationId 	 with a GET-method request, you will see the [status of the progress](cloudrecoapi://index.html#api-TargetCollection-GetGenerationInformation) of the cloud archive generation in the response body as a JSON object. When the generation is completed, the cloud archive is available for recognition. Note that the generation process can take a while when generating a large TargetCollection for the first time. Small additions to existing cloud archives are processed a lot faster.  &lt;div class=\&quot;warning\&quot;&gt; Everytime you changed a target (add/delete) you need to manually call Generate Cloud Archive for your target collection. Otherwise  &lt;ul&gt;&lt;li&gt;your newly added image will not be recognized &lt;/li&gt; &lt;li&gt;your deleted image will still be recognized&lt;/li&gt;&lt;/ul&gt;&lt;/div&gt;  Your Cloud Archive is now ready on the server and can be used in combination with the Wikitude SDK from your app. See the SDK sample called [Cloud Recognition](cloudrecognitionnative.html) for more details.  "
});

documentTitles["cloudrecognitionworkflow.html#generate-a-wtc-file-via-api"] = "Generate a WTC file via API";
index.add({
    url: "cloudrecognitionworkflow.html#generate-a-wtc-file-via-api",
    title: "Generate a WTC file via API",
    body: "## Generate a WTC file via API You can create and download a wtc file of a Target Collection ([Generate WTC](cloudrecoapi://#api-TargetCollection-GenerateWTC)) with up to 1000 targets by calling  	/cloudrecognition/targetCollection/:tcId/generation/wtc 	 with method POST. You have to specify the SDK version the wtc file should be built for in the request body. Valid values for the version are `3.x`, `4.0`, `4.1`,  `5.0`,`5.1`,`5.2`,`5.3`,`6.0`. Optionally, an email address can be added. The email is used for a notification once the generation of the wtc file has finished. Example for the request body:  	{ 		\&quot;sdkVersion\&quot;: \&quot;6.0\&quot;, 		\&quot;iwantmywtcfile@wikitude-user.com\&quot; 	} 	 Similar to the cloud archive generation this call is asynchronous, so the response header (`Location`) contains a path useful for requesting the [status of the wtc creation](cloudrecoapi://index.html#api-TargetCollection-GetWTCGenerationInformation). Once the status is `COMPLETED` the link to the actual wtc file can be requested from the [TargetCollection](cloudrecoapi://#api-TargetCollection-GetTargetCollection). The received `TargetCollection` object (in the body of the response) contains an additional property called `wtc`, which is an array of wtc objects. Those objects consists of the following properties:  - the `url` to the wtc file,  - the number of targets (`nrOfTargets`), - the `version`, - the creation date (`creDat`)  "
});

documentTitles["cloudrecognitionworkflow.html#additional-calls"] = "Additional calls";
index.add({
    url: "cloudrecognitionworkflow.html#additional-calls",
    title: "Additional calls",
    body: "## Additional calls  Beside the above described steps the Manager API also offers to [Delete TargetCollections](cloudrecoapi://index.html#api-TargetCollection-DeleteTargetCollection) and [Delete Targets](cloudrecoapi://index.html#api-Target-DeleteTarget).   Using `GET` request you can query details about a [single TargetCollection](cloudrecoapi://#api-TargetCollection-GetTargetCollection), [all Target Collections](cloudrecoapi://#api-TargetCollection-GetAllTargetCollections) in your account, a [single Target](cloudrecoapi://#api-Target-GetTarget) and [all Targets within a TargetCollection](cloudrecoapi://#api-Target-GetAllTargets).  The physical height and the metadata of an existing target can be [updated](cloudrecoapi://#api-Target-UpdateTarget)."
});



documentTitles["cloudrecognitionnative.html#cloud-recognition-sample"] = "Cloud Recognition Sample";
index.add({
    url: "cloudrecognitionnative.html#cloud-recognition-sample",
    title: "Cloud Recognition Sample",
    body: "## Cloud Recognition Sample  This example shows how to recognize images on a cloud server and then overlay it with augmentations utilizing the `ImageTracker` and `CloudRecognitionService` classes.   For a better understanding, here are some terms that will be used in the following and other sections of this documentation related to vision-based augmented reality.  - **Target**: An image and its associated extracted data that is used to recognize an image.  - **Target Collection**: A group of `targets` that are searched together. Think of it as a directory, which contains all your images you want to search. The Wikitude SDK can work with two different sorts of `Target Collections` 	+ On-device Target Collection: a static `wtc` file containing the extracted data of your images. Can consist of up to 1,000 images. 	+ Cloud Target Collection: A target collection stored on the Wikitude server. See `Cloud Archive` below. Can consist of up to 50,000 images.  - **Cloud Archive**: An archive stored on the server that is optimized for cloud-based recognition. It is generated from a `Target Collection` and is used in combination with `CloudRecognitionService` .   - **CloudRecognitionService**: Instead of analysing and computing the live camera feed directly on the device, the `CloudRecognitionService` will send the image(s) taken by the camera to the Wikitude Cloud Recognition server. The server will then do the hard work of trying to match the image with your targets in the specified cloud archive. Beside the benefit of searching in large image database, using the `CloudRecognitionService` has also a positive impact on the general performance in most cases. Especially when using a large target collection and on older devices.  &lt;a id=\&quot;OnClickCloudTracking\&quot;&gt;&lt;/a&gt; "
});

documentTitles["cloudrecognitionnative.html#cloud-recognition-in-unity"] = "Cloud recognition in Unity";
index.add({
    url: "cloudrecognitionnative.html#cloud-recognition-in-unity",
    title: "Cloud recognition in Unity",
    body: "### Cloud recognition in Unity  "
});

documentTitles["cloudrecognitionnative.html#cloudtracker-prefab"] = "CloudTracker Prefab";
index.add({
    url: "cloudrecognitionnative.html#cloudtracker-prefab",
    title: "CloudTracker Prefab",
    body: "#### CloudTracker Prefab To add a tracker prefab to the scene, simply drag the `CloudTracker` prefab into the scene hierarchy. The `CloudTracker` prefab also has the `ImageTracker` script, but is preconfigured to use the `CloudRecognitionService` instead of a `TargetCollectionResource`.  A `CloudRecognitionService` needs to know which cloud archive should be loaded. This is done by entering a `TargetCollectionId` into the appropriate text field of the `ImageTracker` script component, in the `CloudRecognitionService` section. To identify the SDK user, the field called `ClientToken` needs to be entered as well. With those values in place, the `CloudRecognitionService` knows which image targets have to be searched for on the cloud recognition server.  To react on events like successfully loading a cloud archive, you can use the Unity Events listed in in the inspector of the `ImageTracker`. Please refer to the [Image Recognition](imagerecognitionnative.html) examples for more information on how to use `UnityEvents`. When the `ImageTracker` is using the `CloudRecognitionService` additional events that are specific to it are shown in the inspector.  To start a server recognition, call the `Recognize` or `StartContinuousRecognition` methods of the `Wikitude.CloudRecognitionService` script assigned to the `ImageTracker`. To evaluate the server response and evaluate which target was recognized and which meta information are associated with this particular image target, you can use the `OnRecognitionResponse` event on the `ImageTracker` component, in the `Cloud Recognition Service Events` section.  In case a continuous recognition was started, it needs to be stopped after either a image target was recognized or the application is about to quit. You can restart the continuous recognition after the target was lost to start tracking it again. Please see the `Cloud Recognition - Continuous Mode` sample for an example on how to do this.  "
});

documentTitles["cloudrecognitionnative.html#regional-server-endpoints"] = "Regional server endpoints";
index.add({
    url: "cloudrecognitionnative.html#regional-server-endpoints",
    title: "Regional server endpoints",
    body: "#### Regional server endpoints  The cloud recognition server region can be selected by changing the `Server Region` option in the `ImageTracker` inspector, in the `Cloud Recognition Service` section.   "
});

documentTitles["cloudrecognitionnative.html#define-custom-augmentations"] = "Define custom augmentations";
index.add({
    url: "cloudrecognitionnative.html#define-custom-augmentations",
    title: "Define custom augmentations",
    body: "#### Define custom augmentations Augmentations are placed exactly like when using a normal `ImageTracker`, so please refer to the [Image Recognition](imagerecognitionnative.html) examples for more information.  "
});



documentTitles["occludersunity.html#rendering"] = "Rendering";
index.add({
    url: "occludersunity.html#rendering",
    title: "Rendering",
    body: "# Rendering  "
});

documentTitles["occludersunity.html#occluders-in-unity"] = "Occluders in Unity";
index.add({
    url: "occludersunity.html#occluders-in-unity",
    title: "Occluders in Unity",
    body: "## Occluders in Unity  These steps will help you create an object that hides all geometry behind it, but is still transparent:  - In the Project tab, create a new shader asset and name it `Occluder` - Open the shader and paste the following code in it:  ```c Shader \&quot;Unlit/Occluder\&quot; { 	SubShader { 		Tags { \&quot;Queue\&quot; = \&quot;Geometry-1\&quot; } 		ColorMask 0  		ZWrite On 		Pass { } 	} } ```  - Create a new material and name it `Occluder` as well - In the material inspector     - Set the shader to `Unlit/Occluder`     - Make sure that the `Render Queue` is set to `From Shader`. It should have a value of 1999 - Create a new object that should act as an occluder. - In the `Mesh Renderer` component of the new occluder object, set the material to the `Occluder` material we just created. - The occluder object should hide all other objects behind it, but still draw the background.  If you want more control over which objects get hidden and which don't, you can set the `Render Queue` value of the occluder object to 2001 and the `Render Queue` value of the objects that should be occluded to 2002. This will keep all defaults objects visible and allow you to set the occlusion effect on just some objects. To set the `Render Queue` on other objects, you can either create a custom shader or add the following script to the objects:  ```csharp using UnityEngine;   public class SetRenderQueue : MonoBehaviour {   	[SerializeField] 	protected int[] m_queues = new int[] { 2002 };   	protected void Awake() { 		Material[] materials = renderer.materials; 		for (int i = 0; i &lt; materials.Length &amp;&amp; i &lt; m_queues.Length; ++i) { 			materials[i].renderQueue = m_queues[i]; 		} 	} } ```  Tested on Unity 5.5 "
});



documentTitles["cameracontrolunity.html#camera-controls"] = "Camera Controls";
index.add({
    url: "cameracontrolunity.html#camera-controls",
    title: "Camera Controls",
    body: "## Camera Controls  The `WikitudeCamera` also provides APIs to change the settings on the device camera.  The first category of settings are visible and editable directly in the inspector of the `WikitudeCamera`, while the second category can only be changed through scripting. Please also see the `Camera Controls - Camera Settings` scene for an example on how to use them.  "
});

documentTitles["cameracontrolunity.html#inspector-settings"] = "Inspector Settings";
index.add({
    url: "cameracontrolunity.html#inspector-settings",
    title: "Inspector Settings",
    body: "### Inspector Settings &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/unity_camera_settings_inspector.png\&quot;&gt; "
});

documentTitles["cameracontrolunity.html#camera-resolution"] = "Camera Resolution";
index.add({
    url: "cameracontrolunity.html#camera-resolution",
    title: "Camera Resolution",
    body: "#### Camera Resolution The `Camera Resolution` setting indicates which resolution you would like to use. Available options are `SD`, `HD` and `FullHD`. If the desired resolution is not available, the closest available resolution will be used instead. You can also select `Auto` and the SDK will select a resolution based on the capabilities of the device.  "
});

documentTitles["cameracontrolunity.html#camera-framerate"] = "Camera Framerate";
index.add({
    url: "cameracontrolunity.html#camera-framerate",
    title: "Camera Framerate",
    body: "#### Camera Framerate The `Camera Framerate` setting allows you to select between `30 FPS` and `60 FPS`. If `60 FPS` is selected, but the device doesn't support it, `30 FPS` will be used instead. You can also select `Auto` and the SDK will select a framerate based on the capabilities of the device.  "
});

documentTitles["cameracontrolunity.html#enable-camera-rendering"] = "Enable Camera Rendering";
index.add({
    url: "cameracontrolunity.html#enable-camera-rendering",
    title: "Enable Camera Rendering",
    body: "#### Enable Camera Rendering By default, the WikitudeCamera script will render the camera frames in the background of your scene. By disabling this option, the Wikitude SDK will stop doing any kind of rendering. This also means that the WikitudeCamera script doesn't need a camera component to be attached to the same GameObject.  "
});

documentTitles["cameracontrolunity.html#static-camera"] = "Static Camera";
index.add({
    url: "cameracontrolunity.html#static-camera",
    title: "Static Camera",
    body: "#### Static Camera By default, the WikitudeCamera script will move its GameObject in world space to correspond what the real camera is seeing. When the `Static Camera` option is enabled, the WikitudeCamera GameObject will never move and all the trackables will be moved relative to the camera instead. Additionally, you can move the WikitudeCamera GameObject yourself and the trackables will follow it accordingly.  "
});

documentTitles["cameracontrolunity.html#script-only-settings"] = "Script Only Settings";
index.add({
    url: "cameracontrolunity.html#script-only-settings",
    title: "Script Only Settings",
    body: "### Script Only Settings "
});

documentTitles["cameracontrolunity.html#camera-position"] = "Camera position";
index.add({
    url: "cameracontrolunity.html#camera-position",
    title: "Camera position",
    body: "#### Camera position The `DevicePosition` property enables you to change between the back and front camera of the device.  "
});

documentTitles["cameracontrolunity.html#focus-mode"] = "Focus Mode";
index.add({
    url: "cameracontrolunity.html#focus-mode",
    title: "Focus Mode",
    body: "#### Focus Mode The `FocusMode` property can change the camera focus mode between `Locked`, which will keep the current focus, `Once`, which will try to focus the camera only once and `Continuous` which will constantly adapt the focus of the camera to changes in the view.  "
});

documentTitles["cameracontrolunity.html#manual-focus"] = "Manual Focus";
index.add({
    url: "cameracontrolunity.html#manual-focus",
    title: "Manual Focus",
    body: "#### Manual Focus The `ManualFocus` property allows the focal length to be set at a custom distance when the `FocusMode` is set to `Locked`. The property accepts values from 0 to 1, where 0 means focusing the camera as close as possible.  "
});

documentTitles["cameracontrolunity.html#flash-mode"] = "Flash Mode";
index.add({
    url: "cameracontrolunity.html#flash-mode",
    title: "Flash Mode",
    body: "#### Flash Mode The `FlashMode` property allows you to turn on the camera flash.  "
});

documentTitles["cameracontrolunity.html#zoom-level"] = "Zoom Level";
index.add({
    url: "cameracontrolunity.html#zoom-level",
    title: "Zoom Level",
    body: "#### Zoom Level The `ZoomLevel` property changes the zoom level used by the camera. Valid values are between 1.0 and `MaxZoomLevel`. Be sure tu query the `MaxZoomLevel` property first. A `MaxZoomLevel` value of 1.0 indicates that the device doesn't support zooming.  "
});

documentTitles["cameracontrolunity.html#auto-focus-restriction-ios-only"] = "Auto Focus Restriction (iOS only)";
index.add({
    url: "cameracontrolunity.html#auto-focus-restriction-ios-only",
    title: "Auto Focus Restriction (iOS only)",
    body: "#### Auto Focus Restriction (iOS only) The `AutoFocusRestriction` property let's you restrict the auto focus on the camera to either `Near` or `Far`. By default it is not restricted.  "
});

documentTitles["cameracontrolunity.html#ignore-trackable-scale"] = "Ignore Trackable Scale";
index.add({
    url: "cameracontrolunity.html#ignore-trackable-scale",
    title: "Ignore Trackable Scale",
    body: "#### Ignore Trackable Scale When the `IgnoreTrackableScale` property is enabled, the camera ignores the scaling of the trackable for tracking purposes and assumes it to be 1.0f. When doing a `TransformOverride` that also changes the scale of the trackables, this should be set to true.  "
});

documentTitles["cameracontrolunity.html#transform-override"] = "Transform Override";
index.add({
    url: "cameracontrolunity.html#transform-override",
    title: "Transform Override",
    body: "#### Transform Override The `ActiveOverride` allows a custom `TransformOverride` to be applied before any Transform changes are made to the `WikitudeCamera` or any `Trackables`. "
});



documentTitles["pluginsapiunity.html#plugins-api"] = "Plugins API";
index.add({
    url: "pluginsapiunity.html#plugins-api",
    title: "Plugins API",
    body: "# Plugins API  The Plugins API provides access to the camera frame as a native pointer. This allows you to do additional processing on it, either in C#, or in native code (C++, Objective C, Java). This guide is split into two parts. First, we will discuss how to enable and use plugins in your Unity project. In the second part, we'll go through the steps required to build and use a native library.   "
});

documentTitles["pluginsapiunity.html#unity-interface"] = "Unity interface";
index.add({
    url: "pluginsapiunity.html#unity-interface",
    title: "Unity interface",
    body: "## Unity interface  To enable plugins, you need to add the `PluginManager` script to a GameObject. Then, you simply subscribe to the `On Camera Frame Available` event and you will be notified when a new camera frame is ready for additional processing.  ![](images/unity_plugins_api_plugin_manager.png)  You will receive as a parameter to the callback a `Wikitude.Frame` struct which contains the native pointer to the raw data, as well as additional information about the frame.  ``` public struct Frame {     public IntPtr Data;     public int DataSize;     public int Width;     public int Height;     public FrameColorSpace ColorSpace; } ```  The `ColorSpace` field provides information about the format of the frame you are receiving.  ``` public enum FrameColorSpace : int {     /// &lt;summary&gt;     /// Represents a color space where image data is given in a YUV 420 format, arranged to be compliant to the NV21 standard.     //  The data size is frame width * frame height * 3/2, meaning full luminance resolution and half the size for chroma red * chroma blue     //     //  On iOS this is represented by the kCVPixelFormatType_420YpCbCr8BiPlanarFullRange constant     //  On Android this is represented by the ImageFormat.YUV_420_888 constant. After that the frame needs to be converted to the NV21 format (replace U and V)     /// &lt;/summary&gt;     YUV_420_NV21 = 0,      /// &lt;summary&gt;     /// Represents a color space where image data is given in a RGB format.     /// The data size is frame width * frame height * 3 (R, G and B channel).     ///     /// On iOS this is represented by the kCVPixelFormatType_24RGB constant     /// On Android this is represented by the ImageFormat.FLEX_RGB_888 constant     /// &lt;/summary&gt;     RGB } ```  The native pointer is only valid during the duration of the current update and you should never delete or change the data it's pointing to. You can pass this pointer to your own native plugins, or transfer the data in C# using `Marshal.Copy` functions.  ``` using UnityEngine; using System; using Wikitude; using System.Runtime.InteropServices;  public class PluginController : MonoBehaviour { 	public void OnCameraFrameAvailable(Frame frame) {          // Example of how to transfer data from native memory         // to a C# array  		byte[] data = new byte[frame.DataSize]; 		Marshal.Copy(frame.Data, data, 0, frame.DataSize); 	} } ```  "
});

documentTitles["pluginsapiunity.html#sample-explanation"] = "Sample explanation";
index.add({
    url: "pluginsapiunity.html#sample-explanation",
    title: "Sample explanation",
    body: "## Sample explanation  The `Plugins - Barcode` sample shows  how to integrate the popular barcode library ZBar into Unity and use the Plugins API to send camera frames to it for processing.  ZBar is an open source software suite for reading bar codes from various sources, such as video streams, image files and raw intensity sensors. It supports many popular symbologies (types of bar codes) including EAN-13/UPC-A, UPC-E, EAN-8, Code 128, Code 39, Interleaved 2 of 5 and QR Code.  The `BarcodePlugin.cs` script manages the native C++ library, forwards calls to it and returns scanning results. First, the script declares the functions available in the native C++ library, so that they are available in C# ``` [DllImport(\&quot;barcode\&quot;)] private static extern void initialize(int width, int height);  [DllImport(\&quot;barcode\&quot;)] private static extern string get_barcode(int width, int height, IntPtr buffer);  [DllImport(\&quot;barcode\&quot;)] private static extern void destroy(); ```  After that, it provides C# methods that simply forward the call to C++ and return any result directly. ``` public void Initialize(int width, int height) {     initialize(width, height); }  public string GetBarcode(Wikitude.Frame frame) {     return get_barcode(frame.Width, frame.Height, frame.Data); }  public void Destroy() {     destroy(); } ```  The `PluginController.cs` script controls the sample. It is registered in the editor to receive `OnCameraFrameAvailable`. First, initializes the barcode scanner when the first frame is received, then forwards the pointer to the data to the scanner and prints the result it receives from it.  ``` public void OnCameraFrameAvailable(Frame frame) {     if (!_initialized) {         _plugin.Initialize(frame.Width, frame.Height);         _initialized = true;     }      string barcode = _plugin.GetBarcode(frame);      if (barcode != null) {         ResultText.text = barcode;     } else {         ResultText.text = \&quot;Could not detect any barcodes\&quot;;     } } ```  "
});

documentTitles["pluginsapiunity.html#native-code"] = "Native code";
index.add({
    url: "pluginsapiunity.html#native-code",
    title: "Native code",
    body: "## Native code In the project you will also find source code for the barcode plugin. It is contained in a single .cpp file named barcode.cpp in Assets/Wikitude/Samples/NativeCode/BarcodePlugin/src.  ``` #include &lt;stdlib.h&gt; #include &lt;string.h&gt; #include \&quot;zbar.h\&quot;  zbar::Image* _image; zbar::ImageScanner* _imageScanner;  extern \&quot;C\&quot; {     void initialize(int width, int height);     const char* get_barcode(int width, int height, unsigned char* data);     void destroy(); }  void initialize(int width, int height) {     _image = new zbar::Image(width, height, \&quot;Y800\&quot;, nullptr, 0);     _imageScanner = new zbar::ImageScanner();     _imageScanner-&gt;set_config(zbar::ZBAR_NONE, zbar::ZBAR_CFG_ENABLE, 1); }  const char* get_barcode(int width, int height, unsigned char* data) {     _image-&gt;set_data(data, width * height);     int n = _imageScanner-&gt;scan(*_image);      if (n)     {         zbar::Image::SymbolIterator symbol = _image-&gt;symbol_begin();         return strdup(symbol-&gt;get_data().c_str());     }     else     {         return nullptr;     } }  void destroy() {     _image-&gt;set_data(nullptr, 0);      delete _image;     delete _imageScanner; }  ```  All the exported functions need to be declared with \&quot;C\&quot; linkage so that they can be linked with the C# code.  "
});

documentTitles["pluginsapiunity.html#rebuilding-for-android"] = "Rebuilding for Android";
index.add({
    url: "pluginsapiunity.html#rebuilding-for-android",
    title: "Rebuilding for Android",
    body: "### Rebuilding for Android If you need to rebuild the plugin, you can use the included .mk files for Android located in the `Assets/Wikitude/Samples/NativeCode/BarcodePlugin/project/android/` folder. After the build is done, copy the resulting .so file in the `Assets/Wikitude/Samples/Plugins/Android/` folder, overwriting the current one.  Please check the [Android documentation](https://developer.android.com/ndk/guides/build.html) for how to build mk files using ndk-build.   "
});

documentTitles["pluginsapiunity.html#rebuilding-for-ios"] = "Rebuilding for iOS";
index.add({
    url: "pluginsapiunity.html#rebuilding-for-ios",
    title: "Rebuilding for iOS",
    body: "### Rebuilding for iOS For iOS, you will need to create a new library project and name it `barcodeplugin`.  ![](images/unity_plugins_api_create_library.png)  ![](images/unity_plugins_api_name_library.png)  In the `Build Settings` tab, set `Other Librarian Flags` to `-lzbar` and the `Library Search Paths` to include the path where the `libzbar.a` libary for iOS is located. You can find it in `Assets/Wikitude/Samples/NativeCode/BarcodePlugin/lib/ios`.  ![](images/unity_plugins_api_librarian_flags.png)  ![](images/unity_plugins_api_library_search_path.png)  Then, you need to include the `Assets/Wikitude/Samples/NativeCode/BarcodePlugin/src` folder into the project.  ![](images/unity_plugins_api_add_files_1.png)  ![](images/unity_plugins_api_add_files_2.png)  Finally, the library needs to be build for `Generic iOS Device`.  ![](images/unity_plugins_api_build_target.png)  After it is done, you can copy the product `libbarcodeplugin.a` in the `Assets/Wikitude/Samples/Plugins/iOS/` folder, overwriting the current one. "
});



documentTitles["inputpluginsapiunity.html#input-plugins-api"] = "Input Plugins API";
index.add({
    url: "inputpluginsapiunity.html#input-plugins-api",
    title: "Input Plugins API",
    body: "## Input Plugins API  The input plugins API provides a means to alter the inputs and outputs of the Wikitude Native SDK. For the input case specifically, custom frame data of arbitrary sources can be supplied as an input to the Wikitude SDK Native API for processing. Complementary, for the output case, the default rendering of the Wikitude SDK Native API can be substituted with more advanced implementations. Both cases are illustrated in two separate samples.   "
});

documentTitles["inputpluginsapiunity.html#unity-interface"] = "Unity interface";
index.add({
    url: "inputpluginsapiunity.html#unity-interface",
    title: "Unity interface",
    body: "### Unity interface  Input plugins are enabled by setting the `Enable Input Plugins` toggle in the `WikitudeCamera` script to true. Once you do that, a number of additional options will appear, allowing you to configure how the input plugin behaves.  ![](images/unity_input_plugins_wikitude_camera.png)   1. `Mirroring` will flip the frame horizontally before any processing and rendering is done. This is useful when you want to process the feed from the front facing camera. 2. `Inverted Frame` will flip the frame vertically. The SDK expects the that the first row of pixels to correspond to the top of the image, because this is how the native cameras provide the data. However, when accessing the texture data from a Unity texture (including `WebCamTexture`) with `GetPixels32()`, the first row of the data will correspond to the bottom of the image. You can set this toggle to automatically flip image to convert from Unity format to the one expected by the SDK. This option is available only when the `ColorSpace` is `RGBA`. 3. `ColorSpace` tells the SDK what the format of the frame is. Supported values are the following:     * `YUV_420_NV21`: Represents a color space where image data is given in a YUV 420 format, arranged to be compliant to the NV21 standard. The data size is frame width \* frame height \* 3/2, meaning full luminance resolution and half the size for chroma red \* chroma blue. 	* `RGB`: Represents a color space where image data is given in a RGB format. The data size is frame width \* frame height \* 3 (R, G and B channel). 	* `RGBA`: Represents a color space where image data is given in a RGBA format. The data size is frame width \* frame height \* 4 (R, G, B, A channel). This is provided for convenience since this is the way Unity will return pixel data from a texture. 4. `Width` of the frame. 5. `Height` of the frame. 6. `Horizontal Angle` or FOV of the device used to capture the image. 7. `Rendering` toggle controls if the SDK will display the image on the screen. 8. `On Input Plugin Registered` callback will let you know when the registration of the plugin is complete and it is safe to open the device camera. Before this callback is called, the SDK might still be using the camera and you will get errors when trying to access it.  Please keep in mind that the `Mirroring` and `ColorSpace` properties cannot be changed while the input plugin is running. To change them after the scene has started, you will need to recreate the `Wikitude Camera` with the new settings.  "
});

documentTitles["inputpluginsapiunity.html#custom-camera-sample"] = "Custom Camera sample";
index.add({
    url: "inputpluginsapiunity.html#custom-camera-sample",
    title: "Custom Camera sample",
    body: "#### Custom Camera sample The first sample shows how to grab the camera feed with Unity and send it to the Wikitude SDK for processing and rendering. The logic of the sample is contained in the `CustomCameraController.cs` script.  When the `OnInputPluginRegistered` event is called, we initialize the buffer required to store the frame data. In the Update function, once we get a valid frame, we get the pixels from it using the `GetPixels32(Color32[])` method provided by the `WebCamTexture` class. To avoid additional copies of the data, we can obtain the native pointer to the data directly and send this to the SDK. The SDK will only read from this pointer during the duration of the call, so you don't need to keep the pointer around.  ``` private void SendNewCameraFrame() {     GCHandle handle = default(GCHandle);     try {         handle = GCHandle.Alloc(_pixels, GCHandleType.Pinned);         IntPtr frameData = handle.AddrOfPinnedObject();         WikitudeCam.NewCameraFrame(++_frameIndex, _frameDataSize, frameData);     } finally {         if (handle != default(GCHandle)) {             handle.Free();         }     } ```  "
});

documentTitles["inputpluginsapiunity.html#custom-rendering-samples"] = "Custom Rendering samples";
index.add({
    url: "inputpluginsapiunity.html#custom-rendering-samples",
    title: "Custom Rendering samples",
    body: "#### Custom Rendering samples The second sample works very similarly to the first one, except that the frame is also sent to the another script called `CustomCameraRenderer.cs`, which handles rendering of the camera frame with a custom edge detection shader. This script is placed on the camera and uses a `CommandBuffer` to instruct Unity to blit the camera texture to the screen using a custom material.  ``` _drawFrameBuffer = new CommandBuffer(); _drawFrameBuffer.Blit(_currentFrame, BuiltinRenderTextureType.CameraTarget, EffectMaterial); camera.AddCommandBuffer(eventForBlit, _drawFrameBuffer); ``` The script also handles how to draw the camera frame when the aspect ratio of the feed doesn't match the aspect ratio of the screen. "
});



documentTitles["targetmanagement.html#target-management"] = "Target Management";
index.add({
    url: "targetmanagement.html#target-management",
    title: "Target Management",
    body: "# Target Management  "
});

documentTitles["targetmanagement.html#image-targets-create-and-manage"] = "Image Targets: Create and Manage";
index.add({
    url: "targetmanagement.html#image-targets-create-and-manage",
    title: "Image Targets: Create and Manage",
    body: "## Image Targets: Create and Manage  This guide gives you an overview of how to create a target collection that you can use to detect and track images within your augmented reality experience.  In general the conversion can be done via four different tools:  1. **[Wikitude Studio Manager](#wikitude-studio-manager)**: A browser based tool to convert your images to a wtc file. You can find the tool under:  &lt;a href=\&quot;https://targetmanager.wikitude.com\&quot; target=\&quot;_blank\&quot;&gt;https://targetmanager.wikitude.com&lt;/a&gt;. You need your free developer account to log-in. This tool is described in more detail further below. 2. **WTC Editor within Unity Editor**: The Wikitude Unity plugin installs a WTC Editor as extension of the Unity Editor. Unity developers can manage all their targets and target collections directly within Unity Editor. Please consult the Unity documentation on more details. 2. **RESTful API**: The Cloud Recognition Manager API provides a RESTful API to upload target images and convert them to wtc files. Read more details in the [section about Cloud Recognition API](cloudrecognitionworkflow.html#generate-a-wtc-file) 3. **Targets Enterprise Script**: A binary shell script available for Mac OS X and Linux converting images to target collections. Pleases [contact Wikitude Sales](mailto:sales@wikitude.com) team for technical requirements and pricing.  The following images describes the relationship between the above mentioned methods and the Wikitude Cloud Recognition Service, which is not scope of this documentation.   &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/150212_WT_Infografik_OfflineOnlineRecognition_01.jpg\&quot;&gt;   "
});

documentTitles["targetmanagement.html#wikitude-studio-manager"] = "Wikitude Studio Manager";
index.add({
    url: "targetmanagement.html#wikitude-studio-manager",
    title: "Wikitude Studio Manager",
    body: "### Wikitude Studio Manager  "
});

documentTitles["targetmanagement.html#add-a-project"] = "Add a project";
index.add({
    url: "targetmanagement.html#add-a-project",
    title: "Add a project",
    body: "#### Add a project  - Open &lt;a href=\&quot;https://targetmanager.wikitude.com\&quot; target=\&quot;_blank\&quot;&gt;https://targetmanager.wikitude.com&lt;/a&gt; and login with your Wikitude developer account - Add a new project to your project collection  &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/tmt_CreateProject.png\&quot;&gt;  "
});

documentTitles["targetmanagement.html#add-target-images"] = "Add target images";
index.add({
    url: "targetmanagement.html#add-target-images",
    title: "Add target images",
    body: "#### Add target images  - Enter an existing project  - Add new target images to the project either by clicking on `Add Targets` or drag  &amp; drop them on the empty area. Supported file formats include PNG and JPEG. If you are using PNG images, please make sure that it does not contain any transparent pixels, only solid coloured images are supported.  &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/tmt_AddTargets.png\&quot;&gt;	  - When uploading a target the file name is used as `target name`. It identifies a target in your experience. If the `target name` is not completely visible, hover over it to reveal the full name or double click the target to enter edit-mode.  &lt;div class=\&quot;warning\&quot;&gt; **Important** &lt;br /&gt; If you add your own target images  you need the target name to set them in [`AR.ImageTrackable`](architectapi://reference/classes/ImageTrackable.html).&lt;/div&gt;   "
});

documentTitles["targetmanagement.html#star-rating"] = "Star Rating";
index.add({
    url: "targetmanagement.html#star-rating",
    title: "Star Rating",
    body: "#### Star Rating - **0 stars:** Not suitable for tracking. This target image cannot be tracked because it lacks textured features with high local contrast. Please consider choosing another target image. - **1 star:**  Limited tracking ability. This target image provides basic tracking performance in good lightning conditions. Please consider improving the image - **2 stars:** Good tracking ability. This target image will track well in most conditions. - **3 stars:** Very good tracking ability. This target image will track very well in most conditions.  General advice for reference images  - Good image characteristics: 	- Diversely textured image with high local contrast - Bad image characteristics: 	- Large areas with solid color or smooth color transitions 	- Repetitive patterns 	- Logos, signs		  "
});

documentTitles["targetmanagement.html#create-a-wtc-file"] = "Create a WTC file";
index.add({
    url: "targetmanagement.html#create-a-wtc-file",
    title: "Create a WTC file",
    body: "#### Create a WTC file  - AR.TargetCollectionResource WTC (Wikitude Target Collection) file which contains all information of the targets that should be recognized. Enter the project you need the file for and click the *WTC icon* in the toolbar.  &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/tmt_CreateTargetCollection.png\&quot;&gt;  - Select the Wikitude SDK version you're using and click *Generate* to trigger the creation of the WTC file. You will be notified via e-Mai once the file is available for download.  &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/tmt_TargetCollections.png\&quot;&gt;    "
});

documentTitles["targetmanagement.html#use-projects-wtc-file-in-your-app"] = "Use project's WTC file in your app";
index.add({
    url: "targetmanagement.html#use-projects-wtc-file-in-your-app",
    title: "Use project's WTC file in your app",
    body: "### Use project's WTC file in your app   Look at one of the [client recognition examples](clientrecognitionnative.html) or refer to the relevant reference for instructions on how to use the created target collection for augmentations in your ARchitect Worlds.   "
});

documentTitles["targetmanagement.html#image-targets-for-cloud-recognition"] = "Image Targets for Cloud Recognition";
index.add({
    url: "targetmanagement.html#image-targets-for-cloud-recognition",
    title: "Image Targets for Cloud Recognition",
    body: "### Image Targets for Cloud Recognition  Any existing project may also be published to the Cloud to make it accessible for [`AR.CloudRecognitionService`] (architectapi://reference/classes/CloudRecognitionService.html).  Click the *Cloud icon* in the toolbar for more details.  &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/tmt_CloudIcon.png\&quot;&gt;  Cloud Recognition is available for free in your testing process but you must purchase a license for productive use. [Learn more](http://www.wikitude.com/external/doc/documentation/latest/cloudrecognition/gettingstartedcloudrecognition.html#quota-and-limits)  &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/tmg_CloudPublishing.png\&quot;&gt;  Once a project is published it is accessible via Wiktiude SDK using 'Client Token' and 'Target Collection ID' (compare [`AR.CloudRecognitionService`](architectapi://reference/classes/CloudRecognitionService.html))  &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/tmt_CloudTracker.png\&quot;&gt;  Hints  - You may unpublish a project at any time but be aware that this action has immediate effect on your application(s) making use of the credentials.  - **Metadata** in the 'Edit Target' dialog is solely relevant for Cloud Recognition whereat **Physical Height** is only relevant for distanceToTarget feature.  - Leave **Physical Height** empty if you do not use the distanceToTarget feature of [`AR.ImageTrackable`](architectapi://reference/classes/ImageTrackable.html).  - The **Metadata** field is very useful. It allows you to attach JSON data to a target. That way you can define any kind of additional data and react on it dynamically in the SDK to e.g. let a button refer to a details page which is defined in the Metadata JSON.  &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/tmt_CloudTargetEdit.png\&quot;&gt;   "
});

documentTitles["targetmanagement.html#physical-height-for-image-targets"] = "Physical Height for Image Targets";
index.add({
    url: "targetmanagement.html#physical-height-for-image-targets",
    title: "Physical Height for Image Targets",
    body: "### Physical Height for Image Targets   For several features of the Wikitude SDK it is necessary to know the actual physical size of the Image target that is recognized. This information is used in  * Distance to target calculation * Calibrated wearable devices like Epson BT series or ODG R series devices  The Wikitude SDK only requires the actual height of the target image as information. The width of the actual image will be determined automatically.    There are three ways to provide that information to the Wikitude SDK  1. Using Wikitude Studio 2. Using the JavaScript API 3. Using Unity WTC Editor   "
});

documentTitles["targetmanagement.html#setting-physical-target-height-using-wikitude-studio"] = "Setting physical target height using Wikitude Studio";
index.add({
    url: "targetmanagement.html#setting-physical-target-height-using-wikitude-studio",
    title: "Setting physical target height using Wikitude Studio",
    body: "#### Setting physical target height using Wikitude Studio  Wikitude Studio is the most universal way to add target height information. The tool allows to add the value for each image. The height information (`physical target height`) is then stored as part of the Image Target Collection (.wtc) and will be then automatically applied in the SDK.   1. Add a target image 2. Click `Properties` 3. Add the value in the properties dialog 4. Click Save 5. Export as .wtc file  ![](images/targetmanager_target_height.jpg)    "
});

documentTitles["targetmanagement.html#setting-physical-target-height-using-javascript-api"] = "Setting physical target height using JavaScript API";
index.add({
    url: "targetmanagement.html#setting-physical-target-height-using-javascript-api",
    title: "Setting physical target height using JavaScript API",
    body: "#### Setting physical target height using JavaScript API  The JavaScript API allows you to set the value for target images dynamically using the [`physicalTargetImageHeights`](architectapi://reference/classes/ImageTracker.html#property_physicalTargetImageHeights) option of the `ImageTracker`.   "
});

documentTitles["targetmanagement.html#setting-physical-target-height-using-unity-wtc-editor"] = "Setting physical target height using Unity WTC Editor";
index.add({
    url: "targetmanagement.html#setting-physical-target-height-using-unity-wtc-editor",
    title: "Setting physical target height using Unity WTC Editor",
    body: "#### Setting physical target height using Unity WTC Editor  The WTC Editor included in the Unity Plugin of the Wikitude SDK also includes an option to set the physical target height (Target Height), which then stores the value into the .wtc file.   ![](images/unity_wtc_editor_window.png)   "
});

documentTitles["targetmanagement.html#object-targets-create-and-manage"] = "Object Targets: Create and Manage";
index.add({
    url: "targetmanagement.html#object-targets-create-and-manage",
    title: "Object Targets: Create and Manage",
    body: "## Object Targets: Create and Manage  The object recognition feature in the Wikitude SDK works in a similar way than image recognition. It tries to find and match a pre-created reference in the live camera image. This pre-created reference is called **Object Target**. Sometimes we refer to it as a _map_ as it is a pre-recorded SLAM map. Object Targets are created from videos files, that show the object. The video is converted into **Wikitude Object Target Collection**, which is stored as `.wto` file.  The standard process looks like the following:  1. Create a video of the object  2. Convert the video into a Wikitude Object Target Collection (`.wto`) 3. Use the `.wto` file in your app project. Let's have a closer look at the first two steps:   "
});

documentTitles["targetmanagement.html#create-a-video-of-your-object"] = "Create a video of your object";
index.add({
    url: "targetmanagement.html#create-a-video-of-your-object",
    title: "Create a video of your object",
    body: "### Create a video of your object  This part is essential, as the ObjectTarget can only be as good as the source video material. You shoot videos on your own or have them generated as part of your 3D/CAD modeling software. Supported video formats are  * mp4 * mov  [Please refer to this guide for an optimal video](objecttargetguide.html)   "
});

documentTitles["targetmanagement.html#convert-video-into-object-target-collection"] = "Convert video into Object Target Collection";
index.add({
    url: "targetmanagement.html#convert-video-into-object-target-collection",
    title: "Convert video into Object Target Collection",
    body: "### Convert video into Object Target Collection  There are two ways to convert a video into a Object Target Collection  1. Use Studio Manager web front-end 2. Use RESTful APIs of the Cloud Recognition Manager API  Both ways correspond to how you generate Image Target Collections.    "
});

documentTitles["targetmanagement.html#using-studio-manager"] = "Using Studio Manager";
index.add({
    url: "targetmanagement.html#using-studio-manager",
    title: "Using Studio Manager",
    body: "#### Using Studio Manager  You might have used Studio Manager already when working with Image Targets. Studio Manager is a free web-tool that helps you manage your Targets that are used in combination with the Wikitude SDK.   ![](images/targetmgmr_object_project.png)  1. Log-in to [Studio Manager](https://targetmanager.wikitude.com) with your Wikitude developer account 1. Create Project for Object Targets by selecting `Object` as type for the new project  ![](images/targetmgmr_object_type.png)  2. Enter the project 2. Add a new _Object Target_ and  2. Upload a video from the object (see previous chapter)  ![](images/targetmgmr_upload_video.png)  3. Select recording device or FOV - For creating the Object Target file the service needs to know, which device the video was taken on. The relevant piece of information is the _Field of View_ or _FoV_ of the camera, which tells how much a camera can see. Wikitude provides a list of common devices, where this value is already known. So either select the device or manually enter this value under the option `Custom` 	* When you enter the FoV manually, make sure you enter the **horizontal FoV**. Vendors tend to to show-off their devices with a combined _diagonal FoV_, which is the largest value. Do not use _diagonal FoV_ but only ** horizontal FoV**.   ![](images/targetmgmr_fov.png)  4. Wait for conversion to be finished - the service is performing several runs in the background to find the best possible configuration for your video. Conversion will minimum take 3-times the video run length. So a 50 seconds video will take minimum take nearly 3 minutes to finish. Depending on the current load, this can also take longer. You will be notified via email once the process has finished.  5. Download `.wto` file and embed it into your application (see the [sample](objecttracking.html) for details how to use it.)  ![](images/targetmgmr_download_wto.png)   "
});

documentTitles["targetmanagement.html#using-restful-manager-api"] = "Using RESTful Manager API";
index.add({
    url: "targetmanagement.html#using-restful-manager-api",
    title: "Using RESTful Manager API",
    body: "#### Using RESTful Manager API  Studio Manager can also be accessed through a RESTful API. The API is part of the Cloud Recognition Manager API. "
});



documentTitles["targetguide.html#best-practice-for-image-targets"] = "Best practice for Image Targets";
index.add({
    url: "targetguide.html#best-practice-for-image-targets",
    title: "Best practice for Image Targets",
    body: "## Best practice for Image Targets This guide gives you an overview of how to create a target collection that you can use to detect and track images within your ARchitect World.  "
});

documentTitles["targetguide.html#summary"] = "Summary";
index.add({
    url: "targetguide.html#summary",
    title: "Summary",
    body: "### Summary  **Preferred images have:**  - between 500 to 1000 pixels in each dimension - Rich contrast - Evenly distributed textured areas - Many corner like structures  **Unsuitable images have:**  - Smaller dimensions than 500 pixels - Larger than 1000 pixels as they do not provide more accurate results - Large amounts of text - Many repetitive patterns - Large single-colored areas  - Color contrast only e.g. green to red edge), because all images are processed as grayscale images   "
});

documentTitles["targetguide.html#optimal-image-dimensions"] = "Optimal Image Dimensions";
index.add({
    url: "targetguide.html#optimal-image-dimensions",
    title: "Optimal Image Dimensions",
    body: "### Optimal Image Dimensions  - Optimal images are sized between 500 and 1000 pixels in each dimension - Small images do not contain enough graphical information to extract so called feature points. The uniqueness, amount and distribution of features points are the key indicators for good detection and tracking quality - Larger images do not improve the tracking quality ![Target image too small](images/guide_dimension_wrong.png) ![Optimal size of target image](images/guide_dimension_good.png)  "
});

documentTitles["targetguide.html#low-contrast-images"] = "Low contrast images";
index.add({
    url: "targetguide.html#low-contrast-images",
    title: "Low contrast images",
    body: "### Low contrast images  - Images with high local contrast and large amount of rich textured areas is best suited for reliable detection and tracking - Color contrast only (i.e. green to red edge) appears as high contrast to the human eye but is not discriminative to computer vision algorithms as they are operating on grayscale images ***Tip***: For low contrast images, try to increase the contrast of your target image with an image editing tool like Gimp or PhotoShop to improve detection and tracking quality  ![Target image with low contrast](images/low_contrast_wrong.png) ![Target image with good contrast](images/low_contrast_good.png)  "
});

documentTitles["targetguide.html#distribution-of-textured-areas"] = "Distribution of textured areas";
index.add({
    url: "targetguide.html#distribution-of-textured-areas",
    title: "Distribution of textured areas",
    body: "### Distribution of textured areas  - Images with evenly distributed textured areas are good candidates for reliable detection and tracking - This might be the hardest part to be in control of and often can’t be changed. ***Tip***: Try to crop the most prominent part of your image and use only this as target image.  ![Target image with not optimal distribution](images/texture_distribution_wrong.png) ![Even distribution of features](images/texture_distribution_good.png)  "
});

documentTitles["targetguide.html#images-with-whitespace"] = "Images with whitespace";
index.add({
    url: "targetguide.html#images-with-whitespace",
    title: "Images with whitespace",
    body: "### Images with whitespace  - Single-colored areas or smooth color transitions often found in backgrounds do not exhibit graphical information suitable for detection and tracking.  ***Tip***: Try to crop the most prominent part of your image and use only this as target image.  ![Too much whitespace](images/whitespace_wrong.png) ![Image reduced to the most relevant part](images/whitespace_good.png)  "
});

documentTitles["targetguide.html#vector-based-graphics"] = "Vector-based graphics";
index.add({
    url: "targetguide.html#vector-based-graphics",
    title: "Vector-based graphics",
    body: "### Vector-based graphics   - Logos and vector-based graphics usually consist of very few areas with high local contrast and textured structures and are therefore hard to detect and track.   ***Tip***: Try to add additional elements to the graphic like your logotype or any other specific elements, which can go along with your graphic.  ![Vector-based image](images/vector_wrong.png) ![Target image mixed with graphic elements](images/vector_good.png)  "
});

documentTitles["targetguide.html#images-with-a-lot-of-text"] = "Images with a lot of text";
index.add({
    url: "targetguide.html#images-with-a-lot-of-text",
    title: "Images with a lot of text",
    body: "### Images with a lot of text - Images consisting primarily of large areas of text are hard to detect and track.  ***Tip***: Try to have at least some graphical material and images next to your text for your target image.  ![Pure text](images/text_wrong.png) ![Text mixed with graphic elements](images/text_good.png)  "
});

documentTitles["targetguide.html#repetitive-patterns"] = "Repetitive patterns";
index.add({
    url: "targetguide.html#repetitive-patterns",
    title: "Repetitive patterns",
    body: "### Repetitive patterns  - Repetitive patterns exhibit the same graphical information information at each feature point and therefore cannot be localized reliably - Images with slightly irregular structures can convey a similar information to the target audience while providing enough unique feature points to be detected (second image)  ***Tip***: Try a different selection of your image including non pattern parts or use images with irregular patterns  ![Repetitive patterns that do not track](images/patterns_wrong.png) ![Pattern with irregular structures](images/patterns_good.png) "
});



documentTitles["objecttargetguide.html#best-practice-for-object-targets"] = "Best practice for Object Targets";
index.add({
    url: "objecttargetguide.html#best-practice-for-object-targets",
    title: "Best practice for Object Targets",
    body: "## Best practice for Object Targets  "
});

documentTitles["objecttargetguide.html#characteristics-of-easy-trackable-objects"] = "Characteristics of easy trackable objects";
index.add({
    url: "objecttargetguide.html#characteristics-of-easy-trackable-objects",
    title: "Characteristics of easy trackable objects",
    body: "### Characteristics of easy trackable objects  * Structure and size of the object are very important. Very small objects (&lt; 5cm/2-inch) are challenging as well. * Object should be more or less static. Dynamic and deformable parts are ok, as long as the majority of the object stays static. Try to record only the static parts of your object. * Shiny and glossy surfaces on the objects are challenging. Again it depends on the amount of glossy surfaces in the object.  "
});

documentTitles["objecttargetguide.html#how-to-create-a-video-as-input-for-object-targets"] = "How to create a video as input for Object Targets";
index.add({
    url: "objecttargetguide.html#how-to-create-a-video-as-input-for-object-targets",
    title: "How to create a video as input for Object Targets",
    body: "### How to create a video as input for Object Targets   "
});

documentTitles["objecttargetguide.html#general-information"] = "General information";
index.add({
    url: "objecttargetguide.html#general-information",
    title: "General information",
    body: "#### General information This article should help you with the creation of a video which is needed for Wikitude’s Object Recognition feature. We want to explain how to make sure the object is lightened properly, how to avoid disturbing scenery around the object and how to make sure you can capture the object from all sides.  "
});

documentTitles["objecttargetguide.html#setup"] = "Setup";
index.add({
    url: "objecttargetguide.html#setup",
    title: "Setup",
    body: "#### Setup Make sure you find a room with enough space to move around freely and a table, where you can place your object on.  "
});

documentTitles["objecttargetguide.html#lighting"] = "Lighting";
index.add({
    url: "objecttargetguide.html#lighting",
    title: "Lighting",
    body: "#### Lighting One of the major factors to get a good working Object Target for object recognition is proper lighting. To achieve this soft boxes work really well. They are also rather cheap and easy available. We recommend soft boxes with a tripod and 3 boxes to place them around the object for homogeneous light conditions.    ![Softboxes give proper light](images/objreco_softboxes.jpg)   "
});

documentTitles["objecttargetguide.html#background"] = "Background";
index.add({
    url: "objecttargetguide.html#background",
    title: "Background",
    body: "#### Background To avoid tracking items in the background, it is helpful to mount a photo studio background behind and beneath the object. It is important to have a soft curve from the wall to the table or floor, to avoid edges in the background.  ![White noise-free background](images/objreco_background.jpg)    "
});

documentTitles["objecttargetguide.html#rotating-turntable"] = "Rotating turntable";
index.add({
    url: "objecttargetguide.html#rotating-turntable",
    title: "Rotating turntable",
    body: "#### Rotating turntable To be able to recognize the object from all sides it is necessary to capture it from all sides. This is much easier if you place the object on a rotating turntable, a rotating cake stand or something similar and which works for the size of your object. Make sure that the surface is non-reflecting and in the same color as the background.  ![DIY rotating platform](images/objreco_turntable.jpg)   "
});

documentTitles["objecttargetguide.html#filming"] = "Filming";
index.add({
    url: "objecttargetguide.html#filming",
    title: "Filming",
    body: "#### Filming For the filming make sure you find a good camera. A newer smartphone should work well and if you can change the exposure value, even better. Sometimes it is necessary to reduce the exposure value to stop flickering because of fluorescent light bulbs. You will recognize this immediately watching your video.  "
});

documentTitles["objecttargetguide.html#re-encode-for-smaller-file-size"] = "Re-encode for smaller file size";
index.add({
    url: "objecttargetguide.html#re-encode-for-smaller-file-size",
    title: "Re-encode for smaller file size",
    body: "#### Re-encode for smaller file size We recommend to re-encode the video before uploading to video. Make sure you keep aspect-ratio of the video while doing so. There are several tools that re-encode videos reliably and fast. We have been using [Handbrake for Mac](https://handbrake.fr/), which shows pretty good results. Again make sure you don't change the aspect-ratio of the video while re-encoding.  **Some important general advices:** Please read carefully!  * Start with a sideway movement in the beginning, that is parallel to the object. * Objects should be placed in the center (as big as possible to reduce background noise) * Move slowly when capturing the object * If you don't want to recognize the object from a particular side you also don't have to capture it. * Film from different distances if you want to recognize the object from different distances. * Recording should be done in landscape * The video should be a few seconds long (10 seconds or longer) * Shadows in the video are treated like they belong to the object. * While moving closer will get you more details, try not to capture the object at close range. * Just capture the sides that you actually want the object to be recognizable from.  * Do not crop the video frame and by that change the aspect ratio of the video. * Re-encoding into a different codec is fine. Also scaling the video, while keeping the same aspect ratio is fine.   Make sure you place the object stable on the rotating turntable, choose a side of the object with some structure and start capturing the video. Move close to the object to get some details, move back, get the upper part of the object and cover the whole surface of the current side. Now start rotating the object and capture the object from all sides. While rotating try to get some interesting details with good structure, this will increase the stability of the recognition and tracking. When you captured the object from all sides stop recording and check if there is no flickering and the video is looking good.  ![Infographic of recording](images/WT_ObjectRecording.jpg)  ![Overall setup with object](images/objreco_filming.jpg)  ![Overall setup](images/objreco_full_setup.jpg)    "
});

documentTitles["objecttargetguide.html#using-3d-or-cad-software"] = "Using 3D or CAD software";
index.add({
    url: "objecttargetguide.html#using-3d-or-cad-software",
    title: "Using 3D or CAD software",
    body: "#### Using 3D or CAD software  Of course you don't have to shoot the video of your object on your own, but can use a rendered video from any 3D modeling or CAD software. If you do so, choose a similar rendering path as described above.   * First few seconds parallel movement (translation) * Rotation around the object * Capturing top-side * Zoom out and in again  Make sure you export your rendering in one of the supported formats (`mp4` or `mov`).  "
});

documentTitles["objecttargetguide.html#sample-of-a-video"] = "Sample of a video";
index.add({
    url: "objecttargetguide.html#sample-of-a-video",
    title: "Sample of a video",
    body: "#### Sample of a video  This is the video we were using as source for creating an Object Target for our sample application (the fire toy truck).  [![](images/video_youtube_object_reco.png)](https://www.youtube.com/watch?v=eY8B2A_OYF8)   "
});



documentTitles["targetversioning.html#targets-versioning"] = "Targets Versioning";
index.add({
    url: "targetversioning.html#targets-versioning",
    title: "Targets Versioning",
    body: "## Targets Versioning  "
});

documentTitles["targetversioning.html#image-targets"] = "Image Targets";
index.add({
    url: "targetversioning.html#image-targets",
    title: "Image Targets",
    body: "### Image Targets Over time the format and the capabilities of Wikitude's target collection data format have changed. The following table summarizes which version of the Wikitude SDK can handle which wtc version. Wikitude Studio Manager is capable of producing wtc files compatible with all mentioned versions. If you need to re-create a target collection go there and select the appropriate SDK version.  &lt;table&gt;     &lt;tr&gt;         &lt;th&gt;&lt;/th&gt;         &lt;th&gt;Wikitude SDK 3.x&lt;/th&gt;         &lt;th&gt;Wikitude SDK 4.0&lt;/th&gt;         &lt;th&gt;Wikitude SDK 4.1&lt;/th&gt;         &lt;th&gt;Wikitude SDK 5.0&amp;nbsp;&amp;#8209;&amp;nbsp;5.3&lt;/th&gt;         &lt;th&gt;Wikitude SDK 6.0&amp;nbsp;&amp;#8209;&amp;nbsp;7.2&lt;/th&gt;     &lt;/tr&gt;     &lt;tr&gt;         &lt;td&gt;wtc&amp;nbsp;3.x&lt;/td&gt;         &lt;td class=\&quot;supported\&quot;&gt;supported&lt;/td&gt;         &lt;td class=\&quot;supported\&quot;&gt;supported&lt;/td&gt;         &lt;td class=\&quot;supported\&quot;&gt;supported&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;     &lt;/tr&gt;     &lt;tr&gt;         &lt;td&gt;wtc&amp;nbsp;4.0&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;         &lt;td class=\&quot;supported\&quot;&gt;supported&lt;/td&gt;         &lt;td class=\&quot;supported\&quot;&gt;supported&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;         &lt;/tr&gt;      &lt;tr&gt;         &lt;td&gt;wtc&amp;nbsp;4.1&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;         &lt;td class=\&quot;supported\&quot;&gt;supported&lt;/td&gt;         &lt;td class=\&quot;supported\&quot;&gt;supported&lt;/td&gt;         &lt;td class=\&quot;supported\&quot;&gt;supported&lt;/td&gt;       &lt;/tr&gt;      &lt;tr&gt;         &lt;td&gt;wtc&amp;nbsp;5.0&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;         &lt;td class=\&quot;not-supported\&quot;&gt;not supported&lt;/td&gt;         &lt;td class=\&quot;supported\&quot;&gt;supported&lt;/td&gt;      &lt;/tr&gt; &lt;/table&gt;    "
});



documentTitles["unitywtceditor.html#unity-wtc-editor"] = "Unity WTC Editor";
index.add({
    url: "unitywtceditor.html#unity-wtc-editor",
    title: "Unity WTC Editor",
    body: "## Unity WTC Editor  Version 1.2.0 of the Unity plugin includes a brand new `WTC Editor` that allows you to create and modify wtc collections right inside the Unity Editor without the need to go through Wikitude Studio.  "
});

documentTitles["unitywtceditor.html#overview-of-wtc-editor"] = "Overview of WTC Editor";
index.add({
    url: "unitywtceditor.html#overview-of-wtc-editor",
    title: "Overview of WTC Editor",
    body: "### Overview of WTC Editor  To open the WTC Editor, click on the `Window` menu item and select `WTC Editor`.   &lt;img style=\&quot;width: 100px\&quot; src=\&quot;images/unity_wtc_editor_menu.png\&quot;&gt;  This will open a new dockable window that allows you to manage all your target collections.  &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/unity_wtc_editor_window.png\&quot;&gt;  On the left side you will find the project panel, which contains a tree view of all the wtc files found in the `StreamingAssets` folder. Selecting any of these will display a grid of all the targets in that collection in the middle view. Clicking any of these targets will display additional info about it on the right side of the editor window.  "
});

documentTitles["unitywtceditor.html#create-target-collection-in-wtc-editor"] = "Create target collection in WTC Editor";
index.add({
    url: "unitywtceditor.html#create-target-collection-in-wtc-editor",
    title: "Create target collection in WTC Editor",
    body: "### Create target collection in WTC Editor To create a new collection, click the `Create` button in the upper part of the left panel.  &lt;img style=\&quot;width: 200px\&quot; src=\&quot;images/unity_wtc_editor_create.png\&quot;&gt;  A new window will appear prompting you to select an image from your project.   &lt;img style=\&quot;width: 300px\&quot; src=\&quot;images/unity_wtc_editor_creation_select.png\&quot;&gt;  A new collection will be created in the `StreamingAssets` folder with the same name as the selected image. To rename the collection, simply rename the file in the Unity editor project view or in Windows Explorer / Finder. The collection will initially contain only the selected image, but you can edit it further by adding new ones.  &lt;img style=\&quot;width: 200px\&quot; src=\&quot;images/unity_wtc_editor_creation_after.png\&quot;&gt;  "
});

documentTitles["unitywtceditor.html#edit-target-collection"] = "Edit target collection";
index.add({
    url: "unitywtceditor.html#edit-target-collection",
    title: "Edit target collection",
    body: "### Edit target collection  "
});

documentTitles["unitywtceditor.html#add-images-to-a-target-collection"] = "Add images to a target collection";
index.add({
    url: "unitywtceditor.html#add-images-to-a-target-collection",
    title: "Add images to a target collection",
    body: "#### Add images to a target collection  You can add new images to a target collection by clicking the `Add` button from the upper part of the middle panel. This will open a new window asking you to select which image to add. You can also drag and drop multiple images at once from the Unity editor project view.  &lt;img style=\&quot;width: 400px\&quot; src=\&quot;images/unity_wtc_editor_add.png\&quot;&gt;  "
});

documentTitles["unitywtceditor.html#remove-images-from-a-target-collection"] = "Remove images from a target collection";
index.add({
    url: "unitywtceditor.html#remove-images-from-a-target-collection",
    title: "Remove images from a target collection",
    body: "#### Remove images from a target collection  You can select targets by clicking on them in the middle panel. Using Shift and Ctrl/Cmd allows you to select multiple images at once. You can delete the selected targets by pressing the `Delete` button in the upper part of the middle panel.  &lt;img style=\&quot;width: 400px\&quot; src=\&quot;images/unity_wtc_editor_remove.png\&quot;&gt;  "
});

documentTitles["unitywtceditor.html#modify-target-collections"] = "Modify target collections";
index.add({
    url: "unitywtceditor.html#modify-target-collections",
    title: "Modify target collections",
    body: "#### Modify target collections  When a single target is selected, additional info about it will be displayed in the right panel. Here you can also rename the target and change it's physical height, specified in millimeters. The default value of `-1` means that the physical height is not set.  &lt;img style=\&quot;width: 300px\&quot; src=\&quot;images/unity_wtc_editor_target_info.png\&quot;&gt;  "
});

documentTitles["unitywtceditor.html#save-and-discard-changes"] = "Save and discard changes";
index.add({
    url: "unitywtceditor.html#save-and-discard-changes",
    title: "Save and discard changes",
    body: "#### Save and discard changes  All modifications made to the collection are cached and applied to the actual collection only when you hit the `Apply` button in the upper part of the window. You can also discard any changes made to a collection by pressing the `Revert` button.   &lt;img style=\&quot;width: 500px\&quot; src=\&quot;images/unity_wtc_editor_apply.png\&quot;&gt;  If a collection has unsaved modifications, an asterisk symbol `*` will appear next to its name in the left panel.  &lt;img style=\&quot;width: 200px\&quot; src=\&quot;images/unity_wtc_editor_modified.png\&quot;&gt;  &lt;div class=\&quot;warning\&quot;&gt; **Important** &lt;br /&gt; Make sure you save all your modifications before closing Unity or your changes will be lost!&lt;/div&gt; "
});



documentTitles["reference.html#reference"] = "Reference";
index.add({
    url: "reference.html#reference",
    title: "Reference",
    body: "# Reference            "
});

documentTitles["reference.html#unity-plugin-reference"] = "Unity Plugin Reference";
index.add({
    url: "reference.html#unity-plugin-reference",
    title: "Unity Plugin Reference",
    body: "## Unity Plugin Reference Go to [Unity Plugin Reference](unityapi://annotated.html) for a complete reference of all Unity Wikitude Plugin objects and functions.  The Unity scripting reference can be found [here.](http://docs.unity3d.com/Documentation/ScriptReference/index.html)          "
});

documentTitles["reference.html#cloud-recognition-manager-api"] = "Cloud Recognition Manager API";
index.add({
    url: "reference.html#cloud-recognition-manager-api",
    title: "Cloud Recognition Manager API",
    body: "## Cloud Recognition Manager API  Go to [REST API Reference](https://www.wikitude.com/documentation/latest/Reference/Cloud%20Recognition%20REST%20API/index.html) for a complete reference of all REST API calls for the Manager API.   "
});



documentTitles["migration-unity.html#migration-notes"] = "Migration Notes";
index.add({
    url: "migration-unity.html#migration-notes",
    title: "Migration Notes",
    body: "# Migration Notes  Migration notes for the Wikitude Unity Plugin  "
});

documentTitles["migration-unity.html#migrate-from-710-to-720"] = "Migrate from 7.1.0 to 7.2.0";
index.add({
    url: "migration-unity.html#migrate-from-710-to-720",
    title: "Migrate from 7.1.0 to 7.2.0",
    body: "## Migrate from 7.1.0 to 7.2.0 The minimum Unity version was increased to 5.4.2.  Initialization of `WikitudeCamera` and the internal SDK was moved from `Awake` to `Start`. This means WikitudeCamera properties can now be easily changed from script, as long they are done before the `Start` method is called on the `WikitudeCamera`.  `ImageTracker` and `InstantTracker` now have a new option called `Legacy Scale`. In previous versions of the plugin, the augmentations needed to be scaled by a factor of 10 to match their targets. In the new version, this is no longer required. However, for backwards compatibility, the `Legacy Scale` allows developers to re-enable the old behavior. Keep in mind that this option will be removed in future versions and is only intended to ease the transition of existing projects.  "
});

documentTitles["migration-unity.html#migrate-from-700-to-710"] = "Migrate from 7.0.0 to 7.1.0";
index.add({
    url: "migration-unity.html#migrate-from-700-to-710",
    title: "Migrate from 7.0.0 to 7.1.0",
    body: "## Migrate from 7.0.0 to 7.1.0 No changes.  "
});

documentTitles["migration-unity.html#migrate-from-210-to-700"] = "Migrate from 2.1.0 to 7.0.0";
index.add({
    url: "migration-unity.html#migrate-from-210-to-700",
    title: "Migrate from 2.1.0 to 7.0.0",
    body: "## Migrate from 2.1.0 to 7.0.0 Version 7.0.0 increases the minimum required version for Unity to 5.4.0. Please make sure to also upgrade Unity if you are using an older version, otherwise the plugin will not work properly. Version 7.0.0 also increases the minimum iOS version to 9.0 and the minimum Android version to Android 4.4(19). Please update `minSdkVersion` to 19 in the manifest of your App or build.gradle if you export to a gradle project.  To align the Unity API with that of the Wikitude Native SDK, the general `TrackableBehaviour` component has been deprecated, and was replaced with `ImageTrackable`, `ObjectTrackable` and `InstantTrackable`. These new trackables also have different events. So instead of the generic `OnEnterFieldOfVision` from the previous version, the `ImageTrackable` has an equivalent `OnImageRecognized` event, with an `ImageTarget` parameter, instead of just a string. Similar events are present in the other trackers. When you update to the new API, please make sure to never mix the new `Trackables` with the deprecated `TrackableBehaviour`, as this is not supported.  The new `Trackable` components now have an additional `Drawable` field. This was added to support multiple targets for `ImageTrackers`, but the API is available for all `Trackables`. Please see the [Image Tracking](ImageRecognitionNative.html) examples for more information about multiple targets.  Additionally, some sample scripts were renamed. If you are upgrading and importing the samples as well, please check fo duplicate scripts, or for scripts that should not be present in the project anymore.  "
});

documentTitles["migration-unity.html#migrate-from-200-to-210"] = "Migrate from 2.0.0 to 2.1.0";
index.add({
    url: "migration-unity.html#migrate-from-200-to-210",
    title: "Migrate from 2.0.0 to 2.1.0",
    body: "## Migrate from 2.0.0 to 2.1.0 Version 2.1.0 adds a new value to the FrameColorSpace enum used for Plugins and Input Plugins. Because of this, when loading a scene that contains a WikitudeCamera component configured to use Input Plugins, the deserialized value of the enum will be incorrect. Please set it to the appropriate value for your use case after upgrading to 2.1.0.  "
});

documentTitles["migration-unity.html#migrate-from-140-to-200"] = "Migrate from 1.4.0 to 2.0.0";
index.add({
    url: "migration-unity.html#migrate-from-140-to-200",
    title: "Migrate from 1.4.0 to 2.0.0",
    body: "## Migrate from 1.4.0 to 2.0.0 Version 2.0.0 deprecates the `ClientTracker` and the `CloudTracker` classes. When before you used the `ClientTracker` to recognize images, it is recommended to switch to the new `ImageTracker`, in combination with a `TargetCollectionResource`. Instead of the `CloudTracker`, the same `ImageTracker` can be used, but with a `CloudRecognitionService`, instead. You can select between the `TargetCollectionResource` and the `CloudRecognitionService` in the `ImageTracker` inspector, in the first dropdown menu. Finally, if you used the `ClientTracker` to track 3D targets, you can now use the new `ObjectTracker` with a `TargetCollectionResource` for this.  To help migrate your project to the new APIs, the inspectors of the old classes have a button that allows you to automatically upgrade the script component with the appropriate replacement.  ![](images/unity_upgrade_deprecated_tracker.png)  When you press the button, a warning message will appear, informing you that during the upgrade process, the properties set on the old tracker will be migrated to the new one, but events will **not**. This would not be possible, because in most cases you need to update the script functions receiving the events to the appropriate signature.  ![](images/unity_upgrade_warning.png)  After pressing OK, GameObject will have the new component instead. If you are not happy with the result, or something went wrong, you can undo this operation.  ![](images/unity_after_upgrade.png)  Keep in mind that you still need to update the source code, where references to the old trackers are used.  For example, the `Runtime Tracker` sample used to create a `ClientTracker` with a custom remote URL.  ```csharp GameObject trackerObject = new GameObject(\&quot;ClientTracker\&quot;); _currentTracker = trackerObject.AddComponent&lt;ClientTracker&gt;(); _currentTracker.UseCustomUrl = true; _currentTracker.TargetPath = Url.text;  _currentTracker.OnTrackerFinishedLoading.AddListener(OnTrackerFinishedLoading); _currentTracker.OnTrackerLoadingError.AddListener(OnTrackerLoadingError); ```  Here is how the sample would look like when using the new `ImageTracker` and APIs. ```csharp GameObject trackerObject = new GameObject(\&quot;ImageTracker\&quot;); _currentTracker = trackerObject.AddComponent&lt;ImageTracker&gt;(); _currentTracker.TargetSourceType = TargetSourceType.TargetCollectionResource; _currentTracker.TargetCollectionResource = new TargetCollectionResource(); _currentTracker.TargetCollectionResource.UseCustomURL = true; _currentTracker.TargetCollectionResource.TargetPath = Url.text;  _currentTracker.TargetCollectionResource.OnFinishLoading.AddListener(OnFinishLoading); _currentTracker.TargetCollectionResource.OnErrorLoading.AddListener(OnErrorLoading);  _currentTracker.OnTargetsLoaded.AddListener(OnTargetsLoaded); _currentTracker.OnErrorLoadingTargets.AddListener(OnErrorLoadingTargets); ```  The old trackers are still kept for backwards compatibility, but will be removed in a future version, so please update to the new ones.  Additionally, the CloudTrackable was removed from the samples. If you are upgrading from an older version, please make sure that this script is no longer in your projects, otherwise you might encounter compilation errors.  "
});

documentTitles["migration-unity.html#migrate-from-110-to-120"] = "Migrate from 1.1.0 to 1.2.0";
index.add({
    url: "migration-unity.html#migrate-from-110-to-120",
    title: "Migrate from 1.1.0 to 1.2.0",
    body: "## Migrate from 1.1.0 to 1.2.0 Version 1.2.0 simplifies the `WikitudeCamera` prefab. It is now a single GameObject, without the hierarchy it previously had. If you had any changes to the prefab, except for the license key, please make sure to back it up first.   Because the previous hierarchy is gone, the camera feed is no longer explicitly exposed in the editor, but you can still access it through the `CameraTexture` property on the `WikitudeCamera` script.  "
});

documentTitles["migration-unity.html#migrate-from-101-to-110"] = "Migrate from 1.0.1 to 1.1.0";
index.add({
    url: "migration-unity.html#migrate-from-101-to-110",
    title: "Migrate from 1.0.1 to 1.1.0",
    body: "## Migrate from 1.0.1 to 1.1.0 Version 1.1.0 contains **many breaking changes to the plugin**, so before upgrading, please backup your project, to prevent accidentally losing your work.  Wikitude classes are now concrete and sealed and expose Unity events to communicate. This means that now you can add them directly to game objects and subscribe to their events through the editor or at runtime in code. When adding subscribers to events, make sure you use the dynamic version of your method, when there is a choice between static and dynamic (please see the [Client Recognition](clientrecognitionnative.html) examples for more information on how to set up Client Trackers).  Values that were set in the inspector for these classes will need to be reset because of the change in class name and their internal representation.  The classes that previously derived from them will no longer work, so they need to be updated to receive events. On your game objects, you will get missing mono classes after updating. These should be replaced with the corresponding classes in the Wikitude plugin (Wikitude/Dependencies/WikitudeUnityPlugin) and the values need to be reintroduced.   All function names in Wikitude classes now begin with a capital letter.  When building for iOS, if you choose to append over a build made with a previous version, you will end up with two versions of the Wikitude plugin in your project, one located in Plugins/iOS and the new one in Plugins/Wikitude/iOS. Please make sure that only the new one is used. Alternatively, you can redo the build from scratch using the steps from the [Setup Guide](setupguideunity.html) section.  "
});

documentTitles["migration-unity.html#migration-example"] = "Migration Example";
index.add({
    url: "migration-unity.html#migration-example",
    title: "Migration Example",
    body: "#### Migration Example This section will show how to migrate the example project from version 1.0.1 to work with the new version of the plugin.  1. `(Optional)` Delete the `Dependencies`, `Editor` and `Plugins` folders. The plugin folder has changed drastically in this version. If you don't delete these folders, the correct files should still be replaced with the new version. However, the samples will not work correctly because magazine.wtc will be in `StreamingAssets` folder instead of `StreamingAssets/Wikitude`. Since we won't be using the samples in this example, this step can be skipped. 2. Delete the `Wikitude/Samples` folder. The `Samples` folder is for illustration purposes only and is not needed in development. 3. Update `ClientTracker` script. `Wikitude.IClientTracker` has been renamed to `Wikitude.ClientTracker` and is a sealed class. As such, the `ClientTracker` script should be changed to derive from `MonoBehaviour` instead and it's methods should be simple, instead of override. These methods will be set as callbacks in the Inspector. The class name should also be changed to avoid clashes with the Wikitude class. 4. Similar steps should be taken to update the `CloudTracker` script. Additionally, since it no longer derives from `Wikitude.CloudTracker`, it will need a reference to it so that it can call `StartContinuousRecognition`. 5. Similar steps should be taken to update the `SurferBehaviour` script. 6. Delete `MagazineTracker`, `TrackableBehaviour` and `WikitudeCamera` scripts. Since Wikitude classes are concrete now, they can be assigned directly to GameObjects, so there is no need for these empty classes anymore. 7. Open the scene called `main` from the `Scenes` folder. 8. Select the `WikitudeCamera` GameObject from the Hierarchy and enter your license key in the appropriate field in the Inspector. If the script is missing, add the `WikitudeCamera` script from the `Dependencies/WikitudeUnityPlugin` dll. 9. Create a new GameObject and add the script you updated at step 3 to it. 10. Select the `ClientTracker` GameObject from the Hierarchy and from the `Target Collection` dropdown select `magazine.wtc`. Then, for each event you want to subscribe to, press the plus sign, set the GameObject created at step 9 to the field `None (Object)` and select the corresponding function callback. Please see [Client Recognition](clientrecognitionnative.html) examples for more information on how to work with Unity Events. 11. Select the `WikitudeEye` GameObject from the Hierarchy and add the script you updated at step 5 to it. 12. Select the `Trackable` GameObject from the Hierarchy and in the `Target Pattern` field enter * to track all targets. In the events foldout, subscribe the script you added to WikitudeEye to both `On Enter Field Of Vision` and `On Exit Field Of Vision` events.  The project should now work as before. "
});



documentTitles["changelog.html#release-notes-wikitude-sdk"] = "Release Notes Wikitude SDK";
index.add({
    url: "changelog.html#release-notes-wikitude-sdk",
    title: "Release Notes Wikitude SDK",
    body: "# Release Notes Wikitude SDK   "
});

documentTitles["changelog.html#wikitude-sdk-720"] = "Wikitude SDK 7.2.0";
index.add({
    url: "changelog.html#wikitude-sdk-720",
    title: "Wikitude SDK 7.2.0",
    body: "## Wikitude SDK 7.2.0 Release Date: 05.02.2017  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "### New - SMART - Wikitude's integration of ARKit and ARCore  "
});

documentTitles["changelog.html#improved"] = "Improved";
index.add({
    url: "changelog.html#improved",
    title: "Improved",
    body: "### Improved - Added option to disable camera rendering - Added option to make the WikitudeCamera static  "
});

documentTitles["changelog.html#fixed"] = "Fixed";
index.add({
    url: "changelog.html#fixed",
    title: "Fixed",
    body: "### Fixed - Fixes issues when building for Android using IL2CPP   "
});

documentTitles["changelog.html#wikitude-sdk-710"] = "Wikitude SDK 7.1.0";
index.add({
    url: "changelog.html#wikitude-sdk-710",
    title: "Wikitude SDK 7.1.0",
    body: "## Wikitude SDK 7.1.0 Release Date: 19.09.2017  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "### New - New APIs to get the point cloud for InstantTracking  "
});

documentTitles["changelog.html#improved"] = "Improved";
index.add({
    url: "changelog.html#improved",
    title: "Improved",
    body: "### Improved - Improved OpenGL ES resource handling  "
});

documentTitles["changelog.html#fixed"] = "Fixed";
index.add({
    url: "changelog.html#fixed",
    title: "Fixed",
    body: "### Fixed - Fixes an object tracker issue where the `onTargetsLoaded` callback was called before all object targets were extracted - Fixes an issue where `Plugin::pause` was not called in case it was unregistered from the SDK - Fixes an issue where the SDK could crash in case a new tracker was created while another one was already tracking - Fixes an issue where loading .wto files could have happened on the main thread - Fixes an issue where the SDK could have crashed in case a target collection resource was released - Fixes an issue where the SDK could have crashed in case a cloud recognition service was released - Fixes an issue where the camera frames would not be rendered when using Metal with Unity 2017.1 - Fixes an issue where the WTC Editor would not work properly on Unity 2017.1 - Fixes an occasional camera stuttering and frame sync issues when using Metal - Fixes an issue where the auto frame rate setting would not work properly on iOS - Fixes an issue where cloud recognition would not call OnRecognitionResponse when metadata was missing on iOS or Android   "
});

documentTitles["changelog.html#wikitude-sdk-700"] = "Wikitude SDK 7.0.0";
index.add({
    url: "changelog.html#wikitude-sdk-700",
    title: "Wikitude SDK 7.0.0",
    body: "## Wikitude SDK 7.0.0 Release Date: 13.07.2017  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "### New - Object Recognition and Tracking - Support for multiple Image Targets - New hit-testing API for SLAM engine - Option for Extended Range for Image Recognition - Option for InstantTracker to choose initial plane orientation - Support for Metal Graphics API   "
});

documentTitles["changelog.html#improved"] = "Improved";
index.add({
    url: "changelog.html#improved",
    title: "Improved",
    body: "### Improved - Updated SLAM engine improves performance and accuracy for InstantTracker and Extended Tracking  "
});

documentTitles["changelog.html#fixed"] = "Fixed";
index.add({
    url: "changelog.html#fixed",
    title: "Fixed",
    body: "### Fixed - Issue where TargetRectangleInFrame returned the wrong position and size with HD frames - OpenGL ES 3 rendering issues    "
});

documentTitles["changelog.html#unity-plugin-210-210"] = "Unity Plugin 2.1.0-2.1.0";
index.add({
    url: "changelog.html#unity-plugin-210-210",
    title: "Unity Plugin 2.1.0-2.1.0",
    body: "## Unity Plugin 2.1.0-2.1.0 Release Date: 28.03.2017  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "#### New - Support for OpenGL ES 3.x - New supported FrameColorSpace YV12 for input plugins - New plugin registration error callback that contains more information why an input plugin could not be registered - New Frame methods `hasStrides()` and `getFrameStrides()` to get stride information of frames provided by plugins  "
});

documentTitles["changelog.html#improved"] = "Improved";
index.add({
    url: "changelog.html#improved",
    title: "Improved",
    body: "#### Improved - Trial licenses now support instant tracking   "
});

documentTitles["changelog.html#unity-plugin-201-201"] = "Unity Plugin 2.0.1-2.0.1";
index.add({
    url: "changelog.html#unity-plugin-201-201",
    title: "Unity Plugin 2.0.1-2.0.1",
    body: "## Unity Plugin 2.0.1-2.0.1 Release Date: 15.02.2017  "
});

documentTitles["changelog.html#fixed"] = "Fixed";
index.add({
    url: "changelog.html#fixed",
    title: "Fixed",
    body: "#### Fixed - Fixed a watermark rendering issue that occurred on certain Android devices - Fixed an issue where complex json metadata was not handled correctly   "
});

documentTitles["changelog.html#unity-plugin-200-200"] = "Unity Plugin 2.0.0-2.0.0";
index.add({
    url: "changelog.html#unity-plugin-200-200",
    title: "Unity Plugin 2.0.0-2.0.0",
    body: "## Unity Plugin 2.0.0-2.0.0 Release Date: 25.01.2017  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "#### New - The new instant tracking feature allows users to place augmentations without any markers in any surrounding. Instant tracking uses Wikitudes own SLAM-based 3D engine. - Added advanced camera settings like HD and 60 fps camera rendering and a manual focus control - Unified computer vision related class names - Added support for x86 on Android  "
});

documentTitles["changelog.html#improved"] = "Improved";
index.add({
    url: "changelog.html#improved",
    title: "Improved",
    body: "#### Improved - Updated target collection format (.wtc) which improves the robustness and performance of 2D image recognition. - Extended tracking improved significant using the new SLAM technology  - Custom camera example now shows how to sync 2d tracking and camera frame rendering  "
});

documentTitles["changelog.html#fixed"] = "Fixed";
index.add({
    url: "changelog.html#fixed",
    title: "Fixed",
    body: "#### Fixed - Fix inverted camera view on some Android devices   "
});

documentTitles["changelog.html#unity-plugin-141-130"] = "Unity Plugin 1.4.1-1.3.0";
index.add({
    url: "changelog.html#unity-plugin-141-130",
    title: "Unity Plugin 1.4.1-1.3.0",
    body: "## Unity Plugin 1.4.1-1.3.0  Release Date: 24.11.2016&lt;br/&gt; Unity Plugin: 1.3.0&lt;br/&gt; Native API: 1.4.1  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "#### New  - Includes Native API version 1.4.1 (see separate for detailed changes [iOS](http://www.wikitude.com/external/doc/documentation/latest/iosnative/changelog.html), [Android](http://www.wikitude.com/external/doc/documentation/latest/androidnative/changelog.html))   "
});

documentTitles["changelog.html#unity-plugin-140-130"] = "Unity Plugin 1.4.0-1.3.0";
index.add({
    url: "changelog.html#unity-plugin-140-130",
    title: "Unity Plugin 1.4.0-1.3.0",
    body: "## Unity Plugin 1.4.0-1.3.0  Release Date: 13.09.2016&lt;br/&gt; Unity Plugin: 1.3.0&lt;br/&gt; Native API: 1.4.0  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "#### New  - Plugins enable additional processing to be done on the camera feed directly in Unity, or in custom native plugins  - Input Plugins allow developers to use the Wikitude SDK with an external camera feed  - Includes Native API version 1.4.0 (see separate for detailed changes [iOS](http://www.wikitude.com/external/doc/documentation/latest/iosnative/changelog.html), [Android](http://www.wikitude.com/external/doc/documentation/latest/androidnative/changelog.html))  "
});

documentTitles["changelog.html#improved"] = "Improved";
index.add({
    url: "changelog.html#improved",
    title: "Improved",
    body: "#### Improved  - Cloud Tracker now includes an option to change the server region  "
});

documentTitles["changelog.html#fixed"] = "Fixed";
index.add({
    url: "changelog.html#fixed",
    title: "Fixed",
    body: "#### Fixed  - Fixed bug where extended tracking was not properly enabled  - Fixed bug where augmentations were not placed properly when using the front facing camera   "
});

documentTitles["changelog.html#unity-plugin-130-120"] = "Unity Plugin 1.3.0-1.2.0";
index.add({
    url: "changelog.html#unity-plugin-130-120",
    title: "Unity Plugin 1.3.0-1.2.0",
    body: "## Unity Plugin 1.3.0-1.2.0  Release Date: 14.07.2016&lt;br/&gt; Unity Plugin: 1.2.0&lt;br/&gt; Native API: 1.3.0  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "#### New  - WTC Editor inside Unity  - Includes Native API version 1.3.0 (see separate for detailed changes [iOS](http://www.wikitude.com/external/doc/documentation/latest/iosnative/changelog.html), [Android](http://www.wikitude.com/external/doc/documentation/latest/androidnative/changelog.html))   "
});

documentTitles["changelog.html#improved"] = "Improved";
index.add({
    url: "changelog.html#improved",
    title: "Improved",
    body: "#### Improved  - Trackable inspector can now view local wtc file contents and can preview targets inside the 3D view to make placing augmentations easier  - Trackable transform is no longer changed during tracking  - Camera prefab has been simplified   "
});

documentTitles["changelog.html#fixed"] = "Fixed";
index.add({
    url: "changelog.html#fixed",
    title: "Fixed",
    body: "#### Fixed  - Fixed bug on Windows machines where choosing a wtc file not placed in the StreamingAssets folder directly would cause the app to not track anymore  - Fixed issue with loading pre-recorded .wtm files  - Fixed issue with some shaders not working correctly  - Fixed shadow rendering on Android  - Fixed missing camera feed on Android when the Standard shader was not present in the project  - Fixed errors when no wtc files were present in the project   "
});

documentTitles["changelog.html#unity-plugin-121-110"] = "Unity Plugin 1.2.1-1.1.0";
index.add({
    url: "changelog.html#unity-plugin-121-110",
    title: "Unity Plugin 1.2.1-1.1.0",
    body: "## Unity Plugin 1.2.1-1.1.0 Release Date: 21.03.2016  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "#### New - 3D Tracking and 3D Map Recording - Extended Tracking quality feedback - Camera Controls API - Extended examples illustrating all the available API - Unity editor events for all callbacks - Ability to create and destroy trackers at runtime  "
});

documentTitles["changelog.html#fixed"] = "Fixed";
index.add({
    url: "changelog.html#fixed",
    title: "Fixed",
    body: "#### Fixed - Crashes when reloading scenes  "
});

documentTitles["changelog.html#unity-plugin-101-100"] = "Unity Plugin 1.0.1-1.0.0";
index.add({
    url: "changelog.html#unity-plugin-101-100",
    title: "Unity Plugin 1.0.1-1.0.0",
    body: "## Unity Plugin 1.0.1-1.0.0 Release Date: 12.11.2015  "
});

documentTitles["changelog.html#improved"] = "Improved";
index.add({
    url: "changelog.html#improved",
    title: "Improved",
    body: "#### Improved - Android based app packages can now be exported to Android Studio - 64-bit applications for Android now choose the correct library version  "
});

documentTitles["changelog.html#unity-plugin-100-100"] = "Unity Plugin 1.0.0-1.0.0";
index.add({
    url: "changelog.html#unity-plugin-100-100",
    title: "Unity Plugin 1.0.0-1.0.0",
    body: "## Unity Plugin 1.0.0-1.0.0 Release Date: 27.08.2015  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "#### New - Initial public release of Unity Plugin - Added Android as supported platform - Fixed limited interface orientations  "
});

documentTitles["changelog.html#unity-plugin-100-100-beta"] = "Unity Plugin 1.0.0-1.0.0 beta";
index.add({
    url: "changelog.html#unity-plugin-100-100-beta",
    title: "Unity Plugin 1.0.0-1.0.0 beta",
    body: "## Unity Plugin 1.0.0-1.0.0 beta Release Date: 30.07.2015  "
});

documentTitles["changelog.html#new"] = "New";
index.add({
    url: "changelog.html#new",
    title: "New",
    body: "#### New - Initial Public Beta Release of Unity Plugin  "
});

