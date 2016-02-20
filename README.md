# property-change-tracker
Unit test helper that looks for property changes from classes implementing INotifyPropertyChanged

For a description of the purpose and basic operation of the PropertyChangeTracker, please visit http://jeremybytes.blogspot.com/2015/07/tracking-property-changes-in-unit-tests.html

Planned updates:
* Add support for changes to "all" properties (i.e. calling RaisePropertyChanged with no parameters)  
Completed: http://jeremybytes.blogspot.com/2016/02/tracking-properties-in-unit-tests.html
* Finer-grained timeout (change from seconds to milliseconds)  
Completed: http://jeremybytes.blogspot.com/2016/02/tracking-properties-in-unit-tests_19.html
* Asyn Test Methods  
Completed: http://jeremybytes.blogspot.com/2016/02/tracking-changes-in-unit-tests-part-3.html
* Implement IDisposable
