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
    public class SecondaryDataController : ControllerBase
    {
        private ISecondaryDataRepository secondarydata;

        public SecondaryDataController(espContext context)
        {
            secondarydata = new SecondaryDataRepository(context);
            
        }

        [HttpGet]
        [Route("GetSecondaryDataList")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult GetSecondaryDataList()
        {
            return Ok(secondarydata.GetSecondaryDataList());
        }

        [HttpGet]
        [Route("GetSecondaryDataByID/{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult GetSecondaryDataByID(int id)
        {
            SecondaryDesignData p = secondarydata.GetSecondaryDataByID(id);
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
        [Route("AddUpdateSecondaryData")]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult AddUpdateSecondaryData()
        {
            SecondaryDesignData p = JsonConvert.DeserializeObject<SecondaryDesignData>(HttpContext.Request.Form["SecondaryDesignData"]);
            int success;
            if (p.id != 0)
            {
                success = secondarydata.UpdateSecondaryById(p.id, p);
              
                if (success == 1)
                {
                    return Ok(new { statusText = "Sucess" });
                }

            }
            else
            {
                success = secondarydata.AddNewSecondaryData(p);
                if (success == 1)
                {

                    return Ok(new { statusText = "Sucess" });
                }

            }

            return Ok(new { statusText = "Fail" });
        }



        [HttpDelete]
        [EnableCors("AllowSpecificOrigin")]
        [Route("DeleteSecondaryData/{id}")]
        public IActionResult DeleteSecondaryData(int id)
        {
            int success = secondarydata.DeleteSecondaryDataById(id);

            if (success == 1)
            {
                return Ok();
            }

            return BadRequest();
        }


        [HttpPost]
        [Route("AddUpdateSecondaryOperatingData")]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult AddUpdateSecondaryOperatingData()
        {
            SecondaryOperatingData p = JsonConvert.DeserializeObject<SecondaryOperatingData>(HttpContext.Request.Form["SecondaryOperatingData"]);
            int success;
            success = secondarydata.AddNewSecondaryOperatingData(p);
            if (success == 1)
            {

                return Ok(new { statusText = "Sucess" });
            }
            //if (p.id != 0)
            //{
            //    success = secondarydata.AddNewSecondaryData(p.id, p);

            //    if (success == 1)
            //    {
            //        return Ok(new { statusText = "Sucess" });
            //    }

            //}
            //else
            //{
            //    success = secondarydata.AddNewSecondaryData(p);
            //    if (success == 1)
            //    {

            //        return Ok(new { statusText = "Sucess" });
            //    }

            //}

            return Ok(new { statusText = "Fail" });
        }



    }
}