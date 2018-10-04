﻿#pragma warning disable IDE1006 // Naming Styles
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

using System;
using Wirehome.Core.MessageBus;
using Wirehome.Core.Model;

namespace Wirehome.Core.Python.Proxies
{
    public class MessageBusPythonProxy : IPythonProxy
    {
        private readonly MessageBusService _messageBusService;

        public MessageBusPythonProxy(MessageBusService messageBusService)
        {
            _messageBusService = messageBusService ?? throw new ArgumentNullException(nameof(messageBusService));
        }

        public string ModuleName { get; } = "message_bus";

        public void publish(WirehomeDictionary message)
        {
            _messageBusService.Publish(message);
        }

        public string subscribe(WirehomeDictionary filter, Action<WirehomeDictionary> callback)
        {
            return _messageBusService.Subscribe(filter, callback);
        }

        public void unsubscribe(string subscription_uid)
        {
            _messageBusService.Unsubscribe(subscription_uid);
        }

        public void register_interceptor(string uid, Func<WirehomeDictionary, WirehomeDictionary> interceptor)
        {
            _messageBusService.RegisterInterceptor(uid, interceptor);
        }
    }
}