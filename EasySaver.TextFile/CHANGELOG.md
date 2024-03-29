## EasySaver.TextFile Changelog
[![EasySaver.TextFile](https://img.shields.io/nuget/v/EasySaver.TextFile.svg)](https://www.nuget.org/packages/EasySaver.TextFile/)

<!--
### [Unreleased]

#### Added

#### Changed

#### Removed
-->

### [2.1.0]
#### Fixed
* All methods that work with `SaveToFolder()` or `SaveToFolderSafe()` was throwing an error when folderName is provided with default system values such as `Environment.GetFolderPath(Environment.SpecialFolder.Desktop)`


### [2.0.0]
#### Changed
* `Save()`, `SafeSafe()`, `SaveToFolder()` and `SaveToFolderSafe()` now check if `overwrite` is `true` and save the file otherwise it doesn't save the file.
* `SaveSafe()` was using path "fileName + s_defaultTextExtension" instead of "$"./{fileName}{s_defaultTextExtension}" when `fileExsists` is `false`.

#### Fixed
* `SaveSafe()` was using when `overwrite` is `false` and `renameIfExists` `true` "path: $"./{fileName}({i}{s_defaultTextExtension}", missing ")" character is added.
* `SaveToFolderSafe()` was using "path: $"./{fileName}{s_defaultTextExtension}" when `overwrite` is `true` instead of $"./{folderName}/{fileName}{s_defaultTextExtension}"

### [1.2.0]
#### Added
* Multi-framework support for net7.0

#### Changed
* `SaveToFolder(string text, string folderName, string fileName)` was using `NamingFormat.Custom` instead of `s_onlyTextProvidedNamingFormat`

#### Fixed
* `SaveToFolder()` and `SaveToFolderSafe()` was not saving a file when folderName is empty string. (#58)[https://github.com/meokullu/EasySaver/issues/58]

### [1.1.0]
#### Fixed
* CheckFolderIfExists() had parameter value bug in SaveToFolderSafe(). This bug is fixed. (#52)[https://github.com/meokullu/EasySaver/issues/52]

### [1.0.0]
#### Changed
* Naming inconventions are fixed on internal variables.

### [1.0.0-beta]
#### Changed
* Fixed misleading method links on summaries.
* Renamed private variable.

#### Removed
* `Save(string text, string fileName, string folderName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method was deprecated. Method is removed, you can use `SaveToFolder(string text, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` instead.
* `SaveSafe(string text, string fileName, string folderName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method was deprecated. Method is removed, you can use `SaveToFolderSafe(string text, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` instead.
### [1.0.0-alpha.6]

#### Changed
* New design README.
* New design CHANGELOG.
* Added method references to summaries.

### [1.0.0-alpha.5]
#### Added
* `Save(string text)` method added.
* `Save(string text, string fileName)`method added.
* `Save(string text, string fileName, NamingFormat namingFormat)` method added.
* `Save(string text, string fileName, NamingFormat namingFormat, bool overwrite)` method added.

* `SaveToFolder(string text)` method added.
* `SaveToFolder(string text, string folderName)` method added.
* `SaveToFolder(string text, string folderName, string fileName)`method added.
* `SaveToFolder(string text, string folderName, string fileName, NamingFormat namingFormat)` method added.
* `SaveToFolder(string text, string folderName, string fileName, NamingFormat namingFormat, bool overwrite)` method added.
* `SaveToFolder(string text, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method added.

* `SaveSafe(string text)` method added.
* `SaveSafe(string text, string fileName)`method added.
* `SaveSafe(string text, string fileName, NamingFormat namingFormat)` method added.
* `SaveSafe(string text, string fileName, NamingFormat namingFormat, bool overwrite)` method added.

* `SaveToFolderSafe(string text)` method added.
* `SaveToFolderSafe(string text, string folderName)` method added.
* `SaveToFolderSafe(string text, string folderName, string fileName)`method added.
* `SaveToFolderSafe(string text, string folderName, string fileName, NamingFormat namingFormat)` method added.
* `SaveToFolderSafe(string text, string folderName, string fileName, NamingFormat namingFormat, bool overwrite)` method added.
* `SaveToFolderSafe(string text, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method added.

* Default provided values are listed as properties now.

#### Changed
* `Save(string text, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExist)` method's default parameters are removed. NamingFormat, overwrite, renameIfExist had default parameters NamingFormat.DateTime, false, true respectively.
* `SaveSafe(string text, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExist)` method's default parameters are removed. NamingFormat, overwrite, renameIfExist had default parameters NamingFormat.DateTime, false, true respectively.
* Typo fixed.

#### Removed
* `Save(string text, string fileName, string folderName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method is deprecated. You can use `SaveToFolder(string text, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` instead.
* `SaveSafe(string text, string fileName, string folderName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method is deprecated. You can use `SaveToFolderSafe(string text, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` instead.

### [1.0.0-alpha.4]
### Added
* Summaries to methods.
* Comments to processes.

#### Changed
* New icon.
* README updated.

### [1.0.0-alpha.3]
#### Added
* Download Nuget link added on README.
* CHANGELOG link added under Version History on README.
* Tags added to PackageTags.

#### Changed
* Updated README
* Folder name changed from EasySaver.Text to EasySaver.TextFile.

### [1.0.0-alpha.2]
#### Changed
* Updated README

### [1.0.0-alpha.1]
#### Changed
* Updated README

### [1.0.0-alpha]
Initial version.
