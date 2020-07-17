using System.Threading.Tasks;
using MassTransit;
using RealEstateCommon.Messages;
using RealEstateStatistics.Services;

namespace RealEstateStatistics.Messages
{
    public class PropertyCreateConsumer : IConsumer<PropertyCreatedMessage>
    {
        private readonly IStatisticService _statistics;

        public PropertyCreateConsumer(IStatisticService statistics)
            => this._statistics = statistics;

        public async Task Consume(ConsumeContext<PropertyCreatedMessage> context)
            => await this._statistics.AddProperty();
    }
}
