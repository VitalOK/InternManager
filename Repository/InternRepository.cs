using Dapper;
using Models;
using Repository.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repository
{
    public class InternRepository : IRepository<Intern>
    {
        public List<Intern> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("InternsDB")))
            {
                var output = connection.Query<Intern>($"SELECT * FROM Interns").ToList();
                return output;
            }
        }

        public Intern GetById(int Id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("InternsDB")))
            {
                var output = connection.Query<Intern>($"SELECT * FROM Interns WHERE Id={Id}");
                return output.FirstOrDefault();
            }
        }

        public void Insert(Intern intern)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("InternsDB")))
            {
                connection.Execute("INSERT INTO Interns VALUES (@FirstName, @LastName, @Email, @DateOfBirth, @Description)", intern);
            }
        }

        public void Update(Intern intern)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("InternsDB")))
            {
                connection.Execute($"UPDATE Interns SET Email='{intern.Email}', Description = '{intern.Description}' WHERE Id={intern.Id}");
            }
        }
    }
}
