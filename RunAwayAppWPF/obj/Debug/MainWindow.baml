   M S B A M L   `   `   `  ����H  DRunAwayAppWPF, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RunAwayAppWPFRunAwayAppWPF  5   	       RunAwayAppWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5   	   _ [ICSharpCode.AvalonEdit, Version=6.0.1.278, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  5   	   'localclr-namespace:RunAwayAppWPF  5   	   -   5          �Name$  	CmdWindow��5	       � Title$ RunAway��5
   	   $��50��6   $
��1200��6%    � WindowStyle$
 None=�5   	    � 
ResizeMode$ CanMinimize=�6    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   #   
������  � Icon$ Resources/new.ico��5   /   .��5      � .+�5   
   �� $
��auto��6   $
��auto��6   
���2�2�$��0q�6D    �� CornerRadius$ 16��5      ���#202020 J� Opacity$	 0.9Q�68   ._�5      � 	 � RowDefinitions	 5      �� 5      -   5        
 ��Name$
 
TextHeight��5   $   $��50 �68   �� 5      $��* �6$   .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��80 �6+   .+�5!      � $��1��6   .+�5"      �� -   5         ��Name$ 
MainButton��5"   !      TransparentButtonStyle#��[  65   $��0 0 1 0q�6~   .��5#      �� $��->��6(   
���  ��$��25(�6C   $��Consolas)�6Q   $
��Bold"�6g   5$      3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  5&      -   5        $y�Visible=�5'         ToolTipText$ RunAway tray manager��5(         
IconSource$ Resources/favicon.ico��5)       � ContextMenu 5,      �� 5-   "   -   5         ��Name$ TrayMenu��5-   .     
TrayStyle1#��[ 6@   $��0q�6d   .@�5.   &   m� -   5        $��Open the terminal��5.   /   $��2q�6J   6U   m� 5/   &   -   5        $��	Start cmd��5/   /   $��2q�6B   6M   m� 50   &   -   5        $��Open math interpreter��50   /   $��2q�6N   6Y   m� 51   &   -	   5        $��Open graph drawer��51   /   $��2q�6J   6U   �� 52   &   
���  ��$��2��6A   m� 53   &   -
   5        $
��Quit��53   /   $��2q�6=   6H   54   #   56      57      � 59      $��0��6   .+�5:      '  !ICSharpCode.AvalonEdit.TextEditor  -   5          Name$ 
CommandBox��5;        MainTextBoxStyle#��[ 5<         WordWrap .  5>      5@      5A      � 5C      $��1��6   .+�5D      �� -   5         ��Name$ ProgramsView��5D      $��20 10 20 20q�5E        ListViewStyle#��[ 5F       5H      �� 5I      -   5        $ FileContextMenu��5I   *   #���  6C   $��0q�6h   .@�5J   "   m� -   5        $��	Open file��5J   +   $��2q�6?   6J   m� 5K   "   -   5        $��	Copy file��5K   +   $��2q�6>   6I   m� 5L   "   -   5        $��Copy file's text��5L   +   $��2q�6E   6P   m� 5M   "   -   5        $��Show in file explorer��5M   +   $��2q�6J   6U   5N      5P      5Q      5S      5T      5U      5V      