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

/// <summary>
/// Haase
/// </summary>
namespace File_Duplicate_Finder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileHandler fileHandler;
        public MainWindow()
        {
            InitializeComponent();

            fileHandler = new FileHandler();
        }

        /// <summary>
        /// Återställer fileHandler och treeView. Söker sedan med nya kraven.
        /// </summary>
        private void resetAndSearch()
        {
            treeView.Items.Clear();
            fileHandler.ClearAll();
            setRequirements();

            // Nedan tar programmet bort alla directories som är subdirectories till någon annan vald directory.
            for(int i = 0; i < selectedFoldersListBox.Items.Count - 1; i++)
            {
                for (int j = i + 1; j < selectedFoldersListBox.Items.Count; j++)
                {
                    if(((string)selectedFoldersListBox.Items[i]).StartsWith((string)selectedFoldersListBox.Items[j]))
                    {
                        MessageBox.Show("Folder is subdirectory of another selected folder." +
                            "\nRemoving:\n" + selectedFoldersListBox.Items[i], "Message");
                        selectedFoldersListBox.Items.RemoveAt(i);
                        i--;
                    }
                    else if (((string)selectedFoldersListBox.Items[j]).StartsWith((string)selectedFoldersListBox.Items[i]))
                    {
                        MessageBox.Show("Folder is subdirectory of another selected folder." +
                            "\nRemoving:\n" + selectedFoldersListBox.Items[j], "Message");
                        selectedFoldersListBox.Items.RemoveAt(j);
                        j--;
                    }
                }
            }

            foreach (string item in selectedFoldersListBox.Items)
            {
                string path = item;
                if (Directory.Exists(path))
                {
                    fileHandler.AddFilesFromPath(path);
                }
            }
            fileHandler.CheckDuplicates();
            if(fileHandler.DuplicateLists.Count > 0)
            {
                addFilesToTreeView(fileHandler.DuplicateLists);
            }
            else
            {
                MessageBox.Show("No duplicates found!");
            }
        }

        /// <summary>
        /// Lägger till alla duplicatfiler till TreeView.
        /// </summary>
        /// <param name="duplicateListList">Duplicatfilerna.</param>
        private void addFilesToTreeView(List<List<FileInfo>> duplicateListList)
        {
            foreach (List<FileInfo> duplicateList in duplicateListList)
            {
                FileItem rootItem = new FileItem(duplicateList[0], false);
                foreach (FileInfo fi in duplicateList)
                {
                    FileItem subItem = new FileItem(fi, true);
                    rootItem.Items.Add(subItem);
                }
                treeView.Items.Add(rootItem);
            }
        }

        /// <summary>
        /// Ställer in kraven enligt vad användaren har valt.
        /// </summary>
        private void setRequirements()
        {
            fileHandler.ShouldCompareSize = (bool)sizeCheckBox.IsChecked;
            fileHandler.ShouldCompareExtension = (bool)fileTypesCheckBox.IsChecked;
            fileHandler.ShouldCompareDateModified = (bool)dateModifiedCheckBox.IsChecked;
            fileHandler.ShouldCompareDateCreated = (bool)dateCreatedCheckBox.IsChecked;
        }

        /// <summary>
        /// Hämtar en List med FileInfo som innehåller de element användaren har valt att ta bort.
        /// </summary>
        /// <returns>Lista med element som användaren har valt.</returns>
        private List<FileInfo> getSelectedFilesToDelete()
        {
            List<FileInfo> fileItems = new List<FileInfo>();
            for(int i = 0; i < treeView.Items.Count; i++)
            {
                FileItem root = (FileItem)treeView.Items[i];
                for (int j = 0; j < root.Items.Count; j++)
                {
                    FileItem child = (FileItem)root.Items[j];
                    if ((bool)((CheckBox) child.Header).IsChecked)
                    {
                        fileItems.Add(child.FileInfo);
                        root.Items.RemoveAt(j);
                        j--;
                    }
                }
                if(root.Items.Count < 2)
                {
                    treeView.Items.Remove(root);
                    i--;
                }
            }
            return fileItems;
        }

        private void browseFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            selectedFolderTextBox.Text = folderBrowserDialog.SelectedPath;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedFoldersListBox.Items.Count > 0)
            {
                resetAndSearch();
            }
            else
            {
                MessageBox.Show("No folders chosen. Could not search.", "Error");
            }
        }

        private void addFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if(Directory.Exists(selectedFolderTextBox.Text))
            {
                if(!selectedFoldersListBox.Items.Contains(selectedFolderTextBox.Text))
                {
                    selectedFoldersListBox.Items.Add(selectedFolderTextBox.Text);
                    selectedFolderTextBox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Folder is already included!", "Error");
                }
            }
            else
            {
                MessageBox.Show("Folder not found.", "Error");
            }
        }

        private void removeFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedFoldersListBox.SelectedIndex >= 0)
            {
                selectedFoldersListBox.Items.RemoveAt(selectedFoldersListBox.SelectedIndex);
            }
        }

        private void deleteSelectedFilesButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Delete all selected items?", "Confirm", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                List<FileInfo> deleteList = getSelectedFilesToDelete();
                if(deleteList.Count > 0)
                {
                    fileHandler.DeleteFiles(getSelectedFilesToDelete());
                }
                else
                {
                    MessageBox.Show("No files selected!", "Error");
                }
            }
        }
    }
}
