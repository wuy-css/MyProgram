   M S B A M L   `   `   `  ????B  >WpfApp4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp4.ViewsWpfApp4.Views  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   WindowColor  ContentAreaColorLight  ContentAreaColorDark  DisabledControlLightColor  DisabledControlDarkColor  DisabledForegroundColor  SelectedBackgroundColor  SelectedUnfocusedColor  ControlLightColor 	 ControlMediumColor 
 ControlDarkColor  ControlMouseOverColor  ControlPressedColor  
GlyphColor  GlyphMouseOver  BorderLightColor  BorderMediumColor  BorderDarkColor  PressedBorderLightColor  PressedBorderDarkColor  DisabledBorderLightColor  DisabledBorderDarkColor  DefaultBorderBrushDarkColor  HeaderTopColor " DatagridCurrentCellBorderColor  SliderTrackDarkColor  NavButtonFrameColor  MenuPopupBrush  ?? EndPoint ?? 
StartPoint ? Color ? Offset $  ProgressBarIndicatorAnimatedFill  bool2VisibilityConverter ?? 
TargetType ?? 
ResourceId ?? TypeInTargetAssembly&    System.Windows.Controls.DataGrid ?? Property ?? Value	 ?? 
TargetType'  !System.Windows.VisualStateManager
   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard ?? 
TargetName ?? TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame ?? KeyTime ?? Value R? KeyTime  System.Windows.Visibility   	Collapsed R? Value ??Name J? SnapsToDevicePixels ?Name J? Opacity ? Points ?? Stretch ?? Color ??Name ?? Padding ??Name ? ColumnDefinitions ? RowDefinitions     SelectAllCommand7  1System.Windows.Controls.DataGridHeadersVisibility
!   All" ?? ConverterParameter!#    HeadersVisibilityConverter$ ?? 	Converter% ?? RelativeSource& ?? AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter'  Name(   Column) ??Name* ?? CanContentScroll+ ??Name, ?? Orientation- ?? ViewportHeight. ?? ViewportSize/ ?? ScrollableHeight0 ? Maximum*1 ?? #ComputedVerticalScrollBarVisibility2 ? Value3 ?? Mode4 ?? ViewportWidth5 ?? ScrollableWidth,6 ?? %ComputedHorizontalScrollBarVisibility7 ?? Triggers8 P? Property9 P? Value*  $System.Windows.Controls.DataGridCell)	  #System.Windows.Controls.DataGridRow?
  9System.Windows.Controls.Primitives.SelectiveScrollingGrid?  9System.Windows.Controls.Primitives.DataGridCellsPresenter: 	  
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter; 	  DetailsVisibility$< 
  SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation=   Vertical#>    RowDetailsScrollingConverter:  4System.Windows.Controls.Primitives.DataGridRowHeader
?   Row  RowHeaderGripperStyle@ ?? OrientationA n?Name  ColumnHeaderGripperStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeaderB  NameC J? IsHitTestVisible?? 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      %localclr-namespace:WpfApp4.Views  5      %%A  &	        &	 !     &	 B     &	 c     &	 ?     &	 ?     &	 ?     &	 ?     &	     &		 %    &	
 F    &	 g    &	 ?    &	 ?    &	 ?    &	     &	 .    &	 O    &	 p    &	 ?    &	 ?    &	 ?    &	 ?    &	     &	 2    &	 O    &	 p    &	 ?    &	 X    &	 ?    (?? ?    5M      $" DataGridSelectAllButtonStyle??"   )7  7  '   ?    '  ?    7  '	  }    7  7  7 	 7 
 7 	 7 
 7 	 7 
 7 	 7 
 7 	 7 
 7 	 7 
 7 	 7  7  7  7  7  &	 #0    '  I1    7  7  7  7  &	 ?8    '  :    7  7  '  >    ??5   
   	#FFE8EDF9??6/   ??5   
   	#FFC5CBF9??69   ??5   
   	#FF7381F9??68   ??5	   
   	#FFE8EDF9??6=   ??5
   
   	#FFC5CBF9??6<   ??5   
   	#FF888888??6;   ??5   
   	#FFC5CBF9??6;   ??5   
   	#FFDDDDDD??6:   ??5   
   	White??61   ??5   
   	#FF7381F9??66   ??5   
   	#FF211AA9??64   ??5   
   	#FF3843C4??69   ??5   
   	#FF211AA9??67   ??5   
   	#FF444444??6.   ??5   
   /+sc#1, 0.004391443, 0.002428215, 0.242281124??6T   ??5   
   	#FFCCCCCC??64   ??5   
   	#FF888888??65   ??5   
   	#FF444444??63   ??5    
   	#FF888888??6;   ??5!   
   	#FF444444??6:   ??5#   
   	#FFAAAAAA??6<   ??5$   
   	#FF888888??6;   ??5&   
   	Black??6;   ??5)   
   	#FFC5CBF9??62   ??5*   
   	Black??6>   ??5+   
   	#FFC5CBF9??68   ??5-   
   	#FF3843C4??67   ?? 5/   
   $  0.5,1&?50      $ 0.5,0&?51      .??52      ? # ?  6   $ 0Q?53      ? 54      # ? 	 6   $	 0.5Q?55      ? 56      # ?  6   $ 1Q?57      58      ?? 5:   
   $	 0,0&?5;      $	  1,0&?5<      ??5>      ? ? 5?      $ 	#000000FF??6#   $ 0Q?5@      ? 5A      $ 	#600000FF??6#   $	 0.4Q?5B      ? 5C      $ 	#600000FF??6#   $	 0.6Q?5D      ? 5E      $ 	#000000FF??6#   $ 1Q?5F      5G      5I      ?? 5J   
   6'   ?? 5L   
   " ??6   .?5O      ??  ? ?? 5P      ?? 5Q      "	 ??6&   .R?5R      ? 
 5S        5T   "   CommonStates??. 5U   &     
Normal??62     5V   &   	MouseOver??. 5W   *   ?? .??5X   .   ?? $ Border??6K   $_ Y(Shape.Fill).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5Y   1   .g?5[   2     $ 0??6F   8   5\   *   5]   /   5^   +   5_   '     5`   &   Pressed??. 5a   *   ?? .??5b   .   ?? $ Border??6K   $_ Y(Shape.Fill).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5c   1   .g?5e   2     $ 0??6F   8  5f   *   5g   /   5h   +   5i   '     5j   &   Disabled??. 5k   *   ?? .??5l   .   T? $ (UIElement.Visibility)?6L   $ Arrow??5m   2   ..?5n   2   i? $ 0??6I   # Z 5o   -   5p   /   5q   +   5r   '   5s   #   .+?5u      ?? $ Border??6(    . ??5w   "   ?? 5x   &   $  0.5,1&?6:   $ 0.5,0&?5y   $   .??5z   *   ? # ?  67   $ 0Q?5{      ? 5|   *   # ?  67   $ 1Q?5}      5~   '   ??5?   "   ?? 5?   &   $  0.5,1&?6:   $ 0.5,0&?5?   $   .??5?   *   ? # ?  67   $ 0Q?5?      ? 5?   *   # ? 	 67   $ 1Q?5?      5?   '   5?      ? 5?      $ Arrow??6&   $??Right=?5?      $??8,8,3,3q?5?      $
 0.15Q?5?       ?   ??? ??? ??? ??? $ Uniform=?5?      $??Bottom=?5?      ??5?   "   ?? 5?   &   # ?  66   5?      5?      5?      5?      5?      ?? 5?   
   "   6   .?5?      ??  ? ??# ? ??5?      ?? 5?       ? ?? 5?      ?? 5?      $  0.5,1&?6*   $ 0.5,0&?5?      .??5?      ? # ?  6'   $ 0Q?5?      ? 5?      # ?  6'   $ 1Q?5?      5?      5?      ?? 5?       ? ??$ 1q?5?      ?? 5?        ?@  RowDetailsVisibilityMode$ VisibleWhenSelected=?5?      ?? 5?       ? ?? . 5?      ?? 5?       ?@??PanningMode$
 Both=?5?      ?? 5?       ?@??IsFlicksEnabled .  5?      ?? 5?       ? ?? 5?      ?? 5?      "	   6&   .R?5?      ?? $ border??6!    . #??z??5?      #??z??5?      # z??5?      ??5?      ?? 5?   "   # ?  62   
 5?        5?   "   CommonStates??. 5?   &     Disabled??. 5?   *   ?? .??5?   .   ?? $ border??6K   $G A(Panel.Background).                       (SolidColorBrush.Color)?5?   1   .g?5?   2     $ 0??6F   # ?  5?   *   5?   /   5?   +   5?   '     5?   &   
Normal??62   5?   #   ._?5?      ?? $ DG_ScrollViewer??6+   |?.  
???   ???5?   "   ?? 5?   &   "	 ??66   .R?5?   *   ?  5?   .   ?? 5?   2   $
??Auto ?6C   ?? 5?   2   $??* ?6C   ?? 5?   2   $
??Auto ?6C    5?   .   ?? 5?   2   $
??Auto ?6@   ?? 5?   2   $??* ?6@   ?? 5?   2   $
??Auto ?6@   .+?5?   .   ?? |?.  #??Z  5?      ??5?      C? *?? $" DataGridSelectAllButtonStyle??"   +y?5?      ?? *HeadersVisibility+#" Z! #$ Z# % ?? "&   ??5?      ?? *CellsPanelHorizontalOffset+% ?? "&     5?   .   $!' PART_ColumnHeadersPresenter??6M   $??1??5?   3   y?5?   3   ?? *HeadersVisibility+#" Z( #$ Z# % ?? "&   ?? 5?   .   $!) PART_ScrollContentPresenter??6E   $??2??5?   +   $??1??5?   +   #* z??5?   +   ?? 5?   .   $+ PART_VerticalScrollBar??68   $??2??5?      $??1??5?      $, Vertical=?5?      #. z- 5?      #0 z/ 5?      #y?z1 5?      2 5?      ?? *VerticalOffset+$3 OneWay=?% ?? *TemplatedParent+? 5  .   $??1??63   $??2??5      5  2   ?? 5  6   ??6G   ?? **(NonFrozenColumnsViewportHorizontalOffset+% ?? "&   ?? 5  6   $??* ?6G   .+?5	  2   ?? $+ PART_HorizontalScrollBar??6<   $??1??5
      $, 
Horizontal=?5      #. z4 5      #0 z5 5      #y?z6 5      2 5      ?? *HorizontalOffset+$3 OneWay=?% ?? *TemplatedParent+5  /   5  +   5  '   .??5  "   ?? # z 61   5     5     5     5     7 5     P? 5     8 ?@??
IsGrouping9 . . ?5     ??  ? ?? .  5     5      5"     ?? 5%  
   "  6   .?5&     ??  ? ?? 5'     ?? 5(     "	  6&   .R?5)     ?? $ border??6!   
?????? $??1q?5+     
??????  . 
 5.       5/  "   FocusStates??. 50  &     	Unfocused??62     51  &   Focused??62   52  #     53  "   CurrentStates??. 54  &     Regular??62     55  &   Current??. 56  *   ?? .??57  .   ?? $ border??6K   $I C(Border.BorderBrush).                       (SolidColorBrush.Color)?58  1   .g?5:  2     $ 0??6F   8   5;  *   5<  /   5>  +   5?  '   5@  #   ._?5B     ?? # z 6/   5C     5D     5F     5G     ?? 5J  
   " 	 6   .?5K     ??  ? ?? 5L     ?? 5M     # ?  6&   5O     ?? 5P      ?@J?SnapsToDevicePixels . 5Q     ?? 5R      ?@=?ErrorTemplate 5S     Z? ?? 5T      ?@	 ValidationErrorTemplate 5U     ?? 5V     .R?5W     ?? 
???  ??$??2,0,0,0q?5X     $??!??5Y     $??Center=?5Z     5[     5]     ?? 5^      ? ?? 5_     ?? 5`     "	 	 6&   .R?5a     ?? $ 
DGR_Border??6!   #??z??5b     #??z??5c      . ??5e     ?? 5f  "   $  0.5,1&?66   $ 0.5,0&?5g  "   .??5h  &   ? $ Transparent??63   $ 0Q?5i     ? 5j  &   # ?  63   $ 1Q?5k     5l  #   
 5n       5o  "   CommonStates??. 5p  &     
Normal??62     5s  &   Normal_AlternatingRow??. 5t  *   ?? .??5u  .   ?? $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)?5v  1   .g?5x  2     $ 0??6F   8   5y  *   5z  /   ?? 5{  .   $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5|  1   .g?5  2     $ 0??6F   8  5?  *   5?  /   5?  +   5?  '     5?  &   Normal_Selected??. 5?  *   ?? .??5?  .   ?? $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   ?? 5?  .   $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   5?  +   5?  '     5?  &   Unfocused_Selected??. 5?  *   ?? .??5?  .   ?? $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   ?? 5?  .   $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   5?  +   5?  '     5?  &   Normal_Editing??. 5?  *   ?? .??5?  .   ?? $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   ?? 5?  .   $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   5?  +   5?  '     5?  &   MouseOver_Editing??. 5?  *   ?? .??5?  .   ?? $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   ?? 5?  .   $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8 	 5?  *   5?  /   5?  +   5?  '     5?  &   MouseOver_Unfocused_Editing??. 5?  *   ?? .??5?  .   ?? $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8 
 5?  *   5?  /   ?? 5?  .   $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   5?  +   5?  '     5?  &   Unfocused_Editing??. 5?  *   ?? .??5?  .   ?? $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   ?? 5?  .   $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   5?  +   5?  '     5?  &   	MouseOver??. 5?  *   ?? .??5?  .   ?? $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   ?? 5?  .   $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5?  1   .g?5?  2     $ 0??6F   8  5?  *   5?  /   5?  +   5?  '     5  &   MouseOver_Selected??. 5  *   ?? .??5  .   ?? $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)?5  1   .g?5
  2     $ 0??6F   8  5  *   5  /   ?? 5  .   $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5  1   .g?5  2     $ 0??6F   8  5  *   5  /   5  +   5  '     5  &    MouseOver_Unfocused_Selected??. 5  *   ?? .??5  .   ?? $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[0].(GradientStop.Color)?5  1   .g?5  2     $ 0??6F   8  5  *   5  /   ?? 5  .   $ 
DGR_Border??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5  1   .g?5!  2     $ 0??6F   8  5"  *   5#  /   5$  +   5%  '   5&  #   ._?5)     
   5*  "   ?? 5+  &   $
??Auto ?67   ?? 5,  &   $??* ?67    5.  "   ?? 5/  &   $??* ?64   ?? 50  &   $
??Auto ?64   .+?52  "     $??1??69   #??z: 53  %   # z 54  %     55  "   $??1??6;   $??1??56  '   #y?z; 57  '   < 58  '   ?? *AreRowDetailsFrozen+#" Z= #$ Z> % ?? "&     5=  "   $??2??64   $< Vertical=?5>      y?5?      ?? *HeadersVisibility+#" Z? #$ Z# % ?? "&   5C     5D     5E     5G     5H     ?? 5K  
   " n?5L     .?5M     ??  ? ??$ 8??5N     ?? 5O      ? ??
 ???? 5P     ?? 5Q      ?@?Cursor$ SizeNS??5R     ?? 5S      ? ?? 5T     ?? 5U     "	 n?6&   .R?5V     ?? #??z??6!   # z??5W     5X     5Z     5[     ?? 5^  
   "  6   .?5_     ??  ? ?? 5`     ?? 5a     "	  6&   .R?5b     ? 
 5c       5h  "   CommonStates??. 5i  &     
Normal??62     5j  &   Normal_CurrentRow??62     5k  &   Unfocused_EditingRow??62     5l  &   Normal_EditingRow??62     5m  &   	MouseOver??. 5n  *   ?? .??5o  .   ?? $ rowHeaderBorder??6K   $e _(Panel.Background).                       (GradientBrush.GradientStops)[1].(GradientStop.Color)?5p  1   .g?5r  2     $ 0??6F   8   5s  *   5t  /   5u  +   5v  '     5w  &   MouseOver_CurrentRow??62     5x  &   "MouseOver_Unfocused_EditingRow??62     5y  &   MouseOver_EditingRow??62     5z  &    MouseOver_Unfocused_Selected??62     5{  &   MouseOver_Selected??62     5|  &   +'MouseOver_Unfocused_CurrentRow_Selected??62     5}  &   !MouseOver_CurrentRow_Selected??62     5~  &   Unfocused_Selected??62     5  &   !Unfocused_CurrentRow_Selected??62     5?  &   Normal_CurrentRow_Selected??62     5?  &   Normal_Selected??62   5?  #   .+?5?     ?? $ rowHeaderBorder??6%   $??10??5?     $??1q?5?     ??5?  "   ?? 5?  &   $  0.5,1&?6:   $ 0.5,0&?5?  $   .??5?  *   ? # ?  67   $ 0Q?5?     ? 5?  *   # ?  67   $ 1Q?5?     5?  '   ??5?  "   ?? 5?  &   $  0.5,1&?6:   $ 0.5,0&?5?  $   .??5?  *   ? # ?  67   $ 0Q?5?     ? 5?  *   # ? 	 67   $ 1Q?5?     5?  '   ._?5?  "   ?? $@ 
Horizontal=?6-   .+?5?  &   ?? $??Center=?67   # z 5?  !   ?? 5?  &    .  ??5?     ?? *ValidationErrorTemplate+% ?? "& 	 y?5?     ?? *(Validation.HasError)+8$  % ?? "& 	 5?  #   5?     n? 5?     $A PART_TopHeaderGripper??6$   8?? $	??Top=?5?     n? 5?     $A PART_BottomHeaderGripper??6$   8?? $??Bottom=?5?     5?     5?     5?     5?     ?? 5?  
   " n?5?     .?5?     ??  ? ??$ 8??5?     ?? 5?      ? ??
 ???? 5?     ?? 5?      ?@?Cursor$ SizeWE??5?     ?? 5?      ? ?? 5?     ?? 5?     "	 n?6&   .R?5?     ?? #??z??6!   # z??5?     5?     5?     5?     ?? 5?  
   "  6   .?5?     ??  ? ??$ Center=?5?     ?? 5?      ? ?? 5?     ?? 5?     "	  6&   .R?5?     ? .+?5?     ?? $ columnHeaderBorder??6%   $??1q?5?     $ 3,0,3,0q?5?     ??5?  "   ?? 5?  &   $  0.5,1&?6:   $ 0.5,0&?5?  $   .??5?  *   ? # ?  67   $ 0Q?5?     ? 5?  *   # ?  67   $ 1Q?5?     5?  '   ??5?  "   ?? 5?  &   $  0.5,1&?6:   $ 0.5,0&?5?  $   .??5?  *   ? # ?  67   $ 0Q?5?     ? 5?  *   # ? 	 67   $ 1Q?5?     5?  '   ._?5?  "   ?? #??z??63   # z 5?     #??z??5?     5?     n? 5?     $A PART_LeftHeaderGripper??6$   $
??Left=?5?     8??  5?     n? 5?     $A PART_RightHeaderGripper??6$   $??Right=?5?     8?? 5?     5?     5?     5?     ?? 5?      ? ?? 5?     ?? 5?     $  0.5,1&?6*   $ 0.5,0&?5?     .??5?     ? # ?  6'   $ 0Q?5?     ? 5?     # ? 	 6'   $ 1Q?5?     5?     5?     5?     ?? 5?     "  6   .?5?  
   ??  ? ?? 5      ?? 5     "	  6"   .R?5     ? .+?5       $B PART_FillerColumnHeader??6/   C .  5  !   ?? 5     5     5     5	     5
     5     