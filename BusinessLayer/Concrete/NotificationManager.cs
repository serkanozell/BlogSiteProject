using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationRepository _notificationRepository;

        public NotificationManager(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public void TAdd(Notification entity)
        {
            _notificationRepository.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationRepository.Delete(entity);
        }

        public void TUptade(Notification entity)
        {
            _notificationRepository.Update(entity);
        }
        public Notification TGetByID(int id)
        {
            return _notificationRepository.GetById(id);
        }
        public List<Notification> GetList()
        {
            return _notificationRepository.GetAll();
        }
    }
}
