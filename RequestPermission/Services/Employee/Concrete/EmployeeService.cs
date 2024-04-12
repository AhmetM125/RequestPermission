using RequestPermission.Services.BaseService;
using RequestPermission.Services.Employee.Abstract;
using RequestPermission.ViewModels.Employees;

namespace RequestPermission.Services.Employee.Concrete
{
    public class EmployeeService : BaseApi, IEmployeeService
    {
        public EmployeeService(HttpClient httpClient) : base(httpClient)
        {
            ApiName = "http://localhost:5225/api/Employees/";
        }
        public async Task<List<EmployeesGridVM>> GetAllEmployees()
        {
            var response = await HttpClient.GetAsync(ApiName + "GetAllEmployees");
            if (response.IsSuccessStatusCode)
            {
                var employees = await response.Content.ReadFromJsonAsync<List<EmployeesGridVM>>();
                return employees;
            }
            return null;
        }
    }
}
