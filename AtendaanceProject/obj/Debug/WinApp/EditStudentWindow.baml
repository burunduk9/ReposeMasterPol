   M S B A M L   `   `   `  ����L  HAtendaanceProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AtendaanceProject.WinAppAtendaanceProject.WinApp  5   	   0    *AtendaanceProject.WinApp.EditStudentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:AtendaanceProject.WinApp     5   	     � Title$  EditStudentWindow��5   	   $	��450��6#   $	��800��60   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��5* �6   �� 5      .+�5   
   �� $"��Редактирование��6   $��24(�6)   $��5q�67   ���#8d99ae$��3��6W   �� 5   
    �� Orientation$ 
Horizontal=�6   $��2��6.   ���#8d99ae$��3��6P   .+�5      �� -   5         ��Name$ btnLeave��5      $��leave��6'   $��80��6O   $��30��6Z   $��10q�6f   �� 5      -   5        $ btnSave��5      $
��save��6&   $��80��6L   $��30��6W   $��10q�6c   5      �� 5   
   $��1��6   $��1��6%   $��2��62   .+�5      �� $ 
Horizontal=�6   $��Center=�62   $��10q�6M   .+�5      �� $��старая группа��6   $	��120��60   �� 5      -   5         ��Name$ txtGroup��5      ��6,   �� *Group.title+5      �� 5       $ 
Horizontal=�6   $��Center=�62   $��10q�6M   .+�5!      �� $��новая группа��6   $	��120��6/   �� 5"      -   5         ��Name$ CBgroup��5"      $��30��6,   $	��120��68   5#      �� 5%      $ 
Horizontal=�6   $��Center=�62   $��10q�6M   .+�5&      �� $��дата рождения��6   $	��120��60   �� 5'      -   5        $ txtBirthday��5'      ��6/   �� *
birthday+5(      �� 5)      $ 
Horizontal=�6   $��Center=�62   $��10q�6M   .+�5*      �� $��новая дата��6   $	��120��6-   (  "System.Windows.Controls.DatePicker  5+      -   5          Name$ 	datePanel��5+      5,      5.      �� 50   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   .+�51      �� $��80��6   .+�52      �� $��фамилия��6   �� 53      $��имя��6   �� 54      $��отчесвто��6   55      �� 56      $��80��6   .+�57      �� -   5        $ txtStudentSurname��57      ��65   �� *	surname+�� 58      -   5        $ txtStudentName��58      ��62   �� *name+�� 59      -	   5        $ txtStudentPatronymic��59      ��68   �� *
patronymic+5:      5;      5<      5=      