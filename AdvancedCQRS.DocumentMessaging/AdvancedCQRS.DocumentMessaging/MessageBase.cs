﻿using System;

namespace AdvancedCQRS.DocumentMessaging
{
    public abstract class MessageBase : IMessage
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CorrelationId { get; set; }

        public Guid CausationId { get; set; }

        public void ReplyTo(MessageBase message)
        {
            if (message == null) return;

            CorrelationId = message.CorrelationId;
            CausationId = message.Id;
        }
    }

    public interface IMessage
    {
        Guid Id { get; }

        string CorrelationId { get; }

        Guid CausationId { get; }
    }
}