   M S B A M L   `   `   `  ????J  FDataTemlateDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DataTemlateDemoDataTemlateDemo  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	        DataTemlateDemo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:DataTemlateDemo     5   	   @c2clr-namespace:System.Collections;assembly=mscorlib     5   	     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)    ? 	Resources 5
       ?? 
TargetType ?? Property ?? Value ?? Triggers P? Property P? Value :? RoutedEvent	 g? Duration
 ?? TargetProperty	 W? To ?? BasedOn ?? 
TargetType ??Name J? SnapsToDevicePixels ?? CornerRadius ??Name ?? Triggers ?? 
TargetName ?? DataType   DataTemlateDemo.Unit ?? Orientation"  System.Collections.ArrayList   ds   Year   Price??%5  '??       '?? a    (?? @    5f      *, +)&	  3    ?? 5   
   " ??6   .?5      ??  ?@J?Opacity$	 0.5Q?6(   ?? 5        ? ??$ 75??6*    5"      P? 5#       ?@??
IsSelected .  ?5$      ?? 5%       ?@J?Opacity$	 1.0Q?64   5'      :? 5(      $ Mouse.MouseEnter??6   [?5)      ?? 5*      .??5+      ?? .??5,   "   W? $	 0:0:0.2D?5-      $
 	MaxHeight?5.      $ 90X?5/      50      51      53      :? 54      $ Mouse.MouseLeave??6   [?55      ?? 56      .??57      ?? .??58   "   W? $	 0:0:1D?59      $
 	MaxHeight?5:      5;      5<      5>      5@      ?? 5B   
   " ??6#    6   Z? .?5C      ??  ? ??# ? ??6+   ?? 5D       ? ??# ? ??6+   ?? 5E       ? ??$ 1q?60   ?? 5F       ? ??$ 1q?6(   ?? 5G       ?@J?	AllowDrop . 6*   ?? 5H       ?@?FocusVisualStyle 61   Z? ?? 5I       ?@??PanningMode$ VerticalFirst=?69   ?? 5J       ?@??IsFlicksEnabled .  67   ?? 5K       ? ?? 5L      ?? 5M      " ??6&   .R?5N      ?? $ Bd??6!   #??z??6-   #??z??6Y   #??z??6?    . $ 10??5O      ._?5P      ?? $ PART_ContentHost??6+   # z 6E   $??0 5 0 0q?6?   5Q       5R      P? 5S       ? {? .  . ?5T   "   ?? $ Bd??6?   # ? ??6O    ? ???? 5U   "   # ? ??6?    ? ??5V      P? 5W       ?@J?	IsFocused . . ?5X   "   ?? $ Bd??6?    ? ??
 ?  ??6O   5Z      5\      5^       5_      P? 5`       ?@J?IsMouseOver . . ?5a      ??  ? ??
 ? ? ?65   5b      5d      ?? 5f   
   "  6   .R?5g      ? .+?5h      ?? $ 
Horizontal=?6   .+?5i      ? .+?5j      ?? 
???  ??
??? ?????6@   ?? *Price+6Z   ?? 5k      ??6$   ?? *Year+6<   5l      5m      5n      5o        5p   
     5q      $
 2000??6   $	 100??6%     5r      $
 2010??6   $	 120??6%     5s      $
 2020??6   $	 130??6%     5t      $
 2021??6   $	 140??6%   5u      5v      .??5w      ? .+?5x   
   ?? .+?5z      ?? #??[  6   6;   ?? 5{      #??[  6   6:   (? 5|      .??5}      ?? $??幻音??6   $	??300??6$   $??30??60   6>   5~      5      5?      5?      