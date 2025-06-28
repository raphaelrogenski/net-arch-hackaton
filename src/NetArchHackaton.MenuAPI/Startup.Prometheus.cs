using Prometheus;

namespace NetArchHackaton.MenuAPI
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
