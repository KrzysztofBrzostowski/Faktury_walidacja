   M S B A M L   `   `   `  ����B  >Faktury, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FakturyFaktury  5   	       Faktury.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   'localclr-namespace:Faktury     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � Language$ pl-PL�65    � 	Resources 5         RowStyle �� 
TargetType)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value �� Property �� Value	 �� RelativeSource
 �� Path��%E  &	        �� 5   
   "  6!    5      P� 5	       �@=�HasError . . �5
      ��  � ��$ 3q�68   �� 5       � ��
 �  ��64   �� 5       � ��
 �����63   �� 5       �@�ToolTip 5      �� 	 �� *Self+$)
 #(Validation.Errors)[0].ErrorContent�5      5      5      .��5      � .+�5   
   �� -   5        $��
textBlock1��5   N   $��23��6   $
��Left=�6    $��	33,21,0,0q�6;   $��Data wystawienia:��6`   $	��Top=�6y   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dtpDataWystawienia��5   |   $��25��6A   $
��Left=�6M   $��
161,17,0,0q�6h   $	��Top=�6�   $	��115��6�      SelectedDate 6   �� $
 DataSprzedazy�6�   �� 5   
   -   5        $��
textBlock2��5   N   $��23��6   $
��Left=�6    $��	33,51,0,0q�6;   $��Klient:��6`   $	��Top=�6o   �� 5   
   -   5        $��	txtKlient��5   P   $��23��6/   $��161,48,12,0q�6;   $	��Top=�6a   ��6   �� $
 Klient�6a   �� 5   
   -   5        $��
textBlock3��5   N   $��23��6   $
��Left=�6    $��	33,80,0,0q�6;   $!��Łączna wartość faktury:��6`   $	��Top=�6   �� 5   
   -   5        $��txtWartoscFaktury��5   {   $��23��6Z   $��161,77,12,0q�6f   $	��Top=�6�   ��6   �� $
 WartoscFaktury� �� Mode$ OneWay=� �� StringFormat$ {0:C}��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
grdPozycje��5   �      RowStyle# [  6      AutoGenerateColumns .  $��32,109,12,41q�6�   ��6T   �� $
 PozycjeFaktury�   RowValidationRules 5        Faktury.RowValidationRule  5       ,  &System.Windows.Controls.ValidationRule   ValidationStep$ UpdatedValue=�6*      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Produkt��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $
 Produkt� �� ValidatesOnDataErrors .   5%      $ Ilosc��6%    69   �� $
 Ilosc�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� .   5&      $
 Cena��6%    69   �� $

 Cena�$ TwoWay=�$ PropertyChanged=� .   5'      $ Wartosc��6%    69   �� $
 Wartosc�$ OneWay=�$ {0:C}��5)      �� 5*   
   -   5        $��btDodaj��5*   [   $��Dodaj��6   $��23��6!   $
��Left=�6-   $��	32,0,0,12q�6H   $��Bottom=�6j   $��75��6�   6�   �� 5+   
   -	   5        $��btZmien��5+   \   $��Zmień��6   $��23��6!   $
��Left=�6-   $��
113,0,0,12q�6H   $��Bottom=�6k   $��75��6�   6�   �� 5,   
   -
   5        $��btUsun��5,   [   $��Usuń��6   $��23��6    $
��Left=�6,   $��
194,0,0,12q�6G   $��Bottom=�6i   $��75��6�   �� 5-   
   -   5        $��btTest��5-   \   $
��Test��6   $��23��6    $
��Left=�6,   $��416,276,0,0q�6G   $	��Top=�6j   $��75��6�   6�   5.      5/      