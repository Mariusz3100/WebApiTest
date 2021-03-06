﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace Invest
{

    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    [System.Runtime.Serialization.DataContract]
    public class Transaction
    {
        [Newtonsoft.Json.JsonProperty]
        public int id;

        [Newtonsoft.Json.JsonProperty]
        public string exchangeRate;

        [Newtonsoft.Json.JsonProperty]
        public string currencyCode;

        [Newtonsoft.Json.JsonProperty]
        public string quantity;
        
        public Transaction(int id, string exchangeRate, string currencyCode, string quantity)
        {
            this.id = id;
            this.exchangeRate = exchangeRate;
            this.currencyCode = currencyCode;
            this.quantity = quantity;
        }

        public int getId()
        {
            return this.id;
        }

        public string getExchangeRate()
        {
            return this.exchangeRate;
        }

        public string getCurrencyCode()
        {
            return this.currencyCode;
        }

        public string getQuantity()
        {
            return this.quantity;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void setExchangeRate(string exchangeRate)
        {
            this.exchangeRate = exchangeRate;
        }

        public void setCurrencyCode(string currencyCode)
        {
            this.currencyCode = currencyCode;
        }

        public void setQuantity(string quantity)
        {
            this.quantity = quantity;
        }

    }
}