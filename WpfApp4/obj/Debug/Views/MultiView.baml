   M S B A M L   `   `   `  ????B  >WpfApp4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp4.ConverterWpfApp4.Converter  5          WpfApp4.Views.MultiView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null8metro,http://metro.mahapps.com/winfx/xaml/controls  5      +localclr-namespace:WpfApp4.Converter  5      $	??500??5	   7     ? 	Resources  5
      &    WpfApp4.Converter.ColorConverter 
  rgbCvt??%   &	          5   
   6    5      .??5      ? .+?5   
   ?? -   5         ??Name$ label??5      $
??Red:??6   $
??Left=?6.   $??	10,48,0,0q?6I   $	??Top=?6\   ?? 5   
   -   5        $ 
label_Copy??5      $??Green:??6$   $
??Left=?65   $??7,85,0,0q?6P   $	??Top=?6b   ?? 5   
   -   5        $ label_Copy1??5      $??Blue:??6%   $
??Left=?65   $??	7,123,0,0q?6P   $	??Top=?6c   ?? 5   
   -   5         ??Name$ slider_r??5       ? Minimum$ 0Q?6#    ? Maximum$	 255Q?6/    ?? Ticks$ 1R?6=   $
??Left=?6I   $??	68,53,0,0q?6d   $	??Top=?6w   $	??207??6?   ?? 5   
   -   5        $ slider_g??5      $ 0Q?6#   $	 255Q?6/   $ 1R?6>   $
??Left=?6H   $??	68,91,0,0q?6c   $	??Top=?6v   $	??207??6?   ?? 5   
   -   5        $ slider_b??5      $ 0Q?6#   $	 255Q?6/   $ 1R?6>   $
??Left=?6H   $??
68,124,0,0q?6c   $	??Top=?6w   $	??207??6?   ?? 5   
   -   5         ??Name$ 	rectangle??5      $
??Left=?6'   $??90??6B   $??
68,160,0,0q?6N   
???   ?$	??Top=?6q   $	??142??6?   ??5      `? 5       `? 	Converter# [  6   .1?5      ??  ?? ElementName$ slider_r??6   	 ?? Path$	 Value?65   6D   ?? 5      $ slider_g??6   $	 Value?65   6D   ?? 5      $ slider_b??6   $	 Value?65   6D   5      5      ?? 5   
   
 ?? Orientation$
 
Horizontal=?6   $??30??6.   $??
68 280 0 0q?6:   .+?5      ?? $	??100??6   ??6$   ?? $ 	rectangle??$
	 Fill??? 5      -   5        $	??abc??5      $??hello??6    62   5       5!      5"      