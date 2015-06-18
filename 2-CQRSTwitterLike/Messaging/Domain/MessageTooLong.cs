using System;

namespace Messaging.Domain
{
    public class MessageTooLong : Exception
    {
        private String msgErr;
        private int numErr;

        public MessageTooLong()
        {
            msgErr = "Le message fait plus de 140 caractères.";
            numErr = 10001;
        }
    }
}