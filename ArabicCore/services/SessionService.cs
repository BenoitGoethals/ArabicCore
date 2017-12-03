using System;
using System.Collections.Generic;
using ArabicCore.model;
using ArabicCore.repository;

namespace ArabicCore.services
{
    public class SessionService: ISessionService
    {

        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        
        public IList<Session> AllSessions()
        {
            return _unitOfWork.SessionsRepository.All();
        }

        public IList<Session> AllSessions(Func<Session, bool> predicate)
        {
            return _unitOfWork.SessionsRepository.All(predicate);
        }

        public void Delete(Session session)
        {
            _unitOfWork.SessionsRepository.Delete(session);
        }

        public Session Add(Session session)
        {
            return _unitOfWork.SessionsRepository.Add(session);
        }

        public void Update(Session session)
        {
            _unitOfWork.SessionsRepository.Update(session);
        }
    }
}