using System;

namespace FileSystemLab
{
    public class TextDocument : File
    {
        public int PageCount { get; set; }

        public TextDocument(string name, double sizeMb, string content, int pages)
            : base(name, "txt", sizeMb, content)
        {
            PageCount = pages;
        }

        public override string ToString()
        {
            return base.ToString() + $", Стр: {PageCount} (Текст)";
        }
    }
}