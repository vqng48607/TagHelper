using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TagHelper.Models;

namespace TagHelper.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string pathData = "Data/collection.json";

            using var jsonFile = System.IO.File.OpenRead(pathData);

            var contacts = JsonSerializer.Deserialize<List<Contact>>(jsonFile);

            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);

        }

        public IActionResult Detail(Guid? id)
        {
            string pathData = "Data/collection.json";

            using var jsonFile = System.IO.File.OpenRead(pathData);

            var contacts = JsonSerializer.Deserialize<List<Contact>>(jsonFile);

            if (id == null || contacts == null)
            {
                return NotFound();
            }

            var contact = contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

    }
}
