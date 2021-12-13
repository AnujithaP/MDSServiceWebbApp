using MDSServiceWebbApp.Models;
using MDSServiceWebbApp.Models.SQL;
using MDSServiceWebbApp.Models.Staging;
using MDSServiceWebbApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDSServiceWebbApp.Pages
{
    public class testModel : PageModel
    {
        private readonly IStagingService _stagingService;
        private readonly IMDSServices _mDSServices;


        [BindProperty]
        public IEnumerable<Person_Leaf> person_Leafs { get; set; }

        [BindProperty]
        public bool Any { get; set; }

        public testModel(IStagingService stagingService, IMDSServices mDSServices)
        {
            _stagingService = stagingService;
            _mDSServices = mDSServices;
        }

        public ActionResult OnGet()
        {
            person_Leafs = _stagingService.GetPerson_Leaves();

            return Page();
        }

        public ActionResult OnPostSeed()
        {
            if (!_stagingService.Any()) 
            {
                Seed();
                person_Leafs = _stagingService.GetPerson_Leaves();
            }

            return Page();
        }

        public ActionResult OnPostTest()
        {

            return Page();
        }

        public async Task<ActionResult> OnPostAddPersoner()
        {
            var stagePersoner = _stagingService.GetPerson_Leaves();

            foreach (var leaf in stagePersoner)
            {
                var exists = await _mDSServices.CheckPerson(leaf.Name);
                if (!exists)
                {
                    var person = new Person() { Namn = leaf.Name, Efternamn = leaf.Last_Name, Förnamn = leaf.First_Name, Personnummer = leaf.Social_Security_Number };
                    await _mDSServices.AddPerson(person);
                }
            }

            person_Leafs = _stagingService.GetPerson_Leaves();

            return Page();
        }

        public async Task<ActionResult> OnPostGetPersoner()
        {
            var personer = await _mDSServices.GetPersoner();

            return Page();
        }

        private void Seed()
        {

            var seedlist = new List<Person_Leaf>()
            {
                new Person_Leaf() { First_Name = "Bertil", Last_Name = "Svensson", Social_Security_Number = "199912022382" },
                new Person_Leaf() { First_Name = "Anna", Last_Name = "Persson", Social_Security_Number = "199303292396" },
                new Person_Leaf() { First_Name = "Petter", Last_Name = "Lund", Social_Security_Number = "199011222396" },
                new Person_Leaf() { First_Name = "Gun", Last_Name = "Pålsson", Social_Security_Number = "199501252382" },
                new Person_Leaf() { First_Name = "Fredrik", Last_Name = "Berg", Social_Security_Number = "199001172395" },
                new Person_Leaf() { First_Name = "Gertrud", Last_Name = "Larsson", Social_Security_Number = "195011012365" },
                new Person_Leaf() { First_Name = "Per", Last_Name = "Kjellson", Social_Security_Number = "196502103614" },
                new Person_Leaf() { First_Name = "Ingrid", Last_Name = "Dahlkvist", Social_Security_Number = "198110259283" }
            };

            _stagingService.Seed(seedlist);
        }
    }
}
