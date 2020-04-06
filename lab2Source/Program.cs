using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab2Source
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriterTraceListener trac = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(trac);

            //есть ли файл?
            FileInfo file = new FileInfo("input.txt");
            bool isFileExists = false;
            if (file.Exists)
            {
                isFileExists = true;
                Trace.WriteLine("файл input.txt найден");
            }

            //Если файл не найден создаем
            if (!isFileExists)
            {
                StreamWriter tmp = new StreamWriter("input.txt");
                tmp.Close();
                Trace.WriteLine("файл input.txt был создан");
            }


            StreamReader reader = new StreamReader("input.txt");
            //Если файл можно считать, то узнать количество считываемых источников
            uint n = 0;
            if (!uint.TryParse(reader.ReadLine(), out n))//если первая строку можно считать и строку можно переделать в число
            {
                //Console.WriteLine("no values!");
                Trace.WriteLine("no values in input");
                Console.ReadKey();
                return;
            }
            // Лист для обработки данных, массив для сериализации
            List<Source> book = new List<Source>(Convert.ToInt32(n));
            Source[] bookSer = new Source[n];
            try
            {
                for (int i = 0; i < n; i++)
                {
                    string info = reader.ReadLine();

                    string[] measures = info.Split(',');
                    if (measures.Length == 4)// если найдено в строке найдено ровно 4 параметра
                    {
                        DateTime dateTime;
                        bool res = DateTime.TryParse(measures[3],out dateTime);//если четвертый параметр можно превратить в дату, то определить данную строку, как информацию о книге
                        if (res)
                        {
                            book.Add(new Book(measures[0], measures[1],measures[2],dateTime));
                            bookSer[i] = new Book(measures[0], measures[1], measures[2], dateTime);
                        }
                        else //иначе определить строку, как информацию об электронный ресурс
                        {
                            book.Add(new EResources(measures[0], measures[1], measures[2], measures[3]));
                            bookSer[i] = new EResources(measures[0], measures[1], measures[2], measures[3]);
                        }
                    }
                    else if (measures.Length == 5)//еслм же в строке 5 параметров, то определить данную строку, как информацию о журнале
                    {
                        book.Add(new Paper(measures[0], measures[1], measures[2], Convert.ToInt32(measures[3]), Convert.ToDateTime(measures[4])));
                        bookSer[i] = new Paper(measures[0], measures[1], measures[2], Convert.ToInt32(measures[3]), Convert.ToDateTime(measures[4]));
                    }
                    else// иначе сказать, что для текущей строки не найден форм-фактор ресурса
                    {
                        Console.WriteLine("Считывания строки не произошло");
                    }
                }

                //вывод всех успешно созданных элементов на основе файла
                Console.WriteLine("Информация об источнике");
                foreach (Source source in book)
                    source.OutOnDiplay();
                reader.Close();

                //сериализация
                XmlSerializer formatter = new XmlSerializer(typeof(Source[]));
                using (FileStream fs = new FileStream("Source.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, bookSer);
                    Trace.WriteLine("Объект сериализован");
                }

                //Поиск изданий по автору
                Console.WriteLine("Введите Фамилию автора, издания которого хотите найти:");
                string nameAuthor = Console.ReadLine();
                SearchByAuthor(nameAuthor,book); 
            }
            catch
            { 
                Trace.WriteLine("ошибка при чтении данных");
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Фукнция поиска издания по автору
        /// </summary>
        /// <param name="NameAuthor">Фамилия автора</param>
        /// <param name="sources"> List<Source> в котором нужно производить поиск</param>
        static public void SearchByAuthor(string NameAuthor, List<Source> sources)
        {
            foreach (Source source in sources)//сначала определяем какие источники нам подходят
                source.IsDesired(NameAuthor);

            List<Source> foundSources = sources.FindAll(item => item.FlagFinded== true);//создаем список нужных нам источников

            if (foundSources.Count > 0)//если есть хотя бы 1 элемент выводим все найденные элементы
            {
                Console.WriteLine("Информация о издании, искомого автора");
                foreach (Source foundSource in foundSources)
                    foundSource.OutOnDiplay();
            }
            else //иначе сообщаем о неудаче
            {
                Console.WriteLine("Информация о издании, искомого автора не найдена (их нет)");
            }
            Trace.WriteLine("поиск реализован");
        }
    }
}
