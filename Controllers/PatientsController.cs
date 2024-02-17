using HosptialMangement1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HosptialMangement1.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patients
        public ViewResult GetAllPatients()
        {
            PatientModelManger modelManger = new PatientModelManger();
            List<Patient> patients1 = modelManger.GetPatients();
            List<Patient> patients = patients1;

            return View(patients);
        }
        [HttpGet]
        public ViewResult CreatePatients()
        {
            Patient patient = new Patient();
            return View(patient);
        }
        [HttpPost]
        public ActionResult CreatePatients(Patient patient)
        {
            PatientModelManger modelManger = new PatientModelManger();
            int insertedRow = modelManger.CreatePatient(patient);
            if (insertedRow > 0)
            {
                return RedirectToAction("GetAllPatients");
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdatePatient(int id)
        {
            PatientModelManger modelManger = new PatientModelManger();
            Patient patient = modelManger.GetPatientById(id);
            return View(patient);
        }

        [HttpPost]
        public ActionResult UpdatePatient(Patient patient)
        {
            PatientModelManger modelManger = new PatientModelManger();
            int updatedRows = modelManger.UpdatePatient(patient);
            if (updatedRows > 0)
            {
                return RedirectToAction("GetAllPatients");
            }
            return View(patient);
        }

        public ActionResult DeletePatient(int id)
        {
            PatientModelManger modelManger = new PatientModelManger();
            int deletedRows = modelManger.DeletePatient(id);
            if (deletedRows > 0)
            {
                return RedirectToAction("GetAllPatients");
            }
            return View();
        }

    }
}