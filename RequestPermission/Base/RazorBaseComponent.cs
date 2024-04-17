using Microsoft.AspNetCore.Components;

namespace RequestPermission.Base
{
    public class RazorBaseComponent : ComponentBase
    {

    }
    public enum PageStatus
    {
        Modify = 1,
        Insert = 2,
        List = 3,
        Delete = 4
    }
}
