using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libLogger.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true)]
