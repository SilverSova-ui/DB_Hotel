   M S B A M L   `   `   `  ���� M  IDB_Hotel(prototip), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DB_Hotel_prototip_DB_Hotel_prototip_  #    DB_Hotel_prototip_.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:DB_Hotel_prototip_     -     � Title$  DB_Hotel��$��796.12��$��731.2��$��796.12��$��731.2��$
��1080��$
��1920�� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=�$��20(� � Icon$ H.ico��.��� $��Center=�.+��� -   $��staff��$
��Left=�$	��121��$��380,161,0,0q�$	��Top=�$	��132��$��	Staff.png���� -   $��
staff_text��$
��Left=�$��375,286,0,0q�$
��Wrap=�$��Сотрудники��$	��Top=�$	��132��$��20(�$��Segoe UI Historic)� �� TextAlignment$ Center=��� -   $��	Sql_query��$
��Left=�$��87��$��
74,176,0,0q�$	��Top=�$��88��$��sql.png���� -   $��Sql_query_Text��$
��Left=�$��
61,286,0,0q�$
��Wrap=�$��SQL-Запрос��$	��Top=�$��Segoe UI Historic)�$��20(�$ Center=��� -   $	��job��$
��Left=�$��85��$��220,176,0,0q�$	��Top=�$��80��$��Doljnostei.png���� -   $��job_text��$
��Left=�$��210,286,0,0q�$
��Wrap=�$��Должности��$	��Top=�$��20(�$ Center=��� -   $��Hotel��$
��Left=�$��85��$��580,176,0,0q�$	��Top=�$	��100��$��Room.png���� -	   $��
Hotel_text��$
��Left=�$��545,286,0,0q�$
��Wrap=�$��Номера��$	��Top=�$��Segoe UI Historic)�$��20(�$ Center=�$	��158���� -
   $��Service��$
��Left=�$	��100��$��
82,362,0,0q�$	��Top=�$��60��$��Service.png���� -   $	��Cli��$
��Left=�$	��100��$��410,362,0,0q�$	��Top=�$	��102��$��Clients.png���� -   $��Service_Cli��$
��Left=�$	��100��$��225,364,0,0q�$	��Top=�$	��100��$��Clients-Service.png���� -   $��Service_text��$
��Left=�$��
80,480,0,0q�$
��Wrap=�$��Сервис��$	��Top=�$��Segoe UI Historic)�$ Center=��� -   $��Service_Cli_text��$
��Left=�$��190,478,0,0q�$
��Wrap=�$@��:Услуги предоставляемые клиенту��$	��Top=�$	��177��$ Center=� J� RenderTransformOrigin$ -0.034,0.484&��� -   $��Cli_text��$
��Left=�$��412,481,0,0q�$
��Wrap=�$��Клиенты��$	��Top=��� -    ��Name$ 	textBlock��$
��Left=�$��
310,25,0,0q�$
��Wrap=�$��Hotel_DB��$	��Top=�$��29��$	��107��$��Arial Unicode MS)�$��24(��� -   $��login_object��$
��Left=�$��
514,18,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$	��180��$ Center=�$��36��$��18(��� -   $$��Выход из профиля��$
��Left=�$��514,104,0,0q�$	��Top=�$	��180��$��37���� -    ��Name$ 
Hotel_room��$
��Left=�$	��100��$��
74,176,0,0q�$	��Top=�$��88��$��Hotel rooms.png���� -   $ Hotel_room_text��$
��Left=�$��
61,286,0,0q�$
��Wrap=�$%��Номера гостиницы��$	��Top=�$	��108��$ Center=��� -   $��	Personnel��$
��Left=�$��77��$��
80,186,0,0q�$	��Top=�$��80��$��Personnel.png���� -   $ Personnel_text��$
��Left=�$��
61,286,0,0q�$
��Wrap=�$��Отдел кадров��$	��Top=�$	��108��$ Center=��� -   $ Service_Client��$
��Left=�$��92��$��
80,176,0,0q�$	��Top=�$��89��$��Service_Client.png���� -   $ Service_Client_text��$
��Left=�$��
74,286,0,0q�$
��Wrap=�$!��Услуги клиенту��$	��Top=�$��81��$ Center=��� -   $ 
login_role��$
��Left=�$��24��$��
514,67,0,0q�$
��Wrap=�$	��Top=�$	��179��$ Center=�$��12(��� $�TextBox���� -   $
��User��$
��Left=�$	��100��$��568,571,0,0q�$	��Top=�$	��100��$��Profile+.png���� -   $ Create��$
��Left=�$��80��$��524,676,0,0q�$
��Wrap=�$	��Top=�$	��179��$ Center=�$��20(��� $I�CСоздание или удаление пользователей��