   M S B A M L   `   `   `  ����D  @Cursework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Cursework	Cursework  5   	   %clr-namespace:Cursework	Cursework  5   	       Cursework.MainWindow   5   	   vmclr-namespace:Cursework  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Cursework     5   	     � Title$  PASSWORD GENERATOR��5	   	   $��375.501��6$   $��590.353��65    � DataContext 5        Cursework.PasswordVM  5   
   .��5      �� $��0,0,0,-1q�6   .+�5   
   �� -   5         ��Name$ label1��5      $"��Enter the length of password��6    $��
0,5,329,10q�6G   �� 5   
   -   5         ��Name$ textBox��5      $��24��6$    �� TextWrapping$
 Wrap=�60   $��10,0,0,5q�6D    J� RenderTransformOrigin$ 0.884,0.417&�6V   $
��Left=�6z   $��81��6�   ��6�   �� *Password_OBJ.Length+�� 5   
   $	��272��6   .@�5      �� $��Generate Passwords��6   $��	10,0,-7,0q�62   .��5      �� $��0,3,2,-1q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� -   5         ��Name$ Symbols��5   #   $��Symbols��64   $��24��6F   $��Right=�6�   $��	10,10,0,0q�6�   $��81��6�    d� 	IsChecked 6R   �� *Password_OBJ.IsCheckedSymbol+6�   �� 5      -   5        $ Digits��5   #   $��Digits��63   $��24��6D   $��Center=�6�   $��81��6�   $��	50,10,0,0q�6�    6P   �� *Password_OBJ.IsCheckedNumbers+6�   �� 5      -   5        $ LowerLetters��5   #   $��Lower Letters��69   $
��Left=�6�   $��24��6�   $��95��6�   $��	90,10,0,0q�6�    6Q   �� *!Password_OBJ.IsCheckedLowerCase+6�   �� 5      -   5        $ UpperLetters��5   #   $��Upper Letters��69   $
��Left=�6�   $��24��6�   $��97��6�   $��	60,10,0,0q�6�    6Q   �� *!Password_OBJ.IsCheckedUpperCase+6�   5      �� 5      -   5        $ excludeinformation��5      $
��auto��68   $��Center=�6F   $*��$Symbols to be excluded from password��6j   $��10,18,329,0q�6�   �� 5      -   5        $ exclude��5      $
��auto��6/   $��Center=�6=   $
��auto��6�   $��250,-20,148,0q�6�   ��6a   �� *Password_OBJ.Exclude+6�   �� 5      -	   5        $ password��5      $
��auto��60   $��Center=�6>   $
��auto��6b   	 �� 
IsReadOnly	 . $��112,20,112,0q�6�   ��6�   �� *Password_OBJ.Outputtring+6�   �� 5      -
   5        
 ��Name$
 GeneretePassword��5      $��Generate��67   $��
95,25,95,5q�6y   $��25��6�   ��6J   �� *GenereteNewPasswordCommand+6�   5      5       �� 5!      $��Generete Simple Passwords��6   $��
12,0,-11,0q�69   .��5"      �� .+�5#      �� -   5        $ label4��5#      $
��auto��6.   	 . $��Center=�6N   $��184,30,190,0q�6�   ��6r   �� *" Password_OBJ.OutputtringInSimple+6�   �� 5$      -   5        $
 button1��5$      $��Generate��6.   $��166,20,178,0q�6s   ��6A   �� *GenereteSimplePasswordCommand+6s   5%      5&      �� 5'      $��Validate Password��6   $��
12,0,-27,0q�61   .��5(      �� .+�5)      �� $ 
Horizontal=�6!   .+�5*      �� -   5        $ checkBox1InValidation��5*   #   $��Symbols��6�   $��24��6�   $��Right=�6�   $��	10,10,0,0q�6�   $��81��6�    6B   �� **(Password_OBJ.IsCheckedSymbolInValidation+6�   �� 5+      -   5        $ checkBoxInValidation��5+   #   $��Digits��6�   $��24��6�   $��Center=�6�   $��81��6�   $��	50,10,0,0q�6�    6A   �� *+)Password_OBJ.IsCheckedNumbersInValidation+6�   �� 5,      -   5        $ checkBox2InValidation��5,   #   $��Lower Letters��6�   $
��Left=�6�   $��24��6�   $��95��6�   $��	90,10,0,0q�6�    6B   �� *-+Password_OBJ.IsCheckedLowerCaseInValidation+6�   �� 5-      -   5        $ checkBox3InValidation��5-   #   $��Upper Letters��6�   $
��Left=�6�   $��24��6�   $��97��6�   $��	60,10,0,0q�6�    6B   �� *-+Password_OBJ.IsCheckedUpperCaseInValidation+6�   5.      �� 5/      -   5        $ textBox2��5/      $��23��60   $
 Wrap=�6<   $��112,10,148,0q�6y   ��6P   �� *Password_OBJ.Validation+6y   �� 50      -   5        $
 button2��50      $��Validate��6[   $��99,15,128,0q�6n   ��6.   �� *ValidatePasswordCommand+6n   �� 51      -   5        $ label6��51      $
��auto��6,   $��Center=�6:   $��126,20,105,0q�6�   ��6^   �� *Password_OBJ.ValidationOutput+6�   52      53      54      55      56      