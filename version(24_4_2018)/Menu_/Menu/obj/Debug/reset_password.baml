   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MenuMenu  5   	       Menu.reset_password   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Menu     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��18(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ reset_password��5       � WindowStyle$
 None=�6    � 
ResizeMode$ NoResize=�6/   $��455.336��6E   $	��300��6U    � WindowStartupLocation$ CenterScreen=�6b   .��5      � ���	#FFDFE6E9 � RowDefinitions 5   
   �� 5      $	��15* �6   �� 5      $	��41* �6   �� 5      $	��19* �6   .+�5   
   �� $��0��6   .+�5      �� $'��!Réinisialisez votre mot de passe��6   $��38��6?   $��
60,10,60,3q�6K   ���	#FF2980B9$��Sitka Display)�6v   $��24(�6�   $
��Bold"�6�    � Cursor$
 None��6�   5      �� 5   
   $��1��6   .+�5      � $	��148��6    5      �� 5      �� 5      �� 5      $��0* �6$   .+�5!      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   .+�5"      G� -   5        	 G�Name$	 pass1��5#      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Nouveau Mot De Passe ��5$       ) %MaterialDesignFloatingHintPasswordBox#��[ 5%      $��100,10q�6X   $	��245��6h   $��0,0,0,3q�6t   ���	#FF2980B9���	#FF2980B9$��Sitka Display)�6�   $
��Bold"�6�   $��16(�6�   5&      �� 5'      $��1��6   $ 
Horizontal=�6*   $��Center=�6C   .+�5(      G� -   5        $	 pass2��5)      $ 
 Confirmez Le Mot De Passe ��5*      #��[ 5+      $��100,10q�6B   $	��245��6R   $��0,0,0,3q�6^   ���	#FF2980B9���	#FF2980B9$��Sitka Display)�6�   $��16(�6�   $
��Bold"�6�   5,      5-      50      �� 51   
   $��2��6   $ 
Horizontal=�6"   .+�52      �� -   5         ��Name$ Valider2��52       & "MaterialDesignFloatingActionButton#��[ 53       � ToolTip$ Valider��54      ���	#FF2980B9$��390,10,0,10q�6C   ��6,   Z� .��55      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Check=�6*   $��33��68   $��30��56      57      �� 58      -   5        $ Reset��58      #��[ 59      $ Réinitialiser��5:      $��-120,2,200,0q�61   $��3��6G   ���	#FF2980B9��6k   Z� .��5;        $ 	LockReset=�6*   $��33��6<   $��30��5<      5=      5?      5@      5A      