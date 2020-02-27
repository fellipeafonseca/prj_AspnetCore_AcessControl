using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VsacWeb.Models;

namespace VsacWeb.Data
{
    public class AuditEntry
    {
        //  private readonly UserManager<AppUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public AuditEntry(EntityEntry entry, IHttpContextAccessor httpContextAccessor)
        {
            Entry = entry;

            _httpContextAccessor = httpContextAccessor;
        }


        public EntityEntry Entry { get; }
        public string TableName { get; set; }
        // public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public string Operacao { get; set; }
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public Log ToLog()
        {

            var log = new Log();
            log.Tabela = TableName;
            log.Data = DateTime.UtcNow;
            log.Operacao = Operacao;
            log.ValorAntigo = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            log.ValorNovo = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            log.AppUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return log;
        }
    

}
}
