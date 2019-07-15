namespace WebAPI.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WebAPIDB : DbContext
    {
        // Контекст настроен для использования строки подключения "WebAPIDB" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "WebAPI.DataBase.WebAPIDB" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "WebAPIDB" 
        // в файле конфигурации приложения.
        public WebAPIDB()
            : base("name=WebAPIDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<WebAPIDB>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WebAPIDB>());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}