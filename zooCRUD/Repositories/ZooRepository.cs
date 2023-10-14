using zooCRUD.Interfaces;
using zooCRUD.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace zooCRUD.Repositories;

public class ZooRepository : IZooRepository
{
    private readonly IConfiguration _configuration;
    private readonly string azureConnectionString = "Server=tcp:alexandraburress.database.windows.net,1433;Initial Catalog=zooDBAzure;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";user id=allie.burress@outlook.com";
    public ZooRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string PostAnimal(string name, Species species, int height, int weight)
    {
        var parameters = new SqlParameter[]
        {
            new("@name", name),
            new("@species", species.ToString()),
            new("@height", height),
            new("@weight", weight)
        };

        using var conn = new SqlConnection(azureConnectionString);
        using var command = new SqlCommand("POSTsp", conn) { 
            CommandType = CommandType.StoredProcedure};
        command.Parameters.AddRange(parameters);

        try{
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        catch(Exception ex){
            Console.WriteLine(ex);
        }

        return $"Animal {name} the {species} has been added!";
    }

    public Animal GetAnimal(string name, Species species)
    {
        Animal result = new();
        var parameters = new SqlParameter[]
        {
            new("@name", name),
            new("@species", species.ToString())
        };

        using var conn = new SqlConnection(azureConnectionString);
        using var command = new SqlCommand("GETsp", conn) { 
            CommandType = CommandType.StoredProcedure};
        command.Parameters.AddRange(parameters);
        try{
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                result.Name = reader.GetString(reader.GetOrdinal("Name"));
                result.Species = (Species)Enum.Parse(typeof(Species), reader.GetString(reader.GetOrdinal("Species")));
                result.Height = reader.GetInt32(reader.GetOrdinal("Height"));
                result.Weight = reader.GetInt32(reader.GetOrdinal("Weight"));
                result.Happiness = reader.GetInt32(reader.GetOrdinal("Happiness"));
            }
            reader.Close();
            conn.Close();
        }
        catch(Exception ex){
            Console.WriteLine(ex);
        }

        return result;
    }

    public string UpdateAnimal(string name, Species species, int height, int weight)
    {
        var parameters = new SqlParameter[]
        {
            new("@name", name),
            new("@species", species.ToString()),
            new("@height", height),
            new("@weight", weight)
        };

        using var conn = new SqlConnection(azureConnectionString);
        using var command = new SqlCommand("UPDATEsp", conn) { 
            CommandType = CommandType.StoredProcedure};
        command.Parameters.AddRange(parameters);

        try{
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        catch(Exception ex){
            Console.WriteLine(ex);
        }

        return $"Animal {name} the {species} has been updated!";
    }

    public string DeleteAnimal(string name, Species species)
    {
        var parameters = new SqlParameter[]
        {
            new("@name", name),
            new("@species", species.ToString())
        };

        using var conn = new SqlConnection(azureConnectionString);
        using var command = new SqlCommand("DELETEsp", conn) { 
            CommandType = CommandType.StoredProcedure};
        command.Parameters.AddRange(parameters);

        try{
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        catch(Exception ex){
            Console.WriteLine(ex);
        }

        return $"Animal {name} the {species} has been removed.";
    }

    public List<Animal> GetAllAnimals()
    {
        List<Animal> results = new();

        using var conn = new SqlConnection(azureConnectionString);
        using var command = new SqlCommand("SELECTALLsp", conn) { 
            CommandType = CommandType.StoredProcedure};
        try{
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                results.Add(new Animal{
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Species = (Species)Enum.Parse(typeof(Species), reader.GetString(reader.GetOrdinal("Species"))),
                Height = reader.GetInt32(reader.GetOrdinal("Height")),
                Weight = reader.GetInt32(reader.GetOrdinal("Weight")),
                Happiness = reader.GetInt32(reader.GetOrdinal("Happiness"))});
            }
            reader.Close();
            conn.Close();
        }
        catch(Exception ex){
            Console.WriteLine(ex);
        }

        return results;
    }
}