   M S B A M L   `   `   `  ���� M  IDB_Hotel(prototip), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DB_Hotel_prototip_DB_Hotel_prototip_      DB_Hotel_prototip_.Staff   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:DB_Hotel_prototip_     -     � Title$#  DB_Hotel Сотрудники��$��827.23��$��1059.733��$��827.23��$��1059.733��$
��1080��$
��1920�� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=� � Icon$ H.ico��.���  � RowDefinitions �� .+��� $��
0,0,0,-0.2q����	#FFE5E5E5.@��� -   $��
Data_entry��$��Ввод данных��.��� $��Center=����	#FFE5E5E5$��0,-3,-3,-2.2q�$
��1038�� �� $
��346* �.+��� -   $$��Выход из профиля��$
��Left=�$��
838,69,0,0q�$	��Top=�$	��193��$��20(�$��34���� $
��Left=�$��
441,18,0,0q�$
��Wrap=�$��Сотрудники��$	��Top=�$��20(� J� RenderTransformOrigin$ 1.048,0.519&�$��26��$	��110���� -   $��login_object_input��$
��Left=�$��
838,10,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��18(�$��31��$	��193�� �� TextAlignment$ Center=��� $��Код должности��$
��Left=�$��
39,119,0,0q�$	��Top=�$��16(�$��32��$	��122���� $��Фамилия��$
��Left=�$��570,119,0,0q�$	��Top=�$��16(�$	��122��$��32���� $��Имя��$
��Left=�$��
39,201,0,0q�$	��Top=�$��16(�$ 
0.51,-0.45&�$	��122��$��32���� $��Отчество��$
��Left=�$��570,201,0,0q�$	��Top=�$��16(�$ 0.432,2.794&�$��32��$��77���� $��Возраст��$
��Left=�$��
39,291,0,0q�$	��Top=�$��16(�$ -0.151,0.475&�$��32��$��67���� $��Пол��$
��Left=�$��570,291,0,0q�$	��Top=�$��16(�$ 0.428,0.153&�$��32��$��40���� $(��"Адрес по 
прописке��$
��Left=�$��
36,358,0,0q�$	��Top=�$��16(�$ 2.724,-1.387&�$	��126��$��51���� $B��<Адрес 
фактического 
проживания��$
��Left=�$��570,355,0,0q�$	��Top=�$��16(�$��80��$	��114��$ 
3.74,2.205&��� $��
Серия��$
��Left=�$��
39,468,0,0q�$	��Top=�$��16(�$ 0.298,0.584&�$��32��$��54���� $"��Номер
паспорта��$
��Left=�$��570,458,0,0q�$	��Top=�$��16(�$��51��$	��131���� $ ��Подразделения��$
��Left=�$��
36,554,0,0q�$	��Top=�$��16(�$��32��$	��125��$ 0.326,0.538&��� $��Дата выдачи��$
��Left=�$��570,554,0,0q�$	��Top=�$��16(�$ 0.798,0.481&�$��32��$	��104���� $��Кто выдал��$
��Left=�$��
39,633,0,0q�$	��Top=�$��16(�$ 0.706,0.006&�$��32��$��85���� $��Телефон��$
��Left=�$��570,633,0,0q�$	��Top=�$��16(�$��32��$��74��$ -1.546,2.206&��� -   $
��help��$
��Left=�$��183,119,0,0q�$	��Top=�$	��193��$��32���� -    ��Name$ Familya��$
��Left=�$��32��$��738,119,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -   $
 Imia��$
��Left=�$��32��$��183,201,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -   $ 	Otchestvo��$
��Left=�$��32��$��738,201,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -	   $	 Let��$
��Left=�$��32��$��183,291,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -
   $	��Pol��$
��Left=�$��738,291,0,0q�$	��Top=�$	��193��$��32��.@��� .��Мужской�� .��Женский�� -   $ 
Registered��$
��Left=�$��32��$��183,377,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -   $ Actual��$
��Left=�$��32��$��738,377,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -   $ Ceria��$
��Left=�$��32��$��183,468,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -   $ ID��$
��Left=�$��32��$��738,468,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -   $ Podrazdelenia��$
��Left=�$��32��$��183,554,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -   $
 Date��$
��Left=�$��32��$��738,554,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -   $ Vidol��$
��Left=�$��32��$��183,633,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -   $ 	Telephone��$
��Left=�$��32��$��738,633,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��193��$ 0.503,0.252&�$��20(��� -   $��Отправить��$
��Left=�$��444,711,0,0q�$	��Top=�$	��107��$ 0.139,0.594&�$��16(�$��34���� -   	 ��Name$	 return_1��$
��Left=�$��41��$��	59,33,0,0q�$	��Top=�$��47��$��Strelka.png��$ 0.496,0.537&��� -   
 ��Name$
 login_role_input��$
��Left=�$��23��$��
838,41,0,0q�$
��Wrap=�$	��Top=�$	��193��$ Center=��� $�TextBox���� -   $��Очистить поля��$
��Left=�$��838,711,0,0q�$	��Top=�$	��190��$��34��$ 0.084,0.413&�$��16(��� -   $��Data_output��$��Вывод данных��.��� $��Center=����	#FFE5E5E5$	��774��$	��Top=�$��	8,-3,0,-2q�$
��1040�� � ColumnDefinitions �� .+��� -   $$��Выход из профиля��$
��Left=�$��
835,76,0,0q�$	��Top=�$	��193��$��20(�$��36��$ 0.482,0.528&��� -    ��Name$ explorer_box��$
��Left=�$��
165,89,0,0q�$	��Top=�$	��147��.@��� .��Код сотрудника�� .��Код должности�� .��Фамилия�� .��Имя�� .��Отчество�� .��Возраст�� .��Пол�� .��" Адрес по прописке�� .��:8Адрес фактического проживание�� .��
Серия�� .��Подразделение�� .��Дата выдачи�� .��Кто выдал�� .��Телефон�� -   $ explorer_textBox��$
��Left=�$��26��$��
464,86,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��244��$��16(��� -   $��
Поиск��$
��Left=�$��
723,86,0,0q�$	��Top=�$��75��$��26���� -   $��Delet��$
��Left=�$��26��$��366,129,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��294��$ 
0.223,-0.4&�$��16(��� -   $!��Удалить строку��$
��Left=�$��675,125,0,0q�$	��Top=�$	��123��$��30���� -   $
 login_role_output��$
��Left=�$��23��$��
835,48,0,0q�$
��Wrap=�$	��Top=�$	��193��$ Center=�$ 0.457,0.826&��� $�TextBox��&   System.Windows.Controls.DataGrid  -   $��table��   
IsReadOnly . $
��Left=�$	��575��$��
10,167,0,0q�$	��Top=�$	��779���� -    $	 Fil��$
��Left=�$��835,295,0,0q�$	��Top=�$	��193�� �� Text$ Select Feedback Type:��$ -0.01,0.625&�$��27��.@��� -!    ��Name$ Check_ID_Emp��.��Код сотрудников�� -"   $ Check_ID_Post��.��Код должностей�� -#   $ 	Check_Sur��.��Фамилия�� -$   $ Check_Names��.��Имя�� -%   $ 
Check_Patr��.��Отчество�� -&   $ 
Check_Year��.��Возраст�� -'   $ Check_Gendr��.��Пол�� -(   $ Check_Registered��.��" Адрес по прописке�� -)   $ Check_actual��.��:8Адрес фактического проживание�� -*   $ Check_Series��.��
Серия�� -+   $ Check_ID_Pass��.��Номер паспорта�� -,   $ Check_Subdivision��.��Подразделение�� --   $ 
Check_Date��.��Дата выдачи�� -.   $ Check_Issued��.��Кто выдал�� -/   $ Check_Phones��.��Телефон�� -0   $
 login_object_output��$
��Left=�$��
835,13,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��18(�$ 0.197,0.669&�$	��193��$ Center=�$��30���� $
��Left=�$��
441,18,0,0q�$
��Wrap=�$��Сотрудники��$	��Top=�$��20(�$ 1.048,0.519&�$��26��$	��110���� $.��(Выбор критерия поиска��$
��Left=�$��9,86,0,0q�$	��Top=�$ 0.408,0.458&��� $,��&Ввод значение поиска��$
��Left=�$��
323,86,0,0q�$	��Top=��� -1   $	 return_2��$
��Left=�$��41��$��	59,33,0,0q�$	��Top=�$��47��$��Strelka.png��$ 0.496,0.537&��� $r��lУдаление строки по коду сотрудника, введите код сотрудника��$
��Left=�$��	9,129,0,0q�$	��Top=�$	��357���� $
��Left=�$��838,264,0,0q�$
��Wrap=�$��Выбор поля��$	��Top=�$��20(�$ Center=�$	��190���� -2    ��Name$ button��$,��&Формирование
отчета��$
��Left=�$��837,524,0,0q�$	��Top=�$	��193��$��64��$��20(��� -3   $-��'Очистить выбор
полей��$
��Left=�$��835,610,0,0q�$	��Top=�$	��193��$��61��$��20(��� -4   $��Вывод данных��$
��Left=�$��835,701,0,0q�$	��Top=�$	��193��$ 0.518,3.656&�$��20(�$��41���� -5   $��Data_editing��$/��)Редактирование данных��.��� -6    �Name$ Change��$��Center=����	#FFE5E5E5$	��751��$	��Top=�$��
11,-3,0,-2q�$
��1037�� �� $
��113* ��� $
��939* �.+��� -7   $$��Выход из профиля��$
��Left=�$��
723,81,0,0q�$	��Top=�$	��193��$��20(�$��36��$��1���� -8   $ Staff_ID��$
��Left=�$��63.2,81,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��207��$��32��$��20(�$��1���� $
��Left=�$��328.2,18,0,0q�$
��Wrap=�$��Сотрудники��$	��Top=�$��20(�$ 1.048,0.519&�$��26��$	��110��$��1���� -9   $��login_object_сhange��$
��Left=�$��722.8,13,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��18(�$��26��$	��193��$ Center=�$��1���� $
��Left=�$��725.8,237,0,0q�$
��Wrap=�$��Выбор поле��$	��Top=�$��20(�$ Center=�$	��190��$��1���� $
��Left=�$��723.2,268,0,0q�$	��Top=�$	��193��$��27��$��1��.@��� -:   $ Check_ID_JOB��.��Код должности�� -;   $ Check_Family��.��Фамилия�� -<   $ 
Check_Name��.��Имя�� -=   $ Check_Otchestvo��.��Отчество�� ->   $ 	Check_Age��.��Возраст�� -?   $ 	Check_SEX��.��Пол�� -@   $ Check_Adress��.��" Адрес по прописке�� -A   $ Check_Adress_Act��.��:8Адрес фактического проживание�� -B   $ Check_Seria��.��
Серия�� -C   $ Check_ID_PASS��.��Номер паспорта�� -D   $ 	Check_Pod��.��Подразделение�� -E   $ Check_Date_of_issue��.��Дата выдачи�� -F   $ Check_Issued_by��.��Кто выдал�� -G   $ Check_Phone��.��Телефон�� -H   $/��)Редактирование данных��$
��Left=�$��210.2,658,0,0q�$	��Top=�$	��252��$��16(�$��44��$ 0.525,2.452&�$��1���� -I   $:��4Добавление изменяемых полей��$
��Left=�$��41��$��512.2,661,0,0q�$	��Top=�$	��252��$��16(�$��1���� -J    ��Name$ label��$!��Код сотрудника��$
��Left=�$��	30,81,0,0q�$	��Top=�$��16(�$��2���� -K   $	 return_3��$
��Left=�$��41��$��	59,33,0,0q�$	��Top=�$��47��$��Strelka.png��$ 0.496,0.537&�� -L   $ Grid_Change��$��0,0,-0.2,-5q�$��2���� -M   $��login_role_change��$��1��$
��Left=�$��722.8,50,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$	��193��$ Center=�$��26��