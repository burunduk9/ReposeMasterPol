   M S B A M L   `   `   `  ����L  HAtendaanceProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AtendaanceProject.PageAppAtendaanceProject.PageApp  5      4    .AtendaanceProject.PageApp.TeacherAtendancePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:AtendaanceProject.PageApp     5        N� Title$  TeacherAtendancePage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      .+�5   
   �� .+�5      �� $��search��6   �� 5      -   5         ��Name$ txtsearchik��5      6+   �� 5      $��filter student��6   �� 5      -   5         ��Name$ CBfilterStudent��5      ��60   �� *
Students+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� ��6$   �� *	surname+�� 5      ��6$   �� *name+�� 5      ��6$   �� *
patronymic+5      5      5!      �� 5#      $��filter group��6   �� 5$      -   5        $ CBfilterGroup��5$      ��6.   �� *Groups+��5%      �� 5&      .R�5'      �� ��6    �� *title+5(      5*      �� 5,      $��filter subject��6   �� 5-      -   5        $ CBfilterSubject��5-      ��60   �� *
Subjects+��5.      �� 5/      .R�50      �� ��6    �� *title+51      53      �� 55      -   5         ��Name$ btnAddAtendance��55      $��add atendance��6.   6F   (  "System.Windows.Controls.DatePicker  56      -   5          Name$ 	datePanel��56      6,   57      �� 59   
   $��1��6   .+�5:      �� $	��600��6   $	��800��6+   .��5;      �� -   5         ��Name$ ListAtendance��5;      ��62   �� *
Atendances+ �� View 5<      �� 5=      .P�5?      �� $��surname��6-   	 �� Width$	 80��6>   
 �� CellTemplate
 5@   "   �� 5A   &   .R�5B   *   �� ��60   �� *Student.surname+5C   '   5E      �� 5G      $
��name��6-   $	 80��6;   
 5H   "   �� 5I   &   .R�5J   *   �� ��60   �� *Student.name+5K   '   5M      �� 5O      $��
patronymic��6-   $	 80��6A   
 5P   "   �� 5Q   &   .R�5R   *   �� ��60   �� *Student.patronymic+5S   '   5U      �� 5W      $��group��6-   $	 80��6<   
 5X   "   �� 5Y   &   .R�5Z   *   �� ��60   �� *Schedule.Groupi.title+5[   '   5]      �� 5_      $��subject��6-   $	 80��6>   
 5`   "   �� 5a   &   .R�5b   *   �� ��60   �� *Schedule.Subject.title+5c   '   5e      �� 5g      $��	atendance��6-   $	 80��6@   
 5h   "   �� 5i   &   .R�5j   *   �� ��60   �� *AtendanceType.title+5k   '   5m      �� 5o      $
��date��6-   $	 80��6;   
 5p   "   �� 5q   &   .R�5r   *   �� ��60   �� *date+5s   '   5u      �� 5w      $��support buttons��6-   $		 180��6F   
 5x   "   �� 5y   &   .R�5z   *   �� $ 
Horizontal=�65   .+�5{   .   �� $ btnEdit��65   -   5        $
��edit��5{   F   6U   �� 5|   .   $ 	btnDelete��65   -	   5        $��delete��5|   H   6Y   5}   +   5~   '   5�      5�      5�      5�      5�      5�      5�      