using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp
{
    class ClientsComparer : IComparer<IClient>
    {
        public int Compare(IClient x, IClient y)
        {
            if (x.CountOfTickets > y.CountOfTickets) return -1;

            if (x.CountOfTickets < y.CountOfTickets) return 1;

            return 0;
        }
    }
}
