   M S B A M L   `   `   `  ????B  >WpfApp4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp4WpfApp4  5   	       WpfApp4.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp4     5   	     ? Title$  Window1??5   	   $	??450??6   $	??800??6&    ? 	Resources 5	       ?? 
TargetType ?? Property ?? Value ?? 
TargetType ?? 
Background ?? Bullet A?Name'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard ?? TargetProperty ?? 
TargetName R? KeyTime  System.Windows.Visibility   Visible R? Value ?? RelativeSource?? 5
   
   %6  '	?       ?? 5      " 	?61   .?5      ??  ?@J?SnapsToDevicePixels . 68   ?? 5       ? ?? 5      ?? 5      " 	?6*   .R?5      ?? 
 ????  5   "   ? 5   &   $??13??6+   $??13??66   .+?5   *   A? $ Border??62   
???  ??
?????? $??1??6c   A? 5   *   $ 	CheckMark??62   
??? ? ?$??4q?6R   $y?	Collapsed=?6]   5   '   	 5   "     5   &   CheckStates??.
 5   *     Checked??. 5   .   ?? .??5   2   T? $ (UIElement.Visibility)?6P   $ 	CheckMark??5   2   ..?5   6   i? $ 0??6M   # Z 5   -   5    3   5!   /   5"   +     5#   *   	Unchecked??66     5$   *   Indeterminate??66   5%   '   ._?5'   "   ?? ??6,   ?? *	Content+ ?? *TemplatedParent+6w   5(      5)      5+      5,      5-      .??5/      ? .+?51   
   ? .+?52      ??  ?? Orientation$ 
Horizontal=?6   $??20??62   .+?53      	? -   5         	?Name$	 rbA??53      $??选项_A??6+   6<   	? 54      -   5        $	 rbB??54      $??	选项__B??6+   6=   55      56      59      5:      