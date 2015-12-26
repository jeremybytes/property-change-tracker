# property-change-tracker
Unit test helper that looks for property changes from classes implementing INotifyPropertyChanged

For a description of the purpose and basic operation of the PropertyChangeTracker, please visit http://jeremybytes.blogspot.com/2015/07/tracking-property-changes-in-unit-tests.html

Planned updates:
* Add support for changes to "all" properties (i.e. calling RaisePropertyChanged with no parameters)
* Finer-grained timeout (change from seconds to milliseconds)
* Implement IDisposable
