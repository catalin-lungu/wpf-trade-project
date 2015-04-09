using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmK_Business.Model
{
    [Table("TradingJournalModel")]
    public class TradingJournalModel
    {
        #region col 1
        

        [Key]
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int AccountId { get; set; }
        // This property marks the FK relation
        public virtual Account Account { get; set; }

        [Column("OrderNum")]
        private string orderNum;
        public string OrderNum
        {
            get { return orderNum; }
            set { orderNum = value; }
        }

        [Column("Instrument")]
        private string instrument;
        public string Instrument
        {
            get { return instrument; }
            set { instrument = value; }
        }

        [Column("Type")]
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [Column("Category")]
        private string category;
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        [Column("LotSize")]
        private string lotSize;
        public string LotSize
        {
            get { return lotSize; }
            set { lotSize = value; }
        }

        [Column("EntryPrice")]
        private int entryPrice;
        public int EntryPrice
        {
            get { return entryPrice; }
            set { entryPrice = value; }
        }

        [Column("EntryDate")]
        private DateTime entryDate;
        public DateTime EntryDate 
        {
            get { return entryDate; }
            set { entryDate = value; }
        }

#endregion

        #region col2
        private int tpPrice;
        public int TPPrice
        {
            get { return tpPrice; }
            set { tpPrice = value; }
        }

        private string targetPips;

        public string TargetPips
        {
            get { return targetPips; }
            set { targetPips = value; }
        }
        private int target;

        public int Target
        {
            get { return target; }
            set { target = value; }
        }
        private int slPips;

        public int SLPips
        {
            get { return slPips; }
            set { slPips = value; }
        }
        private int sl;

        public int SL
        {
            get { return sl; }
            set { sl = value; }
        }
        private string rr;

        public string RR
        {
            get { return rr; }
            set { rr = value; }
        }
#endregion

        #region col 3
        private int exitPrice;

        public int ExitPrice
        {
            get { return exitPrice; }
            set { exitPrice = value; }
        }

        private string realizedRR;

        public string RealizedRR
        {
            get { return realizedRR; }
            set { realizedRR = value; }
        }
        private DateTime exitDate;

        public DateTime ExitDate
        {
            get { return exitDate; }
            set { exitDate = value; }
        }
        #endregion

        #region col4
        private int netPL;

        public int NetPL
        {
            get { return netPL; }
            set { netPL = value; }
        }
        private int commission;

        public int Commission
        {
            get { return commission; }
            set { commission = value; }
        }
        private string swap;

        public string Swap
        {
            get { return swap; }
            set { swap = value; }
        }
        private int grossPL;

        public int GrossPL
        {
            get { return grossPL; }
            set { grossPL = value; }
        }
        private int wonPips;

        public int WonPips
        {
            get { return wonPips; }
            set { wonPips = value; }
        }
        private int lostPips;

        public int LostPips
        {
            get { return lostPips; }
            set { lostPips = value; }
        }
        private string runBalance;

        public string RunBalance
        {
            get { return runBalance; }
            set { runBalance = value; }
        }
        #endregion

        #region col5
        private string tradingTF;

        public string TradingTF
        {
            get { return tradingTF; }
            set { tradingTF = value; }
        }
        private string entryTF;

        public string EntryTF
        {
            get { return entryTF; }
            set { entryTF = value; }
        }


        private string durationHours;

        public string DurationHours
        {
            get { return durationHours; }
            set { durationHours = value; }
        }

        private string durationMinutes;

        public string DurationMinutes
        {
            get { return durationMinutes; }
            set { durationMinutes = value; }
        }

        public string Duration
        {
            get { return DurationHours + " " + DurationMinutes; }
            //set { duration = value; }
        }
        #endregion

        #region strategy
        private string entryReason;
        public string EntryReason
        {
            get { return entryReason; }
            set { entryReason = value; }
        }

        private string entryReasonLong;
        public string EntryReasonLong
        {
            get { return entryReasonLong; }
            set { entryReasonLong = value; }
        }


        private string exitReason;
        public string ExitReason
        {
            get { return exitReason; }
            set { exitReason = value; }
        }
        private string exitReasonLong;
        public string ExitReasonLong
        {
            get { return exitReasonLong; }
            set { exitReasonLong = value; }
        }


        private string strategyUsed;
        public string StrategyUsed
        {
            get { return strategyUsed; }
            set { strategyUsed = value; }
        }

        private string strategyUsedLong;
        public string StrategyUsedLong
        {
            get { return strategyUsedLong; }
            set { strategyUsedLong = value; }
        }



        #endregion

        private string notes;
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
         
    }

    //public struct Time
    //{
    //    public int Hours { get; set; }
    //    public int Minutes { get; set; }

    //    public override string ToString()
    //    {
    //        return Hours + " " + Minutes;
    //    }
    //}
}
