   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Menu.Les_interfacesMenu.Les_interfaces  5      -    'Menu.Les_interfaces.recherche_bien_etre   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Menu.Les_interfaces     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
        N� Title$  recherche_bien_etre��5	         MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	   .��5      � .+�5   
   � ��5      �� 5       �� ImageSource$ ..\images\slide1.jpg��6    j� Stretch$
 Fill=�6@    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 7Q�6   5      5      � 5   
   	 � RowDefinitions	 5       �� 5!      $
��102* �6    �� 5"      $
��145* �6    �� 5#      $
��222* �6    .+�5%      � $��0��6   .+�5&      #  MaterialDesignThemes.Wpf.Card  $��15q�6&   $��
50,10,50,5q�63   
�������.��5'      ��    MaterialDesignTitleTextBlock#���  6    $��Center=�6W   ���	#FF2980B9$��36(�6�   $��Sitka Display)�6�   " Rechercher Un Produit Bien-étre6�   5(      5*      � 5+      $��1��6   .+�5,      �� .+�5-        ���#FFF$��20,20q�6<   $	��131��6K   .��5.      �� .+�5/      � 
 � ColumnDefinitions
 50   "   �� 51   &   $��* �67   �� 52   &   $��* �67   �� 53   &   $��* �67   .+�55   "   �� -   5         ��Name$ Marque��55   *   $��0��6:   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Marque * ��56       % !MaterialDesignFloatingHintTextBox#��[ 57      ���	#FF2980B9$��0,0,0,2q�6V    �� 
CaretBrush �	#FF2980B9���	#FF2980B9 �� SelectionBrush �	#FF2980B9$��Sitka Display)�6�   $��18(�6�   $��15q�6�   �� 58   "   -   5        $
 type��58   *   $��1��68   $ Type * ��59      #��[ 5:      ���	#FF2980B9$��0,0,0,2q�6V    �	#FF2980B9���	#FF2980B9 �	#FF2980B9$��Sitka Display)�6�   $��18(�6�   $��15q�6�   �� 5<   "   -   5         ��Name$ Search��5<   )   $��2��69   $��30,15,30,10q�6I     MaterialDesignFlatButton#��[ 5=   %   ���	#FF2980B9
�������$
��10,7q�5>   0   $��18(�6?   $��Sitka Display)�6M   $
��Auto��6h   .��6�   
Rechercher5@   #   5A      5B      5C      5D      5F      � 5H      $��2��6   $��40,20q�6    ��5I      �� 5J       �� Color$ 	#FFDFE6E9��6&    �� Opacity$	 0.5Q�68   .+�5L      �� -   5         ��Name$ view_bien_etre��5L      $��0q�64   ���	#FF304FFE���	#FF304FFE$��Center=�6�   $��Center=�6�   ��6?   Z�  �� View 5M      �� 5N      .P�5O      ��  �� Width$	 100��6-   $��Marque��69    �� DisplayMemberBinding 6I   �� *Marque+�� 5P      $	 100��6-   $
��Type��69    6G   �� *type+�� 5Q      $	 100��6-   $��Composition Principale��69    6Y   �� *Gout+�� 5R      $	 180��6-   $��Date De Production��69    6U   �� *DateDeProduction+�� 5S      $	 180��6-   $��Date De Peremption��69    6U   �� *DateDePeremption+�� 5T      $	 100��6-   $��	Quantité��69    6K   �� *
Quantite+�� 5U      $	 180��6-   $��Prix Unitaire (DA)��69    6U   �� *Prix+5X      5Z      5[      5\      �� 5]   
   $
��Left=�6   $	��100��6-   $��-439,261,0,0q�6:   $	��Top=�6P   $	��100��6h   5_      5`      