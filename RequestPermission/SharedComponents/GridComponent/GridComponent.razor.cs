using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace RequestPermission.SharedComponents.GridComponent
{
    public partial class GridComponent : ComponentBase
    {
        [Parameter] public List<dynamic> Items { get; set; }
        List<string> ColumnNames { get; set; } = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            SetGridColumnNames();
            await base.OnInitializedAsync();
        }
        void SetGridColumnNames()
        {
            foreach (var item in Items)
            {
                Type type = item.GetType();
                PropertyInfo[] properties = type.GetProperties();

                foreach (var prop in properties)
                {
                    string propName = prop.Name;
                    object propValue = prop.GetValue(item);

                }
            }

        }
    }
}
