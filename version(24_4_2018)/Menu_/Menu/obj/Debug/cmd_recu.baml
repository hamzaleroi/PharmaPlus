   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MenuMenu  5          Menu.cmd_recu   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Menu     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $	��500��5      $	��400��6   
������   � AllowsTransparency  .    MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ cmd_recu��5       � WindowStyle$ None =�6    � 
ResizeMode$ NoResize=�6.   .��5      � .+�5   
   � 
������� J� Opacity$
 0.75Q�6"   5      �� 5   
   ���	#FF2980B9$��1q�6)   ._�5   
   �  � RowDefinitions 5      �� 5      $	��36* �6$   �� 5      $	��89* �6$   �� 5      $
��125* �6    �� 5      $	��36* �6    .+�5!      �� ���	#FF2980B9$��30,10q�6/   $��Sitka Display)�6>   $��25(�6Y   $
��Bold"�6g   .��6z   Vous avez recu une commande6�   �� 5"      $��La pharmacie��6   ���	#FF2980B9$��1��6H   $
��Left=�6U   $	��151��6p   $	��Top=�6}   $	��380��6�   $��	10,10,0,0q�6�   $��Sitka Display)�6�   $��18(�6�   .��5#      �� .+�5$      �  5%      �� 5&      $��* �6,   �� 5'      $��* �6,   .+�5)      ��  �� Orientation$ 
Horizontal=�6%   $��0��6>   .+�5*      �� -   5        	 ��Name$		 nom��5*   &   $��0,0,30,0q�63   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Le nom :��5+       % !MaterialDesignFloatingHintTextBox#��[ 5,      $��Sitka Display)�6>   $
��Bold"�6Y   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6k   Z� 6�   �� 5-      -   5        $	��adr��5.   N   $
 L'adresse :��6!   #��[ 5/   !   $��Sitka Display)�6\   $
��Bold"�6w   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6�   Z� 6�   50      �� 51      $ 
Horizontal=�6%   $��1��6>   .+�52      �� -   5        $		 tel��52   &   $��0,0,30,0q�63   $
 N de télephone :��53      #��[ 54      $��Sitka Display)�6>   $
��Bold"�6Y   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6k   Z� 6�   �� 55      -   5        $	��fax��56   M   $
 
N de Fax :��6!   #��[ 57   !   $��Sitka Display)�6\   $
��Bold"�6w   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6�   Z� 6�   58      59      5:      5;      �� 5<      $��La Commande��6   ���	#FF2980B9$��2��6G   $
��Left=�6T   $	��194��6o   $	��Top=�6|   $	��380��6�   $��	10,10,0,0q�6�   $��Sitka Display)�6�   $��18(�6�   .��5=      �� .+�5>      �  5?      �� 5@      $��* �6,   �� 5A      $��* �6,   �� 5B      $��* �6,   .+�5D      �� $ 
Horizontal=�6%   $��0��6>   .+�5E      �� -   5        $		 dci��5E   &   $��0,0,30,0q�63   $
 DCI :��5F      #��[ 5G      $��Sitka Display)�6>   $
��Bold"�6Y   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6k   Z� 6�   �� 5H      -   5        $	 marque��5H   &   $
 La marque :��5I   !   #��[ 5J   !   $��Sitka Display)�6\   $
��Bold"�6w   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6�   Z� 6�   5K      �� 5L      $ 
Horizontal=�6%   $��1��6>   .+�5M      �� -   5        $	 forme��5M   &   $��0,0,30,0q�65   $
 
La forme :��5N      #��[ 5O      $��Sitka Display)�6>   $
��Bold"�6Y   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6k   Z� 6�   �� 5P      -	   5        $	 dosage��5P   &   $
 Le Dosage :��5Q   !   #��[ 5R   !   $��Sitka Display)�6\   $
��Bold"�6w   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6�   Z� 6�   5S      �� 5T      $ 
Horizontal=�6%   $��2��6>   .+�5U      �� -
   5        $	 restitue��5U   &   $��0,0,30,0q�68   $
 Restitué :��5V      #��[ 5W      $��Sitka Display)�6>   $
��Bold"�6Y   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6k   Z� 6�   �� 5X      -   5        $	 quant��5X   &   $
 La quantité :��5Y   !   #��[ 5Z   !   $��Sitka Display)�6\   $
��Bold"�6w   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6�   Z� 6�   5[      5\      5]      5^      �� 5_      $��3��6   $ 
Horizontal=�6*   .+�5`      �� -   5         ��Name$ accept��5`        MaterialDesignFlatButton#��[ 6-   $��Accepter la commande��6a   $
��Left=�6�   $	��Top=�6�   $	��160��6�   $��	20,20,0,0q�6�   $��30��6�   $��Sitka Display)�6�   $��16(�6�   ���	#FFEEEEF2���	#FF2980B9$��3q�6a  ��6J  Z� 6a  �� 5a      -   5        $ refuse��5a      #��[ 6-   $��Refuser la commande��6a   $
��Left=�6   $	��Top=�6�   $	��160��6�   $��	20,20,0,0q�6�   $��30��6�   $��Sitka Display)�6�   $��16(�6�   ���	#FFEEEEF2���	#FF2980B9$��3q�6`  ��6I  Z� 6`  5c      5d      5e      5f      5g      