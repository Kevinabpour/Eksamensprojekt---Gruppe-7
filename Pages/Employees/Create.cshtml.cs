using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
// by Ahmed
namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class CreateModel : PageModel
    {
        //property binds to the Employee form inputs
        [BindProperty]
        public Employee Employee { get; set; }
        //property holds the uploaded image file
        [BindProperty]
        public IFormFile UploadedPicture { get; set; }
        public IActionResult OnPost()
        {
            // Check if the form data is valid
            if (!ModelState.IsValid)
            //if not, reload the page with validation messages
            { return Page(); }
            //check if the pic is uploaded
            if (UploadedPicture!=null)
            // get the uploaded file name
            {
                String  fileName = UploadedPicture.FileName;
                // define the target folder and file path
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media");
                string filePath = Path.Combine(folderPath, fileName);
                // create the folder if it doesnt exist
                if (!Directory.Exists(folderPath)) { Directory.CreateDirectory(folderPath); }
                //save the uploaded file to the target path
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                UploadedPicture.CopyTo(fileStream);
                fileStream.Close();
                //save the file name to the employee´s pic property
                Employee.Picture = fileName;
            }
            // add the employee to a temp list
            IndexModel.TempEmployees.Add(Employee);
            // redirect ti employee overview page
            return RedirectToPage("/Employees/Imdex");
        }

    }
}
