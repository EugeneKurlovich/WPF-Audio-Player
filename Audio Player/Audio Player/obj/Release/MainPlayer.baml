   M S B A M L   `   `   `  ���� G  CAudio Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Audio_PlayerAudio_Player  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms     Audio_Player.MainPlayer   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  &localclr-namespace:Audio_Player  Iwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms  -     �Name$  Form1�� � Title$ Music Player��$��707.79��$��1056.291�� � WindowStartupLocation$ CenterScreen=�
������� � 
ResizeMode$ NoResize=� � Icon$ res/Music.png�����	#FFD10606 J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ local:MainPlayer.com1��  -   $ local:MainPlayer.com��  -   $ local:MainPlayer.com2��  -   $ local:MainPlayer.com3��  -   $ local:MainPlayer.com4�� J� InputBindings �� 
 �� Key$ Space��	 �� 	Modifiers$	 Shiftf�
 �� Command$
 local:MainPlayer.com1���� $ Space��$
 local:MainPlayer.com���� $ Z��$
 local:MainPlayer.com2���� $ X��$
 local:MainPlayer.com3���� $ S��$
 local:MainPlayer.com4��.��� $��10,0,4,5q�.+�o� $
��Left=�$	��540��$��-10,0,0,633q�
�������.@�m� -    m�Name$
 Save��$��82��$��32��$��File ��$��Center=�$��Center=� J� RenderTransformOrigin$ 0.786,0.444&�.@�m� -   $��Add Song��m� -	   $��Add Directory��m� -
   $��Load Play List��m� -   $��Save Play List��m� -   $��96��$��32��$
��User��$��Center=�$��Center=�$ 0.984,0.562&�.@�m� -   $��Choose User��m� -   $��Info about Developer���� -    ��Name$ button1��$�� ��$
��Left=�$��233,624,0,0q�$	��Top=�$��42������  �� ImageSource$ res\Pause.png���� -   $ button2��$�� ��$
��Left=�$��
83,624,0,0q�$	��Top=�$��44������ $ res/Prev.png���� -   $ button3��$�� ��$
��Left=�$��133,624,0,0q�$	��Top=�$��44������ $ res/Stop.png���� -   $ button4��$�� ��$
��Left=�$��281,624,0,0q�$	��Top=�$��44������ $ res/Next.png���� -   $ button5��$�� ��$
��Left=�$��183,624,0,0q�$	��Top=�$��44�����	#FF673AB7���� $ res/Play.png���� -    ��Name$ slider��$
��Left=�$��
35,600,0,0q�$	��Top=�$	��378���� -   $ slider1��$
��Left=�$��435,600,0,0q�$	��Top=�$��80�� � Maximum$	 100Q� � Value$	 100Q��� -    ��Name$ label��$��00.00.00��$
��Left=�$��
37,580,0,0q�$	��Top=�$��60���� -   $ label1��$��00.00.00��$
��Left=�$��353,580,0,0q�$	��Top=�$��60���� -   $ label2��$�� ��$
��Left=�$��	8,183,0,0q�$	��Top=�$ 0.947,-0.038&��� -   $ label4��$	��100��$
��Left=�$��455,586,0,0q�$	��Top=�$ 0.172,0.308&�$��32���� -   $ label5��$��0��$
��Left=�$��419,594,0,0q�$	��Top=�$ 
0.25,0.667&�$��16���� -   $ label6��$	��100��$
��Left=�$��511,594,0,0q�$	��Top=�$��30���� -   $ button7��$��Clear��$
��Left=�$��
756,14,0,0q�$��80��$ 0.08,-0.312&�$��32��$	��Top=��� -   $ button11��$
��Like��$
��Left=�$��
676,14,0,0q�$	��Top=�$��75���� -   $ label3��$�� ��$
��Left=�$��102,580,0,0q�$	��Top=�$ 	0.2,0.808&��� -   $ label7��$�� ��$
��Left=�$��217,579,0,0q�$	��Top=��� -    $ button12��$�� ��$
��Left=�$��455,623,0,0q�$	��Top=�$��44������ $ 
res/NV.png���� -!   $ button��$��Refresh��$
��Left=�$��
841,14,0,0q�$	��Top=�$��80��$��32��� $
��Left=�$	��523��$��8,51,0,0q�$	��Top=�$
��1028��.+�7  1System.Windows.Forms.Integration.WindowsFormsHost  $��
0,10,495,5q�   
Background �	#FF673AB7   Child. %  System.Windows.Forms.PictureBox  -"   pb��&   System.Windows.Controls.DataGrid  -#     Name$ 	DataGridd��   AutoGenerateColumns . $
��Left=�$��538,10,0,-91q�$	��Top=�$	��604��$	��469�����	#FF673AB7���	#DDFFFFFF� $
��Left=�$��42��$��
538,15,0,0q�$	��Top=�$	��442��.+�(  "MaterialDesignThemes.Wpf.RatingBar  -$     Name$ stars��   Value$ 1��$��
10,0,303,0q��� -%   $ button6��$��Delete��$
��Left=�$��
926,14,0,0q�$	��Top=�$��81��$��32��