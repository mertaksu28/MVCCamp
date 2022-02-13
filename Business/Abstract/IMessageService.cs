using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll();
        List<Message> GetAllInbox();
        List<Message> GetAllSendbox();
        Message GetById(int id);
        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
    }
}
