using System.Threading.Tasks;
using AliFitnessAE.Configuration.Dto;

namespace AliFitnessAE.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
