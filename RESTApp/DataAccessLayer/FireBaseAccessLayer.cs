using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTApp.BL;
using RESTApp.GoogleAPI;
using System.Web.Script.Serialization;

namespace RESTApp.DataAccessLayerNameSpace
{
    public class FireBaseAccessLayer
    {
        public void PushNotification(UserNotification p_notification)
        {
            var jsonBody = new JavaScriptSerializer().Serialize(p_notification);
            new FireBaseClient().send(m_serverKey, m_senderId, p_notification.ReceiverFBId, 
                p_notification.Title, jsonBody);
        }

        private string m_serverKey = System.Configuration.ConfigurationManager.AppSettings["SERVER_KEY"];
        private string m_senderId = System.Configuration.ConfigurationManager.AppSettings["SENDER_ID"];
    }
}