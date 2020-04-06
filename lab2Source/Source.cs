using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab2Source
{
    [XmlInclude(typeof(EResources))]
    [XmlInclude(typeof(Paper))]
    [XmlInclude(typeof(Book))]
    [Serializable]
    public abstract class Source
    {

        public string NameAuthor;//Имя автора
        public string NameArticle;//Название издания
        public bool FlagFinded;//Флаг поиска
        
        /// <summary>
        /// Конструктор источника по умолчанию
        /// </summary>
        /// <param name="NameAuthor">Имя Автора</param>
        /// <param name="NameArticle">Название издания</param>
        public Source(string NameAuthor, string NameArticle)
        {
            this.NameAuthor = NameAuthor;
            this.NameArticle = NameArticle;
        }
        /// <summary>
        /// Конструктор источника по умолчанию
        /// </summary>
        public Source()
        {

        }
        /// <summary>
        /// Функция, которая определяет является ли данное издание искомым
        /// </summary>
        /// <param name="NameAuthor">Имя Автора</param>
        public  void IsDesired(string NameAuthor) {
            if (this.NameAuthor == NameAuthor)
            {
                FlagFinded = true;
            }
            else
            {
                FlagFinded = false;
            }
        }
        /// <summary>
        /// Абстрактная функция вывода на экран
        /// </summary>
        public abstract void OutOnDiplay();
    }
}
