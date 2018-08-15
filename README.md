# Combobox-usercontrol-test
This is a toy application that I put together to try and solve a problem with combo boxes being reset when changing between two different reports.

This is the least complicated solution I could come up with that still reproduced the problem that I was having.

There is a Report Control which consists of a view that can have a list of parameters added, a list box which uses a templates selector to choose between a combo box and a text box depending on if an itemssource has been specified for the parameter.  This is all View Only configuration

The Main View consists of a combobox that shows all of the loaded reports, while the content control displays the view associated with the selected Report.

The ReportView contains the view configuration for each report, normally there'd be more views, but for testing purposes we only need the one reportviewmodel and one report view instantiated twice.

The ViewModels start with the TestViewModel, the initialisation code provides the model so that I didn't need to implement one specificly for this solution.  This has two properties, a list of reports, and the selected report.  Each Report would be a ViewModel on a backend Model, but for the purposes of this sample just consist of an indexed property, an Item Name, a View Instantiator, as well as an itemssource.  
