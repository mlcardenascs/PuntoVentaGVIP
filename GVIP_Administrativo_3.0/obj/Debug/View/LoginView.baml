   M S B A M L   `   `   `  ����R  NGVIP_Administrativo_3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:GVIP_Administrativo_3._0.ViewGVIP_Administrativo_3._0.View  5   	   -    'GVIP_Administrativo_3._0.View.LoginView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:GVIP_Administrativo_3._0.View     5   	   @controls+http://metro.mahapps.com/winf/xaml/controls     5   	   -   5          � Title$  	LoginView��5	   	   $	��800��5
   	   $	��800��5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency . .��5      ��  �� CornerRadius$ 5��6   ��5   
   �� 5       �� ImageSource$ /Imagenes/Logo_GVIP.png��6   ._�5   
   �� $ 5��6   $��2q�5      ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 0,1&�5   &   .��5      �    primaryBackColor1	 � Color#	 �   6#   
 � Offset$
 0Q�5   #   -   5        Color_fondo��5   #   5       ._�5#      � $��0,0,0,0q�6    � RowDefinitions 5$      �� 5%      $��30 �6$   �� 5&      .+�5(      �  � ColumnDefinitions 5)      �� 5*      �� 5+      $��25 �6+   �� 5,      $��25 �6+   �� 5-      $��5 �6+   .+�5/      �� $��Inicio de sesión��6    
�������$��10(�51       $��
Montserrat)�52       $��0��53       $��Center=�54       $��10,0,0,0q�55       �� 56      -   5         ��Name$ btnMinimize��56      ���#1a2849$��0q�58      $��-��59      
�������$��16(�5;      $��
Montserrat)�5<       � Cursor$
 Hand��5=      $��1��5>      5?   9   �� 5@      -   5        $ btnClose��5@      
���  ��$��0q�5C      $��X��5D      
�������$��16(�5F      $��
Montserrat)�5G      $
 Hand��5H      $��2��5I      5J   6   5K      �� 5L      -   5         ��Name$ showpassword��5N      $��1��5L      $��660,400,0,0q�5M      5P      �� 5Q      -   5         ��Name$ txtshowpassword��5S      $	��200��5Q      $��20��5R      $��1��5T      $��
10,-90,0,0q�5U      
������ 
�������
������ 5X      �� 5Y      $��Mostrar contraseña��6   $��1��5Z      
�������$��14(�5\      $��680,398,0,0q�5]      �� 5^      $	��250��6   $��1��5_       �� Orientation$ Vertical=�5`      $��
0,150,0,0 q�5a      .+�5b      �� $��/Imagenes/drop.png��6   $	��145��5c      $��90��5d      �� 5e      $��Usuario��6     �� Padding$ 0,20,0,0q�5f       
�������$��20(�5h       $��
Montserrat)�5i       $��Medium"�5j       $��Center=�5k       �� 5l      -   5        $ 
txtUsuario��5l      $��13(�5m      $��Medium"�5n      $��
Montserrat)�5o      
������� �� 
CaretBrush
 �   �
�������$��0,0,0,1q�5s      $��28��5t      $��Center=�5u      $��0,5,0,0q�5v      $��25,0,0,0q�5w      .��61   ��5x      �� 5y      $ /Imagenes/Userlogo.png��6)    j� Stretch$ Uniform=�5z   )    j� 
AlignmentX$
 Left=�5{   )   .��5|   .   5}      �� 5~      $��Contraseña��6    $ 0,10,0,0q�5       
�������$��20(�5�       $��
Montserrat)�5�       $��Medium"�5�       $��Center=�5�       G� 5�      -   5         G�Name$ txtContraseña��5�   "   $��13(�5�   "   $��Medium"�5�   "   $��
Montserrat)�5�   "   
������� G� 
CaretBrush
 �   �
�������$��0,0,0,1q�5�   "   $��34��5�   "   $��Center=�5�   "   $��0,5,0,0q�5�   "   $��25,0,0,0q�5�   "    G� PasswordChar$ *��5�   !   ��5�      �� 5�      $ /Imagenes/Keylogo.png��6)   $ Uniform=�5�   )   $
 Left=�5�   )   5�      �� 5�      -	   5        $ 
btnIniciar��5�        colorSecundario#���  5�      $��0q�5�      $��Iniciar Sesión��5�      
�������$��16(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��0,80,0,0q�5�      $	��150��5�      5�      5�      5�      5�      5�      5�      