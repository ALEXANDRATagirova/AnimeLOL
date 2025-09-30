using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Model;

namespace ConsoleApp7
{
    internal class Program
    {
        static Logic logic = new Logic();

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
                    case "9": running = false; break;
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
            Console.WriteLine("9. Выход");
            Console.Write("Выберите действие: ");
        }

        /// <summary>
        /// добавление аниме
        /// </summary>
        static void AddAnimeMenu()
        {
            Console.WriteLine("\n=== ДОБАВЛЕНИЕ АНИМЕ ===");

            string title = GetInput("Введите название: ");
            string genre = GetInput("Введите жанр: ");
            double rating = GetDoubleInput("Введите рейтинг (0-10): ", 0, 10);

            logic.AddAnime(title, genre, rating);
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

            bool result = logic.ChangeInfo(id, existingAnime.Title, existingAnime.Genre, existingAnime.Rating,
                                         newTitle, newGenre, newRating);

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
        /// показать все аниме
        /// </summary>
        /// <param name="animeList"></param>
        static void ShowAllAnime(List<Anime> animeList)
        {
            Console.WriteLine("ID | Название | Жанр | Рейтинг");
            Console.WriteLine("--------------------------------");
            foreach (var anime in animeList)
            {
                Console.WriteLine($"{anime.Id} | {anime.Title} | {anime.Genre} | {anime.Rating:0.0#}");
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
        /// <summary>
        /// успех
        /// </summary>
        /// <param name="message"></param>
        static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        /// <summary>
        /// ошибка
        /// </summary>
        /// <param name="message"></param>
        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

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
