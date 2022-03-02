using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message> GetAllInbox(string email)
        {
            return _messageDal.GetAll(m => m.ReceiverMail == email);
        }

        public List<Message> GetAllSendbox(string email)
        {
            return _messageDal.GetAll(m => m.SenderMail == email);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(m => m.Id == id);
        }

        public void Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
