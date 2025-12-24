namespace FileSystemLab
{
    public class Audio : File
    {
        public double DurationSeconds { get; set; }

        public Audio(string name, double sizeMb, string content, double duration)
            : base(name, "mp3", sizeMb, content)
        {
            DurationSeconds = duration;
        }

        public override string ToString()
        {
            return base.ToString() + $", Длительность: {DurationSeconds}с (Аудио)";
        }
    }
}