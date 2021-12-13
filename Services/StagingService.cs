using Dapper;
using MDSServiceWebbApp.Data;
using MDSServiceWebbApp.Models.Staging;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDSServiceWebbApp.Services
{
    public class StagingService : IStagingService
    {
        private readonly IConfiguration _configuration;

        public StagingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Any()
        {
            var query = @"SELECT COUNT(*) FROM stg.Person_Leaf";
            var count = 0;
            var exstr = "";

            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("MDSStaging")))
                {
                    count = conn.ExecuteScalar<int>(query);
                }
            }

            catch (Exception ex)
            {
                exstr = ex.Message;
            }
                
            return count > 0;
        }

        public IEnumerable<Person_Leaf> GetPerson_Leaves()
        {
            var exstr = "";
            var query = @"SELECT [Name], [First Name] AS First_Name, [Last Name] AS Last_Name, [Social Security Number] AS Social_Security_Number FROM stg.Person_Leaf";
            var result = new List<Person_Leaf>();

            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("MDSStaging")))
                {
                    result = conn.Query<Person_Leaf>(query).ToList();
                }
            }

            catch (Exception ex)
            {
                exstr = ex.Message;
            }

            return result;
        }

        public void AddPerson_Leaf(Person_Leaf person_leaf)
        {
            var exstr = "";
            var query = @"INSERT INTO stg.Person_Leaf ([ImportType], [ImportStatus_ID], [BatchTag], [ErrorCode], [Name], [First Name], [Last Name], [Social Security Number]) 
                            VALUES (0, 0, 'BatchTag', 0, @name, @firstname, @lastname, @personnummer);";

            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("MDSStaging")))
                {
                    var rows = conn.Execute(query, new { name = person_leaf.Last_Name + ", " + person_leaf.First_Name, firstname = person_leaf.First_Name, lastname = person_leaf.Last_Name, personnummer = person_leaf.Social_Security_Number });
                }
            }

            catch (Exception ex)
            {
                exstr = ex.Message;
            }
        }

        public void Seed(IEnumerable<Person_Leaf> leafs)
        {
            foreach (var leaf in leafs)
            {
                AddPerson_Leaf(leaf);
            }
        }
    }
}
