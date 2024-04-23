using Microsoft.AspNetCore.Components;
using RequestPermission.Base;
using RequestPermission.Services.Security;
using RequestPermission.ViewModels.Security;

namespace RequestPermission.Components.Pages
{
    public partial class LoginComponent : RazorBaseComponent
    {
        EmployeeLoginVM employeeLoginVM = new EmployeeLoginVM();
        [Inject] ILoginService _loginService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        void Login()
        {
            employeeLoginVM = _loginService.Login(employeeLoginVM);
            if (employeeLoginVM.LoginStatus)
            {
                NavigationManager.NavigateTo("/dashboard");
            }
        }

    }
}
