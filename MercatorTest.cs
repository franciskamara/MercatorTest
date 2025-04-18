namespace Mercator_Test;

public class Tests
{
    private IWebDriver driver;
    
    [OneTimeSetUp]
    public void Setup()
    {
        // Open browser and navigate 
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        Console.WriteLine($"Page title: {driver.Title}");
    }

    [Test, Order(1)]
    public void InputUsername()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        IWebElement usernameInput = wait.Until(driver => driver.FindElement(By.Id("user-name")));
        usernameInput.Click();
        usernameInput.SendKeys("standard_user");

        Assert.That(usernameInput.Displayed,Is.True);
    }

    [Test, Order(2)]
    public void InputPassword()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        IWebElement passwordInput = wait.Until(driver => driver.FindElement(By.Id("password")));
        passwordInput.Click();
        passwordInput.SendKeys("secret_sauce");
        
        Assert.That(passwordInput.Displayed, Is.True);
    }

    [Test, Order(3)]
    public void ClickToLogin()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        
        IWebElement clickLoginButton = wait.Until(driver => driver.FindElement(By.Id("login-button")));
        clickLoginButton.Click();
        
        Assert.That(driver.Title, Is.EqualTo("Swag Labs"), "The page title does not match.");
    }

    [Test, Order(4)]
    public void AddHighestPricedItem()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

        IWebElement addHighestPricedItem = wait.Until(driver => driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket")));
        addHighestPricedItem.Click();
        
        // Assert.That(driver.FindElement(By.Id("remove-sauce-labs-fleece-jacket")).Displayed, Is.True);
    }
}