[![kankilog](https://raw.githubusercontent.com/veysel/kankilog/main/content/logo.png)](https://github.com/veysel/kankilog)

# kankilog
Kanki Log

[![NuGet version](https://badge.fury.io/nu/kankilog.svg)](https://www.nuget.org/packages/kankilog/)
[![Build Status](https://travis-ci.com/veysel/kankilog.svg?branch=main)](https://travis-ci.com/github/veysel/kankilog)

<br>

## How to use ?

### Install kankilog

```
Install-Package kankilog

or

dotnet add package kankilog
```

<br>

### Import Project

```c#
using kankilog;
```

<br>

### Log Write

```c#
KankiLog.LogToText(KankiLogType.INFO, "Log text...");
```

<br>

### Set Main Path (Optional)

```c#
KankiLog.SetMainPath("logFolder/logs");
```

<br>

### Set Is Throw Exception (Optional) (Default: false)

```c#
KankiLog.SetIsThrowException(true);
```