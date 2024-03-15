using System;
using System.Data.Entity;
using System.Linq;

namespace PIZZERIA_DA_GIGI.Models
{
    public class DBContext : DbContext
    {
        // Il contesto è stato configurato per utilizzare una stringa di connessione 'DbContext' dal file di configurazione 
        // dell'applicazione (App.config o Web.config). Per impostazione predefinita, la stringa di connessione è destinata al 
        // database 'PIZZERIA_DA_GIGI.Models.DbContext' nell'istanza di LocalDb. 
        // 
        // Per destinarla a un database o un provider di database differente, modificare la stringa di connessione 'DbContext' 
        // nel file di configurazione dell'applicazione.
        public DBContext()
            : base("name=DbContext")
        {
        }

        // Aggiungere DbSet per ogni tipo di entità che si desidera includere nel modello. Per ulteriori informazioni 
        // sulla configurazione e sull'utilizzo di un modello Code, vedere http://go.microsoft.com/fwlink/?LinkId=390109.

        //public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ordine> Ordines { get; set; }
        public virtual DbSet<DettaglioOrdine> DettaglioOrdines { get; set; }
         public virtual DbSet<Pizza> Pizzas { get; set; }
       
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}