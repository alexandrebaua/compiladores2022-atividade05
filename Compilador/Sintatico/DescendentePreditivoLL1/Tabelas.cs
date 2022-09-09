using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Sintatico.DescendentePreditivoLL1
{
    public static class Tabelas
    {
        private static Dictionary<string, Dictionary<string, string[]>> tabelaM = null;
        private static List<string> terminais = null;

        public static Dictionary<string, Dictionary<string, string[]>> TabelaM
        {
            get
            {
                if (Tabelas.tabelaM == null)
                    Tabelas.InitTabelaM();

                return Tabelas.tabelaM;
            }
        }

        public static List<string> Terminais
        {
            get
            {
                if (Tabelas.terminais == null)
                    Tabelas.InitListTerminais();

                return Tabelas.terminais;
            }
        }

        public static string[] BuscaProducao(string topo, string x)
        {
            if (Tabelas.TabelaM.ContainsKey(topo))
            {
                if (Tabelas.tabelaM[topo].ContainsKey(x))
                    return Tabelas.tabelaM[topo][x];
            }

            return null;
        }

        public static bool IsTerminal(string x)
        {
            return !(x.StartsWith("<") && x.EndsWith(">"));
            //return !x.StartsWith("<");
        }

        private static void InitTabelaM()
        {
            Tabelas.tabelaM = new Dictionary<string, Dictionary<string, string[]>>();

            Dictionary<string, string[]> temp = new Dictionary<string, string[]>();
            temp.Add("FUNCTION", new string[] { "FUNCTION", "ID", "ABRE_PAR", "<FUNC_BLOCO_PARAMETRO>", "ABRE_BLOCO", "<LISTA_BLOCO>" });
            Tabelas.tabelaM.Add("<FUNCTION>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("INT", new string[] { "<FUNC_PARAMETRO>", "<FUNC_LISTA_PARAMETRO>" });
            temp.Add("FECHA_PAR", new string[] { "FECHA_PAR" });
            Tabelas.tabelaM.Add("<FUNC_BLOCO_PARAMETRO>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("INT", new string[] { "INT", "ID" });
            Tabelas.tabelaM.Add("<FUNC_PARAMETRO>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("VIRGULA", new string[] { "VIRGULA", "<FUNC_PARAMETRO>", "<FUNC_LISTA_PARAMETRO>" });
            temp.Add("FECHA_PAR", new string[] { "FECHA_PAR" });
            Tabelas.tabelaM.Add("<FUNC_LISTA_PARAMETRO>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("INT", new string[] { "<DECLARA_VAR>", "<LISTA_BLOCO>" });
            temp.Add("ID", new string[] { "<ATRIB>", "<LISTA_BLOCO>" });
            temp.Add("IF", new string[] { "<SEL_IF>", "<LISTA_BLOCO>" });
            temp.Add("WHILE", new string[] { "<ENQUANTO>", "<LISTA_BLOCO>" });
            temp.Add("PRINT", new string[] { "<IMPRIME>", "<LISTA_BLOCO>" });
            temp.Add("FECHA_BLOCO", new string[] { "FECHA_BLOCO" });
            Tabelas.tabelaM.Add("<LISTA_BLOCO>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("INT", new string[] { "INT", "ID", "PONTO_VIRGULA" });
            Tabelas.tabelaM.Add("<DECLARA_VAR>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("ID", new string[] { "ID", "ATRIBUICAO", "<VAR>" });
            Tabelas.tabelaM.Add("<ATRIB>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("ID", new string[] { "ID", "<OPERACAO>" });
            temp.Add("CONST", new string[] { "CONST", "<OPERACAO>" });
            Tabelas.tabelaM.Add("<VAR>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("MENOS", new string[] { "MENOS", "<VAR>" });
            temp.Add("MAIS", new string[] { "MAIS", "<VAR>" });
            temp.Add("ASTERISTICO", new string[] { "ASTERISTICO", "<VAR>" });
            temp.Add("BARRA_ESQUERDA", new string[] { "BARRA_ESQUERDA", "<VAR>" });
            temp.Add("PONTO_VIRGULA", new string[] { "PONTO_VIRGULA" });
            Tabelas.tabelaM.Add("<OPERACAO>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("IF", new string[] { "IF", "ABRE_PAR", "<COMP_CONDICIONAL>", "FECHA_PAR", "ABRE_BLOCO", "<LISTA_BLOCO>" });
            Tabelas.tabelaM.Add("<SEL_IF>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("ID", new string[] { "ID", "<COMPARADOR>", "<VAR_COMP>" });
            temp.Add("CONST", new string[] { "CONST", "<COMPARADOR>", "<VAR_COMP>" });
            Tabelas.tabelaM.Add("<COMP_CONDICIONAL>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("MAIOR", new string[] { "MAIOR" });
            temp.Add("MENOR", new string[] { "MENOR" });
            temp.Add("IGUALDADE", new string[] { "IGUALDADE" });
            temp.Add("DIFERENTE", new string[] { "DIFERENTE" });
            Tabelas.tabelaM.Add("<COMPARADOR>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("ID", new string[] { "ID" });
            temp.Add("CONST", new string[] { "CONST" });
            Tabelas.tabelaM.Add("<VAR_COMP>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("WHILE", new string[] { "WHILE", "ABRE_PAR", "<COMP_CONDICIONAL>", "FECHA_PAR", "ABRE_BLOCO", "<LISTA_BLOCO>" });
            Tabelas.tabelaM.Add("<ENQUANTO>", temp);

            temp = new Dictionary<string, string[]>();
            temp.Add("PRINT", new string[] { "PRINT", "ABRE_PAR", "ID", "FECHA_PAR", "PONTO_VIRGULA" });
            Tabelas.tabelaM.Add("<IMPRIME>", temp);
            /*
            temp = new Dictionary<string, string[]>();
            temp.Add("", new string[] { "", "" });
            Tabelas.tabelaM.Add("<>", temp);
            */
        }

        private static void InitListTerminais()
        {
            Tabelas.terminais = new List<string>();
            Tabelas.terminais.Add("ID");
            Tabelas.terminais.Add("IF");
            Tabelas.terminais.Add("CONST");
            Tabelas.terminais.Add("ESPACO");
            Tabelas.terminais.Add("ABRE_PAR");
            Tabelas.terminais.Add("FECHA_PAR");
            Tabelas.terminais.Add("MAIOR");
            Tabelas.terminais.Add("ABRE_BLOCO");
            Tabelas.terminais.Add("FOR");
            Tabelas.terminais.Add("PRINT");
            Tabelas.terminais.Add("MENOR");
            Tabelas.terminais.Add("FECHA_BLOCO");
            Tabelas.terminais.Add("MENOS");
            Tabelas.terminais.Add("MAIS");
            Tabelas.terminais.Add("ASTERISTICO");
            Tabelas.terminais.Add("BARRA_ESQUERDA");
            Tabelas.terminais.Add("ATRIBUICAO");
            Tabelas.terminais.Add("IGUALDADE");
            Tabelas.terminais.Add("?");
            Tabelas.terminais.Add("DIFERENTE");
            Tabelas.terminais.Add("WHILE");
            Tabelas.terminais.Add("INT");
            Tabelas.terminais.Add("VIRGULA");
            Tabelas.terminais.Add("PONTO_VIRGULA");
            Tabelas.terminais.Add("FUNCTION");
        }
    }
}
