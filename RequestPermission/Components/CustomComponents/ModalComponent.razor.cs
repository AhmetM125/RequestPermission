using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using RazorLight;
using RequestPermission.Components.Pages.Employees;
using System.Reflection;

namespace RequestPermission.Components.CustomComponents
{
    public partial class ModalComponent : ComponentBase
    {
        [Inject] public IModalService ModalService { get; set; }
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public string Description { get; set; }
        [Parameter] public RenderFragment Body { get; set; }
        //[Parameter] public RenderFragment ChildrenComponent { get; set; }

        void OnCancel()
        {
            BlazoredModal.CloseAsync();
        }
        void OnConfirm()
        {
            BlazoredModal.CloseAsync();
        }
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            Title = parameters.GetValueOrDefault<string>(nameof(Title)) ?? "";
            Description = parameters.GetValueOrDefault<string>(nameof(Description)) ?? "";
            RenderDynamicComponent(parameters);
            await base.SetParametersAsync(parameters);
        }
        void RenderDynamicComponent(ParameterView parameters)
        {
            Body = builder =>
            {
                builder.OpenComponent(0, typeof(ModiyComponent));
                builder.CloseComponent();
            };


            //Console.Clear();
            //var componentName = parameters.GetValueOrDefault<string>("Body");
            //var path = Environment.CurrentDirectory;
            //var fullPath = @"C:\Users\ahmet.yurdal\Desktop\Ahmet\Csharp\Projects\RequestPermission\RequestPermission\Components\Pages\Employees\ModiyComponent.razor"
            //; var pathCombine = Path.Combine(path, "Components", "Pages", $"{componentName}.razor");
            //var type = Type.GetType("RequestPermission.Components.Pages.Employees.ModiyComponent");
            //var fullPath2 = Directory.GetCurrentDirectory();
            //var assembly = Assembly.LoadFile(fullPath2);

            ////var engine = new RazorLightEngineBuilder()
            ////                .UseFileSystemProject(type)
            ////                .Build();


            //if (componentType != null)
            //{
            //    DynamicComponent = builder =>
            //    {
            //        builder.OpenComponent(0, componentType);
            //        builder.CloseComponent();
            //    };
            //}
        }
    }
}
