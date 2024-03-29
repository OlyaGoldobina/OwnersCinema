﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    public class FilmRepositiory : IRepository<Film>
    {

        OurCinema Cinema =  Factory.Instance.GetOurCinema();

        public FilmRepositiory()
        {

        }

        public bool AddItem(Film item)
        {
            try
            {
                int tempID = 0;
                foreach (Film film in Cinema.Films)
                {
                    if (film.FilmID > tempID)
                    {
                        tempID = film.FilmID;
                    }
                }
                item.FilmID = tempID + 1;
                Cinema.Films.Add(item);
                Cinema.SaveChanges();
                return true;
            }
            catch 
            {

                return false;
            }

        }

        public bool RemoveItem(Film item)
        {
            try
            {
                foreach (Film film in Cinema.Films)
                {
                    if (film.FilmID == item.FilmID)
                    {
                        Cinema.Films.Remove(film);
                      
                        
                    }
                }
                Cinema.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
           }
            
        }

        public bool UpdateItem(Film previous, Film updated)
        {
            try
            {
                foreach (Film film in Cinema.Films)
                {
                    if (film.FilmID == previous.FilmID)
                    {
                        //Cinema.Films.Remove(film);
                        //Cinema.Films.Add(updated);
                        //Cinema.SaveChanges();
                        film.CostOfMovieRental = updated.CostOfMovieRental;
                        film.Finish = updated.Finish;
                        film.Start = updated.Start;
                        film.Name = updated.Name;
                    }

                }
                Cinema.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }       
        }

        public List<Film> SelectItem()
        {
            List<Film> films = new List<Film>();
            DbSet<Film> dbSet = Cinema.Films;
            foreach (Film item in dbSet)
                films.Add(item);
            return films;
        }
    }
}
