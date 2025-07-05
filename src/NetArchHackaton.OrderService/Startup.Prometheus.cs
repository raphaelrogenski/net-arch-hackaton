using Microsoft.Extensions.Hosting;
using Prometheus;

namespace NetArchHackaton.OrderService
{
    public partial class Startup
    {
        private void UsePrometheus(IHost app)
        {
            ////var metricServer = new KestrelMetricServer(url: "/api/metrics", port: 9091);
            ////metricServer.Start();
        }
    }
}
