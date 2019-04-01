using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ESPAPI.Models;

using ESPAPI.Repositories;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace ESPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimaryDataController : ControllerBase
    {
        //[HttpGet]
        //[Route("GetAdminList")]
        //public ActionResult<ContractorAdmin> GetAdminList()
        //{
        //    ContractorAdmin d = new ContractorAdmin();
        //    d.firstname = "sdsd";
        //    d.lastname = "hjj";
        //    return Ok(d);

        //}
        private IPrimaryDataRepository primarydata;

        public PrimaryDataController(espContext context)
        {
            primarydata = new PrimaryDataRepository(context);
        }

        [HttpGet]
        [Route("GetPrimaryDataList")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult GetPrimaryDataList()
        {
            //  return Ok(primarydata.GetPrimaryData());
            return Ok(primarydata.GetPrimaryDataList());

        }

        [HttpGet]
        [Route("GetPrimaryDataByID/{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult GetPrimaryDataByID(int id)
        {
            PrimaryData p = primarydata.GetPrimaryDataByID(id);
            if (p != null)
            {
                return Ok(p);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddUpdatePrimaryData")]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult AddUpdatePrimaryData()
        {
            PrimaryData p = JsonConvert.DeserializeObject<PrimaryData>(HttpContext.Request.Form["PrimaryData"]);
            int success;
            if (p.id != 0)
            {
                success = primarydata.UpdatePrimaryById(p.id, p);
                //int success = actors.UpdateActorByIdEntityState(id, actor);

                if (success == 1)
                {
                    return Ok(new { statusText = "Sucess" });
                }

            }
            else
            {
                success = primarydata.AddNewPrimaryData(p);
                if (success == 1)
                {

                    return Ok(new { statusText = "Sucess" });
                }

            }

            return Ok(new { statusText = "Fail" });
        }


       
        [HttpDelete]
        [EnableCors("AllowSpecificOrigin")]
        [Route("DeletePrimaryData/{id}")]
        public IActionResult DeletePrimaryData(int id)
        {
            int success = primarydata.DeletePrimaryDataById(id);

            if (success == 1)
            {
                return Ok();
            }

            return BadRequest();
        }


        //// GET api/actors
        //[HttpGet()]
        //public IActionResult Get()
        //{
        //    return Ok(primarydata.GetPrimaryData());
        //}

        //// GET api/actors/101
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    Actor actor = actors.GetActorById(id);
        //    if (actor != null)
        //    {
        //        return Ok(actor);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //// POST api/actors
        //[HttpPost]
        //public IActionResult Post([FromBody]Actor actor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    int success = actors.AddNewActor(actor);
        //    if (success == 1)
        //    {
        //        return Created("api/actors", actor);
        //    }
        //    return BadRequest();
        //}


        // POST api/actors
        //[EnableCors("AllowSpecificOrigin")]
        //[HttpPost]
        //public IActionResult Post([FromBody]PrimaryData p)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    int success = primarydata.AddNewPrimaryData(p);
        //    if (success == 1)
        //    {
        //        //return Created("api/actors", actor);
        //        return Ok();
        //    }
        //    return BadRequest();
        //}






        //// PUT api/actors
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody]Actor actor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    // int success = actors.UpdateActorById(id, actor);
        //    int success = actors.UpdateActorByIdEntityState(id, actor);

        //    if (success == 1)
        //    {
        //        return Ok();
        //    }

        //    return BadRequest();
        //}

        // DELETE api/actors
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    int success = actors.DeleteActorById(id);

        //    if (success == 1)
        //    {
        //        return Ok();
        //    }

        //    return BadRequest();
        //}


    }
}
