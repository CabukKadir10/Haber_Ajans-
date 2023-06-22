using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthService _authService;
        private readonly INewsService _newsService;
        private readonly IMailSenderService _mailSenderService;
        private readonly ISettingService _settingService;
        private readonly IUserService _userService;

        public ServiceManager(IAuthService authService, INewsService newsService, IMailSenderService mailSenderService, ISettingService settingService, IUserService userService)
        {
            _authService = authService;
            _newsService = newsService;
            _mailSenderService = mailSenderService;
            _settingService = settingService;
            _userService = userService;
        }

        public IAuthService AuthService => _authService;

        public INewsService NewsService => _newsService;

        public IMailSenderService MailSenderService => _mailSenderService;

        public ISettingService SettingService => _settingService;

        public IUserService UserService => _userService;
    }
}
