﻿using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace TripLoggerPublic;
public partial class App : Application
{
    static DatabaseService database;

    public static DatabaseService Database
    {
        get
        {
            if (database == null)
            {
                database = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "logger.db3"));
            }
            return database;
        }
    }

    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }

    protected override void OnStart() { }

    protected override void OnSleep() { }

    protected override void OnResume() { }
}
