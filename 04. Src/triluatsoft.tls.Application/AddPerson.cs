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
    public class GetPeopleInput
    {
        public string Filter { get; set; }
    }

    [AutoMapFrom(typeof(Person))]
    public class PersonListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }
    }

    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = input.MapTo<Person>();
            await _personRepository.InsertAsync(person);
        }

        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            var persons = _personRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) ||
                            p.Surname.Contains(input.Filter) ||
                            p.EmailAddress.Contains(input.Filter)
                )
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();

            return new ListResultDto<PersonListDto>(persons.MapTo<List<PersonListDto>>());
        }
    }
}
