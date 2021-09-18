using System.Collections.Generic;

namespace TodayExchangeRate.Models
{
    public class ApiLayerModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ApiLayerModel"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the terms.
        /// </summary>
        /// <value>
        /// The terms.
        /// </value>
        public string Terms { get; set; }

        /// <summary>
        /// Gets or sets the privacy.
        /// </summary>
        /// <value>
        /// The privacy.
        /// </value>
        public string Privacy { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>
        /// The time stamp.
        /// </value>
        public int TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the quotes.
        /// </summary>
        /// <value>
        /// The quotes.
        /// </value>
        public Dictionary<string, decimal> Quotes { get; set; }
    }
}
