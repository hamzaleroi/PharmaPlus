   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MenuMenu  5          Menu.reponse_recu   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Menu     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $	��500��5      $	��400��6   
������   � AllowsTransparency  .    MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ cmd_recu��5       � WindowStyle$ None =�6    � 
ResizeMode$ NoResize=�6.   .��5      � .+�5   
   � 
������� J� Opacity$
 0.75Q�6"   5      �� 5   
   ���	#FF2980B9$��1q�6)   ._�5      �  � RowDefinitions 5      �� 5      $	��36* �6$   �� 5      $	��89* �6$   �� 5      $
��125* �6$   .+�5       �� ���	#FF2980B9$
��20,3q�6/   $��Sitka Display)�6=   $��23(�6X   $
��Bold"�6g   $G��AVous avez recu une réponse à votre
                   commande��6y   �� 5!      $��La pharmacie��6   ���	#FF2980B9$��1��6H   $
��Left=�6U   $	��151��6p   $	��Top=�6}   $	��380��6�   $��	10,10,0,0q�6�   $��Sitka Display)�6�   $��18(�6�   .��5"      �� .+�5#      �  5$      �� 5%   "   $��* �60   �� 5&   "   $��* �60   .+�5(      ��  �� Orientation$ 
Horizontal=�6)   $��0��6B   .+�5)   "   �� -   5        	 ��Name$		 nom��5)   *   $��0,0,30,0q�67   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Le nom :��5*       % !MaterialDesignFloatingHintTextBox#��[ 5+      $��Sitka Display)�6>   $
��Bold"�6Y   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6k   Z� 6�   �� 5,   "   -   5        $	��adr��5-   N   $
 L'adresse :��6!   #��[ 5.   !   $��Sitka Display)�6\   $
��Bold"�6w   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6�   Z� 6�   5/      �� 50      $ 
Horizontal=�6)   $��1��6B   .+�51   "   �� -   5        $		 tel��51   *   $��0,0,30,0q�67   $
 N de télephone :��52      #��[ 53      $��Sitka Display)�6>   $
��Bold"�6Y   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6k   Z� 6�   �� 54   "   -   5        $	��fax��55   M   $
 
N de Fax :��6!   #��[ 56   !   $��Sitka Display)�6\   $
��Bold"�6w   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6�   Z� 6�   57      58      59      5:      �� 5;      $��La Commande��6   ���	#FF2980B9$��2��6G   $
��Left=�6T   $	��194��6o   $	��Top=�6|   $	��380��6�   $��	10,10,0,0q�6�   $��Sitka Display)�6�   $��18(�6�   .��5<      �� .+�5=      �  5>      �� 5?   "   $��* �60   �� 5@   "   $��* �60   �� 5A   "   $��* �60   .+�5C      �� $ 
Horizontal=�6)   $��0��6B   .+�5D   "   �� -   5        $		 dci��5D   *   $��0,0,30,0q�67   $
 DCI :��5E      #��[ 5F      $��Sitka Display)�6>   $
��Bold"�6Y   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6k   Z� 6�   �� 5G   "   -   5        $	 marque��5G   *   $
 La marque :��5H   !   #��[ 5I   !   $��Sitka Display)�6\   $
��Bold"�6w   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6�   Z� 6�   5J      �� 5K      $ 
Horizontal=�6)   $��1��6B   .+�5L   "   �� -   5        $	 forme��5L   *   $��0,0,30,0q�69   $
 
La forme :��5M      #��[ 5N      $��Sitka Display)�6>   $
��Bold"�6Y   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6k   Z� 6�   �� 5O   "   -	   5        $	 dosage��5O   *   $
 Le Dosage :��5P   !   #��[ 5Q   !   $��Sitka Display)�6\   $
��Bold"�6w   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6�   Z� 6�   5R      �� 5S      $ 
Horizontal=�6)   $��2��6B   .+�5T   "   �� -
   5        $	 restitue��5T   *   $��0,0,30,0q�6<   $
 Restitué :��5U      #��[ 5V      $��Sitka Display)�6>   $
��Bold"�6Y   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6k   Z� 6�   �� 5W   "   -   5        $	 quant��5W   *   $
 La quantité :��5X   !   #��[ 5Y   !   $��Sitka Display)�6\   $
��Bold"�6w   ���	#FF2980B9���	#FF2980B9$��0,0,0,2q�6�   $	��147��6�   ��6�   Z� 6�   5Z      5[      5\      5]      5_      5`      �� 5a   
   -   5        $��Fermer��5a      $
��Left=�6"   $��256,469,0,0q�6=   $	��Top=�6R   $��86��6j   $��21��6u   6�   5b      5c      