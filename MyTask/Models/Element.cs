using System;
using CsvHelper.Configuration.Attributes;

namespace MyTask.Models
{
    public class Element
    {
        [Index(0)]
        public int Id { set; get; }
        [Index(1)]
        public int ParentId { set; get; }
        [Index(2)]
        public string Text { set; get; } = "";
        public List<Element> Childrens = new List<Element>();
    }
}

