   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GroupProject.ItemsGroupProject.Items  5   	   !    GroupProject.Items.wndItems   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:GroupProject.Items     5   	     � Title$  Edit Items Window��5   	   $	��450��6#   $	��800��60   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGEditItems��5
      $
��Left=�6(   $	��269��6C   $��
10,140,0,0q�6P   $	��Top=�6d   $	��377��6|   6�   �� 5   
   -   5         ��Name$ LblTitle��5      $6��0Add, delete, or Edit Items in the datagrid below��6"   $
��Left=�6]   $��	10,10,0,0q�6x   $	��Top=�6�   $��37��6�   $	��472��6�   $��20(�6�   �� 5   
   -   5         ��Name$ 	BtnDelete��5      $��Delete Item��6$   $
��Left=�6:   $��409,272,0,0q�6U   $	��Top=�6j   $	��130��6�   $��35��6�   6�   �� 5   
   -   5        $ BtnAdd��5      $��Add Item��6!   $
��Left=�64   $��409,214,0,0q�6O   $	��Top=�6d   $	��130��6|   $��35��6�   6�   �� 5   
   -   5        $ BtnEdit��5      $��	Edit Item��6"   $
��Left=�66   $��409,330,0,0q�6Q   $	��Top=�6f   $	��130��6~   $��35��6�   6�   �� 5   
   -   5         ��Name$ txtItemCode��5      $
��Left=�6'   $��23��6B   $��592,200,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $��Enter Item Code��6w   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtItemDesc��5      $
��Left=�6'   $��23��6B   $��592,226,0,0q�6N   $
 Wrap=�6c   $��Enter Item Description��6w   $	��Top=�6�   $	��168��6�   �� 5   
   -   5        $ txtItemCost��5      $
��Left=�6'   $��34��6B   $��592,254,0,0q�6N   $
 Wrap=�6c   $*��$Enter Item Cost(without dollar sign)��6w   $	��Top=�6�   $	��168��6�   �� 5   
   -	   5        $ 
LblNewItem��5      $��Enter New Item��6$   $
��Left=�6=   $��592,157,0,0q�6X   $	��Top=�6m   �� 5   
   -
   5        $ BtnItemSubmit��5      $��Submit new item��6(   $
��Left=�6B   $��619,315,0,0q�6]   $	��Top=�6r   $	��141��6�   6�   5      5      