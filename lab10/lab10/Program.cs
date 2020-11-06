using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace lab10
{
    interface ITVprogram
    {
        void Watch();
        void Show();
    }
    abstract class TVprogram
    {
        public int agelimit;
    }

    class Film : TVprogram, ITVprogram
    {
        public string name;
        public int year;
        public int limit = 16;
        public Film(string name, int year)
        {
            this.year = year;
            this.name = name;
        }
        public void Watch()
        {
            if (agelimit > limit)
            {
                Console.WriteLine("Вам разрешено смотреть этот фильм");
            }
            else
            {
                Console.WriteLine("Вам рано еще смотреть этот фильм");
            }
        }
        public virtual void Show()
        {
            Console.WriteLine("\n\nНазвание: " + name + "\n" + "Год: " + year + "\n");
        }
    }
    public class Student
    {
        private string name;
        private int age;
        public string Name
        {
            get {return name; }
            set {name=value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList col1 = new ArrayList() { 1, 2, 3, 4, 5 };
            string str = "Elena";
            col1.Add(str);
            Student person1 = new Student("Valera", 19);
            col1.Add(person1);
            col1.RemoveAt(1);
            foreach(object o in col1)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine(col1.Count);
            Console.WriteLine(col1.Contains(person1));
            Console.WriteLine(col1.Contains(99));
            //закончилось 1 задание

            SortedList<int, long> col2 = new SortedList<int, long>();
            col2.Add(1, 12);
            col2.Add(2, 88);
            col2.Add(3, 65);
            col2.Add(4, 1111);
            foreach (KeyValuePair<int, long> o in col2)
            {
                Console.WriteLine("Number "+o.Key+" Meaning "+o.Value);
            }
            Stack<long> col2_2 = new Stack<long>();//снвчала в коллекцию, потом удаление
            IList<long> list = col2.Values;
            for (int i = 0; i < list.Count; i++)
            {
                col2_2.Push(list[i]);
            }
            foreach (long o in col2_2)
            {
                Console.WriteLine(o);
            }
            for (int i = col2.Count - 1; i >= 0; i--)
            {
                col2.RemoveAt(i);
            }
            Console.WriteLine(col2.ContainsValue(88));//нету, так как удалили элементы
            Console.WriteLine(col2_2.Contains(88));//есть, так как перезаписали
            //конец 2 задания

            SortedList<string, Film> col3 = new SortedList<string, Film>();
            Film matrix = new Film("Matrix", 1999);
            Film avengers = new Film("The Avengers", 2012);
            col3.Add("1 film: ", matrix);
            col3.Add("2 film: ", avengers);
            foreach (KeyValuePair<string, Film> o in col3)
            {
                Console.WriteLine("Number " + o.Key + " Name of film " + o.Value.name);
            }
            Stack<Film> col3_2 = new Stack<Film>();//снвчала в коллекцию, потом удаление
            IList<Film> films = col3.Values;
            for (int i = 0; i < films.Count; i++)
            {
                col3_2.Push(films[i]);
            }
            foreach (Film o in col3_2)
            {
                Console.WriteLine(o.name);
            }
            for (int i = col3.Count - 1; i >= 0; i--)
            {
                col3.RemoveAt(i);
            }
            Console.WriteLine(col3.ContainsValue(matrix));//нету, так как удалили элементы
            Console.WriteLine(col3_2.Contains(matrix));//есть, так как перезаписали
            //конец 3 задания

            ObservableCollection<Film> col4 = new ObservableCollection<Film>();
            void col4_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    // Следующая строка сработает если в коллекцию был добавлен элемент.
                    case NotifyCollectionChangedAction.Add:
                        Film newFilm = e.NewItems[0] as Film;
                        Console.WriteLine("Добавлен новый объект: {0}", newFilm.name);
                        break;
                    // Следующая строка если элемент был удален из коллекции.
                    case NotifyCollectionChangedAction.Remove:
                        Film oldFilm = e.OldItems[0] as Film;
                        Console.WriteLine("Удален объект: {0}", oldFilm.name);
                        break;
                }
            }
            col4.CollectionChanged += col4_CollectionChanged;
            col4.Add(new Film("Fight club", 1999));
            col4.Add(new Film("Green mile", 1998));
            col4.Add(new Film("American beauty", 1980));
            col4.Add(new Film("Devil's advokate", 1997));
            col4.RemoveAt(0);
            foreach (Film filmssss in col4)
            {
                Console.WriteLine(filmssss.name);
            }
        }
        
        
    }
}
