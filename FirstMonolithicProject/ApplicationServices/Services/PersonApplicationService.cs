using FirstMonolithicProject.ApplicationServices.Dtos.PersonDtos;
using FirstMonolithicProject.ApplicationServices.Services.Contracts;
using FirstMonolithicProject.Models.Services.Contracts;
using FirstMonolithicProject.Models.DomainModels.PersonAggregates;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FirstMonolithicProject.ApplicationServices.Services
{
    public class PersonApplicationService:IPersonApplicationService
    {
        private readonly IPersonRepository _personRepository;
        #region [- ctor -]
        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        #endregion

        #region [- Put() -]
        public async Task Put(PutPersonDto putPersonDto)
        {   if(putPersonDto == null)
            { 
                return ;
            }
            var putPerson = new Person()
            {
                Id = putPersonDto.Id,
                FirstName = putPersonDto.FirstName,
                LastName = putPersonDto.LastName,
                Age = putPersonDto.Age,
            };
            await _personRepository.Update(putPerson);
        }

        #endregion

        #region [- Delete() -]
        public async Task Delete(DeletePersonDto deletePersonDto)
        {
            if(deletePersonDto == null)
            {
                return;
            }
            var deletePerson = new Person()
            {  
                Id = deletePersonDto.Id,
                FirstName = deletePersonDto.FirstName,
                LastName = deletePersonDto.LastName,
                Age = deletePersonDto.Age
            };
            await _personRepository.Delete(deletePerson);
            
        }
        #endregion

        #region [- Post() -]
        public async Task Post(PostPersonDto postPersonDto)
        {
            if(postPersonDto == null)
            {
                return;
            }
            var person = new Person()
            {
                Id = postPersonDto.Id,
                FirstName = postPersonDto.FirstName,
                LastName = postPersonDto.LastName,
                Age = postPersonDto.Age,
            };
            await _personRepository.Insert(person);
        }
        #endregion

        #region [- GetAllPerson() -]
        public async Task<List<GetPersonDto>> GetAllPerson()
        {
            var persons = await _personRepository.SelectAll();
            var getPersonDtos = new List<GetPersonDto>();
            foreach (var person in persons)
            {
                var getPersonDto = new GetPersonDto()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Age= person.Age,
                };
                getPersonDtos.Add(getPersonDto);
            }
            return getPersonDtos;
        }
        #endregion

        //check line100

        #region [- GetById() -]
        public async Task<PutPersonDto?> GetById(GetPersonDtoById getPersonDtoById)
        {
            var person = await _personRepository.SelectById(getPersonDtoById);
            if (person == null)
            {
                return null ;
            }
            var putPersonDto = new PutPersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age
            };
            return putPersonDto;
        } 
        #endregion

    }
}
