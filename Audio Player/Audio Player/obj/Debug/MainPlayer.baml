   M S B A M L   `   `   `  ����G  CAudio Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Audio_PlayerAudio_Player  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	       Audio_Player.MainPlayer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   &localclr-namespace:Audio_Player  5   	   Iwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms  5   	   -   5          �Name$  Form1��5   	    � Title$ Music Player��5
   	   $��707.79��6   $��1056.291��6.    � WindowStartupLocation$ CenterScreen=�6?   
������� � 
ResizeMode$ NoResize=�6w    � Icon$ res/Music.png��5   	   ���	#FFD10606 J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ local:MainPlayer.com1��5      6:     5   
   -   5        $ local:MainPlayer.com��5      69     5   
   -   5        $ local:MainPlayer.com2��5      6:     5   
   -   5        $ local:MainPlayer.com3��5      6:     5   
   -   5        $ local:MainPlayer.com4��5      6:    J� InputBindings 5      �� 5   
   
 �� Key$ Space��6   	 �� 	Modifiers$	 Shiftf�6!   
 �� Command$
 local:MainPlayer.com1��63   6V   �� 5   
   $ Space��6   $
 local:MainPlayer.com��6!   6C   �� 5   
   $ Z��6   $
 local:MainPlayer.com2��6   6@   �� 5   
   $ X��6   $
 local:MainPlayer.com3��6   6@   �� 5   
   $ S��6   $
 local:MainPlayer.com4��6   6@   .��5#      � $��10,0,4,5q�6   .+�5$   
   o� $
��Left=�6   $	��540��6*   $��-10,0,0,633q�66   
�������.@�5%      m� -   5         m�Name$
 Save��5%   =   $��82��6   $��32��6"   $��File ��6.   $��Center=�6K   $��Center=�6i    J� RenderTransformOrigin$ 0.786,0.444&�6�   .@�5&      m� -   5        $��Add Song��5&      6-   m� 5'      -	   5        $��Add Directory��5'      62   m� 5(      -
   5        $��Load Play List��5(      63   m� 5)      -   5        $��Save Play List��5)      63   5*      m� 5+      $��96��6   $��32��6"   $
��User��6.   $��Center=�6=   $��Center=�6[   $ 0.984,0.562&�6v   .@�5,      m� -   5        $��Choose User��5,      60   m� 5-      -   5        $��Info about Developer��5-      69   5/      50      �� 51   
   -   5         ��Name$ button1��51      $�� ��6#   $
��Left=�6.   $��233,624,0,0q�6I   $	��Top=�6^   $��42��6v   ��52      �� 53       �� ImageSource$ res\Pause.png��6   55      �� 56   
   -   5        $ button2��56      $�� ��6"   $
��Left=�6-   $��
83,624,0,0q�6H   $	��Top=�6\   $��44��6t   ��57      �� 58      $ res/Prev.png��6   5:      �� 5;   
   -   5        $ button3��5;      $�� ��6"   $
��Left=�6-   $��133,624,0,0q�6H   $	��Top=�6]   $��44��6u   ��5<      �� 5=      $ res/Stop.png��6   5?      �� 5@   
   -   5        $ button4��5@      $�� ��6"   $
��Left=�6-   $��281,624,0,0q�6H   $	��Top=�6]   $��44��6u   ��5A      �� 5B      $ res/Next.png��6   5D      �� 5E   
   -   5        $ button5��5E      $�� ��6"   $
��Left=�6-   $��183,624,0,0q�6H   $	��Top=�6]   $��44��6u   ���	#FF673AB7��5F      �� 5G      $ res/Play.png��6   5I      �� 5J   
   -   5         ��Name$ slider��5J      $
��Left=�6!   $��
35,600,0,0q�6<   $	��Top=�6P   $	��378��6h   6t   �� 5K   
   -   5        $ slider1��5K      $
��Left=�6"   $��435,600,0,0q�6=   $	��Top=�6R   $��80��6j    � Maximum$	 100Q�6u    � Value$	 100Q�6�   6�   �� 5L   
   -   5         ��Name$ label��5L      $��00.00.00��6   $
��Left=�62   $��
37,580,0,0q�6M   $	��Top=�6a   $��60��6y   �� 5M   
   -   5        $ label1��5M      $��00.00.00��6    $
��Left=�63   $��353,580,0,0q�6N   $	��Top=�6c   $��60��6{   �� 5N   
   -   5        $ label2��5N      $�� ��6    $
��Left=�6+   $��	8,183,0,0q�6F   $	��Top=�6Y   $ 0.947,-0.038&�6q   �� 5O   
   -   5        $ label4��5O      $	��100��6    $
��Left=�6.   $��455,586,0,0q�6I   $	��Top=�6^   $ 0.172,0.308&�6v   $��32��6�   �� 5P   
   -   5        $ label5��5P      $��0��6    $
��Left=�6,   $��419,594,0,0q�6G   $	��Top=�6\   $ 
0.25,0.667&�6t   $��16��6�   �� 5Q   
   -   5        $ label6��5Q      $	��100��6    $
��Left=�6.   $��511,594,0,0q�6I   $	��Top=�6^   $��30��6v   �� 5R   
   -   5        $ button7��5R      $��Clear��6"   $
��Left=�62   $��
756,14,0,0q�6M   $��80��6a   $ 0.08,-0.312&�6l   $��32��6�   $	��Top=�6�   �� 5S   
   -   5        $ button11��5S      $
��Like��6#   $
��Left=�62   $��
676,14,0,0q�6M   $	��Top=�6a   $��75��6y   6�   �� 5T   
   -   5        $ label3��5T      $�� ��6    $
��Left=�6+   $��102,580,0,0q�6F   $	��Top=�6[   $ 	0.2,0.808&�6s   �� 5U   
   -   5        $ label7��5U      $�� ��6    $
��Left=�6+   $��217,579,0,0q�6F   $	��Top=�6[   �� 5V   
   -   5        $ button12��5V      $�� ��6#   $
��Left=�6.   $��455,623,0,0q�6I   $	��Top=�6^   $��44��6v   ��5W      �� 5X      $ 
res/NV.png��6   5Z      �� 5[   
   -    5        $ button��5[      $��Refresh��6!   $
��Left=�63   $��
841,14,0,0q�6N   $	��Top=�6b   $��80��6z   $��32��6�   � 5\   
   $
��Left=�6   $	��523��6*   $��8,51,0,0q�67   $	��Top=�6I   $
��1028��6a   .+�5]      7  1System.Windows.Forms.Integration.WindowsFormsHost  $��
0,10,495,5q�6      
Background �	#FF673AB7   Child. 5^      %  System.Windows.Forms.PictureBox  -!   5        pb��5^       5_      &   System.Windows.Controls.DataGrid  5`      -"   5          Name$ 	DataGridd��5`         AutoGenerateColumns . $
��Left=�6�   $��538,10,0,-91q�6�   $	��Top=�6�   $	��604��6  $	��469��6  ���	#FF673AB7���	#DDFFFFFF6h  5b      � 5c   
   $
��Left=�6   $��42��6*   $��
538,15,0,0q�66   $	��Top=�6J   $	��442��6b   .+�5d      (  "MaterialDesignThemes.Wpf.RatingBar  -#   5          Name$ stars��5d   1      Value$ 1��6'   $��
10,0,303,0q�6@   5e      �� 5f   
   -$   5        $ button6��5f      $��Delete��6"   $
��Left=�63   $��
926,14,0,0q�6N   $	��Top=�6b   $��81��6z   $��32��6�   6�   5j      5l      