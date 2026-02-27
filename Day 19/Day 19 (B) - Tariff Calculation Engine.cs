using System;
using System.Collections.Generic;

namespace ConsoleApp19Exer
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }

        protected UtilityBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit)
        {
            ConsumerId = consumerId;
            ConsumerName = consumerName;
            UnitsConsumed = unitsConsumed;
            RatePerUnit = ratePerUnit;
        }

        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax(decimal billAmount)
        {
            return 0.05m * billAmount;
        }

        public string PrintBill()
        {
            decimal billAmount = CalculateBillAmount();
            decimal tax = CalculateTax(billAmount);
            return $"Consumer Id : {ConsumerId}\n" +
                   $"Consumer Name : {ConsumerName}\n" +
                   $"Units Consumed : {UnitsConsumed}\n" +
                   $"Rate Per Unit : {RatePerUnit}\n" +
                   $"Payable Amount : {billAmount+tax}";
        }
    }

    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit)
            : base(consumerId, consumerName, unitsConsumed, ratePerUnit) { }

        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            decimal surcharge = 0;
            if (UnitsConsumed > 300) surcharge = 0.1m * billAmount;
            decimal tax = CalculateTax(billAmount);

            return billAmount + surcharge;
        }
    }

    class WaterBill : UtilityBill
    {
        public WaterBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit)
            : base(consumerId, consumerName, unitsConsumed, ratePerUnit) { }
        public override decimal CalculateTax(decimal billAmount)
        {
            return 0.02m * billAmount;
        }

        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            return billAmount;
        }
    }

    class GasBill : UtilityBill
    {
        public GasBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit)
            : base(consumerId, consumerName, unitsConsumed, ratePerUnit) { }

        public override decimal CalculateTax(decimal billAmount)
        {
            return 0;
        }

        public override decimal CalculateBillAmount()
        {
            decimal billAmount = 150 + (UnitsConsumed * RatePerUnit);
            return billAmount;
        }
    }

    internal class Tariff_Calculation_Engine
    {
        static void Main(string[] args)
        {
            ElectricityBill ebill = new ElectricityBill(101, "ABC", 350, 10);
            WaterBill wbill = new WaterBill(102, "DEF", 100, 10);
            GasBill gbill = new GasBill(103, "GHI", 200, 5);
            List<UtilityBill> bills = new List<UtilityBill>(3);
            bills.Add(ebill);
            bills.Add(wbill);
            bills.Add(gbill);
            foreach (var item in bills)
            {
                item.CalculateBillAmount();
                Console.WriteLine(item.PrintBill());
                Console.WriteLine();
            }
        }
    }
}