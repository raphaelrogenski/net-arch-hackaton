using Prometheus;

namespace NetArchHackaton.KitchenAPI
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
