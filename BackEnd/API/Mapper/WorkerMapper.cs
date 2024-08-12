using API.Dtos.WorkerDto;
using API.Models;

namespace API.Mapper;

public static class WorkerMapper
{

    public static WorkerDto ToWorkDto(this Worker worker)
    {
        return new WorkerDto
        {
            Id = worker.Id,
            Name = worker.Name,
            Surname = worker.Surname,
            CreatedOn = worker.CreatedOn,
            JobTitle = worker.JobTitle
        };
    }


    public static Worker ToWorkerFromCreateWorkerDto(this CreateWorkerDto workerDto)
    {
        return new Worker
        {
            Name = workerDto.Name,
            Surname = workerDto.Surname,
            CreatedOn = workerDto.CreatedOn,
            JobTitle = workerDto.JobTitle
        };
    }
}