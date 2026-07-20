using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Test.Domain.Entities
{
    [TestClass]
    public class AppointmentTest
    {
        private Guid _patientId = Guid.NewGuid();
        private Guid _dentistId = Guid.NewGuid();
        private Guid _dentalOfficeId = Guid.NewGuid();

        private TimeInterval _timeInterval = new(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

        [TestMethod]
        public void Constructor_ValidAppointment_StatusIsScheduled()
        {
            var appoiment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);

            Assert.AreEqual(_patientId, appoiment.PatientId);
            Assert.AreEqual(_dentistId, appoiment.DentistId);
            Assert.AreEqual(_dentalOfficeId, appoiment.DentalOfficeId);
            Assert.AreEqual(_timeInterval, appoiment.TimeInterval);
            Assert.AreEqual(AppointmentStatus.Scheduled, appoiment.Status);
            Assert.AreNotEqual(Guid.Empty, appoiment.Id);
        }

        [TestMethod]
        public void Contructor_StartTimeInThePast_Throws()
        {
            var interval = new TimeInterval(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
            Assert.Throws<BussinessRuleException>(() => new Appointment(_patientId, _dentistId, _dentalOfficeId, interval));
        }

        [TestMethod]
        public void Cancel_CancellingAppointment_ChengesStatusToCancelled()
        {
            var appoiment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appoiment.Cancel();
            Assert.AreEqual(AppointmentStatus.Cancelled, appoiment.Status);
        }

        [TestMethod]
        public void Cancel_CancellingAppointment_ThrowsIfStatusIsNotScheduled()
        {
            var appoiment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appoiment.Cancel();
            Assert.Throws<BussinessRuleException>(appoiment.Cancel);
        }


        [TestMethod]
        public void Complete_CompletingAppointment_ChangesStatusToCompleted()
        {
            var appoiment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appoiment.Complete();
            Assert.AreEqual(AppointmentStatus.Completed, appoiment.Status);
        }

        [TestMethod]
        public void Complete_CompletingAppointment_ThrowsIfStatusIsNotScheduled()
        {
            var appoiment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appoiment.Cancel();
            Assert.Throws<BussinessRuleException>(appoiment.Complete);
        }

    }
}
