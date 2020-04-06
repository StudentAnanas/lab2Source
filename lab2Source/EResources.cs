using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2Source
{
    [Serializable]
    public class EResources : Source
    {   
        public string Src;//сылка на источник
        public string Note;//аннотация на источник
        /// <summary>
        /// Конструктор Электронного ресурса по умолчанию
        /// </summary>
        public EResources()
        {

        }
        /// <summary>
        /// Конструктор Электронного ресурса с параметрами
        /// </summary>
        /// <param name="NameAuthor"> Имя Автора</param>
        /// <param name="NameArticle">Название Ресурса</param>
        /// <param name="Src">Ссылка на источник</param>
        /// <param name="Note">Аннотация источника</param>
        public EResources(string NameAuthor, string NameArticle, string Src, string Note) 
        {
            this.NameAuthor = NameAuthor;
            this.NameArticle = NameArticle;
            this.Src = Src;
            this.Note = Note;

        }
        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="eResources">объект класса Электронный ресурс</param>
        public EResources(EResources eResources)
        {
            this.NameAuthor = eResources.NameAuthor;
            this.NameArticle = eResources.NameArticle;
            this.Src = eResources.Src;
            this.Note = eResources.Note;

        }
        /// <summary>
        /// функия, вывода на эран основной информации о классе
        /// </summary>
        public override void OutOnDiplay()
        {
            Console.WriteLine("Book :\\\\ Name Author: {0}, Name Article: {1}, Src: {2}, Note: {3}", NameAuthor, NameArticle, Src, Note);
        }
    }
}
