using FluentValidation;
using School_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_DAL.Validator
{
    public class StudentValidator : AbstractValidator<Student>

    {
       public StudentValidator() {
            RuleFor(c => c.Student_Name).NotEmpty()
                        .WithMessage(" Name is Required");
            RuleFor(x => x.Student_Name).Length(4, 50).WithMessage("Name must atleste 4 letters");
        }
    }
}
