   M S B A M L   `   `   `  ���� M  IDB_Hotel(prototip), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DB_Hotel_prototip_DB_Hotel_prototip_  $    DB_Hotel_prototip_.Main_Client   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:DB_Hotel_prototip_       � Title$  DB_Hotel Main_Client��$��707.568��$��1402.5�� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=� � Icon$ H.ico��.��� $��Center=�.+��� $.��(Выбор критерий поиска��$
��Left=�$��	15,68,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.408,0.458&�$��20(��� -    ��Name$ explorer_box��$
��Left=�$��
268,70,0,0q�$	��Top=�$	��211��$��35��.@��� .��'%Наименование номера�� .��%#Вместимость номера�� .��Описание номера�� .��!Стоимость номера�� .��)'Наименование сервиса�� .��!Описание сервиса�� .��#!Стоимость сервиса�� $,��&Ввод значение поиска��$
��Left=�$��
511,68,0,0q�$	��Top=�$��20(��� -    ��Name$ explorer_textBox��$
��Left=�$��35��$��
746,70,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��292��$��20(��� -   $��
Поиск��$
��Left=�$��1056,70,0,0q�$	��Top=�$��75��$��35��$ 0.475,1.029&��� -   $��login_object��$
��Left=�$��1184,30,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$	��180�� �� TextAlignment$ Center=�$��26��$��20(��� -   $$��Выход из профиля��$
��Left=�$��1184,61,0,0q�$	��Top=�$	��180��$��37��$��20(��� $
��Left=�$��320,157,0,0q�$
��Wrap=�$��Номера��$	��Top=�$ Center=�$��20(�&   System.Windows.Controls.DataGrid  -   $��table_rooms��$
��Left=�$	��409��$��
35,189,0,0q�$	��Top=�$	��677���� $
��Left=�$��1037,157,0,0q�$
��Wrap=�$��Сервис��$	��Top=�$��20(�$ Center=�  -   $��table_services��$
��Left=�$	��409��$��746,189,0,0q�$	��Top=�$	��618���� -   $��Обновить��$
��Left=�$��666,615,0,0q�$	��Top=�$	��127��$��20(�$��40��