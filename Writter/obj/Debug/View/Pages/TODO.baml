   M S B A M L   `   `   `  ����  Writter    Writter.TODO   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      $	��780��5      $	��950��6     N� Title$
  TODO��5	      .��5      � -   5         �Name$ SimplNoteGrid��5      ��5   
   �� 5       �� Color$ 	#FFF4F4F4��6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��250 �6   �� 5      $	��250 �6   �� 5      $	��250 �6    � RowDefinitions 5   
   �� 5      $	��101 �6   �� 5      $��25 �6   �� 5      $��327.2 �6   �� 5      $	��19* �6   �� 5      $��0* �6   �� 5      $	��90* �6   .+�5!   
   �� $X��RD:\УЧЕБА 2 КУРС\2СЕМЕСТР\coursework\Writter\Resourses\TODOList.png��6   $��0��6\   $��0��6l   $��45��6y   $��Right=�6�   $��0,32,0.8,23.8q�6�   �� 5"   
   $��1��6   $��0��6!   $��3��6.   $��0.2,0,0,24.6q�6B   $��2��6X   ._�5#      �� $��TODO Calendar��6   $��50(�5%      $
��Bold"�6&   $
��Left=�68   $��20,20,0,-0.2q�5&      $4��./Writter;component/Resourses/#Montserrat Light)�5'      5(      �� 5)   
   $0��*One Place for write your todo in calendar.��6   $��0��5*      $��1��6$   $��2��61   $��50,0.2,0.2,326.8q�5+      $(��"/Writter;component/Resourses/#Lato)�6.   $��2��6^   � 5-   
   $��2��6   $��1��6   $��3��6,   $��4��6@   $��0.2,0.4,0,0q�6Q    5.      �� 5/      �� 50      �� 51      �� 52       54      �� 55      $
��Auto �6    �� 56      $
��Auto �6    .+�58      � $��0��6   $��3��6    $��0��59      $��4��6#   $��Center=�5:      $	��600��5;      $	��300��6   $��4q�6-   .+�5<      ��  �� CornerRadius$ 10��6   
�������._�5=      �� $	��550��6#    �� Orientation$ Vertical=�60   .+�5>      �� $ 
Horizontal=�6%   .+�5?      �� 
�������$	��550��6<   $
��Auto��6H   ._�5@   "   �� .+�5A   &   �� 
�������$ 10��6@   $��70��5B   -   $��0 30 0 2q�5C   -   ._�5D   *   (  "System.Windows.Controls.DatePicker  -   5        $��DatePickerInfo��5E   5   $	��500��5F   5   $��Center=�6A   $(��"/Writter;component/Resourses/#Lato)�5G   6    (  $MaterialDesignFloatingHintDatePicker#��[  5H   6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Date��5I   6   $��0 0 0 0q�5K   6   $��25(�5M   6   ���	#FFE91E63$��70��6[   $��25,-10,25.4,0q�6g      SelectedDate 5D   5   �� *	DateTimes+5M   g   5N   '   �� 5O   &   
�������$��0 20 0 0q�6@   $ 10��6R   $��90��6d   ._�5P   *   �� -   5        	 ��Name$	 ContentTODO��5P   3   $	��500��6H   ���	#FFE91E63$��Center=�5Q   3   
 �� TextWrapping$

 Wrap=�5R   3    �� AcceptsReturn .  �� 
AcceptsTab . $(��"/Writter;component/Resourses/#Lato)�5U   3    % !MaterialDesignFloatingHintTextBox#��[ 5V   3   $ 
Write here��5W   3   $��20(�5Y   3   $��80��6A   ��5X   2   �� *ContentTodo+5Y   A   5Z   '   � 5[   &   .+�5]   *   �� $	��100��62   $��50��6>   $��	95 20 3 3q�5_   2   ���	#FF765459$
��Left=�6\   ��5^   2   �� *SaveCommand+.��5`   .   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentSave=�6F   $��30��6[   $��30��6f   5a   +   �� 5b   *   $	��100��61   $
��Auto��6=   $��0,20,95,2.8q�6L   $��Right=�6a   ���	#FF765459��5c   1   �� *ClearCommand+.��5d   .     $ TrashCan=�6F   $��30��6W   $��30��6b   5e   +   5f   '   5i   #   5j      5k      5l      5m      5n      5r      �� 5s   
   $��2��6   $��3��6    $��100.8,0.2,0,20q�61   $��3��6I   $��2��6V   $	��400��5t      $��/Resourses/Task-amico.png��6   �� 5u   
   $��My TO-DO list��6   $��1��5v      $��3��5w      $��3��5x      $4��./Writter;component/Resourses/#Montserrat Light)�5y      $��25(�5z      $��68.2,0.2,250,-1q�5{      $��3��6-   6@   �� 5|   
   $��3��6   $��3��5}      $ 10��5~      $��61,35,155.6,50.8q�5      ���	#FFE0E0E0$��3��5�   0   ._�5�      �� $ Vertical=�6   $��0,10,-0.2,10q�64   .+�5�      �� $	��235��6   $��
0,0,-0.2,0q�6,   .��5�      �� -   5         ��Name$ ListAllTodo��5�       �� SelectedIndex 5�      �� *Select_TODO_Element+ �� UpdateSourceTrigger$ PropertyChanged=���5�   #   �� *	AllTODO+$ PropertyChanged=� �� Mode$ TwoWay=� �� View 5�      �� 5�      .P�5�   "   ��  �� Width$
 Auto��61    �� DisplayMemberBinding 6>   �� *NAME_OF_NOTE+�� 5�   "   $ 70��61    6=   �� *DATE_CREATE+5�       � ContextMenu 5�      �� 5�      .@�5�   "   m� $
��Open��6+    m� Command 69   �� *
OpenTODO+$ PropertyChanged=�m� 5�   "   $��Delete��6+    6;   �� *
DeleteTODO+$ PropertyChanged=�5�      5�      5�      5�      5�      5�      5�      