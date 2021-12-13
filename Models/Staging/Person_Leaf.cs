using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MDSServiceWebbApp.Models.Staging
{
    public class Person_Leaf
    {
        [Key]
        public int ID { get; set; }
        public int ImportType { get; set; }
        public int ImportStatus_ID { get; set; }
        public int? Batch_ID { get; set; }
        public string BatchTag { get; set; }
        public int ErrorCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NewCode { get; set; }
        [Column("Social Security Number")]
        public string Social_Security_Number { get; set; }
        [Column("Co ordination number")]
        public string Co_ordination_number { get; set; }
        [Column("Date of birth")]
        public string Date_of_birth { get; set; }
        [Column("First Name")]
        public string First_Name { get; set; }
        [Column("Given Name Marker")]
        public decimal? Given_Name_Marker { get; set; }
        [Column("Given Name")]
        public string Given_Name { get; set; }
        [Column("Middle Name")]
        public string Middle_Name { get; set; }
        [Column("Last Name")]
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        [Column("Date of Death")]
        public DateTime? Date_of_Death { get; set; }
        [Column("Registration Address")]
        public string Registration_Address { get; set; }
        [Column("Special Address")]
        public string Special_Address { get; set; }
        [Column("Emigration Address")]
        public string Emigration_Address { get; set; }
        [Column("Work Email")]
        public string Work_Email { get; set; }
        [Column("Private Email")]
        public string Private_Email { get; set; }
        public string County { get; set; }
        public string Municipality { get; set; }
        [Column("Private Cell Phone Number")]
        public decimal? Private_Cell_Phone_Number { get; set; }
        [Column("Private Phone Number")]
        public decimal? Private_Phone_Number { get; set; }
        [Column("Emigrated Person")]
        public string Emigrated_Person { get; set; }
        [Column("Protected Person")]
        public string Protected_Person { get; set; }
        [Column("Protected Person Type")]
        public string Protected_Person_Type { get; set; }
    }
}
