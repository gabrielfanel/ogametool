   M S B A M L   `   `   `  ����  OGameViewer    OGameViewer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��700��6)    � 	Resources 5       �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid��%�  '��       '�� �     '  �    '�� W    �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       �@J�Opacity$	 0.5Q�6(   �� 5	       � ��
 ��� �6+   �� 5
       � ��$ 16(�6)   �� 5       �@��MaxDropDownHeight$	 100��62   5      �� 5   
   " ��6   .�5      ��  � ��
 ��� �6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ Center=�62   5      �� 5   
   "  6   .�5      ��  � ��
 �   �6+   �� 5       �@J�Opacity$	 0.6Q�6(   �� 5       � ��$ Stretch=�64   �� 5       � ��$ Stretch=�62   5      �� 5   
   " ��6   .�5      ��  � ��
 ��� �6+   �� 5       � ��$ 16(�6)   5      5      .��5!      � ��5"   
   �� 5#       �� ImageSource$ res/og_background.jpg��6    j� Stretch$
 None=�6=   6N    � ColumnDefinitions 5%   
   �� 5&      �� 5'       � RowDefinitions 5)   
   �� 5*      $��30 �6   �� 5+      .+�5.   
   �� $��0��6   $��1��6"   	 �� Orientation$	 
Horizontal=�62   $��Right=�6K   .+�5/      �� $��Select a server :��6   �� 50      $	��200��6r   ��6   �� *ServerNames+
 �� SelectedItem
 6;   �� *SelectedUniverse+ �� Mode$ TwoWay=�6r   51        53   
   $��1��6   $��0��6       AutoGenerateColumns .  ��60   �� *	Players+$ TwoWay=�
 6]   �� *SelectedPlayer+$ TwoWay=�   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ Player��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Name+  56      $ Status��6%    65   �� *Status+  57      $ Alliance��6%    67   �� *
Alliance+59      �� 5;   
   $��1��6   $��1��6    $��Player's Info��60   .��5<      � $��Stretch=�6   $	��Top=�61   $��5q�6I    5=      �� 5>      �� 5?       5A      �� 5B      �� 5C      �� 5D      �� 5E      �� 5F      �� 5G      �� 5H      �� 5I      .+�5L      �� $��0��6   $��0��6)   $��Total Points :��69   �� 5M      $��0��6   $��1��6)   ��5N      `� 5O       �� StringFormat$ 	{0} ({1})��6'   .1�5P      ��  �� Path$ PlayerTotalPoints�6&   �� 5Q      $ PlayerTotalPointsRank�6&   5R      5T      �� 5V      $��1��6   $��0��6)   $��Economy Points :��69   �� 5W      $��1��6   $��1��6)   ��5X      `� 5Y      $ 	{0} ({1})��6'   .1�5Z      �� $ PlayerEconomyPoints�6&   �� 5[      $ PlayerEconomyPointsRank�6&   5\      5^      �� 5`      $��2��6   $��0��6)   $��Research Points :��69   �� 5a      $��2��6   $��1��6)   ��5b      `� 5c      $ 	{0} ({1})��6'   .1�5d      �� $ PlayerResearchPoints�6&   �� 5e      $ PlayerResearchPointsRank�6&   5f      5h      �� 5j      $��3��6   $��0��6)   $��Military Points :��69   �� 5k      $��3��6   $��1��6)   ��5l      `� 5m      $ 	{0} ({1})��6'   .1�5n      �� $ PlayerMilitaryPoints�6&   �� 5o      $ PlayerMilitaryPointsRank�6&   5p      5r      �� 5t      $��4��6   $��0��6)   $��Honor Points :��69   �� 5u      $��4��6   $��1��6)   ��5v      `� 5w      $ 	{0} ({1})��6'   .1�5x      �� $ PlayerHonorPoints�6&   �� 5y      $ PlayerHonorPointsRank�6&   5z      5|      5~      5      5�      5�      