using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HosptialMangement1.Models
{
    public class PatientModelManger
    {
        public List<Patient> GetPatients()
        {
            SqlConnection connection = new SqlConnection(@"data source = LAPTOP-LS03CNJK; initial catalog = eee_hosptial;integrated security=sspi");
            SqlCommand command = new SqlCommand("select * from patient", connection);
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            List<Patient> patients = new List<Patient>();
            while(sqlDataReader.Read())
            {
                Patient patient = new Patient();
                patient.Pid = Convert.ToInt32(sqlDataReader["pid"]);
                patient.Fname = sqlDataReader["fname"].ToString();
                patient.Lname = sqlDataReader["lname"].ToString();
                patient.Age = Convert.ToInt32(sqlDataReader["age"]);
                patient.Bg = sqlDataReader["bg"].ToString();

                patients.Add(patient);
            }
            return patients;
        }

        public Patient GetPatientById(int id) 
        {
            SqlConnection connection = new SqlConnection(@"data source = LAPTOP-LS03CNJK; initial catalog = eee_hosptial;integrated security=sspi");
            SqlCommand command = new SqlCommand($"select * from patient where pid= {id}", connection);
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            Patient patient = new Patient();
            if (sqlDataReader.Read())
            {
                patient.Pid = Convert.ToInt32(sqlDataReader["pid"]);
                patient.Fname = sqlDataReader["fname"].ToString();
                patient.Lname = sqlDataReader["lname"].ToString();
                patient.Age = Convert.ToInt32(sqlDataReader["age"]);
                patient.Bg = sqlDataReader["bg"].ToString();
            }
            return patient;
        }

        public int CreatePatient(Patient patient)
        {
            SqlConnection connection = new SqlConnection(@"data source = LAPTOP-LS03CNJK; initial catalog = eee_hosptial;integrated security=sspi");
            string query = string.Format("insert into patient(fname,lname,age,bg) values('{0}','{1}','{2}','{3}')", patient.Fname, patient.Lname, patient.Age, patient.Bg);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int insertedRows = command.ExecuteNonQuery();
            return insertedRows;
        }

        public int UpdatePatient(Patient patient)
        {
            SqlConnection connection = new SqlConnection(@"data source = LAPTOP-LS03CNJK; initial catalog = eee_hosptial;integrated security=sspi");
            string query = string.Format("update patient set fname ='{0}',lname ='{1}',age ='{2}',bg ='{3}' where pid='{4}' ", patient.Fname, patient.Lname, patient.Age, patient.Bg, patient.Pid);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int updatedRows = command.ExecuteNonQuery();
            return updatedRows;
        }

        public int DeletePatient(int id)
        {
            SqlConnection connection = new SqlConnection(@"data source = LAPTOP-LS03CNJK; initial catalog = eee_hosptial;integrated security=sspi");
            string query = string.Format("delete patient where pid ={0}",id);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int deletedRows = command.ExecuteNonQuery();
            return deletedRows;
        }

    }
}