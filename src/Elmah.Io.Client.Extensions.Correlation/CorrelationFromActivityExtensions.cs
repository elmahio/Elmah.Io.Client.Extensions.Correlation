using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Elmah.Io.Client.Extensions.Correlation
{
    /// <summary>
    /// This class contain extension methods for getting correlation ID from a W3C Trace Context.
    /// </summary>
    public static class CorrelationFromActivityExtensions
    {
        /// <summary>
        /// Enrich a message with a correlation ID taken from a W3C activity trace ID.
        /// </summary>
        public static CreateMessage WithCorrelationIdFromActivity(this CreateMessage message)
        {
            if (message == null) return message;

            try
            {
                var activity = Activity.Current;
                if (activity == null) return message;
                if (activity.TraceId == default) return message;
                message.CorrelationId = activity.TraceId.ToString();
            }
            catch (Exception e)
            {
                message.Data ??= new List<Item>();
                message.Data.Add(new Item("X-ELMAHIO-CORRELATIONERROR", e.Message));
            }

            return message;
        }
    }
}
