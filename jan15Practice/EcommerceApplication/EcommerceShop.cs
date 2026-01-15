using System;

namespace EcommerceApplication
{
    /// <summary>
    /// Represents an e-commerce shop user with wallet balance and total purchase amount.
    /// </summary>
    public class EcommerceShop
    {
        public string UserName{get; set;}
        public double WalletBalance{get; set;}
        public double TotalPurchaseAmount{get; set;}
    }
}