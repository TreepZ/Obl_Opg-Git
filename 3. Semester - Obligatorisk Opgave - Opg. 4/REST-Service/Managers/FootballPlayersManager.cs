using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Sharp_Unit_Test;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_Service.Managers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersManager : ControllerBase
    {
        private static int _nextID = 1;
        private static readonly List<Footballplayer> Data = new List<Footballplayer>
        {
            new Footballplayer {ID = _nextID++, _name = "Emil", Price =2,ShirtNum = 3},
            new Footballplayer {ID = _nextID++, _name = "Oliver", Price =3,ShirtNum = 4}
        };
        // GET: api/<FootballPlayersManager>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FootballPlayersManager>/5
        [HttpGet("{id}")]
        public List<Footballplayer> GetAll()
        {
            return new List<Footballplayer>(Data);
        }
        public Footballplayer GetByID(int id)
        {
            Footballplayer footballplayer = Data.Find(footballplayer => footballplayer.ID == id);

            if (footballplayer == null)
            {
                throw new ArgumentOutOfRangeException("Shirt Number not found");
            }
            return footballplayer;
        }

        // POST api/<FootballPlayersManager>
        [HttpPost]
        public Footballplayer Post([FromBody] Footballplayer footballplayer)
        {
            footballplayer.ID = _nextID++;
            Data.Add(footballplayer);
            return footballplayer;
        }

        // PUT api/<FootballPlayersManager>/5
        [HttpPut("{id}")]
        public Footballplayer Put(int id, [FromBody] Footballplayer value)
        {
            Footballplayer footballplayer = Data.Find(footballplayer1 => footballplayer1.ID == id);
            if (footballplayer == null) return null;
            footballplayer.Name = value.Name;
            footballplayer.Price = value.Price;
            footballplayer.ShirtNum = value.ShirtNum;
            return footballplayer;
        }

        // DELETE api/<FootballPlayersManager>/5
        [HttpDelete("{id}")]
        public Footballplayer Delete(int id)
        {
            Footballplayer footballplayer = Data.Find(footballplayer => footballplayer.ID == id);
            if (footballplayer == null) return null;
            Data.Remove(footballplayer);
            return footballplayer;
        }
    }
}
