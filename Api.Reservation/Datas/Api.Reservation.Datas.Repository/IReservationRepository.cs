
using Api.Reservation.Datas.Entities;
/// <summary>
/// Cette interface définit le contrat pour un référentiel de réservation.
/// </summary>
public interface IReservationRepository
{
    /// <summary>
    /// Récupère une liste de toutes les réservations.
    /// </summary>
    /// <returns>Une liste de réservations.</returns>
    Task<List<Reservation>> GetReservationsAsync();

    /// <summary>
    /// Récupère une liste de réservations par numéro de vol.
    /// </summary>
    /// <param name="numeroVol">Le numéro de vol.</param>
    /// <returns>Une liste de réservations.</returns>
    Task<List<Reservation>> GetReservationsByNumeroVolAsync(string numeroVol);

    /// <summary>
    /// Récupère une liste de réservations par nom d'utilisateur.
    /// </summary>
    /// <param name="nomUtilisateur">Le nom d'utilisateur.</param>
    /// <returns>Une liste de réservations.</returns>
    Task<List<Reservation>> GetReservationsByUtilisateurAsync(string nomUtilisateur);

    /// <summary>
    /// Récupère une liste de réservations par ID d'utilisateur.
    /// </summary>
    /// <param name="idUtilisateur">L'ID d'utilisateur.</param>
    /// <returns>Une liste de réservations.</returns>
    Task<List<Reservation>> GetReservationByUtilisateurIdAsync(int idUtilisateur);

    /// <summary>
    /// Récupère une réservation par ID.
    /// </summary>
    /// <param name="id">L'ID de la réservation.</param>
    /// <returns>La réservation.</returns>
    Task<Reservation> GetReservationByIdAsync(int id);

    /// <summary>
    /// Crée une nouvelle réservation.
    /// </summary>
    /// <param name="reservation">Les informations de réservation.</param>
    /// <returns>La réservation créée.</returns>
    Task<Reservation> CreateReservationAsync(Reservation reservation);

    /// <summary>
    /// Met à jour une réservation.
    /// </summary>
    /// <param name="reservation">Les informations de réservation mises à jour.</param>
    Task UpdateReservation(Reservation reservation);

    /// <summary>
    /// Supprime une réservation.
    /// </summary>
    /// <param name="id">L'ID de la réservation.</param>
    Task DeleteReservationAsync(int id);
}