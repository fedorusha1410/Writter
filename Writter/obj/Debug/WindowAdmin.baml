   M S B A M L   `   `   `  ����B  >Writter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WritterWritter  5   	   1clr-namespace:Writter.CommandWritter.Command  6-       Writter.WindowAdmin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   !localclr-namespace:Writter  5   	   +commandclr-namespace:Writter.Command  6-   -   5        $��AdminWindow��5        � Icon$T  ND:\УЧЕБА 2 КУРС\2СЕМЕСТР\coursework\Writter\Resourses\icon.png��5   	    � Title$ Admin | Writter��5
   	   $
��1200��5   	   $
��1200��6   $	��800��5   
   $	��800��5   
    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   
   $
��1200��5   
   $	��800��6    � 	Resources 5        Writter.Command.Converter 	  admin�� 5   
   %   &	          5      6    5      .��5      � .+�5   
   �� $��40 25 40 25q�6   
�������._�5      ��  �� Orientation$ Vertical=�6   $��20 20 20 70q�5      .+�5      �� $��List of all users��6   $��40(�5       $��Center=�5!      
�������$(��"/Writter;component/Resourses/#Lato)�5#      $
��Bold"�5$      &   System.Windows.Controls.DataGrid  5&      -   5        $��	UsersGrid��50      $
��Left=�5&      
�������$	��560��5(      $��
10,15,0,10q�6*   $	��Top=�5)      $
��1058��5*      $4��./Writter;component/Resourses/#Montserrat Light)�5+      $��20(�5,         AutoGenerateColumns .    SelectionUnit$ FullRow=�5/   !   	 �� SelectedIndex	 5-   %   �� *Index+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5.      �� *
AllUsers+$ PropertyChanged=�$
 TwoWay=� � ContextMenu 52      �� 53      ���	#FFE91E63.@�54      m� -   5        $��_delete_user��55   1   $��Delete��54   '   $��20��55   %   $��
20 0 20 10q�6E   $��1q�6Y   
������� m� Command 54   7   �� *
DeleteUser+$ PropertyChanged=�56   '   m� 58      -   5        $��_block_user��59   �   $��Block/Unblock��58   '   $��20��59   '   
�������$��	20 0 20 0q�6�   $��1q�6�    6F   �� *	BlockUser+$ PropertyChanged=�6�   5:      5<      5=      5?      �� 5A   
   $��Bottom=�6   $��Right=�5B      $��0,0,54.6,32.4q�5C      $��40��5D      $��67��6   ��5E      �� *Close+.��5I      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�6&   $��30��68   $��30��6C   ��5J      `� 5K       `� 	Converter# [  6   .1�5L      ��  �� ElementName$ AdminWindow��6   5N      5Q      5R      5S      