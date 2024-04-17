using RequestPermission.Services.BaseService;
using RequestPermission.Services.Employee.Abstract;
using RequestPermission.ViewModels.Employees;
using System.Text;
using System.Text.Json;

namespace RequestPermission.Services.Employee.Concrete;

public class EmployeeService : BaseApi, IEmployeeService
{
    public EmployeeService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "http://localhost:5225/api/Employees/";
    }

    public async Task DeleteSelectedEmployee(Guid employeeId) => await HandleDeleteResponse(employeeId, $"DeleteEmployee/{employeeId}");


    public async Task<List<EmployeesGridVM>?> GetAllEmployees()
    {
        var response = await HttpClient.GetAsync(ApiName + "GetAllEmployees");
        if (response.IsSuccessStatusCode)
        {
            var employees = await response.Content.ReadFromJsonAsync<List<EmployeesGridVM>>();
            return employees;
        }
        return default(List<EmployeesGridVM>);
    }

    public async Task<EmployeeModifyVM> GetEmployeeForModify(Guid employeeId)
    {
        var response = await HttpClient.GetAsync(ApiName + $"GetEmployeeForModify/{employeeId}");
        if (response.IsSuccessStatusCode)
        {
            var employee = await response.Content.ReadFromJsonAsync<EmployeeModifyVM>();
            return employee;
        }
        return default(EmployeeModifyVM);
    }

    public async Task InsertUser(EmployeeInsertDto employeeModifyVM)
     => await HandlePostResponseAsJson(employeeModifyVM, "InsertNewEmployee");


    public async Task UpdateUser(EmployeeModifyVM employeeModifyVM)
    {
        var content = new StringContent(JsonSerializer.Serialize(employeeModifyVM), Encoding.UTF8, "application/json");

        // Send the POST request
        var response = await HttpClient.PostAsync(ApiName + "UpdateUser", content); // BU PUT OLABILIRDI.

        // Check if the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Optionally, you can read the response content
            var responseContent = await response.Content.ReadAsStringAsync();
            // Do something with responseContent if needed
        }
        else
        {
            // If the request was not successful, handle the error
            // You can extract more information from the response if needed
            var errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            throw new Exception(errorMessage);
        }
    }
}
