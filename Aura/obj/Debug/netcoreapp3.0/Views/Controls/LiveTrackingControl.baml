   M S B A M L   `   `   `  ����?  ;Aura, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Aura.Views.ControlsAura.Views.Controls  5      I)clr-namespace:Aura.Common.ValueConvertersAura.Common.ValueConverters  5      ;"clr-namespace:Aura.Common.BehaviorAura.Common.Behavior  5      ;"clr-namespace:Aura.ViewModels.BaseAura.ViewModels.Base  5	      -    'Aura.Views.Controls.LiveTrackingControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0898x,http://schemas.microsoft.com/winfx/2006/xaml    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      1local!clr-namespace:Aura.Views.Controls    5      CValueConverters)clr-namespace:Aura.Common.ValueConverters    5      5Behavior"clr-namespace:Aura.Common.Behavior    5      =ViewModelLocator"clr-namespace:Aura.ViewModels.Base    5	      2   ,Aura.ViewModels.Base.DynamicViewModelLocator    IsAutomaticLocator$
  True��5      .��5      �  � 	Resources 5   
    �� 
TargetType �� Triggers P� Property P� Value �� Property �� ValueE   ?Aura.Common.ValueConverters.PropertyHasValueVisibilityConverter '  #PropertyHasValueVisibilityConverterH   BAura.Common.ValueConverters.PropertyHasValueInvertedValueConverter * &PropertyHasValueInvertedValueConverterE   ?Aura.Common.ValueConverters.ClockPeriodTimeActiveValueConverter ' #ClockPeriodTimeActiveValueConverterK   EAura.Common.ValueConverters.ClockPeriodReadableTimeSpanValueConverter - )ClockPeriodReadableTimeSpanValueConverterF   @Aura.Common.ValueConverters.StringEqualsVisibilityValueConverter ( $StringEqualsVisibilityValueConverter��%�  '��       &	  �     &	     &	 $    &	 7    &	 J    �� 5      " ��6    5      P� 5       �@��AlternationIndex$ 0��6H   . �5      ��  � ��
 ���� 67   5      P� 5       �@��AlternationIndex$ 1��6H   . �5      ��  � �� �#ededed67   5      5        5      6B     5      6E     5      6B     5      6H     5      6C   5      .+�5    
   ��   
IconButton#��[ 6     ListFiltering#��[ 65   $y�Visible=�6�   $	��Top=�6�   $
��Left=�6�   $��	81,40,0,0q�6�   $��30��6�   ��6^   �� *ShowListViewClick+6�   �� 5!   
   #��[ 6     GridFiltering#��[ 65   $y�Visible=�6�   $	��Top=�6�   $
��Left=�6�   $��
116,40,0,0q�6�   $��30��6�   ��6^   �� *ShowDataGridClick+6�   �� 5"   
   $��10,70,15,10q�6<    %� 
ScrollUnit$ Pixel=�6Q   	 �� AlternationCount$	 2��6v   ��6   �� *ProcessClockings+y�6�   �� *ListViewVisibility+��5#      �� 5$      .R�5%      � .+�5&      �� $��10q�6%   .+�5'      �� $��Name: ��6$   �� 5(      $
��Bold"�6F   ��6$   �� *Process.Title+6F   5)      �� 5*      $��10q�6&   .+�5+      �� $��Time: ��6$   �� 5,      $
��Bold"�6�   ��6$   �� *ClockPeriod+
 �� Mode$
 OneWay=� �� 	Converter# [ 6�   5-      �� 5.      $��10q�6&   .+�5/      �� $��Active Time: ��6$   �� 50      $
��Bold"�6�   ��6$   �� *ClockPeriod+$
 OneWay=�# [ 6�   51      52      53      55      &   System.Windows.Controls.DataGrid  56   
   $��10,70,15,10q�63      AutoGenerateColumns$ False��6H      
IsReadOnly$
 True��6d   $ Pixel=�6v   ��6   �� *	Rollups+y�6�   �� *DataGridVisibility+   Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Process Name��6%    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 150
 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *ProcessName+6[     59      $ 
Is Running��6%    69   �� *	IsRunning+  5:      $ 	Is Active��6%    68   �� *
IsActive+  5;      $ 
Total Time��6%    69   �� *	TotalTime+$
 OneWay=�  TimeSpanValueConverter# [    RowDetailsTemplate 5=      �� 5>      .R�5?      �� $	 2��6A   ��6   �� *	Processes+��5@      �� 5A      .R�5B   "   � .+�5C   &   ��  �� Padding$ 10, 5, 10, 5q�6-   ._�5D   *   �� .+�5E   .   �� $��Name:��68   �� 5F   .   $
��Bold"�6M   ��68   �� *Key+6M   5G   +   5H   '   �� 5J   &   $ 10, 5, 10, 5q�6-   ._�5K   *   �� .+�5L   .   �� $��Bucket:��68   �� 5M   .   .+�5N   2   �� y�6=   �� *Bucket.Name+# [ .+�5O   6   �� $
��Left=�6=   $��60��6X    	 SuccessButton#��[	 6c   $��Assign��6  ��6�   �� *DataContext.AssignBucketClick+ �� RelativeSource ��  �� AncestorType local:LiveTrackingControl6  5P   3   �� 5Q   2   y�6=   �� *Bucket.Name+# [  .+�5R   6   �� $
��Left=�6<   ��6W   �� *Name+5S   3   5T   /   5U   +   5V   '   �� 5X   &   $ 10, 5, 10, 5q�6-   ._�5Y   *   �� .+�5Z   .   �� $��Start:��68   �� 5[   .   $
��Bold"�6S   ��68   �� *	StartTime+6S   5\   +   5]   '   �� 5_   &   $ 10, 5, 10, 5q�6-   ._�5`   *   �� .+�5a   .   �� $��
Is Active:��68   �� 5b   .   $
��Bold"�6R   ��68   �� *
IsActive+6R   5c   +   5d   '   �� 5f   &   $ 10, 5, 10, 5q�6-   ._�5g   *   �� .+�5h   .   �� $��Is Running:��68   �� 5i   .   $
��Bold"�6S   ��68   �� *	IsRunning+6S   5j   +   5k   '   �� 5m   &   $ 10, 5, 10, 5q�6-   ._�5n   *   �� .+�5o   .   �� $��Time Active: ��68   �� 5p   .   $
��Bold"�6�   ��68   �� *TotalTimeActive+# [ 6�   5q   +   5r   '   5s   #   5t      5v      5w      5y      �� 5{   
   #��[	 6   $��Resume��68   $	��Top=�6�   $��Right=�6�   $��73��6�   y�6I   �� *ResumeButtonVisibility+��6w   �� *ResumeClick+6�   �� 5|   
    
 DangerButton#��[
 6   $��Suspend��67   $	��Top=�6�   $��Right=�6�   $��73��6�   y�6I   �� *SuspendButtonVisibility+��6x   �� *SuspendClick+6�   �� 5}   
   $��Live Tracking��6   
����iA�$
��Left=�6?   $��30(�6Z   $
��Left=�6h   $��Center=�6�   $	��Top=�6�   $��10, 0, 0, 0q�6�   $	��444��6�   5~      5      