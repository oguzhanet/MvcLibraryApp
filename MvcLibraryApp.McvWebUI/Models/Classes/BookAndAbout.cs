using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Models.Classes
{
    public class BookAndAbout
    {
        public IEnumerable<Books> Books { get; set; }
        public IEnumerable<Abouts> Abouts { get; set; }
    }
}