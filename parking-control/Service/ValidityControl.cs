﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace parking_control.Service
{
    public class ValidityDateControl
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public double HourPrice { get; set; }

        public ValidityDateControl(double price, DateTime InitialDate, DateTime FinalDate)
        {
            this.HourPrice = price;
            this.InitialDate = InitialDate;
            this.FinalDate = FinalDate;
        }
    }

    public class ValidityControl
    {
        private static List<ValidityDateControl> listDates = new List<ValidityDateControl>();

        public static void AddDateControl(double price, DateTime initialDateControl, DateTime finalDateControl)
        {
            ValidityDateControl validityDateControl = new ValidityDateControl(price, initialDateControl, finalDateControl);
            listDates.Add(validityDateControl);            
        }

        public static List<ValidityDateControl> GetListDates()
        {
            return listDates;
        }

        public static double GetPriceByDate(DateTime dateTime)
        {
            ValidityDateControl filtered = listDates.Where((ValidityDateControl vdc) => { return dateTime >= vdc.InitialDate; }).First();            
            return filtered.HourPrice;
        }
    }
}