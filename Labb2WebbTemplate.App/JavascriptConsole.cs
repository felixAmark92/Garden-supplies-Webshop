using Microsoft.JSInterop;

namespace Labb2WebbTemplate.App;

public class JavascriptConsole(IJSRuntime jsRuntime)
{
    public void Log<T>(T value)
    {
        Task.Run(() =>
        {
            jsRuntime.InvokeAsync<T>("console.log", value);
        });
    }
}