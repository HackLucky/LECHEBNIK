   M S B A M L   `   `   `  ����K  GSokolovLechebnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SokolovLechebnik.WindowsSokolovLechebnik.Windows  5   	   *    $SokolovLechebnik.Windows.StartSplash   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:SokolovLechebnik.Windows     5   	     � Title$  StartSplashScreen��5      $	��540��6'   $	��960��64    � WindowStyle$
 None=�6@    � 
ResizeMode$ NoResize=�6S    � WindowStartupLocation$ CenterScreen=�6i   ��5	      �� 5
   
    �� ImageSource$% /Resources/SplashScreenBack.png��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��960 �6   .+�5   
   �� $
��Left=�6   $	��136��6+   $��	10,10,0,0q�68   $	��Top=�6K   $	��470��6c   $"��/Resources/LechebnikLogo.png��6o    J� OpacityMask 5      �� 5      $" /Resources/LechebnikLogo.png��6   5      �� 5   
   $,��&Загрузка программы...��6   $
��Left=�60   $��
10,490,0,0q�6K   $	��Top=�6_   $��40��6w   $��#Arkhip)�6�   $��20(�6�   $
��Bold"�6�   $��Center=�6�   ���	#FFFEFF00$	��275��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6#   	   
BlurRadius$	 1Q�61   
   ShadowDepth$
 4Q�6@      Opacity$	 0.9Q�6P   5      � 5   
    � IsIndeterminate . $	��Top=�6-   $��10��6E   ���	#FF191919���#00FF00$��	0,530,0,0q�6�   ��6}   Z� 6�   �� 5   
   $&�� Добро пожаловать,��6   $��#Arkhip)�6,   $��36(�6A   
��� ���$��Bottom=�6c   $��160,190,160,270q�6�    5        5      $ Black��6#   $	 1Q�61   $
 4Q�6@   $	 0.9Q�6P   5      �� 5    
   $ ��дорогой гость!��6   $��#Arkhip)�6)   $��36(�6>   
��� � �$��Right=�6^   $��160,270,160,190q�6�    5!        5"      $ Black��6#   $	 1Q�61   $
 4Q�6@   $	 0.9Q�6P   5$      5%      5&      