using CoffeeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeWebsite.Business
{
    public class CartService
    {
        private static CartService instance;

        public static CartService Instance
        {
            get { if (instance == null) instance = new CartService(); return instance; }
            private set => instance = value;
        }

        public bool Payment(CartModel model)
        {
            using(var db = new BaristasEntities())
            {             
                Bill bill = new Bill
                {
                    PaymentID = model.PaymentId,
                    AccountID = model.Account.AccountID,
                    CreatedDate = DateTime.Now,
                    CustomerName = model.CustomerName,
                    ShippingAddress = model.Address,
                    Noted = model.Note,
                    CustomerPhoneNumber = model.Phone,
                    TotalDiscount = (decimal)model.TotalFinal,
                    IsPaid = false,
                    Total = (decimal)model.TotalCart
                };

                if (model.DiscountCode != null)
                {
                    bill.Discount = ShareService.Instance.GetDiscountByCode(model.DiscountCode).DiscountPercent;
                }

                db.Bills.Add(bill);

                if (db.SaveChanges() > 0)
                {
                    int billId = bill.BillID;

                    List<BillDetail> billDetails = new List<BillDetail>();
                    
                    foreach(var cartItem in model.CartItems)
                    {
                        BillDetail billDetail = new BillDetail
                        {
                            BillID = billId,
                            ProductID = cartItem.Product.ProductID,
                            Quantity = cartItem.Quantity
                        };

                        billDetails.Add(billDetail);
                    }

                    db.BillDetails.AddRange(billDetails);

                    int result = db.SaveChanges();

                    if (result > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}