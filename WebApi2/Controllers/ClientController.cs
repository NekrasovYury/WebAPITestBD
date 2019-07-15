using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    
    public class ClientController : ApiController
    {
       public List<Client> clients = new List<Client>
            {
                { new Client { ClientID = 1, ClientName = "Sergey"} },
                {new Client { ClientID = 2, ClientName = "Yura"  } },
                {new Client { ClientID = 3, ClientName = "Pavel" } },
                {new Client { ClientID = 4, ClientName = "Sanya" } },
                { new Client { ClientID = 5, ClientName = "Leha" } }
            };

      public  List<Card> cards = new List<Card>
        {
            
                { new Card { CardID = 12391283 , OwnreID = 1, CardValue = 4000  } },
                { new Card {CardID = 4939182 , OwnreID = 1, CardValue = 2040  } },
                { new Card {CardID = 38491982 , OwnreID = 2, CardValue = 3100  } },
                { new Card{ CardID = 4899182 , OwnreID = 3, CardValue = 4000  } },
                { new Card {CardID = 4892918 , OwnreID = 3, CardValue = 5500  } },
                { new Card{ CardID = 4899182 , OwnreID = 4, CardValue = 4020  } },
                { new Card {CardID = 4892918 , OwnreID = 5, CardValue = 5001  } }

        };
        // GET: api/Client
        public List<Client> Get()
        {
            return clients;
        }

        // GET: api/Client/5
        //[HttpGet]
        //public List<Client> Get(int Id)
        //{
        //    string v = clients[Id].ClientName;

        //    return v;
        //}

        // POST: api/Client
        public void Post([FromBody]Client data)
        {
            var newClientId = clients.Count() + 1;
            clients.Add(new Client { ClientID = newClientId, ClientName = data.ClientName });
            var newCardId = cards.Count()+1;
            cards.Add(new Card { CardID = newCardId, OwnreID = newClientId, CardValue = 0 });
        }

        public void PostCard([FromBody]Card data)
        {
            cards.Add(new Card { CardID = data.CardID, OwnreID = data.OwnreID, CardValue = data.CardValue });
        }
        // PUT: api/Client/5
        public void Put(int id, [FromBody]Card data)
        {
            cards.Add(new Card { CardID = data.CardID, OwnreID = data.OwnreID, CardValue = data.CardValue });
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
           
            clients.RemoveAt(id);
            cards.RemoveAt(id);
        }
    }
}
