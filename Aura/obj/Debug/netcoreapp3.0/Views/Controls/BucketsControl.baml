   M S B A M L   `   `   `  ����?  ;Aura, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Aura.Views.ControlsAura.Views.Controls  5      I)clr-namespace:Aura.Common.ValueConvertersAura.Common.ValueConverters  5      ;"clr-namespace:Aura.ViewModels.BaseAura.ViewModels.Base  5      (    "Aura.Views.Controls.BucketsControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0898x,http://schemas.microsoft.com/winfx/2006/xaml    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      1local!clr-namespace:Aura.Views.Controls    5      CValueConverters)clr-namespace:Aura.Common.ValueConverters    5      =ViewModelLocator"clr-namespace:Aura.ViewModels.Base    5      2   ,Aura.ViewModels.Base.DynamicViewModelLocator    IsAutomaticLocator$
  True��5       � 	Resources 5      >   8Aura.Common.ValueConverters.TempBucketNameValueConverter    TempBucketNameValueConverter��%   &	          5   
   67   5      .��5      � .+�5   
   �� $��Buckets��6   
����iA�$
��Left=�69   $��30(�6T   $��Center=�6b   $��Center=�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��0q�6�   $	��798��6�   �� 5   
   $	��329��6S   $��
10,88,15,0q�6`   $	��Top=�6t   ��6   �� *	Buckets+ �� SelectedItem 63   �� *Bucket+��5      �� 5      .R�5      � .+�5      �� $��Name: ��6$   �� 5      $
��Bold"�6s   ��6$   �� *Name+ �� 	Converter# [  6s   5      5      5      �� 5   
     PrimaryButton#��[ 6   $	��New��68   $
��Left=�6i   $��
716,57,0,0q�6�   $	��Top=�6�   $��67��6�   $��26��6�   ��6F   �� *NewBucketClick+6�   �� 5   
     DangerButton#��[ 6   $��Delete��67   $
��Left=�6H   $��
10,422,0,0q�6c   $	��Top=�6w   $��58��6�   $��26��6�   �� 5   
     SecondaryButton#��[ 6   $
��Edit��6:   $
��Left=�6I   $��725,422,0,0q�6d   $	��Top=�6y   $��58��6�   $��26��6�   5      5      