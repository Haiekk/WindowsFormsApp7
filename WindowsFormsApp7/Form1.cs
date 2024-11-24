using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Drawing;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        private List<int> listaAleatoria;
        private List<int> listaOriginal;
        private int indexAtual;
        private Timer timer;
        private bool ordenando;
        private int i, j;
        private bool insertionSortAtivo;
        private Stack<(int low, int high)> pilhaQuickSort;
        private bool quickSortAtivo;
        private int low, high;
        private bool shellSortAtivo = false;
        private Stopwatch stopwatch;
        private int gap;
        private int lowBinario, highBinario, midBinario, numeroBusca;
        private bool buscaBinariaAtiva;
        private int indiceSequencial;
        private bool buscaSequencialAtiva;
        private bool ordenacaoAtiva = false;  
        private int index1 = 0;               
        private int index2 = 1;
        private int comparacoes = 0;
        private int trocas = 0;



        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += Timer_Tick;
            ordenando = false;
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt_timer.Text, out int intervalo) && intervalo > 0)
            {
                timer.Interval = intervalo;

                if (int.TryParse(txtTamanhoLista.Text, out int tamanhoLista) && tamanhoLista > 0)
                {
                    Random random = new Random();
                    listaAleatoria = new List<int>();
                    listaOriginal = new List<int>();

                    for (int i = 0; i < tamanhoLista; i++)
                    {
                        int valor = random.Next(1, 100);
                        listaAleatoria.Add(valor);
                        listaOriginal.Add(valor);
                    }

                    grf_ordenacao.Series.Clear();
                    var serie = grf_ordenacao.Series.Add("Valores Aleatórios");
                    serie.ChartType = SeriesChartType.Column;

                    indexAtual = 0;
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("Por favor, insira um número válido para o tamanho da lista.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor válido para o intervalo do timer.");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!ordenando)
            {
                if (indexAtual < listaAleatoria.Count)
                {
                    grf_ordenacao.Series[0].Points.AddY(listaAleatoria[indexAtual]);
                    indexAtual++;
                }
                else
                {
                    timer.Stop();
                }
            }
            else if (insertionSortAtivo)
            {
                if (i < listaAleatoria.Count)
                {
                    int key = listaAleatoria[i];
                    j = i - 1;

                    while (j >= 0 && listaAleatoria[j] > key)
                    {
                        comparacoes++;
                        listaAleatoria[j + 1] = listaAleatoria[j];
                        trocas++;
                        j--;
                    }
                    listaAleatoria[j + 1] = key;

                    i++;

                    grf_ordenacao.Series[0].Points.Clear();
                    foreach (var num in listaAleatoria)
                    {
                        grf_ordenacao.Series[0].Points.AddY(num);
                    }
                }
                else
                {
                    ordenando = false;
                    insertionSortAtivo = false;
                    timer.Stop();
                    stopwatch.Stop();
                    MessageBox.Show("Ordenação Insertion Sort concluída!");

                    AtualizarDataGridView();
                }
            }
            else if (shellSortAtivo)
            {
                if (gap > 0)
                {
                    // O loop externo percorre os elementos começando do índice gap.
                    if (j < listaAleatoria.Count)
                    {
                        int temp = listaAleatoria[j];
                        int k = j;

                        // Loop interno para realizar deslocamentos.
                        while (k >= gap && listaAleatoria[k - gap] > temp)
                        {
                            listaAleatoria[k] = listaAleatoria[k - gap];
                            k -= gap;
                        }

                        listaAleatoria[k] = temp;

                        j++; // Avança para o próximo índice.

                        // Atualiza o gráfico após cada iteração de j.
                        AtualizarGrafico();
                        return; // Sai para permitir a visualização gradual.
                    }
                    else
                    {
                        // Reduz o gap e reinicia o índice j.
                        gap = (int)(gap / 2.2); // Redução do gap.
                        j = gap; // Reinicia para o próximo ciclo.
                    }
                }
                else
                {
                    // Finaliza a ordenação.
                    shellSortAtivo = false;
                    ordenando = false;
                    timer.Stop();

                    MessageBox.Show("Ordenação Shell Sort concluída!");
                    AtualizarDataGridView();
                }
            }
            else
            {
                if (i < listaAleatoria.Count - 1)
                {
                    int trocaAtual = i;
                    for (j = i + 1; j < listaAleatoria.Count; j++)
                    {
                        if (listaAleatoria[j] < listaAleatoria[trocaAtual])
                        {
                            trocaAtual = j;
                        }
                    }

                    int temp = listaAleatoria[i];
                    listaAleatoria[i] = listaAleatoria[trocaAtual];
                    listaAleatoria[trocaAtual] = temp;

                    i++;

                    grf_ordenacao.Series[0].Points.Clear();
                    foreach (var num in listaAleatoria)
                    {
                        grf_ordenacao.Series[0].Points.AddY(num);
                    }
                }
                else
                {
                    timer.Stop();
                    MessageBox.Show("Ordenação Selection Sort concluída!");
                    ordenando = false;

                    AtualizarDataGridView();
                }
            }
        }

        private void btn_SelectionSort_Click(object sender, EventArgs e)
        {
            if (listaAleatoria == null || listaAleatoria.Count == 0)
            {
                MessageBox.Show("Por favor, insira os valores no gráfico antes de ordenar.");
                return;
            }

            if (int.TryParse(txt_timer.Text, out int intervalo) && intervalo > 0)
            {
                timer.Interval = intervalo;
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor válido para o intervalo do timer.");
                return;
            }

            ordenando = true;
            i = 0;
            j = 0;
            insertionSortAtivo = false;

            grf_ordenacao.Series[0].Points.Clear();
            foreach (var num in listaAleatoria)
            {
                grf_ordenacao.Series[0].Points.AddY(num);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            grf_ordenacao.Series[0].Points.Clear();
            foreach (var num in listaAleatoria)
            {
                grf_ordenacao.Series[0].Points.AddY(num);
            }

            timer.Start();

            while (timer.Enabled)
            {
                Application.DoEvents();
            }
        }

        private void btn_insertion_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaAleatoria == null || listaAleatoria.Count == 0)
                {
                    MessageBox.Show("Por favor, insira os valores no gráfico antes de ordenar.");
                    return;
                }

                if (int.TryParse(txt_timer.Text, out int intervalo) && intervalo > 0)
                {
                    timer.Interval = intervalo;
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor válido para o intervalo do timer.");
                    return;
                }

                if (stopwatch == null)
                {
                    stopwatch = new Stopwatch();
                }
                stopwatch.Reset();

                // Resetar métricas
                comparacoes = 0;
                trocas = 0;

                ordenando = true;
                insertionSortAtivo = true;
                i = 1;

                // Atualizar gráfico com os valores iniciais
                grf_ordenacao.Series[0].Points.Clear();
                foreach (var num in listaAleatoria)
                {
                    grf_ordenacao.Series[0].Points.AddY(num);
                }

                // Iniciar temporizador e cronômetro
                stopwatch.Start();
                timer.Start();

                // Após a ordenação completa, atualizar informações no RichTextBox
                timer.Tick += (s, ev) =>
                {
                    if (i >= listaAleatoria.Count) // Ordenação concluída
                    {
                        stopwatch.Stop();
                        timer.Stop();
                        ordenando = false;

                        AtualizarNotas("Insertion Sort");
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}\nDetalhes: {ex.StackTrace}");
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            grf_ordenacao.Series.Clear();

            if (listaAleatoria != null) listaAleatoria.Clear();
            if (listaOriginal != null) listaOriginal.Clear();

            dataGridView1.Rows.Clear();

            indexAtual = 0;
            ordenando = false;
            insertionSortAtivo = false;
            shellSortAtivo = false;
            quickSortAtivo = false;

            i = 0;
            j = 0;

            txtTamanhoLista.Clear();
            txt_timer.Clear();
        }

        private void btn_quick_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaAleatoria == null || listaAleatoria.Count == 0)
                {
                    MessageBox.Show("Por favor, insira os valores no gráfico antes de ordenar.");
                    return;
                }

                if (int.TryParse(txt_timer.Text, out int intervalo) && intervalo > 0)
                {
                    timer.Interval = intervalo;
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor válido para o intervalo do timer.");
                    return;
                }

                if (stopwatch == null)
                {
                    stopwatch = new Stopwatch();
                }
                stopwatch.Reset();
                stopwatch.Start();

                ordenando = true;
                quickSortAtivo = true;
                pilhaQuickSort = new Stack<(int low, int high)>();
                pilhaQuickSort.Push((0, listaAleatoria.Count - 1));

                grf_ordenacao.Series[0].Points.Clear();
                foreach (var num in listaAleatoria)
                {
                    grf_ordenacao.Series[0].Points.AddY(num);
                }

                timer.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}\nDetalhes: {ex.StackTrace}");
            }
        }


        private void QuickSort(List<int> lista, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(lista, low, high);

                QuickSort(lista, low, pi - 1);
                QuickSort(lista, pi + 1, high);
            }
        }

        private int Partition(List<int> lista, int low, int high)
        {
            int pivot = lista[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (lista[j] < pivot)
                {
                    i++;
                    Swap(lista, i, j);
                }
            }

            Swap(lista, i + 1, high);
            return i + 1;
        }

        private void Swap(List<int> lista, int i, int j)
        {
            int temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }

        private void QuickSortStepByStep(List<int> lista, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionStepByStep(lista, low, high);

                QuickSortStepByStep(lista, low, pi - 1);
                QuickSortStepByStep(lista, pi + 1, high);
            }
        }

        private int PartitionStepByStep(List<int> lista, int low, int high)
        {
            int pivot = lista[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (lista[j] < pivot)
                {
                    i++;
                    Swap(lista, i, j);

                    AtualizarGrafico();
                }
            }
            Swap(lista, i + 1, high);

            AtualizarGrafico();

            return i + 1;
        }

        private void btn_shell_Click(object sender, EventArgs e)
        {
            try
            {

                if (listaAleatoria == null || listaAleatoria.Count == 0)
                {
                    MessageBox.Show("Por favor, insira os valores no gráfico antes de ordenar.");
                    return;
                }

                if (int.TryParse(txt_timer.Text, out int intervalo) && intervalo > 0)
                {
                    timer.Interval = intervalo;
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor válido para o intervalo do timer.");
                    return;
                }

                ordenando = true;
                shellSortAtivo = true;

                gap = listaAleatoria.Count / 2;
                j = gap; // Começa com o gap atual.

                grf_ordenacao.Series[0].Points.Clear();
                foreach (var num in listaAleatoria)
                {
                    grf_ordenacao.Series[0].Points.AddY(num);
                }

                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}\nDetalhes: {ex.StackTrace}");
            }

        }

        private void btn_Original_Click(object sender, EventArgs e)
        {
            if (listaOriginal == null || listaOriginal.Count == 0)
            {
                MessageBox.Show("Nenhuma lista original foi gerada ainda. Por favor, inicie o processo primeiro.");
                return;
            }

            listaAleatoria = new List<int>(listaOriginal);

            grf_ordenacao.Series[0].Points.Clear();
            foreach (var num in listaAleatoria)
            {
                grf_ordenacao.Series[0].Points.AddY(num);
            }

            dataGridView1.Rows.Clear();
            ordenando = false;
            insertionSortAtivo = false;
            shellSortAtivo = false;
            quickSortAtivo = false;
            pilhaQuickSort = null;
            i = 0;
            j = 0;
            low = 0;
            high = listaAleatoria.Count - 1;
            if (stopwatch != null) stopwatch.Reset();
        }
        
        private void btn_sequencial_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaAleatoria == null || listaAleatoria.Count == 0)
                {
                    MessageBox.Show("Por favor, insira os valores no gráfico antes de realizar a busca sequencial.");
                    return;
                }

                if (!int.TryParse(txt_numero.Text, out numeroBusca))
                {
                    MessageBox.Show("Por favor, insira um número válido para buscar.");
                    return;
                }

                // Reseta o estado da busca sequencial
                indiceSequencial = 0;
                buscaSequencialAtiva = true;

                // Configura o Timer para a animação da busca sequencial.
                timer.Tick -= Timer_Tick;
                timer.Tick -= Timer_BuscaSequencial;
                timer.Tick += Timer_BuscaSequencial;
                timer.Interval = 50; // Intervalo para a animação da busca
                timer.Start();

                AtualizarGrafico(); // Exibe o gráfico inicial
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}\nDetalhes: {ex.StackTrace}");
            }
        }

        private void Timer_BuscaSequencial(object sender, EventArgs e)
        {
            if (buscaSequencialAtiva)
            {
                if (indiceSequencial < listaAleatoria.Count)
                {
                    // Atualiza a cor da barra atual no gráfico
                    AtualizarGrafico(indiceSequencial);

                    // Verifica se o número foi encontrado
                    if (listaAleatoria[indiceSequencial] == numeroBusca)
                    {
                        buscaSequencialAtiva = false;
                        timer.Stop();
                        MessageBox.Show($"Número {numeroBusca} encontrado no índice {indiceSequencial}!");
                        return;
                    }

                    indiceSequencial++; // Avança para o próximo índice
                }
                else
                {
                    buscaSequencialAtiva = false;
                    timer.Stop();
                    MessageBox.Show("Número não encontrado na lista.");
                }
            }
        }

        private void AtualizarGrafico(int indiceAtual = -1)
        {
            // Atualiza o gráfico com base no índice fornecido
            for (int i = 0; i < listaAleatoria.Count; i++)
            {
                if (i == indiceAtual)
                {
                    // Destaca o elemento atual sendo comparado
                    grf_ordenacao.Series[0].Points[i].Color = System.Drawing.Color.Yellow;
                }
                else
                {
                    // Normaliza a cor dos outros elementos
                    grf_ordenacao.Series[0].Points[i].Color = System.Drawing.Color.Blue;
                }
            }
        }

        private void btn_binario_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaAleatoria == null || listaAleatoria.Count == 0)
                {
                    MessageBox.Show("Por favor, insira os valores no gráfico antes de realizar a busca binária.");
                    return;
                }

                if (!int.TryParse(txt_numero.Text, out numeroBusca))
                {
                    MessageBox.Show("Por favor, insira um número válido para buscar.");
                    return;
                }

                listaAleatoria.Sort();

                lowBinario = 0;
                highBinario = listaAleatoria.Count - 1;
                buscaBinariaAtiva = true;

                AtualizarGrafico();

                // Configura o Timer para animar a busca
                timer.Tick -= Timer_Tick; 
                timer.Tick -= Timer_BuscaBinaria; 
                timer.Tick += Timer_BuscaBinaria; 
                timer.Interval = 500; 
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}\nDetalhes: {ex.StackTrace}");
            }
        }

        // Método para animar a busca binária
        private void Timer_BuscaBinaria(object sender, EventArgs e)
        {
            if (!buscaBinariaAtiva)
            {
                timer.Stop(); // Garante que o Timer será parado se a busca estiver inativa
                return;
            }

            if (lowBinario <= highBinario)
            {
                midBinario = (lowBinario + highBinario) / 2;

                // Atualiza o gráfico destacando o intervalo de busca
                AtualizarGrafico();
                for (int k = lowBinario; k <= highBinario; k++)
                {
                    grf_ordenacao.Series[0].Points[k].Color = System.Drawing.Color.Yellow; // Intervalo atual
                }
                grf_ordenacao.Series[0].Points[midBinario].Color = System.Drawing.Color.Red; // Destaque para o elemento médio

                // Verifica se encontrou o número
                if (listaAleatoria[midBinario] == numeroBusca)
                {
                    grf_ordenacao.Series[0].Points[midBinario].Color = System.Drawing.Color.Green; // Número encontrado
                    buscaBinariaAtiva = false; // Desativa a busca
                    timer.Stop(); // Para o Timer
                    MessageBox.Show($"Número {numeroBusca} encontrado no índice {midBinario}.");
                }
                else if (listaAleatoria[midBinario] < numeroBusca)
                {
                    lowBinario = midBinario + 1; // Ajusta o intervalo
                }
                else
                {
                    highBinario = midBinario - 1; // Ajusta o intervalo
                }
            }
            else
            {
                // Busca concluída sem sucesso
                buscaBinariaAtiva = false; 
                timer.Stop(); 
                MessageBox.Show($"Número {numeroBusca} não encontrado.");
            }
        }

        private int BuscaBinaria(List<int> lista, int numero)
        {
            int inicio = 0;
            int fim = lista.Count - 1;

            while (inicio <= fim)
            {
                int meio = (inicio + fim) / 2;

                if (lista[meio] == numero)
                {
                    return meio; // Retorna o índice do número encontrado.
                }
                else if (lista[meio] < numero)
                {
                    inicio = meio + 1;
                }
                else
                {
                    fim = meio - 1;
                }
            }
            return -1; // Retorna -1 se o número não for encontrado.
        }

        private void AtualizarGrafico()
        {
            grf_ordenacao.Series[0].Points.Clear();

            foreach (var num in listaAleatoria)
            {
                grf_ordenacao.Series[0].Points.AddY(num);
            }
        }
        private void AtualizarNotas(string metodoOrdenacao)
        {
            string tempoExecucao = stopwatch.Elapsed.ToString(@"hh\:mm\:ss\:ff");  // Formato: hh:mm:ss:ll
            blc_notas.AppendText($"Método: {metodoOrdenacao}\n");
            blc_notas.AppendText($"Quantidade de valores: {listaAleatoria.Count}\n");
            blc_notas.AppendText($"Comparações: {comparacoes}\n");
            blc_notas.AppendText($"Trocas: {trocas}\n");
            blc_notas.AppendText($"Tempo de execução: {tempoExecucao}\n\n");
        }

        private void AtualizarDataGridView()
        {
            dataGridView1.Rows.Clear();

            for (int k = 0; k < listaAleatoria.Count; k++)
            {
                dataGridView1.Rows.Add(listaOriginal[k], listaAleatoria[k]);
            }
        }
    }
}