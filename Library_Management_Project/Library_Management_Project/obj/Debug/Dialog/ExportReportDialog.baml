   M S B A M L   `   `   `  ����U  QLibrary_Management_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Library_Management_Project.Dialog!Library_Management_Project.Dialog  5   	   :    4Library_Management_Project.Dialog.ExportReportDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Library_Management_Project.Dialog     5   	   a ]Telerik.Windows.Data, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.Navigation, Version=2020.2.513.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Xuất Báo Cáo��5
   	   $	��200��6   $	��520��6+   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � 	Resources 5   
    �� 
TargetType �� Property �� Value(  "Telerik.Windows.Controls.RadButton   RadButtonStyle �� BasedOn,  &Telerik.Windows.Controls.RadDatePicker0  *Telerik.Windows.Controls.RadDateTimePicker  RadCalendarStyle��%G  '��       '  u     7   '  ]    �� 5      " ��6   .�5      ��  � ��$ 5 0 5 0q�6+   �� 5       � ��$ Center=�66   5      �� 5      "  6   8   .�5      ��  � ��$ 5 10 5 5q�6+   �� 5       � ��$ 80��6*   �� 5       � ��$ 30��6+   �� 5       � ��$ 2q�64   �� 5        � �� �#25A0DA60   5!      �� 5"      "  6   .�5#      ��  � ��$ 5 0 0 0q�6+   �� 5$       � ��$	 150��6*   �� 5%       � ��$
 Left=�68   �� 5&       �@ CalendarStyle# �  62   5'      5(      .+�5*   
   �� $��Thông Tin Báo Cáo��6   $��Center=�6-   $��Center=�5+      $��24(�5,      $
��Bold"�6"   �� 5-   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5.      �� $��Lưu tại:��6   �� 5/      -   5        $��fileNameTxtBlock��5/   %   $	��350��6   6%     50      $��Duyệt��6    ��51       �� *BrowserCommand+52      �� 54   
   $��Thời gian:��6   $��2��6&   �� 55   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   .+�56      �� $
��Từ��6     57      	   DateTimeWatermarkContent$	 Ngày bắt đầu...��6$   
   SelectedValue
 58   $   �� *From+�� 59      $��Đến��6   $��40 0 5 0q�6#     5:      $	 Ngày kết thúc...��6$   
 5;   $   �� *To+5<      �� 5=   
   $��4��6   $ 
Horizontal=�6"   $��Right=�5>      .+�5?        $��Xuất báo cáo��6    ��5@       �� *AcceptCommand+  5A      $��Hủy��6     �� IsCancel . 6.   5B      5D      5E      