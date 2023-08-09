using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.backend.infra.extensions
{
    public static class DateTimeExtensions
    {
        public static bool Between(this DateTime dateTime, DateTime valueFrom, DateTime valueTo)
        {
            return (dateTime >= valueFrom) && (dateTime <= valueTo);
        }
    }
}
