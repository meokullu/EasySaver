## EasySaver.BitmapFile Changelog
[![EasySaver.BitmapFile](https://img.shields.io/nuget/v/EasySaver.BitmapFile.svg)](https://www.nuget.org/packages/EasySaver.BitmapFile/)

<!--
### [Unreleased]

#### Added

#### Changed

#### Removed
-->

### [2.1.0]
#### Fixed
* `SaveToFolderSafe()` was missing "/" between `folderName` and `fileName` when file was existing and parameter `renameIfExists` set `true`.

### [2.0.0]
#### Changed
* `Save()`, `SafeSafe()`, `SaveToFolder()` and `SaveToFolderSafe()` now check if `overwrite` is `true` and save the file otherwise it doesn't save the file.
* `SaveSafe()` was using "path: $"{fileName}({i}){s_defaultImageExtension}", bitmap: bitmap" instead of "path: $"./{fileName}({i}){s_defaultImageExtension}", bitmap: bitmap" when `overwrite` is `false` and `renameIfExists` is `true`.
* `SaveToFolderSafe()` was using "path: $"./{fileName}{s_defaultImageExtension}", bitmap: bitmap" instead of "path: $"./{fileName}({i}){s_defaultImageExtension}", bitmap: bitmap" when `overwrite` is `false` and `renameIfExists` is `true`.

#### Fixed
* "({i})" added into `SaveToFolderSafe()` when `overwrite` is `false` and `renameIfExists` is `true`.

### [1.2.0]
#### Added
* Multi-framework support for net7.0

#### Changed
* `SaveSafe(Bitmap bitmap)` and `SaveToFolderSafe(Bitmap bitmap)` was using `s_onlyBitmapProvidedNamingFormat` instead of `s_defaultNamingFormat`
* `SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName)` was using `s_defaultNamingFormat` instead of `s_onlyBitmapProvidedNamingFormat`

#### Fixed
* `SaveToFolder()` and `SaveToFolderSafe()` was not saving a file when folderName is empty string. (#58)[https://github.com/meokullu/EasySaver/issues/58]

### [1.1.0]
#### Fixed
* CheckFolderIfExists() had parameter value bug in SaveToFolderSafe(). This bug is fixed. (#51)[https://github.com/meokullu/EasySaver/issues/51]
* CheckFileIfExists() had parameter value bug in SaveToFolderSave(). This bug is fixed. (#51)[https://github.com/meokullu/EasySaver/issues/51]

### [1.0.0]

#### Changed
* Naming inconventions is fixed on internal variables.

### [1.0.0-beta]

#### Changed
* Renaming private variable.
* Fixed misleading method links on summaries.

#### Removed
* `Save(Bitmap bitmap, string fileName, string folderName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method was deprecated. Method is removed, you can use `SaveToFolder(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` instead.
* `SaveSafe(Bitmap bitmap, string fileName, string folderName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method was deprecated. Method is removed, you can use `SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` instead.

### [1.0.0-alpha.7]

#### Changed
* New design README.
* New design CHANGELOG.
* Added method references to summaries.

### [1.0.0-alpha.6]

#### Added
* `Save(Bitmap bitmap)` method added.
* `Save(Bitmap bitmap, string fileName)`method added.
* `Save(Bitmap bitmap, string fileName, NamingFormat namingFormat)` method added.
* `Save(Bitmap bitmap, string fileName, NamingFormat namingFormat, bool overwrite)` method added.

* `SaveToFolder(Bitmap bitmap)` method added.
* `SaveToFolder(Bitmap bitmap, string folderName)` method added.
* `SaveToFolder(Bitmap bitmap, string folderName, string fileName)`method added.
* `SaveToFolder(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat)` method added.
* `SaveToFolder(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite)` method added.
* `SaveToFolder(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method added.

* `SaveSafe(Bitmap bitmap)` method added.
* `SaveSafe(Bitmap bitmap, string fileName)`method added.
* `SaveSafe(Bitmap bitmap, string fileName, NamingFormat namingFormat)` method added.
* `SaveSafe(Bitmap bitmap, string fileName, NamingFormat namingFormat, bool overwrite)` method added.

* `SaveToFolderSafe(Bitmap bitmap)` method added.
* `SaveToFolderSafe(Bitmap bitmap, string folderName)` method added.
* `SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName)`method added.
* `SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat)` method added.
* `SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite)` method added.
* `SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method added.

* Default provided values are listed as properties now.

#### Changed
* `Save(Bitmap bitmap, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExist)` method's default parameters are removed. NamingFormat, overwrite, renameIfExist had default parameters NamingFormat.DateTime, false, true respectively.
* `SaveSafe(Bitmap bitmap, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExist)` method's default parameters are removed. NamingFormat, overwrite, renameIfExist had default parameters NamingFormat.DateTime, false, true respectively.

#### Removed
* `Save(Bitmap bitmap, string fileName, string folderName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method is deprecated. You can use `SaveToFolder(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` instead.
* `SaveSafe(Bitmap bitmap, string fileName, string folderName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` method is deprecated. You can use `SaveToFolderSafe(Bitmap bitmap, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)` instead.

### [1.0.0-alpha.5]

#### Added
* Summaries to methods.
* Comments to processes.

#### Changed
* New icon.
* README updated.

### [1.0.0-alpha.4]

#### Added
* Licence added.
* Download Nuget link added on README.
* CHANGELOG link added under Version History on README.
* Tags added to PackageTags.

#### Changed
* Updated README.
* Folder name changed from EasySaver.Bitmap to EasySaver.BitmapFile.

### [1.0.0-alpha.3]

#### Changed
* Updated README

### [1.0.0-alpha.2]

#### Changed
* Updated README

### [1.0.0-alpha.1]

#### Changed
* Updated README

### [1.0.0-alpha]
Initial version.
