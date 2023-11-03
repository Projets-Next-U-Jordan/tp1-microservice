using Api.Vols.Datas.Entities;
using LiteDB;

namespace Api.Vols.Datas.Repository
{
    public interface IFlightRepository
    {
        /// <summary>
        /// Cette méthode permet de créer un vol
        /// </summary>
        /// <param name="flight">les informations du vol</param>
        /// <returns></returns>
        Flight CreateFlight(Flight flight);

        /// <summary>
        /// Cette méthode permet de recupérer la liste des vols
        /// </summary>
        /// <returns></returns>
        List<Flight> GetFlights();

        /// <summary>
        /// Cette méthode permet de recupérer les informations d'un vol par son identifiant
        /// </summary>
        /// <param name="id">L'identifiant du vol</param>
        /// <returns></returns>
        Flight GetFlightById(ObjectId id);

        /// <summary>
        /// Cette méthode permet de mettre à jour les informations d'un vol
        /// </summary>
        /// <param name="flight">les nouvelles données du vol</param>
        /// <returns></returns>
        Flight UpdateFlight(Flight flight);

        /// <summary>
        /// Cette méthode de supprimer un vol
        /// </summary>
        /// <param name="id">L'identifiant du vol</param>
        /// <returns></returns>
        bool DeleteFlight(ObjectId id);

        /// <summary>
        /// Cette méthode permet de recupérer les informations d'un siege d'un vol
        /// </summary>
        /// <param name="numeroVol">Le numéro du vol.</param>
        /// <param name="nomSiege">Le nom du siege.</param>
        /// <returns></returns>
        Seat? GetSeatStatus(string numeroVol, string nomSiege);
        Seat? SetSeatStatus(string numeroVol, string nomSiege, string status);
    }
}
