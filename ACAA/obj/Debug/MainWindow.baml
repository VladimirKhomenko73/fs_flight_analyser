   M S B A M L   `   `   `  ����?  ;ACAA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ACAAACAA  5   	   1clr-namespace:ACAA.ConvertersACAA.Converters  5   	   1clr-namespace:ACAA.ViewModelsACAA.ViewModels  5   	       ACAA.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:ACAA     5   	   4
convertersclr-namespace:ACAA.Converters     5   	   ,vmclr-namespace:ACAA.ViewModels     5   	   Y UDynamicDataDisplay, Version=0.3.0.0, Culture=neutral, PublicKeyToken=5b7d744a7263923f=d34http://research.microsoft.com/DynamicDataDisplay/1.0  5	   	     � Title$%  Aircraft Crew Activity Analyzer��5   	   $
��1024��61   $
��1280��6?    � 	Resources 5      2  ,ACAA.Converters.BoolArrayToDataViewConverter   MatrixToDataViewConverter6  0ACAA.Converters.ParameterListToDataViewConverter $  ParameterListToDataViewConverter��%:   &	        &	        5   
   62     5   
   66   5      .��5      � .+�5   
   �� $
��Left=�6   $	��993��60   $	��Top=�6=   $
��1272��6U   .@�5      �� $
��Main��6   .��5      � 
�������.+�5      �� $��	Load data��6   $
��Left=�62   $	��100��6M   $��10,0,0,0q�6Z   $	��Top=�6l   $
��1246��6�   .��5      � .+�5      �� $��	Open file��6'   $
��Left=�6:   $��68��6U   $	��Top=�6a   $	��604��6y   $��10,0,0,0q�6�   .��5   "   � $��0,0,0,12q�6'    � DataContext 5   &      ACAA.ViewModels.OpenFileVM  5   *   .+�5   &   �� $
��Left=�6.   $��23��6I   $��4,10,0,0q�6U   $	��Top=�6�   $	��385��6�   ��6g   �� *
FilePath+6�   �� 5   &   $��	Browse...��6-   $
��Left=�6a   $��
404,10,0,0q�6|   $	��Top=�6�   $��85��6�   $��23��6�   ��6A   �� *GetFilePath+6�   �� 5   &   $
��Load��6-   $
��Left=�6Y   $��
497,10,0,0q�6t   $	��Top=�6�   $��85��6�   $��23��6�   ��6<   �� *
LoadFile+6�   5   #   5      �� 5       $��Open profile��6'   $
��Left=�6=   $��68��6X   $	��Top=�6d   $	��605��6|   $��	619,0,0,0q�6�   .��5!   "   � $��0,0,0,12q�6'    5"   &   #  ACAA.ViewModels.OpenProfileVM  5#   *   .+�5%   &   �� $
��Left=�6.   $��23��6I   $��4,10,0,0q�6U   $	��Top=�6�   $	��385��6�   ��6g   �� *
FilePath+6�   �� 5&   &   $��	Browse...��6-   $
��Left=�6a   $��
404,10,0,0q�6|   $	��Top=�6�   $��85��6�   $��23��6�   ��6A   �� *GetFilePath+6�   �� 5'   &   $
��Load��6-   $
��Left=�6Y   $��
497,10,0,0q�6t   $	��Top=�6�   $��85��6�   $��23��6�   ��6<   �� *
LoadFile+6�   5(   #   5)      5*      5+      �� 5,      $
��Data��6   $
��Left=�6-   $	��850��6H   $��
10,105,0,0q�6U   $	��Top=�6i   $
��1246��6�   .��5-      �  5.        ACAA.ViewModels.DataVM  5/   "   .+�51      �� $
��Left=�6{   $	��344��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��100��6�   ��6'   �� *MatrixElementsList+ �� SelectedItem 6R   �� *SelectedElement+ �� View 52   "   �� 53   &   .P�54   *   �� $��Id��69    �� Width$
 Auto��6E    �� DisplayMemberBinding 6S   �� *	ElementId+�� 55   *   $
��Name��69   $
 Auto��6G    6T   �� *ElementName+56   '   ��58   "   �� 59   &    �� 
TargetType" ��6,   .�5:   *   ��  �� Property � ��	 �� Value$	 20��6C   5;   '   5=      &   System.Windows.Controls.DataGrid  5>      !
   EnableColumnVirtualization
 .    EnableRowVirtualization . $
��Left=�6�   $	��344��6�   $��
110,10,0,0q�6�   $	��Top=�6  $
��1114��6'     AutoGenerateColumns .    CanUserReorderColumns .     CanUserResizeColumns .     CanUserSortColumns .     CanUserResizeRows .     
IsReadOnly .    	RowHeight$ 21Q�6�  ��6'   �� *Matrix+ �� 	Converter# [   �� ConverterParameter$ 1��   ColumnHeaderStyle 5?   "   �� 5@   &   =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6,   .�5A   *   ��  � ��	 6D   �� *DataContext.showPackage+ �� RelativeSource ��  �� AncestorType"  �� 5B   *    � ��	 6M   ��  �� Path$ Content� �� *Self+5C   '   5E        5F      $
��Left=�6�   $	��377��6�   $��1076,441,0,0q�6�   $	��Top=�6�   $	��148��6�    .   .   .   .   . ��6'   �� *PackageParametersList+# [ $ 1��6z  �� 5G      $��Data analysis��6'   $��715,359,10,392q�6>   .��5H   "   � .+�5I   &   �� $��Event analysis��6-   $
��Left=�6h   $��	10,16,0,0q�6�   $	��Top=�6�   $��85��6�   $��23��6�   ��6F   �� *eventAnalysis+6�   �� 5J   &   $��State analysis��6-   $
��Left=�6h   $��
126,16,0,0q�6�   $	��Top=�6�   $��86��6�   $��23��6�   ��6F   �� *stateAnalysis+6�   �� 5K   &   $��Phase analysis��6-   $
��Left=�6h   $��
242,16,0,0q�6�   $	��Top=�6�   $��86��6�   $��23��6�   ��6F   �� *phaseAnalysis+6�   5L   #   5M      �� 5N      $��10,359,524,10q�6Y   ��6&   �� *ElementParametersChartList+��5O   "   �� 5P   &   .R�5Q   *   � 
�������$	��650��6B   $	��206��6N   .+�5R   .   8  2Microsoft.Research.DynamicDataDisplay.ChartPlotter  $��Center=�6>   $��Center=�6Y   3	  -Microsoft.Research.DynamicDataDisplay.Plotter 	  Children. 5S   2   5
  /Microsoft.Research.DynamicDataDisplay.LineGraph
  ;  5Microsoft.Research.DynamicDataDisplay.PointsGraphBase   
DataSource 6@   �� *ParameterPoints+
  5T   2    
  Stroke
 � ��� 6@   �� *ElementPoints+6e   2  ,Microsoft.Research.DynamicDataDisplay.Header  5U   2   ��6<   �� *ParameterDescription+5V   /   5W   +   5X   '   5Z      5[      5\      5]      5^      �� 5_      $��Detector��6   .��5`      � 
�������.+�5a      �� $��Detector��6   $
��Left=�61   $	��442��6L   $��	10,10,0,0q�6Y   $	��Top=�6l   $
��1246��6�   .��5b      �  5c         ACAA.ViewModels.DetectorVM  5d   "   .+�5f      �� $
��Left=�6   $	��344��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��100��6�   ��6'   �� *PhaseElementsList+ 6Q   �� *SelectedPhaseElement+ 5g   "   �� 5h   &   .P�5i   *   �� $��Id��69   $
 Auto��6E    6S   �� *	ElementId+�� 5j   *   $
��Name��69   $
 Auto��6G    6T   �� *ElementName+5k   '   ��5m   "   �� 5n   &   " ��6,   .�5o   *   ��  � ��$	 20��6C   5p   '   5r      �� 5s      $
��Left=�6   $	��344��6�   $��
115,10,0,0q�6�   $	��Top=�6�   $	��100��6�   ��6'   �� *StateElementsList+ 6Q   �� *SelectedStateElement+ 5t   "   �� 5u   &   .P�5v   *   �� $��Id��69   $
 Auto��6E    6S   �� *	ElementId+�� 5w   *   $
��Name��69   $
 Auto��6G    6T   �� *ElementName+5x   '   ��5z   "   �� 5{   &   " ��6,   .�5|   *   ��  � ��$	 20��6C   5}   '   5      �� 5�      $
��Left=�6   $	��344��6�   $��
220,10,0,0q�6�   $	��Top=�6�   $	��100��6�   ��6'   �� *EventElementsList+ 6Q   �� *SelectedEventElement+ 5�   "   �� 5�   &   .P�5�   *   �� $��Id��69   $
 Auto��6E    6S   �� *	ElementId+�� 5�   *   $
��Name��69   $
 Auto��6G    6T   �� *ElementName+5�   '   ��5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � ��$	 20��6C   5�   '   5�      �� 5�      $��325,10,10,66q�6Y   ��6&   �� *ElementParametersChartList+��5�   "   �� 5�   &   .R�5�   *   � 
�������$	��650��6B   $	��206��6N   .+�5�   .     $��Center=�6>   $��Center=�6Y   . 5�   2   
   6@   �� *ParameterPoints+
  5�   2   
 � ��� 6@   �� *ElementPoints+6e     5�   2   ��6<   �� *ParameterDescription+5�   /   5�   +   5�   '   5�      �� 5�      $��Detect��6%   $
��Left=�6Y   $��
10,374,0,0q�6t   $	��Top=�6�   $��84��6�   $��22��6�   ��66   �� *showDetections+6�   5�      5�      5�      5�      5�      5�      5�      