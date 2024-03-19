using DesafioTecnicoPaschoalotto.objetos;
using DesafioTecnicoPaschoalotto.Utilitarios;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Text.RegularExpressions;

automacao.Program.ExecutarAutomacao();
namespace automacao
{
    public static class Program
    {
        public static void ExecutarAutomacao()
        {
            try
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

                foreach (var palavra in palavras)
                {
                    var letras = palavra.InnerText;
                    foreach (var letra in letras)
                    {
                        txtBoxInserirPalavras.SendKeys($"{letra}");
                    }
                    txtBoxInserirPalavras.SendKeys(" ");
                }
                Thread.Sleep(10000);
                htmlContend = webDriver.PageSource;
                htmlDocument.LoadHtml(htmlContend);
                var resultadosHtml = htmlDocument.GetElementbyId("auswertung-result").ChildNodes.FirstOrDefault(t => t.Name.Contains("table"));
                htmlDocument.LoadHtml(resultadosHtml.InnerHtml);
                var resultadoExtraidoDoHtml = htmlDocument.DocumentNode.SelectNodes("//tr");

                var resultado = new Resultado();
                resultado.keyStrokes = filtrarSomenteNumero(resultadoExtraidoDoHtml[1].InnerText.Trim()).ToString();
                resultado.wordsPerMinute = filtrarSomenteNumero(resultadoExtraidoDoHtml[0].InnerText).ToString();
                resultado.correctWords = filtrarSomenteNumero(resultadoExtraidoDoHtml[3].InnerText);
                resultado.WrongWords =   filtrarSomenteNumero(resultadoExtraidoDoHtml[4].InnerText);
                InserirResultados(resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro, execute a aplicação novamente {ex.Message}");
            }           
            Environment.Exit(0);       
        }
        private static int? filtrarSomenteNumero(string entrada)
        {
            Match match = Regex.Match(entrada, @"-?\d+");
            if (match.Success)
            {
                if (int.TryParse(match.Value, out int number))
                {
                    return number;
                }
            }
            return null;
        }
        public static void InserirResultados(Resultado resultado)
        {
            BancoDeDados banco = new BancoDeDados();
            banco.InserirResultadosNoBD(resultado);
        }
    }      
} 