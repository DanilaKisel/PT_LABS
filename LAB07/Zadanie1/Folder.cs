namespace FileSystemLab
{
    public class Folder : IEncrypted
    {
        public string FolderName { get; set; }
        public string Password { get; set; }
        private List<File> files = new List<File>();

        public Folder(string folderName, string password)
        {
            FolderName = folderName;
            Password = password;
        }

        public void AddToFolder(File f)
        {
            if (files.Any(x => x.Name == f.Name && x.Extension == f.Extension))
            {
                Console.WriteLine($"Ошибка: Файл {f.Name}.{f.Extension} уже существует в папке {FolderName}.");
            }
            else
            {
                files.Add(f);
                Console.WriteLine($"Файл {f.Name} добавлен в папку {FolderName}.");
            }
        }

    
        public void DeleteFromFolder(File f)
        {
            if (files.Contains(f))
            {
                files.Remove(f);
                Console.WriteLine($"Файл {f.Name} удален из папки {FolderName}.");
            }
            else
            {
                Console.WriteLine($"Файл {f.Name} не найден в папке.");
            }
        }

    
        public double CalculateTotalCapacity()
        {
            return files.Sum(f => f.SizeMB);
        }

        
        public List<File> GetAllVideos()
        {
            return files.OfType<Video>().Cast<File>().ToList();
        }

      
        public void OpenFolder()
        {
            Console.Write($"\nВведите пароль для открытия папки '{FolderName}': ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string input = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (input == Password)
            {
                Console.WriteLine($"\n--- Содержимое папки {FolderName} (сортировка по дате) ---");
                var sortedFiles = files.OrderBy(f => f.CreationDate).ToList();

                if (sortedFiles.Count == 0)
                {
                    Console.WriteLine("(Папка пуста)");
                }

                foreach (var file in sortedFiles)
                {
                    Console.WriteLine(file.ToString());
                }
                Console.WriteLine("----------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Неверный пароль. Доступ к папке запрещен.");
            }
        }

        
        public static bool operator ==(Folder f1, Folder f2)
        {
            if (ReferenceEquals(f1, f2)) return true;
            if (ReferenceEquals(f1, null) || ReferenceEquals(f2, null)) return false;

            return f1.CalculateTotalCapacity() == f2.CalculateTotalCapacity();
        }

        public static bool operator !=(Folder f1, Folder f2)
        {
            return !(f1 == f2);
        }

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        {
            if (obj is Folder otherFolder)
            {
                return this.CalculateTotalCapacity() == otherFolder.CalculateTotalCapacity();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CalculateTotalCapacity().GetHashCode();
        }
    }
}