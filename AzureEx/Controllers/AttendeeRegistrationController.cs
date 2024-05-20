using AzureEx.Data;
using AzureEx.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureEx.Controllers
{
    public class AttendeeRegistrationController : Controller
    {
        private readonly ITableStorageService _tableStorageService;
        private readonly IBlobStorageService _blogStorageService;
        private readonly IQueueService _queueService;

        public AttendeeRegistrationController(ITableStorageService tableStorageService,
            IBlobStorageService blogStorageService , IQueueService queueService)
        {
            _tableStorageService = tableStorageService;
            _blogStorageService = blogStorageService;
            _queueService = queueService;
        }

        // GET: AttendeeRegistrationController
        public async Task<ActionResult> Index()
        {
            var data=  await   _tableStorageService.GetAttendees();
            foreach (var item in data)
            {
                item.ImageName = await _blogStorageService.GetBlobUrl(item.ImageName);
            }
            return View(data);
        }

        // GET: AttendeeRegistrationController/Details/5
        public async Task<ActionResult> Details(string id,string industry)
        {
            var data = await _tableStorageService.GetAttendee(industry,id);
            data.ImageName = await _blogStorageService.GetBlobUrl(data.ImageName);
            return View(data);
        }

        // GET: AttendeeRegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AttendeeRegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AttendeeEntity attendeeEntity,IFormFile formFile)
        {
            try
            {
                var id=Guid.NewGuid().ToString();
                attendeeEntity.PartitionKey = attendeeEntity.Industry;
                attendeeEntity.RowKey=id;

                if(formFile.Length>0)
                {
                    attendeeEntity.ImageName = await _blogStorageService.UploadBlob(formFile,id);

                }
                else
                {
                    attendeeEntity.ImageName = "default.jpg";
                }

                await _tableStorageService.UpdateAttendee(attendeeEntity);


                var email = new EmailMessage {
                    EmailAddress = attendeeEntity.Email,
                    TimeStamp = DateTime.Now,
                    Message = $"Hi, Thanks for registering"
                
                
                };

                await _queueService.SendMessage(email);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AttendeeRegistrationController/Edit/5
        public async Task<ActionResult> Edit(string id, string industry)
        {
            var data = await _tableStorageService.GetAttendee(industry, id);
            return View(data);
        }

        // POST: AttendeeRegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AttendeeEntity attendeeEntity,IFormFile formFile)
        {
            try
            {

                if (formFile?.Length > 0)
                {
                    attendeeEntity.ImageName = await _blogStorageService.UploadBlob(formFile, attendeeEntity.RowKey);

                }

                attendeeEntity.PartitionKey = attendeeEntity.Industry;

                await _tableStorageService.UpdateAttendee(attendeeEntity);

           

                return RedirectToAction(nameof(Index));
            }
            catch( Exception ex) 
            {
                return View();
            }
        }

        //// GET: AttendeeRegistrationController/Delete/5
        //public async Task<ActionResult> Delete(string id, string industry)
        //{
        //    var data = await _tableStorageService.GetAttendee(industry, id);
        //    return View(data);
        //}

        //POST: AttendeeRegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, string industry)
        {
            try
            {
                var data = await _tableStorageService.GetAttendee(industry, id);
                await _tableStorageService.DeleteAttendee(industry, id);
                await _blogStorageService.RemoveBlob(data.ImageName);


                var email = new EmailMessage
                {
                    EmailAddress = data.Email,
                    TimeStamp = DateTime.Now,
                    Message = $"Hi, It is the notification for delete"


                };

                await _queueService.SendMessage(email);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
