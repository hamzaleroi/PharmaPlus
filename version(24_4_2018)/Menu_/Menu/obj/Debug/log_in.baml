   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MenuMenu  5   	       Menu.log_in   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Menu     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��18(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ log_in��5   	   $
��535 ��6   $	��930��6&    � WindowStartupLocation$ CenterScreen=�62    � WindowStyle$
 None=�6W    � 
ResizeMode$ NoResize=�6j   ��5   	   Z� .��5      � ��6   Z�  � ColumnDefinitions 5   
   �� 5      $	��21* �6   �� 5      $	��17* �6   .+�5   
   �� $��0��6   .+�5      � $
��Left=�6   $	��533��6.   $	��Top=�6;   $	��510��6S   ���	#FF1519225      5      �� 5   
   $��1��6   .+�5      � $
��Left=�6   $	��Top=�6/   ���	#FF2980B9$	��533��6^   $	��429��6k   $��	-17,0,0,0q�6w    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF00A875��6'   .+�5!      �� -   5        	 ��Name$	 fermer��5!   F   ���	#FF2980B9$��	360,0,0,0q�6k   $	��Top=�6~   $��40��6�   
 J� Opacity$

 0.75Q�6�   ��6   Z� .��5"      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6/   $��30��6<   $��30��6H   ���	#FF151922$	
 0.5Q�6j   5#        5$      $ Account=�6*   $��
23,220,0,0q�69     5%      $	 Key=�6*   $��
23,266,0,0q�65   �� 5&      -   5         ��Name$ T_email��5&      $
��Left=�6,   $��46��6G   $��
45,195,0,0q�6S   $	��Top=�6g   $	��240��6   $��Sitka Display)�6�   $��16(�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nom d'utilisateur��5'       % !MaterialDesignFloatingHintTextBox#��[ 5(      
����������	#FF151922 �� 
CaretBrush �	#FF2980B9 �� SelectionBrush �	#FF2980B9$��0,0,0,2q�6�   G� 5*      -   5         G�Name$ T_pass��5+      $��46��5*      $��45,245,114,0q�6*   $	��Top=�6A   $��Sitka Display)�6Y   $��16(�6t   $ Mot De Passe ��5,       ) %MaterialDesignFloatingHintPasswordBox#��[ 5-      $��0,0,0,2q�6B   
����������	#FF151922 G� 
CaretBrush �	#FF2980B96�   �� 5.      -   5        $		 log��5.        MaterialDesignFlatButton#��[ 6&   $��Se connectez��6Z   $
��Left=�6q   $	��Top=�6�   $	��118��6�   $��
45,325,0,0q�6�   $��27��6�   $��Sitka Display)�6�   $��16(�6�   ���	#FFEEEEF2���	#FF2980B9��6<  Z� �� 53      -   5        $	 oublie��53      #��[ 6)   $��Mot de passe oublié ?��6\   $
��Left=�6|   $��27��6�   $��168,325,0,0q�6�   $	��Top=�6�   $	��162��6�   ���	#FFEEEEF2$��Sitka Display)�6   $��16(�6;  $	
 0.7Q�6I  $	��0,4q�6l  ��6�   Z� ��6�   Z� 6l  �� 54      $"��Connectez à votre compte !!��6   $	��Top=�6>   $��
23,133,0,0q�6V   ���	#FF2980B9���	#FFEEEEF2$��Sitka Display)�6�   $��25(�6�   $
��Left=�6�   $	��306��6�   $��44��6�   56      57      �� 5:   
   $��	Bienvenue��6   $	��Top=�6$   $��
30,191,0,0q�6<   
�������$��Sitka Display)�6y   $��48(�6�   $
��Left=�6�   $	��306��6�   $��61��6�   ��6P   Z� 6�   �� 5;   
   -   5        $	 regester��5;      #��[ 6#   $��Créer��6V   $
��Left=�6f   $	��Top=�6�   $	��114��6�   $��
40,343,0,0q�6�   $��30��6�   $��Sitka Display)�6�   $��22(�6�   ���	#FF2980B9
���������6  Z� 6/  �� 5<   
   $��Créer un compte ici !��6   $	��Top=�60   $��
30,286,0,0q�6H   
�������$��Sitka Display)�6�   $��22(�6�   $
��Left=�6�   $	��262��6�   $��38��6�   ��6\   Z� 6�   �� 5=   
   $��
Pharm Plus��6   $	��Top=�6%   $��	30,77,0,0q�6=   ���	#FF2980B9$��Sitka Display)�6}   $��65(�6�   $
��Left=�6�   $	��306��6�   $��76��6�   ��6P   Z� 6�   5?      5@      