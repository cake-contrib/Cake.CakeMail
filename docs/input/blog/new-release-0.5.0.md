---
Title: New Release - 0.5.0
Published: 13/03/2018
Category: Release
Author: jericho
---

## Breaking Changes

- [__#19__](https://github.com/cake-contrib/Cake.CakeMail/issues/19) Upgrade to Cake 0.26.0 and target netstandard2.0

## Note

First, include a reference to this addin in your script like this:
```csharp
#addin nuget:?package=Cake.CakeMail&version=0.5.0&loaddependencies=true
```

Second, we highly recommend that you add the following 'using' statement in your script. Technically, this is not necessary, but it simplifies dealing with attachements: 
```csharp
using Cake.Email.Common;
```

Also, this addin is designed to take advantage of some of the new features released in CakeBuild version `0.26.0` therefore your `tools\package.config` should look like this:
```xml
<packages>
    <package id="Cake" version="0.26.0" />
</packages>
```

Please do not hesitate to reach out in the [GitHub discussions](https://github.com/cake-build/cake/discussions/categories/extension-q-a) if you have any issues using this addin.
