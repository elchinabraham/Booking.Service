using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Booking.Service.WebApi.Test.HomeApi
{
    public class HomesControllerTests : IClassFixture<TestWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public HomesControllerTests(TestWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAvailableHomes_Returns200_AndHomesCoveringRequestedRange()
        {
            var start = DateTime.Today.AddDays(3);
            var end = DateTime.Today.AddDays(4);

            var url = $"/api/homes?StartDate={start:yyyy-MM-dd}&EndDate={end:yyyy-MM-dd}";

            var response = await _client.GetAsync(url);


            // --------------------------------------------------------------------
            // It is for test failing scenario --> It should be "HttpStatusCode.Ok"
            // --------------------------------------------------------------------
            response.StatusCode.Should().Be(HttpStatusCode.NotFound); // HttpStatusCode.Ok
            // --------------------------------------------------------------------

            using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            var arr = doc.RootElement;

            arr.ValueKind.Should().Be(JsonValueKind.Array);
            arr.GetArrayLength().Should().BeGreaterThan(0);

            foreach (var home in arr.EnumerateArray())
            {
                home.TryGetProperty("homeId", out _).Should().BeTrue();
                home.TryGetProperty("homeName", out _).Should().BeTrue();
                home.TryGetProperty("availableSlots", out var slotsEl).Should().BeTrue();
                slotsEl.ValueKind.Should().Be(JsonValueKind.Array);

                
                var slotDates = slotsEl.EnumerateArray()
                                       .Select(e => DateTime.Parse(e.GetString()!))
                                       .Select(d => d.Date)
                                       .ToHashSet();

                slotDates.Contains(start.Date).Should().BeTrue();
                slotDates.Contains(end.Date).Should().BeTrue();
            }
        }

        [Fact]
        public async Task GetAvailableHomes_Returns200_AndEmptyArray_WhenNoHomeMatches()
        {
            var start = DateTime.Today.AddDays(25);
            var end = DateTime.Today.AddDays(26);

            var url = $"/api/homes?StartDate={start:yyyy-MM-dd}&EndDate={end:yyyy-MM-dd}";

            var response = await _client.GetAsync(url);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var payload = await response.Content.ReadFromJsonAsync<JsonElement>();
            payload.ValueKind.Should().Be(JsonValueKind.Array);
            payload.GetArrayLength().Should().Be(0);
        }

        [Fact]
        public async Task GetAvailableHomes_Returns400_ProblemDetails_WhenStartAfterEnd()
        {
            var start = DateTime.Today.AddDays(7);
            var end = DateTime.Today.AddDays(6);

            var url = $"/api/homes?StartDate={start:yyyy-MM-dd}&EndDate={end:yyyy-MM-dd}";

            var response = await _client.GetAsync(url);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var problem = await response.Content.ReadFromJsonAsync<JsonElement>();
            problem.TryGetProperty("type", out _).Should().BeTrue();  
            problem.TryGetProperty("title", out _).Should().BeTrue();
            problem.TryGetProperty("status", out var status).Should().BeTrue();
            status.GetInt32().Should().Be(400);
        }
    }
}
