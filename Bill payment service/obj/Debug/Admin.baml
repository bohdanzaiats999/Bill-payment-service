   M S B A M L   `   `   `  ����O  KBill payment service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Bill_payment_serviceBill_payment_service  5   	        Bill_payment_service.Admin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Bill_payment_service     5   	     � Title$  Admin��5   	   $��433.669��6   $��722.168��6(    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N   ��5	      �� 5
   
    �� ImageSource$ Resource/kosmos5.jpg��6   .��5      � .+�5   
   �� ��6   Z� .@�5      �� $4��.Встановлення суми оплати��6   $��30��68   .��5      � .+�5      � 
���   � K� ZIndex$ 1��6.   $��41,72,379,72q�6@    J� Opacity$	 0.7Q�6V   .+�5      �� -   5         ��Name$ textBlockSettingTheFeesId��5   $   $
��Left=�6G   $
��Wrap=�6b   $��ID користувача��6v   $	��Top=�6�   $��
116,10,0,0q�6�   
�������6�   �� 5      -   5         ��Name$ textBoxSettingTheFeesId��5   "   $
��Left=�6C   $��23��6^   $��	91,31,0,0q�6j    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $	��120��6�   �� 5      -   5        $% textBlockSettingTheFeesInternet��5   $   $
��Left=�6M   $
��Wrap=�6h   $.��(Інтернет послуги / грн��6|   $	��Top=�6�   $��	20,61,0,0q�6�   
�������6�   �� 5      -   5        $# textBoxSettingTheFeesInternet��5   "   $
��Left=�6I   $��23��6d   $
 Wrap=�6p   $	��Top=�6�   $	��138��6�   $��	20,82,0,0q�6�   �� 5      -   5        $&  textBlockSettingTheFeesUtilities��5   $   $
��Left=�6N   $
��Wrap=�6i   $2��,Комунальні послуги / грн��6}   $	��Top=�6�   $��
20,113,0,0q�6�   
�������6�   �� 5      -   5        $$ textBoxSettingTheFeesUtilities��5   "   $
��Left=�6J   $��23��6e   $
 Wrap=�6q   $	��Top=�6�   $	��138��6�   $��
20,134,0,0q�6�   �� 5      -   5        $+ %textBlockSettingTheFeesСellphoneBill��5   $   $
��Left=�6R   $
��Wrap=�6m   $0��*Мобільний рахунок / грн��6�   $	��Top=�6�   $��
20,169,0,0q�6�   
�������6�   �� 5      -   5        $( "textBoxSettingTheFeesCellphoneBill��5   "   $
��Left=�6N   $��23��6i   $
 Wrap=�6u   $	��Top=�6�   $	��138��6�   $��
20,190,0,0q�6�   �� 5      -	   5        	 ��Name$+	 %buttonSettingTheFeesAddChangeInternet��5   !   $��Добавити��6P   $
��Left=�6c   $	��Top=�6~   $��75��6�   $��
190,82,0,0q�6�   6�   �� 5      -
   5        $!	 buttonSettingTheFeesRefresh��5   !   $��Обновити��6F   $
��Left=�6Y   $��490,342,0,0q�6t   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $,	 &buttonSettingTheFeesAddChangeUtilities��5   !   $��Добавити��6Q   $
��Left=�6d   $	��Top=�6   $��75��6�   
 J� RenderTransformOrigin$
 	0.573,0.8&�6�   $��190,134,0,0q�6�   6�   �� 5      -   5        $0	 *buttonSettingTheFeesAddChangeCellphoneBill��5   !   $��Добавити��6U   $
��Left=�6h   $	��Top=�6�   $��75��6�   $��190,190,0,0q�6�   6�   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGridSettingTheFees��5      $
��Left=�6?   $	��Top=�6Z   $��
368,10,0,0q�6r   $	��285��6�   $	��315��6�   ���	#FFB2B2B26�   5      5       �� 5!      $F��@Додавання/Блокування користувачів��6   $��30��6A   .��5"      � .+�5#      � 
���   �$ 1��6.   $��65,29,355,115q�6@   $	 0.7Q�6W   .+�5%      �� -   5        $&  textBlockAddAndBlockBlockUnblock��5%   $   $
��Left=�6N   $
��Wrap=�6i   $"��ID / Блок/Розблок��6}   $	��Top=�6�   $��	85,55,0,0q�6�   
�������6�   �� 5&      -   5        $$ textBoxAddAndBlockBlockUnblock��5&   "   $
��Left=�6J   $��23��6e   $
 Wrap=�6q   $	��Top=�6�   $	��120��6�   $��	74,76,0,0q�6�   �� 5'      -   5        $#	 buttonAddAndBlockBlockUnblock��5'   !   $!��Змінити статус��6H   $
��Left=�6a   $	��Top=�6|   $��94��6�   $��
84,110,0,0q�6�   6�   5(        5)      -   5        $ dataGridAddAndBlock��5)      $��375,0,10,71q�6<      AutoGenerateColumns . ���	#FFB2B2B26l   5*      5+      5,      5-      5.      