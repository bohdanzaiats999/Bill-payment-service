   M S B A M L   `   `   `  ����O  KBill payment service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Bill_payment_serviceBill_payment_service  5   	   %    Bill_payment_service.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Bill_payment_service     5   	     � Title$   ��5   	   $��363.23��6   $	��525��6"    � 
ResizeMode$ NoResize=�6.    � WindowStartupLocation$ CenterScreen=�6D   ��5	      �� 5
   
    �� ImageSource$ Resource/kosmos1.jpg��6   .��5      � .+�5   
   �� ��6   Z� .@�5      �� $��Авторизація��6   $��30��6+   .��5      � .+�5      � 
���   � K� ZIndex$ 1��6.   $��121,36,125,21q�6@    J� Opacity$	 0.7Q�6W   .+�5      �� -   5         ��Name$ textBoxAuthorizationLogin��5   "   $��16(�6E   $
��Left=�6S   $��27��6o   $	��166��6{   $��	56,63,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   �� 5      -   5         ��Name$ buttonAuthorizationLogin��5   !   $��
Логін��6C   $
��Left=�6S   $ 1Q�6n   $��
92,199,0,0q�6z   $	��Top=�6�   $��75��6�   	 J� RenderTransformOrigin$	 
0.467,0.95&�6�   G� 5      -   5        
 G�Name$&
  passwordBoxAuthorizationPassword��5   &   $��16(�6P   $
��Left=�6^   $��
56,126,0,0q�6y   $	��Top=�6�   $��27��6�   $	��166��6�   �� 5      -   5         ��Name$$ textBlockAuthorizationPassword��5   $   $
��Left=�6L   $��
56,110,0,0q�6g   $
��Wrap=�6{   $��Пароль��6�   $	��Top=�6�   ��5      �� 5   "    �� Color$ White��62    �� Opacity$	 0.8Q�6@   5      �� 5      -   5        $! textBlockAuthorizationLogin��5   $   $
��Left=�6J   $��	56,42,0,0q�6e   $
��Wrap=�6x   $��
Логін��6�   $	��Top=�6�   $��32��6�   ��5      �� 5   "   $ White��62   $	 0.8Q�6@   5      5      5       5!      �� 5"      $��Реєстрація��6   $��30��6*   $��
-2,-1,-2,1q�66   .��5#      � .+�5$      � 
���   �$ 1��6.   $��121,36,125,21q�6@   $	 0.7Q�6W   .+�5%      �� -   5        $ textBoxRegistrationLogin��5%   "   $
��Left=�6D   $��16(�6_   $��	56,63,0,0q�6m   $
 Wrap=�6�   $	��Top=�6�   $��27��6�   $	��166��6�   G� 5&      -   5        $%
 passwordBoxRegistrationPassword��5&   &   $
��Left=�6O   $��16(�6j   $��
56,126,0,0q�6x   $	��Top=�6�   $��27��6�   $	��166��6�   �� 5'      -   5        $$ buttonRegistrationRegistration��5'   !   $��Реєстрація��6I   $
��Left=�6^   $��
92,199,0,0q�6y   $	��Top=�6�   $��75��6�   6�   �� 5(      -	   5        $  textBlockRegistrationLogin��5(   $   $
��Left=�6H   $��	56,42,0,0q�6c   $
��Wrap=�6v   $��
Логін��6�   $	��Top=�6�   
�������6�   �� 5)      -
   5        $# textBlockRegistrationPassword��5)   $   $
��Left=�6K   $��
56,110,0,0q�6f   $
��Wrap=�6z   $��Пароль��6�   $	��Top=�6�   
�������6�   5*      5+      5,      5-      5.      5/      