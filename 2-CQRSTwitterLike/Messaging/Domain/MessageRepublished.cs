using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Domain
{
    public struct MessageRepublished : IDomainEvent
    {
        private UserId _republisherId;
        private int _messageId;

        public MessageRepublished(UserId rpId, int msgId)
        {
            _republisherId = rpId;
            _messageId = msgId;
        }

        
    }
}
