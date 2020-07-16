namespace RealEstate.Bookmarks.Gateway.Services
{
    using System;
    using System.Linq;

    public class ServiceEndpoints
    {
        public string Property { get; set; }

        public string Bookmark { get; set; }

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
