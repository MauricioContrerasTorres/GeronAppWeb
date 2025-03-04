//using Microsoft.AspNetCore.Components;

using Macaner.GeronAppWeb.Service.Interface;

public class LoadingService
{
    public event Action<bool> OnLoadingChanged;

    public void SetLoading(bool isLoading)
    {
        OnLoadingChanged?.Invoke(isLoading);
    }
}