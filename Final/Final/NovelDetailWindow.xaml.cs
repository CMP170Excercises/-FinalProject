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
using System.Windows.Shapes;

namespace Final
{
    /// <summary>
    /// Interaction logic for NovelDetailWindow.xaml
    /// </summary>
    public interface ICloseable
    {
        event EventHandler CloseRequest;
    }
    public partial class NovelDetailWindow : Window
    {
        public NovelDetailWindow(ICloseable context)
        {
            InitializeComponent();
            context.CloseRequest += (s, e) => this.Close();
        }
    }
}
