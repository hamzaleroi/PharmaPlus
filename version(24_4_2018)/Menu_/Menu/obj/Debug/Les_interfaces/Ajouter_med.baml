   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:facturefacture  5          facture.Ajouter_med   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:facture     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	        N� Title$  Ajouter_med��5         MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��18(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	   .��5      � .+�5   
   � ��5      �� 5       �� ImageSource$ ..\images\w.jpg��6    j� Stretch$
 Fill=�6;    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 15Q�6   5      5      � 5   
   	 � RowDefinitions	 5      �� 5      $
��106* �6    �� 5       $
��347* �6    .+�5"      #  MaterialDesignThemes.Wpf.Card  $��10q�6"   $��10,10,10,10q�6/   $��0��6E   $	��100��6R   .��5$      �� $��Center=�6   $��Sitka Display)�69   �� 5%       # MaterialDesignDisplay2Hyperlink#��[ 5&      ���	#FF2980B9.�6U   Ajouter Un Medicament5(      5)      5*      � 51      $��1��6   $��	20,0,20,0q�6    	 53      �� 54      $��* �6$   �� 55      $��* �6$   �� 56      $��* �6$   �� 57      $��* �6$   �� 58      $��* �6$   .+�5:      � $��0��6   
 � ColumnDefinitions
 5;      �� 5<      �� 5=      �� 5>      .+�5@      �� -   5        $	��DCI��5@      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ DCI * ��5A       % !MaterialDesignFloatingHintTextBox#��[ 5B      $��10,10,21,10q�6>   ���	#FF2980B9���	#FF2980B9$��18(�6�    �� 
CaretBrush �	#FF2980B9$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   �� 5C      -   5        $��Nom_com��5C      $ Nom Commercial * ��5D      #��[ 5E      $��10,10,21,10q�6P   ���	#FF2980B9���	#FF2980B9 �	#FF151922$��18(�6�   $
��Bold"�6�   $��1��6�   $��Sitka Display)�6�    �� SelectionBrush �	#FF2980B96  �� 5F      -   5        $��Dosage��5F      $ Dosage  ��5G      #��[ 5H      $��10,10,21,10q�6P   ���	#FF2980B9���	#FF2980B9 �	#FF151922$��18(�6�   $
��Bold"�6�   $��2��6�   $��Sitka Display)�6�   5K      � 5L      $��1��6   
 5M      �� 5N      �� 5O      �� 5P      .+�5R      d� -   5        $��rembours��5R   #    $  MaterialDesignSwitchToggleButton#��[ 5S       d� 	IsChecked$
 TrueY�5U      $��
188,36,5,0q�6   ���	#FF2980B9$��1��6?   �� 5V      $��	0,36,81,0q�6   ���	#FF2980B9$��Sitka Display)�6F   $
��Bold"�6a   $��
Restitué ��6s   �� 5W      $
��Left=�6   $��	1,36,0,10q�67   $	��172��6J   ���	#FF2980B9$��Sitka Display)�6m   $
��Bold"�6�   $��Remboursable��6�   $��1��6�   d� 5X      -   5        $��restitue��5X   $   #��[ 5Y      $
 TrueY�5[      $��187,36,6,10q�6&   ���	#FF2980B9��6R   Z� d� 5\      -   5        $��oriente��5\   #   #��[ 5]      $
 TrueY�5_      $��182,36,10,5q�6&   ���	#FF2980B9$��2��6R   �� 5`      $
��Left=�6   $��5,36,0,0q�67   $	��172��6I   ���	#FF2980B9$��Sitka Display)�6l   $
��Bold"�6�   $��Orienté��6�   $��2��6�   5e      � 5f      $��2��6   
 5g      �� 5h      �� 5i      �� 5j      .+�5m      �� -   5         ��Name$ Forme��5m      $ Forme  ��5n       & "MaterialDesignFloatingHintComboBox#��[ 5o      $��1��6@   $��0,2,19,8q�6P   ���	#FF2980B9���	#FF2980B9$��52��6�   $��Sitka Display)�6�   $
��Bold"�6�   5p      �� 5q      -   5        $ Effet��5q      $ Effet Thérapeutique  ��5r      #��[ 5s      $��0,2,19,8q�6Q   ���	#FF2980B9���	#FF2980B9$��52��6�   $��Sitka Display)�6�   $
��Bold"�6�   �� 5t      -	   5        $��Quantite��5t      $ Quantité  ��5u      #��[ 5v      $��	0,0,31,21q�6P   ���	#FF2980B9���	#FF2980B9$��18(�6�    �	#FF2980B9$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   $��2��6�   5x      � 5y      $��3��6   
 5z      �� 5{      �� 5|      �� 5}      .+�5      (  "System.Windows.Controls.DatePicker  -
   5          Name$ 	date_prod��5   !   $ Date De Production * ��5�       ( $MaterialDesignFloatingHintDatePicker#��[ 5�      $��
5,20,10,20q�6A   ���	#FF2980B9���	#FF2980B9$��Sitka Display)�6�   $��18(�6�   $
��Bold"�6�     5�      -   5        $��date_peromp��5�   !   $ Date De Peremption * ��5�      #��[ 5�      $��
5,20,10,20q�6S   ���	#FF2980B9���	#FF2980B9$��Sitka Display)�6�   $��18(�6�   $
��Bold"�6�   $��1��6�   �� 5�      -   5        $
��prix��5�      $ Prix  ��5�      #��[ 5�      $��10,20q�6P   ���	#FF2980B9���	#FF2980B9$��18(�6�    �	#FF2980B9$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   $��2��6�   5�      � 5�      $��4��6   $��69��6$   $	��Top=�60   
 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� -   5        $	��lot��5�   "   $
 Lot ��5�      #��[ 5�      $��0,5,10,0q�6P   ���	#FF2980B9���	#FF2980B9 �	#FF151922$��18(�6�   $
��Bold"�6�   $��0��6�   $��Sitka Display)�6�    �	#FF2980B9$�� ��6  $	��Top=�6  � 5�      $��5��6   �� 5�       �� Orientation$ 
Horizontal=�6!   $��1��6:   .+�5�      �� -   5        $��	75,0,15,0q�5�   !    & "MaterialDesignFloatingActionButton#��[ 5�       � ToolTip$ Réinitialiser��5�      ���	#FF2980B9$	��Top=�6\   ��6E   Z� .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Reload=�66   $��40��6D   $��40��5�      5�      �� 5�      -   5        #��[ 5�      $ Valider��5�      ���	#FF2980B9$	��Top=�6X   $��2��6p   ��6,   Z� .��5�        $
 Plus=�66   $��40��6B   $��40��5�      5�      5�      5�      5�      5�      5�      5�      