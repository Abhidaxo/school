using FluentValidation;
using School_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_DAL.Validator
{
    public class ClassValidator : AbstractValidator<Class>
    {
        public ClassValidator() 
        {
            RuleFor(x => x.Class_Name).NotEmpty().WithMessage(" Class is Required");
        
        }
    }
}
