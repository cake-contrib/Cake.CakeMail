---
Title: New Release - 0.4.0
Published: 22/10/2017
Category: Release
Author: jericho
---

## Improvements

- [__#18__](https://github.com/cake-contrib/Cake.CakeMail/issues/18) Support Cake 0.22.2
- [__#17__](https://github.com/cake-contrib/Cake.CakeMail/issues/17) Multi-target net46 and netstandard1.6

## Note

First, include a reference to this addin in your script like this:
```
#addin nuget:?package=Cake.CakeMail
```

Also, this addin is designed to take advantage of some of the new features released in CakeBuild version `0.22.0`. Having said that, a [bug](https://github.com/cake-build/cake/issues/1838) was discovered in `0.22.0` and fixed in `0.23.0` therefore you need to ensure to ensure that version (or more recent).
Your `tools\package.config` should be:
```
<packages>
    <package id="Cake" version="0.23.0" />
</packages>
```

Finally, and this is critical, you need to "opt-in" the new feature in CakeBuild that this addin depends on. If you are using the standard bootstrapper, you opt-in these feature like so:
```
.\build.ps1 --nuget_useinprocessclient=true --nuget_loaddependencies=true
```

Please do not hesitate to reach out in the [Gitter Channel](https://gitter.im/cake-contrib/Lobby) if you have any issues using this addin.