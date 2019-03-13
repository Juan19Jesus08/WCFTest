using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1;

namespace ServicioWTF
{
    public class Service1 : IService1
    {
        public Service1()
        {
            ConnectToDb();
        }
        SqlConnection conn;
        SqlCommand comm;
        SqlConnectionStringBuilder connStringBuilder;
        void ConnectToDb()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.InitialCatalog = "Escuela";
            connStringBuilder.Encrypt = true;
            connStringBuilder.TrustServerCertificate = true;
            connStringBuilder.ConnectTimeout = 30;
            connStringBuilder.AsynchronousProcessing = true;
            connStringBuilder.MultipleActiveResultSets = true;
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
            comm = conn.CreateCommand();
        }
        public List<Carrera> GetAllBachelors()
        {
            List<Carrera> list = new List<Carrera>();
            try
            {
                comm.CommandText = "Select * from Carrera";
                comm.CommandType = CommandType.Text;
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Carrera person = new Carrera()
                    {
                        id_carrera = Convert.ToInt32(reader[0]),
                        carrera = reader[1].ToString(),
                       
                    };
                    list.Add(person);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public List<Alumno> GetAllStudents()
        {
            List<Alumno> list = new List<Alumno>();
            try
            {
                comm.CommandText = "select* from Alumno inner join Carrera on Alumno.id_carrera = Carrera.id_carrera ";
                comm.CommandType = CommandType.Text;
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Carrera carrera = new Carrera()
                    {
                        id_carrera = Convert.ToInt32(reader[5]),
                        carrera = reader[7].ToString(),
                    };
                    Alumno person = new Alumno()
                    {
                        id_alumno = Convert.ToInt32(reader[0]),
                        name = reader[1].ToString(),
                        a_paterno = reader[2].ToString(),
                        a_materno = reader[3].ToString(),
                        edad = Convert.ToInt32(reader[4]),
                        id_carrera=carrera

                    };
                    list.Add(person);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public List<Alumno> FindStudent(string id)
        {
            List<Alumno> list = new List<Alumno>();
            try
            {
                comm.CommandText = "Select * from Alumno where id_alumno=@id_alumno";
                comm.Parameters.AddWithValue("id_alumno", id);
                comm.CommandType = CommandType.Text;
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Alumno person = new Alumno()
                    {
                        id_alumno = Convert.ToInt32(reader[0]),
                        name = reader[1].ToString(),
                        a_paterno = reader[2].ToString(),
                        a_materno = reader[3].ToString(),

                    };
                    list.Add(person);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}