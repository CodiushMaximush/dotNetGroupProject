   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GroupProject.SearchGroupProject.Search  5   	   #    GroupProject.Search.wndSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GroupProject.Search     5   	     � Title$  Search��5   	   $	��450��6   $	��800��6%   .��5	      � .+�5
   
   �� $��Invoices��6   $��10,52,405,10q�6%   .��5      �� -   5        $��InvoicesDataList��5       �� SelectionMode$ Single=�6/   ��.   �� View 5      �� 5       �� AllowsColumnReorder .  .P�5      �� $��Invoice Number��6)    �� Width$	 100��6A    �� DisplayMemberBinding 6M   �� *Num+�� 5      $
��Date��6)   $	 100��67    6C   �� *Date+�� 5      $��
Total Cost��6)   $	 100��6=    6I   �� *	TotalCost+5      5      5      �� 5   
   -   5        $��lblTitle��5      
���   �$ ��Filter and Select Invoices��63   $
��Left=�6X   $��	10,10,0,0q�6s   $	��Top=�6�   $��37��6�   $	��472��6�   $��20(�6�   �� 5   
   -   5         ��Name$ btnSelectInvoice��5      $��Select Invoice��6+   $
��Left=�6D   $��409,330,0,0q�6_   $	��Top=�6t   $	��130��6�   $��35��6�   6�   �� 5   
   -   5        $ btnClearSearch��5      $��Clear Search��6)   $
��Left=�6@   $��600,330,0,0q�6[   $	��Top=�6p   $	��130��6�   $��35��6�   6�   �� 5   
   $��Search Controls��6   $
��Left=�6,   $	��315��6G   $��
392,10,0,0q�6T   $	��Top=�6h   $	��390��6�   .��5      �� $��16q�6   .+�5      �� 
���   �.��6+   Select Invoice Number:6C   �� 5      -   5        $��cbInvoiceNumber��5      6i   �� 5      $��16q�6   6'   �� 5      
���   �.��6+   Select Invoice Date:6A   �� 5!      -   5        $��cbInvoiceDatePicker��5!      6p   �� 5"      $��16q�6   6'   �� 5$      
���   �.��6+   Select Total Charges:6B   �� 5%      -   5        $��cbTotalCharges��5%      6g   5&      5'      5(      5)      