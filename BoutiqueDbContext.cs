using INF27507_Boutique_En_Ligne.Models;
using Microsoft.EntityFrameworkCore;

namespace INF27507_Boutique_En_Ligne
{
    public class BoutiqueDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Usage> Usages { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
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
            modelBuilder.Entity<Client>().HasData(
                new Client() { Id = 1, Username = "Default-User", Firstname = "Default", Lastname = "User", Balance = 250.00 }
            );

            modelBuilder.Entity<Seller>().HasKey(seller => seller.Id).HasName("pk_sellers_id");
            modelBuilder.Entity<Seller>().HasMany(seller => seller.Products).WithOne(product => product.Seller);
            modelBuilder.Entity<Seller>().HasData(
                new Seller() { Id = 1, Username = "Albert", Firstname = "Albert", Lastname = "" },
                new Seller() { Id = 2, Username = "Amélie", Firstname = "Amélie", Lastname = "" },
                new Seller() { Id = 3, Username = "Julie", Firstname = "Julie", Lastname = "" },
                new Seller() { Id = 4, Username = "Xavier", Firstname = "Xavier", Lastname = "" }
            );

            modelBuilder.Entity<Gender>().HasKey(g => g.Id).HasName("pk_genders_id");
            modelBuilder.Entity<Gender>().HasData(
                new Gender() { Id = 1, Name = "Boys" },
                new Gender() { Id = 2, Name = "Girls" },
                new Gender() { Id = 3, Name = "Men" },
                new Gender() { Id = 4, Name = "Women" }
            );

            modelBuilder.Entity<Category>().HasKey(c => c.Id).HasName("pk_categories_id");
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Apparel" },
                new Category() { Id = 2, Name = "Footwear" }
            );

            modelBuilder.Entity<SubCategory>().HasKey(s => s.Id).HasName("pk_subcategories_id");
            modelBuilder.Entity<SubCategory>().HasOne(s => s.Category);
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory() { Id = 1, Name = "Topwear", CategoryId = 1 },
                new SubCategory() { Id = 2, Name = "Bottomwear", CategoryId = 1 },
                new SubCategory() { Id = 3, Name = "Shoes", CategoryId = 2 },
                new SubCategory() { Id = 4, Name = "Flip Flops", CategoryId = 2 },
                new SubCategory() { Id = 5, Name = "Sandal", CategoryId = 2 }
            );

            modelBuilder.Entity<ProductType>().HasKey(p => p.Id).HasName("pk_producttypes_id");
            modelBuilder.Entity<ProductType>().HasOne(p => p.SubCategory);
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType() { Id = 1, Name = "Tshirts", SubCategoryId = 1 },
                new ProductType() { Id = 2, Name = "Tops", SubCategoryId = 1 },
                new ProductType() { Id = 3, Name = "Skirts", SubCategoryId = 2 },
                new ProductType() { Id = 4, Name = "Formal Shoes", SubCategoryId = 3 },
                new ProductType() { Id = 5, Name = "Casual Shoes", SubCategoryId = 3 },
                new ProductType() { Id = 6, Name = "Sports Shoes", SubCategoryId = 3 },
                new ProductType() { Id = 7, Name = "Flats", SubCategoryId = 3 },
                new ProductType() { Id = 8, Name = "Heels", SubCategoryId = 3 },
                new ProductType() { Id = 9, Name = "Shorts", SubCategoryId = 2 },
                new ProductType() { Id = 10, Name = "Flip Flops", SubCategoryId = 4 },
                new ProductType() { Id = 11, Name = "Kurtas", SubCategoryId = 1 },
                new ProductType() { Id = 12, Name = "Capris", SubCategoryId = 2 },
                new ProductType() { Id = 13, Name = "Sandals", SubCategoryId = 5 },
                new ProductType() { Id = 14, Name = "Sports Sandals", SubCategoryId = 5 },
                new ProductType() { Id = 15, Name = "Rompers", SubCategoryId = 1 },
                new ProductType() { Id = 16, Name = "Shirts", SubCategoryId = 1 }
            );

            modelBuilder.Entity<Colour>().HasKey(c => c.Id).HasName("pk_colours_id");
            modelBuilder.Entity<Colour>().HasData(
                new Colour() { Id = 1, Name = "Black" },
                new Colour() { Id = 2, Name = "Blue" },
                new Colour() { Id = 3, Name = "Yellow" },
                new Colour() { Id = 4, Name = "White" },
                new Colour() { Id = 5, Name = "Green" },
                new Colour() { Id = 6, Name = "Pink" },
                new Colour() { Id = 7, Name = "Brown" },
                new Colour() { Id = 8, Name = "Red" },
                new Colour() { Id = 9, Name = "Olive" },
                new Colour() { Id = 10, Name = "Beige" },
                new Colour() { Id = 11, Name = "Silver" },
                new Colour() { Id = 12, Name = "Grey" },
                new Colour() { Id = 13, Name = "Peach" },
                new Colour() { Id = 14, Name = "Orange" },
                new Colour() { Id = 15, Name = "Gold" }
            );

            modelBuilder.Entity<Usage>().HasKey(u => u.Id).HasName("pk_usages_id");
            modelBuilder.Entity<Usage>().HasData(
                new Usage() { Id = 1, Name = "Casual" },
                new Usage() { Id = 2, Name = "Formal" },
                new Usage() { Id = 3, Name = "Sports" },
                new Usage() { Id = 4, Name = "Ethnic" }
            );

            modelBuilder.Entity<Product>().HasKey(product => product.Id).HasName("pk_products_id");
            modelBuilder.Entity<Product>().HasOne(product => product.Gender);
            modelBuilder.Entity<Product>().HasOne(product => product.Usage);
            modelBuilder.Entity<Product>().HasOne(product => product.Colour);
            modelBuilder.Entity<Product>().HasOne(product => product.Category);
            modelBuilder.Entity<Product>().HasOne(product => product.SubCategory);
            modelBuilder.Entity<Product>().HasOne(product => product.ProductType);
            modelBuilder.Entity<Product>().HasOne(product => product.Seller).WithMany(seller => seller.Products);
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, SellerId = 1, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 1, UsageId = 1, Title = "Gini and Jony Boys Printed Black T-Shirt", Image = "39855.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/6fa45d21a0d6194932652bfcaf4c0e2b_images.jpg", Price = 20.00, Active = true },
                new Product() { Id = 2, SellerId = 1, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 2, UsageId = 1, Title = "Jungle Book Boys Jungle Friends Blue T-shirt", Image = "35881.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/2ea8c6ea0765fca46041647c5ce1c514_images.jpg", Price = 10.75, Active = true },
                new Product() { Id = 3, SellerId = 1, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 3, UsageId = 1, Title = "Palm Tree Boys Printed Yellow T-Shirt", Image = "39859.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/a3c0711f3d54240e227c7c615d8d46c5_images.jpg", Price = 20.00, Active = true },
                new Product() { Id = 4, SellerId = 1, GenderId = 2, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 2, ColourId = 4, UsageId = 1, Title = "Disney Kids Girl's White Kidswear", Image = "2700.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/d2c388bcd6a795e0d0cea56392d352a6_images.jpg", Price = 49.99, Active = true },
                new Product() { Id = 5, SellerId = 1, GenderId = 2, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 2, ColourId = 5, UsageId = 1, Title = "Doodle Kids Girls Ballon Green Top", Image = "18171.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/f1dbb13abb1efd3ba19bd4108f1a6703_images.jpg", Price = 15.50, Active = true },
                new Product() { Id = 6, SellerId = 1, GenderId = 2, CategoryId = 1, SubCategoryId = 2, ProductTypeId = 3, ColourId = 2, UsageId = 1, Title = "Gini and Jony Girls Washed Blue Skirt", Image = "34148.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/c90319b0bf114581aa3dc692239a0607_images.jpg", Price = 20.00, Active = true },
                new Product() { Id = 7, SellerId = 1, GenderId = 3, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 5, ColourId = 1, UsageId = 1, Title = "F Sports Men Black Shoes", Image = "54529.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/F-Sports-Men-Black-Shoes_f4920f8c2dd4277191a4468e5acf397d_images.jpg", Price = 10.00, Active = true },
                new Product() { Id = 8, SellerId = 1, GenderId = 3, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 5, ColourId = 1, UsageId = 1, Title = "Numero Uno Men Black Casual Shoes", Image = "13072.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/2fc766a7415035d5855a236326c01366_images.jpg", Price = 15.00, Active = true },
                new Product() { Id = 9, SellerId = 1, GenderId = 3, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 5, ColourId = 1, UsageId = 1, Title = "Numero Uno Men Black Casual Shoes", Image = "13080.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/efef30c05460e90a1e170998dde8f92c_images.jpg", Price = 15.00, Active = true },
                new Product() { Id = 10, SellerId = 1, GenderId = 4, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 7, ColourId = 1, UsageId = 1, Title = "HM Women Black Sandals", Image = "56943.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/HM-Women-Black-Sandals_a9da5e1e341b17a3eb061f783c01ca21_images.jpg", Price = 49.99, Active = true },
                new Product() { Id = 11, SellerId = 1, GenderId = 4, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 8, ColourId = 6, UsageId = 1, Title = "Cobblerz Women Pink & White Wedges", Image = "45324.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/31414b116179349f43cf4a558a05de25_images.jpg", Price = 49.99, Active = true },
                new Product() { Id = 12, SellerId = 1, GenderId = 4, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 8, ColourId = 7, UsageId = 1, Title = "Clarks Women Brown Leather Heels", Image = "10292.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/Clarks-Women-Dolphin-Splash-Leather-Silver-Sandals_e55a6fa02cca3f6b6f3fa750619911d4_images.jpg", Price = 55.75, Active = true },
                new Product() { Id = 13, SellerId = 2, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 8, UsageId = 1, Title = "Ben 10 Boys Red Printed T-shirt", Image = "38249.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/91b690cee7977353b5fa29ae56bf22d4_images.jpg", Price = 10.00, Active = true },
                new Product() { Id = 14, SellerId = 2, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 9, UsageId = 1, Title = "Chhota Bheem Kids Boys Spare Me TShirt", Image = "15571.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/ba3659da8365d5f255ab9b992fec690f_images.jpg", Price = 49.99, Active = true },
                new Product() { Id = 15, SellerId = 2, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 5, UsageId = 1, Title = "Gini and Jony Boys Polo Green T-Shirt", Image = "39861.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/f61e63af58565cb07fba8b5d54db3994_images.jpg", Price = 55.75, Active = true },
                new Product() { Id = 16, SellerId = 2, GenderId = 2, CategoryId = 1, SubCategoryId = 2, ProductTypeId = 9, ColourId = 6, UsageId = 1, Title = "Gini and Jony Girls Pink Shorts", Image = "38766.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/9097ddc9c0e1272023976f8e8da00617_images.jpg", Price = 30.85, Active = true },
                new Product() { Id = 17, SellerId = 2, GenderId = 2, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 2, ColourId = 8, UsageId = 1, Title = "Doodle Girls Printed Red Top", Image = "35448.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/bdcb051154afdf6da0a6b1010e116c35_images.jpg", Price = 15.50, Active = true },
                new Product() { Id = 18, SellerId = 2, GenderId = 2, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 2, ColourId = 6, UsageId = 1, Title = "United Colors of Benetton Kids Girls Pink Top", Image = "24941.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/c1a5e415fd0e4f4945aa965729de43c1_images.jpg", Price = 15.00, Active = true },
                new Product() { Id = 19, SellerId = 2, GenderId = 3, CategoryId = 2, SubCategoryId = 4, ProductTypeId = 10, ColourId = 4, UsageId = 1, Title = "Quiksilver Men White Flip Flops", Image = "40785.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/3ac1a2f48ba5767e13a5cb112da62654_images.jpg", Price = 15.50, Active = true },
                new Product() { Id = 20, SellerId = 2, GenderId = 3, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 5, ColourId = 2, UsageId = 1, Title = "ID Men Blue Shoes", Image = "26553.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/a02747a571130ca2d2aa6f491d8b5fc2_images.jpg", Price = 15.00, Active = true },
                new Product() { Id = 21, SellerId = 2, GenderId = 3, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 4, ColourId = 1, UsageId = 2, Title = "Arrow Men Black Formal Shoes", Image = "45603.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/8f3b9f4c5f554e39681567b22985966e_images.jpg", Price = 20.00, Active = true },
                new Product() { Id = 22, SellerId = 2, GenderId = 4, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 8, ColourId = 10, UsageId = 1, Title = "Cobblerz Women Beige & Blue Wedges", Image = "45322.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/04bf5738b8d46cc9a768caf2a35f9451_images.jpg", Price = 15.50, Active = true },
                new Product() { Id = 23, SellerId = 2, GenderId = 4, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 8, ColourId = 11, UsageId = 1, Title = "Catwalk Women Silver Heels", Image = "41669.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/a87cc5ed84c4882d76413571787cad2f_images.jpg", Price = 10.00, Active = true },
                new Product() { Id = 24, SellerId = 2, GenderId = 4, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 6, ColourId = 2, UsageId = 3, Title = "Nike Women Ten Blue White Shoe", Image = "7595.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/b3f3d37c936ee1b487eb6ed3ef399e0b_images.jpg", Price = 30.85, Active = true },
                new Product() { Id = 25, SellerId = 3, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 16, ColourId = 6, UsageId = 1, Title = "Gini and Jony Boys Pink Shirt", Image = "46831.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/943d9b272c042d8b06ee6b1d277de5be_images.jpg", Price = 30.00, Active = true },
                new Product() { Id = 26, SellerId = 3, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 11, ColourId = 2, UsageId = 4, Title = "Fabindia Boys Printed Blue Kurta", Image = "30720.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/e95357480c6acea8e7bcdce602a0a532_images.jpg", Price = 10.00, Active = true },
                new Product() { Id = 27, SellerId = 3, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 5, UsageId = 1, Title = "Gini and Jony Boys United Green T-shirt", Image = "40974.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/c534bd1e6aef81fafe5fddf41bff6401_images.jpg", Price = 15.00, Active = true },
                new Product() { Id = 28, SellerId = 3, GenderId = 2, CategoryId = 1, SubCategoryId = 2, ProductTypeId = 12, ColourId = 6, UsageId = 1, Title = "Gini and Jony Girls Kinky Pink Capris", Image = "42002.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/d07f3c84fe3df82e98b46ba9a55cc866_images.jpg", Price = 15.50, Active = true },
                new Product() { Id = 29, SellerId = 3, GenderId = 2, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 6, UsageId = 1, Title = "Doodle Girl's Princess Cute Little Pink Kidswear", Image = "8359.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/705333ff633393a22cb5c229128afcc2_images.jpg", Price = 30.85, Active = true },
                new Product() { Id = 30, SellerId = 3, GenderId = 2, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 2, ColourId = 4, UsageId = 1, Title = "Palm Tree Girls Knits White Tops", Image = "40972.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/6ad4e27d85073205cafdd1edbd1d86f6_images.jpg", Price = 55.75, Active = true },
                new Product() { Id = 31, SellerId = 3, GenderId = 3, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 6, ColourId = 4, UsageId = 3, Title = "FILA Men Hostile White Sports Shoes", Image = "23500.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/0734fd1f8aea4117ff2f3810a8d7d30b_images.jpg", Price = 49.99, Active = true },
                new Product() { Id = 32, SellerId = 3, GenderId = 3, CategoryId = 2, SubCategoryId = 5, ProductTypeId = 13, ColourId = 12, UsageId = 1, Title = "Lee Cooper Men Grey Sandals", Image = "41455.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/788847bb37bf3ba404eeebcb290c8746_images.jpg", Price = 19.99, Active = true },
                new Product() { Id = 33, SellerId = 3, GenderId = 3, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 5, ColourId = 7, UsageId = 1, Title = "Red Tape Men's Brown casual Shoe", Image = "7364.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/e1f82da932e688fe0f59740369c59b97_images.jpg", Price = 20.00, Active = true },
                new Product() { Id = 34, SellerId = 3, GenderId = 4, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 6, ColourId = 4, UsageId = 3, Title = "ADIDAS Women's Duramo Luxury White Shoe", Image = "5319.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/54a68221353b667c1aa1c17631a6e534_images.jpg", Price = 15.50, Active = true },
                new Product() { Id = 35, SellerId = 3, GenderId = 4, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 8, ColourId = 1, UsageId = 1, Title = "Rocia Women Black Flats", Image = "54118.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/8d6fd53f28e010658cdf5c14c43d0cb0_images.jpg", Price = 10.00, Active = true },
                new Product() { Id = 36, SellerId = 3, GenderId = 4, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 5, ColourId = 8, UsageId = 1, Title = "Catwalk Women Red Shoes", Image = "49608.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/5055777a92b6b46240d58dd31eb46ba8_images.jpg", Price = 30.00, Active = true },
                new Product() { Id = 37, SellerId = 4, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 8, UsageId = 1, Title = "Gini and Jony Boys Comics Red T-shirt", Image = "40956.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/a913999991c21e8233f1d5fd1ab20802_images.jpg", Price = 10.00, Active = true },
                new Product() { Id = 38, SellerId = 4, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 8, UsageId = 1, Title = "The Amazing Spiderman Boys Red T-Shirt", Image = "48250.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/edc6d691eeab51c01264064be592e390_images.jpg", Price = 20.00, Active = true },
                new Product() { Id = 39, SellerId = 4, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 15, ColourId = 2, UsageId = 1, Title = "Madagascar3 Infant Boys Light Blue Snapsuit Romper", Image = "37524.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/1ed5e3016f7bf021add2fd67ac735d80_images.jpg", Price = 24.99, Active = true },
                new Product() { Id = 40, SellerId = 4, GenderId = 2, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 2, ColourId = 8, UsageId = 1, Title = "Doodle Girls Printed Red Top", Image = "35448.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/bdcb051154afdf6da0a6b1010e116c35_images.jpg", Price = 15.50, Active = true },
                new Product() { Id = 41, SellerId = 4, GenderId = 2, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 2, ColourId = 3, UsageId = 1, Title = "Disney Kids Girl's Yellow Daisy Kidswear", Image = "2701.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/9f0369e7d1bb5beabf1071dcd6f15867_images.jpg", Price = 30.85, Active = true },
                new Product() { Id = 42, SellerId = 4, GenderId = 2, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 2, ColourId = 13, UsageId = 1, Title = "Gini and Jony Girls Printed Peach Top", Image = "39835.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/a7e6fca57d133337f6e76e3b5e74fd20_images.jpg", Price = 20.00, Active = true },
                new Product() { Id = 43, SellerId = 4, GenderId = 3, CategoryId = 2, SubCategoryId = 5, ProductTypeId = 13, ColourId = 9, UsageId = 1, Title = "Ganuchi Men Casual Olive Sandals", Image = "11947.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/464879391de4e1a7b881dad3b7bd83a8_images.jpg", Price = 24.99, Active = true },
                new Product() { Id = 44, SellerId = 4, GenderId = 3, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 5, ColourId = 1, UsageId = 1, Title = "Converse Men's AS Canvas HI Black Shoe", Image = "3790.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/2cbba1cd60b44011accb7c099a859ec4_images.jpg", Price = 55.75, Active = true },
                new Product() { Id = 45, SellerId = 4, GenderId = 3, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 5, ColourId = 7, UsageId = 1, Title = "Puma Men Drift Cat Brown Shoes", Image = "33848.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/Puma-Men-Drift-Cat-Brown-Shoes_b37c89652031b205bcd19c36d6c686bd_images.jpg", Price = 20.00, Active = true },
                new Product() { Id = 46, SellerId = 4, GenderId = 4, CategoryId = 2, SubCategoryId = 4, ProductTypeId = 10, ColourId = 14, UsageId = 1, Title = "Lotto Women Coral Elegant Flip Flops", Image = "44725.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/839c627c80dba9ac4412db3f35a52bb7_images.jpg", Price = 30.85, Active = true },
                new Product() { Id = 47, SellerId = 4, GenderId = 4, CategoryId = 2, SubCategoryId = 5, ProductTypeId = 14, ColourId = 1, UsageId = 1, Title = "Rocia Women Casual Black Sandal", Image = "16995.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/2e68ca2646690a4bf4ed092bf44cc6df_images.jpg", Price = 24.99, Active = true },
                new Product() { Id = 48, SellerId = 4, GenderId = 4, CategoryId = 2, SubCategoryId = 3, ProductTypeId = 8, ColourId = 15, UsageId = 1, Title = "Inc 5 Women Casual Gold Flats", Image = "13027.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/9d70af39b13503d1ae27c581dc5e711d_images.jpg", Price = 30.85, Active = true },
                new Product() { Id = 49, SellerId = 1, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 1, UsageId = 1, Title = "Product to test product suppression", Image = "39855.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/6fa45d21a0d6194932652bfcaf4c0e2b_images.jpg", Price = 99.99, Active = true },
                new Product() { Id = 50, SellerId = 1, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 1, UsageId = 1, Title = "Product to test product suppression with appearence in order", Image = "39855.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/6fa45d21a0d6194932652bfcaf4c0e2b_images.jpg", Price = 99.99, Active = true },
                new Product() { Id = 51, SellerId = 1, GenderId = 1, CategoryId = 1, SubCategoryId = 1, ProductTypeId = 1, ColourId = 1, UsageId = 1, Title = "Product to test product suppression with disappearence in cart", Image = "39855.jpg", ImageURL = "http://assets.myntassets.com/v1/images/style/properties/6fa45d21a0d6194932652bfcaf4c0e2b_images.jpg", Price = 99.99, Active = true }
            );

            modelBuilder.Entity<CartItem>().HasKey(item => item.Id).HasName("pk_cartitems_id");
            modelBuilder.Entity<CartItem>().HasOne(item => item.Cart).WithMany(cart => cart.Items);
            modelBuilder.Entity<CartItem>().HasOne(item => item.Product);

            modelBuilder.Entity<Cart>().HasKey(cart => cart.Id).HasName("pk_carts_id");
            modelBuilder.Entity<Cart>().HasOne(cart => cart.Client).WithMany(client => client.Carts);
            modelBuilder.Entity<Cart>().HasMany(cart => cart.Items).WithOne(item => item.Cart);

            modelBuilder.Entity<PaymentMethod>().HasKey(p => p.Id).HasName("pk_paymentmethods_id");
            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod() { Id = 1, Name = "Credits" },
                new PaymentMethod() { Id = 2, Name = "PayPal" }
            );

            modelBuilder.Entity<Order>().HasKey(order => order.Id).HasName("pk_orders_id");
            modelBuilder.Entity<Order>().HasOne(order => order.Cart);
            modelBuilder.Entity<Order>().HasOne(order => order.PaymentMethod);
        }
    }
}
