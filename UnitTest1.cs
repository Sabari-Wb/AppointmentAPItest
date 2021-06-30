
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ScheduleAppointment.Controllers;
using ScheduleAppointment.Model;
using ScheduleAppointment.Provider;
using ScheduleAppointment.Repository;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        Appointment p1;
        Mock<IAppointmentProvider> mockAppointmentprovider = new Mock<IAppointmentProvider>();
        Mock<IAppointmentRepo> mockAppointmentrepo = new Mock<IAppointmentRepo>();

        [SetUp]
        public void setup()
        {
            DateTime j = Convert.ToDateTime("21/12/2021");
            DateTime d = Convert.ToDateTime("10:00");
            DateTime a = Convert.ToDateTime("11:00");
            p1 = new Appointment(1, 3, "General", "Sham", j, d, a);
            Mock<IAppointmentProvider> mockAppointmentprovider = new Mock<IAppointmentProvider>();
            Mock<IAppointmentRepo> mockAppointmentrepo = new Mock<IAppointmentRepo>();
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
        }
        [Test]

        public void getallAppointmentdetailstest()
        {


            List<Appointment> appointments = new List<Appointment>();
            appointments.Add(p1);
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.GetAppointmentdetails()).Returns(appointments);
            mockAppointmentprovider.Setup(n => n.GetAppointmentdetails()).Returns(appointments);
            // var obj = c.GetAppointmentDetails() as OkObjectResult;
            //  Assert.AreEqual(200, obj.StatusCode);

        }


        [Test]

        public void getAppointmentdetailbyidtest()
        {
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.GetAppointmentdetailById(1)).Returns(p1);
            mockAppointmentprovider.Setup(n => n.GetAppointmentdetailById(1)).Returns(p1);
            // var obj = c.GetAppointmentdetailbyID(1)as OkObjectResult;
            // Assert.AreEqual(200, obj.StatusCode);
        }
        [Test]
        public void insertAppointmentdetailtest()
        {
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.AddNewAppointment(p1));
            mockAppointmentprovider.Setup(n => n.AddNewAppointment(p1));
            //  var obj = c.PostAppointment(p1) as CreatedAtActionResult;
            //  Assert.AreEqual(201, obj.StatusCode);
        }
        [Test]
        public void updateAppointmentdetailstest()
        {
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.UpdateAppointmentdetail(1, p1));
            mockAppointmentprovider.Setup(n => n.UpdateAppointmentdetail(1, p1));
            //  var obj = c.PutAppointment(1, p1) as NoContentResult;
            //  Assert.AreEqual(204, obj.StatusCode);
        }
        [Test]
        public void deleteAppointmenttest()
        {
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.DeleteAppointmentdetail(1));
            mockAppointmentprovider.Setup(n => n.DeleteAppointmentdetail(1));
            var obj = c.DeleteAppointment(1) as NoContentResult;
            Assert.AreEqual(204, obj.StatusCode);
        }

        //provider unit test
        [Test]
        public void AppointmentdetailsExists()
        {
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.AppointmentdetailExists(1)).Returns(true);
            mockAppointmentprovider.Setup(n => n.AppointmentdetailExists(1)).Returns(true);
            bool obj = p.AppointmentdetailExists(1);
            Assert.AreEqual(true, obj);
        }
        [Test]
        public void getAppointmentdetailsbyidTestp()
        {
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.GetAppointmentdetailById(1)).Returns(p1);
            mockAppointmentprovider.Setup(n => n.GetAppointmentdetailById(1)).Returns(p1);
            Appointment obj = p.GetAppointmentdetailById(1);
            Assert.AreEqual("Sham", obj.DoctorName);
        }
        [Test]
        public void getallAppointmentdetailsTestp()
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments.Add(p1);
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.GetAppointmentdetails()).Returns(appointments);
            mockAppointmentprovider.Setup(n => n.GetAppointmentdetails()).Returns(appointments);
            var obj = p.GetAppointmentdetails();
            Assert.AreEqual(1, obj.Count);
        }
        [Test]
        public void insertAppointmentdetailtestp()
        {
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.AddNewAppointment(p1)).Returns(p1);
            mockAppointmentprovider.Setup(n => n.AddNewAppointment(p1)).Returns(p1);
            var obj = p.AddNewAppointment(p1);
            Assert.AreEqual("Sham", obj.DoctorName);
        }
        [Test]
        public void updateAppointmentdetailstestp()
        {
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.UpdateAppointmentdetail(1, p1)).Returns(p1);
            mockAppointmentprovider.Setup(n => n.UpdateAppointmentdetail(1, p1)).Returns(p1);
            var obj = p.UpdateAppointmentdetail(1, p1);
            Assert.AreEqual("Sham", obj.DoctorName);
        }
        [Test]
        public void deleteAppointmenttestp()
        {
            AppointmentProvider p = new AppointmentProvider(mockAppointmentrepo.Object);
            AppointmentsController c = new AppointmentsController(mockAppointmentprovider.Object);
            mockAppointmentrepo.Setup(r => r.DeleteAppointmentdetail(1));
            mockAppointmentprovider.Setup(n => n.DeleteAppointmentdetail(1));
            p.DeleteAppointmentdetail(1);

        }
    }
}
