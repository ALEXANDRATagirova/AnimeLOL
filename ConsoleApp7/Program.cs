using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Model;
using static BusinessLogic.Logic;

namespace ConsoleApp7
{
    internal class Program
    {
        static Logic logic = new Logic();
        static SubscriptionService subscriptionService = new SubscriptionService();
        static int currentUserId = 1; // Текущий пользователь

        static void Main(string[] args)
        {
            AddSampleData();

            bool running = true;
            while (running)
            {
                Console.Clear();
                ShowMainMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddAnimeMenu(); break;
                    case "2": DeleteAnimeMenu(); break;
                    case "3": ShowAllAnimeMenu(); break;
                    case "4": FindAnimeByIdMenu(); break;
                    case "5": UpdateAnimeMenu(); break;
                    case "6": GroupByGenreMenu(); break;
                    case "7": SortByRatingMenu(); break;
                    case "8": SortByGenreAndRatingMenu(); break;
                    case "9": SubscriptionMenu(); break; // Новый пункт меню для подписки
                    case "0": running = false; break;
                    default: ShowError("Неверный выбор!"); break;
                }

                if (running && choice != "3")
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Программа завершена. До свидания!");
        }

        /// <summary>
        /// показывает основное меню
        /// </summary>
        static void ShowMainMenu()
        {
            Console.WriteLine("=== МЕНЕДЖЕР АНИМЕ ===");
            Console.WriteLine("1. Добавить аниме");
            Console.WriteLine("2. Удалить аниме");
            Console.WriteLine("3. Показать все аниме");
            Console.WriteLine("4. Найти аниме по ID");
            Console.WriteLine("5. Изменить информацию об аниме");
            Console.WriteLine("6. Группировка по жанрам");
            Console.WriteLine("7. Сортировка по рейтингу");
            Console.WriteLine("8. Сортировка по жанру и рейтингу");
            Console.WriteLine("9. Управление подпиской"); // Новый пункт
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");
        }

        /// <summary>
        /// Меню управления подпиской
        /// </summary>
        static void SubscriptionMenu()
        {
            bool inSubscriptionMenu = true;
            while (inSubscriptionMenu)
            {
                Console.Clear();
                Console.WriteLine("=== УПРАВЛЕНИЕ ПОДПИСКОЙ ===");
                Console.WriteLine("1. Просмотреть доступные тарифы");
                Console.WriteLine("2. Оформить подписку");
                Console.WriteLine("3. Проверить текущую подписку");
                Console.WriteLine("4. Отменить подписку");
                Console.WriteLine("5. Показать все подписки (отладка)");
                Console.WriteLine("6. Назад в главное меню");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": DisplayAvailablePlans(); break;
                    case "2": SubscribeToPlan(); break;
                    case "3": CheckCurrentSubscription(); break;
                    case "4": CancelCurrentSubscription(); break;
                    case "5": DisplayAllSubscriptions(); break;
                    case "6": inSubscriptionMenu = false; break;
                    default: ShowError("Неверный выбор!"); break;
                }

                if (inSubscriptionMenu && choice != "1")
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Показать доступные тарифные планы
        /// </summary>
        static void DisplayAvailablePlans()
        {
            Console.WriteLine("\n--- ДОСТУПНЫЕ ТАРИФЫ ---");
            var plans = subscriptionService.GetAvailablePlans();

            foreach (var plan in plans)
            {
                Console.WriteLine($"\nID: {plan.Id}");
                Console.WriteLine($"Название: {plan.Name}");
                Console.WriteLine($"Описание: {plan.Description}");
                Console.WriteLine($"Цена: {(plan.Price == 0 ? "Бесплатно" : $"{plan.Price} руб./мес")}");
                Console.WriteLine($"Длительность: {(plan.DurationDays == 0 ? "Бессрочно" : $"{plan.DurationDays} дней")}");
                Console.WriteLine("Возможности:");
                foreach (var feature in plan.Features)
                {
                    Console.WriteLine($"  • {feature}");
                }
                Console.WriteLine(new string('-', 40));
            }
        }

        /// <summary>
        /// Оформить подписку на тарифный план
        /// </summary>
        static void SubscribeToPlan()
        {
            Console.WriteLine("\n--- ОФОРМЛЕНИЕ ПОДПИСКИ ---");
            DisplayAvailablePlans();

            Console.Write("Введите ID тарифного плана: ");
            if (int.TryParse(Console.ReadLine(), out int planId))
            {
                var plan = subscriptionService.GetPlanById(planId);
                if (plan != null)
                {
                    Console.WriteLine($"\nВыбран тариф: {plan.Name}");
                    Console.WriteLine($"Цена: {(plan.Price == 0 ? "Бесплатно" : $"{plan.Price} руб.")}");
                    Console.Write("Подтвердить оформление? (y/n): ");

                    var confirm = Console.ReadLine();
                    if (confirm?.ToLower() == "y")
                    {
                        subscriptionService.SubscribeUser(currentUserId, planId);
                    }
                    else
                    {
                        Console.WriteLine("Оформление подписки отменено.");
                    }
                }
                else
                {
                    ShowError("Тарифный план с таким ID не найден.");
                }
            }
            else
            {
                ShowError("Неверный формат ID.");
            }
        }

        /// <summary>
        /// Проверить текущую подписку пользователя
        /// </summary>
        static void CheckCurrentSubscription()
        {
            Console.WriteLine("\n--- ТЕКУЩАЯ ПОДПИСКА ---");
            var subscription = subscriptionService.GetUserSubscription(currentUserId);

            if (subscription != null)
            {
                var plan = subscriptionService.GetPlanById(subscription.PlanId);

                Console.WriteLine($"✅ У вас есть активная подписка:");
                Console.WriteLine($"Тариф: {plan?.Name ?? "Неизвестно"}");
                Console.WriteLine($"Статус: {subscription.Status}");
                Console.WriteLine($"Начало: {subscription.StartDate:dd.MM.yyyy HH:mm}");
                Console.WriteLine($"Окончание: {subscription.EndDate:dd.MM.yyyy HH:mm}");

                if (plan != null && plan.DurationDays > 0)
                {
                    var daysLeft = (int)(subscription.EndDate - DateTime.Now).TotalDays;
                    Console.WriteLine($"Осталось дней: {daysLeft}");

                    Console.WriteLine("\nДоступные возможности:");
                    foreach (var feature in plan.Features)
                    {
                        Console.WriteLine($"  • {feature}");
                    }
                }
            }
            else
            {
                ShowError("У вас нет активной подписки.");
            }
        }

        /// <summary>
        /// Отменить текущую подписку
        /// </summary>
        static void CancelCurrentSubscription()
        {
            Console.WriteLine("\n--- ОТМЕНА ПОДПИСКИ ---");
            var subscription = subscriptionService.GetUserSubscription(currentUserId);

            if (subscription != null)
            {
                var plan = subscriptionService.GetPlanById(subscription.PlanId);
                Console.WriteLine($"Текущая подписка: {plan?.Name}");
                Console.Write("Вы уверены, что хотите отменить подписку? (y/n): ");

                var confirm = Console.ReadLine();
                if (confirm?.ToLower() == "y")
                {
                    subscriptionService.CancelSubscription(currentUserId);
                }
                else
                {
                    Console.WriteLine("Отмена подписки отменена.");
                }
            }
            else
            {
                ShowError("Нет активной подписки для отмены.");
            }
        }

        /// <summary>
        /// Показать все подписки (для отладки)
        /// </summary>
        static void DisplayAllSubscriptions()
        {
            Console.WriteLine("\n--- ВСЕ ПОДПИСКИ (ОТЛАДКА) ---");
            var allSubscriptions = subscriptionService.GetAllSubscriptions();

            if (allSubscriptions.Any())
            {
                foreach (var sub in allSubscriptions)
                {
                    var plan = subscriptionService.GetPlanById(sub.PlanId);
                    Console.WriteLine($"Пользователь: {sub.UserId}, Тариф: {plan?.Name}, " +
                                    $"Активна: {sub.IsActive}, Действует до: {sub.EndDate:dd.MM.yyyy}");
                }
            }
            else
            {
                Console.WriteLine("Нет сохраненных подписок.");
            }
        }

        // Остальные методы остаются без изменений
        /// <summary>
        /// добавление аниме
        /// </summary>
        static void AddAnimeMenu()
        {
            Console.WriteLine("\n=== ДОБАВЛЕНИЕ АНИМЕ ===");

            string title = GetInput("Введите название: ");
            string genre = GetInput("Введите жанр: ");
            double rating = GetDoubleInput("Введите рейтинг (0-10): ", 0, 10);
            bool isWatched = GetBoolInput("Просмотрено? (1 - да, 0 - нет): ");

            logic.AddAnime(title, genre, rating, isWatched);
            ShowSuccess("Аниме успешно добавлено!");
        }

        /// <summary>
        /// удаление аниме
        /// </summary>
        static void DeleteAnimeMenu()
        {
            Console.WriteLine("\n=== УДАЛЕНИЕ АНИМЕ ===");

            var allAnime = logic.GetAllAnime();
            if (allAnime.Count == 0)
            {
                ShowError("Список аниме пуст!");
                return;
            }

            ShowAllAnime(allAnime);

            int id = GetIntInput("Введите ID аниме для удаления: ");
            bool result = logic.DeleteAnime(id);

            if (result)
                ShowSuccess("Аниме успешно удалено!");
            else
                ShowError("Аниме с таким ID не найдено!");
        }

        /// <summary>
        /// показать всё аниме
        /// </summary>
        static void ShowAllAnimeMenu()
        {
            Console.WriteLine("\n=== ВСЕ АНИМЕ ===");
            var allAnime = logic.GetAllAnime();

            if (allAnime.Count == 0)
            {
                ShowError("Список аниме пуст!");
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }

            ShowAllAnime(allAnime);

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        /// <summary>
        /// поиск аниме по ID
        /// </summary>
        static void FindAnimeByIdMenu()
        {
            Console.WriteLine("\n=== ПОИСК АНИМЕ ПО ID ===");
            int id = GetIntInput("Введите ID аниме: ");

            var anime = logic.GetAnimeById(id);
            if (anime != null)
            {
                Console.WriteLine("\nНайдено аниме:");
                Console.WriteLine($"ID: {anime.Id}");
                Console.WriteLine($"Название: {anime.Title}");
                Console.WriteLine($"Жанр: {anime.Genre}");
                Console.WriteLine($"Рейтинг: {anime.Rating:0.0#}");
            }
            else
            {
                ShowError("Аниме с таким ID не найдено!");
            }
        }

        /// <summary>
        /// изменение инфы по аниме
        /// </summary>
        static void UpdateAnimeMenu()
        {
            Console.WriteLine("\n=== ИЗМЕНЕНИЕ ИНФОРМАЦИИ ОБ АНИМЕ ===");

            var allAnime = logic.GetAllAnime();
            if (allAnime.Count == 0)
            {
                ShowError("Список аниме пуст!");
                return;
            }

            ShowAllAnime(allAnime);

            int id = GetIntInput("Введите ID аниме для изменения: ");
            var existingAnime = logic.GetAnimeById(id);

            if (existingAnime == null)
            {
                ShowError("Аниме с таким ID не найдено!");
                return;
            }

            Console.WriteLine($"\nТекущие данные: {existingAnime.Title}, {existingAnime.Genre}, {existingAnime.Rating:0.0#}");
            Console.WriteLine("Введите новые данные (оставьте пустым для сохранения текущего):");

            string newTitle = GetInputOrKeep($"Новое название [{existingAnime.Title}]: ", existingAnime.Title);
            string newGenre = GetInputOrKeep($"Новый жанр [{existingAnime.Genre}]: ", existingAnime.Genre);
            double newRating = GetDoubleInputOrKeep($"Новый рейтинг [{existingAnime.Rating:0.0#}]: ", existingAnime.Rating, 0, 10);
            bool newIsWatched = GetBoolInputOrKeep($"Просмотрено? (1/0) [текущее: {(existingAnime.IsWatched ? "да" : "нет")}]: ", existingAnime.IsWatched);

            bool result = logic.ChangeInfo(id, existingAnime.Title, existingAnime.Genre, existingAnime.Rating, existingAnime.IsWatched,
                                         newTitle, newGenre, newRating, newIsWatched);

            if (result)
                ShowSuccess("Информация об аниме успешно изменена!");
            else
                ShowError("Ошибка при изменении информации!");
        }

        /// <summary>
        /// группировка по жанрам
        /// </summary>
        static void GroupByGenreMenu()
        {
            Console.WriteLine("\n=== ГРУППИРОВКА ПО ЖАНРАМ ===");
            var grouped = logic.GroupByGenre();

            if (grouped.Count == 0)
            {
                ShowError("Нет данных для группировки!");
                return;
            }

            foreach (var group in grouped)
            {
                Console.WriteLine($"\n--- {group.Key.ToUpper()} ({group.Value.Count}) ---");
                foreach (var anime in group.Value)
                {
                    Console.WriteLine($"  {anime.Title} - {anime.Rating:0.0#}");
                }
            }
        }

        /// <summary>
        /// сортировка по рейтингу
        /// </summary>
        static void SortByRatingMenu()
        {
            Console.WriteLine("\n=== СОРТИРОВКА ПО РЕЙТИНГУ ===");
            Console.WriteLine("1. По возрастанию");
            Console.WriteLine("2. По убыванию");

            string choice = GetInput("Выберите порядок сортировки: ");
            bool ascending = choice == "1";

            var sorted = logic.GetAnimeSortedByRating(ascending);

            if (sorted.Count == 0)
            {
                ShowError("Нет данных для сортировки!");
                return;
            }

            Console.WriteLine($"\nАниме {(ascending ? "по возрастанию" : "по убыванию")} рейтинга:");
            foreach (var anime in sorted)
            {
                Console.WriteLine($"{anime.Title} - {anime.Rating:0.0#} - {anime.Genre}");
            }
        }

        /// <summary>
        /// сортировка по жанру и рейтингу
        /// </summary>
        static void SortByGenreAndRatingMenu()
        {
            Console.WriteLine("\n=== СОРТИРОВКА ПО ЖАНРУ И РЕЙТИНГУ ===");


            var allAnime = logic.GetAllAnime();
            var genres = allAnime.Select(a => a.Genre).Distinct().ToList();

            if (genres.Count == 0)
            {
                ShowError("Нет доступных жанров!");
                return;
            }

            Console.WriteLine("Доступные жанры:");
            for (int i = 0; i < genres.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {genres[i]}");
            }

            int genreIndex = GetIntInput("Выберите жанр: ", 1, genres.Count) - 1;
            string selectedGenre = genres[genreIndex];

            Console.WriteLine("1. По возрастанию рейтинга");
            Console.WriteLine("2. По убыванию рейтинга");
            string sortChoice = GetInput("Выберите порядок сортировки: ");
            bool ascending = sortChoice == "1";

            var sorted = logic.GetAnimeSortedByRatingWithGenre(selectedGenre, ascending);

            if (sorted.Count == 0)
            {
                ShowError($"Нет аниме в жанре '{selectedGenre}'!");
                return;
            }

            Console.WriteLine($"\nАниме жанра '{selectedGenre}' {(ascending ? "по возрастанию" : "по убыванию")} рейтинга:");
            foreach (var anime in sorted)
            {
                Console.WriteLine($"{anime.Title} - {anime.Rating:0.0#}");
            }
        }

        /// <summary>
        /// показывает все аниме
        /// </summary>
        /// <param name="animeList">Число всех аниме в списке</param>
        static void ShowAllAnime(List<Anime> animeList)
        {
            Console.WriteLine("ID | Название | Жанр | Рейтинг | Просмотрено");
            Console.WriteLine("---------------------------------------------");
            foreach (var anime in animeList)
            {
                Console.WriteLine($"{anime.Id} | {anime.Title} | {anime.Genre} | {anime.Rating:0.0#} | {(anime.IsWatched ? "да" : "нет")}");
            }
            Console.WriteLine($"\nВсего: {animeList.Count} аниме");
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().Trim();
        }

        static string GetInputOrKeep(string prompt, string defaultValue)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            return string.IsNullOrEmpty(input) ? defaultValue : input;
        }

        static int GetIntInput(string prompt, int min = 1, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                    return result;
                Console.WriteLine($"Ошибка! Введите число от {min} до {max}");
            }
        }

        static double GetDoubleInput(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine().Replace(',', '.'), out double result) && result >= min && result <= max)
                    return result;
                Console.WriteLine($"Ошибка! Введите число от {min} до {max}");
            }
        }

        static double GetDoubleInputOrKeep(string prompt, double defaultValue, double min, double max)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input)) return defaultValue;

            if (double.TryParse(input.Replace(',', '.'), out double result) && result >= min && result <= max)
                return result;

            Console.WriteLine($"Ошибка! Используется значение по умолчанию: {defaultValue:0.0#}");
            return defaultValue;
        }

        static bool GetBoolInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "1" || input == "да" || input == "y" || input == "yes" || input == "д") return true;
                if (input == "0" || input == "нет" || input == "n" || input == "no" || input == "н") return false;
                Console.WriteLine("Ошибка! Введите 1/0 или да/нет");
            }
        }

        static bool GetBoolInputOrKeep(string prompt, bool defaultValue)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrEmpty(input)) return defaultValue;
            if (input == "1" || input == "да" || input == "y" || input == "yes" || input == "д") return true;
            if (input == "0" || input == "нет" || input == "n" || input == "no" || input == "н") return false;
            Console.WriteLine("Ошибка! Используется текущее значение.");
            return defaultValue;
        }

        /// <summary>
        /// Отображает сообщение об успехе в консоли с зеленым цветом текста
        /// </summary>
        /// <param name="message">Текст сообщения для отображения</param>
        static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        /// <summary>
        /// показывает ошибку
        /// </summary>
        /// <param name="message">Текс об ошибке</param>
        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        /// <summary>
        /// Добавляет в список базовые аниме
        /// </summary>
        static void AddSampleData()
        {
            logic.AddAnime("Attack on Titan", "Action", 9.2);
            logic.AddAnime("Naruto", "Adventure", 8.5);
            logic.AddAnime("One Piece", "Adventure", 9.0);
            logic.AddAnime("Death Note", "Mystery", 8.8);
            logic.AddAnime("My Hero Academia", "Action", 8.3);
        }
    }
}
