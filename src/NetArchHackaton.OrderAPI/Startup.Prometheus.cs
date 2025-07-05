using Prometheus;

namespace NetArchHackaton.OrderAPI
{
    public partial class Startup
    {
        private void UsePrometheus(WebApplication app)
        {
            app.UseMetricServer(url: "/api/metrics");
            app.UseHttpMetrics();
        }
    }
}
