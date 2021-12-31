# EMS
EMS is a resource for FiveM by Albo1125 that provides medical functionality. It also prevents you from automatically respawning if you die. It is available at [https://github.com/Albo1125/EMS](https://github.com/Albo1125/EMS)

## Installation & Usage
1. Download the latest release.
2. Unzip the EMS folder into your resources folder on your FiveM server.
3. Add the following to your server.cfg file:
```text
ensure EMS
```
4. Optionally, customise the commands in sv_EMS.lua.

## Commands & Controls
* /respawn - Respawns you if dead to the designated spawn point for your map.
* /revive - Revives your dead character in-place.
* /cpr PUMPS - Performs the CPR animation PUMPS times. If PUMPS unspecified, defaults to 30. If currently performing CPR, cancels it.
* /die - Kills your character.

## Improvements & Licencing
Please view the license. Improvements and new feature additions are very welcome, please feel free to create a pull request. As a guideline, please do not release separate versions with minor modifications, but contribute to this repository directly. However, if you really do wish to release modified versions of my work, proper credit is always required and you should always link back to this original source and respect the licence.

## Libraries used (many thanks to their authors)
* [CitizenFX.Core.Client](https://www.nuget.org/packages/CitizenFX.Core.Client)
