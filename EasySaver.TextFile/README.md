## EasySaver TextFile
[![EasySaver.TextFile](https://img.shields.io/nuget/v/EasySaver.TextFile.svg)](https://www.nuget.org/packages/EasySaver.TextFile/) [![EasySaver.TextFile](https://img.shields.io/nuget/dt/EasySaver.TextFile.svg)](https://www.nuget.org/packages/EasySaver.TextFile/) [![License](https://img.shields.io/github/license/meokullu/EasySaver.svg)](https://github.com/meokullu/EasySaver/blob/master/LICENSE)

EasySaver.TextFile is a package to save text files easily with different naming formats including `Custom`, `LongDate`, `ShortDate`, `LongTime`, `ShortTime`, `LongDateTime` and `ShortDateTime`.

![EasySaver](https://github.com/meokullu/EasySaver/assets/4971757/83483703-12f4-439b-b03b-95db2477e8c2)

### Description
This is README file for EasySaver.TextFile. 

### How to download
Release: [Latest release](https://github.com/meokullu/EasySaver/releases/latest)

[Download on NuGet gallery](https://www.nuget.org/packages/EasySaver.TextFile/)

.NET CLI:
```
dotnet add package EasySaver.TextFile
```

### Example Usage
```
Save(string text);
```
```
Save(string text, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists)
```
```
SaveToFolder(string text);
```
```
SaveToFolder(string text, string folderName, string fileName, NamingFormat namingFormat, bool overwrite, bool renameIfExists);
```

To check listed/unlisted methods, example of output visit wiki page. [EasySaver Wiki](https://github.com/meokullu/EasySaver/wiki)

### Version History
See Changelog [EasySaver.TextFile Changelog](https://github.com/meokullu/EasySaver/blob/master/EasySaver.Text/CHANGELOG.md)

### Task list
* Create an issue or check task list: [Issues](https://github.com/meokullu/EasySaver/issues)

### Licence
This repository is licensed under the "MIT" license. See [MIT license](https://github.com/meokullu/EasySaver/blob/master/LICENSE).

### Authors & Contributing

If you'd like to contribute, then contribute. [contributing guide](https://github.com/meokullu/EasySaver/blob/master/CONTRIBUTING.md).

[![Contributors](https://contrib.rocks/image?repo=meokullu/EasySaver)](https://github.com/meokullu/EasySaver/graphs/contributors)

### Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)
