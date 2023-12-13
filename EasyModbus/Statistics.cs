using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyModbus
{
    /// <summary>
    /// Hold the statistices of 1 type of function call.
    /// </summary>
    public class Statistic
    {
        /// <summary>
        /// The number of calls at the previous recaluclation.
        /// </summary>
        private int prevCalls;

        /// <summary>
        /// The number of fails at the previous recalulation.
        /// </summary>
        private int prevFails;

        /// <summary>
        /// Gets or sets the nr calls made.
        /// </summary>
        /// <value>
        /// The number of calls.
        /// </value>
        public int NrCalls { get; set; }

        /// <summary>
        /// Gets or sets the number of failed calls.
        /// </summary>
        /// <value>
        /// The number of fails.
        /// </value>
        public int NrFails { get; set; }

        /// <summary>
        /// Gets the number of failed calls per second.
        /// </summary>
        /// <value>
        /// The failoed percentage.
        /// </value>
        public double FailsPerSec { get; private set; }

        /// <summary>
        /// Gets the number of calls per sec.
        /// </summary>
        /// <value>
        /// The calls per sec.
        /// </value>
        public double CallsPerSec { get; private set; }

        /// <summary>
        /// Recalculates the number of calls per second and percantage of fails.
        /// </summary>
        /// <param name="timeSinceLastRecal">The time since last recalculation.</param>
        public void Recalculate(TimeSpan timeSinceLastRecal)
        {
            CallsPerSec = (double)(NrCalls - prevCalls) / timeSinceLastRecal.TotalSeconds;
            prevCalls = NrCalls;

            FailsPerSec = (double)(NrFails - prevFails) / timeSinceLastRecal.TotalSeconds;
            prevFails = NrFails;
        }
    }

    /// <summary>
    /// Data class to hold all the statistics of each function call.
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// The last time a recalculate of the statistics was done
        /// </summary>
        private DateTime lastTimeRecalculate = DateTime.UtcNow;

        /// <summary>
        /// Initializes a new instance of the <see cref="Statistics"/> class.
        /// </summary>
        public Statistics()
        {
            ReadCoilsStats = new Statistic();
            ReadDiscreteStats = new Statistic();
            ReadHoldingStats = new Statistic();
            ReadInputStats = new Statistic();
            WriteSingleCoilStats = new Statistic();
            WriteSingleRegStats = new Statistic();
            WriteMultiCoilsStats = new Statistic();
            WriteMultiRegsStats = new Statistic();
            RWMultiRegsStats = new Statistic();
        }

        /// <summary>
        /// Gets or sets the statistics of read coils stats.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public Statistic ReadCoilsStats { get; set; }

        /// <summary>
        /// Gets or sets the statistics of read discrete stats.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public Statistic ReadDiscreteStats { get; set; }

        /// <summary>
        /// Gets or sets the statistics of read holding stats.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public Statistic ReadHoldingStats { get; set; }

        /// <summary>
        /// Gets or sets the statistics of read input stats.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public Statistic ReadInputStats { get; set; }

        /// <summary>
        /// Gets or sets the statistics of write single coil stats.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public Statistic WriteSingleCoilStats { get; set; }

        /// <summary>
        /// Gets or sets the statistics of write single reg stats.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public Statistic WriteSingleRegStats { get; set; }

        /// <summary>
        /// Gets or sets the statistics of write multi coils stats.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public Statistic WriteMultiCoilsStats { get; set; }

        /// <summary>
        /// Gets or sets the statistics of write multi regs stats.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public Statistic WriteMultiRegsStats { get; set; }

        /// <summary>
        /// Gets or sets the statistics of rw multi regs stats.
        /// </summary>
        /// <value>
        /// The statistics.
        /// </value>
        public Statistic RWMultiRegsStats { get; set; }

        /// <summary>
        /// Gets the time difference between recalculations.
        /// </summary>
        /// <value>
        /// The time difference.
        /// </value>
        public TimeSpan TimeDiffBetweenRecal { get; private set; }

        /// <summary>
        /// Recalculates ll the internal statistics.
        /// </summary>
        public void Recalculate()
        {
            TimeDiffBetweenRecal = DateTime.UtcNow- lastTimeRecalculate;
            lastTimeRecalculate = DateTime.UtcNow;

            ReadCoilsStats.Recalculate(TimeDiffBetweenRecal);
            ReadDiscreteStats.Recalculate(TimeDiffBetweenRecal);
            ReadHoldingStats.Recalculate(TimeDiffBetweenRecal);
            ReadInputStats.Recalculate(TimeDiffBetweenRecal);
            WriteSingleCoilStats.Recalculate(TimeDiffBetweenRecal);
            WriteSingleRegStats.Recalculate(TimeDiffBetweenRecal);
            WriteMultiCoilsStats.Recalculate(TimeDiffBetweenRecal);
            WriteMultiRegsStats.Recalculate(TimeDiffBetweenRecal);
            RWMultiRegsStats.Recalculate(TimeDiffBetweenRecal);
        }
    }
}
