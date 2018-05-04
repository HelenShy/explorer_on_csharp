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
using System.IO;
using System.Collections.ObjectModel;

namespace TotalCommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// Plans to do
    /// - Back, Ahead Buttons
    /// - Change View
    /// - 3d field (view files, info about them)
    /// - leftListview add structure
    /// - StatusBar add info
    /// - InstrumentPanel add
    /// - RightView at loading
    /// - change columnwidth
    /// - drag n drop
    /// - ContextMenu
    public partial class MainWindow : Window
    {
        public ObservableCollection<RootFolder> DirList = new ObservableCollection<RootFolder>();

        public ObservableCollection<Item> ItemList = new ObservableCollection<Item>();

        public MainWindow()
        {
            InitializeComponent();
            foreach (var dir in MyComputer.GetDirectories())
            {
                DirList.Add(dir);
            }
            leftView.ItemsSource = DirList;
        }

        private void leftView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RootFolder selection = (RootFolder)leftView.SelectedItem;
            this.OpenFolder(selection.Path);
            rightView.ItemsSource = ItemList;
        }

        private void rightView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item selection = (Item)rightView.SelectedItem;
            if (selection.Type=="Directory")
            {
                this.OpenFolder(selection.Path);
                rightView.ItemsSource = ItemList;
            }
            else
            {
                System.Diagnostics.Process.Start(selection.Path);
            }
        }

        public void OpenFolder(string Path)
        {
            ObservableCollection<Item> ItemList_Copy = new ObservableCollection<Item>();
            foreach (var item in ItemList)
            {
                ItemList_Copy.Add(item);
            }
            ItemList.Clear();
            FolderContent fc = new FolderContent(Path);
            try
            {    
                ItemList = fc.GetContent();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                ItemList = ItemList_Copy;
            }
        }
    }

    
}
