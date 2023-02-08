﻿using System;
using System.Diagnostics;

namespace g2.Animation.DesktopWPFUI;

public static class Time
{
    private static TimeSpan previous;
    private static Stopwatch? watch;
    private static double deltaTime;


    public static void Delta()
    {
        deltaTime = (watch!.Elapsed - previous).TotalSeconds;
        previous = watch.Elapsed;
    }

    private static double? TotalTicksInMilliseconds()
    {
        return watch?.ElapsedTicks / Stopwatch.Frequency * 1000.0;
    }

    public static double DeltaTime
    {
        get
        {
            return deltaTime;
        }
        private set
        {
            deltaTime = value;
        }
    }

    public static void Reset()
    {
        watch = null; // (watch ??= new()).Reset();
    }

    public static void Start()
    {
        if (watch == null)
        {
            watch = new();
            watch.Start();
            previous = watch.Elapsed;
        }
    }
}

