using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
        INewsService NewsService { get; }
        IMailSenderService MailSenderService { get; }
        ISettingService SettingService { get; }
        IUserService UserService { get; }
   
    }
}
