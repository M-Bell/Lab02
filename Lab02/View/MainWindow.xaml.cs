﻿using Lab02.Navigation;
using Lab02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab02.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NavigationViewModel _navigationViewModel = new NavigationViewModel();

        public MainWindow()
        {
            InitializeComponent();
            _navigationViewModel.CurrentViewModel = new DataInputViewModel(_navigationViewModel);
            DataContext = new MainViewModel(_navigationViewModel);
        }
    }


}
