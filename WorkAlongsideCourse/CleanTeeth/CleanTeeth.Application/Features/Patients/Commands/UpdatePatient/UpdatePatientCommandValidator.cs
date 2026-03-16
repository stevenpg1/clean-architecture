using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("the field {PropertyName} required.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("the field {PropertyName} required.")
                .EmailAddress().WithMessage("Invalid email format");
        }
    }
}
