using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RotuloCodigoFonte
{
    public class Rotulo
    {
        private List<Resultado> listresultado;

        public List<Resultado> ListResultado
        {
            get { return listresultado; }
            set { listresultado = value; }
        }

        public static void SetRotulo(Rotulo rotulo)
        {
            HttpContext.Current.Session["rotulo"] = rotulo;
        }

        public static Rotulo GetRotulo()
        {
            return (Rotulo)HttpContext.Current.Session["rotulo"];
        }

        public string[] GetLines(string text)
        {
            text = text.Replace("\r", "");
            string[] result = text.Split('\n');

            return result;
        }

        public void AnalizaCodigo(string[] linhas)
        {
            this.ListResultado = new List<Resultado>();

            try
            {
                for (int i = 0; i < linhas.Length; i++)
                {
                    string linha = linhas[i];
                    ListResultado.Add(Resultado.Identificar(i, linha));
                }
                SetRotulo(this);
            }
            catch
            {
            }
        }

        public class Resultado
        {
            private int linha;
            private string itendificacao;

            public int Linha
            {
                get { return linha; }
                set { linha = value; }
            }
            public string Identificacao
            {
                get { return itendificacao; }
                set { itendificacao = value; }
            }

            public Resultado(int linha, string identificacao)
            {
                this.Linha = linha;
                this.Identificacao = identificacao;
            }

            public static Resultado Identificar(int numLinha, string linha)
            {
                //identificar
                //string padrao = @"^\w+a$|a$";

                //Regex regex = new Regex(padrao).is;

                linha = linha.Trim();
                try
                {
                    string mensagem = string.Empty;
                    Identificacao id = new Identificacao();

                    if (id.ehIgnorar(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehBiblioteca(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehNamespace(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehClasse(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehMetodo(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehComentario(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehRetorno(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehOperacaoMatematica(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehRepeticao(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehVariavel(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehCondicao(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehIncioBloco(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    if (id.ehFimBloco(linha, ref mensagem))
                    {
                        return new Resultado(numLinha, mensagem);
                    }
                    return new Resultado(numLinha, "Linha Não Identificada");
                }
                catch
                {
                    return new Resultado(numLinha, "Erro ao Identificar Linha");
                }
            }
        }
    }
}