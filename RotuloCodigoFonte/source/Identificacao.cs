using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RotuloCodigoFonte
{
    public class Identificacao
    {
        private bool Identifica(string padrao, string texto)
        {
            Regex regex = new Regex(padrao, RegexOptions.None);
            return regex.IsMatch(texto);
        }

        private string ExtraiTexto(string padrao, string texto)
        {
            string result = string.Empty;
            try
            {
                Regex regex = new Regex(padrao);
                Match match = regex.Match(texto);
                result = match.Groups[match.Groups.Count - 1].Value;
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool ehIgnorar(string texto, ref string message)
        {
            if (string.IsNullOrEmpty(texto))
            {
                message = "Linha Ignorada";
                return true;
            }
            if (texto == " ")
            {
                message = "Linha Ignorada";
                return true;
            }
            string padrao = @"^\s+\s$";
            if (Identifica(padrao, texto))
            {
                message = "Linha Ignorada";
                return true;
            }
            return false;
        }

        public bool ehIncioBloco(string texto, ref string message)
        {
            string padrao = @"(^\{|^+\s+\{|^\s+\{+\s)";
            if (Identifica(padrao, texto))
            {
                message = "Inicio de Bloco de Codigo";
                return true;
            }
            return false;
        }

        public bool ehFimBloco(string texto, ref string message)
        {
            string padrao = @"(^\}|^+\s+\}|^\s+\}+\s)";
            if (Identifica(padrao, texto))
            {
                message = "Fim de Bloco de Codigo";
                return true;
            }
            return false;
        }

        public bool ehBiblioteca(string texto, ref string message)
        {
            string padrao = @"^(using|\s+using|\s+using+\s)+(([A-Za-z0-9]|\s+[A-Za-z0-9])|([A-Za-z0-9]|\s+[A-Za-z0-9])[._]+[A-Za-z0-9])";
            if (Identifica(padrao, texto))
            {
                message = "Declaracao de Biblioteca";
                return true;
            }
            return false;
        }

        public bool ehNamespace(string texto, ref string message)
        {
            string padrao = @"^(namespace|\s+namespace)+\s+[A-Za-z0-9]";
            if (Identifica(padrao, texto))
            {
                padrao = @"^(namespace|\s+namespace)+\s+([A-Za-z0-9]{1,200})";
                message = "Declaracao de Namespace (" + ExtraiTexto(padrao, texto) + ")";
                return true;
            }
            return false;
        }

        public bool ehClasse(string texto, ref string message)
        {
            string padrao = @"^((public|\s+public|\s+public\s)|(protected|\s+protected|\s+protected\s)|(internal|\s+internal|\s+internal\s)|(protected+\s+internal|\s+protected+\s+internal|\s+protected+\s+internal\s)|(private|\s+private|\s+private\s))+\s+class+\s+[A-Za-z0-9]";
            if (Identifica(padrao, texto))
            {
                padrao = @"^((public|\s+public|\s+public\s)|(protected|\s+protected|\s+protected\s)|(internal|\s+internal|\s+internal\s)|(protected+\s+internal|\s+protected+\s+internal|\s+protected+\s+internal\s)|(private|\s+private|\s+private\s))+\s+class+\s+([A-Za-z0-9]{1,200})";
                message = "Declaracao de Classe (" + ExtraiTexto(padrao, texto) + ")";
                return true;
            }
            return false;
        }

        public bool ehMetodo(string texto, ref string message)
        {
            string padrao = @"^((public|\s+public|\s+public\s)|(protected|\s+protected|\s+protected\s)|(internal|\s+internal|\s+internal\s)|(protected+\s+internal|\s+protected+\s+internal|\s+protected+\s+internal\s)|(private|\s+private|\s+private\s))+\s+[A-Za-z0-9]+\s+[A-Za-z0-9]";
            if (Identifica(padrao, texto))
            {
                padrao = @"^((public|\s+public|\s+public\s)|(protected|\s+protected|\s+protected\s)|(internal|\s+internal|\s+internal\s)|(protected+\s+internal|\s+protected+\s+internal|\s+protected+\s+internal\s)|(private|\s+private|\s+private\s))+\s+[A-Za-z0-9]+\s+([A-Za-z0-9]{1,200})";
                message = "Declaracao de Metodo (" + ExtraiTexto(padrao, texto) + ")";
                return true;
            }
            return false;
        }

        public bool ehComentario(string texto, ref string message)
        {
            string padrao = @"//";
            if (Identifica(padrao, texto))
            {
                message = "Comentario de Codigo";
                return true;
            }
            return false;
        }

        public bool ehRetorno(string texto, ref string message)
        {
            string padrao = @"^(return|\s+return)";
            if (Identifica(padrao, texto))
            {
                message = "Retorno de Metodo";
                return true;
            }
            return false;
        }

        public bool ehOperacaoMatematica(string texto, ref string message)
        {
            string padrao = @"[\w\s][A-Za-z0-9][\w\s]+[\-\+\*\/]";
            if (Identifica(padrao, texto))
            {
                message = "Operacao Matemática";
                return true;
            }
            return false;
        }

        public bool ehVariavel(string texto, ref string message)
        {
            //double temp = calcularMultiplicacao(valueMulti, n);
            string padrao = @"[A-Za-z0-9]+\s+[A-Za-z0-9]+\s+\=+\s+[A-Za-z0-9]";
            if (Identifica(padrao, texto))
            {
                message = "Atribuição de valores a uma Variável";
                return true;
            }
            return false;
        }

        public bool ehRepeticao(string texto, ref string message)
        {
            string padrao = @"^((for|\s+for|\s+for+\s)|(while|\s+while|\s+while+\s)|(foreach|\s+foreach|\s+foreach+\s))";
            if (Identifica(padrao, texto))
            {
                message = "Estrutura de Controle de Repeticao";
                return true;
            }
            return false;
        }

        public bool ehCondicao(string texto, ref string message)
        {
            string padrao = @"(if+(\(|\s)|else)";
            if (Identifica(padrao, texto))
            {
                message = "Estrutura de Controle Condicional";
                return true;
            }
            return false;
        }
    }
}