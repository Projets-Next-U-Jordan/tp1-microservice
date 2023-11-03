using Api.Reservation.Business.Models;
using Api.Reservation.Business.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {

        private readonly IUtilisateurService _utilisateurService;
        private readonly IReservationService _reservationService;

        public UtilisateursController(IUtilisateurService utilisateurService, IReservationService reservationService)
        {
            _utilisateurService = utilisateurService;
            _reservationService = reservationService;
        }

        // GET: api/<UtilisateursController>
        [HttpGet]
        [ProducesResponseType(typeof(List<Datas.Entities.Utilisateur>), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _utilisateurService.GetUtilisateursAsync());
        }

        // GET api/<UtilisateursController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Datas.Entities.Utilisateur), 200)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _utilisateurService.GetUtilisateurByIdAsync(id));
        }

        // POST api/<UtilisateursController>
        [HttpPost]
        [ProducesResponseType(typeof(Datas.Entities.Utilisateur), 200)]
        public async Task<IActionResult> Post([FromBody] CreateUtilisateurDto value) {
            try {
                var userToCreate = new Datas.Entities.Utilisateur() {
                    Nom = value.Nom,
                    Prenom = value.Prenom,
                    Email = value.Email,
                    DateNaissance = value.DateNaissance
                };

                return Ok(await _utilisateurService.CreateUtilisateurAsync(userToCreate));
            } catch (Exception e) { return Problem(e.Message, e.StackTrace); }
        }

        // PUT api/<UtilisateursController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Datas.Entities.Utilisateur), 200)]
        public void Put(int id, [FromBody] CreateUtilisateurDto value)
        {
            var userToUpdate = new Datas.Entities.Utilisateur()
            {
                Nom = value.Nom,
                Prenom = value.Prenom,
                Email = value.Email,
                DateNaissance = value.DateNaissance
            };
            _utilisateurService.UpdateUtilisateurAsync(id, userToUpdate);
        }

        // DELETE api/<UtilisateursController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var usersReservations = await _reservationService.GetReservationsByUtilisateurAsync(id);
            if (usersReservations.Count > 0)
            {
                foreach (var reservation in usersReservations)
                {
                    await _reservationService.DeleteReservationByIdAsync(reservation.Id);
                }
            }
            await _utilisateurService.DeleteUtilisateurAsync(id);
        }
    }
}
