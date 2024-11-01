# GettingStarted_CircularChart_MAUI

## Creating an application using the .NET MAUI chart

1. Create a new .NET MAUI application in Visual Studio.
2. Syncfusion .NET MAUI components are available in [nuget.org](https://www.nuget.org/). To add SfCircularChart to your project, open the NuGet package manager in Visual Studio, search for Syncfusion.Maui.Charts and then install it.
3. To initialize the control, import the Chart namespace.
4. Initialize [SfCircularChart](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCircularChart.html).

###### Xaml
```xaml
<ContentPage   
    . . .
    xmlns:chart="clr-namespace:Syncfusion.Maui.Charts;assembly=Syncfusion.Maui.Charts">

    <chart:SfCircularChart/>
</ContentPage>
```

###### C#
```C#
using Syncfusion.Maui.Charts;
. . .
public partial class MainWindow : ContentPage
{
    public MainPage()
    {
        this.InitializeComponent();
        SfCircularChart chart = new SfCircularChart();
        this.Content = chart;
    }
}   
```

## Register the handler

Syncfusion.Maui.Core nuget is a dependent package for all Syncfusion controls of .NET MAUI. In the MauiProgram.cs file, register the handler for Syncfusion core.

######
```C#
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using Syncfusion.Maui.Core.Hosting;

namespace ChartGettingStarted
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

            return builder.Build();
        }
    }
}
```

## Initialize view model

Now, let us define a simple data model that represents a data point in the chart.
###### C#
```C#
public class SalesModel
{
    public string Product { get; set; }
    public double SalesRate { get; set; }
}
```

Next, create a SalesViewModel class and initialize a list of `SalesModel` objects as follows.
###### 
```C#
public class SalesViewModel
{
    public List<SalesModel> Data { get; set; }

    public SalesViewModel()
    {
        Data = new List<SalesModel>()
        {
            new SalesModel(){Product = "iPad", SalesRate = 25},
            new SalesModel(){Product = "iPhone", SalesRate = 35},
            new SalesModel(){Product = "MacBook", SalesRate = 15},
            new SalesModel(){Product = "Mac", SalesRate = 5},
            new SalesModel(){Product = "Others", SalesRate = 10},
        };
    }
}
```

* Create a `SalesViewModel` instance and set it as the chart's `BindingContext`. This enables property binding from `SalesViewModel` class.

* Add namespace of `SalesViewModel` class to your XAML Page, if you prefer to set `BindingContext` in XAML.
###### Xaml
```xaml 
<ContentPage
    . . .
    xmlns:chart="clr-namespace:Syncfusion.Maui.Charts;assembly=Syncfusion.Maui.Charts"
    xmlns:model="clr-namespace:ChartGettingStarted">

    <chart:SfCircularChart>
        <chart:SfCircularChart.BindingContext>
            <model:SalesViewModel/>
        </chart:SfCircularChart.BindingContext>
    </chart:SfCircularChart>
</ContentPage>
```
###### C#
```C#
SfCircularChart chart = new SfCircularChart();
this.BindingContext = new SalesViewModel();
this.Content = chart;
```

## Populate chart with data

Adding [PieSeries](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.PieSeries.html) to the charts [Series](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCircularChart.html#Syncfusion_Maui_Charts_SfCircularChart_Series) collection and binding `Data` to the series [ItemsSource](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_ItemsSource) property from its BindingContext to create our own Product Sales Pie chart.

* The circular chart has [Series](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCircularChart.html#Syncfusion_Maui_Charts_SfCircularChart_Series) as its default content.

* To plot the series, the [XBindingPath](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_XBindingPath) and [YBindingPath](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.CircularSeries.html#Syncfusion_Maui_Charts_CircularSeries_YBindingPath) properties must be configured so that the chart may get values from the respective properties in the data model.

###### Xaml
```xaml
<chart:SfCircularChart>
    . . .
    <chart:PieSeries ItemsSource="{Binding Data}" 
                    XBindingPath="Product" 
                    YBindingPath="SalesRate"/>
</chart:SfCircularChart>
```
###### C#
```C#
SfCircularChart chart = new SfCircularChart();
SalesViewModel viewModel = new SalesViewModel();
chart.BindingContext = viewModel;
PieSeries series = new PieSeries();
series.ItemsSource = viewModel.Data;
series.XBindingPath = "Product";
series.YBindingPath = "SalesRate";
chart.Series.Add(series);
```

## Add a title

The title of the chart acts as the title to provide quick information to the user about the data being plotted in the chart. You can set title using the [Title](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartBase.html#Syncfusion_Maui_Charts_ChartBase_Title) property of circular chart as follows.

###### Xaml
```xaml
<chart:SfCircularChart>
    <chart:SfCircularChart.Title>
        <Label Text="PRODUCT SALES"/>
    </chart:SfCircularChart.Title>
    . . .
</chart:SfCircularChart>
```
###### C#
```C#
SfCircularChart chart = new SfCircularChart();
chart.Title = new Label
{
    Text = "PRODUCT SALES"
};
``` 

## Enable the data labels

The [ShowDataLabels](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_ShowDataLabels) property of series can be used to enable data labels to improve the readability of the circular chart. The label visibility is set to `False` by default.

###### Xaml
```xaml
<chart:SfCircularChart>
    . . .
    <chart:PieSeries ShowDataLabels="True"/>
</chart:SfCircularChart>
```
###### C#
```C#
SfCircularChart chart = new SfCircularChart();
. . .
PieSeries series = new PieSeries();
series.ShowDataLabels = true;
chart.Series.Add(series);
``` 

## Enable a legend

The legend provides information about the data point displayed in the circular chart. The [Legend](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartBase.html#Syncfusion_Maui_Charts_ChartBase_Legend) property of the chart was used to enable it.

###### Xaml
```xaml
<chart:SfCircularChart>
    . . .
    <chart:SfCircularChart.Legend>
    <chart:ChartLegend/>
    </chart:SfCircularChart.Legend>
</chart:SfCircularChart>
```
###### C#
```C#
SfCircularChart chart = new SfCircularChart();
. . .
chart.Legend = new ChartLegend();
```

## Enable Tooltip

Tooltips are used to show information about the segment, when mouse over on it. Enable tooltip by setting series [EnableTooltip](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_EnableTooltip) property as true.

###### Xaml
```xaml
<chart:SfCircularChart>
    . . .
    <chart:PieSeries EnableTooltip="True"/>
</chart:SfCircularChart>
```
###### C#
```C#
SfCircularChart chart = new SfCircularChart();
. . .
PieSeries series = new PieSeries();
series.EnableTooltip = true;
chart.Series.Add(series);
```

The following code example gives you the complete code of above configurations.
###### Xaml
```xaml
<chart:SfCircularChart>
    <chart:SfCircularChart.Title>
        <Label Text="PRODUCT SALES"/>
    </chart:SfCircularChart.Title>
    <chart:SfCircularChart.BindingContext>
        <model:SalesViewModel/>
    </chart:SfCircularChart.BindingContext>
    <chart:SfCircularChart.Legend>
        <chart:ChartLegend/>
    </chart:SfCircularChart.Legend>
    <chart:PieSeries
		ItemsSource="{Binding Data}"
		ShowDataLabels="True"
		XBindingPath="Product"
		EnableTooltip="True"
		YBindingPath="SalesRate"/>
</chart:SfCircularChart>
 ```
###### C#
```C#
using Syncfusion.Maui.Charts;
. . .
public partial class MainPage : ContentPage
{   
    public MainWindow()
    {
        SfCircularChart chart = new SfCircularChart();
        chart.Title = new Label
        {
            Text = "PRODUCT SALES"
        };
        chart.Legend = new ChartLegend();
        SalesViewModel viewModel = new SalesViewModel();
        chart.BindingContext = viewModel;

        PieSeries series = new PieSeries();
        series.ItemsSource = viewModel.Data;
        series.XBindingPath = "Product";
        series.YBindingPath = "SalesRate";
        series.EnableTooltip = true;
        series.ShowDataLabels = true;
        chart.Series.Add(series);
        this.Content = chart;
    }
}
```

![Pie chart in .NET MAUI Chart](Getting_started-images/MAUI_pie_chart.png)
