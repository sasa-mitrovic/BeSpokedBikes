# BeSpokedBikes

Requirements:

Visual Studio 2019
Sql Server Management Studio

To run the application, ensure you have .NET framework and dependencies installed. When importing for the first time, it will guide you through fixes if you don't have dependencies.

Once the application code is ready, next is Database.

Right click on BeSpokedDB and click Publish.

From here click Load Profile and open the folder "PublishProfiles" and select the BeSpokedDB.publish.xml 
after selecting, you should have the option to Publish. Go ahead and publish it from there. In the console at the bottom, we should have all green check marks and good to go.

Now that the Database is published to the localdb, we can populate the data.

Navigate to the "TestDatePackage.dtsx" package and run that with SSIS (Execute Package Utility)

Allow the package to extract and the data should be imported and the project should be good to go.
