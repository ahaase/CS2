   M S B A M L   `   `   `  ����P  LFile Duplicate Finder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:File_Duplicate_FinderFile_Duplicate_Finder  5   	   &     File_Duplicate_Finder.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:File_Duplicate_Finder     5   	     � Title$$  Duplicate Finder by Alex Haase��5   	   $	��510��60   $	��600��6=   $	��510��6I   $	��600��6Y    � 
ResizeMode$ CanMinimize=�6h   .��5	      � .+�5
   
   �� $��3q�6   
���   �$
��Left=�69   $��Bottom=�6T   $��
10,0,0,118q�6o   $	��160��6�   ._�5      � .+�5      �� -   5         ��Name$ whatToConsiderLabel��5      $��What to consider��65   $��Center=�6P   $	��Top=�6m   $��10,0,0,0q�6�   �� 5      -   5         ��Name$ dateCreatedCheckBox��5      $��Date Created��68   $
��Left=�6O   $��	10,45,0,0q�6j   $	��Top=�6}    d� 	IsChecked$
 TrueY�6�   �� 5      -   5        $ dateModifiedCheckBox��5      $��Date Modified��69   $
��Left=�6Q   $��	10,75,0,0q�6l   $	��Top=�6   $
 TrueY�6�   �� 5      -   5        $ sizeCheckBox��5      $
��Size��61   $
��Left=�6@   $��
10,105,0,0q�6[   $	��Top=�6o   $
 TrueY�6�   �� 5      -   5        $ fileTypesCheckBox��5      $!��File Type (.txt, .png, *.*)��66   $
��Left=�6\   $��10,135,0,10q�6w   $	��Top=�6�   $
 TrueY�6�   5      5      �� 5   
   -   5        $ welcomeLabel��5      $9��3Welcome to the Duplicate File Finder by Alex Haase!��6&   $
��Left=�6d   $��	10,10,0,0q�6   $	��Top=�6�   �� 5   
   $��3q�6   
���   �$
��Left=�69   $	��Top=�6T   $��10, 50, 0, 0q�6l   ._�5      � .+�5      �� -   5        $ selectedFolderLabel��5      $��Selected folder��65   $
��Left=�6O   $	��Top=�6j   $��	10,10,0,0q�6�   �� 5      -   5         ��Name$ selectedFolderTextBox��5      $
��Left=�69   $��10,40,80,10q�6T   $	��Top=�6i   $	��300��6�   �� 5      -	   5         ��Name$ browseFolderButton��5      $��	Browse...��65   $��Right=�6I   $��10,40,10,10q�6e   $	��Top=�6z   6�   �� 5      -
   5        $ addFolderButton��5      $��
Add folder��62   $
��Left=�6G   $��10,70,10,10q�6b   $	��Top=�6w   $	��120��6�   $��25��6�   6�   5      5      �� 5   
   -   5        $ listBoxTitleLabel��5      $��Selected folders:��6+   $��Right=�6G   $��0,9,63,0q�6c   $	��Top=�6u   �� 5    
   -   5         ��Name$ selectedFoldersListBox��5       $��Right=�62   $	��Top=�6N   $	��100��6f   $	��150��6v   $	��100��6�   $	��150��6�   $��	0,40,10,0q�6�   $	��149��6�   $��62��6�   �� 5!   
   -   5        $ removeFolderButton��5!      $��Remove folder��6-   $��Right=�6E   $��
0,145,10,0q�6a   $	��Top=�6u   $��30��6�   $	��150��6�   6�   �� 5"   
   -   5        $ searchButton��5"      $��Search selected folders��6'   $��Right=�6I   $��
0,180,10,0q�6e   $	��Top=�6y   $��30��6�   $	��150��6�   6�   �� 5$   
   -   5        $ treeviewTitleLabel��5$      $��Found Duplicates:��6,   $��Right=�6H   $��0,0,303,255q�6d   $��Bottom=�6y   R� 5%   
   -   5         R�Name$ treeView��5%      $��	0,0,10,10q�6%   $��Right=�68   $��Bottom=�6T   $	��240��6o   $	��390��6   $	��240��6�   $	��390��6�   �� 5&   
   -   5        $ deleteSelectedFilesButton��5&      $��DELETE SELECTED FILES��64   $
��Left=�6T   $��	10,0,0,10q�6o   $��Bottom=�6�   $��62��6�   $	��160��6�   
���  ��
���   �6�   5)      5*      