using System.Threading.Tasks;
using MassTransit;
using RealEstateCommon.Messages;
using RealEstateStatistics.Services;

namespace RealEstateStatistics.Messages
{
    public class NewsLetterCreateConsumer : IConsumer<NewsLetterCreatedMessage>
    {
        private readonly IStatisticService statistics;

        public NewsLetterCreateConsumer(IStatisticService statistics)
            => this.statistics = statistics;

        public async Task Consume(ConsumeContext<NewsLetterCreatedMessage> context)
            => await this.statistics.AddNewsLetter();
    }
}
