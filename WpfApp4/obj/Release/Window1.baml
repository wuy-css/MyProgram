   M S B A M L   `   `   `  ???? B  >WpfApp4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp4WpfApp4      WpfApp4.Window1   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp4       ? Title$  Window1??$	??450??$	??800?? ? 	Resources  ?? 
TargetType ?? Property ?? Value ?? 
TargetType ?? 
Background ?? Bullet A?Name'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard ?? TargetProperty ?? 
TargetName R? KeyTime  System.Windows.Visibility   Visible R? Value ?? RelativeSource?? %?  '	?       ?? " 	?.???  ?@J?SnapsToDevicePixels . ??  ? ?? ?? " 	?.R??? 
 ????  ? $??13??$??13??.+?A? $ Border??
???  ??
?????? $??1??A? $ 	CheckMark??
??? ? ?$??4q?$y?	Collapsed=?	   CheckStates??.
   Checked??. ?? .??T? $ (UIElement.Visibility)?$ 	CheckMark??..?i? $ 0??# Z   	Unchecked??  Indeterminate??._??? ???? *	Content+ ?? *TemplatedParent+.??? .+?? .+???  ?? Orientation$ 
Horizontal=?$??20??.+?	? -    	?Name$	 rbA??$??选项_A??	? -   $	 rbB??$??	选项__B??