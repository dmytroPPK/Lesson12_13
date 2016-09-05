using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson12_13.Core;

namespace Lesson12_13
{
    partial class Program
    {
        
        private School school;
        private Subjects subjects;
        private MySerializator myslr;
        private string menustr;
        private string enteredvalue;
        private bool isDefaultInit;
        

        public Program(string datfile_, bool initDefaultData_ = false)
        {
            //DatFile = datfile_;
            myslr = new MySerializator(datfile_);
            isDefaultInit = initDefaultData_;
        }
        public void CheckDat()
        {
            if (!myslr.FileIsExist())
            {
                school = new School();
                subjects = school.GetSubjects();
                if (isDefaultInit)
                {
                    MyInit.InitDefaultData(school,subjects);
                }
            }
            else
            {
                school = myslr.FromFile();
                subjects = school.GetSubjects();
            }
        }

        

        public void Menu()
        {
            menustr = IniMenuText();
            while (true)
            {
                Console.Clear();
                Console.Write(menustr);
                enteredvalue = Console.ReadLine();
                switch (enteredvalue.Trim().ToLower())
                {
                    case "1":
                        ShowAverScore();
                        break;
                        
                    case "2":
                        ShowAgeAverScore();
                        break;
                        
                    case "3":
                        ShowAllList();
                        break;
                        
                    case "4":
                        AddChild();
                        break;
                        
                    case "5":
                        AddSubject();
                        break;
                        
                    case "exit":
                        break;
                        
                    default:
                        continue;
                }
                break;
            }
        }

        private void AddSubject()
        {
            try
            {
                Console.WriteLine("Выбирите ребенка для добавления предмета");
                foreach (var item in school.ChildList)
                {
                    Console.WriteLine($"\tID {item.ID}, Name {item.Name}");
                }

                Console.Write("Ваш выбор:  ");
                var idChild = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"Вы выбрали:\n\t{school[idChild].ToString(true)}");

                Console.WriteLine("Выберите из списка недостающий предмет");
                foreach (var item in subjects.ListSubjects)
                {
                    Console.WriteLine($"ID {item.ID}, Name {item.Name}");

                }
                Console.Write("Ваш выбор:  ");
                var idSubject = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"Вы выбрали:\n\t{subjects[idSubject].Name}");

                Console.Write("Оценка за предмет:  ");
                var scoreSubject = Double.Parse(Console.ReadLine());
                school[idChild].AddSubject(subjects[idSubject], scoreSubject);
                Console.WriteLine($"Предмет  с оценкой добавлен !!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("----  Будьте внимательней. Вводите коректные данные");
                Console.ReadKey();
                Console.Clear();
                AddSubject();
            }
            Console.ReadKey();
            Menu();
        }

        private void AddChild()
        {
            try
            {
                Console.Write("Имя школьника: ");
                var name = Console.ReadLine();
                Console.Write("Возраст школьника: ");
                var age = Int32.Parse(Console.ReadLine());
                school.AddChild(name, age);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Некоректнный возраст");
                Console.ReadKey();
                Console.Clear();
                AddChild();
            }
            Console.WriteLine("школьник добавлен !!!");
            Console.ReadKey();
            Menu();
        }

        private void ShowAllList()
        {
            if(school.ChildList.Count == 0)
                Console.WriteLine("Empty List");
            foreach (var item in school.ChildList)
            {
                Console.WriteLine(  item.ToString(true));
            }
            Console.ReadKey();
            Menu();
        }

        private void ShowAgeAverScore()
        {
            try
            {
                Console.Write("Введите возраст: ");
                var value = Int32.Parse(Console.ReadLine());
                var list = school.ChildList.Where(c => c.Age > value);

                if (list.Count() == 0)
                    Console.WriteLine("Empty List");
                foreach (var item in list)
                {
                    Console.WriteLine(item as SchoolChild);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некоректный формат данных");
                Console.ReadKey();
                Console.Clear();
                ShowAgeAverScore();
            }
            Console.ReadKey();
            Menu();
        }

        private void ShowAverScore()
        {

            if (school.ChildList.Count == 0)
                Console.WriteLine("Empty List");
            foreach (var item in school)
            {
                Console.WriteLine(item as SchoolChild);
            }
            Console.ReadKey();
            Menu();
        }

        private string IniMenuText()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("1. Средний бал учеников").AppendLine();
            builder.Append("2. Средний бал учеников старше возраста").AppendLine();
            builder.Append("3. Список учеников(полн информация)").AppendLine();
            builder.Append("4. Добавить ученика").AppendLine();
            builder.Append("5. Добавить ученику предмет с оценков ").AppendLine();
            builder.Append("Для выхода наберите < exit >").AppendLine();
            builder.Append("\n\t\tВаше действие:  ");
            return builder.ToString();
        }
        public void Final()
        {
            myslr.InFile(school);
        }

    }
}
