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

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      OutText.Inlines.Add("Authenicating to a service");
      doCoolStuff.Authenicate();

      OutText.Inlines.Add("Making request to service");
      var text = doCoolStuff.MakeRequestForData();

      OutText.Inlines.Add("Done with stuff");
    }
  }
}
