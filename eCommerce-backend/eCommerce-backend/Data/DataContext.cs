using eCommerce_backend.Models;

namespace eCommerce_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorsMovies>()
                .HasKey(am => new { am.ActorId, am.MovieId });

            modelBuilder.Entity<ActorsMovies>()
                .HasOne(am => am.Movie)
                .WithMany(a => a.Actors)
                .HasForeignKey(am => am.MovieId);

            modelBuilder.Entity<ActorsMovies>()
                .HasOne(am => am.Actor)
                .WithMany(m => m.Movies)
                .HasForeignKey(am => am.ActorId);
            
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Cinema)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CinemaId);

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Producer)
                .WithMany(p => p.Movies)
                .HasForeignKey(m => m.ProducerId);

            modelBuilder.Entity<MovieComment>()
                .HasOne(c => c.Movie)
                .WithMany(m => m.Comments)
                .HasForeignKey(c => c.MovieId);

            modelBuilder.Entity<MovieComment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserMovies>()
                .HasKey(um => new { um.UserId, um.MovieId });

            modelBuilder.Entity<UserMovies>()
                .HasOne(um => um.Movie)
                .WithMany(m => m.Users)
                .HasForeignKey(um => um.MovieId);

            modelBuilder.Entity<UserMovies>()
                .HasOne(um => um.User)
                .WithMany(u => u.Movies)
                .HasForeignKey(um => um.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(ci => ci.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Movie)
                .WithMany(m => m.Cart)
                .HasForeignKey(ci => ci.MovieId);

            modelBuilder.Entity<MoviePurchase>()
                .HasOne(mp => mp.Movie)
                .WithMany(m => m.Purchases)
                .HasForeignKey(mp => mp.MovieId);

            modelBuilder.Entity<MoviePurchase>()
                .HasOne(mp => mp.Purchases)
                .WithMany(p => p.Movies)
                .HasForeignKey(mp => mp.PurchaseId);
            
            modelBuilder.Entity<Purchases>()
                .HasOne(p => p.User)
                .WithMany(u => u.PurchaseList)
                .HasForeignKey(p => p.UserId);
            
            modelBuilder.Entity<UserFavoriteMovies>()
                .HasOne(um => um.User)
                .WithMany(u => u.FavoriteMoviesList)
                .HasForeignKey(um => um.UserId);
            
            modelBuilder.Entity<UserFavoriteMovies>()
                .HasOne(um => um.Movie)
                .WithMany(m => m.UserFavoriteMoviesList)
                .HasForeignKey(um => um.MovieId);
        }
        
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<MoviePurchase> MoviesPurchases { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieComment> MovieComments { get; set; }
        public DbSet<CinemaComment> CinemaComments { get; set; }
        public DbSet<UserMovies> UserMovies { get; set; }
        public DbSet<ActorsMovies> ActorsMovies { get; set;}
        public DbSet<UserFavoriteMovies> UserFavoriteMovies { get; set; }
    }
}
