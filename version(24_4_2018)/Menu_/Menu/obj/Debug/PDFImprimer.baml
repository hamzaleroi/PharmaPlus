   M S B A M L   `   `   `  ����  Menu    Menu.PDFImprimer   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Page9��5         MaterialDesignBody#���   5   	   $��Regular"�5   	   $��18(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5	   	      TextRenderingMode$
 Auto=�5
   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
    � -   5        $��frame1��5        � NavigationUIVisibility$ Hidden=�6   $��0��60   $��50��6=   $��Stretch=�6I   $y�	Collapsed=�6h   $	��Top=�6�   $
��Auto��6�   � 5   
   $��1��6   $��Stretch=�6   $��Stretch=�6:   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      � 	 � Color$	 	#992980B9��6#   
 � Offset$
 0Q�65   � 5      $	 White��6#   $
 1Q�61   � 5      $	 	#992980B9��6#   $
 0.385Q�65   � 5      $	 White��6#   $
 0.385Q�61   5       � ColumnDefinitions 5!      �� 5"      $��* �6#   6/   �� 5#      $��3* �6#   60   �� 5$      $��* �6#   6/   .+�5&      �� 
�������$��1��6(   $��20q�68   $��1q�6E    J� Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         
BlurRadius$ 20Q�6'      Opacity$	 0.4Q�67      	Direction$	 100Q�6E   5*      ._�5,      � }�.  5/      �� 50      $
��Auto �6(   �� 51      $��* �6(   �� 52      $
��Auto �6(   .+�54      �� 
������� 55        56      $ 20Q�6/   $ 1Q�6?   $
 -100Q�6K   58      ._�5:      �� $��0��6%    �� Orientation$ 
Horizontal=�62   .+�5;      �� $��18(�6$   $��DemiBold"�62    J� Opacity$
 0.54Q�6H   .��6W   64La facture : veuillez choisir undes choix en dessous6�   5<      5=      (  "System.Windows.Controls.WebBrowser  5>      -   5          Name$ webpage��5>   C   $��1��6T   $��Stretch=�6a   $��Stretch=�6    J� OpacityMask �	#FFD824245@      �� 5A      $��2��6    �� Padding$ 10q�6*   ._�5B      �� $ 
Horizontal=�6%   $��Right=�6>   .+�5C      �� 
������ ���	#FF151922
������ $��15(�6o   $��DemiBold"�6}   $��40��6�   $��Right=�6�   $��8q�6�   $��0,24,0,0q�6�   .��6�   
Click me 26�   �� 5D      -   5        ���	#FF151922  MaterialDesignFlatButton#��[ 5D   <   
�������
������ $��15(�6�   $��DemiBold"�6�   $��40��6�   $��Right=�6�   $��8q�6�   $��0,24,0,0q�6�   .��6  Convertir en PDF6-  5E      5F      5G      5H      5I      5J      5M      