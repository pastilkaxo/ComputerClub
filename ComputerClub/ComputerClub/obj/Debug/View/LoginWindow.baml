   M S B A M L   `   `   `  ����G  CComputerClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ComputerClub.WindComputerClub.Wind  5   	   9!clr-namespace:ComputerClub.HelperComputerClub.Helper  5   	   #    ComputerClub.Wind.LoginWindow   5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5	   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5
   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ComputerClub.Wind     5   	   :localHelpers!clr-namespace:ComputerClub.Helper     5   	      MaterialDesignBody#���   5   	   $��Medium"�5   	   $��14(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	     � Title$  Login��5   	   $	��700��6   $	��500��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F    � WindowStyle$
 None=�6k    � AllowsTransparency .  � Icon$0 */ComputerClub;component/Resources/icon.png��6�   ��6�   Z� .��5      � ��5   
   �� 5      .��5      �  � Color$ #f6f6f6��6    � Offset$	 0.0Q�6/   � 5      $
 #fff��6   $ 1Q�6,   5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5!   
   �� -   5        $��0��5!      
������ ._�5"      � .+�5#      (  "MaterialDesignThemes.Wpf.ColorZone  	   Mode$	 PrimaryDark=�6+   ���	#FF7F0000.��5$      �� $��Right=�6!   .+�5%      �� $��30��6!   $��30��6-   
�������+  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth4=�6K   $��0q�6|   ���	#FFFB435C���	#FF2D7BA8��6�   �� *CloseCommand+.��5&      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowClose=�66   6K   5'      5(      5)      5*      5+      � 5.   
   $��1��6   .+�5/      ��  �� Orientation$ 
Horizontal=�6   ���	#FF28688D$��Center=�6I   .+�50      �� $ 
Horizontal=�6   
���   �$
 Depth4=�6J   $��99��6{   $	��499��6�   .+�51      �� $��	iBUYPOWER��6    $��35(�61   $��10q�6?   ���	#DDFFFFFF �� TextAlignment$ Center=�6b   $��Center=�6y   $	��486��6�   $��Arial Black)�6�   52      53      54      � 57   
   $��2��6   .+�58      �� $ Vertical=�6   .+�5:      �� $ 
Horizontal=�6   $��	0,120,0,0q�66   .+�5;        $ Account=�6.   $��Bottom=�6{   $��	40,0,10,0q�6�   $��50��6�   $��50��6�   ��6=   ��  �� ElementName$ txt_user�� �� Path$ BorderBrush�6�   �� 5<      -   5         ��Name$ txt_user��5<      $��50��6q   $	��350��6~   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Пользователь��6�      
IsFloating . $��20(�6�    �� 	MaxLength$ 50��6�   ��61   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5=      �� 5?      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5@        $
 Lock=�6.   $��Bottom=�6|   $��	40,0,10,0q�6�   $��50��6�   $��50��6�   ��6:   �� $ txt_password��$ BorderBrush�6�   G� 5A      -   5         G�Name$ txt_password��5A   "   $��50��6h   $	��350��6u   $ Пароль��6�    . $��20(�6�    G� 	MaxLength$ 15��6�   5B      �� 5D       $  MaterialDesignRaisedAccentButton#���  6:   $��
ВОЙТИ��6u   ���	#FFD3113D���	#DDFFFFFF$��	0,80,0,30q�6�   $	��200��6�   $��50��6�   $��	0 15 0 15q�6�   $��Center=�6  $��20(�6(  ��6   �� *LoginCommand+��6�   Z� 6(  �� 5G      $��Center=�6   $��0,15,0,0q�6:   .+�5H      �� �� 6!   
������� % !MaterialDesignSubheadingHyperlink#��[ 6>   $��22(�6y    �� Command 6�   �� *RegisterCommand+.�6�   31Еще не зарегестрировались?6�   6�   �� 5I      $��0,15,0,0q�6    $ Center=�62   �� 6J   
�������#��[ 6g   $��22(�6�   )  #MaterialDesignThemes.Wpf.DialogHost   OpenDialogCommand# Z 6�    �� CommandTarget 6�   �� $ 	hechoPass��.�6!  Забыли пароль?61  6=  5J      5K        5L      -   5          Name$ 	hechoPass��5L   7      IsOpen .  
�������$��0,10,0,0q�6]      DialogContent 5M      �� 5N      $ Vertical=�6!   $��15q�68   .+�5O      �� $%��Изменение пароля��6$   $��5,5,5,0q�6<   $��20(�6M   $��Center=�6[   
���   �6x   �� 5P      -   5        $ 
txt_nameUr��5P   "   $ 
Логин��6Q    . $��20(�6�   $	��225��6�   $
��Left=�6�   $��0,10,0,0q�6�   ��66   �� *	UsernameP+6�   �� 5Q      $ 
Horizontal=�6%   .+�5R      �� $%��Запросить замену��5S      $��18(�63   $
��0,20q�6A   
���������5R   %   �� *ForgotPasswordCommand+��6O   �� $ 	hechoPass��5S   O   �� 5T         CloseDialogCommand#��Z 6%   $��Отмена��5U      $��18(�6)   $��10,20q�67   
���������5T   g   �� $ 	hechoPass��5U   F   5V      5W      5Y      5Z      5]      5^      