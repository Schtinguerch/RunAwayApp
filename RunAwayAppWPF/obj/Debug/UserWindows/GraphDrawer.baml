   M S B A M L   `   `   `  ����H  DRunAwayAppWPF, Version=3.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:RunAwayAppWPF.UserWindowsRunAwayAppWPF.UserWindows  5   	   +    %RunAwayAppWPF.UserWindows.GraphDrawer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:RunAwayAppWPF.UserWindows     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0$oxyPlothttp://oxyplot.org/wpf  5   	   -   5        $��GraphDrawerr��5	   6     � Title$  GraphDrawer��6	   $	��450��6   $	��800��6*    � Icon$ /Resources/favicon.ico��6J    � WindowStyle$
 None=�5
   	   ���#1c1c1c.��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � -   5        $��ToolBar��5   5   $��0��6   
������ .+�5      � -   5         �Name$	 Hat��5      
������� J� Opacity$	 0.2Q�5       � Points) �   ��� h�	���  �%&��� �6�&5      �� 5      $��Right=�6    �� Orientation$ 
Horizontal=�65   $	��130��6N   .+�5      �� -   5        $��25��5         MenuStripButtonStyle#��[  6$   $��0 0 20 0q�6R   .��5      �� $��22��6   $$��/ApplicationData/addWindow.png��6(   5      �� 5      -   5        $��	LowButton��5   :   $��15��6   $��15��6$   $��5q�6/   ��5       �� 5!       �� 
TargetType" ��6    .�5"      �� 	 �� Property	 � ��
 �� Value$+
 %/ApplicationData/свернуть.png��67    �� Triggers 5#      �� 5$   "    �� Binding 6.   �� *IsMouseOver+ �� ElementName$ 	LowButton�� �� Value True6e   .a�5%   &   �� 	 � ��$;
 5/ApplicationData/свернутьактивный.png��6?   5&   #   5(      5*      �� 5+      -   5        $��UpButton��5+   :   $��15��6   $��15��6$   $��5q�6/   ��5,      �� 5-      " ��6    .�5.      �� 	 � ��$#
 /ApplicationData/окно.png��67    5/      �� 50   "    6.   �� *IsMouseOver+$ UpButton�� True6d   .a�51   &   �� 	 � ��$3
 -/ApplicationData/окноактивный.png��6?   52   #   54      56      �� 57      -   5        $��CloseButton��57   A   $��15��6   $��15��6$   $��5 5 12 5q�6/   ��58      �� 59      " ��6    .�5:      �� 	 � ��$)
 #/ApplicationData/крестик.png��67    5;      �� 5<   "    6.   �� *IsMouseOver+$ CloseButton�� True6g   .a�5=   &   �� 	 � ��$7
 1/ApplicationData/крестикактивый.png��6?   5>   #   5@      5B      5C      5D      � 5F   
   $��1��6   .+�5G      �� $��Function range��6     
LableStyle#��[ 6.   $��	10 5 10 0q�6R   �� 5H      -   5        $��rangeA��5H   v     TextBoxStyle#��[ 6   $��50��6<   $��
130 3 10 0q�6G   $
��Left=�6[   $	��-10��6�   �� 5I      $��to��6   #��[ 6"   $��
200 5 10 0q�6F   $
��Left=�6Z   �� 5J      -	   5        $��rangeB��5J   v   #��[ 6   $��50��6<   $��
230 3 10 0q�6G   $
��Left=�6[   $��10��6�   �� 5L      $��Formula��6   #��[ 6'   $��
10 5 315 0q�6K   $��Right=�6_   �� 5M      -
   5        $��formulaTextBox��5M   x   #��[ 6   $	��250��6<   $��
230 3 50 0q�6H   $��Right=�6\   $��	exp(x, x)��6�   �� 5N      -   5        $��30��5N      $��27��6!   $��Right=�6-   $��0 3 10 0q�6I   6[   5O      � 5Q   
   $��2��6   .+�5R        OxyPlot.Wpf.PlotView  -   5          Name$ Grapher��5R      ���#1c1c1c60   5S      5T      5U      