using AboutMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AboutMe.Domain.Abstract
{
    public interface IAboutMeRepo
    {
        #region Abstract Methods
        Task<MyInfo> GetAboutMe(); 
        #endregion
    }
}
