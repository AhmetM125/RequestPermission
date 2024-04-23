using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RequestPermission.Base;

public class CascadingLayoutBase : LayoutComponentBase
{
    [Inject] IJSRuntime JSRuntime { get; set; }
    [CascadingParameter] public MainLayoutCascadingValue LayoutValue { get; set; }

}
