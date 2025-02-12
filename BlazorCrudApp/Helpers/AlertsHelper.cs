using Microsoft.JSInterop;

namespace BlazorCrudApp.Helpers;

public class AlertsHelpers
{
    private readonly IJSRuntime _jsRuntime;

    public AlertsHelpers(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ShowInfoAlert(string title, string message)
    {
        await _jsRuntime.InvokeVoidAsync("Alerts.showInfoAlert", title, message);
    }

    public async Task<bool> ShowConfirmationAlert(string title, string message)
    {
        return await _jsRuntime.InvokeAsync<bool>("Alerts.showConfirmationAlert", title, message);
    }
}
