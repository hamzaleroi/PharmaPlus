   M S B A M L   `   `   `  ����?  ;Menu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MenuMenu  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF 5          Menu.BilanDeVente   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $localclr-namespace:Menu     5      Efa6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF     5        N� Title$  Page8��5      .��5      � $	��550��6    � ColumnDefinitions 5	   
   �� 5
      $	��.7* �6   6-   �� 5      $	��.3* �6   6-   �� 5      $
��auto �6   6.   .+�5   
   �� -   5         ��Name$ arrowbutton��5   R   $��3��5   &   $��40��63   $��40��6?   $��Bottom=�6K   $��Right=�5      $��30, 30q�61    K� ZIndex$ 1��6A   ��5      �� 5       �� 
TargetType" ��6"   .R�5      �  J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6/      	Direction$	 -90Q�6?      RenderingBias$ Quality=�6O   	   Opacity$	 .2Q�6g   
   ShadowDepth$
 1Q�6t   .+�5      A� 
���   �$��0��61   ���	#FF1519225      "  FontAwesome.WPF.ImageAwesome  5        Name$ hamza��69      Icon$ AngleUp=�6*      
Foreground
 �����$��20��6[   $��20��6f   6u   �� 5      $��Center=�6+   $��Center=�5   #   5       �� Triggers 5      5!      5%      �� 5&   
    �� Padding$ 15q�6   $	��400��6   $��0��6.   ._�5'         Menu.BasicColumn  -   5          Name$ chart��5'       62   5(      �� 5)   
   $��1��6   $��Center=�6$   $
��Left=�6?   ._�5*      � .+�5+         Menu.UserControl1  -   5          Name$ setter3��5+   0   $��5q�6%   6C     5,      -   5        $ setter2��5,   0      Menu.UserControl1   Initialized$ Setter2_Initialized��6A   $��5q�6%   6e   5-      50      51      52      