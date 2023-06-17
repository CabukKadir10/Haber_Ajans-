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
        private readonly IEfSetting _efSetting;

        public SettingManager(IEfSetting efSetting)
        {
            _efSetting = efSetting;
        }

        public bool IsMaintenance(int settingId)
        {
            var result = _efSetting.Gett(p => p.Id == settingId);
            if(result.IsMaintenance ==false)
            {
                return false;
            }

            return true;
        }

        public void OnMaintenance(int settingId)
        {
            var result = _efSetting.Gett(p => p.Id == settingId);
            if (IsMaintenance(result.Id) == false)
            {
                result.IsMaintenance = true;
            }
        }

        public void OfMaintenance(int settingId)
        {
            var result = _efSetting.Gett(p => p.Id == settingId);
            if (IsMaintenance(result.Id) == true)
            {
                result.IsMaintenance = false;
            }
        }
    }
}
