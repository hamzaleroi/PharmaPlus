   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Menu.Les_interfacesMenu.Les_interfaces  5   	   $    Menu.Les_interfaces.Window_cmd   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Menu.Les_interfaces     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
     � Title$  
Window_cmd��5   	   $��276.15��6   $	��543��6,    � WindowStyle$
 None=�68    � 
ResizeMode$ NoResize=�6K      MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � ���	#FF1976D2 � ColumnDefinitions 5   
   �� 5      .+�5   
   � $
��Left=�6   $	��227��6*   $��5,41,0,0q�67   $	��Top=�6I   $	��534��6a   ���	#FFDFE6E9 5      �� 5      $	��20* �6#   �� 5      $	��24* �6#   �� 5      $��5* �6#   .+�5      �� -   5        $��
DCItextbox��5      ���	#FF2980B9$
��Left=�6@   $��45��6[   $��
124,10,0,0q�6g    �� TextWrapping$
 Wrap=�6{   $�� ��6�   $	��Top=�6�   $	��120��6�   ���	#FF2980B9$��2��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 DCI��5       % !MaterialDesignFloatingHintTextBox#��[ 5      ��5   �   Z� 5      �� 5       -   5        $��Marquetextbox��5       ���	#FF2980B9$��124,69,240,122q�6C   $
 Wrap=�6[   $�� ��6o   ���	#FF2980B9$��2��6�   $ Nom Commercial��5!      #��[ 5"      ��5    w   Z� 5"      �� 5$      -   5        $��Quanttextbox��5$      ���	#FF2980B9$��124,119,240,74q�6A   $
 Wrap=�6Y   $�� ��6m   ���	#FF2980B9$��2��6�   $ 	Quantité��5%      #��[ 5&      ��5$   u   Z� 5&      �� 5(      -   5        $��Dosagetextbox��5(      ���	#FF2980B9$
��Left=�6B   $��45��6]   $��
134,10,0,0q�6i   $
 Wrap=�6}   $�� ��6�   $	��Top=�6�   $	��120��6�   ���	#FF2980B9$��1��6�   $ Dosage��5)      #��[ 5*      ��5(   �   Z� 5*      �� 5-      -   5         ��Name$ Forme_combobox��5-      $ Forme��5.      ���	#FF2980B9���	#FF2980B9$��72��5/       & "MaterialDesignFloatingHintComboBox#��[ 51      $��
134,69,0,0q�6@   $	��Top=�6T   $
��Left=�6l   $	��120��6�   $��36��6�   $��1��6�   ��50      �� *#!LongListToTestComboVirtualization+��52      �� 53      .R�54      $� 55      57      �� 59      -   5        	 ��Name$	 Renitialiser��59      $��136,175,93,19q�6+   $��1��6C    . *MaterialDesignFloatingActionMiniDarkButton#��[ 5:      
 � ToolTip$
 Réinitialiser ��5;      $
��Auto��6.   $
��Auto��6<   .��5<      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ 	Autorenew=�6*   $��24��6;   ���	#FFDFE6E9$��24��6_   5=      �� 5?      -   5        $��valider��5?   T   $��195,175,34,19q�6   $��1��6.   #��[ 5@      $
 Valider ��5A      $
��Auto��6(   $
��Auto��66   .��5B        $ Check=�6*   $��24��67   ���	#FFDFE6E9$��24��6[   5C      5E      � 5F   
   -   5        $
��Left=�5F      $��29��6P   $	��Top=�6\   $	��539��6t   $��0,0,-4,0q�6�    � RowDefinitions 5G      �� 5H      $��5* �6    �� 5I      $	��17* �6    .+�5K      �� $��
13,0,13,-7q�6   $
��Wrap=�6,   ���	#FFDFE6E9$��18(�6W   $��Sitka Display)�6e   $
��Bold"�6�    �� Padding$ 2,2,2,1q�6�   $��1��6�    �� TextAlignment$ Center=�6�   $+��%Ajouter un médicament à la commande��6�   �� 5L      -	   5        $��499,0,10,-7q�5L       J� RenderTransformOrigin$ 	0.25,2.75&�6A   $��1��6c   $
��Auto��6p   ���	#FF1976D2���	#FF1976D2��5M      �� 5N       �� 
TargetType" ��6&   .R�5O      � .+�5P      A� $��1��6&   ���	#FF2980B96:   A� 5R      ���	#FFEEF3FD$��1��5S      ��6&   Z� (� 5T      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     6&    (� Stretch$ Uniform=�6h   .��5U   "   ��  ��Name$ Calque_1��6)   $	��840��6;   $	��595��6G    �� Left$ 0��6T   
 �� Top$ 0��6d   z�5V   &   T� 5W   *    T� X$ 0Q�6=    T� Y$ 0Q�6C   .+�5[   &   F� :x,http://schemas.microsoft.com/winfx/2006/xaml     6+    F�Name$ path10��6b   ���	#FFDFE6E8��5\   *   B� 5]   .   $����M601.528 393.328L506.2 298l95.328-95.328c23.42-23.42 22.921-62.262-0.509-85.691  s-62.271-23.929-85.691-0.509L420 211.8l-95.328-95.328c-23.42-23.42-62.262-22.92-85.691 0.509s-23.929 62.271-0.509 85.691  L333.8 298l-95.328 95.328c-23.42 23.42-22.921 62.262 0.509 85.691s62.271 23.929 85.691 0.509L420 384.2l95.328 95.328  c23.42 23.421 62.262 22.921 85.691-0.509S624.948 416.749 601.528 393.328zC�6;    B� FillRule$ NonZero=�6�  5_   '   5`   #   5a      �� 5b      $��Center=�6/   $��Center=�5c      5d      5e      5h      5i      5l      5m      