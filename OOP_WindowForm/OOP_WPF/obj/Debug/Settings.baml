   M S B A M L   `   `   `  ����B  >OOP_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OOP_WPFOOP_WPF  5   	   5clr-namespace:OOP_WPF.ResourcesOOP_WPF.Resources  5   	       OOP_WPF.Settings   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:OOP_WPF     5   	   0propclr-namespace:OOP_WPF.Resources     5   	   -   5          �Name$  settingForm��5   	    � Title$ World Cup 2018��5
   
   $	��600��6!   $	��400��6.    � Icon$ /Icon/trophy.ico��5   	   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��0.5* �6   �� 5      �� 5      $��0.15* �6   .+�5   
   �� $��Center=�6   $��Center=�62   $	��250��6M   .+�5      �� -   5         ��Name$ lblLang��5      �� 5      -   5         ��Name$ btnLanguage��5      $��25��6*       OOP_WPF.Resources.Resource   CurrentLang#��Z 66   6e   5      �� 5   
   $��1��6   $��Center=�6"   $��Center=�6?   $	��250��6Z   .+�5      �� -   5        $ lblSex��5      �� 5      -   5         ��Name$ cbSex��5      ��5      �� 5       �� 
TargetType" ��6   	 �� Triggers	 5      P� 5      
 P� Property
 �@��IsDropDownOpen P� Value . . �5   "   ��  �� Property �@��
IsEditable �� Value . 6N   5      5!      5#      5$      �� 5%   
   $��2��6   $��Center=�6"   $��Center=�6?   $	��250��6Z   .+�5&      �� -   5        $ lblRes��5&      �� 5'      -   5        $ cbResolution��5'      ��5(      �� 5)      " ��6   	 5*      P� 5+      
 �@��IsDropDownOpen . . �5,   "   ��  �@��
IsEditable . 6N   5-      5/      51      52      � 53   
   $��2��6   $��Bottom=�6   $��30��67    � ColumnDefinitions 54      �� 55      $
��0.5* �6#   �� 56      $
��0.5* �6#   .+�58      �� -   5        $ btnSave��58      $
��Save��6&   $��5q�65   
��� � �
�������6f   �� 59      -	   5        $ btnContinue��59      $��Continue��6*   $��1��6=   $��5q�6M   6X   5:      �� 5;   
   $��3��6   .@�5<      �� .��5=      �� -
   5        $ lblSettingsStatus��5=      $��10(�67      SettingsNotSaved#��Z 6E   5>      5?      5@      5B      