using Newtonsoft.Json;


namespace SimpleLibrary
{
    public class Repository
    {
        private static readonly string DbFilePathLibraries = @"D:\beetroot\DbFolder\db_Libraries.json";
        private List<LibraryEntity> _libStorage = ReadLibraryStorage(DbFilePathLibraries);
        
        private static readonly string DbFilePathBooks = @"D:\beetroot\DbFolder\db_Books.json";
        private List<BookEntity> _bookStorage = ReadBookStorage(DbFilePathBooks);


        public IList<LibraryEntity> GetAllLibs()
        {
            return _libStorage;
        }
        public IList<BookEntity> GetAllBooks()
        {
            return _bookStorage;
        }

        public LibraryEntity GetLibrary(int id)
        {
            var storageEntity = _libStorage.First(ent => ent.Id == id);

            return storageEntity;
        }

        public BookEntity GetBook(int id)
        {
            var storageEntity = _bookStorage.First(ent => ent.Id == id);

            return storageEntity;
        }
        public void InsertLibrary(LibraryEntity entity)
        {
            if (entity.LibTitle == null)
            {
                entity.LibTitle = Service.AskLibraryTitle();
            }
            if (entity.Id <= 0)
            {
                entity.Id = (_libStorage.OrderByDescending(ent => ent.Id).FirstOrDefault()?.Id ?? 0) + 1;
            }
            if (_libStorage.Any(ent => ent.Id == entity.Id))
                throw new Exception("Duplicated Id.");

            _libStorage.Add(entity);
            SaveStorage(_libStorage);
        }

        public void InsertBook(BookEntity entity)
        {
            if (entity.Id <= 0)
            {
                entity.Id = (_bookStorage.OrderByDescending(ent => ent.Id).FirstOrDefault()?.Id ?? 0) + 1;
            }
            if (_bookStorage.Any(ent => ent.Id == entity.Id))
                throw new Exception("Duplicated Id.");

            _bookStorage.Add(entity);
            SaveStorage(_bookStorage);
        }
        private static void EnshureDbFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }
        }

        private static List<LibraryEntity> ReadLibraryStorage(string filePath)
        {
            EnshureDbFile(filePath);

            var text = File.ReadAllText(filePath);

            var entities = JsonConvert.DeserializeObject<List<LibraryEntity>>(text);

            return entities ?? new List<LibraryEntity>();
        }
        private static List<BookEntity> ReadBookStorage(string filePath)
        {
            EnshureDbFile(filePath);

            var text = File.ReadAllText(filePath);

            var entities = JsonConvert.DeserializeObject<List<BookEntity>>(text);

            return entities ?? new List<BookEntity>();
        }

        private static void SaveStorage(List<LibraryEntity> entities)
        {
            var text = JsonConvert.SerializeObject(entities);

            File.WriteAllText(DbFilePathLibraries, text);
        }

        private static void SaveStorage(List<BookEntity> entities)
        {
            var text = JsonConvert.SerializeObject(entities);

            File.WriteAllText(DbFilePathBooks, text);
        }
    }
}
