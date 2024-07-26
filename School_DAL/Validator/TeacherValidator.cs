using FluentValidation;
using School_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_DAL.Validator
{
    public class TeacherValidator : AbstractValidator<Teacher>
    {
        public TeacherValidator()
        {
            RuleFor(c => c.Teacher_Name).NotEmpty()
                        .WithMessage(" Name is Required");

            RuleFor(x => x.Teacher_Name).Length(4, 50).WithMessage("Name must atleste 4 letters");

        }
    }
}
