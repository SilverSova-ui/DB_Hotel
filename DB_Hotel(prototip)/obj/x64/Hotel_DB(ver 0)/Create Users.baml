   M S B A M L   `   `   `  ���� M  IDB_Hotel(prototip), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DB_Hotel_prototip_DB_Hotel_prototip_  %    DB_Hotel_prototip_.Create_Users   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:DB_Hotel_prototip_     -     � Title$  DB_Create_Users��$��576.768��$��943.5�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Icon$ H.ico��.��� .+��� -   $��login_object��$
��Left=�$��
720,13,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��18(�$��26��$	��193�� �� TextAlignment$ Center=� J� RenderTransformOrigin$ 0.498,0.423&��� -    ��Name$ 
login_role��$
��Left=�$��24��$��
720,49,0,0q�$
��Wrap=�$	��Top=�$	��193��$ Center=�$��12(��� $�TextBox���� -   $$��Выход из профиля��$
��Left=�$��
720,78,0,0q�$	��Top=�$	��193��$��37��$��18(��� -    ��Name$ return_1��$
��Left=�$��41��$��	27,52,0,0q�$	��Top=�$��47��$��Strelka.png��$ 0.496,0.537&��� -   $��login��$
��Left=�$��29��$��205,205,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��246��$��18(��� $��
Логин��$
��Left=�$��101,200,0,0q�$	��Top=�$��18(�$��72��$ -0.149,0.521&��� $��Пароль��$
��Left=�$��101,291,0,0q�$	��Top=�$��18(�$ -0.014,0.476&��� $��Роль��$
��Left=�$��101,394,0,0q�$	��Top=�$��18(�$ 0.472,1.321&��� -   $
��Role��$
��Left=�$��205,394,0,0q�$	��Top=�$	��246��$��34��.@��� .��
Admin_BD�� .��
PR_Manager�� .��
ST_Manager�� .��
RP_Manager�� $
��Left=�$��
360,18,0,0q�$
��Wrap=�$1��+Создание пользователей��$	��Top=�$��20(�$ Center=��� -   $��Создать��$
��Left=�$��275,465,0,0q�$	��Top=�$��87��$��35��$��18(�G� -	   $
��Pass��$
��Left=�$��29��$��205,296,0,0q�$	��Top=�$	��246��$��18(�&   System.Windows.Controls.DataGrid  -
   $��table��$
��Left=�$	��176��$��530,252,0,0q�$	��Top=�$	��370���� -   $0��*Вывод данных
о профиле��$
��Left=�$��628,451,0,0q�$	��Top=�$	��193��$ 0.518,3.656&�$��16(�$��49���� -   $��login_check��$
��Left=�$��29��$��654,205,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��246��$��18(��� $#��Проверка Логина��$
��Left=�$��520,205,0,0q�$	��Top=�$��14(�