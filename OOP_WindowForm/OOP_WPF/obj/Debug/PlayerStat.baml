   M S B A M L   `   `   `  ����B  >OOP_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OOP_WPFOOP_WPF  5   	       OOP_WPF.PlayerStat   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:OOP_WPF     5   	     � Title$  
PlayerStat��5   	   $	��450��6   $	��400��6)    � Icon$ /Icon/trophy.ico��5	   	    � Triggers 5
      :� 5   
    :� RoutedEvent$ Loaded��6   .[�5      �� .��5      ��  g� Duration$ 00:00:3D�6    �� TargetProperty$ Width�60   .��5      W�  W� From$	 600X�6&   	 W� To$	 400X�61   5      5      5      .��5      �� $��Center=�6   $��Center=�6.    � 	Resources 5   
   	 �� 
TargetType
 �� Property �� Value��%R   '��       �� 5      "	 ��6   .�5      �� 
 � ��$ 18(�6-   5      5      .+�5   
   �� -   5         ��Name$ 	lblNumber��5   :   $��99��6   $��Right=�6   $��20(�6M   $
��Bold"�6[   �� 5   
   -   5         ��Name$ playerImage��5   ?   $��/Icon/football-player.png��6   $	��150��63   6?   �� 5   
   -   5         ��Name$ lblName��5      $��	NAME NAME��6%   $��Center=�66   $��25(�6S   $
��Bold"�6a   �� 5   
   -   5        $ 
lblCaptain��5   (   $y�Hidden=�6   $��CAPTAIN��6<   $��Center=�6K   $��15(�6h   $
��Bold"�6v   � 5   
    � ColumnDefinitions 5      �� 5       �� 5!       � RowDefinitions 5#      �� 5$      �� 5%      �� 5&      .+�5(      �� $��
Position: ��6   �� 5)      $��Goals:��6   $��1��6%   �� 5*      $��Yellow cards: ��6   $��2��6-   �� 5+      -   5        $ lblPosition��5+   '   $��POSITION��6   $��0��6<   $��1��6I   �� 5,      -   5        $ lblGoals��5,   -   $��0��6   $��1��6    $��1��6?   �� 5-      -   5        $ 	lblYCards��5-   -   $��0��6   $��2��6    $��1��6@   5.      5/      50      