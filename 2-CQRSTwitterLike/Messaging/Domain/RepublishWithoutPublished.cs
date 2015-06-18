
using System;

namespace Messaging.Domain
{
    public class RepublishWithoutPublished : Exception
    {
        private String msgErr;
        private int numErr;

        public RepublishWithoutPublished()
        {
            msgErr = "Le message ne peut pas être republié sans avoir déjà été publié.";
            numErr = 10003;
        }
    }
}
