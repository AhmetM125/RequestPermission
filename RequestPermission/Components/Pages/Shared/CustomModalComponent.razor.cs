using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RequestPermission.Base;

namespace RequestPermission.Components.Pages.Shared;

public partial class CustomModalComponent : RazorBaseComponent
{
    [Parameter] public string Id { get; set; }
    [Parameter] public RenderFragment Body { get; set; }
    [Parameter] public string Title { get; set; }
    [Inject] IJSRuntime JSRuntime { get; set; }


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }
    async Task CloseModal()
    {
        await JSRuntime.InvokeVoidAsync("CloseModal", Id);
    }
}





