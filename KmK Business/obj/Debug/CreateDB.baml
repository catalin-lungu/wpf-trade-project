   M S B A M L   `   `   `  ����  KmK Business    KmK_Business.CreateDB   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  CreateDB��5   	   $	��300��6   $	��300��6'   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5	      $��1* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   ��    database#���   6   �� 5   
   -   5         ��Name$ txtDB��5      $��1��6!    �� 
IsReadOnly . 61   �� 5   
   -   5        $	��...��5      $��30��6   $��Right=�6+   $��1��6G   6W   �� 5   
     userName#���  6   $��1��65   �� 5   
   -   5        $ txtUsername��5      $��1��6'   $��1��67   �� 5   
     password#���  6   $��2��65   G� 5   
   -   5         G�Name$ txtPassword��5      $��1��6,   $��2��6<    G� PasswordChar$ *��6I   �� 5   
   -   5         
 create#���  5      $��3��64   $��1��6A   6Q   5      5      