using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;




namespace CodeFirstMVC.Models
{                                           
    public class SalarieContext : DbContext // le DbContext fait parti intégrant d'entity framework, c'est la brique centrale et une session de communication avec la base de donnée. Ce qui notamment nous permet de faire le CRUD.
                                            //Donc permet également d'enregistrer des instances, ou de récupérer des instances. Il vient de Microsoft.EntityFrameworkCore .
    {


        //C'est un constructeur du DbContext qui reçoit en argument des options, les options sont de types dbcontextOptions de la classe context.
        // Qui hérite bien sûr du constructeur de base, et donc de mon objet de base DbContext.
        //C'est comme ça qu'on déclare un constructeur du DbContext.
        public SalarieContext(DbContextOptions<SalarieContext> options)
            : base(options)
        {
        }

        //2 évènements: Méthodes OnConfiguring() et OnModelCreating().
        // La méthode OnConfiguring() nous permet de selectionner et de configurer la source de données à utiliser avec un contexte utilisant DbContextOptionsBuilder.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }


        //Le modèle "OnModelCreating()" se déclenche quand on va créer un modèle de l'autre côté grâce aux migrations (qd on crée la base de donnée).
        //la base DbContext vient déjà avec un "OnmodelCreating()" qu'on vient "overrider" cad surcharger 
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder); //Qd on surcharge, on exécute ce qui est par défaut à savoir la classe parent (DbContext). 

            modelBuilder.Entity<Salarie>().ToTable("t_salarie"); // Ensuite on exécute le spécifique, ici donc notre classe fille (où qui hérite de DbContext) "SalarieContext" (nomenclature des tables).
                                                                 //Le ToTable() permet de nommer la table SQL comme on le souhaite.

           // modelBuilder.Entity<Salarie>().Property(s => s.Sal_nom).IsRequired().HasMaxLength(200); //C'est du code API fluent qu'on peut utiliser à la place des datannotations.
                                                                                                      //On peut configurer les propriétés de nos classes en passant par la méthode Property() notamment.
                                                                                                      
                
        }

        //Les DbSet sont des unités utilitaires (groupe de donnée).
        //C'est à travers les DbSet que le DbContext va effectuer le contrôle des données des tables SQL correspondantes.
        //Il contient le contrôle du DAO (data access object) mais à travers un DbSet pour chaque entité (classe).
        public DbSet<Salarie> Salaries { get; set; }
















    }
}
