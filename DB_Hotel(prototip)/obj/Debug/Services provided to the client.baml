   M S B A M L   `   `   `  ����M  IDB_Hotel(prototip), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DB_Hotel_prototip_DB_Hotel_prototip_  5   	   8    2DB_Hotel_prototip_.Services_provided_to_the_client   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:DB_Hotel_prototip_     5   	   -   5          � Title$.  (DB_Hotel Services_provided_to_the_client��5   	   $��802.697��6:   $��1059.733��6K   $��802.697��5	   	   $��1059.733��6   $
��1080��5
   	   $
��1920��6    � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ H.ico��6.   .��5      �  � RowDefinitions 5   
   �� 5      .+�5   
   �� $��0,0,-0.4,-0.2q�6   ���	#FFE5E5E5.@�5      �� -   5        $��
Data_entry��5      $��Ввод данных��6(   .��5      � $��Center=�6   ���	#FFE5E5E5$��	0,-3,3,-2q�6K    5      �� 5      $
��346* �6(   .+�5      �� -   5        $$��Выход из профиля��5      $
��Left=�68   $��
767,65,0,0q�6S   $	��Top=�6g   $	��193��6   $��20(�6�   $��34��6�   6�   �� 5      -   5        $��ID_Cli��5      $
��Left=�6-   $��32��6H   $��183,119,0,0q�6T   $	��Top=�6i   $	��193��6�   �� 5      -   5         ��Name$ ID_Ser��5      $
��Left=�6/   $��767,119,0,0q�6J   $	��Top=�6_   $	��193��6w   $��32��6�   �� 5      -   5         ��Name$	 Cos��5      $
��Left=�6+   $��32��6F   $��183,201,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��193��6�    J� RenderTransformOrigin$ 0.503,0.252&�6�   $��20(�6�   �� 5      -   5        $��login_role_input��5       $
��Left=�68   $��
767,40,0,0q�6S   $
��Wrap=�6g   $��	TextBlock��6{   $	��Top=�6�   $	��193��6�   	 �� TextAlignment$	 Center=�6�   $��20��6�   �� 5      $
��Left=�6    $��
340,18,0,0q�6;   $
��Wrap=�6O   $@��:Услуги предоставляемые клиенту��6c   $	��Top=�6�   $��20(�6�   $ 1.048,0.519&�6�   $��26��6�   $	��352��6�   $	 Center=�6�   �� 5      -   5        $��login_object_input��5       $
��Left=�6:   $��	767,9,0,0q�6U   $
��Wrap=�6h   $��	TextBlock��6|   $	��Top=�6�   $��18(�6�   $��26��6�   $	��193��6�   $	 Center=�6�   �� 5      $��Код клиента��6   $
��Left=�62   $��
39,119,0,0q�6M   $	��Top=�6a   $��16(�6y   $��32��6�   $	��122��6�   �� 5      $��Код услуги��6   $
��Left=�61   $��590,119,0,0q�6L   $	��Top=�6a   $��16(�6y   $	��122��6�   $��32��6�   $ 0.528,0.347&�6�   �� 5       $��Стоимость��6   $
��Left=�60   $��
39,201,0,0q�6K   $	��Top=�6_   $��16(�6w   $ 
0.51,-0.45&�6�   $	��122��6�   $��32��6�   �� 5!      -	   5        $��Отправить��5!      $
��Left=�61   $��458,698,0,0q�6L   $	��Top=�6a   $	��107��6y   $ 0.139,0.594&�6�   $��16(�6�   $��34��6�   6�   �� 5"      -
   5        
 ��Name$
 return_1��5"      $
��Left=�6.   $��41��6I   $��	59,33,0,0q�6U   $	��Top=�6h   $��47��6�   $��Strelka.png��6�   $ 0.496,0.537&�6�   6�   5#      5$      �� 5%      -   5        $��Data_output��5%      $��Вывод данных��6)   .��5&      � $��Center=�6   ���	#FFE5E5E5$	��750��6K   $	��Top=�6X   $��	0,-3,3,-2q�6p    � ColumnDefinitions 5'      �� 5(      .+�5*      �� -   5        $$��Выход из профиля��5*      $
��Left=�68   $��
835,89,0,0q�6S   $	��Top=�6g   $	��193��6   $��20(�6�   $��36��6�   $ 0.5,0.5&�6�   6�   �� 5+      -   5        $ explorer_box��5+      $
��Left=�66   $��
165,89,0,0q�6Q   $	��Top=�6e   $	��147��6}   .@�5,      �� .��6'   Код клиента64   �� 5-      .��6'   Код услуги63   �� 5.      .��6'   Описание61   5/      �� 50      -   5        $ explorer_textBox��50      $
��Left=�68   $��26��6S   $��
464,86,0,0q�6_   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��244��6�   $��20(�6�   �� 51      -   5        $��
Поиск��51      $
��Left=�6-   $��
723,86,0,0q�6H   $	��Top=�6\   $��75��6t   $��26��6   6�   �� 52      -   5        $��Delet��52      $
��Left=�6+   $��26��6F   $��330,129,0,0q�6R   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��330��6�   $ 
0.223,-0.4&�6�   $��16(�6�   �� 53      -   5        $��Delet_Button��53      $!��Удалить строку��61   $
��Left=�6J   $��675,125,0,0q�6e   $	��Top=�6z   $	��123��6�   $��30��6�   6�   &   System.Windows.Controls.DataGrid  54      -   5        $��table��54         
IsReadOnly . $
��Left=�6>   $	��578��6Y   $��
10,167,0,0q�6f   $	��Top=�6z   $	��779��6�   �� 55      -   5        $	 Fil��55      $
��Left=�6,   $��835,273,0,0q�6G   $	��Top=�6\   $	��193��6t    �� Text$ Select Feedback Type:��6�   $ -0.01,0.625&�6�   $��27��6�   .@�56      �� -   5         ��Name$ 	Check_Cli��56   #   .��66   Код клиента6C   �� 57      -   5        $ Check_ID_Ser��57   #   .��69   Код услуги6E   �� 58      -   5        $ 
Check_Cost��58   #   .��67   Описание6A   59      �� 5:      -   5         ��Name$ button��5:      $,��&Формирование
отчета��6-   $
��Left=�6T   $��838,494,-1.4,0q�6o   $	��Top=�6�   $	��193��6�   $��64��6�   $��20(�6�   6�   �� 5;      -   5        $-��'Очистить выбор
полей��5;      $
��Left=�6E   $��838,579,0,0q�6`   $	��Top=�6u   $	��190��6�   $��61��6�   $��20(�6�   6�   �� 5<      -   5        $��Вывод данных��5<      $
��Left=�64   $��835,673,0,0q�6O   $	��Top=�6d   $	��193��6|   $ 0.518,3.656&�6�   $��20(�6�   $��41��6�   6�   �� 5=      -   5         ��Name$ login_object_output��5=       $
��Left=�6=   $��
835,21,0,0q�6X   $
��Wrap=�6l   $��	TextBlock��6�   $	��Top=�6�   $��18(�6�   $ 0.197,0.669&�6�   $	��193��6�   $	 Center=�6�   �� 5>      -   5        $ login_role_output��5>       $
��Left=�6;   $��23��6V   $��
835,51,0,0q�6b   $
��Wrap=�6v   $	��Top=�6�   $	��193��6�   $	 Center=�6�   �� 6�   $�TextBox��6�   6�   �� 5?      $
��Left=�6    $��
323,11,0,0q�6;   $
��Wrap=�6O   $@��:Услуги предоставляемые клиенту��6c   $	��Top=�6�   $��20(�6�   $ 1.048,0.519&�6�   $��26��6�   $	��333��6�   $	 Center=�6�   �� 5@      $.��(Выбор критерия поиска��6   $
��Left=�6<   $��9,86,0,0q�6W   $	��Top=�6i   $ 0.408,0.458&�6�   �� 5A      $,��&Ввод значение поиска��6   $
��Left=�6;   $��
323,86,0,0q�6V   $	��Top=�6j   �� 5B      -   5        $
 return_2��5B      $
��Left=�6.   $��41��6I   $��	59,33,0,0q�6U   $	��Top=�6h   $��47��6�   $��Strelka.png��6�   $ 0.496,0.537&�6�   6�   �� 5C      -   5        $��Delet_label��5C      $f��`Удаление строки по коду клиенту, введите код клиента��6/   $
��Left=�6n   $��
10,127,0,0q�6�   $	��Top=�6�   $	��320��6�   �� 5E      $
��Left=�6    $��835,242,0,0q�6;   $
��Wrap=�6P   $��Выбор поля��6d   $	��Top=�6v   $��20(�6�   $	 Center=�6�   $	��190��6�   5F      5G      �� 5H      -   5        $��Data_editing��5H      $/��)Редактирование данных��6*   .��5I      � -   5         �Name$ Change��5I   4   $��Center=�6   ���	#FFE5E5E5$	��751��6[   $	��Top=�6h   $��	0,-3,3,-2q�6�   .+�5J      �� -    5        $$��Выход из профиля��5J      $
��Left=�68   $��
836,77,0,0q�6S   $	��Top=�6g   $	��193��6   $��20(�6�   $��36��6�   6�   �� 5K      -!   5        $ Services_ID��5K      $
��Left=�63   $��
176,81,0,0q�6N   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��207��6�   $��32��6�   $��20(�6�   �� 5L      -"   5        $ 	Client_ID��5L      $
��Left=�61   $��
568,80,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��207��6�   $��32��6�   $��20(�6�   �� 5M      $
��Left=�6    $��
333,18,0,0q�6;   $
��Wrap=�6O   $@��:Услуги предоставляемые клиенту��6c   $	��Top=�6�   $��20(�6�   $ 1.048,0.519&�6�   $��26��6�   $	��350��6�   $	 Center=�6�   �� 5N      -#   5        $��login_object_сhange��5N       $
��Left=�6;   $��	836,9,0,0q�6V   $
��Wrap=�6i   $��	TextBlock��6}   $	��Top=�6�   $��18(�6�   $��26��6�   $	��193��6�   $	 Center=�6�   �� 5O      -$   5        $ login_role_change��5O       $
��Left=�6;   $��23��6V   $��
835,51,0,0q�6b   $
��Wrap=�6v   $	��Top=�6�   $	��193��6�   $	 Center=�6�   �� 6�   $�TextBox��6�   6�   �� 5P      $
��Left=�6    $��835,236,0,0q�6;   $
��Wrap=�6P   $��Выбор поле��6d   $	��Top=�6v   $��20(�6�   $	 Center=�6�   $	��190��6�   �� 5Q      $
��Left=�6   $��836,268,0,0q�6:   $	��Top=�6O   $	��193��6g   $��27��6s   .@�5R      �� -%   5        $ Check_ID_Cliet��5R   #   .��6;   Код клиента6H   �� 5S      -&   5        $ Check_ID_Serv��5S   #   .��6:   Код услуги6F   �� 5T      -'   5        $ Check_Costs��5T   #   .��68   Стоимость6C   5U      �� 5V      -(   5        $/��)Редактирование данных��5V      $
��Left=�6=   $��323,658,0,0q�6X   $	��Top=�6m   $	��252��6�   $��16(�6�   $��44��6�   $ 0.525,2.452&�6�   6�   �� 5W      -)   5        $:��4Добавление изменяемых полей��5W      $
��Left=�6C   $��41��6^   $��625,661,0,0q�6j   $	��Top=�6   $	��252��6�   $��16(�6�   6�   �� 5X      -*   5         ��Name$ label��5X      $��Код клиента��6+   $
��Left=�6A   $��	30,81,0,0q�6\   $	��Top=�6o   $��16(�6�   �� 5Z      -+   5        $ label_1��5Z      $��Код услуги��6-   $
��Left=�6B   $��
443,80,0,0q�6]   $	��Top=�6q   $��16(�6�   �� 5\      -,   5        $
 return_3��5\      $
��Left=�6.   $��41��6I   $��	59,33,0,0q�6U   $	��Top=�6h   $��47��6�   $��Strelka.png��6�   $ 0.496,0.537&�6�   6�   � 5]      --   5        $ Grid_Change��5]      $��0,0,0,-5q�60   6D   5^      5_      5`      5a      5b      