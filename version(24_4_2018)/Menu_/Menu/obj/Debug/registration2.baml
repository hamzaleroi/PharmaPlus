   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MenuMenu  5   	       Menu.registration2   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Menu     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ registration2��5   	   $
��535 ��6   $	��930��6-    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6   ���	#FF151922.+�5      �� $��	Bienvenue��6   $	��Top=�6(   $��
40,117,0,0q�6@   
�������$��Sitka Display)�6}   $��48(�6�   $
��Left=�6�   $	��306��6�   $��61��6�   ��6T   Z� 6�   �� 5      $
��Left=�6   $��67��63   $��
40,235,0,0q�6?   $	��Top=�6S   $	��233��6k   
�������$��Sitka Display)�6�   $��20(�6�   $
��Wrap=�6�   ��6w   Z� 0.Si vous avez déja un compte à votre compte !5      �� 5      -   5         ��Name$ connect1��5        MaterialDesignFlatButton#��[ 5      ���	#FF2980B9$��	Connectez��5   1   $��273,235,95,239q�6E   $��Roboto)�6]   $��16(�6q   $��5q�6    J� Opacity$	 0.8Q�6�   ��6   Z� 6�   5       � 5!   
   $��1��6   ���	#FF2980B9.+�5"      �� $	��350��6   $��40,60q�6&   .+�5#      � $	��350��6    � RowDefinitions 5$      �� 5%      $��* �6(   �� 5&      $��* �6(   �� 5'      $��* �6(   �� 5(      $��* �6(   .+�5*      � $��0��6   .+�5+      G� -   5        	 G�Name$	 Q1��5+   &   $	��240��62   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$(
 "Numero De Votre Carte D'identité ��5,       ) %MaterialDesignFloatingHintPasswordBox#��[ 5-      $��Sitka Display)�6B   $��18(�6]   
�������$��0,0,0,2q�6~   $��	0,10,15,0q�6�   ���	#FF1519226�   '  !MaterialDesignThemes.Wpf.PackIcon  5.      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$	 key=�62   $��25��6>   $��10,59,344,0q�6J   $��Stretch=�6_   $��Stretch=�6{   $��25��6�   ���	#FF1519226�   50      � 51      $��1��6   .+�53        $	 Key=�62   $��25��6?   $��25��6K   $��	10,49,0,0q�6V   $��2��6i   ���	#FF1519226v   G� 54      -   5        $	 Q2��55      $��	0,10,10,9q�54   &   $	��240��69   $ 
 Numero De Votre Compte CCP��56      #��[ 57      $��0,0,0,2q�6\   ���	#FF151922
�������$��Sitka Display)�6�   $��18(�6�   59      � 5:      $��2��6   .+�5<      G� -   5        $	 Q3��5=      $��
0,10,15,10q�5<   &   $	��240��6:   $#
 La Clé de Votre  Compte CCP ��5>      #��[ 5?      $��0,0,0,2q�6B   ���	#FF151922
�������$��Sitka Display)�6�   $��18(�6�     5@      $	 key=�62   $��25��6?   $��25��6K   $��	10,49,0,0q�6V   ���	#FF1519226i   5A      � 5C      $��3��6   .+�5D      ��  �� Orientation$ 
Horizontal=�6%   $��Right=�6>   .+�5F      �� -   5        $ Reset��5F   %   #��[ 5G      $��
0,28,10,27q�5H      ���	#FFEEEEF2���	#FF2980B9$��Réinitialiser��6F   $	��105��6^   $��Roboto)�6j   $��14(�6~   $
��10,4q�6�   6�   �� 5J      -   5        $ Check��5J   %   #��[ 5K      $��0,28,100,27q�5L      ���	#FFEEEEF2���	#FF2980B9$��Valider��6H   $	��105��6Z   $
��10,4q�6f   6u   5M      5N      5P      5Q      5S      5U      5V      