   M S B A M L   `   `   `  ���� D  @Wpfparser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Wpfparser	Wpfparser      Wpfparser.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:Wpfparser       � Title$  Парсер��$	��450��$	��800��$	��450��$	��300�� � Icon$ 
MyIcon.ico��.���  � ColumnDefinitions �� $��72 �$��72��$��72���� �� $	��120 �$	��120��$	��120�� � RowDefinitions �� $��40��$��40��$	��40* ��� $��40 �$��40��$��40���� $
��160* �.+��� -    ��Name$ Output��$��
Вывод��$��0��$��2��$��5,5,5,5q��� -    ��Name$ 	LinkLabel��$��Ссылка:��$��0��$��0��$��Center=�$��Stretch=��� -    ��Name$
 Link��$!��Введите ссылку��$��0��$��1��$��Center=�$��35���� -   $ Header�� �� 
IsReadOnly$
 True��$��1��$��1��$��Center=�$��35���� -   $ HeaderLabel��$��Заголовок:��$��1��$��0��$
��Left=�$��Center=��� -   $ Content��$��0��$��2��$��3��$
 True��$��
10,5,10,10q� �� AcceptsReturn$
 True��	 �� TextWrapping$
	 Wrap=��� -   $ SaveAs��$$��Сохранить в файл��$��1��$��2��$��5,5,5,5q�