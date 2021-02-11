using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AboutMe.Domain.Abstract;
using AboutMe.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AboutMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutMeController : ControllerBase
    {
        #region Global Variables
        private readonly IAboutMeRepo _repo;
        #endregion

        #region Constructors
        public AboutMeController(IAboutMeRepo repo)
        {
            this._repo = repo;
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method returns the data about me from the repository.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<MyInfo>> GetAboutMe()
        {
            try
            {
                return await _repo.GetAboutMe();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}
