using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmK_Business.Model
{
    [Table("Plan")]
    public class Plan
    {
        public long Id { get; set; }
        public bool IsTest { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TradingPlanName { get; set; }
        public string TradingPlanNameLongDesc { get; set; }

        public string WhatKingOfPerson { get; set; }
        public string MyStrength { get; set; }
        public string MyWeaknesses { get; set; }
        public string DoIWantToBeATrader { get; set; }
        public string CanICommitEnoughTime { get; set; }
        public string DoIHaveFinancial { get; set; }
        public string CanIhandlePressure { get; set; }
        public string DoIGiveUpEasily { get; set; }
        public string DoIHaveEnoughWillpower { get; set; }

        public bool DoIWantToBeATraderYesNo { get; set; }
        public bool CanICommitEnoughTimeYesNo { get; set; }
        public bool DoIHaveFinancialYesNo { get; set; }
        public bool CanIhandlePressureYesNo { get; set; }
        public bool DoIGiveUpEasilyYesNo { get; set; }
        public bool DoIHaveEnoughWillpowerYesNo { get; set; }

        public string WhatIsMyTradingGoal { get; set; }
        public string GoalAdditionalNotesAndComments { get; set; }

        public string MaxRiskAccount { get; set; }
        public string MinRiskRewardRatio { get; set; }
        public string MaxStopLoss { get; set; }
        public bool LongTerm { get; set; }
        public bool Swing { get; set; }
        public bool IntraDay { get; set; }
        public bool Scalp { get; set; }

        public bool SupplyDemand { get; set; }
        public bool PriceAnalysis { get; set; }
        public bool Breakouts { get; set; }
        public bool Momentum { get; set; }
        public bool Divergence { get; set; }

        public bool Trend { get; set; }
        public bool OscillatorsOverbought { get; set; }
        public bool Retracements { get; set; }
        public bool CandlePatterns { get; set; }
        public bool HistoricalSupRes { get; set; }

        public bool MALines { get; set; }
        public bool DailyOpenLine { get; set; }
        public bool Reversals { get; set; }
        public bool ChartPatterns { get; set; }
        public bool RoundNumbers { get; set; }

        public string StrategyAdditionalNotesAndComments { get; set; }

        public string EntryRule { get; set; }
        public string TradeManagementRule { get; set; }
        public string ExitRule { get; set; }
        public string AdditionalRules { get; set; }
        public string RulesAdditionalNotesAndComments { get; set; }

    }
}
