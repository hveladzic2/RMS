using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RMSLibrary.Models.DBModel;

namespace Recruitment_Management_System.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> UpdateAdminProfileAsync(ProfilAdministratora profile, string currentUserId);
        Task<bool> UpdateCompanyProfileAsync(ProfilKompanije profile, string currentUserId);

    }
}
