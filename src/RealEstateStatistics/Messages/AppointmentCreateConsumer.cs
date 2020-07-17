using System.Threading.Tasks;
using MassTransit;
using RealEstateCommon.Messages;
using RealEstateStatistics.Services;

namespace RealEstateStatistics.Messages
{
    public class AppointmentCreateConsumer : IConsumer<AppointmentCreatedMessage>
    {
        private readonly IStatisticService statistics;

        public AppointmentCreateConsumer(IStatisticService statistics)
            => this.statistics = statistics;

        public async Task Consume(ConsumeContext<AppointmentCreatedMessage> context)
            => await this.statistics.AddAppointment();
    }
}
