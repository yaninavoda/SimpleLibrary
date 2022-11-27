using Newtonsoft.Json;


namespace SimpleLibrary
{
    public class Repository
    {
        private static readonly string DbFilePathLibraries = @"D:\beetroot\DbFolder\db_Libraries.json";
        //private static readonly string DbFilePathBooks = @"D:\beetroot\DbFolder\db_Books.json";
        private List<LibraryEntity> _libStorage = ReadStorage(DbFilePathLibraries);


        public IList<LibraryEntity> GetAll()
        {
            return _libStorage;
        }
        public void Insert(LibraryEntity entity)
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
        private static void EnshureDbFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }
        }

        private static List<LibraryEntity> ReadStorage(string filePath)
        {
            EnshureDbFile(filePath);

            var text = File.ReadAllText(filePath);

            var entities = JsonConvert.DeserializeObject<List<LibraryEntity>>(text);

            return entities ?? new List<LibraryEntity>();
        }

        private static void SaveStorage(List<LibraryEntity> entities)
        {
            var text = JsonConvert.SerializeObject(entities);

            File.WriteAllText(DbFilePathLibraries, text);
        }
    }
}
