using System.Text;

namespace FileSystemLab
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            
            Folder folder1 = new Folder("Work Docs", "1234");
            Folder folder2 = new Folder("Media", "0000");

            Console.WriteLine("=== ЗАПОЛНЕНИЕ ПАПКИ 1 ===");
            File txt1 = new TextDocument("Report", 1.5, "Annual report content...", 10);
            File vid1 = new Video("Meeting", 500, "Zoom recording", true, "video123");
            File aud1 = new Audio("VoiceMemo", 5.2, "Note to self", 120);
            File photo1 = new Photo("Diagram", 2.0, "UML diagram image", "1920x1080", "photo123");
            File txtDuplicate = new TextDocument("Report", 1.5, "Copy", 10); 
            File txt2 = new TextDocument("Notes", 0.5, "Meeting notes", 2);

            folder1.AddToFolder(txt1);
            folder1.AddToFolder(vid1);
            folder1.AddToFolder(aud1);
            folder1.AddToFolder(photo1);
            folder1.AddToFolder(txtDuplicate); // ошибка
            folder1.AddToFolder(txt2);

            Console.WriteLine("\n=== ЗАПОЛНЕНИЕ ПАПКИ 2 ===");
            File vid2 = new Video("Movie", 1500, "Action movie", true, "pass");
            File vid3 = new Video("Clip", 50, "Short clip", false, "pass");
            File photo2 = new Photo("Selfie", 3.5, "Me at park", "4000x3000", "pass");
            File aud2 = new Audio("Song", 10.0, "Rock music", 300);
            File txt3 = new TextDocument("Lyrics", 0.1, "Song lyrics", 1);

            folder2.AddToFolder(vid2);
            folder2.AddToFolder(vid3);
            folder2.AddToFolder(photo2);
            folder2.AddToFolder(aud2);
            folder2.AddToFolder(txt3);

            Console.WriteLine("\n=== ТЕСТЫ ===");
            
            // 1. Открытие папки
            Console.WriteLine("Попытка открыть папку 1 (введите 1234):");
            folder1.OpenFolder();

            // 2. Удаление
            Console.WriteLine("\nУдаляем 'VoiceMemo':");
            folder1.DeleteFromFolder(aud1);

            // 3. Сравнение веса
            Console.WriteLine($"\nВес папки 1: {folder1.CalculateTotalCapacity()} МБ");
            Console.WriteLine($"Вес папки 2: {folder2.CalculateTotalCapacity()} МБ");
            Console.WriteLine($"Папки равны по весу? {folder1 == folder2}");

            // 4. Получение видео
            Console.WriteLine("\nВидео из Папки 2:");
            var videos = folder2.GetAllVideos();
            foreach (var v in videos) Console.WriteLine($" - {v.Name}");

            // 5. Открытие защищенного файла
            Console.WriteLine("\nПопытка открыть видео (введите video123):");
            vid1.Open();

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}