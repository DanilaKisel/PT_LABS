namespace FileSystemLab
{
    public class File
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public double SizeMB { get; set; } 
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }

        public File(string name, string extension, double sizeMb, string content)
        {
            Name = name;
            Extension = extension;
            SizeMB = sizeMb;
            CreationDate = DateTime.Now;
            Content = content;
        }
        public virtual void Open()
        {
            Console.WriteLine($"--- Открытие файла: {Name}.{Extension} ---");
            Console.WriteLine($"Содержимое: {Content}");
            Console.WriteLine("-------------------------------------------");
        }

        public override string ToString()
        {
            return $"{Name}.{Extension} ({SizeMB} МБ) от {CreationDate}";
        }
    }
}