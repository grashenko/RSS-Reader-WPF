   M S B A M L   `   `   `  ����G  CRSSreadedWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RSSreadedWPFRSSreadedWPF  5   	   ?$clr-namespace:LoadingControl.ControlLoadingControl.Control  5   	       RSSreaderWPF.Entry   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialdesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:RSSreadedWPF  5   	   2control$clr-namespace:LoadingControl.Control  5   	     � Title$  Entry��5
   	    	  Color#���   6   $	��670��6<   $
��1200��6I    � WindowStartupLocation$ CenterScreen=�6V   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��157* �6   �� 5      $
��215* �6   �� 5      $
��160* �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��login��5   %   
���   � K� ZIndex$ 1��62   $��Roboto)�6C   $��15(�6W   $��2��6{   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
ЛОГИН��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   
���   �$��Center=�6  $��70��6  $	��300��6+  $��91,31,91.4,0q�67  $	��Top=�6N  $��1��6f  ��6e   Z� 6f  G� 5   
   -   5        $��password��5   )   
���   �$ 1��69   $��Roboto)�6J   $��15(�6^   $��3��6�   $ ПАРОЛЬ��6�    ) %MaterialDesignFloatingHintPasswordBox#��[ 6�   
���   �$��Center=�6  $��70��6(  $	��300��64  $��91,20,91.4,0q�6@  $	��Top=�6X  $��1��6p  ��6l   Z� 6p  �� 5   
   -   5        #���   5      $��
Войти��66   $��Roboto)�6F   $��15(�6Z   $��Center=�6h   $��4��6�   $��28,48,314.4,0q�6�   $	��Top=�6�   $	��140��6�   $��40��6�   $��1��6�   �� 5   
   -   5        #���   5      $��Регистрация��66   $��Roboto)�6M   $��15(�6a   $��Center=�6o   $��4��6�   $��307,48,34.4,0q�6�   $	��Top=�6�   $	��141��6�   $��40��6�   $��1��6�   d� 5   
   -   5        #���   5      $��294.6,10,9.6,86q�6<    � ToolTip$! Светлая/Тёмная��6U    J� RenderTransformOrigin$ 0.397,0.616&�6n   $��1��6�   $��2��6�   6�   �� 5    
   -   5        #���   5       $.��(Войти без регистрации��66   $��Center=�6V   $��15(�6s   $��5��6�   $��91,10,91.4,0q�6�   $	��Top=�6�   $	��300��6�   $��1��6�   $��39��6�   �� 5!   
   $��Center=�6   $��Roboto)�61   $��3��6E   $��86(�6Y   $��Medium&�6g   $��290,22,278.6,0q�6}   $��1��6�   $
��Wrap=�6�   $��АВТОРИЗАЦИЯ��6�   $	��Top=�6�   $	��102��6�   $	��625��6�   �� 5"   
   $��0��6   $��0��6   $��5��6.   
���   �.+�5#      �� -   5        $��tb��5#      $
��Wrap=�6"   $��Roboto)�66   $��	-25,0,0,0q�6J   $��15(�6]   
�������$��Center=�6~   $��Center=�6�   $��	TextBlock��6�    �� Left$	 600��6�   $��28��6�   5$      �� 5%   
   
���   �#���   6%   $��1q�6J   $��1��6^   $
��Left=�6n   $	��230��6�   $��	28,31,0,0q�6�   $��2��6�   $��3��6�   $	��Top=�6�   $	��420��6�   5&      5'      