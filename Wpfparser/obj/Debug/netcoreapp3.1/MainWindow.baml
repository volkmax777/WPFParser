   M S B A M L   `   `   `  ����D  @Wpfparser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Wpfparser	Wpfparser  5   	       Wpfparser.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Wpfparser     5   	     � Title$  Парсер��5   	   $	��450��6   $	��800��6%   $	��450��61   $	��300��6@    � Icon$ 
MyIcon.ico��6P   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��72 �6   $��72��6*   $��72��68   �� 5      �� 5      $	��120 �6   $	��120��6+   $	��120��6:    � RowDefinitions 5   
   �� 5      $��40��6   $��40��6+   $	��40* �6:   �� 5      $��40 �6   $��40��6(   $��40��67   �� 5      $
��160* �6   �� 5      $��30��6   $��30��6+   $	��30* �6:   .+�5   
   �� -   5         ��Name$ Output��5      $��
Вывод��6!   $��0��61   $��2��6>   $��5,5,5,5q�6c   �� 5   
   -   5         ��Name$ 	LinkLabel��5      $��Ссылка:��6#   $��0��65   $��0��6B   $��Center=�6R   $��Stretch=�6t   �� 5   
   -   5         ��Name$
 Link��5      $!��Введите ссылку��6    $��0��66   $��1��6C   $��Center=�6S   $��35��6u   �� 5   
   -   5        $ Header��5       �� 
IsReadOnly$
 True��6"   $��1��64   $��1��6A   $��Center=�6Q   $��35��6s   $��0,0,5,0q�6�   �� 5   
   -   5        $ HeaderLabel��5      $��Заголовок:��6%   $��1��6:   $��0��6G   $
��Left=�6W   $��Center=�6y   �� 5   
   -   5        $ Content��5      $��0��6#   $��2��63   $��3��6@   $
 True��6T   $��	10,5,10,0q�6f    �� AcceptsReturn$
 True��6y   	 �� TextWrapping$
	 Wrap=�6�   	� 5   
   -   5        
 	�Name$
 	Universal��5      $ ��Универсальный��6)   $��1��6A   $��2��6N   $
��Left=�6^   $	��Top=�6y   $��5,2,0,0q�6�    d� 	IsChecked$
 TrueY�6�   $��15��6�   $	��106��6�   	� 5   
   -   5        $
 Lenta��5      $��Lenta.ru��6%   $��1��68   $��2��6E   $��Bottom=�6U   $
��Left=�6p   $��5,0,0,5q�6�   $��15��6�   $��61��6�   �� 5   
   -	   5        $ SaveAs��5      $$��Сохранить в файл��6!   $��4��6<   $��2��6I   $��5,5,5,5q�6n   5      5       