using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

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
        private int numeroComparacoes = 0;
        private int numeroTrocas = 0;



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
                        listaAleatoria[j + 1] = listaAleatoria[j];
                        j--;
                        numeroComparacoes++;  // Conta apenas a comparação
                    }
                    if (j + 1 != i) // Troca só ocorre se o elemento foi movido
                    {
                        listaAleatoria[j + 1] = key;
                        numeroTrocas++;  // Conta a troca
                    }
                    i++;
                    AtualizarGrafico();
                }
                else
                {
                    ordenando = false;
                    insertionSortAtivo = false;
                    stopwatch.Stop();
                    AtualizarNotas("Insertion Sort");
                    MessageBox.Show("Ordenação Insertion Sort concluída!");
                    AtualizarDataGridView();
                }
            }
            else if (shellSortAtivo)
            {
                try
                {
                    if (gap > 0)
                    {
                        if (j < listaAleatoria.Count)
                        {
                            int temp = listaAleatoria[j];
                            int k = j;
                            while (k >= gap && listaAleatoria[k - gap] > temp)
                            {
                                listaAleatoria[k] = listaAleatoria[k - gap];
                                k -= gap;
                                numeroComparacoes++;  
                            }
                            if (k != j)  
                            {
                                listaAleatoria[k] = temp;
                                numeroTrocas++;  
                            }
                            j++;
                            AtualizarGrafico();
                        }
                        else
                        {
                            gap = (int)(gap / 2.2);
                            j = gap;
                        }
                    }
                    else
                    {
                        shellSortAtivo = false;
                        ordenando = false;
                        timer.Stop();

                        if (stopwatch != null && stopwatch.IsRunning)
                        {
                            stopwatch.Stop();
                        }
                        AtualizarNotas("Shell Sort");
                        MessageBox.Show("Ordenação Shell Sort concluída!");
                        AtualizarDataGridView();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro durante a ordenação Shell Sort: {ex.Message}\n{ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (quickSortAtivo)
            {
                if (pilhaQuickSort.Count > 0)
                {
                    var (low, high) = pilhaQuickSort.Pop();
                    if (low < high)
                    {
                        int pi = Partition(listaAleatoria, low, high);
                        pilhaQuickSort.Push((low, pi - 1));
                        pilhaQuickSort.Push((pi + 1, high));
                        AtualizarGrafico();
                        numeroComparacoes++;
                        numeroTrocas++;
                    }
                }
                else
                {
                    pilhaQuickSort = new Stack<(int, int)>();
                    pilhaQuickSort.Push((0, listaAleatoria.Count - 1));
                    quickSortAtivo = false;
                    ordenando = false;
                    timer.Stop();
                    stopwatch.Stop();
                    AtualizarNotas("Quick Sort");
                    MessageBox.Show("Ordenação Quick Sort concluída!");
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
                        numeroComparacoes++;
                        if (listaAleatoria[j] < listaAleatoria[trocaAtual])
                        {
                            trocaAtual = j;
                        }
                    }
                    if (trocaAtual != i)
                    {
                        int temp = listaAleatoria[i];
                        listaAleatoria[i] = listaAleatoria[trocaAtual];
                        listaAleatoria[trocaAtual] = temp;
                        numeroTrocas++;
                    }
                    i++;
                    AtualizarGrafico();
                }
                else
                {
                    timer.Stop();
                    stopwatch.Stop();
                    AtualizarNotas("Selection Sort");
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
            numeroComparacoes = 0;
            numeroTrocas = 0;
            if (stopwatch == null)
            {
                stopwatch = new Stopwatch();
            }
            stopwatch.Reset();
            stopwatch.Start();

            ordenando = true;
            i = 0;
            grf_ordenacao.Series[0].Points.Clear();
            foreach (var num in listaAleatoria)
            {
                grf_ordenacao.Series[0].Points.AddY(num);
            }
            timer.Start();
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
                stopwatch.Start();
                numeroComparacoes = 0;
                numeroTrocas = 0;
                ordenando = true;
                insertionSortAtivo = true;
                i = 1;
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
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                numeroComparacoes++;
                if (lista[j] < pivot)
                {
                    i++;
                    int temp = lista[i];
                    lista[i] = lista[j];
                    lista[j] = temp;
                    numeroTrocas++;
                }
            }
            int temp2 = lista[i + 1];
            lista[i + 1] = lista[high];
            lista[high] = temp2;
            numeroTrocas++;
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
                if (stopwatch == null)
                {
                    stopwatch = new Stopwatch();
                }
                stopwatch.Start();  
                ordenando = true;
                shellSortAtivo = true;
                gap = listaAleatoria.Count / 2;
                j = gap;
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
        private async void btn_sequencial_Click(object sender, EventArgs e)
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
                indiceSequencial = 0;
                buscaSequencialAtiva = true;
                AtualizarGrafico();
                while (buscaSequencialAtiva && indiceSequencial < listaAleatoria.Count)
                {
                    AtualizarGrafico(indiceSequencial);
                    await Task.Delay(50); 
                    if (listaAleatoria[indiceSequencial] == numeroBusca)
                    {
                        buscaSequencialAtiva = false;
                        MessageBox.Show($"Número {numeroBusca} encontrado no índice {indiceSequencial}!");
                        return;
                    }
                    indiceSequencial++;
                }
                if (buscaSequencialAtiva)
                {
                    MessageBox.Show("Número não encontrado na lista.");
                }
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
                    AtualizarGrafico(indiceSequencial);
                    if (listaAleatoria[indiceSequencial] == numeroBusca)
                    {
                        buscaSequencialAtiva = false;
                        timer.Stop();
                        MessageBox.Show($"Número {numeroBusca} encontrado no índice {indiceSequencial}!");
                        return;
                    }
                    indiceSequencial++;
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
            for (int i = 0; i < listaAleatoria.Count; i++)
            {
                if (i == indiceAtual)
                {
                    grf_ordenacao.Series[0].Points[i].Color = System.Drawing.Color.Yellow;
                }
                else
                {
                    grf_ordenacao.Series[0].Points[i].Color = System.Drawing.Color.Blue;
                }
            }
        }
        private async void btn_binario_Click(object sender, EventArgs e)
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
                while (buscaBinariaAtiva && lowBinario <= highBinario)
                {
                    midBinario = (lowBinario + highBinario) / 2;
                    AtualizarGrafico();
                    for (int k = lowBinario; k <= highBinario; k++)
                    {
                        grf_ordenacao.Series[0].Points[k].Color = System.Drawing.Color.Yellow;
                    }
                    grf_ordenacao.Series[0].Points[midBinario].Color = System.Drawing.Color.Red;
                    await Task.Delay(500); 
                    if (listaAleatoria[midBinario] == numeroBusca)
                    {
                        grf_ordenacao.Series[0].Points[midBinario].Color = System.Drawing.Color.Green;
                        buscaBinariaAtiva = false;
                        MessageBox.Show($"Número {numeroBusca} encontrado no índice {midBinario}.");
                    }
                    else if (listaAleatoria[midBinario] < numeroBusca)
                    {
                        lowBinario = midBinario + 1;
                    }
                    else
                    {
                        highBinario = midBinario - 1;
                    }
                }
                if (buscaBinariaAtiva)
                {
                    MessageBox.Show($"Número {numeroBusca} não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}\nDetalhes: {ex.StackTrace}");
            }
        }
        private void btn_limpardesc_Click(object sender, EventArgs e)
        {
            blc_notas.Clear();
        }
        private void Timer_BuscaBinaria(object sender, EventArgs e)
        {
            if (!buscaBinariaAtiva)
            {
                timer.Stop();
                return;
            }
            if (lowBinario <= highBinario)
            {
                midBinario = (lowBinario + highBinario) / 2;
                AtualizarGrafico();
                for (int k = lowBinario; k <= highBinario; k++)
                {
                    grf_ordenacao.Series[0].Points[k].Color = System.Drawing.Color.Yellow;
                }
                grf_ordenacao.Series[0].Points[midBinario].Color = System.Drawing.Color.Red;
                if (listaAleatoria[midBinario] == numeroBusca)
                {
                    grf_ordenacao.Series[0].Points[midBinario].Color = System.Drawing.Color.Green;
                    buscaBinariaAtiva = false;
                    timer.Stop();
                    MessageBox.Show($"Número {numeroBusca} encontrado no índice {midBinario}.");
                }
                else if (listaAleatoria[midBinario] < numeroBusca)
                {
                    lowBinario = midBinario + 1;
                }
                else
                {
                    highBinario = midBinario - 1;
                }
            }
            else
            {
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
                    return meio;
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
            return -1;
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
            TimeSpan tempoDecorrido = stopwatch.Elapsed;
            string tempoFormatado = tempoDecorrido.ToString(@"hh\:mm\:ss\:fff");
            blc_notas.AppendText($"Método de Ordenação: {metodoOrdenacao}\n");
            blc_notas.AppendText($"Quantidade de valores inseridos: {listaAleatoria.Count}\n");
            blc_notas.AppendText($"Número de comparações: {numeroComparacoes}\n");
            blc_notas.AppendText($"Número de trocas: {numeroTrocas}\n");
            blc_notas.AppendText($"Tempo de ordenação: {tempoFormatado}\n\n");
            numeroComparacoes = 0;
            numeroTrocas = 0;
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