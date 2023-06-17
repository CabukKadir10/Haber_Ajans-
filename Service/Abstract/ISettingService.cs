using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface ISettingService
    {
        bool IsMaintenance(int settingId);
        void OnMaintenance(int settingId);
        void OfMaintenance(int settingId);
    }
}
