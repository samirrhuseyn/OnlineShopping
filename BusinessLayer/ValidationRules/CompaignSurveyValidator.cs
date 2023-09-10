using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CompaignSurveyValidator:AbstractValidator<CampaignSurvey>
    {
        public CompaignSurveyValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50).MinimumLength(3).WithMessage("Sorğu başlığı, 3 simvoldan az,50 simvoldan çox ola bilməz!");
            RuleFor(x => x.Description).NotEmpty().MaximumLength(1000).MinimumLength(50).WithMessage("Sorğu haqqında məlumat, 50 simvoldan az,1000 simvoldan çox ola bilməz!");
        }
    }
}
