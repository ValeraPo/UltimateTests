using System.Data.Entity;
using System.Data.Entity.Infrastructure.Design;
using Data.Maps;

namespace Data
{
    public class Context : DbContext
    {
        #region Singleton

        private Context()
            : base("name=Connect") { }
        private static Context _context;
        public static Context GetContext()
        {
            return _context ??= new Context();
        }

        #endregion


        public virtual DbSet<Answers>            Answers            {get; set;}
        public virtual DbSet<AppointmentQuizzes> AppointmentQuizzes {get; set;}
        public virtual DbSet<Attempts>           Attempts           {get; set;}
        public virtual DbSet<Feedbacks>          Feedbacks          {get; set;}
        public virtual DbSet<Groups>             Groups             {get; set;}
        public virtual DbSet<GroupsCategories>   GroupsCategories   {get; set;}
        public virtual DbSet<Questions>          Questions          {get; set;}
        public virtual DbSet<Quizzes>            Quizzes            {get; set;}
        public virtual DbSet<QuizzesCategories>  QuizzesCategories  {get; set;}
        public virtual DbSet<SetTags>            SetTags            {get; set;}
        public virtual DbSet<TeachingGroups>     TeachingGroups     {get; set;}
        public virtual DbSet<Users>              Users              {get; set;}
        public virtual DbSet<UserTypes>          UserTypes          {get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attempts>()
                        .Property(e => e.TransitTime)
                        .HasPrecision(0);

            modelBuilder.Entity<Groups>()
                        .Property(e => e.NameOfGroup)
                        .IsFixedLength();

            modelBuilder.Entity<Groups>()
                        .HasMany(e => e.GroupsCategories)
                        .WithRequired(e => e.Groups)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groups>()
                        .HasMany(e => e.TeachingGroups)
                        .WithRequired(e => e.Groups)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questions>()
                        .HasMany(e => e.Answers)
                        .WithRequired(e => e.Questions)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizzes>()
                        .Property(e => e.TimeToComplete)
                        .HasPrecision(0);

            modelBuilder.Entity<Quizzes>()
                        .HasMany(e => e.AppointmentQuizzes)
                        .WithRequired(e => e.Quizzes)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizzes>()
                        .HasMany(e => e.Attempts)
                        .WithRequired(e => e.Quizzes)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizzes>()
                        .HasMany(e => e.Feedbacks)
                        .WithRequired(e => e.Quizzes)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizzes>()
                        .HasMany(e => e.Questions)
                        .WithRequired(e => e.Quizzes)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizzes>()
                        .HasMany(e => e.QuizzesCategories)
                        .WithRequired(e => e.Quizzes)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<SetTags>()
                        .HasMany(e => e.GroupsCategories)
                        .WithRequired(e => e.SetTags)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<SetTags>()
                        .HasMany(e => e.QuizzesCategories)
                        .WithRequired(e => e.SetTags)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                        .HasMany(e => e.AppointmentQuizzes)
                        .WithRequired(e => e.Users)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                        .HasMany(e => e.Attempts)
                        .WithRequired(e => e.Users)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                        .HasMany(e => e.Feedbacks)
                        .WithRequired(e => e.Users)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                        .HasMany(e => e.Quizzes)
                        .WithRequired(e => e.Users)
                        .HasForeignKey(e => e.ID_UserCreateons)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                        .HasMany(e => e.TeachingGroups)
                        .WithRequired(e => e.Users)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserTypes>()
                        .HasMany(e => e.Users)
                        .WithRequired(e => e.UserTypes)
                        .WillCascadeOnDelete(false);
        }
    }
}