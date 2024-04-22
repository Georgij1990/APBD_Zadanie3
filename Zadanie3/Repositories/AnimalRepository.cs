using MySql.Data.MySqlClient;
using Zadanie3.Model;

namespace Zadanie3.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        IConfiguration _configuration;

        public AnimalRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int CreateAnimal(Animal animal)
        {
            using var con = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Animals(Name, Description, Category, Area) VALUES(@Name, @Description, @Category, @Area)";
            cmd.Parameters.AddWithValue("@Name", animal.Name);
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Category", animal.Category);
            cmd.Parameters.AddWithValue("@Area", animal.Area);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }

        public int DeleteAnimal(int idAnimal)
        {
            using var con = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Animals WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", idAnimal);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            using var con = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]); 
            con.Open();
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT Id, Name, Description, Category, Area FROM Animals ORDER BY {orderBy} ASC";
            var dr = cmd.ExecuteReader();
            var animals = new List<Animal>();
            while (dr.Read())
            {
                var animal = new Animal
                {
                    Id = (int)dr["Id"],
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString()
                };
                animals.Add(animal);
            }
            return animals;
        }

        public Animal GetAnimal(int idAnimal)
        {
            using var con = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select Id, Name, Description, Category, Area FROM Animals WHERE Id = @idAnimal";
            cmd.Parameters.AddWithValue("@idAnimal", idAnimal);

            var dr = cmd.ExecuteReader();

            if (!dr.Read()) return null;

            var animal = new Animal
            {
                Id = (int)dr["Id"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };

            return animal;
        }

        public int UpdateAnimal(int id, Animal animal)
        {
            using var con = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Animals SET Name=@Name, Category=@Category, Area=@Area WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", animal.Name);
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Category", animal.Category);
            cmd.Parameters.AddWithValue("@Area", animal.Area);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }
    }
}
