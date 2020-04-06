using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2Source
{
    [Serializable]
    public class Paper : Source
    {
        string NamePaper; //Название журнала
        int Number; //Номер издания
        DateTime YearOfPublishing; //Год публикации

        /// <summary>
        /// Конструктор  Журнала по умолчанию
        /// </summary>
        public Paper()
        {

        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="NameAuthor"></param>
        /// <param name="NameArticle"></param>
        /// <param name="NamePaper"></param>
        /// <param name="Number"></param>
        /// <param name="YearOfPublishing"></param>
        public Paper(string NameAuthor, string NameArticle, string NamePaper, int Number, DateTime YearOfPublishing)
        {
            this.NameAuthor = NameAuthor;
            this.NameArticle = NameArticle;
            this.NamePaper = NamePaper;
            this.Number = Number;
            this.YearOfPublishing = YearOfPublishing;

        }
        /// <summary>
        /// Конструктор копирования Журнала
        /// </summary>
        /// <param name="paper">экземпляр класса Журанал для копирования</param>
        public Paper(Paper paper)
        {
            this.NameAuthor = paper.NameAuthor;
            this.NameArticle = paper.NameArticle;
            this.NamePaper = paper.NamePaper;
            this.Number = paper.Number;
            this.YearOfPublishing = paper.YearOfPublishing;

        }

        /// <summary>
        ///  функия, вывода на эран основной информации о классе
        /// </summary>
        public override void OutOnDiplay()
        {
            Console.WriteLine("Book :\\\\ Name Author: {0}, Name Article: {1}, Name Paper: {2},№{3}, Year: {4}", NameAuthor, NameArticle, NamePaper, Number.ToString(), YearOfPublishing.ToString());
        }
    }
}
