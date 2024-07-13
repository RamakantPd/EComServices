using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComServices.Repository.Implementation;

namespace EComServices.Repository.@interface
{
    public interface IMailRequestService
    {
        public Task<MailRequest> SendEMails(MailRequest req);
    }
}
