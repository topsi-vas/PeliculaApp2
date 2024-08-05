﻿using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using PeliculaApp2.Models;
using System.Data.SqlClient;
namespace PeliculaApp2.Services
{
    public class PeliculaService
    {
        private readonly string _connectionString;
        public PeliculaService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //get peliculas
        public List<Pelicula> GetPeliculas()
        {
            var peliculas = new List<Pelicula>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetPeliculas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            peliculas.Add(new Pelicula
                            {
                                Id = (int)reader["id"],
                                Nombre_Pelicula = reader["Nombre_Pelicula"].ToString(),
                                Genero = reader["Genero"].ToString(),
                                Precio = (decimal)reader["Precio"]
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return peliculas;
        }

        // get peliculas

        //get peliculaBiId
        public Pelicula GetPeliculaById(int id)
        {
            Pelicula pelicula = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetPeliculaById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pelicula = new Pelicula
                        {
                            Id = (int)reader["id"],
                            Nombre_Pelicula = reader["Nombre_Pelicula"].ToString(),
                            Genero = reader["Genero"].ToString(),
                            Precio = (decimal)reader["Precio"]
                        };
                    }
                }
            }
            }
            catch (Exception)
            {

                throw;
            }
            return pelicula;
        }

        //insert Pelicula
        public void InsertPelicula(Pelicula pelicula)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("InsertPelicula", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre_Pelicula", pelicula.Nombre_Pelicula);
                    cmd.Parameters.AddWithValue("@Genero", pelicula.Genero);
                    cmd.Parameters.AddWithValue("@Precio", pelicula.Precio);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        //update
        public void UpdatePelicula(Pelicula pelicula)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdatePelicula", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", pelicula.Id);
                cmd.Parameters.AddWithValue("@Nombre_Pelicula", pelicula.Nombre_Pelicula);
                cmd.Parameters.AddWithValue("@Genero", pelicula.Genero);
                cmd.Parameters.AddWithValue("@Precio", pelicula.Precio);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //delete
        public void DeletePelicula(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeletePelicula", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
