using Api.Reservation.Business.Models;
using Api.Reservation.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Reservation.Business.Service
{
    public interface IUtilisateurService
    {

        /// <summary>
        /// Creates user asynchronously.
        /// </summary>
        /// <param name="utilisateur">L'utilisateur.</param>
        /// <returns></returns>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'un utilisateur : L'adresse email est déjà utilisée.</exception>
        Task<Datas.Entities.Utilisateur> CreateUtilisateurAsync(Datas.Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        Task<List<Datas.Entities.Utilisateur>> GetUtilisateursAsync();
        Task<Datas.Entities.Utilisateur> GetUtilisateurByIdAsync(int id);
        Task<Datas.Entities.Utilisateur> UpdateUtilisateurAsync(int id, Utilisateur utilisateur);
        Task DeleteUtilisateurAsync(int id);
    }
}
