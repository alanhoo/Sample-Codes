using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Helpers;
using StockAjaxMvc.Model;
using Newtonsoft.Json.Linq;

namespace StockAjaxMVC.BLL
{
    public class StockAjaxMVCflow
    {
        private string webAddress;

        public IEnumerable<Quote> ExecuteQuote(string symbols)
        {
            string symbol = convertSymbols(symbols);  

            webAddress = string.Empty;
            webAddress = string.Concat(webAddress, "http://query.yahooapis.com/v1/public/yql?");
            webAddress = string.Concat(webAddress, "q=");
            webAddress = string.Concat(webAddress, System.Web.HttpUtility.UrlEncode("select *  from csv where url=\"http://finance.yahoo.com/d/quotes.csv?s="));
            webAddress = string.Concat(webAddress, System.Web.HttpUtility.UrlEncode(symbol));
            webAddress = string.Concat(webAddress, System.Web.HttpUtility.UrlEncode("&f=snd1l1yrc1\""));
            webAddress = string.Concat(webAddress, System.Web.HttpUtility.UrlEncode(" and columns = 'Symbol,Name,LastTradeDay,LastTradePrice,DividendYield,PERatio,Change'"));
            webAddress = string.Concat(webAddress, "&format=json");
            webAddress = string.Concat(webAddress, "&diagnostics=false");

            string results = "";

            using (WebClient wc = new WebClient())
            {
                results = wc.DownloadString(webAddress);
            }

            JObject dataJObject = JObject.Parse(results);
            
            if (symbols.Contains(","))
            {
                JArray jArray = (JArray) dataJObject["query"]["results"]["row"];

                IEnumerable<Quote> quotes = getQuoteList(jArray);
                return quotes;
            }
            else
            {
                IEnumerable<Quote> quotes = getSingleQuoteList(dataJObject);
                return quotes;
            }
        }

        private List<Quote> getSingleQuoteList(JObject quote)
        {
            List<Quote> quoteList = new List<Quote>();

            quoteList.Add(new Quote(quote["query"]["results"]["row"]["Symbol"].ToString(),
                quote["query"]["results"]["row"]["Name"].ToString(),
                quote["query"]["results"]["row"]["LastTradeDay"].ToString(),
                quote["query"]["results"]["row"]["LastTradePrice"].ToString(),
                quote["query"]["results"]["row"]["DividendYield"].ToString(),
                quote["query"]["results"]["row"]["PERatio"].ToString(),
                quote["query"]["results"]["row"]["Change"].ToString()));

            return quoteList;
        } 

        private List<Quote> getQuoteList(JArray quotes)
        {
            List<Quote> quoteList = new List<Quote>();

            foreach (var stock in quotes)
            {
                quoteList.Add(new Quote(stock["Symbol"].ToString(), stock["Name"].ToString(), stock["LastTradeDay"].ToString(),
                    stock["LastTradePrice"].ToString(), stock["DividendYield"].ToString(), stock["PERatio"].ToString(),
                    stock["Change"].ToString()));
            }
            return quoteList;
        }

        private string convertSymbols(string symbols)
        {
            if (symbols.Contains(","))
            {
                symbols = symbols.Replace(" ", "");
                var results = symbols.Split(',');

                StringBuilder symbolURL = new StringBuilder();
                for (int i = 0; i < results.Length; i++)
                {
                    symbolURL.Append(results[i]);
                    if (i < results.Length - 1)
                    {
                        symbolURL.Append("+");
                    }
                }
                return symbolURL.ToString();
            }
            return symbols;
        }
    }
}