## EasySaver
[![EasySaver](https://img.shields.io/nuget/v/EasySaver.Common.svg)](https://www.nuget.org/packages/EasySaver.Common/) [![EasySaver.Common](https://img.shields.io/nuget/dt/EasySaver.Common.svg)](https://www.nuget.org/packages/EasySaver.Common/) [![License](https://img.shields.io/github/license/meokullu/EasySaver.svg)](https://github.com/meokullu/EasySaver/blob/master/LICENSE)

EasySaver is a multi-solution package to save bitmap image files and text files easily with different naming formats including `Custom`, `LongDate`, `ShortDate`, `LongTime`, `ShortTime`, `LongDateTime` and `ShortDateTime`.

![EasySaver](https://github.com/meokullu/EasySaver/assets/4971757/8e11e803-36ce-4dfc-a04d-b1251caefd00)

[Download on NuGet gallery](https://www.nuget.org/packages/EasySaver/)

***
* BitmapFile
[![EasySaver](https://img.shields.io/nuget/v/EasySaver.BitmapFile.svg)](https://www.nuget.org/packages/EasySaver.BitmapFile/) [![EasySaver.BitmapFile](https://img.shields.io/nuget/dt/EasySaver.BitmapFile.svg)](https://www.nuget.org/packages/EasySaver.BitmapFile/)

* TextFile
[![EasySaver](https://img.shields.io/nuget/v/EasySaver.TextFile.svg)](https://www.nuget.org/packages/EasySaver.TextFile/) [![EasySaver.TextFile](https://img.shields.io/nuget/dt/EasySaver.TextFile.svg)](https://www.nuget.org/packages/EasySaver.TextFile/)

### How to download
Release: [Latest release](https://github.com/meokullu/EasySaver/releases/latest)

[Download on NuGet gallery](https://www.nuget.org/packages/EasySaver.Common/)

.NET CLI:
```
dotnet add package EasySaver.Common
```

### Description
EasySaver has one common and two external packages. Common package have several internal, private and public methods. Via these methods using [EasySaver.BitmapFile](https://github.com/meokullu/EasySaver/tree/master/EasySaver.BitmapFile) or [EasySaver.TextFile](https://github.com/meokullu/EasySaver/tree/master/EasySaver.TextFile) are easy.

### Naming Formats

```
NamingFormat.Custom
```

> {hour}-{minute}-{second}-{millisecond}
```
NamingFormat.LongTime
```

> {hour}-{minute}-{second}
```
NamingFormat.ShortTime
```

> {year}-{month}-{day}
```
NamingFormat.LongDate
```

> {month}-{day}
```
NamingFormat.ShortDate
```

> {year}-{month}-{day}-{hour}-{minute}-{second}-{millisecond}
```
NamingFormat.LongDateTime
```

> {month}-{day}-{hour}-{minute}-{second}
```
NamingFormat.ShortDateTime
```

To check listed/unlisted methods, example of output visit wiki page. [EasySaver Wiki](https://github.com/meokullu/EasySaver/wiki)

### BitmapFile
[BitmapFile README](https://github.com/meokullu/EasySaver/tree/master/EasySaver.BitmapFile/README.md)

### TextFile
[TextFile README](https://github.com/meokullu/EasySaver/tree/master/EasySaver.TextFile/README.md)

### Version History
See changelog [EasySaver Changelog](https://github.com/meokullu/EasySaver/blob/master/CHANGELOG.md)

### Task list
* Create an issue or check task list: [Issues](https://github.com/meokullu/EasySaver/issues)

### Licence
[MIT license](https://github.com/meokullu/EasySaver/blob/master/LICENSE)

### Authors & Contributing

If you'd like to contribute, then contribute. [contributing guide](https://github.com/meokullu/EasySaver/blob/master/CONTRIBUTING.md).

[![Contributors](https://contrib.rocks/image?repo=meokullu/EasySaver)](https://github.com/meokullu/EasySaver/graphs/contributors)

### Authors
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)

### Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)
