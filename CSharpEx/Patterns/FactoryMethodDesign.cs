using System;

namespace FactoryMethodDesignPattern
{

    public interface CreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }

    public class MoneyBack : CreditCard
    {
        public string GetCardType()
        {
            return "MoneyBack";
        }
        public int GetCreditLimit()
        {
            return 15000;
        }
        public int GetAnnualCharge()
        {
            return 500;
        }
    }


    public class Titanium : CreditCard
    {
        public string GetCardType()
        {
            return "Titanium Edge";
        }
        public int GetCreditLimit()
        {
            return 25000;
        }
        public int GetAnnualCharge()
        {
            return 1500;
        }
    }

    public abstract class CreditCardFactory
    {
        protected abstract CreditCard MakeProduct();

        public CreditCard CreateProduct()
        {
            return this.MakeProduct();
        }
    }

    public class MoneyBackFactory : CreditCardFactory
    {
        // The signature of the method still uses the abstract product CreditCard type
        // Even though the concrete MoneyBack product is actually returned from the method.
        // This way the Creator can stay independent of concrete product classes.
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new MoneyBack();
            return product;
        }

        
    }


    public class TitaniumFactory : CreditCardFactory
    {
        // The signature of the method uses the abstract product CreditCard type,
        // Even though the concrete Titanium product is returned from the method.
        // This way the Abstract Creator CreditCardFactory can stay independent of concrete product classes.
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Titanium();
            return product;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // The client code works with an instance of a concrete creator
            // The CreateProduct will return the actual product instance via the product interface
            //PlatinumFactory CreateProduct method will return an instance of Platinum Product via the CreditCard interface
            CreditCard creditCard = new TitaniumFactory().CreateProduct();
            if (creditCard != null)
            {
                Console.WriteLine("Card Type : " + creditCard.GetCardType());
                Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
                Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.WriteLine("--------------");
            //MoneyBackFactory CreateProduct method will return an instance of Platinum Product via the CreditCard interface
            creditCard = new MoneyBackFactory().CreateProduct();
            if (creditCard != null)
            {
                Console.WriteLine("Card Type : " + creditCard.GetCardType());
                Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
                Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.ReadLine();
        }
    }





    }
