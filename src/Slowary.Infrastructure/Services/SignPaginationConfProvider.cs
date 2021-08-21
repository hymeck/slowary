using Microsoft.Extensions.Configuration;
using Slowary.Application.Services;

namespace Slowary.Infrastructure.Services
{
    public class SignPaginationConfProvider : ISignPaginationConfProvider
    {
        private readonly IConfiguration _configuration;

        public SignPaginationConfProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int SignsPerPageCount => GetCount(_configuration["pagination:signs"]);

        private int GetCount(string confValue) => int.TryParse(confValue, out var count) ? count : 10;
    }
}