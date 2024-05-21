using NUnit.Framework;
using System.Diagnostics;

namespace Elmah.Io.Client.Extensions.Correlation.Test
{
    public class CorrelationFromActivityExtensionsTest
    {
        [Test]
        public void CanGetTraceIdFromActivity()
        {
            using var activity = new Activity("ApiCall").Start();
            Assert.That(new CreateMessage().WithCorrelationIdFromActivity().CorrelationId, Is.EqualTo(activity.TraceId.ToString()));
        }

        [Test]
        public void CanGetTraceIdFromUnstartedActivity()
        {
            using var activity = new Activity("ApiCall");
            Assert.That(new CreateMessage().WithCorrelationIdFromActivity().CorrelationId, Is.Null);
        }

        [Test]
        public void CanRunOnNullActivity()
        {
            Assert.That(new CreateMessage().WithCorrelationIdFromActivity().CorrelationId, Is.Null);
        }

        [Test]
        public void CanRunOnNull()
        {
            Assert.That(((CreateMessage)null).WithCorrelationIdFromActivity(), Is.Null);
        }
    }
}
