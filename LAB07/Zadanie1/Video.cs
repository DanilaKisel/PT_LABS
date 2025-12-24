namespace FileSystemLab
{
    public class Video : File, IEncrypted
    {
        public bool IsHD { get; set; }
        public string Password { get; set; }

        public Video(string name, double sizeMb, string content, bool isHd, string password)
            : base(name, "mp4", sizeMb, content)
        {
            IsHD = isHd;
            Password = password;
        }

        public override void Open()
        {
            Console.Write($"Введите пароль для просмотра видео {Name}: ");
            string input = Console.ReadLine();

            if (input == Password)
            {
                Console.WriteLine($"Доступ разрешен! Видео: {Content} (HD: {IsHD})");
            }
            else
            {
                Console.WriteLine("Неверный пароль. Доступ к видео запрещен.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + " [VIDEO]";
        }
    }
}