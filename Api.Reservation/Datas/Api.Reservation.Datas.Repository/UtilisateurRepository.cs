using Api.Reservation.Datas.Context;
using Api.Reservation.Datas.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Classe de repository pour la gestion des opérations CRUD sur les entités Utilisateur.
/// </summary>
namespace Api.Reservation.Datas.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ReservationRepository"/>.
        /// </summary>
        /// <param name="context">Le contexte.</param>
        public UtilisateurRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crée un nouvel utilisateur de manière asynchrone.
        /// </summary>
        /// <param name="utilisateur">L'utilisateur à créer.</param>
        /// <returns>L'utilisateur créé.</returns>
        public async Task<Utilisateur> CreateUtilisateurAsync(Utilisateur utilisateur)

        /// <summary>
        /// Supprime un utilisateur de manière asynchrone.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur à supprimer.</param>
        public async Task DeleteUtilisateurAsync(int id)

        /// <summary>
        /// Obtient un utilisateur par son identifiant de manière asynchrone.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur à obtenir.</param>
        /// <returns>L'utilisateur correspondant à l'identifiant spécifié.</returns>
        public async Task<Utilisateur> GetUtilisateurByIdAsync(int id)

        /// <summary>
        /// Obtient une liste d'utilisateurs de manière asynchrone.
        /// </summary>
        /// <returns>Une liste d'utilisateurs.</returns>
        public async Task<List<Utilisateur>> GetUtilisateursAsync()

        /// <summary>
        /// Obtient un utilisateur par sa réservation de manière asynchrone.
        /// </summary>
        /// <param name="reservation">La réservation de l'utilisateur à obtenir.</param>
        /// <returns>L'utilisateur correspondant à la réservation spécifiée.</returns>
        public async Task<Utilisateur> GetUtilisateurByReservationAsync(Entities.Reservation reservation)

        /// <summary>
        /// Met à jour un utilisateur de manière asynchrone.
        /// </summary>
        /// <param name="utilisateur">L'utilisateur à mettre à jour.</param>
        public async Task UpdateUtilisateur(Utilisateur utilisateur)

        /// <summary>
        /// Obtient un utilisateur par son adresse e-mail de manière asynchrone.
        /// </summary>
        /// <param name="email">L'adresse e-mail de l'utilisateur à obtenir.</param>
        /// <returns>L'utilisateur correspondant à l'adresse e-mail spécifiée.</returns>
        public async Task<Utilisateur> GetUtilisateurByEMailAsync(string email)

        /// <summary>
        /// Met à jour un utilisateur par son identifiant de manière asynchrone.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur à mettre à jour.</param>
        /// <param name="utilisateurMaj">Les nouvelles informations de l'utilisateur.</param>
        /// <returns>L'utilisateur mis à jour.</returns>
        public async Task<Utilisateur> UpdateUserByIdAsync(int id, Utilisateur utilisateurMaj)

    }
}
