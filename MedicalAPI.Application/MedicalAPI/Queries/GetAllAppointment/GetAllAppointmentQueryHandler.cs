using AutoMapper;
using MediatR;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetAllAppointment
{
    public class GetAllAppointmentQueryHandler : IRequestHandler<GetAllAppointmentQuery, IEnumerable<AppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAllAppointmentQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AppointmentDto>> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetAll();

            var dtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            return dtos;
        }
    }
}
