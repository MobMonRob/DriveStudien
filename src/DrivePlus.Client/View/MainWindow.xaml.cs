﻿using DrivePlus.Client.ViewModel;

namespace DrivePlus.Client.View
{
    public partial class MainWindow
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
