
using Api.Reservation.Datas.Entities;
using Api.Reservation.Datas.Repository;
using Api.Reservation.Generals.Common;

namespace Api.Reservation.Business.Service
{
    /// <summary>
    /// Service pour la gestion des utilisateurs.
    /// </summary>
    public class UtilisateurService : IUtilisateurService
    {
        /// <summary>
        /// Le repository des utilisateurs.
        /// </summary>
        private readonly IUtilisateurRepository _utilisateurRepository;

        public UtilisateurService(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }

        /// <summary>
        /// Crée un nouvel utilisateur.
        /// </summary>
        /// <param name="utilisateur">L'utilisateur à créer.</param>
        /// <returns>L'utilisateur créé.</returns>
        public async Task<Datas.Entities.Utilisateur> CreateUtilisateurAsync(Utilisateur utilisateur)
        {
            Utilisateur _utilisateur = await _utilisateurRepository.GetUtilisateurByEMailAsync(utilisateur.Email);

            if (_utilisateur != null)
                throw new BusinessException("Echec de création d'un utilisateur : L'adresse email est déjà utilisée.");

            return await _utilisateurRepository.CreateUtilisateurAsync(utilisateur);
        }

        /// <summary>
        /// Met à jour un utilisateur existant.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur à mettre à jour.</param>
        /// <param name="utilisateur">Les nouvelles informations de l'utilisateur.</param>
        /// <returns>L'utilisateur mis à jour.</returns>
        public async Task<Datas.Entities.Utilisateur> UpdateUtilisateurAsync(int id, Utilisateur utilisateur)
        {
            Utilisateur _utilisateur = await _utilisateurRepository.GetUtilisateurByEMailAsync(utilisateur.Email) ?? throw new BusinessException("Echec de la modification d'un utilisateur : Aucun utilisateur ne possède l'identifiant " + utilisateur.Id);
            if (_utilisateur != null && utilisateur.Id != id)
                throw new BusinessException("Echec de création d'un utilisateur : L'adresse email est déjà utilisée.");

            return await _utilisateurRepository.UpdateUserByIdAsync(_utilisateur.Id, utilisateur);
        }

        /// <summary>
        /// Récupère la liste de tous les utilisateurs.
        /// </summary>
        /// <returns>La liste de tous les utilisateurs.</returns>
        public async Task<List<Utilisateur>> GetUtilisateursAsync()
        {
            return await _utilisateurRepository.GetUtilisateursAsync();
        }

        /// <summary>
        /// Récupère un utilisateur par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur à récupérer.</param>
        /// <returns>L'utilisateur correspondant à l'identifiant.</returns>
        public async Task<Utilisateur> GetUtilisateurByIdAsync(int id)
        {
            return await _utilisateurRepository.GetUtilisateurByIdAsync(id);
        }

        /// <summary>
        /// Supprime un utilisateur existant.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur à supprimer.</param>
        public async Task DeleteUtilisateurAsync(int id)
        {
            await _utilisateurRepository.DeleteUtilisateurAsync(id);
        }
    }
}
