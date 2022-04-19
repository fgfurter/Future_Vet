using Future_Vet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Future_Vet
{
    public class AuditAttribute : ActionFilterAttribute//framework for custom ActionFilter.
    {
        private Future_VetEntities db = new Future_VetEntities();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //Stores the Request in an Accessible object
                var request = filterContext.HttpContext.Request;
                //Generate an audit
                AuditLog audit = new AuditLog()
                {
                    //Our Username (if available)

                    UserName = HttpContext.Current.Session["FullName"].ToString(),
                    //The IP Address of the Request
                    IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                    //The URL that was accessed
                    AreaAccessed = request.RawUrl,
                    //Creates our Timestamp
                    Timestamp = DateTime.UtcNow
                };

                db.AuditLogs.Add(audit);
                //Stores the Audit in the Database
                //AuditingContext context = new AuditingContext();
                //context.AuditRecords.Add(audit);
                db.SaveChanges();

                //Finishes executing the Action as normal 
                base.OnActionExecuting(filterContext);
            }
            catch (Exception ex)
            {
            }
          
        }
    }
}