using NSubstitute;
using NUnit.Framework;
using System;
using Tls.ThinkLikeSmart.Common.Factories;
using Tls.ThinkLikeSmart.Common.Presenters.Authentication;
using Tls.ThinkLikeSmart.Common.Storage;
using Tls.ThinkLikeSmart.Common.Views.Authentication;

namespace ThinkLikeSmart.Common.Tests.Presenters.Authentication
{
    [TestFixture]
    public class LoginPresenterTests
    {
        private LoginPresenter loginPresenter;
        private ISettings settings;
        private ILoginView loginView;
        private IStrategiesFactory factory;
        private IResourcesProvider resourcesProvider;

        [SetUp]
        public void SetUp()
        {
            settings = Substitute.For<ISettings>();
            loginView = Substitute.For<ILoginView>();
            factory = Substitute.For<IStrategiesFactory>();
            resourcesProvider = Substitute.For<IResourcesProvider>();

            loginPresenter = new LoginPresenter(loginView, factory, settings, resourcesProvider);
        }

        [Test]
        public void Constructor_ViewParamIsNull_ShouldArgumentNullExceptionThrow()
        {
            Assert.Throws<ArgumentNullException>(() => new LoginPresenter(null, factory, settings, resourcesProvider));
        }

        [Test]
        public void Constructor_FactoryParamIsNull_ShouldArgumentNullExceptionThrow()
        {
            Assert.Throws<ArgumentNullException>(() => new LoginPresenter(loginView, null, settings, resourcesProvider));
        }

        [Test]
        public void Constructor_SettingsParamIsNull_ShouldArgumentNullExceptionThrow()
        {
            Assert.Throws<ArgumentNullException>(() => new LoginPresenter(loginView, factory, null, resourcesProvider));
        }

        [Test]
        public void Constructor_ResourcesProviderParamIsNull_ShouldArgumentNullExceptionThrow()
        {
            Assert.Throws<ArgumentNullException>(() => new LoginPresenter(loginView, factory, settings, null));
        }

        [TestCase(LoginType.Phone, true)]
        [TestCase(LoginType.Email, false)]
        public void ViewCreated_RecentLoginTypeIsPhone_CountryContainerVisibilityShouldBeSetProperly(LoginType arrangedLoginType, bool expectedMode)
        {
            //Arrange
            settings.RecentLoginType.Returns(arrangedLoginType);

            //Act
            loginPresenter.ViewCreated();

            //Assert
            loginView.Received().CountryContainerVisible = expectedMode;
        }

        [Test]
        public void ViewCreated_RecentLoginTypeIsPhone_TogglePhoneLoginTypeShouldBeCalled()
        {
            //Arrange
            settings.RecentLoginType.Returns(LoginType.Phone);

            //Act
            loginPresenter.ViewCreated();

            //Assert
            loginView.Received().TogglePhoneLoginType();
        }
        
        [Test]
        public void ViewCreated_RecentLoginTypeIsEmail_ToggleEmailLoginTypeShouldBeCalled()
        {
            //Arrange
            settings.RecentLoginType.Returns(LoginType.Email);

            //Act
            loginPresenter.ViewCreated();

            //Assert
            loginView.Received().ToggleEmailLoginType();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void HandleLoginButtonClick_AccountNameIsNullOrWhitespace_ToastShouldBeShowed(string arrangedAccountName)
        {
            //Arrange
            loginView.AccountName.Returns(arrangedAccountName);
            loginView.Password.Returns("some password");

            //Act
            loginPresenter.HandleLoginButtonClick();

            //Assert
            loginView.Received().ShowInvalidAccountNameToast();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void HandleLoginButtonClick_PasswordIsNullOrWhitespace_ToastShouldBeShowed(string arrangedAccountName)
        {
            //Arrange
            loginView.AccountName.Returns("some account name");
            loginView.Password.Returns(arrangedAccountName);

            //Act
            loginPresenter.HandleLoginButtonClick();

            //Assert
            loginView.Received().ShowInvalidPasswordToast();
        }

        [TearDown]
        public void TearDown()
        {
            settings = null;
            loginView = null;
            loginPresenter = null;
            resourcesProvider = null;
        }
    }
}
