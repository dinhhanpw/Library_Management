   M S B A M L   `   `   `  ����U  QLibrary_Management_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Library_Management_Project.ViewLibrary_Management_Project.View  5      8    2Library_Management_Project.View.BookManagementView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Library_Management_Project.View     5      a ]Telerik.Windows.Data, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.Navigation, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 5      .��5
      �   � 	Resources  5   
   '  !Telerik.Windows.Controls.GroupBox �� 
TargetType �� Property �� Value��%Y  '        �� 5      "  6   .�5      ��  � ��$ 10q�6+   �� 5       � ��$ 10q�6,   �� 5       � ��$ 0 1 0 1q�64   �� 5       � �� �#25A0DA60   �� 5       � �� 5      �� 5      .R�5      �� $��12(�69   $
��Bold"�6G   
���������6(   �� 6Y   5      5      5      5       � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $��* �6   .+�5%   
     $��Thông Tin Sách��5&      $��10,10,10,10q�6%   .��5'      �  � DataContext 6   �� *Holder+  5(      2  ,Telerik.Windows.Controls.RadWatermarkTextBox   RadWatermarkTextBoxStyle �� BasedOn4  .Telerik.Windows.Controls.RadMaskedNumericInput  RadMaskedNumericInputStyle5  /Telerik.Windows.Controls.RadMaskedCurrencyInput  RadMaskedCurrencyInputStyle,  &Telerik.Windows.Controls.RadDatePicker0  *Telerik.Windows.Controls.RadDateTimePicker  RadCalendarStyle*  $Telerik.Windows.Controls.RadComboBox  RadComboBoxStyle��%U  '��       '  v     7   '  �     7  '  �    7  '  }    '  F    7  �� 5)      " ��6   .�5*      ��  � ��$ 5 15 0 0q�63   �� 5+       � ��$ Center=�6>   5-      �� 5.      "  6   8   .�5/      ��  � ��$ 5 15 5 0q�63   �� 50       � ��$ Center=�6>   51      �� 52      "  6   8   .�53      ��  � ��$ 5 15 5 0q�63   �� 54       � ��$ Center=�6>   �� 55       � ��$	 150��62   �� 56       � ��$
 Left=�6G   57      �� 58      "  6   8   .�59      ��  � ��$ 5 15 5 0q�63   �� 5:       � ��$ Center=�6>   �� 5;       � ��$	 150��62   �� 5<       � ��$
 Left=�6G   5=      �� 5>      "  6   .�5?      ��  � ��$ 5 15 0 0q�63   �� 5@       � ��$	 150��62   �� 5A       � ��$
 Left=�6@   �� 5B       �@ CalendarStyle# �  6:   5C      �� 5E      "  6   8   .�5F      ��  � ��$ 5 15 0 0q�63   �� 5G       � ��$	 150��62   �� 5H       � ��$	 Top=�6>   �� 5I       � ��$
 Left=�6@   5J      5L       5M      �� 5N      $
��Auto �6'   �� 5O      $��* �6'   �� 5P      $
��Auto �6'   �� 5Q      $��* �6'   �� 5R      $
��Auto �6'   �� 5S      $
��Auto �6'    5U      �� 5V      $
��Auto �6$   �� 5W      $
��Auto �6$   �� 5X      $
��Auto �6$   .+�5[      �� $��
Tên sách��6     5\      -   5          Name$ displayNameTextBox��5\   .   $��1��6J   $��0��6Z   	   WatermarkContent$	 Tên sách...��5]        ErrorInfoTemplate
 =� ErrorTemplate#
 [ 5^      ��5_      �� *Ten+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=�" �� ValidatesOnNotifyDataErrors . �� 5c      $��2��6   $��Loại sách��6,     5d      $��3��6&   $��Light"�66    �� SelectedValuePath$ Id��5i   &    �� DisplayMemberPath$	 Ten��5k   &   ��5e   &   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" >� �� Path$ DataContext.BookTypes� �� SelectedValue 5j   &   �� *IdLoai+$ TwoWay=�$ PropertyChanged=�5k   &   �� 5m      $��4��6   $��Ngày nhập��6,     5n      $��5��6(   #
 [ 5o   (      DateTimeWatermarkContent$ Ngày nhập...��5q   (      SelectedValue 5p   (   �� *
NgayNhap+5q   (   �� 5s      $��1��6   $��
Tác giả��6)     5t      $��1��6.   $��1��6>   #
 [ 5u   .   $	 Tác giả...��5w   .   ��5v   .   �� *TacGia+5w   .   �� 5y      $��1��6   $��2��6)   $��Nhà xuất bản��69     5z      $��3��6.   $��1��6>   #
 [ 5{   .   $	 Nhà xuất bản...��5}   .   ��5|   .   �� *NhaXB+5}   .   �� 5      $��1��6   $��4��6)   $��Năm xuất bản��69     5�      $��5��60   $��1��6@   1  +Telerik.Windows.Controls.RadMaskedInputBase   Mask$
 #4.0��5�   0      TextMode$ 	PlainText=�6<      EmptyContent$ Năm xuất bản...��5�   0   #
 [ 5�   )      Value 5�   0   �� *NamXB+5�   )   �� 5�      $��2��6   $��Số lượng��6)     5�      $��1��61   $��2��6A   $ Số lượng...��5�      $
 #6.0��65   $ 	PlainText=�5�      #
 [ 5�       5�      �� *	SoLuong+$ TwoWay=�$ 	LostFocus=� . �� 5�      $��2��6   $��2��6,   $��
Giá sách��69     5�      $��3��61   $��2��6A   $
 #8.0��5�   1   $ 	PlainText=�6=   $ Giá sách...��5�   1      Value 5�   1   �� *Gia+$ TwoWay=�$ 	LostFocus=� . 5�   1   5�      5�      �� 5�   
   $��1��6   $��Center=�6"    �� Orientation$ 
Horizontal=�6=   $��Right=�6V     5�      (	  "Telerik.Windows.Controls.RadButton  RadButtonStyle��%  '	        7  �� 5�      " 	 6   8   .�5�      ��  � ��$ 5 5 5 5q�6/   �� 5�       � ��$	 120��6.   �� 5�       � ��$ 35��6/   �� 5�       � ��$ 12(�61   �� 5�       � ��$ 2q�68   �� 5�       � �� �#25A0DA64   5�      5�      .+�5�      	  ��6!   �� *
AddCommand+��5�   %   �� *Holder+.��5�      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�5�   !   .+�5�      '
  !Telerik.Windows.Controls.RadGlyph
   
  Glyph$	 ��6'    
  FontSize$ 25(�68   �� 5�      $��Thêm��6    $��10 0 0 0q�6,   $��Center=�6>   5�      5�      	  5�      ��6!   �� *EditCommand+��5�   %   ��  �� ElementName$ radGridView��$ SelectedItem�.��5�      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�5�   !   .+�5�      
  $	 ��6'   $ 25(�68   �� 5�      $��Sửa��6    $��10 0 0 0q�6+   $��Center=�6=   5�      5�      	  5�      ��6    �� *DeleteCommand+.��5�      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�5�   !   .+�5�      
  $	 ��6'   $ 25(�68   �� 5�      $
��Xóa��6    $��10 0 0 0q�6+   $��Center=�6=   5�      5�      	  5�      ��6    �� *ExportCommand+.��5�      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�5�   !   .+�5�      
  $	 ��6'   $ 25(�68   �� 5�      $��Xuất Báo Cáo��6    $��10 0 0 0q�64   $��Center=�6F   5�      5�      5�      *  $Telerik.Windows.Controls.RadGridView  5�   
   $��5,5,5,5q�6   $��2��6/   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   ShowSearchPanel .     NewRowPosition$  Bottom=�5�      !   CanUserDeleteRows! . "   CanUserSearch" . #   AutoGenerateColumns# .  8  2Telerik.Windows.Controls.GridView.BaseItemsControl$   GroupRenderMode$
$ Flat=�5�      %   CanUserFreezeColumns% .  &   CanUserSortColumns& . *  $Telerik.Windows.Controls.DataControl'   ItemsSource' 5�      �� *Books+(   SelectedItem( 5�      �� *SelectedBook+$ TwoWay=�$ PropertyChanged=�5  /Telerik.Windows.Controls.EventToCommandBehavior)   EventBindings) 5�      +  %Telerik.Windows.Controls.EventBinding  5�      *   	EventName$* RowEditEnded��6'   +   PassEventArgsToCommand+ . ,   Command, 5�   '   �� *EditOnTableDataCommand+-   Columns- 5�      3  -Telerik.Windows.Controls.GridViewSelectColumn  5�      1  +Telerik.Windows.Controls.GridViewDataColumn  5�      6  0Telerik.Windows.Controls.GridViewBoundColumnBase.   Header$. 
Tên sách��6-   -  'Telerik.Windows.Controls.GridViewColumn/   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$/ * 6?   0   DataMemberBinding0 5�   -   �� *Ten+$ PropertyChanged=�5  /Telerik.Windows.Controls.GridViewComboBoxColumn  5�      $. Loại Sách��61   1   DisplayMemberPath$	1 Ten��5�   -   2   SelectedValueMemberPath$2 Id��5�   -   3   ItemsSource3 5�   D   �� *	BookTypes+0 5�   -   �� *IdLoai+$ TwoWay=�$ PropertyChanged=�  5�      $. Ngày Nhập��6-   4   DataFormatString$4 
MM-dd-yyyy��5�   z   0 6-   �� *
NgayNhap+$ PropertyChanged=�6z     5�      $. 
Tác Giả��6-   0 5�   -   �� *TacGia+$ PropertyChanged=�  5�      $. Nhà Xuất Bản��6-   0 5�   -   �� *NhaXB+$ PropertyChanged=�  5�      $. Năm Xuất Bản��6-   0 5�   -   �� *NamXB+$ PropertyChanged=�  5�      $. Số Lượng��6-   0 5�   -   �� *	SoLuong+$ PropertyChanged=�  5�      $. 
Giá Sách��6-   0 5�   -   �� *Gia+$ PropertyChanged=�5      5     5     