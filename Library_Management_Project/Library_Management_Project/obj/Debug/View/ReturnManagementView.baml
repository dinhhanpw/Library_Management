   M S B A M L   `   `   `  ����U  QLibrary_Management_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Library_Management_Project.ViewLibrary_Management_Project.View  5      :    4Library_Management_Project.View.ReturnManagementView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Library_Management_Project.View     5      a ]Telerik.Windows.Data, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.Navigation, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 5      .��5
      �   � 	Resources  5   
   '  !Telerik.Windows.Controls.GroupBox �� 
TargetType �� Property �� Value��%=  '        �� 5      "  6   .�5      ��  � ��$ 
10 10 10 0q�6+   �� 5       � ��$ 0 1 0 0q�64   �� 5       � �� �#25A0DA60   �� 5       � �� 5      �� 5      .R�5      �� $��12(�69   $
��Bold"�6G   
���������6(   �� 6Y   5      5      5      5       � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5       $��* �6   �� 5!      $
��Auto �6   �� 5"      $��* �6   .+�5$   
     $��Thông Tin Trả Sách��5%      .��5&      �   5'         TextBlockStyle,  &Telerik.Windows.Controls.RadDatePicker0  *Telerik.Windows.Controls.RadDateTimePicker  RadCalendarStyle5  /Telerik.Windows.Controls.RadMultiColumnComboBox  MultiColumnComboBoxStyle  RadMultiColumnComboBoxStyle �� BasedOn��%�  &	        '  v     &	 ?    7  �� 5)      " ��6   .�5*      ��  � ��$ 5 15 0 0q�63   �� 5+       � ��$ Center=�6>   5-      �� 5/      "  6   .�50      ��  � ��$ 5 15 0 0q�63   �� 51       � ��$	 150��62   �� 52       � ��$
 Left=�6@   �� 53       �@ CalendarStyle# �  6:   54      �� 57      "  6   8   .�59      ��  � ��$ 5 20 0 0q�63   �� 5:      ( �@  CloseDropDownAfterSelectionInput . 6M   �� 5;       �@ AutoCompleteMode$ SuggestAppend=�6=   �� 5<       �@ DeferTextChange .  6<   �� 5=       �@ 
SearchMode$ MatchAnyTerm=�67   �� 5>       �@ 	MatchCase .  66   5?      5A       5B      �� 5C      $
��Auto �6'   �� 5D      $��* �6'   �� 5E      $
��Auto �6'   �� 5F      $
��Auto �6'    5I      �� 5J      $
��Auto �6$   �� 5K      $
��Auto �6$   �� 5L      $��* �6$   .+�5O      �� $��Họ và tên��6   #��[  6-   2  ,Telerik.Windows.Controls.RadWatermarkTextBox  5P      $��0��6.   $��1��6;   $��5 15 0 0q�6K      WatermarkContent$ Họ và tên...��5T   .    � DataContext 5Q   .   �� 	 �� ElementName$	 receiptInfoList��
 �� Path$
 SelectedItem���5R   .   �� *
DocGia.Ten+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�5T   .   �� 5X      $��1��6   $��2��6)   $$��Danh sách đang sách mượn��6=   #��[  6]   *  $Telerik.Windows.Controls.RadGridView  5[      -   5        $��bookList��5\   &   $��0 10 0 0q�5[   &   $��2��68   $��4��6E   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   RowIndicatorVisibility$ 	Collapsed=�5]         ShowSearchPanel .     CanUserSearch .    SelectionMode$ Multiple=�5`         AutoGenerateColumns .  8  2Telerik.Windows.Controls.GridView.BaseItemsControl   GroupRenderMode$
 Flat=�5c         CanUserFreezeColumns .     CanUserSortColumns . *	  $Telerik.Windows.Controls.DataControl 	  ItemsSource 5a      �� *BorrowReceiptInfos+5
  /Telerik.Windows.Controls.EventToCommandBehavior 
  EventBindings 5g      +  %Telerik.Windows.Controls.EventBinding  5h         	EventName$ RowEditEnded��6/      PassEventArgsToCommand .    Command 5j   '   �� *BorrowReceiptInfos+   Columns 5m      3  -Telerik.Windows.Controls.GridViewSelectColumn  5n      1  +Telerik.Windows.Controls.GridViewDataColumn  5p      6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ 
Tên Sách��65      DataMemberBinding 5q   -   �� *
Sach.Ten+  5s      $ Loại Sách��65    5t   -   �� *Sach.LoaiSach.Ten+  5v      $ 
Tác Giả��65    5w   -   �� *Sach.TacGia+  5y      $ Nhà Xuất Bản��65   -  'Telerik.Windows.Controls.GridViewColumn   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ * 6K    5z   -   �� *
Sach.NhaXB+  5|      $ Năm Xuất Bản��65    5}   -   �� *
Sach.NamXB+  5      $ Mất Sách��65    5�   -   �� *BiMat+  5�      $ Thành Tiền��65    5�   -   �� *
TienPhat+5�      �� 5�      $��2��6   $��Ngày trả sách��6,   $��	10 15 0 0q�6A   #��[  5�        5�      $��3��6(     ErrorInfoTemplate =� ErrorTemplate# [ 5�   (      DateTimeWatermarkContent$ Ngày trả...��5�   (       SelectedValue  5�   (   �� *ReturningDate+$ TwoWay=�$ PropertyChanged=�5�   (   5�      5�      �� 5�   
   $��1��6   $��Center=�6"   ! �� Orientation$! 
Horizontal=�6=   $��Right=�6V     5�      (  "Telerik.Windows.Controls.RadButton  RadButtonStyle��%  '        7  �� 5�      "  6   8   .�5�      ��  � ��$ 5 5 5 5q�6/   �� 5�       � ��$	 120��6.   �� 5�       � ��$ 35��6/   �� 5�       � ��$ 12(�61   �� 5�       � ��$ 2q�68   �� 5�       � �� �#25A0DA64   5�      5�      .+�5�        ��6    �� *ReturnCommand+��5�       �� $	 bookList��$
 SelectedItems�.��5�      �� $! 
Horizontal=�6   $��Center=�66   $��Center=�5�   !   .+�5�      '  !Telerik.Windows.Controls.RadGlyph  "   Glyph$	" ��6'   #   FontSize$# 25(�68   �� 5�      $
��Lưu��6    $��10 0 0 0q�6+   $��Center=�6=   5�      5�      5�        5�   
   -   5        $��receiptInfoList��5�      $��5,5,5,5q�5�      $��2��6/   $   
IsReadOnly$ . $ 	Collapsed=�5�       .   .  .  $
 Flat=�5�       .   .  5�      �� *BorrowReceipts+% 	  SelectedItem% 5�      �� *SelectedReceipt+$ OneWayToSource=�$ PropertyChanged=� 5�        5�      $ RowEditEnded��6'    . 5�   '    5�        5�        5�      $ 	Họ Tên��6-   $ * 6=    5�   -   �� *
DocGia.Ten+$ PropertyChanged=�  5�      $ Loại��6-    5�   -   �� *DocGia.Loai.Ten+$ PropertyChanged=�  5�      $ 
Ngày Sinh��6-   &   DataFormatString$& 
MM-dd-yyyy��5�   �    6-   �� *DocGia.NgaySinh+$ PropertyChanged=�6�     5�      $ Địa Chỉ��6-    5�   -   �� *DocGia.DiaChi+$ PropertyChanged=�  5�      $ Email��6-    5�   -   �� *DocGia.Email+$ PropertyChanged=�  5�      $ Ngày Mượn��6-   $ * 6@   $& 
MM-dd-yyyy��5�   z    6-   �� *
NgayMuon+$ PropertyChanged=�6z   5�      5�      5�      