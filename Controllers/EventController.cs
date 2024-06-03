using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMSwithREST.DataProvider;
using EMSwithREST.Models;

namespace EMSwithREST.Controllers
{
    [Route("[controller]")]
    public class EventController : Controller
    {
        private readonly IEventDataProvider eventDataProvider;

        public EventController(IEventDataProvider eventDataProvider)
        {
            this.eventDataProvider = eventDataProvider;
        }

        /// <summary>
        /// Gets all events.
        /// </summary>
        /// <returns>List of events</returns>
        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
        {
            return await this.eventDataProvider.GetEvents();
        }

        [HttpGet("{id}")]
        public async Task<Event> Get(int id)
        {
            return await this.eventDataProvider.GetEvent(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Event evt)
        {
            await this.eventDataProvider.AddEvent(evt);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Event evt)
        {
            await this.eventDataProvider.UpdateEvent(evt);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.eventDataProvider.DeleteEvent(id);
        }
    }
}