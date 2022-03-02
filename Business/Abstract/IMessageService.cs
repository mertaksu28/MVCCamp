using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll();
        List<Message> GetAllInbox(string email);
        List<Message> GetAllSendbox(string email);
        Message GetById(int id);
        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
    }
}
