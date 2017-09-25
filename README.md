# CsharpLearning
The folders have the title this article storing the codes linking to the video tutorials under the titles.

## dataBindingMode1
[Data Binding Modes in WPF](https://www.youtube.com/watch?v=CniIPEFZ1Oo)

## bindComboBoxString
[C# WPF Bind ComboBox from List of String type](https://www.youtube.com/watch?v=xOX-Zb8B6hU)

## loadUserControl  
[C# Tutorial - Dynamically Loading User Control | FoxLearn](https://www.youtube.com/watch?v=mECkft9LG4k)

## [userControl](https://www.youtube.com/watch?v=s49G6ph4XXA)
It is the codes for [Tutorial WPF | Creating And Using An User Control (C#) | VS 2012](https://www.youtube.com/watch?v=s49G6ph4XXA)

## [pagesAndNavigation](https://www.youtube.com/watch?v=aBh0weP1bmo)
The ["pagesAndNavigation folder"] includes the codes for navigating pages within visual studio in C# project based on the youtube tutorial [C# WPF and GUI - Pages and Navigation](https://www.youtube.com/watch?v=aBh0weP1bmo)

## [dersYoutube folder](https://github.com/kelfan/CsharpLearning/tree/master/dersYoutube) 
The ["dersYoutube foler"](https://github.com/kelfan/CsharpLearning/tree/master/dersYoutube) includes the codes for the C# practical based on the Youtube tutorial: [Wpf ile Kütüphane Programı Yapıyoruz](https://www.youtube.com/playlist?list=PLi_9f1-X3vit_29s30akNn93krXT3Yalm) 


# following resources
How to draw table from a database [WPF Grid: Master-Detail Support](https://www.youtube.com/watch?v=Sh_VVEBFk50)
[C# WPF MVVM Eden Cerberus](https://www.youtube.com/results?search_query=wpf+information+detail)
Database manipulation 
[C# Tutorial - Insert Update Delete View data from database using Three Tier Architecture | FoxLearn](https://www.youtube.com/watch?v=ciUI2vaJ8GI)
    
wpf 
[C# ListView Ep.03 : Filter/Search List of Objects](https://www.youtube.com/watch?v=cycavkXug5U)
[WPF Listview with ItemTemplate binding](https://www.youtube.com/watch?v=ca3Kc2HE0QQ)
[C# Tutorials - Filter ListBox Data using TextBox](https://www.youtube.com/watch?v=7J-D4OzfX7Y)
    
design 
[C#, Modern Flat UI Dashboard Windows Form Visual Studio - Design Bunifu.NET](https://www.youtube.com/watch?v=tgqKd7l7_s8)
[C# WPF UI Tutorials: 09 - User Controls Side Menu Content @AngelSix](https://www.youtube.com/watch?v=9wYhpZ2oHkw)

user control 
[C# WPF UI Tutorials: 09 - User Controls Side Menu Content](https://www.youtube.com/watch?v=9wYhpZ2oHkw)

listView 
[C# ListView Ep.03 : Filter/Search List of Objects](https://www.youtube.com/watch?v=cycavkXug5U)
[C# Tutorials - Filter ListBox Data using TextBox](https://www.youtube.com/watch?v=7J-D4OzfX7Y)

itemTemplateBinding = listView link to the MySql ER model
[WPF Listview with ItemTemplate binding](https://www.youtube.com/watch?v=ca3Kc2HE0QQ)

# Notes 
## LINQ resources 
- [Introduction to LINQ Queries (C#)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries)

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

## ToList()
## ComboBox
	<ComboBox Name="combo1" SelectionChanged="ComboBox_SelectionChanged" ItemsSource="{Binding List}" SelectedValuePath="Id" DisplayMemberPath="Properity" />

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