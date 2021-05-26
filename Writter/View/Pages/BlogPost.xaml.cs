using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Writter
{
    /// <summary>
    /// Логика взаимодействия для BlogPost.xaml
    /// </summary>
    public partial class BlogPost : Page
    {
        public BlogPost()
        {
            InitializeComponent();
            LoadPage();
        }

        void LoadPage()
        {
           
            WtiteText.AcceptsReturn = true;
            WtiteText .AcceptsTab = true;
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Text Files (*.txt)|*.txt|HTML Files (*.html)|*.html|All files (*.*)|*.*";

                if (ofd.ShowDialog() == true)
                {
                    TextRange doc = new TextRange(WtiteText.Document.ContentStart, WtiteText.Document.ContentEnd);

                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {

                        if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".html")
                            doc.Load(fs, DataFormats.Html);
                        else if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                            doc.Load(fs, DataFormats.Text);
                        else
                            //doc.Load(fs, DataFormats.Xaml);
                            throw new Exception("Wrong format");
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           


        }

        private void SaveText(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|HTML Files (*.html)|*.html|All files (*.*)|*.*";
                if (sfd.ShowDialog() == true)
                {
                    TextRange doc = new TextRange(WtiteText.Document.ContentStart, WtiteText.Document.ContentEnd);
                    using (FileStream fs = File.Create(sfd.FileName))
                    {
                        if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".html")
                            doc.Save(fs, DataFormats.Html);
                        else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                            doc.Save(fs, DataFormats.Text);
                        else
                            //doc.Save(fs, DataFormats.Xaml);
                            throw new Exception("You can save only in the suggested formats!");
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void MaxLen(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (WtiteText.Document.ToString().Length > 1500)
                    throw new Exception("This text is too big!");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}   
