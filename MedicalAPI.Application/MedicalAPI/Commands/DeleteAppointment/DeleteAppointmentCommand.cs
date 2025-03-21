﻿using MediatR;
using MedicalAPI.Application.MedicalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommand : IRequest<AppointmentDto>
    {
        public int AppointmentId { get; set; }

        public DeleteAppointmentCommand() { }
        public DeleteAppointmentCommand(int AppointmentId) 
        {
            this.AppointmentId = AppointmentId;
        }
    }
}
