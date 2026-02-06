using FutureXcel.Backend.Shared;
using FutureXcel.Backend.Shared.Enums;

namespace FutureXcel.Frontrnd.Components.Pages
{
    public partial class SystemHealth
    {


        private bool IsLoading;
        private string LastChecked = "Never";

        private string BackendText = "--";
        private string BackendIcon = "bi-shield";
        private string BackendColor = "#38bdf8";
        private string BackendTextClass = "text-muted";

        private string DatabaseText = "--";
        private string DatabaseIcon = "bi-shield";
        private string DatabaseColor = "#38bdf8";
        private string DatabaseTextClass = "text-muted";

        private async Task CheckSystemHealth()
        {
            IsLoading = true;

            SetLoadingState();

            try
            {
                var response =
                    await Http.GetFromJsonAsync<ApiResponse<HealthStatus>>(
                        "https://localhost:7060/api/Health/health");

                if (response != null && response.IsSuccess)
                {
                    SetHealthyState();
                }
                else
                {
                    SetErrorState();
                }
            }
            catch
            {
                SetErrorState();
            }

            LastChecked = DateTime.Now.ToString("HH:mm:ss");
            IsLoading = false;
        }

        private void SetLoadingState()
        {
            BackendText = "Checking...";
            BackendIcon = "bi-arrow-repeat";
            BackendColor = "#facc15";
            BackendTextClass = "text-warning";

            DatabaseText = "Checking...";
            DatabaseIcon = "bi-arrow-repeat";
            DatabaseColor = "#facc15";
            DatabaseTextClass = "text-warning";
        }

        private void SetHealthyState()
        {
            BackendText = "Online";
            BackendIcon = "bi-shield-check";
            BackendColor = "#4ade80";
            BackendTextClass = "text-success";

            DatabaseText = "Connected";
            DatabaseIcon = "bi-database-check";
            DatabaseColor = "#4ade80";
            DatabaseTextClass = "text-success";
        }

        private void SetErrorState()
        {
            BackendText = "Down";
            BackendIcon = "bi-exclamation-octagon";
            BackendColor = "#f87171";
            BackendTextClass = "text-danger";

            DatabaseText = "Disconnected";
            DatabaseIcon = "bi-database-x";
            DatabaseColor = "#f87171";
            DatabaseTextClass = "text-danger";
        }
    }

}

