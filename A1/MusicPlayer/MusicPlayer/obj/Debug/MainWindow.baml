   M S B A M L   `   `   `  ����F  BMusicPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MusicPlayerMusicPlayer  5   	       MusicPlayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MusicPlayer     5   	     � Title$  AudioPlayerMain��5   	   $	��450��6!   $	��400��6.    � 
ResizeMode$ NoResize=�6:    � 	Resources 5	       �� 
TargetType �� Property �� Value��%/  '��       �� 5
   
   " ��6   .�5      ��  � ��$ 	40,20,0,0q�6'   6;   �� 5       � ��$
 Left=�64   6C   �� 5       � ��$ 16(�6)   66   �� 5       � ��$
 Bold"�6+   6:   �� 5       � ��$ 30��6'   64   �� 5       � ��$ 85��6&   63   5      5      .��5      � .+�5   
   �� -   5        $��DisplayTime��5      $��Not playing...��6#   $��Center=�6<   $��5q�6`   � 5   
   .+�5      �� -   5        $��btnPause��5   0   $
��Left=�6   $��	40,10,0,0q�6W   .��6j   Pause6q   �� 5      -   5        $��btnStop��5   1   $��Right=�6   $��
145,10,0,0q�6V   .��6j   Stop6p   5      �� 5   
   $��1��6   $��0,0,0.334,-0.333q�6)   .+�5      �� -   5        $��	40,60,0,0q�5      $
��Play��6(   67   �� 5      -   5        $��	Beginning��5      6)   �� 5      -   5        $
��Back��5      6$   �� 5      -   5        $
��Next��5      6$   �� 5      -   5        $	��End��5      6#   �� 5      -	   5        $��	LoadAudio��5      $
��Load��6>   5       �� 5!   
   $��153,0,0.333,-0.333q�6   .+�5"      �� -
   5         ��Name$ SongsListBox��5"      $	��292��6,   $��0,57,37.333,0q�69   6P   �� 5#      -   5         ��Name$ Current��5#      $��Now Playing:��6%   6>   �� 5$      -   5         ��Name$ CurrentSong��5$      	 �� 
IsReadOnly	 . $	��180��6=   $��0,0,44,0q�6I   $��20��6[   5%      5&      5'      