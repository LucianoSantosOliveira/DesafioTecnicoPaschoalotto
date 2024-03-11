using DesafioTecnicoPaschoalotto.objetos;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

automacao.Program.ExecutarAutomacao();
namespace automacao
{
    public static class Program
    {
        public static void ExecutarAutomacao()
        {
            var webDriver = new EdgeDriver();
            webDriver.Navigate().GoToUrl("https://10fastfingers.com/typing-test/portuguese");
            var BtndenyCookie = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div[1]/div[2]/button[1]"));
            BtndenyCookie.Click();
            var txtBoxInserirPalavras = webDriver.FindElement(By.Id("inputfield"));

            var htmlContend = webDriver.PageSource;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlContend);

            var palavras = htmlDocument.GetElementbyId("words").ChildNodes;

            foreach(var palavra in palavras)
            {
                var letras = palavra.InnerText;
                foreach(var letra in letras)
                {                   
                    txtBoxInserirPalavras.SendKeys($"{letra}");                   
                }
                txtBoxInserirPalavras.SendKeys(" ");
            }
            Environment.Exit(0);       
        }
    }      
} 

