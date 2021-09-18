using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayExchangeRate.Interface
{
    public interface  IMessageBuilder
    {
        string BuildExchangeMessage(decimal apiRate, decimal marketRate);
    }
}
