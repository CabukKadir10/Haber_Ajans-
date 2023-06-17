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
    

        public ServiceManager(IAuthService authService, INewsService newsService)
        {
            _authService = authService;
            _newsService = newsService;
           
        }

        public IAuthService AuthService => _authService;

        public INewsService NewsService => _newsService;

   
    }
}
