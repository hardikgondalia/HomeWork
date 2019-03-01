using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class DropDownModel
    {
        List<Project> _Project = new List<Project>();
        public IEnumerable<SelectListItem> ProjectList
        {
            get
            {
                _Project.Add(new Project { Project_ID = 1, Catetory_ID = 1, Project_Title = "Project 1" });
                _Project.Add(new Project { Project_ID = 2, Catetory_ID = 1, Project_Title = "Project 2" });
                _Project.Add(new Project { Project_ID = 3, Catetory_ID = 1, Project_Title = "Project 3" });
                _Project.Add(new Project { Project_ID = 4, Catetory_ID = 2, Project_Title = "Project 4" });
                _Project.Add(new Project { Project_ID = 5, Catetory_ID = 3, Project_Title = "Project 5" });
                _Project.Add(new Project { Project_ID = 6, Catetory_ID = 3, Project_Title = "Project 6" });
                return new SelectList(_Project, "Project_ID", "Project_Title");
            }
        }
        List<Category> _Category = new List<Category>();
        public IEnumerable<SelectListItem> CategoryList
        {
            get
            {
                _Category.Add(new Category { Category_ID = 1, Category_Title = "Category 1" });
                _Category.Add(new Category { Category_ID = 2, Category_Title = "Category 2" });
                _Category.Add(new Category { Category_ID = 3, Category_Title = "Category 3" });
                return new SelectList(_Category, "Category_ID", "Category_Title");
            }
        }
    }

    public class Project
    {
        public int Project_ID { get; set; }
        public int Catetory_ID { get; set; }
        public string Project_Title { get; set; }
    }

    public class Category
    {
        public int Category_ID { get; set; }
        public string Category_Title { get; set; }
    }

    public class Test1
    {
        public int Reference_ID { get; set; }
        public string Reference_Title { get; set; }
    }

    public class Multiselect
    {
        List<Movie> _Movie = new List<Movie>();
        public IEnumerable<SelectListItem> ProjectList
        {
            get
            {
                _Movie.Add(new Movie { Movie_ID = 1, Title = "Movie 1" });
                _Movie.Add(new Movie { Movie_ID = 2, Title = "Movie 2" });
                _Movie.Add(new Movie { Movie_ID = 3, Title = "Movie 3" });
                _Movie.Add(new Movie { Movie_ID = 4, Title = "Movie 4" });
                _Movie.Add(new Movie { Movie_ID = 5, Title = "Movie 5" });
                _Movie.Add(new Movie { Movie_ID = 6, Title = "Movie 6" });
                return new SelectList(_Movie, "Movie_ID", "Title");
            }
        }
        MovieList movie = new MovieList();
        //public List<int> MovieList { get; set; }
        public DateTime Duration { get; set; }
    }

    public class Movie
    {
        public int Movie_ID { get; set; }
        public String Title { get; set; }
    }

    public class MovieList
    {
        List<Movie> _movieList = new List<Movie>()
        {
            new Movie { Movie_ID = 1, Title = "Movie 1" },
            new Movie { Movie_ID = 2, Title = "Movie 2" },
            new Movie { Movie_ID = 3, Title = "Movie 3" },
            new Movie { Movie_ID = 4, Title = "Movie 4" },
            new Movie { Movie_ID = 5, Title = "Movie 5" },
            new Movie { Movie_ID = 6, Title = "Movie 6" }
        };
    }
}