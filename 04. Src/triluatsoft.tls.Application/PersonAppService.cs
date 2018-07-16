using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Domain.Chat;

namespace triluatsoft.tls
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);
        Task CreatePerson(CreatePersonInput input);

    }
    [AutoMapTo(typeof(Person))]
    public class CreatePersonInput
    {
        [Required]
        [MaxLength(Person.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(Person.MaxSurnameLength)]
        public string Surname { get; set; }

        [EmailAddress]
        [MaxLength(Person.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}
