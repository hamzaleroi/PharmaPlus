   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Menu.Les_interfacesMenu.Les_interfaces  5   	   .    (Menu.Les_interfaces.Window_cmd_bien_etre   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Menu.Les_interfaces     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
     � Title$  Window_cmd_bien_etre��5   	   $��276.15��6&   $	��543��66    � WindowStyle$
 None=�6B    � 
ResizeMode$ NoResize=�6U      MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � ���	#FF1976D2 � ColumnDefinitions 5   
   �� 5      .+�5   
   � $
��Left=�6   $	��227��6*   $��5,41,0,0q�67   $	��Top=�6I   $	��534��6a   ���	#FFDFE6E9 5      �� 5      $	��20* �6#   �� 5      $	��24* �6#   �� 5      $��5* �6#   .+�5      �� -   5        $��Marquetextbox��5      ���	#FF2980B9$
��Left=�6C   $��45��6^   $��
109,10,0,0q�6j    �� TextWrapping$
 Wrap=�6~   $�� ��6�   $	��Top=�6�   $	��135��6�   ���	#FF2980B9$��2��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Marque��5       % !MaterialDesignFloatingHintTextBox#��[ 5      ��5   �   Z� 5      �� 5       -   5        $��Typetextbox��5       ���	#FF2980B9$��109,91,240,100q�6A   $
 Wrap=�6Y   $�� ��6m   ���	#FF2980B9$��2��6�   $
 Type��5!      #��[ 5"      ��5    u   Z� 5"      �� 5$      -   5        $��Compotextbox��5$      ���	#FF2980B9$
��Left=�6A   $��45��6\   $��
102,10,0,0q�6h   $
 Wrap=�6|   $�� ��6�   $	��Top=�6�   $	��152��6�   ���	#FF2980B9$��1��6�   $ Composition Principale��5%      #��[ 5&      ��5$   �   Z� 5&      �� 5(      -   5        $��Quanttextbox��5(      ���	#FF2980B9$��102,93,10,100q�6A   $
 Wrap=�6X   $�� ��6l   ���	#FF2980B9$ 	Quantité��5)      #��[ 5*      $��1��6>   ��5(   t   Z� 5*   >   �� 5,      -   5         ��Name$ Renitialiser��5,      $��0,170,229,24q�6+   $��1��6B    . *MaterialDesignFloatingActionMiniDarkButton#��[ 5-      	 � ToolTip$	 Réinitialiser ��5.      $
��Auto��6.   $
��Auto��6<   .��5/      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]
   Kind$
 	Autorenew=�6*   $��24��6;   ���	#FFDFE6E9$��24��6_   50      �� 52      -   5        $��valider��52   T   $��59,170,170,24q�6   $��1��6.   #��[ 53      $	 Valider ��54      $
��Auto��6(   $
��Auto��66   .��55        $
 Check=�6*   $��24��67   ���	#FFDFE6E9$��24��6[   56      58      � 59   
   -   5        $
��Left=�59      $��29��6P   $	��Top=�6\   $	��539��6t   $��0,0,-4,0q�6�    � RowDefinitions 5:      �� 5;      $��5* �6    �� 5<      $	��17* �6    .+�5>      �� $��
13,0,13,-7q�6   $
��Wrap=�6,   ���	#FFDFE6E9$��18(�6W   $��Sitka Display)�6e   $
��Bold"�6�    �� Padding$ 2,2,2,1q�6�   $��1��6�    �� TextAlignment$ Center=�6�   $4��.Ajouter un produit de bien etre à la commande��6�   �� 5?      -   5        $��499,0,10,-7q�5?       J� RenderTransformOrigin$ 	0.25,2.75&�6A   $��1��6c   $
��Auto��6p   ���	#FF1976D2���	#FF1976D2��5@      �� 5A       �� 
TargetType" ��6&   .R�5B      � .+�5C      A� $��1��6&   ���	#FF2980B96:   A� 5E      ���	#FFEEF3FD$��1��5F      ��6&   Z� (� 5G      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     6&    (� Stretch$ Uniform=�6h   .��5H   "   ��  ��Name$ Calque_1��6)   $	��840��6;   $	��595��6G    �� Left$ 0��6T   
 �� Top$ 0��6d   z�5I   &   T� 5J   *    T� X$ 0Q�6=    T� Y$ 0Q�6C   .+�5N   &   F� :x,http://schemas.microsoft.com/winfx/2006/xaml     6+    F�Name$ path10��6b   ���	#FFDFE6E8��5O   *   B� 5P   .   $����M601.528 393.328L506.2 298l95.328-95.328c23.42-23.42 22.921-62.262-0.509-85.691  s-62.271-23.929-85.691-0.509L420 211.8l-95.328-95.328c-23.42-23.42-62.262-22.92-85.691 0.509s-23.929 62.271-0.509 85.691  L333.8 298l-95.328 95.328c-23.42 23.42-22.921 62.262 0.509 85.691s62.271 23.929 85.691 0.509L420 384.2l95.328 95.328  c23.42 23.421 62.262 22.921 85.691-0.509S624.948 416.749 601.528 393.328zC�6;    B� FillRule$ NonZero=�6�  5R   '   5S   #   5T      �� 5U      $��Center=�6/   $��Center=�5V      5W      5X      5[      5\      5_      5`      