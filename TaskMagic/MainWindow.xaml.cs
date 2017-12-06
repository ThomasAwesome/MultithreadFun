﻿using System;
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

namespace TaskMagic
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private DoCoolStuff doCoolStuff;
    public MainWindow()
    {
      InitializeComponent();
      doCoolStuff = new DoCoolStuff();
    }

    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      OutText.Inlines.Add("Authenicating to a service");
      await doCoolStuff.Authenicate();

      OutText.Inlines.Add("\n\rMaking request to service");
      var text = await doCoolStuff.MakeRequestForData();

      OutText.Inlines.Add("\n\rDone with stuff");
    }
  }
}
