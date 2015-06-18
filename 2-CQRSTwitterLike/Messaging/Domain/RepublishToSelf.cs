using System;

namespace Messaging.Domain
{
    public class RepublishToSelf : Exception
    {
        private String msgErr;
        private int numErr;

        public RepublishToSelf()
        {
            msgErr = "Le message ne peut pas être republié par le même auteur.";
            numErr = 10002;
        }
    }
}
