
using Api.Reservation.Datas.Entities;

namespace Api.Reservation.Datas.Repository
{
    public interface IUtilisateurRepository
    {
        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        Task<List<Entities.Utilisateur>> GetUtilisateursAsync();

        /// <summary>
        /// Cette méthode permet de recupérer un utilisateur par son email
        /// </summary>
        /// <param name="email">l'email.</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> GetUtilisateurByEMailAsync(string email);

        /// <summary>
        /// Cette méthode permet de recupérer un utilisateur par sa reservation
        /// </summary>
        /// <param name="reservation">la reservation.</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> GetUtilisateurByReservationAsync(Entities.Reservation reservation);

        /// <summary>
        /// Cette méthode permet de recupérer les informations d'un utilisateur par son identifiant
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> GetUtilisateurByIdAsync(int id);

        /// <summary>
        /// Cette methode permet de créer un nouvel utilisateur.
        /// </summary>
        /// <param name="utilisateur">Les informations du nouvel utilisateur</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> CreateUtilisateurAsync(Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de mettre à jour les informations d'un utilisateur
        /// </summary>
        /// <param name="utilisateur">les informations modifié d'un utilisateur.</param>
        Task UpdateUtilisateur(Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur</param>
        Task DeleteUtilisateurAsync(int id);

        /// <summary>
        /// Cette méthode permet de mettre a jour un utilisateur
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur</param>
        /// <param name="utilisateurMaj">Les nouvelles informations de l'utilisateur</param>
        Task<Utilisateur> UpdateUserByIdAsync(int id, Utilisateur utilisateurMaj);
    }
}
