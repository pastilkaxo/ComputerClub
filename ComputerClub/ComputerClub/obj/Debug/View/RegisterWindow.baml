   M S B A M L   `   `   `  ����G  CComputerClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ComputerClub.ViewModelComputerClub.ViewModel  5   	   5clr-namespace:ComputerClub.WindComputerClub.Wind  5   	   9!clr-namespace:ComputerClub.HelperComputerClub.Helper  5   	   &     ComputerClub.Wind.RegisterWindow   5   	   2	viewmodel$clr-namespace:ComputerClub.ViewModel  5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ComputerClub.Wind     5   	   :localHelpers!clr-namespace:ComputerClub.Helper     5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��14(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	     � Title$  Register��5   	   $	��700��6   $	��500��6'    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I    � WindowStyle$
 None=�6n    � AllowsTransparency .  � Icon$0 */ComputerClub;component/Resources/icon.png��6�   .��5      � ��5   
   �� 5      .��5      �  � Color$ #f6f6f6��6    � Offset$	 0.0Q�6/   � 5      $
 #fff��6   $ 1Q�6,   5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��100 �6   �� 5       $��* �6   .+�5#   
   �� -   5        $��0��5#      
������ ._�5$      � .+�5%      (  "MaterialDesignThemes.Wpf.ColorZone  	   Mode$	 PrimaryDark=�6+   ���	#FF7F0000.��5&      �� $��Right=�6!   .+�5'      �� -   5        $��30��5'   !   $��30��6-   
�������+  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth4=�6K   $��0q�6|   ���	#FFFB435C���	#FF2D7BA8.��5(      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowClose=�66   6K   5)      5*      5+      5,      5-      � 50   
   $��1��6   .+�51      ��  �� Orientation$ 
Horizontal=�6   ���	#FF28688D$��Center=�6I   .+�52      �� $ 
Horizontal=�6   
���   �$
 Depth4=�6J   $��99��6{   $	��499��6�   .+�53      �� $��	iBUYPOWER��6    $��35(�61   $��10q�6?   ���	#DDFFFFFF �� TextAlignment$ Center=�6b   $��Center=�6y   $	��281��6�   $��Arial Black)�6�   �� 54      $	��100��6   $	��100��6)    J� OpacityMask 55      �� 56      58      59      5:      5;      � 5>   
   $��2��6   .+�5?      #  MaterialDesignThemes.Wpf.Card  $��12,12,12,12q�6"   $��15q�67   $	��545��6D   $
 Depth5=�6Q   .��5@      �� $ Vertical=�6   .+�5B      �� $ 
Horizontal=�6!   .+�5C      �� -   5         ��Name$ txt_name��5C   "   $��50��6J   $	��200��6V   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя��6b      
IsFloating . $��20(�6�   $��5,0,10,0q�6�    �� 	MaxLength$ 30��6�   ��64   �� *Name+6�   �� 5D      -   5        $ txt_lastname��5D   "   $��50��6R   $	��200��6^   $ Фамилия��6j    . $��20(�6�   $��0,0,5,0q�6�   $ 30��6�   ��68   �� *
LastName+6�   5E      �� 5G      $ 
Horizontal=�6!   .+�5H      �� -   5        $ txt_patronymic��5H   "   $��50��6V   $	��200��6b   $ Отчество��6n    . $��20(�6�   $��5,0,10,0q�6�   $ 34��6�   ��6:   �� *
Patronymic+6�   5I      �� 5K      $ 
Horizontal=�6!   .+�5L      (  "System.Windows.Controls.DatePicker  -   5          Name$ 	txt_birth��5L   %   $��50��6[   $	��200��6g   $��20(�6s   $��Bottom=�6�   $ Дата рождения��6�    . $��5,0,10,0q�6�      SelectedDate 68   �� *	BirthDate+6  5M      �� 5O      $ 
Horizontal=�6!   .+�5P      �� -   5        $ 
txt_mobile��5P   "   $��50��6N   $	��200��6Z   $ Телефон��6f    . $��20(�6�   $��5,0,10,0q�6�   $ 30��6�   ��66   �� *Mobile+6�   5Q      �� 5S      $ 
Horizontal=�6!   .+�5T      �� -   5        $ 	txt_email��5T   "   $��50��6L   $	��200��6X   $ 
Почта��6d    . $��20(�6�   $��5,0,10,0q�6�   $ 30��6�   ��65   �� *Email+6�   5U      �� 5W      $ 
Horizontal=�6!   .+�5X      �� -	   5        $ 	txt_login��5X   "   $��50��6L   $	��200��6X   $ 
Логин��6d    . $��20(�6�   $��5,0,10,0q�6�   $ 30��6�   ��65   �� *Login+6�   5Y      �� 5[      $ 
Horizontal=�6!   .+�5\      G� -
   5         G�Name$ txt_pass��5\   &   $��50��6c   $	��200��6o   $ Пароль��6{    . $��20(�6�   $��5,0,10,0q�6�    G� 	MaxLength$ 15��6�   6   5]      �� 5_      )  #MaterialDesignThemes.Wpf.DialogHost   OpenDialogCommand#��Z 6    $  MaterialDesignRaisedAccentButton#���  5`      $��Регистрация��6T   ���	#FFD3113D���	#DDFFFFFF$	��200��6�   $��50��6�   $��	0 15 0 15q�6�   $��Center=�6�   $��0,50,0,0q�6�   $��20(�6
  ��5_   ^   ��  �� ElementName$ hecho2����5`   �   Z� 6
  �� 5b      $ 
Horizontal=�6!   $��Center=�6:   $��0,15,0,0q�6W   .+�5c      �� �� 6%   
������� % !MaterialDesignSubheadingHyperlink#��[ 6A   $��18(�6|    �� Command 6�   �� *GoToLoginCommand+.�6�   !Уже есть аккаунт?6�   6�   5d      5e      5f      5g        5j   
   -   5          Name$ hecho2��5j   3      IsOpen .  $��3��6C      DialogContent 5k      �� 5l      $ Vertical=�6   $��15q�64   .+�5m      �� $��Вы уверены?��6    $��5q�63   $��18(�6>   $��Center=�6L   �� 5n      $ 
Horizontal=�6!   .+�5o      ��  # MaterialDesignRaisedLightButton#���  5p      $
��ДА��6S   $��18(�6`   $��5q�6n   
���������5o   "   �� *RegisterCommand+5p   y   �� 5q         CloseDialogCommand#��Z 6!   #���  5r      $��НЕТ��6S   $��18(�6a   $��5q�6o   
���������5q   c   �� $ hecho2��5r   z   5s      5t      5v      5x      5y      