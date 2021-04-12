using System;
using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain
{
    public class Note:BaseNote, IPatientContainer,IDoctorContainer
    {
        public int Id { get; set; }
        
        public DateTime DateVisit { get; set; }
    }
}