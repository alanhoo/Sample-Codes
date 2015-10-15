using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAjaxMvc.Model
{
    public class Quote
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string LastTradeDay { get; set; }
        public string LastTradePrice { get; set; }
        public string DividendYield { get; set; }
        public string PERatio { get; set; }
        public string Change { get; set; }
        public string Uptick { get; set; }  // 0 - up. 1 - down, 2 - neutral

        public Quote(string symbol, string name, string lastTradeDay,
            string lastTradePrice, string dividendYield, string pERatio, string change)
        {
            Symbol = symbol;
            Name = name;
            LastTradeDay = lastTradeDay;
            LastTradePrice = lastTradePrice;
            DividendYield = dividendYield;
            PERatio = pERatio;
            Change = change;
            Uptick = getChange(Change);
        }

        private string getChange(string change)
        {
            string result;
            if (!string.IsNullOrEmpty(change))
            {
                if (change.Contains("+"))
                {
                    result = "0";
                }
                else if (change.Contains("-"))
                {
                    result = "1";
                }
                else
                {
                    result = "2";
                }
            }
            else
            {
                result = "2";
            }          
            return result;
        }
    }
}
