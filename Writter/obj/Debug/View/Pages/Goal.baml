   M S B A M L   `   `   `  ����B  >Writter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Writter.View.PagesWritter.View.Pages  5          Writter.View.Pages.Goal   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Writter.View.Pages     5      $	��780��5	      $	��960��6     N� Title$
  Goal��5
      .��5      � -   5         �Name$ SimplNoteGrid��5      
������� � ColumnDefinitions 5   
   �� 5      $	��100 �6    �� 5      �� 5      $	��145 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��25 �6   �� 5      �� 5      $��60 �6   .+�5   
   �� $��1��6   $��0��6!   $��3��61   $��30 0 0 0q�6E   $(��"/Writter;component/Resourses/#Lato)�5      $-��'One place to set goals and achieve them��5      �� 5   
   $��1��6   $��0��6!   
���   �$��3��5      $	��Top=�5      $��0 20 0 0q�5      �� 5    
   $T��ND:\УЧЕБА 2 КУРС\2СЕМЕСТР\coursework\Writter\Resourses\Goal.png��6   $��0��5!      $��0��5"      $��55��5#      $��Right=�5$      $��	15 10 0 0q�5%      �� 5&   
   $��Goals��6   $��1��5(      $��0��5)      $��55(�5*      $��5 20 0 0q�5+      $
��Bold"�5,      $
��Left=�6.   $4��./Writter;component/Resourses/#Montserrat Light)�6J   � 5-   
   $��2��6   $��2��6   $��3q�6-   $��0��68   $��3��6H    5.      �� 5/      �� 50       52      �� 53      $	��170 �6    �� 54      �� 55      .+�57      �� $��0��6   $��1��6%   $��My Goals��65   $��55(�6E   $4��./Writter;component/Resourses/#Montserrat Light)�58      $��Center=�59      $	��Top=�5:      $��0 20 0 0q�5;      �� 5<      $��1��6   $��0��6%   $��30 120 50 60q�62   $��3��6H    �� CornerRadius$ 10��5=      ���	#FFFFE2B9$��2q�5?      ���	#FFE0E0E0._�5A      �� .+�5B      �� $	��472��6#   $��
0,0,-0.2,0q�60   .��5C      �� $	��382��6�   $	��462��6�    �� SelectedIndex 6#   �� *SelectIndex+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6{   �� *
AllGoals+$ PropertyChanged=�$ TwoWay=� �� View 5D      �� 5E   "   .P�5F   &   �� 	 �� DisplayMemberBinding	 65   �� *NAME_OF_NOTE+5G   #   
 � ContextMenu
 5I      �� 5J   "   .@�5K   &   m� $
��Open��6/    m� Command 6=   �� *
OpenGoal+$ PropertyChanged=�m� 5L   &   $��Delete��6/    6?   �� *
DeleteTask+$ PropertyChanged=�5M   #   5O      5P      5Q      5R      �� 5S      $��0��6   $��20 -25 20 20q�5T      $	��250��5U      $ 10��5V      ���	#FFFFE2B9$��0��5X      $��2��6%   ._�5Y      �� .+�5Z      �� $ 5��6   
�������$��0��5[      $��0��6&   $��40��5\      $�� 20 25 20 0q�5]      
�������._�5^      �� $	��385��6"   $4��./Writter;component/Resourses/#Montserrat Light)�5_   "    %  !MaterialDesignFloatingHintTextBox#��[  5`   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Name Goal��5a   "   ��5b      �� *	MyGoals+68   5d      �� 5e      $��80��6   
�������$ 5��5f      $��
20 20 20 0q�5g      ._�5h      �� $	��385��6"    �� TextWrapping$
 Wrap=�5i   "    �� 
AcceptsTab . $4��./Writter;component/Resourses/#Montserrat Light)�5k   "   #��[  5l      $ Write about your goal��5m   3   ��5n   #   �� *
GoalTell+.��6=   5p      5q      �� 5r       �� Orientation$ 
Horizontal=�6!   .+�5s      �� $��40��6!   $��20 27 250 0q�6.   $	��150��6C   
�������$ 5��6b   ._�5t      �� $	��140��6'   ���	#FFFF2D79��5v      �� *Status+ �� SelectedValue 6>   �� *SelectedStatus+ 6g   �� *IndexStatus+6�   5x      5z      �� 5{      $��36��6   $��244,-40,122.8,0q�6)   $
��Save��6B   ��6Q   �� *
SaveGoal+�� 5|      $��36��6   $��328,-40,38.8,0q�6)   $��Clear��6A   ��6Q   �� *	ClearGoal+5~      5�      �� 5�      $��0��6   $��1��6$   $��/Resourses/goUp.png��61   $��2��5�      $
��Left=�6(   $	��335��6C   $��
70 140 0 0q�6P   $��2��6d   5�      5�      5�      