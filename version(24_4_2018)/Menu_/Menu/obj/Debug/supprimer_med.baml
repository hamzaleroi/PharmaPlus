   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MenuMenu  5          Menu.supprimer_med   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Menu     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
        N� Title$  supprimer_med��5	         MaterialDesignBody#���   5   	   $��Regular"�5   	   $��18(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	   $��481.5��6;   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��106* �6   �� 5      $
��347* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��10q�6   $��
10,10,11,0q�6+   ���	#FFDFE6E9$��0��6V   $	��100��6c   .��5      �� $��Center=�6   $��Sitka Display)�65   �� 5       # MaterialDesignDisplay2Hyperlink#��[ 5      ���	#FF2980B9.�6U   Supprimer un produit5      5       5!      � 5(   
   $��1��6    5)      �� 5*      $	��62* �6    �� 5+      $	��62* �6    �� 5,      $	��62* �6    �� 5-      $	��62* �6    �� 5.      $	��71* �6    �� 5/      $	��50* �6    .+�51      � $��0��6    � ColumnDefinitions 52      �� 53      �� 54      �� 55      .+�57      �� -   5        $	��DCI��57      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 DCI ��58       % !MaterialDesignFloatingHintTextBox#��[ 59      $��
5,10,19,10q�6>   ���	#FF2980B9���	#FF2980B9$��18(�6�    �� 
CaretBrush �	#FF151922$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   �� 5:      -   5        $��Nom_com��5:      $ Nom Commercial  ��5;      #��[ 5<      $��10,10,21,10q�6P   ���	#FF2980B9���	#FF2980B9 �	#FF151922$��18(�6�   $
��Bold"�6�   $��1��6�   $��Sitka Display)�6�   	 �� SelectionBrush	 �	#FF2980B96  �� 5=      -   5        $��Dosage��5=      $ Dosage  ��5>      #��[ 5?      $��10,10,22,10q�6P   ���	#FF2980B9���	#FF2980B9 �	#FF151922$��18(�6�   $
��Bold"�6�   $��2��6�   $��Sitka Display)�6�   5B      � 5C      $��1��6    5D      �� 5E      �� 5F      �� 5G      .+�5I      d� -   5        $��rembours��5I       $  MaterialDesignSwitchToggleButton#��[ 5J      
 � ToolTip$&
  MaterialDesignSwitchToggleButton��5K       d� 	IsChecked$
 TrueY�5L      $��
187,0,6,10q�6   ���	#FF2980B9$��1��6?   �� 5M      $
��Left=�6   $��51��63   $��0,11,0,0q�6?   $	��Top=�6Q   $	��172��6i   ���	#FF2980B9$��Sitka Display)�6�   $
��Bold"�6�   $��
Restitué ��6�   �� 5N      $
��Left=�6   $��51��63   $��	10,11,0,0q�6?   $	��Top=�6R   $	��172��6j   ���	#FF2980B9$��Sitka Display)�6�   $
��Bold"�6�   $��Remboursable��6�   $��1��6�   d� 5O      -   5        $��restitue��5O       #��[ 5P      $&
  MaterialDesignSwitchToggleButton��5Q      $
 TrueY�5R      $��
187,0,5,10q�6&   ���	#FF2980B96:   5V      � 5W      $��2��6    5X      �� 5Y      �� 5Z      �� 5[      .+�5]      �� $
��Left=�6   $��52��63   $��	5,-46,0,0q�6?   $	��Top=�6R   $	��172��6j   ���	#FF2980B9$��Sitka Display)�6�   $
��Bold"�6�   $��Orienté��6�   $��2��6�   d� 5^      -   5        $��oriente��5^      #��[ 5_      $&
  MaterialDesignSwitchToggleButton��5`      $
 TrueY�5a      $��182,-56,10,64q�6&   ���	#FF2980B9$��2��6T   �� 5b      -   5         ��Name$ Forme��5b      $
��Bold"�6*   $ Forme  ��5c       & "MaterialDesignFloatingHintComboBox#��[ 5d      $��	10,2,21,8q�6?   $��1��6R   ���	#FF2980B9���	#FF2980B9$��52��6�   5e      �� 5f      -   5        $ Effet��5f      $
��Bold"�6*   $ Effet Thérapeutique  ��5g      #��[ 5h      $��0,2,19,8q�6Q   ���	#FF2980B9���	#FF2980B9$��52��6�   �� 5i      -	   5        $��Quantite��5i      $ Quantité  ��5j      #��[ 5k      $��10,11,21,10q�6P   ���	#FF2980B9���	#FF2980B9$��18(�6�    �	#FF151922$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   $��2��6�   5m      � 5n      $��3��6    5o      �� 5p      �� 5q      �� 5r      .+�5t      (  "System.Windows.Controls.DatePicker  -
   5          Name$ 	date_prod��5t      $ Date De Production ��5u       ( $MaterialDesignFloatingHintDatePicker#��[ 5v      $��	0,18,32,3q�6A   ���	#FF2980B9���	#FF2980B9$��Sitka Display)�6�   $��18(�6�   $
��Bold"�6�     5w      -   5        $��date_peromp��5w      $ Date De Peremption ��5x      #��[ 5y      $��	10,21,8,3q�6S   ���	#FF2980B9���	#FF2980B9$��Sitka Display)�6�   $��18(�6�   $
��Bold"�6�   $��1��6�   �� 5z      -   5        $
��prix��5z      $ Prix  ��5{      #��[ 5|      $��
10,18,22,3q�6P   ���	#FF2980B9���	#FF2980B9$��18(�6�    �	#FF151922$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   $��2��6�   5}      � 5      $��4��6   $��69��6    $	��Top=�6,    5�      �� 5�      �� 5�      �� 5�      .+�5�      �� -   5         & "MaterialDesignFloatingActionButton#��[ 5�      $(
 "MaterialDesignFloatingActionButton��5�      $��2��60   $��136,63,75,-50q�6@   ���	#FF2980B9$	��Top=�6�   ��6n   Z� .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�6.   $��40��6:   $��40��6F   5�      �� 5�      -   5        #��[ 5�      $(
 "MaterialDesignFloatingActionButton��5�      $��2��6B   $��51,63,160,-50q�6R   ���	#FF2980B9$	��Top=�6�   ��6�   Z� .��5�        $ Reload=�6.   $��40��6<   $��40��5�      5�      �� 5�      -   5        $	��lot��5�      $	��245��6)   $
 Lot ��5�      #��[ 5�      $��0,29,0,0q�6P   ���	#FF2980B9���	#FF2980B9$��18(�6�    �	#FF151922$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   $
��Left=�6�   $��37��6   �� TextWrapping$
 Wrap=�6  $	��Top=�6(  5�      5�      5�      5�      