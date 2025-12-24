namespace FileSystemLab
{
    public class Photo : File, IEncrypted
    {
        public string Resolution { get; set; }
        public string Password { get; set; }

        public Photo(string name, double sizeMb, string content, string resolution, string password)
            : base(name, "jpg", sizeMb, content)
        {
            Resolution = resolution;
            Password = password;
        }

        public override void Open()
        {
            Console.Write($"Введите пароль для просмотра фото {Name}: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string input = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (input == Password)
            {
                Console.WriteLine($"Доступ разрешен! Фото: {Content} (Разрешение: {Resolution})");
            }
            else
            {
                Console.WriteLine("Неверный пароль. Доступ к фото запрещен.");
            }
        }
    }
}