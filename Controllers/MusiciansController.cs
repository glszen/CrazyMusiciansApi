using CrazyMusiciansApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusiciansApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusiciansController : ControllerBase
    {

        private static List<Musicians> _musicians = new List<Musicians>() //Random Data
        {
            new Musicians{ID = 1, Name = "Ahmet Çalgı", Profession = "Ünlü Çalgı Çalar", FunFeature = "Her zaman yanlış nota çalar, ama çok eğlenceli."},
            new Musicians{ID = 2, Name = "Zeynep Melodi", Profession = "Popüler Melodi Yazarı", FunFeature = "Şarkıları yanlış anlaşılır ama çok popüler."},
            new Musicians{ID = 3, Name = "Cemil Akor", Profession = "Çılgın Akorist", FunFeature = "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli."},
            new Musicians{ID = 4, Name = "Fatma Nota", Profession = "Sürpriz Nota Üreticisi", FunFeature = "Nota üretirken sürekli sürprizler hazırlar."},
            new Musicians{ID = 5, Name = "Hasan Ritim", Profession = "Ritim Canavarı", FunFeature = "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir."},
            new Musicians{ID = 6, Name = "Elif Armoni", Profession = "Armoni Ustası", FunFeature = "Armonilerini bazen yanlış çalar, ama çok yaratıcıdır."},
            new Musicians{ID = 7, Name = "Ali Perde", Profession = "Perde Uygulayıcı", FunFeature = "Her perdeyi farklı şekilde çalar, her zaman sürprizlidir."},
            new Musicians{ID = 8, Name = "Ayşe Rezonans", Profession = "Rezonans Uzmanı", FunFeature = "Rezonans konusunda uzman, ama bazen çok gurultu çıkarır."},
            new Musicians{ID = 9, Name = "Murat Ton", Profession = "Tonlama Meraklısı", FunFeature = "Tonlamalarındaki farklılıklar bazen komik, ama oldukça ilginç."},
            new Musicians{ID = 10, Name = "Selin Akor", Profession = "Akor Sihirbazı", FunFeature = "Akorları değiştirdiğinde bazen sihirli bir hava yaratır."}

        };

        [HttpGet]
        public IEnumerable<Musicians> Get()
        {
            return _musicians;
        }

        [HttpGet("{id:int:min(1)}", Name = "GetMusicianById")]
        public IActionResult Get(int id) //For read
        {
            var musician = _musicians.FirstOrDefault(x => x.ID == id);
            if (musician == null)
            {
                return NotFound();
            }
            return Ok(musician);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Musicians musicians) //For create
        {
            var id = _musicians.Max(x => x.ID) + 1;
            musicians.ID = id;
            _musicians.Add(musicians);
            return CreatedAtRoute("GetMusicianById", new { id = musicians.ID, name = musicians.Name, profession = musicians.Profession, funFeature = musicians.FunFeature });
        }

        [HttpPut("settings/{id:int:min(1)}")]
        public IActionResult Put(int id, [FromBody] Musicians musicians) //For update
        {

            if (musicians == null || id != musicians.ID)
            {
                return BadRequest();
            }

            var existingMusician = _musicians.FirstOrDefault(x => x.ID == id);

            if (existingMusician is null)
            {
                return NotFound();
            }

            existingMusician.Name = musicians.Name;
            existingMusician.Profession = musicians.Profession;
            existingMusician.FunFeature = musicians.FunFeature;

            return Ok(existingMusician);
        }

        [HttpDelete("delete/{id:int:min(1)}")]
        public IActionResult Delete(int id)
        { //Fot delete

            var existingMusician = _musicians.FirstOrDefault(y => y.ID == id);

            if (existingMusician is null)
            {
                return NotFound();
            }
            _musicians.Remove(existingMusician);

            return NoContent();
        }

        [HttpGet("search/{keyword:alpha}")] //Only contain alphabethic character.
        public IActionResult Search(string keyword)
        {
            return Search(keyword);
        }

        [HttpPatch("reprofession/{id:int:min(1)}/{newProfession}/")] //For update only profession part.
        public IActionResult ReprofessionMusician(int id, string newProfession, [FromBody] JsonPatchDocument<Musicians> patchDocument)
        {
            var existingMusician = _musicians.FirstOrDefault(r => r.ID == id);
            if (existingMusician is null)
            {
                return NotFound($"Musician {id} not found.");
            }

            existingMusician.Profession = newProfession;
            patchDocument.ApplyTo(existingMusician);

            return NoContent();

        }
    }
}
