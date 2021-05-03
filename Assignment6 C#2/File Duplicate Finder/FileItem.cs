using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Controls;

/// <summary>
/// Haase
/// </summary>
namespace File_Duplicate_Finder
{
    /// <summary>
    /// Klass som hanterar ett FileItem som passar in i en TreeView.
    /// </summary>
    public class FileItem : TreeViewItem
    {
        private FileInfo fileInfo;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="fileInfo">Information om filen.</param>
        /// <param name="isChild">Om FileItemet är root eller child.</param>
        public FileItem(FileInfo fileInfo, bool isChild) : base()
        {
            this.fileInfo = fileInfo;
            if(isChild)
            {
                Header = new CheckBox();
                ((CheckBox)Header).Content = fileInfo.Name;
            }
            else
            {
                Header = fileInfo.Name;
            }
            setToolTip();
        }

        /// <summary>
        /// Hämtar FileInfo-objektet som tillhör FileItemet.
        /// </summary>
        public FileInfo FileInfo { get => fileInfo; }

        /// <summary>
        /// Ställer in tooltip så att den visar information om FileItemet.
        /// </summary>
        private void setToolTip()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Size: " + fileInfo.Length);
            sb.Append("\nExtension: " + fileInfo.Extension);
            sb.Append("\nLast modified: " + fileInfo.LastWriteTime.ToLongTimeString());
            sb.Append("\nDate created: " + fileInfo.CreationTime.ToLongTimeString());
            sb.Append("\nPath: " + fileInfo.FullName);
            ToolTip = sb.ToString();
        }
    }
}
