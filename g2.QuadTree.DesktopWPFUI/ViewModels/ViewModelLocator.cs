﻿namespace g2.Animation.WPFDesktopApp.ViewModels;
public class ViewModelLocator
{
    private readonly MainWindowViewModel mainWindowViewModel = new();

    public MainWindowViewModel MainWindowViewModel
    {
        get { return mainWindowViewModel; }
    }
}

