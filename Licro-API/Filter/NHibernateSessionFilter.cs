using Dominio.Modelos.Notifications;
using Microsoft.AspNetCore.Mvc.Filters;
using NHibernate;
using System;
using System.Threading.Tasks;

namespace Licro_Api.Filters
{
    public class NHibernateSessionFilter : IAsyncActionFilter
    {
        private readonly NotificationContext _notificationContext;
        private readonly ISession _session;

        public NHibernateSessionFilter(NotificationContext notificationContext, ISession session)
        {
            _notificationContext = notificationContext ?? throw new ArgumentNullException(nameof(notificationContext));
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var transaction = _session.BeginTransaction();

            try
            {
                await next.Invoke();

                if (_notificationContext.HasNotifications && transaction.IsActive && !transaction.WasCommitted)
                {
                    transaction.Rollback();
                }
                else if (transaction.IsActive && !transaction.WasCommitted)
                {
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                if (transaction.IsActive && !transaction.WasRolledBack)
                {
                    transaction.Rollback();
                }

                throw;
            }
        }
    }
}