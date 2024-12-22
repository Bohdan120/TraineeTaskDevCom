using AnnouncementClient.Models;
using Newtonsoft.Json;

namespace AnnouncementClient.Services
{
    public class AnnouncementService
    {
        private readonly HttpClient _client;

        public AnnouncementService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<AnnouncementViewModel>> GetAllAnnouncementsAsync()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/announcement/Get");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AnnouncementViewModel>>(data);
            }
            return new List<AnnouncementViewModel>();
        }

        public List<AnnouncementViewModel> FilterAnnouncements(List<AnnouncementViewModel> announcements, string category, string subcategory)
        {
            if (!string.IsNullOrEmpty(category))
            {
                announcements = announcements.Where(a => a.Category == category).ToList();
            }

            if (!string.IsNullOrEmpty(subcategory))
            {
                announcements = announcements.Where(a => a.SubCategory == subcategory).ToList();
            }

            return announcements;
        }

        public List<string> GetCategories(List<AnnouncementViewModel> announcements)
        {
            return announcements.Select(a => a.Category).Distinct().ToList();
        }

        public List<string> GetSubCategories(List<AnnouncementViewModel> announcements, string category)
        {
            return announcements
                .Where(a => string.IsNullOrEmpty(category) || a.Category == category)
                .Select(a => a.SubCategory)
                .Distinct()
                .ToList();
        }
    }
}
