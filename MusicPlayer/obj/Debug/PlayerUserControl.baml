   M S B A M L   `   `   `  ����F  BMusicPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MusicPlayerMusicPlayer  5      #    MusicPlayer.PlayerUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:MusicPlayer     5      .��5      � $��0,0,0,0q�6   .+�5	   
   �� -   5          ��Name$  imgBackground��5	      $��images/black.jpg��6'   $
��Fill=�6A   $��8��6P   $��7��6a   �� 5
   
   -   5         ��Name$ lstSongs��5
      $��5��6$   $��1��68   $��2��6E   $��1��6V   .@�5      �� $��	SONG LIST��6   $��18(�6.   $
��Bold"�6<   {�.  6N   5      �� 5   
   -   5        $ lstMenu��5      $��5��6#   $��1��67   $��2��6D   $��1��6U   $y�Hidden=�6e   .@�5      �� $
��MENU��6   $��18(�6)   $
��Bold"�67   {�.  6I   �� 5      $��
> ADD SONG��6    �� 
IsSelected . 6/   �� 5      $��> EDIT SONG INFO��6   �� 5      $��> REMOVE SONG��6   �� 5      $��<< BACK��6   5      �� 5   
   -   5         ��Name$ rectPrevious��5      ���	#FFF4F4F5
���   � J� Opacity$ 0Q�6J   $��5��6x    � Cursor$
 Hand��6�   $��2��6�   $��0,1,0,0q�6�    � ToolTip$ Previous��6�   �� 5   
   -   5        $ rectNext��5      ���	#FFF4F4F5
���   �$ 0Q�6F   $��5��6p   $
 Hand��6}   $��4��6�   $��0,1,0,0q�6�   $
 Next��6�   �� 5   
   -   5        $ rectMenu��5      ���	#FFF4F4F5
���   �$ 0Q�6F   $��4��6r   $
 Hand��6   $��3��6�   $��0,1,0,0q�6�   $ 	Menu/Stop��6�   �� 5   
   -   5        $ rectPlayPause��5      ���	#FFF4F4F5
���   �$ 0Q�6K   $��6��6x   $
 Hand��6�   $��3��6�   $��0,2,0,0q�6�   $ Select/Play/Pause��6�   r� 5   
   -   5         r�Name$ MediaElement1��5       r� Source$  ?�6.   	 r� LoadedBehavior$	 Manual=�68   
 r� UnloadedBehavior$

 Stop=�6P    r� Stretch$
 Fill=�6h   $��5��6w   $��3��6�   $��0,1,0,0q�6�   $y�Hidden=�6�    � RowDefinitions 5   
   �� 5      $	��35* �6   6+   �� 5      $
��250* �6   �� 5      $
��100* �6   �� 5      $	��40* �6   6+   �� 5      $	��50* �6   6+   �� 5      $	��99* �6   �� 5       $	��50* �6   �� 5!      $	��50* �6    � ColumnDefinitions 5#   
   �� 5$      $	��30* �6   6-   �� 5%      $	��10* �6   �� 5&      $	��50* �6   �� 5'      $
��100* �6   6.   �� 5(      $	��50* �6   �� 5)      $��10 �6   �� 5*      $	��30* �6   5,      5-      