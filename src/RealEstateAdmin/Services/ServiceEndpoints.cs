namespace RealEstate.Services
{
    using System;
    using System.Linq;

    public class ServiceEndpoints
    {
        public string Identity { get; private set; }

        public string News { get; private set; }

        public string Appointment { get; private set; }

        public string Property { get; set; }

        public string Bookmark { get; set; }
        public string BookmarkGateway { get; set; }
        public string Statistic { get; set; }

        public string this[string service] 
            => this.GetType()
                .GetProperties()
                .Where(pr => string
                    .Equals(pr.Name, service, StringComparison.CurrentCultureIgnoreCase))
                .Select(pr => (string) pr.GetValue(this))
                .FirstOrDefault()
                ?? throw new InvalidOperationException(
                    $"External service with name '{service}' does not exists.");
    }
}
