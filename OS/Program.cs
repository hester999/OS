using System.IO.Compression;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml;

class OS
{
    static void Main(string[] args)
    {
        Drive_info d = new Drive_info();

        print p = new print();



        p.menu();




     

        
        

       

   
    }

    
}



public class Drive_info
{
    public void getinfo()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in drives) {

            Console.WriteLine("Drive name:{0}", drive.Name);
            Console.WriteLine("Drive type:{0}", drive.DriveType);
            if (drive.IsReady == true)
            {
                Console.WriteLine("Drive mark:{0}", drive.VolumeLabel);
                Console.WriteLine("Drive total spase: {0}", drive.TotalSize);
                Console.WriteLine("Drive free spase: {0}", drive.TotalFreeSpace);

            }
        }

        
    }
   
}
public class Create_fiele
{
    public async Task fileAsync()
    {
        string str;


        string path = @"./file.txt";
        
        using (StreamWriter s = new StreamWriter(path, true))
        {
            Console.WriteLine("Введите строку для записи ");
            str = Console.ReadLine();
            s.WriteLine(str);
          
;        }
       
            using (StreamReader reader = new StreamReader(path))
            {
                Console.WriteLine("Содержимое файла");
                string text = await reader.ReadToEndAsync();
                Console.WriteLine(text);
                
            }
        

    }
}


public class Create_JSON
{
    string name;
    int age;


    public async void Create_json()
    {
        string path = "./file.json";


        Person user = new Person(name, age);
        
        Console.WriteLine("Enter age");
        age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter name");
        name = Console.ReadLine();



        user.Age = age;
        user.Name = name;
      

        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            string json = JsonSerializer.Serialize(user);
            Console.WriteLine(json);
            Person? restoredPerson = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(restoredPerson?.Name, restoredPerson?.Age);
            Console.WriteLine(restoredPerson?.Age);

        }
    
    }

      
        
class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }



}



class Create_XML
{

    public void Creat_xml()
    {
        XDocument xdoc = new XDocument();

        XElement tom = new XElement("person");

        XAttribute tomNameAttr = new XAttribute("name", "Tom");

        XElement tomCompanyElem = new XElement("company", "Microsoft");
        XElement tomAgeElem = new XElement("age", 37);

        tom.Add(tomNameAttr);
        tom.Add(tomCompanyElem);
        tom.Add(tomAgeElem);


        XElement bob = new XElement("person");

        XAttribute bobNameAttr = new XAttribute("name", "Bob");

        XElement bobCompanyElem = new XElement("company", "Google");
        XElement bobAgeElem = new XElement("age", 41);
        bob.Add(bobNameAttr);
        bob.Add(bobCompanyElem);
        bob.Add(bobAgeElem);

        XElement people = new XElement("people");

        people.Add(tom);
        people.Add(bob);

        xdoc.Add(people);

        xdoc.Save("people.xml");


    }


    public void print_XML()
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("people.xml");
     
        XmlElement? xRoot = xDoc.DocumentElement;
        if (xRoot != null)
        {
       
            foreach (XmlElement xnode in xRoot)
            {
                
                XmlNode? attr = xnode.Attributes.GetNamedItem("name");
                Console.WriteLine(attr?.Value);

               
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                   
                    if (childnode.Name == "company")
                    {
                        Console.WriteLine($"Company: {childnode.InnerText}");
                    }
                   
                    if (childnode.Name == "age")
                    {
                        Console.WriteLine($"Age: {childnode.InnerText}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}


class ZIP
{
    string path = "./start";
    string path_z = "./arc.zip";
    string extractPath = "./";

    public void Cereate_ZIP()
    {

        Directory.CreateDirectory("./start");
        ZipFile.CreateFromDirectory(path, path_z);

        Console.WriteLine("Выберите файл: 1-текстовый, 2-json, 3-xml\n");

        string ans = Console.ReadLine();


    a1: switch (ans)
        {
            case "1":
                {
                    using (ZipArchive zipArchive = ZipFile.Open(path_z, ZipArchiveMode.Update))
                    {
                        string pathFileToAdd = @"./file.txt";
                        string nameFileToAdd = "file.txt";
                        zipArchive.CreateEntryFromFile(pathFileToAdd, nameFileToAdd);
                        File.Delete("./file.txt");
                    }

                    FileInfo arc_info = new FileInfo("./arc.zip");

                    if (arc_info.Exists)
                    {
                        Console.WriteLine($"Имя файла: {arc_info.Name}");
                        Console.WriteLine($"Время создания: {arc_info.CreationTime}");
                        Console.WriteLine($"Размер: {arc_info.Length}");
                    }

                    using (ZipArchive zipArchive = ZipFile.Open(path_z, ZipArchiveMode.Read))
                    {
                        ZipFile.ExtractToDirectory(path_z, extractPath);
                    }

                    FileInfo f = new FileInfo("./file.txt");

                    if (f.Exists)
                    {
                        Console.WriteLine($"Имя файла: {f.Name}");
                        Console.WriteLine($"Время создания: {f.CreationTime}");
                        Console.WriteLine($"Размер: {f.Length}");
                    }
                    
                    




                    break;
                }
            case "2":
                {
                    using (ZipArchive zipArchive = ZipFile.Open(path_z, ZipArchiveMode.Update))
                    {
                        string pathFileToAdd = @"./file.json";
                        string nameFileToAdd = "file.json";
                        zipArchive.CreateEntryFromFile(pathFileToAdd, nameFileToAdd);
                        File.Delete("./file.json");
                      
                    }
                    
                FileInfo arc_info = new FileInfo("./arc.zip");

                if (arc_info.Exists)
                {
                    Console.WriteLine($"Имя файла: {arc_info.Name}");
                    Console.WriteLine($"Время создания: {arc_info.CreationTime}");
                    Console.WriteLine($"Размер: {arc_info.Length}");
                }

                using (ZipArchive zipArchive = ZipFile.Open(path_z,ZipArchiveMode.Read))
                {
                   ZipFile.ExtractToDirectory(path_z, extractPath);
                }

                FileInfo f = new FileInfo("./file.json");

                if (f.Exists)
                {
                    Console.WriteLine($"Имя файла: {f.Name}");
                    Console.WriteLine($"Время создания: {f.CreationTime}");
                    Console.WriteLine($"Размер: {f.Length}");
                }



                    break;
                }
            case "3":
                {
                    using (ZipArchive zipArchive = ZipFile.Open(path_z, ZipArchiveMode.Update))
                    {
                        string pathFileToAdd = @"./people.xml";
                        string nameFileToAdd = "people.xml";
                        zipArchive.CreateEntryFromFile(pathFileToAdd, nameFileToAdd);
                      
                        File.Delete("./people.xml");
                     
                    }




                    FileInfo arc_info = new FileInfo("./arc.zip");

                    if (arc_info.Exists)
                    {
                        Console.WriteLine($"Имя файла: {arc_info.Name}");
                        Console.WriteLine($"Время создания: {arc_info.CreationTime}");
                        Console.WriteLine($"Размер: {arc_info.Length}");
                    }

                    using (ZipArchive zipArchive = ZipFile.Open(path_z, ZipArchiveMode.Read))
                    {
                        ZipFile.ExtractToDirectory(path_z, extractPath);
                    }

                    FileInfo f = new FileInfo("./people.xml");

                    if (f.Exists)
                    {
                        Console.WriteLine($"Имя файла: {f.Name}");
                        Console.WriteLine($"Время создания: {f.CreationTime}");
                        Console.WriteLine($"Размер: {f.Length}");
                    }


                    break;
                }
            default:
                Console.WriteLine("Вы ввели неверное число. 1-текстовый, 2-json, 3-xml");
                ans = Console.ReadLine();
                goto a1;

        }
       
    }


    /*public void un_arc()
    {
        FileInfo arc_info = new FileInfo("./arc.zip");

        if (arc_info.Exists)
        {
            Console.WriteLine($"Имя файла: {arc_info.Name}");
            Console.WriteLine($"Время создания: {arc_info.CreationTime}");
            Console.WriteLine($"Размер: {arc_info.Length}");
        }

        using (ZipArchive zipArchive = ZipFile.Open(path_z,ZipArchiveMode.Read))
        {
           ZipFile.ExtractToDirectory(path_z, extractPath);
        }

        FileInfo f = new FileInfo("./start/");

        if (f.Exists)
        {
            Console.WriteLine($"Имя файла: {f.Name}");
            Console.WriteLine($"Время создания: {f.CreationTime}");
            Console.WriteLine($"Размер: {f.Length}");
        }



    }*/
}




class del
{
    public void del_file()
    {
        File.Delete("./file.txt");
        File.Delete("./file.json");
        File.Delete("./people.xml");
        File.Delete("./arc.zip");
        Directory.Delete("./start"); 
    }


}

class print{

    string a;
   
       public void show()
    {

        Console.WriteLine("1.Информация о дисках");
        Console.WriteLine("2.Создание текстового файла");
        Console.WriteLine("3.Создание json файла");
        Console.WriteLine("4.Создание xml файла");
        Console.WriteLine("5.Создание zip файла");
        Console.WriteLine("0.Выход");
        
    }
    
    public void menu()
    {
        
        do
        {
            show();
           
            a = Console.ReadLine();
        
        b: switch (a)
                {
                    case "1":
                        {
                            Drive_info d = new Drive_info();

                            d.getinfo();
                        }
                        break;

                    case "2":
                        {

                            Create_fiele f = new Create_fiele();

                            f.fileAsync();
                        }
                        break;


                    case "3":
                        {
                            Create_JSON j = new Create_JSON();

                            j.Create_json();
                        }
                        break;



                    case "4":
                        {
                            Create_XML x = new Create_XML();

                            x.Creat_xml();
                            x.print_XML();
                        }
                        break;

                    case "5":
                        {
                            ZIP z = new ZIP();

                            z.Cereate_ZIP();



                            del del = new del();

                            del.del_file();
                        }
                        break;
                    case "0":
                    {
                        System.Environment.Exit(1);
                        break;
                    }
                    default:
                        Console.WriteLine("Вы выбрали не существующую функцию");
                        Console.WriteLine("\n");
                        menu();
                        a = Console.ReadLine();
                        
                        goto b;
                  

            }
            Console.WriteLine("Для продолжения  нажмите enter");
            Console.WriteLine("\n");
            if ( a != "0")
                
            {
                
                Console.ReadLine();
               
            }

        }

        while (a !="0");
        


    }

}









