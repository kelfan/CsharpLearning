# controls 控件
https://msdn.microsoft.com/zh-cn/library/aa970268%28v=vs.100%29.aspx?f=255&MSPPError=-2147217396#Applications
- 按钮：Button 和 RepeatButton。
- 数据显示：DataGrid、ListView 和 TreeView。
- 日期显示和选择：Calendar 和 DatePicker。
- 对话框：OpenFileDialog、PrintDialog 和 SaveFileDialog。
- 数字墨迹：InkCanvas 和 InkPresenter。
- 文档：DocumentViewer、FlowDocumentPageViewer、FlowDocumentReader、FlowDocumentScrollViewer 和 StickyNoteControl。
- 输入：TextBox、RichTextBox 和 PasswordBox。
- 布局：Border、BulletDecorator、Canvas、DockPanel、Expander、Grid、GridView、GridSplitter、GroupBox、Panel、ResizeGrip、Separator、ScrollBar、ScrollViewer、StackPanel、Thumb、Viewbox、VirtualizingStackPanel、Window 和 WrapPanel。
- 媒体：Image、MediaElement 和 SoundPlayerAction。
- 菜单：ContextMenu、Menu 和 ToolBar。
- 导航：Frame、Hyperlink、Page、NavigationWindow 和 TabControl。
- 选择：CheckBox、ComboBox、ListBox、RadioButton 和 Slider。
- 用户信息：AccessText、Label、Popup、ProgressBar、StatusBar、TextBlock 和 ToolTip。



# Notes
## RichTextBox binding
```xml
 <RichTextBox>
     <FlowDocument PageHeight="180">
         <Paragraph>
             <Run Text="{Binding Text, Mode=TwoWay}"/>
          </Paragraph>
     </FlowDocument>
 </RichTextBox>
```

## Utas week 8 LINQ
add MySQL references
>	SolutionExplorer -> right click -> add references -> browser
	-> search route like 'C:\Program Files (x86)\MySQL\MySQL Connector Net 6.9.9\Assemblies\v4.5'
	-> add 'MySql.Data.dll'

build connection
```cs
// head
using MySql.Data.MySqlClient;
using MySql.Data.Types;

// define connection
private static MySqlConnection conn = null;

        // build up the mysql connection
        private static MySqlConnection GetConnection()
        {
            if(conn == null)
            {
                string connectionString = String.Format("Database={0}; Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }
```

## ComboBox
```xml
	<ComboBox Name="combo1"
    SelectionChanged="ComboBox_SelectionChanged"
    ItemsSource="{Binding List}"
    SelectedValuePath="Id"
    DisplayMemberPath="Properity" />
```
```cs
private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
	var item = combo1.SelectedItem as Employee;
	MessageBox.Show(item.Emp_Name.ToString());
}
```
## listBox
[# WPF学习笔记——ListBox用ItemsSource绑定数据源](http://blog.csdn.net/leftfist/article/details/25333425)
```cs
        protected class UserItem
        {
            public UserItem(int Id, string Name, bool IsActived)
            {
                this.Id = Id;
                this.Name = Name;
                this.IsActived = IsActived;
            }
            public int Id{get;set;}
            public string Name { get; set; }
            public bool IsActived { get; set; }
            public string BackGround
            {
                get
                {
                    return IsActived
                        ? "/test;component/Assets/Images/UserItemNull.png"
                        : "/test;component/Assets/Images/UserItemNullg.png";
                }
            }
        }
        void Init()
        {
            Lst.ItemsSource = new List<UserItem>
            {
                new UserItem(1,"张三",true)
                ,new UserItem(2,"李四",true)
                ,new UserItem(3,"赵五",true)
                ,new UserItem(4,"钱六",true)
                ,new UserItem(5,"孙七",false)
                ,new UserItem(6,"李八",false)
                ,new UserItem(7,"王九",false)
                ,new UserItem(8,"陈十",false)
                ,new UserItem(9,"吴万",false)
                ,new UserItem(10,"刘十八",false)
            };
        }
```
```xml
<Grid>
        <ListBox x:Name="Lst">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Button MouseDoubleClick="Button_MouseDoubleClick">
                        <Grid>
                            <Image Source="{Binding Path=BackGround}" />
                            <TextBlock Text="{Binding Path=Name}" Margin="70 10" FontSize="18"></TextBlock>
                        </Grid>
                    </Button>
                </DataTemplate>
            </ListBox.ItemTemplate>
</Grid>
```
## JsonConvert
JsonConvert is from the namespace Newtonsoft.Json, not System.ServiceModel.Web

Use NuGet to download the package

"Project" -> "Manage NuGet packages" -> "Search for "newtonsoft json". -> click "install".

```cs
public void LoadJson()
{
    using (StreamReader r = new StreamReader("file.json"))
    {
        string json = r.ReadToEnd();
        List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
    }
}

public class Item
{
    public int millis;
    public string stamp;
    public DateTime datetime;
    public string light;
    public float temp;
    public float vcc;
}
```
You can even get the values dynamically without declaring Item class.
```cs
dynamic array = JsonConvert.DeserializeObject(json);
foreach(var item in array)
{
    Console.WriteLine("{0} {1}", item.temp, item.vcc);
}
```

# save json file
https://stackoverflow.com/questions/16921652/how-to-write-a-json-file-in-c
```cs
string json = JsonConvert.SerializeObject(_data.ToArray(), Formatting.Indented);
string jsonData = JsonConvert.SerializeObject(responseData, Formatting.None);
System.IO.File.WriteAllText(Server.MapPath("~/JsonData/jsondata.txt"), jsonData);
System.IO.File.WriteAllText(@"D:\path.txt", json);
```

## configuration
- Add an Application Configuration File item to your project (right click project > add item). This will create a file called app.config in your project.
- Edit the file by adding entries like `<add key="keyname" value="someValue" /> within the <appSettings>` tag.
- Add a reference to the System.Configuration dll, and reference the items in the config using code like `ConfigurationManager.AppSettings["keyname"]`

```cs
Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

confCollection["YourKey"].Value = "YourNewKey";

configManager.Save(ConfigurationSaveMode.Modified);
ConfigurationManager.RefreshSection(configManager.AppSettings.SectionInformation.Name);
```

## wpf open folders dialog
- add a reference to `System.Windows.Forms.dll`.
- `using System.Windows.Forms;``

```cs
using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
{
    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
}
```

## MVVM + WinForms FolderBrowserDialog as behavior
```cs
public class FolderDialogBehavior : Behavior<Button>
{
    public string SetterName { get; set; }

    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.Click += OnClick;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.Click -= OnClick;
    }

    private void OnClick(object sender, RoutedEventArgs e)
    {
        var dialog = new FolderBrowserDialog();
        var result = dialog.ShowDialog();
        if (result == DialogResult.OK && AssociatedObject.DataContext != null)
        {
            var propertyInfo = AssociatedObject.DataContext.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.CanRead && p.CanWrite)
            .Where(p => p.Name.Equals(SetterName))
            .First();

            propertyInfo.SetValue(AssociatedObject.DataContext, dialog.SelectedPath, null);
        }
    }
}
```
```xml
<Button Grid.Column="3" Content="...">
       <Interactivity:Interaction.Behaviors>
           <Behavior:FolderDialogBehavior SetterName="SomeFolderPathPropertyName"/>
       </Interactivity:Interaction.Behaviors>
</Button>
```

## wpf listbox/listview SelectionChanged 'System.IndexOutOfRangeException'
```cs
if (this.publicationListView.SelectedItem != null) { }
```

## Multiline for WPF TextBox
Enable `TextWrapping="Wrap"` and `AcceptsReturn="True"` on your TextBox.
You might also wish to `enable AcceptsTab` and `SpellCheck.IsEnabled` too.

## EASY way to refresh ListBox in WPF?
myListBox.Items.Refresh();

## simplest MVVM
MyModel.cs
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApplication1
{
    public class MyModel: INotifyPropertyChanged
    {
        private string _name;
        private string _companyName;

        public string Name
        {
            get { return _name; }
            set { _name = value;  NotifyPropertyChanged("Name"); }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; NotifyPropertyChanged("CompanyName"); }
        }

        public string DisplayMember
        {
            get { return string.Format("{0} ({1})", Name, CompanyName); }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayMember"));
            }
        }
    }
}
```
MainWindow.XMAL.cs
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

/// https://stackoverflow.com/questions/14096414/easy-way-to-refresh-listbox-in-wpf
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<MyModel> _list = new ObservableCollection<MyModel>();
        private MyModel _selectedModel;

        public MainWindow()
        {
            InitializeComponent();
            List.Add(new MyModel { Name = "James", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Adam", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Chris", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Steve", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Brent", CompanyName = "StackOverflow" });
        }

        public ObservableCollection<MyModel> List
        {
            get { return _list; }
            set { _list = value; }
        }

        public MyModel SelectedModel
        {
            get { return _selectedModel; }
            set { _selectedModel = value; NotifyPropertyChanged("SelectedModel"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
```

XAML
```xml
<Window x:Class="WpfApplication11.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525" Name="UI">
    <Grid>
        <ListBox ItemsSource="{Binding ElementName=UI, Path=List}" SelectedItem="{Binding ElementName=UI, Path=SelectedModel}" Margin="0,0,200,0" DisplayMemberPath="DisplayMember" SelectedIndex="0" />
        <StackPanel HorizontalAlignment="Left" Height="100" Margin="322,10,0,0" VerticalAlignment="Top" Width="185">
            <TextBlock Text="Name" />
            <TextBox Height="23" TextWrapping="Wrap" Text="{Binding ElementName=UI, Path=SelectedModel.Name, UpdateSourceTrigger=PropertyChanged}" />
            <TextBlock Text="Company Name" />
            <TextBox Height="23" TextWrapping="Wrap" Text="{Binding ElementName=UI, Path=SelectedModel.CompanyName, UpdateSourceTrigger=PropertyChanged}" />
        </StackPanel>
    </Grid>
</Window>
```

## delegate

2.2.1 Declaring a delegate Inside the namespace declaration but outside the Program class declaration add the following:
`public delegate Employee ManageWorker(int id); `
This defines a new delegate type that is compatible with any method whose return type is Employee and that takes in a single integer parameter. It doesn’t specify what the behaviour of the method must be, only what parameters and return type it must have.

2.2.2 Attaching delegates variables to actual methods Now that the ManageWorker delegate has been defined, add the following declarations inside Main():
`Action doSomething; ManageWorker manage;`
Action is an existing delegate in the System namespace. It is compatible with any method that has no return value (its return type is void) and that takes no parameters.
Adapt the code in Main() that called methods on the Boss object directly to be more like the following (which assumes that your Boss object is called boss):
```
doSomething = boss.Display;
manage = boss.Use;

doSomething();
Console.WriteLine("Dealing with {0}", manage(1)); #if 1 is an ID
doSomething();
``` 
Note that there are no parentheses after the method names in the two assignments; these statements assign those methods to the variables doSomething and manage, but do not execute the methods.

# Resources
- [WPF Grid: Master-Detail Support](https://www.youtube.com/watch?v=Sh_VVEBFk50): How to draw table from a database
- [C# WPF MVVM Eden Cerberus](https://www.youtube.com/results?search_query=wpf+information+detail)

## Database manipulation
- [C# Tutorial - Insert Update Delete View data from database using Three Tier Architecture | FoxLearn](https://www.youtube.com/watch?v=ciUI2vaJ8GI)

## wpf
- [C# ListView Ep.03 : Filter/Search List of Objects](https://www.youtube.com/watch?v=cycavkXug5U)
[WPF Listview with ItemTemplate binding](https://www.youtube.com/watch?v=ca3Kc2HE0QQ)
- [C# Tutorials - Filter ListBox Data using TextBox](https://www.youtube.com/watch?v=7J-D4OzfX7Y)

## design
- [C#, Modern Flat UI Dashboard Windows Form Visual Studio - Design Bunifu.NET](https://www.youtube.com/watch?v=tgqKd7l7_s8)
- [C# WPF UI Tutorials: 09 - User Controls Side Menu Content @AngelSix](https://www.youtube.com/watch?v=9wYhpZ2oHkw)

## user control
- [C# WPF UI Tutorials: 09 - User Controls Side Menu Content](https://www.youtube.com/watch?v=9wYhpZ2oHkw)

## listView
- [C# ListView Ep.03 : Filter/Search List of Objects](https://www.youtube.com/watch?v=cycavkXug5U)
- [C# Tutorials - Filter ListBox Data using TextBox](https://www.youtube.com/watch?v=7J-D4OzfX7Y)

## itemTemplateBinding = listView link to the MySql ER model
- [WPF Listview with ItemTemplate binding](https://www.youtube.com/watch?v=ca3Kc2HE0QQ)

## LINQ resources
- [Introduction to LINQ Queries (C#)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries)
