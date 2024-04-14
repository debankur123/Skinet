using API.Errors;
using Infrasturucture.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BugsController : BaseApiController
    {
        public StoreContext StoreContext { get; }
        public BugsController(StoreContext storeContext)
        {
            this.StoreContext = storeContext;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest(){
            var thing = this.StoreContext.Products.Find(42);
            if(thing == null)
                return NotFound(new ApiResponse(404));
            return Ok();
        }
        [HttpGet("servererror")]
        public IActionResult GetServerError(){
            var thing = this.StoreContext.Products.Find(42);
            var thingToReturn = thing.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]
        public IActionResult GetBadRequest(){
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public IActionResult GetNotFoundRequest(int id){
            return Ok();
        }
    }
}