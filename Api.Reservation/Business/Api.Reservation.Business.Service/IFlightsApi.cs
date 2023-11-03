using Api.Reservation.Business.Models;
using Refit;

namespace Api.Reservation.Business.Service
{
    public interface IFlightsApi
    {
        [Get("/api/Flights/{numeroVol}/siege/{nomSiege}")]
        Task<Seat> GetSiegeStatusAsync(string numeroVol, string nomSiege);

        [Put("/api/Flights/{numeroVol}/siege/{nomSiege}")]
        Task<Seat> SetSiegeStatusAsync(string numeroVol, string nomSiege, int status);
    }
}
