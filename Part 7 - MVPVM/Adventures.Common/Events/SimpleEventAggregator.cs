﻿namespace Adventures.Common.Events
{
    public class SimpleEventAggregator : IMvpEventAggregator
	{
        // https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/messagingcenter
        //

        public void Publish<TSender>(TSender sender, string message)
            where TSender : class
        {
            MessagingCenter.Send<TSender>(sender, message);
        }

        public void Publish<TSender,TArgs>(TSender sender, string message, TArgs args)
			where TSender : class
        {
			MessagingCenter.Send<TSender,TArgs>(sender, message, args);
		}

		public void Subscribe<TSender>(object subscriber, string  message,
			Action<TSender> callback) where TSender : class
        {
			MessagingCenter.Subscribe<TSender>(subscriber, message, callback);
        }
	}
}