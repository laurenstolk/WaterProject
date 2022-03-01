using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WaterProject.Infrastructure;

namespace WaterProject.Models
{
    public class SessionBasket : Basket
    {

        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;

        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Project Proj, int qty)
        {
            base.AddItem(Proj, qty);

            Session.SetJson("Basket", this);

        }

        public override void RemoveItem(Project proj)
        {
            base.RemoveItem(proj);

            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();

            Session.Remove("Basket");
        }

    }
}
