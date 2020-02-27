using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsacWeb.Models
{
    public class UsuarioUrlsViewModel
    {
     
        public string AppUserId { get; set; }

        public Int64[] UrlIds { get; set; }

        public IEnumerable<SelectListItem> Urls { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }

        public Dictionary<string, IEnumerable<SelectListItem>> KeyUrls { get; set; }

    }
}
