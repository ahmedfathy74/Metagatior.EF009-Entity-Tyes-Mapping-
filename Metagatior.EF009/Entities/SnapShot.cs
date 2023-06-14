using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF009.BasicSetup.Entities
{
    public class SnapShot
    {
        public DateTime LoadedAt => DateTime.UtcNow;
        public string Version =>
            Guid.NewGuid().ToString().Substring(0, 8);
    }
}
