   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MenuMenu  5   	       Menu.Regetration1   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Menu     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ 
MainWindow��5   	   $
��535 ��6   $	��930��6*    � 
ResizeMode$ NoResize=�66    � WindowStyle$
 None=�6L    � WindowStartupLocation$ CenterScreen=�6_   ��5   	   Z� .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6   ���	#FF151922.+�5      �� $��	Bienvenue��6   $	��Top=�6(   $��
40,117,0,0q�6@   
�������$��Sitka Display)�6}   $��48(�6�   $
��Left=�6�   $	��306��6�   $��61��6�   ��6T   Z� 6�   �� 5      $
��Left=�6   $��67��63   $��
40,235,0,0q�6?   $	��Top=�6S   $	��233��6k   
�������$��Sitka Display)�6�   $��20(�6�   $
��Wrap=�6�   ��6w   Z� 0.Si vous avez déja un compte à votre compte !5      �� 5      -   5         ��Name$ connect1��5        MaterialDesignFlatButton#��[ 5      ���	#FF2980B9$��	Connectez��5   4   $��273,235,95,239q�6H   $��Roboto)�6`   $��16(�6t   $��5q�6�    J� Opacity$	 0.8Q�6�   ��6   Z� 6�   5       � 5!   
   $��1��6   ���	#FF2980B9.+�5"      �� $	��350��6   $��40,60q�6&   .+�5#      � $	��350��6   	 � RowDefinitions	 5$      �� 5%      $��* �6(   �� 5&      $��* �6(   �� 5'      $��* �6(   �� 5(      $��* �6(   .+�5*      � $��0��6   .+�5+      �� -   5        
 ��Name$	
 Nom��5+   "   $	��240��6/   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nom d'utilisateur��5,       % !MaterialDesignFloatingHintTextBox#��[ 5-      $��Sitka Display)�6>   $��18(�6Y   
�������$��0,0,0,2q�6z   $��	0,10,15,0q�6�   ���	#FF1519226�   '  !MaterialDesignThemes.Wpf.PackIcon  5.      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�62   $��29��6B   $��10,59,344,0q�6N   $��Stretch=�6c   $��Stretch=�6   $��29��6�   ���	#FF1519226�   50      � 6   $��1��6"   .+�52        $ 
AccountKey=�62   $��29��6F   $��29��6R   $��	10,49,0,0q�6]   $��2��6p   ���	#FF1519226}   G� 53      -   5         G�Name$ 
pass1_Copy��54      $��	0,10,10,9q�53   &   $	��240��69   $ Mot de Passe��55       ) %MaterialDesignFloatingHintPasswordBox#��[ 56      $��0,0,0,2q�6\   ���	#FF151922
�������$��Sitka Display)�6�   $��18(�6�   58      � 59      $��2��6   .+�5;      G� -   5        $ pass1��5<      $��
0,10,15,10q�5;   &   $	��240��6:   $ Confirmer le Mot de Passe��5=      #��[ 5>      $��0,0,0,2q�6B   ���	#FF151922
�������$��Sitka Display)�6�   $��18(�6�     5?      $ 
AccountKey=�62   $��29��6F   $��29��6R   $��	10,49,0,0q�6]   ���	#FF1519226p   5@      � 5B      $��3��6   .+�5C      ��  �� Orientation$ 
Horizontal=�6%   $��Right=�6>   .+�5E      �� -   5        $ Reset��5E   %   #��[ 5F      $��
0,28,10,27q�5G      ���	#FFEEEEF2���	#FF2980B9$��Réinitialiser��6G   $	��105��6_   $��Roboto)�6k   $��14(�6   $
��10,4q�6�   6�   �� 5I      -   5        $ Check��5I   %   #��[ 5J      $��0,28,100,27q�5K      ���	#FFEEEEF2���	#FF2980B9$��Valider��6J   $	��105��6\   $
��10,4q�6h   6w   5L      5M      5O      5P      5S      5T      5U      