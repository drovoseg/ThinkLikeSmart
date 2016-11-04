using Tls.ThinkLikeSmart.Common.Interfaces.Views;
using Tls.ThinkLikeSmart.Common.Presenters.Authentication;

namespace Tls.ThinkLikeSmart.Common.Views.Authentication
{
    public interface ILoginView : ISystemView
    {
        VisibliltyMode CountriesContainerVisiblity { get; set; }
        void TogglePhoneLoginType();
        void ToggleEmailLoginType();
    }
}