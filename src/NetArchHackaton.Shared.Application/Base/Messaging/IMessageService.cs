﻿namespace NetArchHackaton.Shared.Application.Base.Messaging
{
    public interface IMessageService
    {
        void Publish<T>(T message);
        void Consume<T>(Func<T, Task> handler, bool useDeadLetter = true);
        T? ConsumeFromDLQ<T>();
    }
}
