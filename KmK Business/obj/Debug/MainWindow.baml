   M S B A M L   `   `   `  ����G  CKmK Business, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:KmK_Business.ConvertorKmK_Business.Convertor  5   	       KmK_Business.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2l$clr-namespace:KmK_Business.Convertor     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $	��750��5   '   $
��1200��64   $
��1200��6A   $	��750��6Q    � Icon$ /imgs/app_title_bar.png��5   	    � Title 5   	   �� *WindowTitle+ � 	Resources 5	      6   0KmK_Business.Convertor.BoolToVisibilityConverter   	converter��%   &	          5
   
   6&   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��7* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   o� $��2��6   .@�5      m�   file#���  6   .@�5      m� -   5        $ ��Open - (Go on home window)��5      6?   5      m� 5        edit#���  6   y�67   �� *VisibilityEdit+ �� 	Converter# [  m� 5        	navigator#���  6   y�6<   �� *VisibilityMenuItem+# [  m� 5         view#���  6   y�67   �� *VisibilityMenuItem+# [  m� 5!        accounts#���  6   y�6;   �� *VisibilityMenuItem+# [  m� 5"        trading#���  6   y�6:   �� *VisibilityMenuItem+# [  m� 5#        reports#���  6   y�6:   �� *VisibilityMenuItem+# [  m� 5$       	 tasks#���  6   y�68   �� *VisibilityMenuItem+# [  m� 5%       	 contacts#��� 	 6   y�6;   �� *VisibilityMenuItem+# [  m� 5&       
 knowledgeBase#��� 
 6   y�6@   �� *VisibilityMenuItem+# [  m� 5'        help#���  6   5(      �� 5*   
   -   5        $��ContentHolder��5*   :   $��1��6   $��2��6&   $��Stretch=�5+      � 5-   
   -   5         �Name$ 
statusGrid��5-      $��2��6#   $��0��60   $��2��6@    5.      �� 5/      $��2* �6#   �� 50      $��6* �6#   .+�53      �� $��0��6    �� Orientation$ 
Horizontal=�6)   .+�54      �� $��1��6   $��Right=�6%   $"��/imgs/status_bar_db_path.png��6A   $��25��6g   $��25��6s   �� 55        currentDatabase#���  6   �� 56      ��6   �� *DatabaseName+57      �� 59      -   5        	 ��Name$	 contextToolTips��59      $��1��6v   $
��Left=�6�   ��6-   �� *ContextToolTips+
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   5;      5=      5>      