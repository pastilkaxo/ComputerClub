   M S B A M L   `   `   `  ����G  CComputerClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ComputerClub.WindComputerClub.Wind  5   	   #    ComputerClub.Wind.ServicePage   5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5	   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5
   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ComputerClub.Wind     5   	      MaterialDesignBody#���   5        MaterialDesignPaper  N� 
Background#  �  5   	   $��Medium"�5   	   $��14(�5   	    N� 
FontFamily$X Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	    N� Title$ Login��5   	   $	��693��6   $
��1192��6$   .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��	0,0,373,0q�6,   .+�5      �� $ Vertical=�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridViewUsers1��5   b   
�������$��
20,20,20,0q�62   $	��465��6F   $	��720��6S   $	��Top=�6~   6�   �� 5      $��40��6   $	��140��6(   
����������	#FFB2B2B2$��
540,10,0,0q�6u   ��6^   Z� ��6�   �� *RefreshCommand+.��5      �� $ 
Horizontal=�6!   .+�5      �� $��Light"�6$   $
��Auto��67   $��22(�6D   $��Обновить��6R   $��Center=�6b   $��Center=�6}   5      5      �� 5      $��40��6   $	��140��6(   
����������	#FFB2B2B2$��
540,10,0,0q�6u   ��6^   Z� ��6�   �� *DeleteLastCommand+.��5      �� $ 
Horizontal=�6!   .+�5      �� $
��Bold"�6$   $
��Auto��66   $��22(�6C   $��Удалить��6Q   $��Center=�6`   $��Center=�6{   
���  ��6�   5      5      5       �� 5"      $ 
Horizontal=�6   $��20, 0, 20, 0q�62   .+�5$      �� $��60��6   $��60��6%   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�60   $��0q�6a   $��
70,10,10,0q�6m   ���	#FFB2B2B2��6�   Z� ��6�   �� *SearchProcedureCommand+.��5%      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Magnify=�6.   $��40��6=   
�������$��50��6\   6i   5&      �� 5'      -   5         ��Name$ txt_SearchProcName��5'      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Поиск тарифа��6V   	   
IsFloating	 . $��20(�6�   $	��200��6�   $
��Left=�6�   $��	0,20,0,20q�6�   ��66   �� *SearchProcName+6�   �� 5)      $��60��6   $��60��6%   $ Depth3=�60   $��0q�6a   $��
60,10,10,0q�6m   ���	#FFB2B2B2��6�   Z� ��6�   �� *SearchPriceCommand+.��5*        
�������$ Magnify=�6B   $��40��6Q   $��50��6]   6j   5+      �� 5,      -   5        $ txt_SearchRole��5,      $ Поиск по цене��6O   	 . $��20(�6�   $	��200��6�   $
��Left=�6�   $��	0,40,0,20q�6�   ��62   �� *SearchPrice+6�   5-      5.      �� 5/   
   $��
824,0,10,0q�6   $	��700��6)   $��Bottom=�66   .+�50      �� -   5        $ ID��50      $
 ИД��51      	 . $��20(�6X   $	��200��6f   $��0,20,0,0q�6r   {�.  ��50   "   �� *SelectedProc.ID+
 �� UpdateSourceTrigger$
 PropertyChanged=�51   �   �� 52      -   5        $
 Name��52      $ Название��53      	 . $��20(�6^   $	��200��6l   $��0,20,0,0q�6x    �� 	MaxLength$ 15��6�   ��52   $   �� *SelectedProc.Name+$
 PropertyChanged=�53   �   �� 54      -   5        $ Price��54      $ Цена��55      	 . $��20(�6Z   $	��200��6h   $��0,20,0,0q�6t   $ 15��6�   ��54   %   �� *SelectedProc.Price+$
 PropertyChanged=�55   �   �� 56      -   5        $ 
Durability��56      $ Длительность��57      	 . $��20(�6b   $	��200��6p   $��0,20,0,0q�6|   $ 15��6�   ��56   *   �� *SelectedProc.Durability+$
 PropertyChanged=�57   �   �� 58      -   5        $ Description��58      $ Описание��59      	 . $��20(�6^   $	��200��6l   $��0,20,0,0q�6x   $ 15��6�   ��58   +   �� *SelectedProc.Description+$
 PropertyChanged=�59   �   �� 5:      $��Изменить��6   
��� � �
�������$��18(�6p   $	��200��6~   $��0,20,0,0q�6�   ��6(   �� *UpdateCommand+6�   5;      5<      5=      