using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ImagesController : ApiController
    {

        //Get Images
        public IEnumerable<Images> Get()
        {
            using (MSSQL600021Entities entities = new MSSQL600021Entities())
            {
                return entities.Images.ToList();
            }
        }


        //Get Images by Id
        public Images Get(int id)
        {
            using (MSSQL600021Entities entities = new MSSQL600021Entities())
            {
                return entities.Images.FirstOrDefault(e => e.ID == id);
            }
        }


        //Post Images
        public void Post([FromBody]Images imag)
        {
            using (MSSQL600021Entities entities = new MSSQL600021Entities())
            {
                entities.Images.Add(imag);
                entities.SaveChanges();
            }
        }


        //Delete Images
        public void Delete(int id)
        {
            using (MSSQL600021Entities entities = new MSSQL600021Entities())
            {
                entities.Images.Remove(entities.Images.FirstOrDefault(e => e.ID == id));
                entities.SaveChanges();
            }
        }

        //Update Images (Put)
        public void Put(int id, [FromBody] Images img)
        {
            using (MSSQL600021Entities entities = new MSSQL600021Entities())
            {
                var entity = entities.Images.FirstOrDefault(e => e.ID == id);

                entity.ID = img.ID;
                entity.Data = img.Data;
                entities.SaveChanges();
            }
        }
    }
}
