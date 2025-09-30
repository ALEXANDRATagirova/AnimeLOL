using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesLogic;
using Model;

namespace BusinessLogic
{
    public class Logic
    {
       
        List<Anime> animeList = new List<Anime>();
        private int nextId = 1;

        /// <summary>
        /// добавляет аниме
        /// </summary>
        /// <param name="title">название</param>
        /// <param name="genre">жанр</param>
        /// <param name="rating">рейтинг</param>
        public void AddAnime(string title, string genre, double rating, bool iswatching)
        {
            Anime anime = new Anime()
            {
                Id = nextId++,
                Title = title,
                Genre = genre,
                Rating = rating,
                IsWatched = iswatching
            };
            animeList.Add(anime);
              
        }

        // Перегрузка для сохранения совместимости со старым интерфейсом вызова
        public void AddAnime(string title, string genre, double rating)
        {
            AddAnime(title, genre, rating, false);
        }

        /// <summary>
        /// Удаляет аниме из коллекции по указанному идентификатору
        /// </summary>
        /// <param name="id">Указанный идентификатор</param>
        /// <returns>true - если аниме было успешно удалено, false - если аниме с указанным ID не найдено</returns>
        public bool DeleteAnime(int id)
        {
            Anime animeToRemove = GetAnimeById(id);  //

            if (animeToRemove != null)
            {
                animeList.Remove(animeToRemove);
                return true;
            }
            return false;
        }

        /// <summary>
        /// поиск аниме по id
        /// </summary>
        /// <param name="id">Идентификатор аниме для поиска</param>
        /// <returns>Найденный объект аниме или null, если аниме с указанным ID не существует</returns>
        public Anime GetAnimeById(int id)
        {
            return animeList.FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// показывает все аниме
        /// </summary>
        /// <returns>Выводит весь список с аниме</returns>
        public List<Anime> GetAllAnime()
        {
            return new List<Anime>(animeList);
        }
        /// <summary>
        /// Обновляет информацию об аниме по указанному идентификатору
        /// </summary>
        /// <param name="id">Идентификатор аниме для изменения</param>
        /// <param name="newTitle">Новое название аниме</param>
        /// <param name="newGenre">Новый жанр аниме</param>
        /// <param name="newRating">Новый рейтинг аниме</param>
        /// <returns>true - если аниме было успешно обновлено, false - если аниме с указанным ID не найдено</returns>
        public bool ChangeInfo(int id, string oldTitle, string oldGenre, double oldRating, bool oldIsWatched,
                      string newTitle, string newGenre, double newRating, bool newIsWatched)
        {
            var anime = GetAnimeById(id);
            if (anime != null)
            {
                anime.Title = newTitle;
                anime.Genre = newGenre;
                anime.Rating = newRating;
                anime.IsWatched = newIsWatched;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Группирует все аниме по жанрам
        /// </summary>
        /// <returns>Словарь где ключ - название жанра, значение - список аниме этого жанра</returns>
        public Dictionary<string, List<Anime>> GroupByGenre()
        {
            return animeList.GroupBy(a => a.Genre).ToDictionary(g => g.Key, g => g.ToList());
        }
        /// <summary>
        /// Отсортировывает аниме список по рейтингу
        /// </summary>
        /// <param name="ascending">Направление сортировки</param>
        /// <returns>Отсортированный список аниме</returns>
        public List<Anime> GetAnimeSortedByRating(bool ascending = true)
        {
            if (ascending)
                return animeList.OrderBy(a => a.Rating).ToList();
            else
                return animeList.OrderByDescending(a => a.Rating).ToList();
        }

        /// <summary>
        /// Отсортировывает по жанру и рейтингу список с аниме
        /// </summary>
        /// <param name="genre">Жанр для фильтрации</param>
        /// <param name="ascending">Направление сортировки</param>
        /// <returns>Отсортированный список по жанру и рейтингу</returns>
        public List<Anime> GetAnimeSortedByRatingWithGenre(string genre, bool ascending = true)
        {
            var filtered = animeList.Where(a => string.Equals(a.Genre, genre, StringComparison.OrdinalIgnoreCase));
            if (ascending)
            {
                return filtered.OrderBy(a => a.Rating).ToList();
            }
            else
            {
                return filtered.OrderByDescending(a => a.Rating).ToList();
            }
        }

        /// <summary>
        /// Возвращает список всех уникальных жанров из коллекции аниме
        /// </summary>
        /// <returns>Уникальный список жанров, отсортированный по алфавиту</returns>
        public List<string> GetAllGenres()
        {
            return animeList.Select(a => a.Genre).Distinct().ToList();
        }
        /// <summary>
        /// Отмечает аниме как просмотренное или непросмотренное
        /// </summary>
        /// <param name="id">ID аниме которое нужно отметить</param>
        /// <param name="watched">True - просмотрено, False - не просмотрено</param>
        public void MarkAsWatched(int id, bool watched)
        {
            var anime = GetAnimeById(id);
            if (anime != null)
            {
                anime.IsWatched = watched;
            }
        }
        /// <summary>
        /// Группирует аниме по статусу просмотра и сортирует по рейтингу
        /// </summary>
        /// <returns>Словарь где ключ - статус просмотра, значение - список аниме отсортированных по рейтингу</returns>
        public Dictionary<bool, List<Anime>> GroupByWatchedStatus()
        {
            return animeList
                .GroupBy(a => a.IsWatched)
                .OrderBy(g => g.Key) // false (не просмотрено) будет первым
                .ToDictionary(g => g.Key, g => g.OrderByDescending(a => a.Rating).ToList());
        }
        
        public class SubscriptionService
        {
            private List<SubscriptionPlan> _availablePlans;
            private List<UserSubscription> _userSubscriptions;
            /// <summary>
            /// Создает новую подписку для пользователя
            /// </summary>
            public SubscriptionService()
            {
                _userSubscriptions = new List<UserSubscription>();
                _availablePlans = new List<SubscriptionPlan>();
                InitializeDefaultPlans();
            }
            /// <summary>
            /// Получает текущую подписку пользователя
            /// </summary>
            private void InitializeDefaultPlans()
            {
                _availablePlans = new List<SubscriptionPlan>
                {
                    new SubscriptionPlan
                    {
                        Id = 1,
                        Name = "Базовый",
                        Description = "Доступ к базовому контенту",
                        Price = 0,
                        DurationDays = 0,
                        Features = new List<string> { "720p качество", "Реклама", "Ограниченный каталог" }
                    },
                    new SubscriptionPlan
                    {
                        Id = 2,
                        Name = "Премиум",
                        Description = "Расширенный доступ без рекламы",
                        Price = 299,
                        DurationDays = 30,
                        Features = new List<string> { "1080p качество", "Без рекламы", "Полный каталог", "Оффлайн просмотр" }
                    },
                    new SubscriptionPlan
                    {
                        Id = 3,
                        Name = "Ультра",
                        Description = "Полный доступ ко всем функциям",
                        Price = 599,
                        DurationDays = 30,
                        Features = new List<string> { "4K качество", "Ранний доступ к сериям", "Эксклюзивный контент", "Приоритетная поддержка" }
                    }
                };
            }
            /// <summary>
            /// Оформляет подписку пользователя на выбранный тариф
            /// </summary>
            /// <param name="userId">ID пользователя</param>
            /// <param name="planId">ID тарифного плана</param>
            /// <returns>True если подписка оформлена успешно, false если произошла ошибка</returns>
            public bool SubscribeUser(int userId, int planId)
            {
                try
                {
                    var plan = _availablePlans.FirstOrDefault(p => p.Id == planId);
                    if (plan == null)
                    {
                        Console.WriteLine($"Тарифный план с ID {planId} не найден.");
                        return false;
                    }
                    var oldSubscriptions = _userSubscriptions.Where(s => s.UserId == userId).ToList();
                    foreach (var sub in oldSubscriptions)
                    {
                        sub.IsActive = false;
                    }

                    // Создаем новую подписку
                    var newSubscription = new UserSubscription
                    {
                        UserId = userId,
                        PlanId = planId,
                        StartDate = DateTime.Now,
                        EndDate = plan.DurationDays > 0 ? DateTime.Now.AddDays(plan.DurationDays) : DateTime.MaxValue,
                        IsActive = true
                    };

                    _userSubscriptions.Add(newSubscription);

                    Console.WriteLine($"✅ Пользователь {userId} успешно подписан на тариф '{plan.Name}'");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Ошибка при оформлении подписки: {ex.Message}");
                    return false;
                }
            }
            /// <summary>
            /// Получает активную подписку пользователя
            /// </summary>
            /// <param name="userId">ID пользователя</param>
            /// <returns>Объект подписки или null если подписка не найдена</returns>
            public UserSubscription GetUserSubscription(int userId)
            {
                return _userSubscriptions
                    .FirstOrDefault(s => s.UserId == userId && s.IsValid);
            }
            /// <summary>
            /// Возвращает список всех доступных тарифных планов
            /// </summary>
            /// <returns>Список тарифных планов</returns>
            public List<SubscriptionPlan> GetAvailablePlans()
            {
                return _availablePlans;
            }
            /// <summary>
            /// Отменяет текущую подписку пользователя
            /// </summary>
            /// <param name="userId">ID пользователя</param>
            /// <returns>True если подписка отменена, false если подписка не найдена</returns>
            public bool CancelSubscription(int userId)
            {
                var subscription = GetUserSubscription(userId);
                if (subscription != null)
                {
                    subscription.IsActive = false;
                    Console.WriteLine($"✅ Подписка пользователя {userId} отменена");
                    return true;
                }

                Console.WriteLine($"❌ У пользователя {userId} нет активной подписки для отмены");
                return false;
            }

            /// <summary>
            /// Получает все подписки всех пользователей
            /// </summary>
            /// <returns>Список всех подписок в системе</returns>
            public List<UserSubscription> GetAllSubscriptions()
            {
                return _userSubscriptions;
            }

            /// <summary>
            /// Находит тарифный план по его идентификатору
            /// </summary>
            /// <param name="planId">ID тарифного плана</param>
            /// <returns>Объект тарифного плана или null если не найден</returns>
            public SubscriptionPlan GetPlanById(int planId)
            {
                return _availablePlans.FirstOrDefault(p => p.Id == planId);
            }
        }
    }
    
}
