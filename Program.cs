using System;

namespace exemplo2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Criacao do documento
                // Cria um documento com o nome exemploDoc

                Document exemploDoc = new Document();
                
            #endregion

            #region Criacao de secao no documento
                // adiciona um seção capa com o nome secaoCapa ao documento
                // Cada secao pode ser entendida como uma pagina do documento

                Section secaoCapa = exemploDoc.AddSection();
            
            #endregion

            #region Copiar um paragrafo
            // Cria um paragrafo com o nome titulo e adiciona a secao secaoCapa
            // os paragrafos são necessários para inserçao de textos, imagens, tabela etc
            
            Paragraph titulo = secaoCapa.AddParagraph();

            #endregion

            #region Adiciona texto ao paragrafo
            // Adiciona o texto exemplo de titulo ao paragrafo titulo
                titulo.AppendText("Exemplo de titulo\n\n");

            #endregion

            #region Formatar paragrafo
            // Através da propriedade HorizontalAlignment, é possivel alinhar o parágrafo 
                titulo.Format.HorizontalAlignment = HorizontalAlignment.Center;
                
            // cria um estilo com o nome estilo01 e adiciona ao documento
                ParagraphStyle estilo01 = new ParagraphStyle(exemploDoc);
                
            // adiciona um nome ao estilo01
                estilo01.Name = "Cor do titulo";

            // Definir a cor do titulo
            estilo01.CharacterFormat.TextColor = Color.DarkRed;

            // Define que o texto será em negrito
            estilo01.CharacterFormat.Bold = true;

            // Adiciona o estilo01 ao documento exemploDoc
            exemploDoc.Styles.Add(estilo01);


            // Aplica o estilo01 ao paragrafo titulo
            titulo.ApplyStyle(estilo01.Name);
            #endregion

            #region Trabalhar com tabulação
            // Adiciona um paragrafo textoCapa à seção secaoCapa
                Paragraph textoCapa = secaoCapa.AddParagraph();

            // Adiciona um texto ao paragrafo com tabulação
                textoCapa.AppendText("\tEste é um exemplo de texto com tabulação\n");   

                Paragraph textoCapa2 = secaoCapa.AddParagraph(); 

                textoCapa2.AppendText("\tBasicamente, então, uma seção representa uma página do documento e os parágrafos dentro de uma mesma seção," + "obviamente, aparecem na mesma página");           
            #endregion

            #region Inserir Imagens
                Paragraph imagemCapa = secaoCapa.AddParagraph();

                // Adiciona um texto ao parágrafo imagemCapa
                imagemCapa.AppendText("\n\n\tAgora vamos inserir uma imagem ao documento\n\n");

                imagemCapa.Format.HorizontalAlignment = HorizontalAlignment.Center;

                // Adiciona uma imagem com o nome imagemExemplo ao paragrafo imagemCapa
                DocPicture imagemExemplo = imagemCapa.AppendPicture(Image.FromFile(@"saida\img\logo_cshasrp.png"));

                // define uma largura e uma altura para a imagem
                imagemExemplo.Width = 300;
                imagemExemplo.Height = 300;

            #endregion

            #region Adicionar uma nova  seção 
            Section secaoCorpo = exemploDoc.AddSection();

            // Adiciona um parágrafo à seção secaoCorpo
            Paragraph.paragrafoCorpo1 = secaoCorpo.AddParagraph();

            // Adiciona um texto ao parágrafo paragrafocorpo1
            paragrafoCorpo1.AppendText("\tEste é um exemplo de parágrafo criado em uma nova seção." +"\tComo foi criada uma nova seção, perceba que este texto aparece em uma nova página.");

            #endregion

            #region Adicionar uma tabela
            // Adiciona uma tabela à seção secaoCorpo
            Table tabela = secaoCorpo.AddTable(true);

             // cria o cabeçalho da tabela
             string[] cabecalho = {"Item", "descrição", "Qtd","Preço Unit.","Preço"};

             string[][] dados = {
                 new String[]{"Cenoura","Vegetal muito nutritivo","1", "R$ 4,00", "R$ 4,00"},
                 new String[]{"Batata","Vegetal muito consumido","1", "R$ 5,00", "R$ 10,00"},
                 new String[]{"Alface","Vegetal utilizado desde 500 a.C.","1", "R$ 1,50", "R$ 1,50"},
                 new String[]{"Tomate","Tomate é uma fruta","2", "R$ 6,00", "R$ 12,00"},
             };

            // Adiciona as células na tabela
             tabela.ResetCells(dados.Length + 1, cabecalho.Length);

            // Adiciona uma linha na posição [0] do vetor de linhas
            // E define que esta linha é o cabecalho
             TableRow Linha1 = tabela.Rows[0];
             Linha1.IsHeader = true;

            // Define a altura da linha
             Linha1.Height = 23;

             // Formatação do cabeçalho
             Linha1.RowFormat.BackColor = Color.AliceBlue;

            // Percorre as colunas do cabecalho
             for (int i = 0; i < cabecalho.Length; i++)
             {
                
            // Alinhamento das células
                 Paragraph p = Linha1.Cells[i].AddParagraph();
                 Linha1.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment
                 .Middle;
                 p.Format.HorizontalAlignment = HorizontalAlignment.Center;

                 // Formatação dos dados do cabeçalho
                 TextRange TR = p.AppendText(cabecalho[i]);
                 TR.CharacterFormat.FontName = "Calibri";
                 TR.CharacterFormat.FontSize = 14;
                 TR.CharacterFormat.TextColor = Color.Teal;
                 TR.CharacterFormat.Bold = true;

                 

             }
             
             // Adiciona as linhas do corpo da tabela
            for (int r = 0; r < dados.Length; r++)
            {
                TableRow LinhasDados = tabela.Rows[r + 1];

                // Define a altura da linha 
                LinhasDados.Height = 20;

                // Percorre as colunas
                for (int c = 0; c < dados[r].Length; c++)
                {
                 // Alinhar as células
                 LinhasDados.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;

                 // Preenche os dados nas linhas
                 Paragraph p2 = LinhasDados.Cells[c].AddParagraph();
                 TextRange TR2 = p2.AppendText(dados[r][c]);

                 // Formata as células
                p2.Format.HorizontalAlignment = HorizontalAlignment.Center;
                TR2.CharacterFormat.FontName = "Calibri";
                TR2.CharacterFormat.FontSize = 12;
                TR2.CharacterFormat.TextColor = Color.Brown;

                
                }

            }
            #endregion

            #region Salvar Arquivo
            // Salva o Arquivo em .Docx
            // Utiliza o método SaveToFile para salvar o arquivo no formato desejado
            // Assim como no Word, caso já existia um arquivo com este nome, é substituido
            exemploDoc.SaveToFile(@"saida\exemplo_arquivo_word.docx", FileFormat.Docx);
            #endregion
        }
    }
}
