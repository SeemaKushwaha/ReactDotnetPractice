using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    [ApiController]
    [Route("/api/[controller]")]
    public class ActivitiesController: BaseApiController
    {
        private readonly DataContext _dataContext;
        public ActivitiesController(DataContext dataContext){
            _dataContext = dataContext;
         
        }

        [HttpGet("{id}")] //api/activities/1
        public async Task<ActionResult<Activity>> GetActivity(Guid id){
            return Ok( await _dataContext.Activities.FindAsync(id));
        }

        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _dataContext.Activities.ToListAsync();
        }
    }
