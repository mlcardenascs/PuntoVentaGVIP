   M S B A M L   `   `   `  ����R  NGVIP_Administrativo_3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:GVIP_Administrativo_3._0.ViewModelss$GVIP_Administrativo_3._0.ViewModelss  5      7    1GVIP_Administrativo_3._0.ViewModelss.SupplierPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:GVIP_Administrativo_3._0.ViewModelss     5        N� Title$  SupplierPage��5
      .��5      �    colorSecundario#��[  6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5   
   ��   colorPrincipal#��[ 6   $��0,0,0,2q�5      ._�5      �� $��Proveedores��6   
�������$��24(�5      $��Center=�5      $��0��5      5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $	��850 �6#   �� 5      .+�5      � $��0��6   
������ .+�5!      �� 
������ #��[ 5"      $��0,0,2,0q�5#      65   �� 5$      
������ $	��400��5%      ._�5&      �  5'      �� 5(      $��50 �6,   �� 5)      �� 5*      �� 5+      �� 5,      �� 5-      �� 5.      .+�50      �� $��Datos del proveedor��6$   
�������$��18(�52   $   $��Center=�53   $   $��0��54   $   �� 55      $��Nombre*:��6$   
�������$��18(�57   $   $��1��58   $   �� 59      -   5         ��Name$ 
txt_nombre��5=   "   $��30��59   "   $	��200��5:   "   $��1��5;   "   $��0,0,0,70q�5<   "   5=   "   �� 5>      $��Apellido Paterno:��6$   
�������$��18(�5@   $   $��2��5A   $   �� 5B      -   5        $ txt_apellido_paterno��5F   "   $��30��5B   "   $	��200��5C   "   $��2��5D   "   $��150,4,80,70q�5E   "   5F   "   �� 5G      $��Apellido Materno:��6$   
�������$	��18 (�5I   $   $��3��5J   $   �� 5K      -   5        $ txt_apellido_materno��5O   "   $��30��5K   "   $	��200��5L   "   $��3��5M   "   $��150,5,80,70q�5N   "   5O   "   �� 5P      $��RFC*:��6$   
�������$��18(�5R   $   $��4��5S   $   �� 5T      -   5        $ txt_rfc��5X   "   $��30��5T   "   $	��200��5U   "   $��4��5V   "   $��140,5,80,70q�5W   "    �� 	MaxLength$ 13��5Y   "   �� 5[      $��Dirección*:��6$   
�������$��18(�5]   $   $��5��5^   $   �� 5_      -   5        $ txt_direccion��5c   "   $��30��5_   "   $	��200��5`   "   $��5��5a   "   $��	40,0,0,70q�5b   "   5c   "   �� 5d      $��Tipo de proveedor*:��6$   
�������$��18(�5f   $   $��7��5g   $   �� 5h      -   5         ��Name$ cbox_tipo_proveedor��5h   #   $
��Left=�5i   #   $��170,-70,0,0q�5j   #   $��6��5k   #   $	��150��5l   #   $��30��5m   #   $��Center=�5n   #   $��Center=�5o   #   $��17(�5p   #   5r      5s      5t      �� 5u      $��Acción:��6   $��20(�5v      
�������$��1��5x      $��	175,0,0,0q�5y      �� 5z      -   5        $ cbox_opciones��5z      $��1��5{      $	��200��5|      $��30��5}      $��Center=�5~      $��Center=�5      $��17(�5�      $��
0,-600,0,0q�5�      5�      5�      5�      5�      