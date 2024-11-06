using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace Kreata.Backend.Datas.Entities
{
    public class Order
    {
        public Order(Guid orderId, string buyername, DateTime createdAt, string deliverTo, string products)
        {
            OrderId = orderId;
            BuyerName = buyername;
            CreatedAt = createdAt;
            DeliverTo = deliverTo;
            Products = products;
        }

        public Order()
        {
            OrderId = Guid.Empty;
            BuyerName = String.Empty;
            CreatedAt = DateTime.Now;
            DeliverTo = string.Empty;
            Products = string.Empty;
        }

        public Guid OrderId { get; set; }
        public string BuyerName { get; set; }
        public DateTime CreatedAt {  get; set; }
        public string DeliverTo { get; set; }
        public string Products { get; set; }

        public override string ToString()
        {
            return $"Id: {OrderId},Vevő: {BuyerName}, Létrehozás {CreatedAt}, Kiszallítasi cím: {DeliverTo}, Rendelt termekek szama: {Products}";
        }
    }
}
