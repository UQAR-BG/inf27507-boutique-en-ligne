using INF27507_Boutique_En_Ligne.Models;
using Microsoft.EntityFrameworkCore;

namespace INF27507_Boutique_En_Ligne
{
    public class BoutiqueDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseMySql(
                @"server=inf27507-boutique.kyllian.schwedt.fr;
                port=3308;
                database=inf27507-Boutique;
                user=inf27507-Boutique;
                password=RYYkbju7fwmw9pu",
                new MySqlServerVersion(new Version(8, 0, 28))
            );

            //dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=TaskManagerDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(client => client.Id).HasName("pk_clients_id");
            modelBuilder.Entity<Client>().HasMany(client => client.Carts).WithOne(cart => cart.Client);

            modelBuilder.Entity<Seller>().HasKey(seller => seller.Id).HasName("pk_sellers_id");
            modelBuilder.Entity<Seller>().HasMany(seller => seller.Products).WithOne(product => product.Seller);
            modelBuilder.Entity<Seller>().HasData(
                new Seller() { Id = 1, Username = "default-seller", Firstname = "Default", Lastname = "Seller" }
            );

            modelBuilder.Entity<Category>().HasKey(c => c.Id).HasName("pk_categories_id");
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "T-shirts" },
                new Category() { Id = 2, Name = "Manteaux" },
                new Category() { Id = 3, Name = "Pantalons" },
                new Category() { Id = 4, Name = "Jeans" },
                new Category() { Id = 5, Name = "Chemises" },
                new Category() { Id = 6, Name = "Chaussures" },
                new Category() { Id = 7, Name = "Accessoires" }
            );

            modelBuilder.Entity<Product>().HasKey(product => product.Id).HasName("pk_products_id");
            modelBuilder.Entity<Product>().HasOne(product => product.Category);
            modelBuilder.Entity<Product>().HasOne(product => product.Seller).WithMany(seller => seller.Products);
            modelBuilder.Entity<Product>().HasData(
                new Product() {
                    Id = 1,
                    Title = "Le parka duvet McMurdo", 
                    Description = "The North Face au 31\nC'est le parka utilitaire performant pour affronter les temps froids de ville\nChaude isolation en duvet d'oie 550 idéale pour les températures froides\nCoquille Dryvent imperméable et respirante assurant un confort au sec\nCapuchon tempête bordé aspect fourrure amovible\nFermoir zip aller - retour sous patte pression\nPoches pratiques",
                    ShortDescription = "",
                    Image = "wwwroot/img/manteaux_parka_duvet_mcmurdo.jpg",
                    Price = 299.95,
                    SellerId = 1,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = 2,
                    Title = "Le jean tricot bleu délavé Coupe Stockholm - étroite",
                    Description = "Un denim joggjean tissé effet tricot au pigment bleu délavé pour un confort décontracté ultra extensible\nNotre coupe nommée Stockholm désigne un pantalon à jambe étroite et à taille régulière\nModèle 5 poches\nCoton extensible tout confort",
                    ShortDescription = "",
                    Image = "wwwroot/img/jean_tricot_bleu_coupe_stockholm.jpg",
                    Price = 89.00,
                    SellerId = 1,
                    CategoryId = 4
                },
                new Product()
                {
                    Id = 3,
                    Title = "Le sneaker d'hiver Standard Mid MTE Snow",
                    Description = "Vans chez Simons\nCollection MTEMC toutes saisons\nMTE Snow : sous la neige\nPratiques, compressibles et prêtes à sortir en ville, le modèle Standard Mid Snow MTE est une version réduite de la populaire botte d'hiver du même nom. Enfin une chaussure qui fusionne le style classique de Vans aux besoins utilitaires du quotidien!\nTige imperméable en cuir véritable\nConstruction étanche aux coutures scellées\nChaude et douce doublure coussinée avec isolation de 100 g\nSemelle intérieure coussinée amovible\nGanse arrière pour faciliter le chaussage\nCoque de protection en caoutchouc vulcanisé\nSemelle extérieure en caoutchouc Snow MTE à crans dynamiques qui garantissent une adhérence et une flexibilité fiables sur tous les terrains et dans toutes les conditions\nNuméro de modèle : VN0A54FUY28",
                    ShortDescription = "",
                    Image = "wwwroot/img/sneaker_hiver_mid_mte_snow.jpg",
                    Price = 129.95,
                    SellerId = 1,
                    CategoryId = 6
                }
            );

            modelBuilder.Entity<CartItem>().HasKey(item => item.Id).HasName("pk_cartitems_id");
            modelBuilder.Entity<CartItem>().HasOne(item => item.Cart).WithMany(cart => cart.Items);
            modelBuilder.Entity<CartItem>().HasOne(item => item.Product);

            modelBuilder.Entity<Cart>().HasKey(cart => cart.Id).HasName("pk_carts_id");
            modelBuilder.Entity<Cart>().HasOne(cart => cart.Client).WithMany(client => client.Carts);
            modelBuilder.Entity<Cart>().HasMany(cart => cart.Items).WithOne(item => item.Cart);

            modelBuilder.Entity<Order>().HasKey(order => order.Id).HasName("pk_orders_id");
            modelBuilder.Entity<Order>().HasOne(order => order.Cart);
        }
    }
}
