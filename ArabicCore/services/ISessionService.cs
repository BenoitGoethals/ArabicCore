using System;
using System.Collections.Generic;
using ArabicCore.model;

namespace ArabicCore.services
{
    public interface ISessionService
    {
        IList<Session> AllSessions();
        IList<Session> AllSessions(Func<Session, bool> predicate);
        void Delete(Session session);
        Session Add(Session session);
        void Update(Session session);
    }
}