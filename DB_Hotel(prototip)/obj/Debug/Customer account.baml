   M S B A M L   `   `   `  ����M  IDB_Hotel(prototip), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DB_Hotel_prototip_DB_Hotel_prototip_  5   	   )    #DB_Hotel_prototip_.Customer_account   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:DB_Hotel_prototip_     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ DB_Hotel Customer_account��5
   	   ���	#FFE5E5E5$	��450��6B   $	��800��6O    � Icon$ H.ico��6[   .��5      � .+�5   
   �� -   5         ��Name$ return_1��5      $
��Left=�6"   $��33��6=   $��	10,10,0,0q�6I   $	��Top=�6\   $��47��6t   $��Strelka.png��6    J� RenderTransformOrigin$ 0.496,0.537&�6�   6�   �� 5   
   $.��(Выбор критерия поиска��6   $
��Left=�60   $��	10,48,0,0q�6K   $	��Top=�6^   $ 0.408,0.458&�6v   �� 5   
   -   5         ��Name$ explorer_box��5      $
��Left=�6*   $��
160,52,0,0q�6E   $	��Top=�6Y   $	��147��6q   .@�5      �� .��6   Код клиента6(   �� 5      .��6   Фамилия6$   �� 5      .��6   Имя6    �� 5      .��6   Отчество6%   5      �� 5   
   $,��&Ввод значение поиска��6   $
��Left=�6/   $��
326,48,0,0q�6J   $	��Top=�6^   �� 5   
   -   5         ��Name$ explorer_textBox��5      $
��Left=�6,   $��26��6G   $��
467,48,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��244��6�   $��16(�6�   �� 5   
   -   5        $��
Поиск��5      $
��Left=�6!   $��
722,48,0,0q�6<   $	��Top=�6P   $��60��6h   $��26��6s   6   &   System.Windows.Controls.DataGrid  5   
   -   5        $��table��5      	   
IsReadOnly	 . $
��Left=�62   $	��316��6M   $��	10,93,0,0q�6Z   $	��Top=�6m   $	��772��6�   5      5      