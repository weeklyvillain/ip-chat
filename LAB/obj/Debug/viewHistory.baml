   M S B A M L   `   `   `  ����>  :LAB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LABLAB  5   	       LAB.viewHistory   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:LAB     5   	     � Title$  viewHistory��5   	   $	��450��6   $	��800��6*    � 	Resources 5
         ImageTemplate �� Path  TextTemplate   LAB.ChattTemplateSelector  ChattTemplateSelector��%�  &	        &	 �     &	 �    �� 5   
   .R�5      �� .��5      �� .+�5      �� ��6    �� $	 Who��� 5      $	��200��6   $	��200��6(   $
��Fill=�65   ��6D   �� $ Source�6e   5      5      5      �� 5   
   .R�5      �� .��5      �� .+�5      �� ��6    �� $	 Who��� 5      $	��500��6    $
��Wrap=�6G   ��6,   �� $
 Data�6G   5      5      5        5   
   6'   5      .��5      � .+�5   
   �� -   5         ��Name$ UsersBox��5      $
��Left=�6$   $	��370��6?   $��	10,39,0,0q�6L   $	��Top=�6_   $	��203��6w   ���	#FFDDDDDD��6�   �� $ UserList�6�   �� 5   
   -   5        $ chattBox��5      $
��Left=�6$   $	��399��6?   $��
218,10,0,0q�6L   $	��Top=�6`   $	��564��6x   #��[ 6�   ���	#FFDDDDDD��6�   �� $ oldChatMessages�6�   �� 5    
   -   5         ��Name$ 	searchBar��5       $
��Left=�6%   $��23��6@   $��	10,10,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��136��6�   ���	#FFDDDDDD��6�   �� *
searchText+ �� Mode$ TwoWay=�6�   �� 5!   
   -   5         ��Name$ searchButton��5!      $��Search��6'   $
��Left=�68   $��
151,10,0,0q�6S   $	��Top=�6g   $��62��6   $��23��6�   6�   5#      5$      