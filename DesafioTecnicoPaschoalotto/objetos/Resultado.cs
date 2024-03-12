using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoPaschoalotto.objetos
{
    public class Resultado
    {
        public Resultado()
        {
            this.wordsPerMinute = "";
            this.keyStrokes = "";
            this.correctWords = 0;
            this.WrongWords = 0; 
        }
        public string? wordsPerMinute { get; set; }
        public string? keyStrokes { get; set; }
        public int? correctWords { get; set; }
        public int? WrongWords { get ; set; }
    }
}
