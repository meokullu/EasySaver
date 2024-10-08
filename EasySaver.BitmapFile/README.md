## EasySaver BitmapFile
[![EasySaver.BitmapFile](https://img.shields.io/nuget/v/EasySaver.BitmapFile.svg)](https://www.nuget.org/packages/EasySaver.BitmapFile/) [![EasySaver.BitmapFile](https://img.shields.io/nuget/dt/EasySaver.BitmapFile.svg)](https://www.nuget.org/packages/EasySaver.BitmapFile/) [![License](https://img.shields.io/github/license/meokullu/EasySaver.svg)](https://github.com/meokullu/EasySaver/blob/master/LICENSE)

EasySaver.BitmapFile is a package to save bitmap files easily with different naming formats including `Custom`, `LongDate`, `ShortDate`, `LongTime`, `ShortTime`, `LongDateTime` and `ShortDateTime`

![EasySaver](https://github.com/meokullu/EasySaver/assets/4971757/830f74f1-eab8-44eb-9211-ed61c11074df)

### Description
This is README file for EasySaver.BitmapFile.

### How to download
Release: [Latest release](https://github.com/meokullu/EasySaver/releases/latest)

[Download on NuGet gallery](https://www.nuget.org/packages/EasySaver.BitmapFile/)

.NET CLI:
```
dotnet add package EasySaver.BitmapFile
```

### Example Usage
```
Save(Bitmap bitmap);
```
```
Save(Bitmap bitmap, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists);
```
```
SaveToFolder(Bitmap bitmap);
```
```
SaveToFolder(Bitmap bitmap, string fileName, string folderName, NamingFormat namingFormat, bool overwrite, bool renameIfExists);
```

To check listed/unlisted methods, example of output visit wiki page. [EasySaver Wiki](https://github.com/meokullu/EasySaver/wiki)

### Version History
See Changelog [EasySaver.BitmapFile Changelog](https://github.com/meokullu/EasySaver/blob/master/EasySaver.BitmapFile/CHANGELOG.md)

### Task list
* Create an issue or check task list: [Issues](https://github.com/meokullu/EasySaver/issues)

### Licence
This repository is licensed under the "MIT" license. See [MIT license](https://github.com/meokullu/EasySaver/blob/master/LICENSE).

### Authors & Contributing

If you'd like to contribute, then contribute. [contributing guide](https://github.com/meokullu/EasySaver/blob/master/LICENSE).

[![Contributors](https://contrib.rocks/image?repo=meokullu/EasySaver)](https://github.com/meokullu/EasySaver/graphs/contributors)

### Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)
