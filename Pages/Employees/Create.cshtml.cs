using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensgruppe_7___ClassLibrary.Models;
using Eksamensgruppe_7___ClassLibrary.Service;
// by Ahmed

namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class CreateModel : PageModel
    {

        // Instance of the service used to perform employee operations 
        private readonly EmployeeService _service = new EmployeeService();

        //property binds to the Employee form inputs
        [BindProperty]
        public Employee Employee { get; set; }

        //property holds the uploaded image file
        [BindProperty]
        public IFormFile UploadedPicture { get; set; }

        public IActionResult OnPost()
        {
            //check if the pic is uploaded
            if (UploadedPicture!=null && UploadedPicture.Length > 0)

            {
                // get the uploaded file name
                String fileName = UploadedPicture.FileName;

                // define the target folder and file path
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media");

                // create the folder if it doesnt exist
                if (!Directory.Exists(folderPath))

                { Directory.CreateDirectory(folderPath); }

                string filePath = Path.Combine(folderPath, fileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    UploadedPicture.CopyTo(stream);
                }

                //save the file name to the employee�s pic property
                Employee.Picture = fileName;
            }

            //add the employee to the list
            _service.Add(Employee);

            //set a message to show after adding
            TempData["Message"] = "Medarbejderen blev tilf�jet!";

            // redirect ti employee overview page
            return RedirectToPage("/Employees/Index");

        }

    }
}
