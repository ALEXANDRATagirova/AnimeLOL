using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void AddAnime(string title, string genre, double rating, string imagePath = "")
        {
            Anime anime = new Anime()
            {
                Id = nextId++,
                Title = title,
                Genre = genre,
                Rating = rating
            };
            animeList.Add(anime);

        }
        /// <summary>
        /// удаляет
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteAnime(int id)
        {
            Anime animeToRemove = animeList.FirstOrDefault(a => a.Id == id);

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
        /// <param name="id"></param>
        /// <returns></returns>
        public Anime GetAnimeById(int id)
        {
            return animeList.FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// показывает все аниме
        /// </summary>
        /// <returns></returns>
        public List<Anime> GetAllAnime()
        {
            return new List<Anime>(animeList);
        }
        /// <summary>
        /// изменить инфу про аниме
        /// </summary>
        /// <param name="id"></param>
        /// <param name="oldTitle">старое название</param>
        /// <param name="oldGenre">старый жанр</param>
        /// <param name="oldRating">старый рейтинг</param>
        /// <param name="newTitle"></param>
        /// <param name="newGenre"></param>
        /// <param name="newRating"></param>
        /// <returns></returns>
        public bool ChangeInfo(int id ,string oldTitle, string oldGenre, double oldRating,
                              string newTitle, string newGenre, double newRating)
        {
            Anime animeToChange = animeList.FirstOrDefault(a => a.Id == id);

            if (animeToChange != null)
            {
                animeToChange.Title = newTitle;
                animeToChange.Genre = newGenre;
                animeToChange.Rating = newRating;
                return true;
            }
            return false;
        }
        /// <summary>
        /// группирует по жанру
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Anime>> GroupByGenre()
        {
            return animeList.GroupBy(a => a.Genre).ToDictionary(g => g.Key, g => g.ToList());
        }
        /// <summary>
        /// сортирует по рейтингу
        /// </summary>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public List<Anime> GetAnimeSortedByRating(bool ascending = true)
        {
            if (ascending)
                return animeList.OrderBy(a => a.Rating).ToList();
            else
                return animeList.OrderByDescending(a => a.Rating).ToList();
        }

        /// <summary>
        /// сортирует по рейтингу в жанре
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public List<Anime> GetAnimeSortedByRatingWithGenre(string genre, bool ascending = true)
        {
            if (ascending)
            {
                return animeList.OrderBy(a => a.Rating).ToList();
            }
            else
            {
                return animeList.OrderByDescending(a => a.Rating).ToList();
            }
        }
        /// <summary>
        /// показать все жанры
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllGenres()
        {
            return animeList.Select(a => a.Genre).Distinct().ToList();
        }
        




    }
}
