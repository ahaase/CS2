using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Haase
/// </summary>
namespace File_Duplicate_Finder
{
    /// <summary>
    /// Klass som hanterar filer.
    /// </summary>
    public class FileHandler
    {
        private List<FileInfo> fileList;
        private List<List<FileInfo>> duplicateLists;

        private bool shouldCompareSize;
        private bool shouldCompareExtension;
        private bool shouldCompareDateCreated;
        private bool shouldCompareDateModified;

        /// <summary>
        /// Listan med alla inmatade filer.
        /// </summary>
        public List<FileInfo> FileList { get => fileList; }

        /// <summary>
        /// Listan med listor av duplicerade filer.
        /// </summary>
        public List<List<FileInfo>> DuplicateLists { get => duplicateLists; }

        /// <summary>
        /// Om FileHandler borde jämföra när filen senast ändrades.
        /// </summary>
        public bool ShouldCompareDateModified { get => shouldCompareDateModified; set => shouldCompareDateModified = value; }

        /// <summary>
        /// Om FileHandler borde jämföra när filen skapades.
        /// </summary>
        public bool ShouldCompareDateCreated { get => shouldCompareDateCreated; set => shouldCompareDateCreated = value; }

        /// <summary>
        /// Om FileHandler borde jämföra extensions.
        /// </summary>
        public bool ShouldCompareExtension { get => shouldCompareExtension; set => shouldCompareExtension = value; }

        /// <summary>
        /// Om FileHandler borde jämför storlekar.
        /// </summary>
        public bool ShouldCompareSize { get => shouldCompareSize; set => shouldCompareSize = value; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public FileHandler()
        {
            fileList = new List<FileInfo>();
            duplicateLists = new List<List<FileInfo>>();
        }

        /// <summary>
        /// Söker efter och lägger ihop likadana filer i sina egna (separerade) listor.
        /// </summary>
        public void CheckDuplicates()
        {
            for(int i = 0; i < fileList.Count - 1; i++)
            {
                List<FileInfo> duplicates = new List<FileInfo>();
                duplicates.Add(fileList[i]);
                for (int j = i + 1; j < fileList.Count; j++)
                {
                    if(compareFiles(fileList[i], fileList[j]))
                    {
                        duplicates.Add(fileList[j]);
                        fileList.RemoveAt(j);
                        j--;
                    }
                }
                if(duplicates.Count > 1)
                {
                    duplicateLists.Add(duplicates);
                }
            }
        }

        /// <summary>
        /// Lägger till filer till listan från en vald mapp. Det är en rekursiv metod som
        /// kollar genom alla mappar i mappen.
        /// </summary>
        /// <param name="path">Valda mappen.</param>
        public void AddFilesFromPath(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new Exception("Folder not found!");
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            for (int i = 0; i < directoryInfo.GetFiles().Length; i++)
            {
                fileList.Add(directoryInfo.GetFiles()[i]);
            }

            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            for (int i = 0; i < subDirectories.Length; i++)
            {
                AddFilesFromPath(subDirectories[i].FullName);
            }
        }

        /// <summary>
        /// Återställer båda listorna.
        /// </summary>
        public void ClearAll()
        {
            duplicateLists = new List<List<FileInfo>>();
            fileList = new List<FileInfo>();
        }

        /// <summary>
        /// Tar bort filerna i den inmatade listan.
        /// </summary>
        /// <param name="files">Filer som ska raderas from hårddisken.</param>
        public void DeleteFiles(List<FileInfo> files)
        {
            foreach(FileInfo fi in files)
            {
                if(File.Exists(fi.FullName))
                {
                    File.Delete(fi.FullName);
                }
            }
            fileList.Clear();
        }

        /// <summary>
        /// Jämför två filer enligt användarens krav.
        /// </summary>
        /// <param name="file1">Första filen.</param>
        /// <param name="file2">Andra filen.</param>
        /// <returns>Om filerna är likadana.</returns>
        private bool compareFiles(FileInfo file1, FileInfo file2)
        {
            if(shouldCompareSize)
            {
                if(compareSize(file1, file2) != 0)
                {
                    return false;
                }
            }
            if(shouldCompareExtension)
            {
                if(!compareExtension(file1, file2))
                {
                    return false;
                }
            }
            if(shouldCompareDateCreated)
            {
                if(!compareDateCreated(file1, file2))
                {
                    return false;
                }
            }
            if(shouldCompareDateModified)
            {
                if(!compareDateModified(file1, file2))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Jämför två filers storlek.
        /// </summary>
        /// <param name="file1">Första filen.</param>
        /// <param name="file2">Andra filen.</param>
        /// <returns>0 om filerna har samma storlek, annars !0.</returns>
        private long compareSize(FileInfo file1, FileInfo file2)
        {
            return file1.Length - file2.Length;
        }

        /// <summary>
        /// Jämför två filers extension.
        /// </summary>
        /// <param name="file1">Första filen.</param>
        /// <param name="file2">Andra filen.</param>
        /// <returns>True om filerna har samma extension. Annars false.</returns>
        private bool compareExtension(FileInfo file1, FileInfo file2)
        {
            return file1.Extension.ToLower().Equals(file2.Extension.ToLower());
        }

        /// <summary>
        /// Jämför två filers DateTime då filerna skapades.
        /// </summary>
        /// <param name="file1">Första filen.</param>
        /// <param name="file2">Andra filen.</param>
        /// <returns>True om filerna skapades samtidigt. Annars false.</returns>
        private bool compareDateCreated(FileInfo file1, FileInfo file2)
        {
            // Jag användare ToLongTimeString för annars får jag inga resultat då inga filer skapades
            // på *EXAKT* samma gång.
            return file1.CreationTime.ToLongTimeString().Equals(file2.CreationTime.ToLongTimeString());
        }

        /// <summary>
        /// Jämför två filers DateTime då filerna senast ändrades.
        /// </summary>
        /// <param name="file1">Första filen.</param>
        /// <param name="file2">Andra filen.</param>
        /// <returns>True om båda filerna ändrades senast samtidigt. Annars false.</returns>
        private bool compareDateModified(FileInfo file1, FileInfo file2)
        {
            return file1.LastWriteTime.Equals(file2.LastWriteTime);
        }
    }
}
