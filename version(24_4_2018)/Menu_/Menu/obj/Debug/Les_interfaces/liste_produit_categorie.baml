   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Menu.Les_interfacesMenu.Les_interfaces  5      1    +Menu.Les_interfaces.liste_produit_categorie   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Menu.Les_interfaces     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5      $��Regular"�5	   	   $��18(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� Title$ liste_produit_categorie��5      .��5      � .+�5   
   � ��5      �� 5       �� ImageSource$ ..\images\1.jpg��6    j� Stretch$
 Fill=�6;    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 12Q�6   5      5      � 5   
   	 � RowDefinitions	 5   
   �� 5       $
��101* �6   �� 5!      $
��349* �6   .+�5#   
   #  MaterialDesignThemes.Wpf.Card  $��15q�6   $��
10,10,10,0q�6+   
�������$��78��6R   .��5$      ��    MaterialDesignTitleTextBlock#���  6   $��Center=�6O   ���	#FF2980B9$��36(�6�   $��Sitka Display)�6�   31Affichage de la liste des produits par catégorie6�   5%      � 5&   
   $��58,39,51,42q�6   $��1��6$   .+�5(          MaterialDesignBackground#���  5)      .��5*      �� $
��Auto=�6   .��5+      �� .+�5,      9� $��Stretch=�5-      $��Les médicaments��5.      ���	#FF2980B9$��Sitka Display)�6O   $��20(�6j   $
��Bold"�6x   .��5/      �� -   5        $��medica��5/   )   
 �� Orientation$
 Vertical=�50   !   #���   51   !   $��
24,8,24,16q�52   !   53      54      �� 55      -   5        $��border1��55   %   ���	#FF2980B9$��1��57      $��Stretch=�58       J� SnapsToDevicePixels . ���	#FF2980B959   :   9� 5:      $��Stretch=�6'   $ ��Les produits de bien être��6E   ���	#FF2980B9$��Sitka Display)�6   $��20(�6�   $
��Bold"�6�   .��5;      �� -   5        $��	bien_etre��5<   !   $
 Vertical=�5=   !   #���   5>   !   $��
24,8,24,16q�6]   5?      5@      �� 5A        MaterialDesignDivider#���  5B      $��1��5C      $��Stretch=�5D       . 5E      5F      5G      5H      5J      5K      5L      5M      