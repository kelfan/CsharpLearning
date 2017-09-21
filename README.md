# CsharpLearning

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

load data 
```cs 


```



	
