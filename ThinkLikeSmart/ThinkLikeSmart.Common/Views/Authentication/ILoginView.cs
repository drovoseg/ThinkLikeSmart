using Tls.ThinkLikeSmart.Common.Interfaces.Views;

namespace Tls.ThinkLikeSmart.Common.Views.Authentication
{
    public interface ILoginView : ISystemView
    {
        bool IsCountryContainerVisible { get; set; }
        void TogglePhoneLoginType();
        void ToggleEmailLoginType();
    }
}