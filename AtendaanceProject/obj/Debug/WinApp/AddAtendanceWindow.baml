   M S B A M L   `   `   `  ����L  HAtendaanceProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AtendaanceProject.WinAppAtendaanceProject.WinApp  5   	   1    +AtendaanceProject.WinApp.AddAtendanceWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:AtendaanceProject.WinApp     5   	     � Title$  AddAtendanceWindow��5   	   $	��450��6$   $	��800��61   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��5* �6   �� 5      .+�5   
   �� $��Добавление��6   $��24(�6%   $��5q�63   ���#8d99ae$��3��6S   �� 5   
    �� Orientation$ 
Horizontal=�6   $��2��6.   ���#8d99ae$��3��6P   .+�5      �� -   5         ��Name$ btnLeave��5      $��leave��6'   $��80��6O   $��30��6Z   $��10q�6f   �� 5      -   5        $ btnSave��5      $
��save��6&   $��80��6L   $��30��6W   $��10q�6c   5      �� 5   
   $��1��6   $��1��6%   .+�5      �� $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��студент��6   $��60��6*   �� 5      -   5         ��Name$ 	CBstudent��5      $��26��6.   5      �� 5       $ 
Horizontal=�6   $��Center=�62   .+�5!      �� $��предмет��6   $��60��6*   �� 5)      -   5        $ 	CBsubject��5)      $��26��6.   5*      �� 5+      $ 
Horizontal=�6   $��Center=�62   .+�5,      �� $��отметка��6   $��60��6*   �� 5-      -   5        $ CBatendance��5-      $��26��60   5.      (  "System.Windows.Controls.DatePicker  50      -   5        $��	datePanel��50      51      �� 53   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   .+�54      �� $��80��6   .+�55      �� $��студент��6   �� 56      $��предмет��6   �� 57      $��отметка��6   �� 58      $��дата��6   59      �� 5:      $��80��6   .+�5;      �� -   5         ��Name$ 
txtStudent��5;      $��26��6.   �� 5<      -   5        $ 
txtSubject��5<      $��26��6.   �� 5=      -	   5        $ txtAtendance��5=      $��26��60   �� 5>      -
   5        $ txtDate��5>      $��26��6+   5?      5@      5A      5B      