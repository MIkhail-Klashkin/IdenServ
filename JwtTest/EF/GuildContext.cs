using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Isopoh.Cryptography.Argon2;

namespace JwtTest.EF
{
    public class GuildContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Adventurer> Adventurers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public GuildContext(DbContextOptions<GuildContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Персонал гильдии в Афинах
            modelBuilder.Entity<Person>().HasData(new Person() 
            { Id = 1, Login = "admin", PasswordHash = Argon2.Hash("admin"), Role = UserRole.Guildmaster });
            modelBuilder.Entity<Person>().HasData(new Person()
            { Id = 2, Login = "ironholder", PasswordHash = Argon2.Hash("glugnar"), Role = UserRole.Guildmaster });
            modelBuilder.Entity<Person>().HasData(new Person()
            { Id = 3, Login = "Arni", PasswordHash = Argon2.Hash("critsky"), Role = UserRole.Guildmaster });
            modelBuilder.Entity<Person>().HasData(new Person()
            { Id = 4, Login = "borchid", PasswordHash = Argon2.Hash("fataya"), Role = UserRole.Guildmaster });
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Мелос",
                LastName = "Фальборн",
                Race = Race.Human,
                Sex = Sex.Male,
                Age = 50,
                Country = "Портау",
                City = "Афины",
                Person = People.Where(m => m.Id == 1).First()
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 2,
                FirstName = "Глугнар",
                LastName = "Железоносный",
                Race = Race.Dwarf,
                Sex = Sex.Male,
                Age = 204,
                Country = "Портау",
                City = "Афины",
                Person = People.Where(m => m.Id == 2).First()
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 3,
                FirstName = "Арни",
                LastName = "Критский",
                Race = Race.Half_elf,
                Sex = Sex.Male,
                Age = 90,
                Country = "Портау",
                City = "Афины",
                Person = People.Where(m => m.Id == 3).First()
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 4,
                FirstName = "Фетэйя",
                LastName = "Луйтис",
                Race = Race.Human,
                Sex = Sex.Female,
                Age = 33,
                Country = "Портау",
                City = "Афины",
                Person = People.Where(m => m.Id == 4).First()
            });
            #endregion
            #region Афинская гильдия (Для оформления квестов гильдии)
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.Person.Id == 1).First()
            });
            #endregion
            #region Кураторы с инициализацией
            modelBuilder.Entity<Adventurer>().HasData(new Adventurer()
            {
                AdventurerName = "Железоносный",
                AdventurerRank = AdventureRank.Golden,
                User = Users.Where(a => a.Id == 2).First(),
                IsMentor = true,
            });
            modelBuilder.Entity<Adventurer>().HasData(new Adventurer()
            {
                AdventurerName = "Арни",
                AdventurerRank = AdventureRank.Golden,
                User = Users.Where(a => a.Id == 3).First(),
                IsMentor = true
            });
            modelBuilder.Entity<Adventurer>().HasData(new Adventurer()
            {
                AdventurerName = "Чёрная Орхидея",
                AdventurerRank = AdventureRank.Golden,
                User = Users.Where(a => a.Id == 4).First(),
                IsMentor = true
            });
            #endregion
            #region Клиенты гильдии (без учётной записи)
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Айкор",
                LastName = "Из Левадии",
                Race = Race.Human,
                Sex = Sex.Male,
                Age = 29,
                Country = "Портау",
                City = "Левадия"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Берг",
                LastName = "",
                Race = Race.Dwarf,
                Sex = Sex.Male,
                Age = 127,
                Country = "Портау",
                City = "Один"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Девиан",
                LastName = "Афинский",
                Race = Race.Human,
                Sex = Sex.Male,
                Age = 44,
                Country = "Портау",
                City = "Афины"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Джафар",
                LastName = "Халем",
                Race = Race.Planetouched,
                Sex = Sex.Male,
                Age = 92,
                Country = "Портау",
                City = "Афины"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Ликфан",
                LastName = "Из Фивы",
                Race = Race.Human,
                Sex = Sex.Male,
                Age = 50,
                Country = "Портау",
                City = "Фивы"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Малант",
                LastName = "Из Патра",
                Race = Race.Half_elf,
                Sex = Sex.Male,
                Age = 21,
                Country = "Портау",
                City = "Патра"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Хемир",
                LastName = "",
                Race = Race.Half_elf,
                Sex = Sex.Male,
                Age = 59,
                Country = "Портау",
                City = "Кореллон"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Горт",
                LastName = "",
                Race = Race.Half_orc,
                Sex = Sex.Male,
                Age = 30,
                Country = "Портау",
                City = "Груумш"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Фелисия",
                LastName = "Эйлис",
                Race = Race.Human,
                Sex = Sex.Female,
                Age = 22,
                Country = "Портау",
                City = "Афины"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Дуглан",
                LastName = "Галацийский",
                Race = Race.Human,
                Sex = Sex.Male,
                Age = 37,
                Country = "Портау",
                City = "Афины"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Мелд",
                LastName = "Пакиос",
                Race = Race.Human,
                Sex = Sex.Male,
                Age = 60,
                Country = "Портау",
                City = "Афины"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Меланра",
                LastName = "Финия",
                Race = Race.Human,
                Sex = Sex.Female,
                Age = 20,
                Country = "Портау",
                City = "Афины"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Ласей",
                LastName = "Семецвет",
                Race = Race.Halfing,
                Sex = Sex.Male,
                Age = 19,
                Country = "Портау",
                City = "Афины"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Силия",
                LastName = "Бора",
                Race = Race.Human,
                Sex = Sex.Male,
                Age = 40,
                Country = "Портау",
                City = "Афины"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Фелин",
                LastName = "Вейтис",
                Race = Race.Human,
                Sex = Sex.Male,
                Age = 29,
                Country = "Портау",
                City = "Афины"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Гиран",
                LastName = "Фаросский",
                Race = Race.Human,
                Sex = Sex.Male,
                Age = 45,
                Country = "Портау",
                City = "Афины"
            });

            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Айкор" &&
                                        u.LastName == "Из Левадии" &&
                                        u.City == "Левадия").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Берг" &&
                                        u.LastName == "" &&
                                        u.City == "Один").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Джафар" &&
                                        u.LastName == "Халем" &&
                                        u.City == "Афины").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Девиан" &&
                                        u.LastName == "Афинский" &&
                                        u.City == "Афины").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Ликфан" &&
                                        u.LastName == "Из Фивы" &&
                                        u.City == "Фивы").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Малант" &&
                                        u.LastName == "Из Патра" &&
                                        u.City == "Патра").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Хемир" &&
                                        u.LastName == "" &&
                                        u.City == "Кореллон").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Горт" &&
                                        u.LastName == "" &&
                                        u.City == "Груумш").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Фелисия" &&
                                        u.LastName == "Эйлис" &&
                                        u.City == "Афины").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Дуглан" &&
                                        u.LastName == "Галацийский" &&
                                        u.City == "Афины").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Мелд" &&
                                        u.LastName == "Пакиос" &&
                                        u.City == "Афины").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Меланра" &&
                                        u.LastName == "Финия" &&
                                        u.City == "Афины").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Ласей" &&
                                        u.LastName == "Семецвет" &&
                                        u.City == "Афины").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Силия" &&
                                        u.LastName == "Бора" &&
                                        u.City == "Афины").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Гиран" &&
                                        u.LastName == "Фаросский" &&
                                        u.City == "Афины").First()
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                User = Users.Where(u => u.FirstName == "Фелин" &&
                                        u.LastName == "Вейтис" &&
                                        u.City == "Афины").First()
            });
            #endregion
            #region Путешественники (без учётной записи)                
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Ауст",
                LastName = "Лиадон",
                Race = Race.Half_elf,
                Sex = Sex.Male,
                Age = 62,
                Country = "Портау",
                City = "Афины",
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Дамая",
                LastName = "",
                Race = Race.Planetouched,
                Sex = Sex.Female,
                Age = 24,
                Country = "Портау",
                City = "Афины",
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Амнон",
                LastName = "Арафат",
                Race = Race.Planetouched,
                Sex = Sex.Male,
                Age = 27,
                Country = "Портау",
                City = "Афины",
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Таннан",
                LastName = "",
                Race = Race.Gnome,
                Sex = Sex.Male,
                Age = 230,
                Country = "Портау",
                City = "Афины",
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Яндер",
                LastName = "Легкогор",
                Race = Race.Halfing,
                Sex = Sex.Male,
                Age = 33,
                Country = "Портау",
                City = "Афины",
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = "Винсент",
                LastName = "Гюнтлет",
                Race = Race.Half_elf,
                Sex = Sex.Male,
                Age = 18,
                Country = "Портау",
                City = "Афины",
            });
            modelBuilder.Entity<Adventurer>().HasData(new Adventurer()
            {
                AdventurerName = "Ауст",
                AdventurerRank = AdventureRank.Copper,
                User = Users.Where(u => u.FirstName == "Ауст" &&
                                        u.LastName == "Лиадон" &&
                                        u.City == "Афины").First(),
                IsMentor = false
            });
            modelBuilder.Entity<Adventurer>().HasData(new Adventurer()
            {
                AdventurerName = "Случай",
                AdventurerRank = AdventureRank.Copper,
                User = Users.Where(u => u.FirstName == "Дамая" &&
                                        u.LastName == "" &&
                                        u.City == "Афины").First(),
                IsMentor = false
            });
            modelBuilder.Entity<Adventurer>().HasData(new Adventurer()
            {
                AdventurerName = "Преданный",
                AdventurerRank = AdventureRank.Copper,
                User = Users.Where(u => u.FirstName == "Амнон" &&
                                        u.LastName == "Арафат" &&
                                        u.City == "Афины").First(),
                IsMentor = false
            });
            modelBuilder.Entity<Adventurer>().HasData(new Adventurer()
            {
                AdventurerName = "Таннан",
                AdventurerRank = AdventureRank.Copper,
                User = Users.Where(u => u.FirstName == "Таннан" &&
                                        u.LastName == "" &&
                                        u.City == "Афины").First(),
                IsMentor = false
            });
            modelBuilder.Entity<Adventurer>().HasData(new Adventurer()
            {
                AdventurerName = "Фелин",
                AdventurerRank = AdventureRank.Copper,
                User = Users.Where(u => u.FirstName == "Фелин" &&
                                        u.LastName == "Вейтис" &&
                                        u.City == "Афины").First(),
                IsMentor = false
            });
            modelBuilder.Entity<Adventurer>().HasData(new Adventurer()
            {
                AdventurerName = "Яндер Легкогор",
                AdventurerRank = AdventureRank.Copper,
                User = Users.Where(u => u.FirstName == "Яндер" &&
                                        u.LastName == "Легкогор" &&
                                       u.City == "Афины").First(),
                IsMentor = false
            });
            modelBuilder.Entity<Adventurer>().HasData(new Adventurer()
            {
                AdventurerName = "Сир Гюнтлет",
                AdventurerRank = AdventureRank.Copper,
                User = Users.Where(u => u.FirstName == "Винсент" &&
                                        u.LastName == "Гюнтлет" &&
                                        u.City == "Афины").First(),
                IsMentor = false
            });
            #endregion
            #region Квесты
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = true,
                QuestRank = AdventureRank.Copper,
                QuestType = QuestType.Search,
                Client = Clients.Where(c => c.User.FirstName == "Фелин" &&
                                            c.User.LastName == "Вейтис" &&
                                            c.User.City == "Афины").First(),
                Details = "Фелин Вейтис просит найти для него алхимический ингредиент под названием \"дыхание василиска\", также известное в жреческих кругах как \"Серое воздержание\". Для выполнения поручения достаточно двух-трёх порций данного ингредиента, за каждую порцию сверху гильдия обещает доплатить 70 зм.",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = true,
                QuestRank = AdventureRank.Copper,
                QuestType = QuestType.Rescue,
                Client = Clients.Where(c => c.User.FirstName == "Дуглан" &&
                                            c.User.LastName == "Галацийский" &&
                                            c.User.City == "Афины").First(),
                Details = "Кузнец Дуглан просит найти своего кузена Фина, который пропал по дороге на лесопилку вместе с повозкой.",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = true,
                QuestRank = AdventureRank.Copper,
                QuestType = QuestType.Search,
                Client = Clients.Where(c => c.User.FirstName == "Девиан" &&
                                            c.User.LastName == "Афинский" &&
                                            c.User.City == "Афины").First(),
                Details = "Мужчина по имени Девиан просит найти своего пса по кличке Милорд, который потерялся во время прогулки в портовом районе города Афины.",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = true,
                QuestRank = AdventureRank.Copper,
                QuestType = QuestType.Extermination,
                Client = Clients.Where(c => c.User.FirstName == "Ликфан" &&
                                            c.User.LastName == "Из Фивы" &&
                                            c.User.City == "Фивы").First(),
                Details = "Староста деревни Фивы просит о помощи с голодными бродячими псами, что наводнили улицы деревни. За каждый хвост пса он обещает 20 золотых.",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = true,
                QuestRank = AdventureRank.Silver,
                QuestType = QuestType.Extermination,
                Client = Clients.Where(c => c.User.FirstName == "Ликфан" &&
                                            c.User.LastName == "Из Фивы" &&
                                            c.User.City == "Фивы").First(),
                Details = "Староста деревни Фивы просит помочь егерю Фергену зачистить пещеру к северу от деревни.",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = true,
                QuestRank = AdventureRank.Silver,
                QuestType = QuestType.Assassination,
                Client = Clients.Where(c => c.User.FirstName == "Гиран" &&
                                            c.User.LastName == "Фаросский" &&
                                            c.User.City == "Афины").First(),
                Details = "Следователь \"Синих Виверн\" Гиран просит авантюристов найти и устранить главаря шайки разбойников, что расположилась где-то у подножья горы Дирфис. Он обещает 400 золотых в награду за его голову.",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = true,
                QuestRank = AdventureRank.Copper,
                QuestType = QuestType.Search,
                Client = Clients.Where(c => c.User.FirstName == "Фелисия" &&
                                            c.User.LastName == "Эйлис" &&
                                            c.User.City == "Афины").First(),
                Details = "Девушка по имени Фелисия просит о помощи в поиске украденного ожерелья. она обещает 75 золотых в награду за поимку преступника или за само ожерелье. Найти её можно к северу от Храмовой площади, она живёт в двухэтажном доме в паре кварталов от храма Диониса.",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = false,
                QuestRank = AdventureRank.Copper,
                QuestType = QuestType.Search,
                Client = Clients.Where(c => c.User.FirstName == "Горт" &&
                                            c.User.LastName == "" &&
                                            c.User.City == "Груумш").First(),
                Details = "Фермер по имени Флафий ищет частного детектива для помощи в поиске пропавших овец. В награду обещает 30 золотых",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = false,
                QuestRank = AdventureRank.Copper,
                QuestType = QuestType.Assassination,
                Client = Clients.Where(c => c.User.FirstName == "Хемир" &&
                                            c.User.LastName == "" &&
                                            c.User.City == "Кореллон").First(),
                Details = "Купец по имени Хемир просит о помощи в поимке подозрительного типа, что покушается на его товар. В награду обещает 100 золотых",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = true,
                QuestRank = AdventureRank.Copper,
                QuestType = QuestType.Rescue,
                Client = Clients.Where(c => c.User.FirstName == "Малант" &&
                                            c.User.LastName == "Из Патра" &&
                                            c.User.City == "Патра").First(),
                Details = "Фермер по имени Малант просит найти целительницу, внезапно пропавшую ночью в четверг.",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = true,
                IsPublic = true,
                QuestRank = AdventureRank.Silver,
                QuestType = QuestType.Search,
                Client = Clients.Where(c => c.User.FirstName == "Мелос" &&
                                            c.User.LastName == "Фальборн" &&
                                            c.User.City == "Афины").First(),
                Details = "Гильдия города Афины просит всех путешественников о помощи в поиске жетонов авантюристов, пропавших без вести во время \"Битвы за Эдесу\". В награду за каждый жетон гильдия обещает 100 золотых вместо 50, как обычно.",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });
            modelBuilder.Entity<Quest>().HasData(new Quest()
            {
                IsLegal = true,
                IsRepeatable = false,
                IsPublic = true,
                QuestRank = AdventureRank.Silver,
                QuestType = QuestType.Assassination,
                Client = Clients.Where(c => c.User.FirstName == "Мелос" &&
                                            c.User.LastName == "Фальборн" &&
                                            c.User.City == "Афины").First(),
                Details = "Cрочное поручение от гильдии. Требуется найти и привести колдуна-смутьяна, известного как \"Схин\". Особые приметы: Тифлинг, краснокожий, длинные острые уши, толстые изогнутые вперёд рога, хвоста нет, одет в тряпьё. В последний раз он был замечен возле города Левадия, двигается на север. Награда 500 золотых.",
                Adventurers = new List<Adventurer>(),
                Status = Status.Active
            });

            #endregion
        }
    }
}
