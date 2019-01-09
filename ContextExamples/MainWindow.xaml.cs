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

namespace ContextExamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GoogleApiWrapper googleApiWrapper;
        private GoogleApiWrapperContextFree googleApiWrapperContextFree;

        public MainWindow()
        {
            InitializeComponent();
            googleApiWrapper = new GoogleApiWrapper();
            googleApiWrapperContextFree = new GoogleApiWrapperContextFree();
        }

        private async void AwaitTrue_OnClick(object sender, RoutedEventArgs e)
        {
            AwaitTrue.IsEnabled = false;
            try
            {
                var html = await googleApiWrapper.MakeRequest();
                Console.WriteLine(html);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                AwaitTrue.IsEnabled = true;
            }
        }

        private async void AwaitFalse_OnClick(object sender, RoutedEventArgs e)
        {
            AwaitFalse.IsEnabled = false;
            try
            {
                var html = await googleApiWrapper.MakeRequest().ConfigureAwait(false);
                Console.WriteLine(html);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                AwaitFalse.IsEnabled = true;
            }
        }

        private async void ContextFree_OnClick(object sender, RoutedEventArgs e)
        {
            ContextFree.IsEnabled = false;
            try
            {
                var html = await googleApiWrapperContextFree.MakeRequest();
                Console.WriteLine(html);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                ContextFree.IsEnabled = true;
            }
        }
    }
}
