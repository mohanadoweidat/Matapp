using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class AccountsController : ApiController
    {


        //Get Accounts
        public IEnumerable<Accounts> Get()
        {
            using (MSSQL600021Entities entities = new MSSQL600021Entities())
            {
                return entities.Accounts.ToList();
            }
        }


        //Get Accounts by Id
        public Accounts Get(int id)
        {
            using (MSSQL600021Entities entities = new MSSQL600021Entities())
            {
                return entities.Accounts.FirstOrDefault(e => e.ID == id);
            }
        }

        //Post Accounts

        public void Post([FromBody]Accounts accounts)
        {
            using (MSSQL600021Entities entities = new MSSQL600021Entities())
            {
                entities.Accounts.Add(accounts);
                entities.SaveChanges();
            }
        }

        //Delete Accounts
        public void Delete(int id)
        {
            using (MSSQL600021Entities entities = new MSSQL600021Entities())
            {
                entities.Accounts.Remove(entities.Accounts.FirstOrDefault(e => e.ID == id));
                entities.SaveChanges();
            }
        }


        //Update Accounts (Put)
        public void Put(int id, [FromBody] Accounts accounts)
        {
            using (MSSQL600021Entities entities = new MSSQL600021Entities())
            {
                var entity = entities.Accounts.FirstOrDefault(e => e.ID == id);

                entity.Username = accounts.Username;
                entity.Password = accounts.Password;
                entity.Attached = accounts.Attached;


                entities.SaveChanges();
            }
        }

    }
}
