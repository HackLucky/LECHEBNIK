   M S B A M L   `   `   `  ����K  GSokolovLechebnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SokolovLechebnik.WindowsSokolovLechebnik.Windows  5   	   $    SokolovLechebnik.Windows.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:SokolovLechebnik.Windows     5   	     � Title$/  )ЛЕЧЕБНИК [АВТОРИЗАЦИЯ]��5   	   $	��540��6(   $	��960��65   $	��960��6W   $	��540��6f    � Icon$ /Resources/favicon.ico��6v    � WindowStartupLocation$ CenterScreen=�6�   ��6A   Z� .��5	      � -   5         �Name$ GridMain��5	      ���	#FFAFAFAF � RowDefinitions 5
   
   �� 5      $
��0.2* �6   �� 5      $��0.70* �6   �� 5      $
��0.1* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � .+�5      �� -   5         ��Name$ MainLogoFull��5      $"��/Resources/LechebnikLogo.png��6*   5      � 5   
   $��1��6    5      �� 5      $��0.15* �6    �� 5      $��0.85* �6    .+�5      �� -   5         ��Name$ LabelMainReg��5      $��АВТОРИЗАЦИЯ��6*   $��Arial)�6@   $��48(�6S   $��Center=�6a   $��Center=�6�   
��� � �$��
UltraBlack"�6�   $��0,0,0,0q�6�   
��� � �$��	10,0,10,0q�6  ��6�   Z�  J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   Color$	 Black��6'   
   
BlurRadius$
 1Q�65      ShadowDepth$ 4Q�6D      Opacity$ 1Q�6T   5       �� 5!      -   5         ��Name$ BorderLabelMainReg��5!      $��	15,3,15,3q�61   $��	10,0,10,0q�6M   ��5"      �� 5#       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;    �� RelativeTransform 5$      V� 5%      .~�5&   "   ��  �� CenterY$	 0.5Q�61    �� CenterX$	 0.5Q�6?   �� 5'   "    �� CenterX$	 0.5Q�60    �� CenterY$	 0.5Q�6>   �� 5(   "    �� Angle$	 -90Q�62    �� CenterX$	 0.5Q�6>    �� CenterY$	 0.5Q�6L   T� 5)   "   5*      .��5,      �  � Color$ Yellow��6'    � Offset$
 0.15Q�66   � 5-      $ 	#00AFAFAF��6'   $
 0.15Q�69   � 5.      $ 	#00AFAFAF��6'   $
 0.85Q�69   � 5/      $ Yellow��6'   $
 0.85Q�66   50      ��52      �� 53       �� 
TargetType" ��6   .�54      ��  �� Property �@J�Effect �� Value 55        56   "   $	 Black��63   $
 1Q�6A   $ 4Q�6P   $ 1Q�6`   58      59      5;      �� 5<      ���	#FF323232$��3,3,3,3q�6-   $��1��6G   $��10,10,10,10q�6T   ���	#FF646464 5=        5>      $	 Black��6'   $
 1Q�65   $ 4Q�6D   $ 1Q�6T   ._�5@      �  5A      �� 5B      $
��0.1* �6(   �� 5C      $
��0.1* �6(   �� 5D      $��0.15* �6(   �� 5E      $
��0.1* �6(   �� 5F      $
��0.1* �6(   �� 5G      $
��0.1* �6(   �� 5H      $
��0.1* �6(   �� 5I      $
��0.1* �6(   �� 5J      $
��0.1* �6(   .+�5L      �  5M      �� 5N      $
��Auto �6/   �� 5O      $
��289* �6/   .+�5Q      �� -   5        $ 	LabelMail��5Q       $��Почта:��63   $��Right=�6D   $��Center=�6g   $��0,0,10,0q�6�   $��Arial)�6�   $��18(�6�   $
��Bold"�6�   
��� ���
��� ���$��0,0,10,0q�6�   $��167.524017467249��6  $��28.7100464967132��6/   5R        5S   "   $	 Black��63   $
 1Q�6A   $ 4Q�6P   $ 1Q�6`   5U      �� 5V      -   5         ��Name$ TextBoxMail��5V   "   $��1��67   $��Center=�6G   $��Arial)�6i   ��. $��18(�6�   ���	#FF323232
��� � �$��1,1,10,1q�6�   $��0��65  .��6B  ��5W      �� 5X   "    �� 
TargetType" ��62   .R�5Y   &   �� #��z��6-   #��z��5Z   -   #��z��5[   -    �� CornerRadius$ 	0,10,10,0��5\   -   ._�5]   *   ��   ��Name$  PART_ContentHost��67   5^   '   5_   #   .��5`   0   ! �� 
CaretBrush! 5a      �� 5b   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5c   &   � $ Yellow��63   $	 0.3Q�6B   � 5d   &   $
 Lime��63   $	 0.7Q�6@   � 5e   &   $
 Lime��63   $	 0.3Q�6@   � 5f   &   $ Yellow��63   $	 0.7Q�6B   5g   #   .��5h   2   " �� SelectionBrush" 5i      �� 5j   "   # �� Color$# Yellow��62   $ �� Opacity$	$ 0.8Q�6A   .��5k   6   % �� SelectionTextBrush% 5l      �� 5m   "   $# 	#FF14FF00��62   $	$ 0.5Q�6D   .��5n   :   ��5o      �� 5p   "   $ 0.5,1&�66   $ 0.5,0&�6G    5q   &   V� 5r   *   .~�5s   .   �� $	 0.5Q�6=   $	 0.5Q�6K   �� 5t   .   $	 0.5Q�6<   $	 0.5Q�6J   �� 5u   .   $	 -90Q�6>   $	 0.5Q�6J   $	 0.5Q�6X   T� 5v   .   5w   +   .��5y   &   � $ 	#FFAFAFAF��63   $	 0.9Q�6E   � 5z   &   $
 Lime��63   $	 0.9Q�6@   5{   #   .��5|   3   5}      5~      � 5      $��1��6    5�      �� 5�      $
��Auto �6/   �� 5�      $
��289* �6/   .+�5�      �� -   5        $ 	LabelPass��5�       $��Пароль:��63   $��Right=�6E   $��Center=�6h   $��0,0,10,0q�6�   $��Arial)�6�   $��18(�6�   $
��Bold"�6�   
��� ���
��� ���$��0,0,10,0q�6�   $��167.524017467249��6  $��28.7100464967132��60   5�        5�   "   $	 Black��63   $
 1Q�6A   $ 4Q�6P   $	 0.9Q�6`   5�      G� 5�      -   5        & G�Name$& TextBoxPass��5�   &   $��1��6;   $��Center=�6K   $��Arial)�6m   ��. $��18(�6�   ���	#FF323232$��0,0,0,1q�6�   
��� � �$��1,1,10,1q�6�   $��1��6K  ��5�      �� 5�   "   " G�62   .R�5�   &   �� #��z��6-   #��z��5�   -   #��z��5�   -   $ 	0,10,10,0��5�   -   ._�5�   *   �� $  PART_ContentHost��67   5�   '   5�   #   ' G� 
CaretBrush' 5�      �� 5�   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5�   &   � $ Yellow��63   $	 0.3Q�6B   � 5�   &   $
 Lime��63   $	 0.7Q�6@   � 5�   &   $
 Lime��63   $	 0.3Q�6@   � 5�   &   $ Yellow��63   $	 0.7Q�6B   5�   #   ( G� SelectionBrush( 5�      �� 5�   "   $# Yellow��62   $	$ 0.8Q�6A   ) G� SelectionTextBrush) 5�      �� 5�   "   $# 	#FF14FF00��62   $	$ 0.5Q�6D   ��5�      �� 5�   "   $ 0.5,1&�66   $ 0.5,0&�6G    5�   &   V� 5�   *   .~�5�   .   �� $	 0.5Q�6=   $	 0.5Q�6K   �� 5�   .   $	 0.5Q�6<   $	 0.5Q�6J   �� 5�   .   $	 -90Q�6>   $	 0.5Q�6J   $	 0.5Q�6X   T� 5�   .   5�   +   .��5�   &   � $ 	#FFAFAFAF��63   $	 0.9Q�6E   � 5�   &   $
 Lime��63   $	 0.9Q�6@   5�   #   5�      5�      � 5�      $��2��6    5�      �� 5�      $
��Auto �6/   �� 5�      $
��289* �6/   5�      � 5�      $��3��6    5�      �� 5�      $
��Auto �6/   �� 5�      $
��289* �6/   5�      � 5�      $��4��6    5�      �� 5�      $
��Auto �6/   �� 5�      $
��289* �6/   .+�5�      �� $��Arial)�6    $��18(�63   $��Center=�6A   ���	#FF969600$ ��Забыли пароль?��6z   $��Center=�6�   $��2��6�   {�.   5�        5�   "   $	 Black��63   $
 1Q�6A   $ 4Q�6P   $	 0.9Q�6`   5�      5�      � 5�      $��5��6    5�      �� 5�      $
��Auto �6/   �� 5�      $	��66* �6/   �� 5�      $
��161* �6/   .+�5�      �� -	   5        * ��Name$* ButtonVoityRemember��5�   !   $��Arial)�6>   $
��Bold"�6Q   $��20(�6c   ���	#00000000���	#FF969600$��1��6�   $��0,0,0,0q�6�   $��2��6�   + � Cursor$
+ Hand��6�   $��3��6�   {�.  ��6�   Z� ��5�      �� 5�   "   " ��62   .R�5�   &   �� #��z��6-   $��	20,5,20,5q�6W   ��5�   *   �� 5�   .   $ 0.5,1&�6B   $ 0.5,0&�6S    5�   2   V� 5�   6   .~�5�   :   �� $	 0.5Q�6I   $	 0.5Q�6W   �� 5�   :   $	 0.5Q�6H   $	 0.5Q�6V   �� 5�   :   $	 -45Q�6J   $	 0.5Q�6V   $	 0.5Q�6d   T� 5�   :   5�   7   .��5�   2   � $ 	#FF969600��6?   $
 0.25Q�6Q   � 5�   2   $ 	#00AFAFAF��6?   $
 0.25Q�6Q   � 5�   2   $ 	#00AFAFAF��6?   $
 0.75Q�6Q   � 5�   2   $ 	#FF969600��6?   $
 0.75Q�6Q   5�   /   ._�5�   *   �� $��Center=�6;   $��Center=�6X   5�   '   5�   #   ��5�      �� 5�   "   " ��6(   .�5�   &   ��  �@J�Effect 5�   *     5�   .   $
	 #000��6?   $
 0Q�6L   $ 4Q�6[   5�   '   , �� Triggers, 5�   &   P� 5�   *   - P� Property- �@J�IsMouseOver. P� Value. . . �5�   .   ��  � �� �	#FF9696006K   �� 5�   .    �@J�Effect 5�   2     5�   6   $	 	#FF969600��6G   $
 15Q�6Y   $ 0Q�6i   5�   /   5�   +   P� 5�   *   - � ��. . . �5�   .   ��  � ��
 �   �6K   �� 5�   .    �@J�Effect 5�   2     5�   6   $	 Black��6G   $
 20Q�6U   $ 0Q�6e   5�   /   5�   +   5   #   .��5     �� -
   5        / ��Name$/ TextBlockVoity1��5  (   $%��ВСПОМНИТЬ ПАРОЛЬ��6A   $
+ Hand��6Y   5     5     � 5     $��7��6    5     �� 5     $
��Auto �6/   �� 5     $
��289* �6/   .+�5
     �� $��Arial)�6    $��18(�63   $��Center=�6A   
��� ���$/��)Или, если нет аккаунта:��6w   $��Center=�6�   $��2��6�    5       5  "   $	 Black��63   $
 1Q�6A   $ 4Q�6P   $	 0.9Q�6`   5     5     � 5     $��8��6    5     �� 5     $
��Auto �6/   �� 5     $
��247* �6/   .+�5     �� -   5        $* 	ButtonReg��5  !   $��Arial)�64   $
��Bold"�6G   $��20(�6Y   ���	#00000000
��� ���$��1��6�   $��0,0,0,0q�6�   $
+ Hand��6�   $��4��6�   ��6�   Z� ��5     �� 5  "   " ��62   .R�5  &   �� #��z��6-   $
��20,5q�6W   ��5  *   �� 5  .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5  2   � $ Yellow��6?   $
 0.25Q�6N   � 5  2   $ 	#00AFAFAF��6?   $
 0.25Q�6Q   � 5  2   $ 	#00AFAFAF��6?   $
 0.75Q�6Q   � 5  2   $ Yellow��6?   $
 0.75Q�6N   5  /   ._�5!  *   �� $��Center=�6;   $��Center=�6X   5"  '   5#  #   ��5%     �� 5&  "   " ��6(   .�5'  &   ��  �@J�Effect 5(  *     5)  .   $	 Yellow��6?   $
 10Q�6N   $ 0Q�6^   5+  '   , 5,  &   P� 5-  *   - �@J�IsMouseOver. . . �5.  .   ��  � �� �	#FF9696006K   �� 5/  .    �@J�Effect 50  2     51  6   $	 	#FF969600��6G   $
 15Q�6Y   $ 0Q�6i   53  /   54  +   P� 55  *   - � ��. . . �56  .   ��  � ��
 �   �6K   �� 57  .    �@J�Effect 58  2     59  6   $	 Black��6G   $
 20Q�6U   $ 0Q�6e   5;  /   5<  +   5>  #   .��5@     �� -   5        $/ TextBlockVoity��5@  (   $*��$ЗАРЕГИСТРИРОВАТЬСЯ��6@   $
+ Hand��6Z   5A     5B     �� 5C     -   5        $* ButtonVoity��5C     $��2��63   $��Arial)�6@   $
��Bold"�6S   $��24(�6e   ���	#00000000
��� ���$��0,0,0,0q�6�   $
+ Hand��6�   $��2��6�   ��6�   Z� ��5D     �� 5E     " ��6.   .R�5F  "   �� #��z��6)   $��	20,5,20,5q�6S   ��5G  &   �� 5H  *   $ 0.5,1&�6>   $ 0.5,0&�6O    5I  .   V� 5J  2   .~�5K  6   �� $	 0.5Q�6E   $	 0.5Q�6S   �� 5L  6   $	 0.5Q�6D   $	 0.5Q�6R   �� 5M  6   $	 -45Q�6F   $	 0.5Q�6R   $	 0.5Q�6`   T� 5N  6   5O  3   .��5Q  .   � $ Yellow��6;   $
 0.25Q�6J   � 5R  .   $ 	#00AFAFAF��6;   $
 0.25Q�6M   � 5S  .   $ 	#00AFAFAF��6;   $
 0.75Q�6M   � 5T  .   $ Yellow��6;   $
 0.75Q�6J   5U  +   ._�5W  &   �� $��Center=�67   $��Center=�6T   5X  #   5Y     ��5[     �� 5\     " ��6$   .�5]  "   ��  �@J�Effect 5^  &     5_  *   $	 Yellow��6;   $
 10Q�6J   $ 0Q�6Z   6l   5a  #   , 5b  "   P� 5c  &   - �@J�IsMouseOver. . . �5d  *   ��  � �� �	#FF9696006G   �� 5e  *    �@J�Effect 5f  .     5g  2   $	 	#FF969600��6C   $
 15Q�6U   $ 0Q�6e   5i  +   5j  '   P� 5k  &   - � ��. . . �5l  *   ��  � ��
 �   �6G   �� 5m  *    �@J�Effect 5n  .     5o  2   $	 Black��6C   $
 20Q�6Q   $ 0Q�6a   5q  +   5r  '   5t     .��5v     �� -   5        $/ TextBlockReg��5v  $   $��
ВОЙТИ��6:   $
+ Hand��6G   6W   5w     5x     5y     5z     � 5{  
   $��2��6   .+�5|     �� -   5        $* 
ButtonExit��5|     $��Arial)�6)   $
��Bold"�6<   
������ 
��� ���$��0q�6{   $��24(�6�   $
��13,0q�6�   $
+ Hand��6�   $��1��6�   $��9��6�   ��6�   Z� ��5}     �� 5~     " ��6&   .R�5     �� #��z��6!   $
��20,5q�6K   ��5�     �� 5�  "   $ 0.5,1&�66   $ 0.5,0&�6G    5�  &   V� 5�  *   .~�5�  .   �� $	 0.5Q�6=   $	 0.5Q�6K   �� 5�  .   $	 0.5Q�6<   $	 0.5Q�6J   �� 5�  .   $	 -45Q�6>   $	 0.5Q�6J   $	 0.5Q�6X   T� 5�  .   5�  +   .��5�  &   � $ Yellow��63   $
 0.25Q�6B   � 5�  &   $ 	#00AFAFAF��63   $
 0.25Q�6E   � 5�  &   $ 	#00AFAFAF��63   $
 0.75Q�6E   � 5�  &   $ Yellow��63   $
 0.75Q�6B   5�  #   ._�5�     �� $��Center=�6/   $��Center=�6L   5�     5�     ��5�     �� 5�     " ��6   .�5�     ��  �@J�Effect 5�       5�  "   $	 Yellow��63   $
 10Q�6B   $ 0Q�6R   5�     , 5�     P� 5�     - �@J�IsMouseOver. . . �5�  "   ��  � �� �	#FF9696006?   �� 5�  "    �@J�Effect 5�  &     5�  *   $	 	#FF969600��6;   $
 15Q�6M   $ 0Q�6]   5�  #   5�     P� 5�     - � ��. . . �5�  "   ��  � ��
 �   �6?   �� 5�  "    �@J�Effect 5�  &     5�  *   $	 Black��6;   $
 20Q�6I   $ 0Q�6Y   5�  #   5�     5�     .��5�     �� -   5        $/ TextBlockExit��5�     $(��"ВЫЙТИ ИЗ ПРОГРАММЫ��63   $
+ Hand��6M   5�     5�     �� 5�  
   ���	#FF323232$��3,3,3,3q�6)   $��1��6C   $��1��6S    5�       5�     $	 Black��6#   $
 1Q�61   $ 4Q�6@   $	 0.9Q�6P   5�     �� 5�  
   ���	#FF323232$��3,3,3,3q�6)   $��1��6C   $��1��6S   $��10,10,10,10q�6`   ���	#FF646464 5�       5�     $	 Black��6#   $
 1Q�61   $ 4Q�6@   $	 0.9Q�6P   ._�5�     �� -   5        $/ TextBlockAvatar��5�     $�� ��61   $��Arial)�6:   $��14(�6M   $
��Wrap=�6[   
��� � �$��5,5,5,5q�6�   5�     �� 5�  
   ���	#FF323232$��3,3,3,3q�6)   $��2��6C   $��1��6S    5�       5�     $	 Black��6#   $
 1Q�61   $ 4Q�6@   $	 0.9Q�6P   5�     �� 5�  
   ���	#FF323232$��3q�6)   $��2��6=   $��1��6M   $��10q�6Z    5�       5�     $	 Black��6#   $
 1Q�61   $ 4Q�6@   $	 0.9Q�6P   ._�5�     � .+�5�     �� -   5        $* ButtonImageAvatar��5�     $
+ Hand��6K   $��11��6Y   ��64   Z� ��5�     �� 5�     0 �� ImageSource$ 0 /Resources/AvatarLecha.png��6%   5�     5�     5�     � 5�  
   $��1��6   $��2��6   $��2��63   $��0,3,0,0q�6@    5�     �� 5�     $��0.75* �6#   �� 5�     $��0.25* �6#   .+�5�     �� -   5        $ TextBoxForAvatar��5�     $��Center=�60   $��Arial)�6R   ��. $��18(�6�   ���	#FF323232
��� � �$��	10,3,10,3q�6�   $��12��6�   $��0,5,0,5q�6�   .��6�   ��5�     �� 5�     " ��6&   .R�5�     �� #��z��6!   #��z��6K   #��z��6w   $ 10,10,10,10��6�   ._�5�     �� $  PART_ContentHost��6+   5�     5�     .��5�  $   ! 5�     �� 5�     $ 0.5,1&�6*   $ 0.5,0&�6;   .��5�     � $ Yellow��6'   $	 0.3Q�66   � 5�     $
 Lime��6'   $	 0.7Q�64   � 5�     $
 Lime��6'   $	 0.3Q�64   � 5�     $ Yellow��6'   $	 0.7Q�66   5�     .��5�  &   " 5�     �� 5�     $# Yellow��6&   $	$ 0.8Q�65   .��5�  *   % 5�     �� 5�     $# 	#FF14FF00��6&   $	$ 0.5Q�68   .��5�  .   ��5�     �� 5�     $ 0.5,1&�6*   $ 0.5,0&�6;    5�     V� 5�     .~�5�  "   �� $	 0.5Q�61   $	 0.5Q�6?   �� 5�  "   $	 0.5Q�60   $	 0.5Q�6>   �� 5�  "   $	 -90Q�62   $	 0.5Q�6>   $	 0.5Q�6L   T� 5�  "   5�     .��5�     � $ 	#FFAFAFAF��6'   $	 0.9Q�69   � 5�     $
 Lime��6'   $	 0.9Q�64   � 5�     $
 Lime��6'   $	 0.1Q�64   � 5�     $ 	#FFAFAFAF��6'   $	 0.1Q�69   � 5�     $ 	#FFAFAFAF��6'   $
 0.35Q�69   � 5�     $ Yellow��6'   $
 0.35Q�66   � 5�     $ Yellow��6'   $
 0.65Q�66   � 5�     $ 	#FFAFAFAF��6'   $
 0.65Q�69   5�     .��5�  '   5�     �� 5�     -   5        $* ButtonSearch��5�     $��СКАЗАТЬ��6+   $��1��6=   $��Arial)�6M   ���	#00000000
��� ���$��0,0,0,0q�6�   $
+ Hand��6�   $
��Bold"�6�   $��16(�6�   ��6�   Z� ��5�     �� 5      " ��6&   .R�5     �� #��z��6!   $
��20,5q�6K   ��5     �� 5  "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5  &   � $ Yellow��63   $
 0.25Q�6B   � 5  &   $ 	#00AFAFAF��63   $
 0.25Q�6E   � 5  &   $ 	#00AFAFAF��63   $
 0.75Q�6E   � 5  &   $ Yellow��63   $
 0.75Q�6B   5  #   ._�5
     �� $��Center=�6/   $��Center=�6L   5     5     ��5     �� 5     " ��6   .�5     ��  �@J�Effect 5       5  "   $	 Yellow��63   $
 10Q�6B   $ 0Q�6R   5     , 5     P� 5     - �@J�IsMouseOver. . . �5  "   ��  � �� �	#FF9696006?   �� 5  "    �@J�Effect 5  &     5  *   $	 	#FF969600��6;   $
 15Q�6M   $ 0Q�6]   5  #   5     P� 5     - � ��. . . �5  "   ��  � ��
 �   �6?   �� 5   "    �@J�Effect 5!  &     5"  *   $	 Black��6;   $
 20Q�6I   $ 0Q�6Y   5$  #   5%     5'     5)     5*     � 5+  
   $��2��6    5,     �� 5-     $
��0.5* �6    �� 5.     $
��0.5* �6     50     �� 51     $
��0.2* �6#   �� 52     $
��0.2* �6#   �� 53     $
��0.2* �6#   �� 54     $
��0.2* �6#   .+�56     �� -   5        $* ButtonOnOff��56     $��3��6*   ���	#FF646464$
+ Hand��6R   $��10��6`   ��57     �� 58     $0 /Resources/dark_mode.png��6!   1 j� Stretch$1 Uniform=�6H   ��5:     �� 5;     " ��6   .�5<     ��  �@J�Effect 5=       5>  "   $
	 Lime��63   $
 5Q�6@   $ 0Q�6O   5@     5A     5C     5D     5E     5F     