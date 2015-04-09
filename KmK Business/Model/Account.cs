using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmK_Business.Model
{
    [Table("Account")]
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDemo { get; set; }

        //[ForeignKey("DefaultAddressId")]
        //public virtual TradingJournalModel DefaultAddress { get; set; }
        //public virtual ICollection<TradingJournalModel> Addresses { get; set; }

        public virtual ObservableCollection<TradingJournalModel> TradingJournal { get; set; }

        //public virtual ObservableCollection<TradingJournalModel> tradingJournal = new ObservableCollection<TradingJournalModel>();
        //public ObservableCollection<TradingJournalModel> TradingJournal
        //{
        //    get { return tradingJournal; }
        //    set { tradingJournal = value; }
        //}

    }
}
