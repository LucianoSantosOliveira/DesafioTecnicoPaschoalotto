using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoPaschoalotto.objetos
{
    internal class Resultado
    {
        public Resultado()
        {
            this.wordsPerMinute = "";
            this.keyStrokes = "";
            this.correctWords = "";
            this.WrongWords = ""; 
        }
        public string wordsPerMinute { get; set; }
        public string keyStrokes { get; set; }
        public string correctWords { get; set; }
        public string WrongWords { get ; set; }
    }
}
