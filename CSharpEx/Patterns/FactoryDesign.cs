using System;

namespace FactoryDesign
{

    public interface CreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }

    public class MoneyBack : CreditCard
    {
        public int GetAnnualCharge()
        {
            return 100;
        }

        public string GetCardType()
        {
            Console.WriteLine("MoneyBack");
            return "MoneyBack";
            
        }

        public int GetCreditLimit()
        {
            return 1000;
        }
    }

    public class Plantinum : CreditCard
    {
        public int GetAnnualCharge()
        {
            return 200;
        }

        public string GetCardType()
        {
            Console.WriteLine("Plantinum");
            return "Plantinum";
        }

        public int GetCreditLimit()
        {
            return 2000;
        }
    }


    public class CreditCardFactory
    {
        public static CreditCard GetCreditCard(string cardType)
        {
            CreditCard cardDetails = null;

            if (cardType == "MoneyBack")
            {
                cardDetails = new MoneyBack();
            }

            else if (cardType == "Plantinum")
            {
                cardDetails = new Plantinum();
            }

            return cardDetails;
        }
    }


    class program
    {
        static void Main1()
        {



            #region Before Factory Design
            //string creditCardType = "MoneyBack";

            //CreditCard creditCard = null;

            //if (creditCardType == "MoneyBack")
            //    creditCard = new MoneyBack();

            //if (creditCardType == "Plantinum")
            //    creditCard = new Plantinum();

            //Console.WriteLine(creditCard.GetCreditLimit());
            //Console.WriteLine(creditCard.GetCardType()); 
            #endregion



            #region After Factory Design

            CreditCard cardDetails = CreditCardFactory.GetCreditCard("Plantinum");

            if (cardDetails != null)
            {
                Console.WriteLine("CardType : " + cardDetails.GetCardType());
                Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
                Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            } 

            #endregion

            Console.ReadLine();

        }
    }


   
        





}
