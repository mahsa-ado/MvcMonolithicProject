using FirstMonolithicProject.ApplicationServices.Dtos.PersonDtos;

namespace FirstMonolithicProject.ApplicationServices.Services.Contracts
{
    public interface IPersonApplicationService
    {
        #region [- Put() -]
        Task Put(PutPersonDto putPersonDto);
        #endregion

        #region [- Delete() -]
        Task Delete(DeletePersonDto deletePersonDto);
        #endregion

        #region [- Post() -]
        Task Post(PostPersonDto postPersonDto);
        #endregion

        #region [- GetAllPerson() -]
        Task<List<GetPersonDto>> GetAllPerson();

        #endregion

        #region [- GetById() -]
        Task<PutPersonDto?> GetById(GetPersonDtoById getPersonDtoById);
        #endregion

    }
}