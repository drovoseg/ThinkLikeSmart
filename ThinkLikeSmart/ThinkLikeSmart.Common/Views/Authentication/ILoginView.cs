namespace Tls.ThinkLikeSmart.Common.Views.Authentication
{
    public interface ILoginView : ISystemView
    {
        bool CountryContainerVisible { get; set; }

        string AccountName { get; set; }

        string Password { get; set; }

        bool RememberPasswordToggled { get; set; }

        string CountryPhoneCode { get; set; }

        string CountryName { get; set; }

        void TogglePhoneLoginType();

        void ToggleEmailLoginType();

        void SetAccountNamePhoneHint();

        void SetAccountNameEmailHint();
    }
}