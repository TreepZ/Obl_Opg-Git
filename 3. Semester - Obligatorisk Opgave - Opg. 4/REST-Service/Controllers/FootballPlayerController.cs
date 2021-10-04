using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REST_Service.Managers;
using C_Sharp_Unit_Test;
using Microsoft.AspNetCore.Mvc;

namespace REST_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FootballPlayerController : ControllerBase
    {
        public readonly FootballPlayersManager footballPlayersManager = new FootballPlayersManager();
        [HttpGet("name/{substring}")]
        public IEnumerable<Footballplayer> Get([FromQuery] string substring)
        {
            return footballPlayersManager.GetAll();
        }
        [HttpGet("id/{substring}")]
        public Footballplayer GetByFootballplayerID(int substring)
        {
            Footballplayer footballplayer = footballPlayersManager.GetByID(substring);
            return footballplayer;
        }
        [HttpGet("{id}")]
        public Footballplayer Get(int id)
        {
            return footballPlayersManager.GetByID(id);
        }
        [HttpPost]
        public Footballplayer Post([FromBody] Footballplayer value)
        {
            return footballPlayersManager.Post(value);
        }
        [HttpPut("{id}")]
        public Footballplayer Put(int id, [FromBody] Footballplayer value)
        {
            return footballPlayersManager.Put(id, value);
        }
        [HttpDelete("{id}")]
        public Footballplayer Delete(int id)
        {
            return footballPlayersManager.Delete(id);
        }

        
    }
}
