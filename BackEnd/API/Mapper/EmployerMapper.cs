using API.Dtos.EmployerDto;
using API.Models;

namespace API.Mapper;

public static class EmployerMapper
{
    public static EmployerDto ToEmployerDto(this Employer employerModel)
    {
        return new EmployerDto
        {
            Id = employerModel.Id,
            Name = employerModel.Name,
            Surname = employerModel.Surname,
            CreatedOn = employerModel.CreatedOn,
            OrganizationTitle = employerModel.OrganizationTitle
        };
    }

    public static Employer ToEmployerFromCreateEmployerDto(this CreateEmployerDto employerDto)
    {
        return new Employer
        {
            Name = employerDto.Name,
            Surname = employerDto.Surname,
            CreatedOn = employerDto.CreatedOn,
            OrganizationTitle = employerDto.OrganizationTitle
        };
    }
}