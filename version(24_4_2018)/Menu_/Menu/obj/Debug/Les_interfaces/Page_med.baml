   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Menu.Les_interfacesMenu.Les_interfaces  5      "    Menu.Les_interfaces.Page_med   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Menu.Les_interfaces     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
        N� Title$  Page_med��5	         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper N� 
Background# �  5        MaterialDesignFont N� 
FontFamily# �  5      .��5      � ���	#FFDFE6E9 � RowDefinitions 5   
   �� 5      $
��217* �6   6,   �� 5      $	��73* �6   6+   �� 5      $	��10* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      6%   �� 5       6%   .+�5#      � $��0��6   $	��203��6#   $	��Top=�60    5$      �� 5%      6&   �� 5&      6&   �� 5'      6&   .+�5)      �� -   5        $��
DCItextbox��5*   5   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 DCI��6   $	��164��6)   ���	#FF2980B9���	#FF2980B9$��	0,10,69,0q�6x    �� TextWrapping$
 Wrap=�6�   $�� ��6�    % !MaterialDesignFloatingHintTextBox#��[ 5+      	 �� 
CaretBrush	 �	#FF2980B9
 �� SelectionBrush
 �	#FF2980B9$��0��6q   $��Right=�6~   $��47��6�   $	��Top=�6�   ��5*   �   Z� 5+   �   �� 5-      -   5        $��Marquetextbox��5.   D   $ Marque��6   $��1��6+   $	��164��68   ���	#FF2980B9$��	0,11,69,0q�6q   $
 Wrap=�6�   $�� ��6�   ���	#FF2980B9
 �	#FF2980B9#��[ 5/      $��Right=�6>   $��44��6Z   $	��Top=�6f   ��5.   �   Z� 5/   f   �� 50      -   5         ��Name$ Quanttextbox��51   -   $ 	Quantité��6   $	��164��6C   $��2��6O   ���	#FF2980B9$��	0,10,69,0q�6t   $
 Wrap=�6�   $�� ��6�   ���	#FF2980B9
 �	#FF2980B9#��[ 52       J� RenderTransformOrigin$ 0.5,0.5&�6>   $��Right=�6^   $��41��6z   $	��Top=�6�   ��51   �   Z� 52   �   53      � 54      $��1��6   $	��193��6#   $	��Top=�60    55      �� 56      6&   �� 57      6&   �� 58      6&   .+�5:      �� -   5        $��Dosagetextbox��5;   Q   $ Dosage��6   $��0��6+   ���	#FF2980B9$
��Left=�6f   $��	79,10,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��164��6�   ���	#FF2980B9
 �	#FF2980B9#��[ 5<      $��50��6>   $	��Top=�6J   ��5;   �   Z� 5<   J   �� 5=      -   5         ��Name$ Forme_combobox��5A   ?   $��1��5=      $	��164��6)   $ Forme��5>      ���	#FF2980B9���	#FF2980B9 & "MaterialDesignFloatingHintComboBox#��[ 5A      $��	79,10,0,0q�6W   $	��Top=�6j   $
��Left=�6�   $��50��6�   ��5@      �� *#!LongListToTestComboVirtualization+��5B      �� 5C      .R�5D      $� 5E      5G      �� 5H      -   5        $ restit��5K   ?   $��2��5H      $
 Type��5I      ���	#FF2980B9���	#FF2980B9$��72��5J      #��[ 5K      $��	79,10,0,0q�6O   $	��Top=�6b   $
��Left=�6z   $	��164��6�   $��48��6�   ��5J      �� *#!LongListToTestComboVirtualization+.@�5L      �� -   5         ��Name$
 rest��5L   #   $��	Restitué��61   �� 5M      -   5        $ non_rest��5M   #   $��Non Restitué��65   �� 5N      -	   5        $
 none��5N   #   $��Non Défini��61   ��5O      �� 5P      .R�5Q      $� 5R      5T      5U      5V      � 5W   
   $��Center=�6   $	��604��6,   $��
98,15,98,0q�68   $��1��6L    5X      �� 5Y      �� 5Z      .+�5\      �� -
   5         ��Name$ Renitialiser��5\       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5]       � ToolTip$ Réinitialiser ��5^      $��40��6.   $��40��6:   $��Right=�6F   $��	0,10,47,0q�6b   $	��Top=�6u   .��5_      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ 	Autorenew=�6*   $��24��6;   ���	#FFDFE6E9$��24��6_   5`      �� 5b      -   5        $ valider��5b   T   $��40��6   $��40��6"   $��1��6-   #��[ 5c      $ Valider ��5d      $
��Left=�6(   $��47,9,0,0q�6C   $	��Top=�6U   .��5e        $ Check=�6*   $��24��67   ���	#FFDFE6E9$��27��6[   5f      5g      5j      5l      