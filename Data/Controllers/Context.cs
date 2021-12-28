using System.Data.Entity;
using Data.Maps;

namespace Data.Controllers
{
    internal class Context : DbContext
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


        public virtual DbSet<Answer>            Answers            {get; set;}
        public virtual DbSet<AppointmentQuizze> AppointmentQuizzes {get; set;}
        public virtual DbSet<Attempt>           Attempts           {get; set;}
        public virtual DbSet<Feedback>          Feedbacks          {get; set;}
        public virtual DbSet<Group>             Groups             {get; set;}
        public virtual DbSet<GroupsCategory>    GroupsCategories   {get; set;}
        public virtual DbSet<Question>          Questions          {get; set;}
        public virtual DbSet<QuestType>         QuestTypes         {get; set;}
        public virtual DbSet<Quizze>            Quizzes            {get; set;}
        public virtual DbSet<QuizzesCategory>   QuizzesCategories  {get; set;}
        public virtual DbSet<SetTag>            SetTags            {get; set;}
        public virtual DbSet<TeachingGroup>     TeachingGroups     {get; set;}
        public virtual DbSet<User>              Users              {get; set;}
        public virtual DbSet<UserType>          UserTypes          {get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attempt>()
                        .Property(e => e.TransitTime)
                        .HasPrecision(0);

            modelBuilder.Entity<Group>()
                        .Property(e => e.NameOfGroup)
                        .IsFixedLength();

            modelBuilder.Entity<Group>()
                        .HasMany(e => e.GroupsCategories)
                        .WithRequired(e => e.Group)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                        .HasMany(e => e.TeachingGroups)
                        .WithRequired(e => e.Group)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                        .HasMany(e => e.Answers)
                        .WithRequired(e => e.Question)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestType>()
                        .HasMany(e => e.Questions)
                        .WithRequired(e => e.QuestType)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizze>()
                        .Property(e => e.TimeToComplete)
                        .HasPrecision(0);

            modelBuilder.Entity<Quizze>()
                        .HasMany(e => e.AppointmentQuizzes)
                        .WithRequired(e => e.Quizze)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizze>()
                        .HasMany(e => e.Attempts)
                        .WithRequired(e => e.Quizze)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizze>()
                        .HasMany(e => e.Feedbacks)
                        .WithRequired(e => e.Quizze)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizze>()
                        .HasMany(e => e.Questions)
                        .WithRequired(e => e.Quizze)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quizze>()
                        .HasMany(e => e.QuizzesCategories)
                        .WithRequired(e => e.Quizze)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<SetTag>()
                        .HasMany(e => e.GroupsCategories)
                        .WithRequired(e => e.SetTag)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<SetTag>()
                        .HasMany(e => e.QuizzesCategories)
                        .WithRequired(e => e.SetTag)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.AppointmentQuizzes)
                        .WithRequired(e => e.User)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Attempts)
                        .WithRequired(e => e.User)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Feedbacks)
                        .WithRequired(e => e.User)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Quizzes)
                        .WithRequired(e => e.User)
                        .HasForeignKey(e => e.ID_UserCreateons)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.TeachingGroups)
                        .WithRequired(e => e.User)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserType>()
                        .HasMany(e => e.Users)
                        .WithRequired(e => e.UserType)
                        .WillCascadeOnDelete(false);
        }
    }
}