using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayExchangeRate.Models
{
    public class OpenMarketModel
    {
        /// <summary>
        /// Gets or sets the disclaimer.
        /// </summary>
        /// <value>
        /// The disclaimer.
        /// </value>
        public string Disclaimer { get; set; }

        /// <summary>
        /// Gets or sets the license.
        /// </summary>
        /// <value>
        /// The license.
        /// </value>
        public string License { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>
        /// The time stamp.
        /// </value>
        public int TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the base.
        /// </summary>
        /// <value>
        /// The base.
        /// </value>
        public string Base { get; set; }

        /// <summary>
        /// Gets or sets the rates.
        /// </summary>
        /// <value>
        /// The rates.
        /// </value>
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
