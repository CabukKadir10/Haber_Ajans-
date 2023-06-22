using DataAccess.Abstract;
using Entity.Concrete;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class SettingManager : ISettingService
    {
        private readonly IRepositoryManager _repositoryManager;
        public SettingManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public bool IsMaintenance(int settingId)
        {
            var result = _repositoryManager.EfSetting.Gett(p => p.Id == settingId);
            if(result.IsMaintenance ==false)
            {
                return false;
            }

            return true;
        }

        public void OnMaintenance(int settingId)
        {
            var result = _repositoryManager.EfSetting.Gett(p => p.Id == settingId);
            if (IsMaintenance(result.Id) == false)
            {
                result.IsMaintenance = true;
            }
        }

        public void OfMaintenance(int settingId)
        {
            var result = _repositoryManager.EfSetting.Gett(p => p.Id == settingId);
            if (IsMaintenance(result.Id) == true)
            {
                result.IsMaintenance = false;
            }
        }
    }
}
