   M S B A M L   `   `   `  ����>  :LAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LABLAB  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       LAB.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:LAB     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   -   5          �Name$  
mainWindow��5   ?    � Title$ EzChat v1337��5	   	   $��471.951��6   $	��800��6/   ��5
      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6    � Offset$ 0.573Q�6)   � 5      $ White��6   5       � 	Resources 5         ImageTemplate �� Path  TextTemplate   LAB.ChattTemplateSelector  ChattTemplateSelector��%�  &	        &	 �     &	 �    �� 5   
   .R�5      �� .��5      �� .+�5      �� ��6    �� $	 Who��� 5      $	��200��6   $	��200��6(   $
��Fill=�65   ��6D   �� $ Source�6e   5      5      5      �� 5   
   .R�5      �� .��5      �� .+�5      �� ��6    �� $	 Who��� 5      $	��500��6    $
��Wrap=�6G   ��6,   �� $
 Data�6G   5      5      5         5!   
   6'   5"      .��5#      � 
�������.+�5$   
   �� -   5         ��Name$ sendRequest��5$      $��Add Connection��6&   $
��Left=�6?   $��	22,25,0,0q�6Z   $	��Top=�6m   $	��164��6�   $��19��6�   
���   �{�.  ���	#FFDDDDDD6�   � 5'   
   -   5        	 �Name$	 
listenGrid��5'      $
��Left=�6#   $��72��6>   $��	0,331,0,0q�6J   $	��Top=�6]   $	��331��6u   .+�5(      �� -   5        $ startListen��5(      $��Start Chatting��6*   $
��Left=�6C   $��
234,31,0,0q�6^   $	��Top=�6r   $��88��6�   $��24��6�   
���   �5*      �� 5+      -   5        
 ��Name$
 portTbx��5+      $
��Left=�6'   $��23��6B   $��	103,3,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   
���   ����	#FFDDDDDD��6�   �� *
PortNumber+ �� Mode$ TwoWay=�6�   �� 5,      -   5        $
 userNametbx��5,      $
��Left=�6+   $��23��6F   $��
103,31,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $	��120��6�   
���   ����	#FFDDDDDD��6�   �� *
UserName+$ TwoWay=�6�   �� 5-      $��Port-nr:��6   $
��Left=�6'   $	��Top=�6B   $��10,3,0,0q�6Z   $��76��6l   $��23��6w   
���   �6�   �� 5.      $��	Username:��6   $
��Left=�6(   $	��Top=�6C   $��	10,31,0,0q�6[   $��76��6n   $��23��6y   
���   �6�   5/      � 50   
   -   5        $	 	chattGrid��50      $
��Left=�6"   $	��415��6=   $��	22,10,0,0q�6J   $	��Top=�6]   $	��766��6u    � ColumnDefinitions 51      �� 52      $
��224* �6#   �� 53      $	��31* �6#   �� 54      $
��197* �6#   .+�56      �� -   5         ��Name$ chattBox��56      $
��Left=�6(   $	��301��6C   $��174,0,0,104q�6P   ��. $��Bottom=�6�   $	��582��6�   
���   �$��3��6�    J� IsHitTestVisible . #��[ 6#  ���	#FFDDDDDD��6�   �� $ CurrentChatMessages���57      �� 58       �� 
TargetType" ��6   .�59      ��  �� Property � |� �� Value .  66   5:      5<      �� 5=      -	   5        $
 chattTextBox��5=      $
��Left=�6,   $��74��6G   $��174,321,0,0q�6S   $
 Wrap=�6h    �� AcceptsReturn . $	��Top=�6�   $	��469��6�   
���   �$��3��6�   ���	#FFDDDDDD6�   �� 5>      -
   5        $ sendMessage��5>      $
��Send��6*   $
��Left=�69   $��221.465,321,0,0q�6T   $	��Top=�6m   $	��103��6�   $��34��6�   
���   �$��2��6�   ���	#FFDDDDDD6�   �� 5?      -   5        $ 	sendImage��5?      $��
Send Image��6(   $
��Left=�6=   $��221.465,360,0,0q�6X   $	��Top=�6q   $	��103��6�   $��35��6�   
���   �$��2��6�   ���	#FFDDDDDD6�   5@      �� 5A   
   -   5        $ viewHistoryBtn��5A      $��View History��6)   $
��Left=�6@   $��	22,64,0,0q�6[   $	��Top=�6n   $	��164��6�   $��19��6�   
���   ����	#FFDDDDDD6�   5D      5E      