## EasySaver.BitmapFile Changelog
[![EasySaver.BitmapFile](https://img.shields.io/nuget/v/EasySaver.BitmapFile.svg)](https://www.nuget.org/packages/EasySaver.BitmapFile/)

<!--
### [Unreleased]

#### Added

#### Changed

#### Removed
-->

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
