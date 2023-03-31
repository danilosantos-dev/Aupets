using Entities.Models;

namespace Contracts;
public interface IStatusRepository : IRepositoryBase<Status>
{
    IEnumerable<Status> GetAllStatus();
    Status GetStatusById(int statusId);
    void CreateStatus(Status status);
    void UpdateStatus(Status status);
    void DeleteStatus(Status status);
}