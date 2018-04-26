using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;

using MobileApps.MobileAppService.DataObjects;
using MobileApps.MobileAppService.Models;

namespace MobileApps.MobileAppService.Controllers
{
    // TODO: Uncomment [Authorize] attribute to require user be authenticated to access Item(s).
    // [Authorize]
    public class BoletaController : TableController<Boletas>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MasterDetailContext context = new MasterDetailContext();
            DomainManager = new EntityDomainManager<Boletas>(context, Request);
        }

        // GET tables/Item
        public IQueryable<Boletas> GetAllBoletas()
        {
            return Query();
        }

        // GET tables/Item/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Boletas> GetBoleta(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Item/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Boletas> PatchBoleta(string id, Delta<Boletas> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Item
        public async Task<IHttpActionResult> PostBoleta(Boletas boleta)
        {
            Boletas current = await InsertAsync(boleta);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Item/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteBoleta(string id)
        {
            return DeleteAsync(id);
        }
    }
}