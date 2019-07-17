﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCase.Models.ViewModels
{
    public class BookCreateViewModel
    {
        public Book Book { get; set; }
        public List<Author> AvailableAuthors { get; set; }
        public List<SelectListItem> AuthorOptions => AvailableAuthors?.Select(a => new SelectListItem(a.FullName, a.Id.ToString())).ToList();
        public List<Genre> AvailableGenres { get; set; }
        public List<SelectListItem> GenreOptions => AvailableGenres?.Select(g => new SelectListItem(g.Name, g.Id.ToString())).ToList();
    }
}
