   M S B A M L   `   `   `  ����?  ;Aura, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Aura.Modals.ControlsAura.Modals.Controls  5      I)clr-namespace:Aura.Common.ValueConvertersAura.Common.ValueConverters  5      +    %Aura.Modals.Controls.AddBucketControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0898x,http://schemas.microsoft.com/winfx/2006/xaml    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      2local"clr-namespace:Aura.Modals.Controls    5      CValueConverters)clr-namespace:Aura.Common.ValueConverters    5        � DataContext  5
      ��    ViewModelLocator �� Source# [   �� Path$ AddBucketControl� � 	Resources 5      J   DAura.Common.ValueConverters.WhenRuleItemTypeVisibilityValueConverter , (WhenRuleItemTypeVisibilityValueConverterJ   DAura.Common.ValueConverters.ThenRuleItemTypeVisibilityValueConverter , (ThenRuleItemTypeVisibilityValueConverterK   EAura.Common.ValueConverters.BucketRuleHasRuleVisibilityValueConverter - )BucketRuleHasRuleVisibilityValueConverterM   GAura.Common.ValueConverters.BucketRuleHasNoRuleVisibilityValueConverter / +BucketRuleHasNoRuleVisibilityValueConverter  NoHeader �� 
TargetType �� Property �� Value  WhenThenLabel �� 
TargetType �� Padding	 J� SnapsToDevicePixels
 �� CornerRadius �� Triggers P� Property P� Value  CircleAddButton ��Name �� Triggers  RuleItem �� 	Converter �� Left
 �� Top �� SelectedValue �� RelativeSource �� AncestorType 	 TextBox 
 DangerButton �� Right �� Mode��%�  &	       &	      &	 &     &	 9     &	 L     &	 �     &	 B    &	 u    7  7 	 7 
 7  7  7  7  7 
   5   
   6C     5   
   6C     5   
   6D     5   
   6F   �� 5   
   " ��6!   .�5      ��  � y�$ 	Collapsed=�6+   5      �� 5   
   " ��6'   .�5      ��  � ��$ Center=�6;   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6M   #��z��6�   # z��6�   $
	 true��6�   $
 3��6�   ._�5      �� #��z��6/   $
��True��6r   #	 z	 6�   #��z��6�   5       5      P� 5       � {�$ false��6;   . �5   "   �� # � ��6?    � ��5      5       5"      5#      �� 5$   
   " ��6   .�5%      ��  � ��
 ���� 6+   �� 5&       � �� �#0040856+   �� 5'       � ��$ Center=�6;   �� 5(       � ��$ Center=�69   �� 5)       � ��$ 0q�6(   �� 5*       � ��$ 30��6&   �� 5+       � ��$ 30��6'   �� 5,       � ��$ 14(�6)   �� 5-       �@��TextAlignment$ Center=�68   �� 5.       � �� 5/      �� 50      " ��6&   .R�51      �� $
 30,30,30,30��6!   #��z��6<   #��z��6f   $��3q�6�   ._�52      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6  53      54      56       57      P� 58       �@J�IsMouseOver$
 True��61   . �59      ��  � ��
 ��ح�64   �� 5:       �@�Cursor$
 Hand��6/   5;      5=      �� 5>   
   .R�5?      �� $	��110��6   $	��700��6&   .+�5@      �� y�6   �� *RuleItemType+8   .+�5A      �� 
����iA�$��3q�65   $��	0, 5, 0 5q�6I   $
 40,40,40,40��6\   ._�5B      � .+�5C      �� $
��When��6$   $��Center=�63   $��Center=�6W   $��62��6y   $��50, 0, 0, 0q�6�   $��20(�6�   
����iA�
�������6�   �� 5D      $	��580��6%   $��60��61   .+�5E   "   �� $��Rule:��6(   $	��Top=�68   $ 10��6P   $
��Left=�6a   �� 5F   "   $	��Top=�6�   $
��Left=�6�   $ 26��6�   $ 10��6	  $	��200��6  $��26��6)   6+   �� *
RuleName+��6O   �� *DataContext.WhenRuleNames+ ��  local:AddBucketControl6)  �� 5H   "   $��	Property:��6(   $	��Top=�6<   $	 215��6T   $
��Left=�6f   �� 5I   "   $	��Top=�6�   $
��Left=�6�   $ 26��6   $	 215��6  $	��130��6"  $��26��61  $	��117��6=   6+   �� *PropertyName+��6R   �� *DataContext.WhenPropertyNames+ ��  local:AddBucketControl6=  �� 5K   "   $��Value:��6(   $	��Top=�69   $	 350��6Q   $
��Left=�6c   �� 5L   "   8�� $	��Top=�6K   $
��Left=�6z   $ 26��6�   $	 350��6�   $	��150��6�   $��26��6�   $	��160��6�   ��6c   �� *Value+6�   �� 5M   "   8�� $��Delete��6�   $��Center=�6�   $��Right=�6�   $ 25��6  $ 15��6  $	 515��6(  y�6O   �� *Rule+$ OneWay=�8  6(  5N      5O      5P      �� 5Q      8�� $��+��6�   $��Center=�6�   $��
0, 0, 0, 0q�6�   y�6F   �� *Rule+$ OneWay=�8  6�   5R      �� 5S      y�6   �� *RuleItemType+8  .+�5T      �� 
���"�"�$��3q�67   $��	0, 5, 0 5q�6K   $
 40,40,40,40��6^   ._�5U      � .+�5V      �� $
��Then��6$   $��Center=�63   $��Center=�6W   $��62��6y   $��50, 0, 0, 0q�6�   $��20(�6�   
���"�"�
�������6�   �� 5W      $	��580��6%   $��60��61   .+�5Y   "   �� $��Action:��6(   $	��Top=�6:   $ 10��6R   $
��Left=�6c   �� 5Z   "   $	��Top=�6+   $
��Left=�6C   $ 26��6^   $ 10��6n   $	��150��6   $��26��6�   �� 5\   "   8�� $��Delete��6O   $��Center=�6`   $��Right=�6{   $ 25��6�   $ 15��6�   5]      5^      5_      5`      5a      5b      5d      .��5e      � .+�5f   
   �� $��Name:��6   $��Right=�6    $
��Left=�6C   $��0,43,0,0q�6^   $	��Top=�6p   $��93��6�   �� 5g   
   #��[	 6   $
��Left=�63   $��26��6N   $��	93,43,0,0q�6Z    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��228��6�   ��6�   �� *	Item.Name+6�   �� 5h   
   $��Rule Creator��6   $
��Left=�6'   $��0,90,0,0q�6B   $��26(�6T   $��Center=�6b   $	��Top=�6�   $	��800��6�   �� 5i   
   #��[ 65   
������ $��0q�6w   $
��Left=�6�   $��Center=�6�   $	��305��6�   $��
10,135,0,0q�6�   $	��Top=�6�   $	��780��6  ��6   �� *
Item.Rules+6  �� 5j   
   $��Bucket Information��6   $
��Left=�6-   $��0,-2,0,0q�6H   $��26(�6Z   $��Center=�6h   $	��Top=�6�   $	��800��6�   �� 5k   
     SuccessButton#��[ 6   $
��Save��6V   $
��Left=�6e   $��700,415,0,0q�6�   $	��Top=�6�   $��75��6�   ��68   �� *	SaveClick+6�   �� 5l   
   #��[
 6   $��Cancel��67   $
��Left=�6H   $��010,415,0,0q�6c   $	��Top=�6x   $��75��6�   5m      5n      