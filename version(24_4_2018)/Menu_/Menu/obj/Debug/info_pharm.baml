   M S B A M L   `   `   `  ����  Menu    Menu.info_pharm   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ 
MainWindow��5   	   $
��535 ��6   $	��930��6*    � WindowStyle$
 None=�66    � 
ResizeMode$ NoResize=�6I    � WindowStartupLocation$ CenterScreen=�6_   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6   ���	#FF151922.+�5      �� $��
Pharm Plus��6   $	��Top=�6)   $��	30,77,0,0q�6A   ���	#FF2980B9$��Sitka Display)�6�   $��65(�6�   $
��Left=�6�   $	��306��6�   $��76��6�   ��6T   Z� 6�   �� 5      $��	Bienvenue��6   $	��Top=�6(   $��
30,191,0,0q�6@   
�������$��Sitka Display)�6}   $��48(�6�   $
��Left=�6�   $	��306��6�   $��61��6�   ��6T   Z� 6�   �� 5      $
��Left=�6   $��67��63   $��
30,291,0,0q�6?   $	��Top=�6S   $	��386��6k   
�������$��Sitka Display)�6�   $��20(�6�   $
��Wrap=�6�   ��6w   Z� YWEntrez les informations de votre pharmacie pour que vous puissiez connecter au réseau!5      5       � 5!   
   $��1��6   ���	#FF2980B9.+�5"      �� $	��400��6   $��40,10q�6&   .+�5#      � $	��400��6    � RowDefinitions 5$      �� 5&      $��* �6(   �� 5'      $��* �6(   �� 5(      $��* �6(   �� 5)      $��* �6(   �� 5*      $��* �6(   �� 5+      $��* �6(   .+�5/      � $��0��6   .+�51      �� -   5         ��Name$ 	pharmacie��51   "   $	��240��65   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Nom de pharmacie��52       % !MaterialDesignFloatingHintTextBox#��[ 53      $��Sitka Display)�6>   $��18(�6Y   
�������$��0,0,0,2q�6z   $��	0,10,15,0q�6�   ���	#FF1519226�   '  !MaterialDesignThemes.Wpf.PackIcon  54      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]
   Kind$
 Pharmacy=�62   $��29��6C   $��10,35,330,0q�6O   $	��Top=�6d   $��Stretch=�6|   $��29��6�   ���	#FF1519226�   57      � 59      $��1��6   .+�5:      �� -   5        $ adress��5:   "   $	��240��62   $	 	L'adresse��5;      #��[ 5<      $��Sitka Display)�6>   $��18(�6Y   
�������$��0,0,0,2q�6z   $��	0,10,15,0q�6�   ���	#FF1519226�     5=      $

 Home=�62   $��29��6?   $��10,35,330,0q�6K   $��Stretch=�6`   $��Stretch=�6|   $��29��6�   ���	#FF1519226�   5?      � 5A      $��2��6   .+�5B      �� -   5        $ 	telephone��5B   "   $	��240��65   $	 Numero de telephone��5C      #��[ 5D      $��Sitka Display)�6>   $��18(�6Y   
�������$��0,0,0,2q�6z   $��	0,10,15,0q�6�   ���	#FF1519226�     5E      $
 Phone=�62   $��29��6@   $��10,35,330,0q�6L   $��Stretch=�6a   $��Stretch=�6}   $��29��6�   ���	#FF1519226�   5H      � 5I      $��3��6   .+�5K      �� -   5        $	 fax��5K   "   $	��240��6/   $	 Numero de FAX��5L      #��[ 5M      $��Sitka Display)�6>   $��18(�6Y   
�������$��0,0,0,2q�6z   $��	0,10,15,0q�6�   ���	#FF1519226�     5N      $	
 Fax=�62   $��29��6>   $��10,35,330,0q�6J   $��Stretch=�6_   $��Stretch=�6{   $��29��6�   ���	#FF1519226�   5O      � 5P      $��4��6   .+�5R      �� -   5        $ IP��5R   "   $	��240��6.   $	 Adresse ip de serveur��5S      #��[ 5T      $��Sitka Display)�6>   $��18(�6Y   
�������$��0,0,0,2q�6z   $��	0,10,15,0q�6�   ���	#FF1519226�     5U      $
 CodeTags=�62   $��29��6C   $��10,35,330,0q�6O   $��Stretch=�6d   $��Stretch=�6�   $��29��6�   ���	#FF1519226�   5V      � 5W      $��5��6   .+�5X      �� -   5         ��Name$ Check��5X   !     MaterialDesignFlatButton#��[ 5Y      $��138,22,101,16q�5Z      ���	#FFEEEEF2���	#FF2980B9$��Valider��6L   $
��10,4q�6^   6m   5\      5]      5^      5a      5b      5c      