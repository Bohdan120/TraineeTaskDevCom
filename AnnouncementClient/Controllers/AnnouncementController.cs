using AnnouncementClient.Models;
using AnnouncementClient.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AnnouncementClient.Controllers
{
    public class AnnouncementController : Controller
    {
        Uri baseAdress = new Uri("https://localhost:7235/api");
        private readonly HttpClient _client;
        private readonly AnnouncementService _announcementService;

        public AnnouncementController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdress;
            _announcementService = new AnnouncementService(_client);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string category, string subcategory)
        {
            List<AnnouncementViewModel> announcements = await _announcementService.GetAllAnnouncementsAsync();
            List<AnnouncementViewModel> filteredAnnouncements = _announcementService.FilterAnnouncements(announcements, category, subcategory);

            ViewBag.Categories = _announcementService.GetCategories(announcements);
            ViewBag.SubCategories = _announcementService.GetSubCategories(announcements, category);

            ViewBag.SelectedCategory = category;
            ViewBag.SelectedSubCategory = subcategory;
             
            return View(filteredAnnouncements);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AnnouncementViewModel announcement)
        {
            if (ModelState.IsValid)
            {
                string jsonData = JsonConvert.SerializeObject(announcement);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/announcement/Post", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Announcement added successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the announcement");
                }
            }

            return View(announcement);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            AnnouncementViewModel announcement = null;
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/announcement/Get/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                announcement = JsonConvert.DeserializeObject<AnnouncementViewModel>(data);
            }

            return View(announcement);
        }

        [HttpPost]
        public IActionResult Edit(AnnouncementViewModel announcement)
        {
            if (ModelState.IsValid)
            {
                string jsonData = JsonConvert.SerializeObject(announcement);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + $"/announcement/Update/{announcement.Id}", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Announcement updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to update the announcement");
                }
            }

            return View(announcement);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/announcement/Delete/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Announcement deleted successfully!";
            }
            else
            {
                ModelState.AddModelError("", "Failed to delete the announcement");
            }

            return RedirectToAction("Index");
        }

    }
}
