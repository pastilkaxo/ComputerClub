   M S B A M L   `   `   `  ����G  CComputerClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ComputerClub.WindComputerClub.Wind  5   	   #    ComputerClub.Wind.ModerWindow   5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ComputerClub.Wind     5   	      MaterialDesignBody#���   5      $��Medium"�5   	   $��14(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	     � Title$  Moder��5   	   $	��700��6   $
��1000��6$    � 
ResizeMode$ NoResize=�61    � WindowStartupLocation$ CenterScreen=�6G    � WindowStyle$
 None=�6l    � AllowsTransparency .  � Icon$0 */ComputerClub;component/Resources/icon.png��6�   
���   ���5      �� 5   
    �� ImageSource$' !/Resources/заднийфон.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   � -   5        $��2��5      ���	#FFF52B2B � Cursor$  ��6q   .+�5      �� 	 �� Orientation$	 
Horizontal=�6   $��Right=�62   .+�5      '  !MaterialDesignThemes.Wpf.PopupBox  
   PlacementMode$
 BottomAndAlignLeftEdges=�6*      	StaysOpen .  
�������   PopupContent. 5      �� .+�5      �� $��Помощь��6!   ��63   �� *	HelpBtn+�� 5       $��	О нас��6!   ��62   �� *
AboutBtn+5!      5"      �� 5$      $��30��6   $��30��6%   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�60   $��0q�6a   $��0,0,3,0q�6m   ���	#FFD0A429���	#FFF50F04
���������6~   �� *
AdminClose+.��5%      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowClose=�6.   6C   5&      5'      5(      � 5+   
   $��1��6   $��2��6    � ColumnDefinitions 5.      �� 5/      $	��300 �6#   �� 50      $��* �6#   .+�54      � $��0��6   
������� J� Effect 57      3  -System.Windows.Media.Effects.DropShadowEffect  58         
BlurRadius$ 20Q�6'      RenderingBias$ Quality=�67      ShadowDepth$ 1Q�6O   .+�5;      �� $	 Vertical=�6   $��Center=�64   .+�5B      �� $	 
Horizontal=�6!   $��
30,80,30,0q�6:   .+�5C      �� -   5         ��Name$ txt_insertID��5C   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6V      
IsFloating . $��20(�6�   $	��200��6�    �� 	MaxLength$ 30��6�   ��68   �� *txt_insertID+6�   5D      �� 5F      $	 
Horizontal=�6!   $��
30,10,30,0q�6;   .+�5G      �� -   5        $ txt_insertPassword��5G   "   $ Пароль��6b    . $��20(�6�   $	��200��6�   $ 15��6�   ��6>   �� *txt_insertPassword+6�   5H      �� 5N      $	 
Horizontal=�6!   $��
30,10,30,0q�6;   .+�5O      �� -   5        $ txt_insertRole��5O   "   $ Роль��6Z    . $��20(�6�   $	��200��6�   $ 15��6�   ��6:   �� *txt_insertRole+6�   5P      �� 5S      $��30,100,30,0q�6"   $
��Left=�67   .+�5T      �� $��60��6!   $	��200��60   
����������	#FFB2B2B2��6<   �� *InsertCommand+��6�   Z� .��5U      �� $	 
Horizontal=�6)   .+�5V   "   �� $��Light"�6,   $
��Auto��6?   $��24(�6L   $��Подтвердить��6Z   $��Center=�6m   $��Center=�6�   5W      5X      5Y      �� 5c      $��
30,30,30,0q�6"   $
��Left=�66   .+�5d      �� $��60��6!   $	��200��60   
����������	#FFB2B2B2��6<   �� *DeleteCommand+��6�   Z� .��5e      �� $	 
Horizontal=�6)   .+�5f   "   �� $��Light"�6,   $
��Auto��6?   $��24(�6L   $��Удалить��6Z   $��Center=�6i   $��Center=�6�   5g      5h      5i      �� 5k      $��
30,30,30,0q�6"   $
��Left=�66   .+�5l      �� $��60��6!   $	��200��60   
����������	#FFB2B2B2��6<   �� *UpdateCommand+��6�   Z� .��5m      �� $	 
Horizontal=�6)   .+�5n   "   �� $��Light"�6,   $
��Auto��6?   $��24(�6L   $��Изменить��6Z   $��Center=�6j   $��Center=�6�   5o      5p      5q      5s      5t      � 5v      $��1��6   $��2��6#    5y      �� 5z      $	��400 �6$   �� 5{      $��* �6$   .+�5~      �� $	��420��6   $��0��6*   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridViewUsers��5   O   
�������$��20q�66   $	��380��6B   6O   5�      �� 5�      $	��264��6   $��1��6*   .+�5�      �� $	 
Horizontal=�6!   $��50, 20, 50,0q�6:   .+�5�      �� $��60��6!   $��60��6-   $ Depth3=�68   $��0q�6i   $��
20,10,10,0q�6u   ���	#FFB2B2B2��6�   �� *SearchCommand+��6�   Z� .��5�        $ Magnify=�66   $��40��6E   
�������$��50��6d   6q   5�      �� 5�      -   5        $ txt_SearchID��5�   "   $" Поиск по логину��6V    . $��20(�6�   $	��200��6�   $
��Left=�6�   $��	0,20,0,20q�6�   
�������$ 15��6  ��68   �� *txt_SearchID+6  �� 5�      $��40��6!   $	��140��60   
����������	#FFB2B2B2$��120,10,0,10q�6}   ��6f   Z� ��6�   �� *RefreshCommand+.��5�      �� $	 
Horizontal=�6)   .+�5�   "   �� $��Light"�6,   $
��Auto��6?   $��22(�6L   $��Обновить��6Z   $��Center=�6j   $��Center=�6�   5�      5�      5�      5�      5�      5�      5�      5�      