   M S B A M L   `   `   `  ����O  KBill payment service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Bill_payment_serviceBill_payment_service  5   	       Bill_payment_service.User   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Bill_payment_service     5   	     � Title$
  User��5   	   $��375.669��6   $��625.168��6'    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M   ��5	      �� 5
   
    �� ImageSource$ Resource/kosmos2 .jpg��6   .��5      � .+�5   
   �� ��6   Z� .@�5      �� $5��/Покласти гроші на рахунок��6   $��30��69   .��5      � .+�5      � 
���   � K� ZIndex$ 1��6.   $��121,36,125,21q�6@    J� Opacity$	 0.7Q�6W   .+�5      �� -   5         ��Name$! textBlocScoreBalanceBalance��5   $   $
��Left=�6I   $
��Wrap=�6d   $��30(�6x   $��	TextBlock��6�   $	��Top=�6�   $��	10,10,0,0q�6�   
�������6�   �� 5      -   5        $# textBlockScoreBalanceAddFunds��5   $   $
��Left=�6K   $��110,102,0,0q�6f   $
��Wrap=�6{   $2��,Введіть суму поповнення��6�   $	��Top=�6�   
�������6�   �� 5      -   5         ��Name$! textBoxScoreBalanceAddFunds��5   "   $
��Left=�6G   $��23��6b   $��110,126,0,0q�6n    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��139��6�   �� 5      -   5        	 ��Name$ 	 buttonScoreBalanceAddFunds��5   !   $��Поповнити��6E   $
��Left=�6Y   $	��Top=�6t   $��94��6�   $��126,191,0,0q�6�   $��37��6�   6�   �� 5      -   5        
 ��Name$!
 checkBoxScoreBalanceAutoPay��5   #   $��16(�6H   $9��3Вкл/Викл Автоматичну оплату��6V   $
��Left=�6|   $��
66,154,0,0q�6�   $	��Top=�6�   
�������
�������6   5      5      5      �� 5      $#��Перегляд послуг��6   $��30��6/   .��5      � .+�5      � 
���   �$ 1��6.   $��121,36,69,21q�6@   $	 0.7Q�6V   .+�5      �� -   5        $+ %textBlockWatchServiceCellphoneBillPay��5   $   $
��Left=�6S   $��
14,152,0,0q�6n   $
��Wrap=�6�   $-��'Рахунок моб. телефону��6�   $	��Top=�6�   
�������6�   �� 5       -   5        $' !textBlockWatchServiceUtilitiesPay��5    $   $
��Left=�6O   $��
14,123,0,0q�6j   $
��Wrap=�6~   $)��#Комунальні послуги��6�   $	��Top=�6�   
���   �
�������6�   �� 5!      -   5        $&  textBlockWatchServiceInternetPay��5!   $   $
��Left=�6N   $��	14,93,0,0q�6i   $
��Wrap=�6|   $%��Інтернет послуги��6�   $	��Top=�6�   
�������6�   �� 5"      -	   5        $#	 buttonWatchServiceInternetPay��5"   !   $��Оплатити��6H   $
��Left=�6[   $��
300,86,0,0q�6v   $	��Top=�6�   $��75��6�   6�   �� 5#      -
   5        $$	 buttonWatchServiceUtilitiesPay��5#   !   $��Оплатити��6I   $
��Left=�6\   $��300,116,0,0q�6w   $	��Top=�6�   $��75��6�   6�   �� 5$      -   5        $)	 #buttonWatchServiceСellphoneBillPay��5$   !   $��Оплатити��6M   $
��Left=�6`   $��300,148,0,0q�6{   $	��Top=�6�   $��75��6�   6�   5&      5(      5)      5*      5-      5.      