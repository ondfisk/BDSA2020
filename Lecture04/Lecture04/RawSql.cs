using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Lecture04
{
    public class RawSql : IDisposable
    {
        private readonly SqlConnection _connection;

        public RawSql(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public int Create(CharacterDTO character)
        {
            var cmdText = @"INSERT Character (Name, Species, Planet, ActorId)
                            VALUES (@Name, @Species, @Planet, @ActorId);
                            SELECT SCOPE_IDENTITY()";

            using (var command = new SqlCommand(cmdText, _connection))
            {
                command.Parameters.AddWithValue("@Name", character.Name);
                command.Parameters.AddWithValue("@Species", character.Species);
                command.Parameters.AddWithValue("@Planet", character.Planet);
                command.Parameters.AddWithValue("@ActorId", character.ActorId);

                OpenConnection();

                var id = command.ExecuteScalar();

                return (int)id;
            }
        }

        public CharacterDTO Read(string name)
        {
            var cmdText = @"SELECT c.Id, c.Name, c.Species, c.Planet, c.ActorId, a.Name AS ActorName
                            FROM Characters AS c
                            LEFT JOIN Actors AS a ON c.ActorId = a.Id
                            WHERE c.Name = @Name";

            using (var command = new SqlCommand(cmdText, _connection))
            {
                command.Parameters.AddWithValue("@Name", name);

                OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read()
                        ? new CharacterDTO
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"] as string,
                            Species = reader["Species"] as string,
                            Planet = reader["Planet"] as string,
                            ActorId = (int)reader["ActorId"],
                            ActorName = reader["ActorName"] as string,
                        }
                        : null;
                }
            }
        }

        public IEnumerable<CharacterDTO> Read()
        {
            var cmdText = @"SELECT c.Id, c.Name, c.Species, c.Planet, c.ActorId, a.Name AS ActorName
                            FROM Characters AS c
                            LEFT JOIN Actors AS a ON c.ActorId = a.Id
                            ORDER BY c.Name";

            using (var command = new SqlCommand(cmdText, _connection))
            {
                OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new CharacterDTO
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"] as string,
                            Species = reader["Species"] as string,
                            Planet = reader["Planet"] as string,
                            ActorId = (int)reader["ActorId"],
                            ActorName = reader["ActorName"] as string,
                        };
                    }
                }
            }
        }

        public void Update(CharacterDTO character)
        {
            var cmdText = @"UPDATE Characters SET
                            Name = @Name,
                            Species = @Species,
                            Planet = @Planet,
                            ActorId = @ActorId
                            WHERE Id = @Id";

            using (var command = new SqlCommand(cmdText, _connection))
            {
                command.Parameters.AddWithValue("@Id", character.Id);
                command.Parameters.AddWithValue("@Name", character.Name);
                command.Parameters.AddWithValue("@Species", character.Species);
                command.Parameters.AddWithValue("@Planet", character.Planet);
                command.Parameters.AddWithValue("@ActorId", character.ActorId);

                OpenConnection();

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int characterId)
        {
            var cmdText = @"DELETE Characters WHERE Id = @Id";

            using (var command = new SqlCommand(cmdText, _connection))
            {
                command.Parameters.AddWithValue("@Id", characterId);

                OpenConnection();

                command.ExecuteNonQuery();
            }
        }

        private void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}