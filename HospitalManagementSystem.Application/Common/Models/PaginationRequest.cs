namespace HospitalManagementSystem.Application.Common.Models;

public class PaginationRequest
{
    private const int MaxPageSize = 10;

    public int PageNumber { get; set; } = 1;


    private int _pageSize = 10;

    // Filtering
    public string? SearchTerm { get; set; }

    public string? Gender { get; set; }

    // Sorting
    public string SortColumn { get; set; } = "Id";

    public int PageSize
    {
        get => _pageSize;

        set
        {
            _pageSize =
                value > MaxPageSize
                ? MaxPageSize
                : value;
        }
    }
}