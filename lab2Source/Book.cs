using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2Source
{
    [Serializable]
    public class Book : Source
    {
        public DateTime YearOfPublishing;//Год издания
        public string Publisher;//Название Издательство

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Book()
        {

        }
        /// <summary>
        /// Конструктор Книги с параметрами 
        /// </summary>
        /// <param name="NameAuthor">Имя Автора</param>
        /// <param name="NameArticle">Названия издания</param>
        /// <param name="Publisher">Названия Издательства</param>
        /// <param name="YearOfPublishing">Год издательства</param>
        public Book(string NameAuthor, string NameArticle, string Publisher, DateTime YearOfPublishing)
        {
            this.NameAuthor = NameAuthor;
            this.NameArticle = NameArticle;
            this.Publisher = Publisher;
            this.YearOfPublishing = YearOfPublishing;
        }
        /// <summary>
        /// Конструктор копирования Книги
        /// </summary>
        /// <param name="book">Объект Книги</param>
        public Book(Book book)
        {
            this.NameAuthor =book.NameAuthor;
            this.NameArticle = book.NameArticle;
            this.Publisher = book.Publisher;
            this.YearOfPublishing = book.YearOfPublishing;
        }

        /// <summary>
        /// функия, вывода на эран основной информации о классе
        /// </summary>
        public override void OutOnDiplay()
        {
            Console.WriteLine("Book :\\\\ Name Author: {0}, Name Article: {1}, Publisher: {2}, Year: {3}", NameAuthor, NameArticle, Publisher, YearOfPublishing.ToString());
        }
    }
}
