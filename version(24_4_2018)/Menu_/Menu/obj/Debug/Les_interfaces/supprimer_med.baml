   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MenuMenu  5          Menu.supprimer_med   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Menu     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
        N� Title$  supprimer_med��5	         MaterialDesignBody#���   5   	   $��Regular"�5   	   $��18(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	   .��5      � .+�5   
   � ��5      �� 5       �� ImageSource$ /images\w.jpg��6    j� Stretch$
 Fill=�69    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 15Q�6   5      5      � 5   
   	 � RowDefinitions	 5       �� 5!      $
��106* �6    �� 5"      $
��347* �6    .+�5$      #  MaterialDesignThemes.Wpf.Card  $��10q�6"   $��
10,10,11,0q�6/   
�������$��0��6V   $	��100��6c   .��5&      �� $��Center=�6   $��Sitka Display)�69   ���	#FF2980B9�� 5'       # MaterialDesignDisplay2Hyperlink#��[ 5(      ���	#FF2980B9.�6U   Supprimer Un Medicament5*      5+      5,      � 55      $��1��6   $��10q�6    	 56      �� 57      $	��62* �6$   �� 58      $	��62* �6$   �� 59      $	��62* �6$   �� 5:      $	��62* �6$   �� 5;      $	��50* �6$   .+�5=      � $��1��6   
 � ColumnDefinitions
 5>      �� 5?      �� 5@      �� 5A      .+�5C      �� -   5        $	��DCI��5C      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ DCI * ��5D       % !MaterialDesignFloatingHintTextBox#��[ 5E      $��-5,10,29,10q�6>   ���	#FF2980B9���	#FF2980B9$��18(�6�    �� 
CaretBrush �	#FF151922$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   �� 5F      -   5        $��Nom_com��5F      $ Nom Commercial * ��5G      #��[ 5H      $��10,10,21,10q�6P   ���	#FF2980B9���	#FF2980B9 �	#FF151922$��18(�6�   $
��Bold"�6�   $��1��6�   $��Sitka Display)�6�    �� SelectionBrush �	#FF2980B96  �� 5I      -   5        $��Dosage��5I      $ 	Dosage * ��5J      #��[ 5K      $��10,10,22,10q�6P   ���	#FF2980B9���	#FF2980B9 �	#FF151922$��18(�6�   $
��Bold"�6�   $��2��6�   $��Sitka Display)�6�   5N      � 5O      $��2��6   
 5P      �� 5Q      $
��263* �6+   �� 5R      $
��257* �6+   �� 5S      $
��260* �6+   .+�5U      �� -   5         ��Name$ restit��5X   ?   $��0��5U       $ Type * ��5V      ���	#FF2980B9���	#FF2980B9$��Sitka Display)�6]   $��18(�6x   $��72��5W       & "MaterialDesignFloatingHintComboBox#��[ 5X      $��-2,32,0,-16q�6O   $	��Top=�6d   $
��Left=�6|   $	��262��6�   $��52��6�   ��5W      �� *#!LongListToTestComboVirtualization+.@�5Y      �� -   5         ��Name$
 rest��5Y   '   $��	Restitué��65   �� 5Z      -   5        $ non_rest��5Z   '   $��Non Restitué��69   �� 5[      -   5        $
 deux��5[   '   $��les deux��65   ��5\      �� 5]      .R�5^   "   $� 5_      5a      �� 5c      -   5        $ Forme��5c      $��Sitka Display)�60   $��18(�6K   $ Forme * ��5d      #��[ 5e      $��
10,16,21,0q�6?   $��1��6S   ���	#FF2980B9���	#FF2980B9$��52��6�   5f      (  "System.Windows.Controls.DatePicker  5g      -	   5        $��date_peromp��5g   !   $ Date De Peremption ��5h       ( $MaterialDesignFloatingHintDatePicker#��[ 5i      $��14,18,21,14q�6S   ���	#FF2980B9���	#FF2980B9$��Sitka Display)�6�   $��18(�6�   $
��Bold"�6�   $��2��6�   5j      � 5k      $��3��6   
 5l      �� 5m      $
��277* �6+   �� 5n      $
��243* �6+   �� 5o      $
��260* �6+   .+�5r      �� -
   5        $	��lot��5r   "   $	��267��6-   $��0��69   $
 Lot ��5s      #��[ 5t      $��	-6,15,0,0q�6P   ���	#FF2980B9���	#FF2980B9$��18(�6�    �	#FF151922$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   $
��Left=�6�   $��52��6   �� TextWrapping$
 Wrap=�6  $	��Top=�6)  5v      � 5y      $��4��6   $��69��6$   $	��Top=�60   
 5z      �� 5{      �� 5|      �� 5}      .+�5�      �� -   5         & "MaterialDesignFloatingActionButton#��[ 5�       � ToolTip$ 	Supprimer��5�      $��1��6   $��
150,3,54,0q�6'   ���	#FF2980B9$	��Top=�6~   ��6R   Z� .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Check=�62   $��40��6?   $��40��6K   5�      �� 5�      -   5        #��[ 5�      $ Réinitialiser��5�      $��1��6-   $��
62,3,142,0q�6=   ���	#FF2980B9$	��Top=�6   ��6h   Z� .��5�        $ Reload=�62   $��40��6@   $��40��5�      5�      5�      5�      5�      5�      5�      