using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using DocumentFormat.OpenXml.Validation;

namespace DocxXmlViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = "Word Files(*.docx)|*.docx";
            if (fileDialog.ShowDialog().Value)
                FileInput.Text = fileDialog.FileName;
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox.Text = Util.GetFormattedXml(FileInput.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("We've encountered an exception: " + exception.Message);
            }
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox.Text.SaveAsDocx(FileInput.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox.Text.AsDocument();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            //IEnumerable<ValidationErrorInfo> errors = TextBox.Text.AsDocument().Validate();
            //if (errors.Count() > 0)
            //    errors.Display();
        }
    }
}
