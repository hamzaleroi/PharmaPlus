   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:facturefacture  5   	       facture.Window1   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:facture     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
     � Title$  Window1��5   	   $��389.302��6   $��646.447��6*    � WindowStyle$
 None=�6:    � 
ResizeMode$ NoResize=�6M      MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      �  � RowDefinitions 5   
   �� 5      $
��104* �6   �� 5      $
��285* �6   .+�5   
   � $��0��6   ���	#FF2980B9 5      �� 5      $	��47* �6    �� 5      $	��44* �6    6/   .+�5      �� -   5        $
��Wrap=�5      $��0��6T   $��Center=�6a   $��Center=�6~   ���	#FFDFE6E9$��24(�6�   $��Sitka Display)�6�   $
��Bold"�6�    �� Padding$ 2,2,2,1q�6�   $	��636��6�   $��
10,10,0,10q�6	   �� TextAlignment$ Center=�6  �� 67  $
�    ��6;  �� 6I  $&� Ajouter un produit à la facture��6M  6w  �� 5      -   5        $��0��5      $��29��6;   $��29��6F   ���	#FF1976D2���	#FF1976D2$	��Top=�6�   $��	0,10,10,0q�6�   $��Right=�6�   ��5      �� 5       �� 
TargetType" ��6&   .R�5      � .+�5       A� $��1��6&   ���	#FF2980B96:   A� 5"      ���	#FFEEF3FD$��1��5#      ��6&   Z� (� 5$      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     6&   	 (� Stretch$	 Uniform=�6h   .��5%   "   �� 
 ��Name$
 Calque_1��6)   $	��840��6;   $	��595��6G    �� Left$ 0��6T   
 �� Top$ 0��6d   z�5&   &   T� 5'   *    T� X$ 0Q�6=    T� Y$ 0Q�6C   .+�5+   &   F� :x,http://schemas.microsoft.com/winfx/2006/xaml     6+    F�Name$ path10��6b   ���	#FFDFE6E8��5,   *   B� 5-   .   $����M601.528 393.328L506.2 298l95.328-95.328c23.42-23.42 22.921-62.262-0.509-85.691  s-62.271-23.929-85.691-0.509L420 211.8l-95.328-95.328c-23.42-23.42-62.262-22.92-85.691 0.509s-23.929 62.271-0.509 85.691  L333.8 298l-95.328 95.328c-23.42 23.42-22.921 62.262 0.509 85.691s62.271 23.929 85.691 0.509L420 384.2l95.328 95.328  c23.42 23.421 62.262 22.921 85.691-0.509S624.948 416.749 601.528 393.328zC�6;    B� FillRule$ NonZero=�6�  5/   '   50   #   51      �� 52      $��Center=�6/   $��Center=�53      54      55      58      o� 5:      $��Center=�6   
������ $��1��6J   $	��414��6W   .@�5;      m� -   5        $��  Médicament��5;      $��0,0,0,2q�61   ���	#FFDFE6E9
�������$��18(�6�   
������ $��Sitka Display)�6�   $��
3,0,-90,-9q�6�   $	��190��6�   $��38��6�    m� Icon 5<      '  !MaterialDesignThemes.Wpf.PackIcon  5>      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ 
MedicalBag=�62   5@      m� 5A      -   5        $��
 Bien Etre��5A      $��0,0,0,2q�61   ���	#FFDFE6E9
�������
������ $��18(�6�   $��Sitka Display)�6�   $��0,0,0,0q�6�   $��2,12,6,2q�6�   $	��191��6�   $��38��6�    5C        5D      $
 Gift=�62   5F      5H      5I      � 5J   
   $��1��6   $��0,0,0,0q�6   .+�5K       � -   5          �Name$
 Main��5K        � NavigationUIVisibility$ Hidden=�6#   5L      5M      5O      