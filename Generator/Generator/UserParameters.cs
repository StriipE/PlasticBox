using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class UserParameters
    {
        public int SalesVariationPercentage { get; set; }
        public int BeginningSalesAmount { get; set; }
        public DateTime BeginningDate { get; set; }
        public int NumberOfWeeks { get; set; }

        public UserParameters(int _SalesVariationPercentage, int _BeginningSalesAmount,
                              DateTime _BeginningDate, int _NumberOfWeeks)
        {
            SalesVariationPercentage = _SalesVariationPercentage;
            BeginningSalesAmount = _BeginningSalesAmount;
            BeginningDate = _BeginningDate;
            NumberOfWeeks = _NumberOfWeeks;
        }
    }
}
