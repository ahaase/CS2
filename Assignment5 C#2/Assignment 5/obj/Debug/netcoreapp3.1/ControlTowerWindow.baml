   M S B A M L   `   `   `  ����G  CAssignment 5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Assignment_5Assignment_5  5   	   %    Assignment_5.ControlTowerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Assignment_5     5   	     � Title$  Control Tower��5   	   $	��450��6   $	��500��6,    � 
ResizeMode$ CanMinimize=�5	   	   .��5
      � .+�5   
   �� -   5         ��Name$ listView��5      $��10,10,10,38q�6%    �� View 5      �� 5      .P�5      �� $��Flight Code��6%    �� Width$	 130��6:    �� DisplayMemberBinding 6F   �� *
FlightCode+�� 5      $��Status��6%   $	 210��65    6A   �� *StatusString+�� 5      $
��Time��6%   $	 130��63    6?   �� *Time+5      5      �� 5   
   -   5         ��Name$ nextFlightLabel��5      $��Next Flight:��6)   $
��Left=�6@   $��10,0,0,6q�6[   $��Bottom=�6m    J� RenderTransformOrigin$ -3.616,0.533&�6�   �� 5   
   -   5         ��Name$ nextFlightTextBox��5      $
��Left=�6-   $��	95,0,0,10q�6H   $�� ��6[   	 �� TextWrapping$
	 Wrap=�6c   $��Bottom=�6w   $	��115��6�   �� 5   
   -   5        
 ��Name$
 sendNextAirplaneButton��5      $"��Send next Airplane to Runway��61   $��Right=�6X   $��	0,0,90,10q�6t   $��Bottom=�6�   $	��172��6�   6�   �� 5   
   -   5        $
 viewLogButton��5      $��View Log��6(   $��Right=�6;   $��	0,0,10,10q�6W   $��Bottom=�6j   $��70��6�   6�   5      5      