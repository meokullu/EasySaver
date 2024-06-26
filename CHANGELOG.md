## EasySaver Changelog
[![EasySaver.Common](https://img.shields.io/nuget/v/EasySaver.Common.svg)](https://www.nuget.org/packages/EasySaver.Common/) [![EasySaver.Common](https://img.shields.io/nuget/dt/EasySaver.Common.svg)](https://www.nuget.org/packages/EasySaver.Common/) [![License](https://img.shields.io/github/license/meokullu/EasySaver.svg)](https://github.com/meokullu/EasySaver/blob/master/LICENSE)

<!--
### [Unreleased]

#### Added

#### Changed

#### Removed
-->

### [1.4.0]
#### Removed
* `TodayString`, `NowString` and `LongDayString` are removed as `NamingFormat`.
* `NamingFormat.Time`, `NamingFormat.Date` and `NamingFormat.DateTime` are removed as a condition in `GetFormattedDateTimeStamp(NamingFormat namingFormat)` and `GetFileName(string fileName, NamingFormat namingFormat = NamingFormat.LongDateTime)` internal method. 

### [1.3.0]
#### Added
* EasySaver.Common.cs is splitted into AppName.cs, CallerMethodName.cs, DateTime.cs, DefaultExtension.cs, Exist.cs, GetFileName.cs, MaxAttempt.cs, NamingFormat.cs and Path.cs.
* `AppName` added under AppName.cs
* `CallerMethodName1-8` added under CallerMethodName.cs
* `ShortDateString` and `ShortTimeString` added under DateTime.cs
* `DesktopPath` added under Path.cs
#### Changed
* `LongDayString` is marked as obsolote due to hypo. Use `LongDayString` instead.

### [1.2.0]
#### Added
* Multi-framework support for net7.0; net461; netcoreapp3.1; netstandard2.0

### [1.1.0]
#### Added
* `NamingFormat.LongTime`, `NamingFormat.LongDateTime`, `NamingFormat.LongDate`, `NamingFormat.ShortTime`, `NamingFormat.ShortDateTime` and `NamingFormat.ShortDate`are added.

#### Changed
* `NamingFormat.Time`, `NamingFormat.DateTime` and `NamingFormat.Date` are obsolete now. You can use .LongTime, .LongDateTime and .LongDateTime respectively.
* `TodayString` and `NowString` are obsolete now. You can use `LongDayString` and `LongTimeString` respectively.

### [1.0.0]
#### Changed
* Internal variable `s_maxAttemptForRename` is moved from RandomNaming.cs to EasySaver.Common.cs
* `MaxAttemptMessage(string methodName)` is moved from RandomNaming.cs to EasySaver.Common.cs
* Naming inconventions are fixed.

#### Removed
* RandomNaming.cs is removed.
* `RandomName` is removed as an option from `NamingFormat` enum.
* `RandomName` is removed as an condition from `GetFileName(string fileName, NamingFormat namingFormat = NamingFormat.DateTime)`

### [1.0.0-beta]
#### Added
* Random names into `RandomFileNameList.txt` as data source.

#### Changed
* `GetAvailableFileName()` renamed as `GetRandomFileName()`.
* `NamingFormat.RandomName` is available now for beta tests.
* `NamingFormat.RandomName` and random naming has its own class as `RandomNaming.cs` under src folder.

### [1.0.0-alpha.6]
#### Changed
* New design README.
* New design CHANGELOG.

### [1.0.0-alpha.5]
#### Changed
* New icon.
* README updated

### [1.0.0-alpha.4]
#### Added
* CHANGELOG link added under Version History on README.
* EasySaver.BitmapFile README link added.
* EasySaver.TextFile README link added.

### [1.0.0-alpha.3]
#### Added
* Updated README.

### [1.0.0-alpha.2]
#### Added
* Licence is added.

### [1.0.0-alpha.1]
* Default image extension is added. ".bmp"

### [1.0.0-alpha]
Initial version.
