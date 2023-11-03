using Api.Reservation.Business.Models;
using Api.Reservation.Datas.Entities;
using Api.Reservation.Datas.Repository;
using Api.Reservation.Generals.Common;
using Microsoft.VisualBasic;
using Refit;

namespace Api.Reservation.Business.Service
{
    public class ReservationService : IReservationService
    {
        /// <summary>
        /// Service de réservation qui gère les opérations de réservation de billets d'avion.
        /// </summary>
        public class ReservationService
        {
            /// <summary>
            /// Le référentiel de réservation.
            /// </summary>
            private readonly IReservationRepository _reservationRepository;

            /// <summary>
            /// Le référentiel d'utilisateur.
            /// </summary>
            private readonly IUtilisateurRepository _utilisateurRepository;

            /// <summary>
            /// L'API de vols.
            /// </summary>
            private readonly IFlightsApi _flightsApi;

            /// <summary>
            /// Initialise une nouvelle instance de la classe <see cref="ReservationService"/>.
            /// </summary>
            /// <param name="reservationRepository">Le référentiel de réservation.</param>
            /// <param name="utilisateurRepository">Le référentiel d'utilisateur.</param>
            /// <param name="flightsApi">L'API de vols.</param>
            public ReservationService(IReservationRepository reservationRepository, IUtilisateurRepository utilisateurRepository, IFlightsApi flightsApi)
            {
                _reservationRepository = reservationRepository;
                _utilisateurRepository = utilisateurRepository;
                _flightsApi = flightsApi;
            }

            /// <summary>
            /// Cette méthode permet de faire un appel Http vers l'API des vols pour
            /// récupérer les informations d'un siège.
            /// </summary>
            /// <param name="numeroVol">Le numéro du vol.</param>
            /// <param name="nomSiege">Le nom du siège.</param>
            /// <returns>Les informations du siège.</returns>
            public async Task<Seat> GetSiegeStatusAsync(string numeroVol, string nomSiege)
            {
                return await _flightsApi.GetSiegeStatusAsync(numeroVol, nomSiege)
                    .ConfigureAwait(false);
            }

            /// <summary>
            /// Cette méthode permet de faire un appel Http vers l'API des vols pour
            /// modifier les informations d'un siège.
            /// </summary>
            /// <param name="numeroVol">Le numéro du vol.</param>
            /// <param name="nomSiege">Le nom du siège.</param>
            /// <param name="status">Le nouvel état.</param>
            /// <returns>Les informations du siège.</returns>
            public async Task<Seat> SetSiegeStatusAsync(string numeroVol, string nomSiege, int status)
            {
                return await _flightsApi.SetSiegeStatusAsync(numeroVol, nomSiege, status)
                    .ConfigureAwait(false);
            }

            /// <summary>
            /// Crée une réservation de billet d'avion.
            /// </summary>
            /// <param name="reservation">La réservation à créer.</param>
            /// <returns>La réservation créée.</returns>
            /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'une reservation : Le siège n'est pas disponible.</exception>
            public async Task<Datas.Entities.Reservation> CreateReservationAsync(Datas.Entities.Reservation reservation)
            {
                // Vérifier l'existence de l'utilisateur, sinon lever une exception.
                var utilisateur = await _utilisateurRepository.GetUtilisateurByIdAsync(reservation.UtilisateurId);
                if (utilisateur == null)
                    throw new BusinessException("Echec de création d'une reservation : L'utilisateur n'éxiste pas.");

                var siegeStatus = await GetSiegeStatusAsync(reservation.NumeroVol, reservation.NumeroSiege);

                if (siegeStatus?.Status != "Disponible")
                    throw new BusinessException("Echec de création d'une reservation : Le siège n'est pas disponible.");

                // Le siège est disponible, procéder à la création de la réservation.
                return await _reservationRepository.CreateReservationAsync(reservation)
                    .ConfigureAwait(false);
            }

            /// <summary>
            /// Cette méthode permet de récupérer la liste des réservations.
            /// </summary>
            /// <returns>La liste des réservations.</returns>
            public async Task<List<Datas.Entities.Reservation>> GetReservationsAsync()
            {
                return await _reservationRepository.GetReservationsAsync()
                    .ConfigureAwait(false);
            }

            /// <summary>
            /// Récupère une liste de réservations pour un utilisateur donné.
            /// </summary>
            /// <param name="utilisateurID">L'ID de l'utilisateur pour lequel récupérer les réservations.</param>
            /// <returns>Une liste de réservations pour l'utilisateur donné.</returns>
            public async Task<List<Datas.Entities.Reservation>> GetReservationsByUtilisateurAsync(int utilisateurID)
            {
                return await _reservationRepository.GetReservationByUtilisateurIdAsync(utilisateurID)
                    .ConfigureAwait(false);
            }

            /// <summary>
            /// Supprime une réservation de billet d'avion.
            /// </summary>
            /// <param name="id">L'identifiant de la réservation à supprimer.</param>
            /// <returns>Une tâche qui représente l'opération asynchrone.</returns>
            public async Task DeleteReservationByIdAsync(int id)
            {
                var reservation = await _reservationRepository.GetReservationByIdAsync(id);
                if (reservation != null) {
                    await _reservationRepository.DeleteReservationAsync(id);
                    await _flightsApi.SetSiegeStatusAsync(reservation.NumeroVol, reservation.NumeroSiege, 1);
                }
            }
        }
    }
}
