   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Menu.Les_interfacesMenu.Les_interfaces  5      )    #Menu.Les_interfaces.Ajouter_b1_etre   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -local!clr-namespace:Menu.Les_interfaces  5         MaterialDesignBody#���   5      $��Regular"�5	   	   $��18(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� Title$ Ajouter_b1_etre��5      .��5      � .+�5   
   � ��5      �� 5       �� ImageSource$ ..\images\slide1.jpg��6    j� Stretch$
 Fill=�6@    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 7Q�6   5      5      � 5   
   .+�5       #  MaterialDesignThemes.Wpf.Card  $��10q�6"   $��
24,10,25,0q�6/   ���#FFF$��0��6U   $	��100��6b   .��5#      �� $��Center=�6   $&�� Ajouter un produit de Bien être��65   ���	#FF2980B9��5$      �� 5%      	 �� 
TargetType"	 ��6    .�5&      �� 
 �� Property
 � �� �� Value$ 45(�69    �� BasedOn 5'      �� 5(   "   "	 ��6(   .�5)   &   �� 
 � ��$ 13(�6A   �� 5*   &   
 � ��$ Normal"�6C   �� 5+   &   
 � ��# �   6C    �� Triggers 5,   &   P� 5-   *    P� Property � {� P� Value .  . �5.   .   �� 
 � �� " MaterialDesignCheckBoxDisabled# �  6K   5/   +   P� 50   *    � {� . . �51   .   �� 
 �@�Cursor$
 Hand��6G   52   +   ]� 53   *    ]� 
Conditions 54   .   �� 55   2    �� Property � {� �� Value . 6Q   �� 56   2    �@J�IsMouseOver . 6S   59   +   5;   #   5=      5?      5@      � 5G      $��	0,113,0,0q�6    � RowDefinitions 5H      �� 5I      $	��93* �6$   �� 5J      $	��87* �6$   �� 5K      $	��91* �6$   �� 5L      $
��153* �6$   .+�5N      � $��0��6   $
��25,0q�6$    � ColumnDefinitions 5O      �� 5P      �� 5Q      �� 5R      .+�5T      �� -   5         ��Name$ Marque��5T      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Marque * ��5U       % !MaterialDesignFloatingHintTextBox#��[ 5V      $��
5,10,10,10q�6P   ���	#FF2980B9���	#FF2980B9$��18(�6�    �� 
CaretBrush �	#FF151922$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   �� 5W      -   5        $
 Type��5W      $ Type * ��5X      #��[ 5Y      $��10,10,23,10q�6P   ���	#FF2980B9���	#FF2980B9 �	#FF151922$��18(�6�   $
��Bold"�6�   $��1��6�   $��Sitka Display)�6�    �� SelectionBrush �	#FF2980B96�   �� 5Z      -   5        $ main_ingred��5Z      $ Composition Principale * ��5[      #��[ 5\      $��10,10,22,10q�6P   ���	#FF2980B9���	#FF2980B9 �	#FF151922$��18(�6�   $
��Bold"�6�   $��2��6�   $��Sitka Display)�6�   5_      � 5`      $��1��6   $
��25,0q�6$    5a      �� 5b      �� 5c      �� 5d      .+�5f      �� -   5        $ Quantite��5f      $ Quantité * ��5g      #��[ 5h      $��
5,10,10,11q�6P   ���	#FF2980B9���	#FF2980B9$��18(�6�    �	#FF151922$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   �� 5i      -   5        $
 prix��5i      $ Prix * ��5j      #��[ 5k      $��10,11,28,10q�6P   ���	#FF2980B9���	#FF2980B9$��18(�6�    �	#FF151922$��Sitka Display)�6�   $
��Bold"�6�   $�� ��6�   $��1��6�   5l      � 5n      $��2��6   $
��25,0q�6$   $��86��62   $��Bottom=�6>    5o      �� 5p      $
��296* �6+   �� 5q      $
��284* �6+   �� 5r      $
��309* �6+   .+�5t      (  "System.Windows.Controls.DatePicker  -   5          Name$ 	date_prod��5t   1   $��0��6!   $ Date De Production ��5u       ( $MaterialDesignFloatingHintDatePicker#��[ 5v      $��10,29,10,10q�6S   ���	#FF2980B9���	#FF2980B9$��Sitka Display)�6�   $��18(�6�   $
��Bold"�6�     5w      -   5        $ date_peromp��5w   !   $��1��66   $ Date De Peremption * ��5x      #��[ 5y      $��
0,29,15,10q�6S   ���	#FF2980B9���	#FF2980B9$��Sitka Display)�6�   $��18(�6�   $
��Bold"�6�   $��Right=�6�   $	��225��6�   5z      � 5{      $��3��6    5|      �� 5}      �� 5~      .+�5�      �� -   5        $��1��5�   !   $��0��61    & "MaterialDesignFloatingActionButton#��[ 5�       � ToolTip$ Valider��5�      ���	#FF2980B9$��Bottom=�6c   $��10,0,334,56q�6~   ��67   Z� .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�62   $��40��6>   $��40��6J   5�      �� 5�      -	   5        $��0��5�      $��0��6-   #��[ 5�      $ Réinitialiser��5�      ���	#FF2980B9$��Bottom=�6S   $
��Left=�6�   $��
334,0,0,56q�6�   ��6<   Z� .��5�        $ Reload=�62   $��40��6@   $��40��5�      5�      5�      5�      5�      5�      5�      