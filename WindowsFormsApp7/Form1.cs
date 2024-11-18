using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

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
                    stopwatch.Stop();
                    double tempoMs = stopwatch.Elapsed.TotalMilliseconds;
                    lblTempoExecucao.Text = $"Tempo de execução: {tempoMs:F2} ms";
                    timer.Stop();
                    ordenando = false;
                    insertionSortAtivo = false;
                    MessageBox.Show("Ordenação Insertion Sort concluída!");

                    AtualizarDataGridView();
                }
            }
            else if (shellSortAtivo)
            {
                if (i < listaAleatoria.Count)
                {
                    int gap = listaAleatoria.Count / 2;

                    while (gap > 0)
                    {
                        if (i >= gap)
                        {
                            int temp = listaAleatoria[i];
                            j = i;

                            while (j >= gap && listaAleatoria[j - gap] > temp)
                            {
                                listaAleatoria[j] = listaAleatoria[j - gap];
                                j -= gap;
                            }

                            listaAleatoria[j] = temp;

                            grf_ordenacao.Series[0].Points.Clear();
                            foreach (var num in listaAleatoria)
                            {
                                grf_ordenacao.Series[0].Points.AddY(num);
                            }

                            i++;
                        }

                        gap /= 2;
                    }
                }
                else
                {
                    timer.Stop();
                    MessageBox.Show("Ordenação Shell Sort concluída!");
                    ordenando = false;
                    shellSortAtivo = false;

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

            // Esperar a ordenação ser concluída
            while (timer.Enabled)
            {
                Application.DoEvents();
            }

            // Parar o cronômetro e exibir o tempo
            stopwatch.Stop();
            double tempoMs = stopwatch.Elapsed.TotalMilliseconds;
            lblTempoExecucao.Text = $"Tempo de execução: {tempoMs:F2} ms";
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

                // Inicializa o cronômetro
                if (stopwatch == null)
                {
                    stopwatch = new Stopwatch();
                }
                stopwatch.Reset();

                ordenando = true;
                insertionSortAtivo = true;
                i = 1; // Configura o índice inicial para o Insertion Sort

                // Atualizar o gráfico antes de iniciar a ordenação
                grf_ordenacao.Series[0].Points.Clear();
                foreach (var num in listaAleatoria)
                {
                    grf_ordenacao.Series[0].Points.AddY(num);
                }

                // Iniciar o cronômetro e o timer
                stopwatch.Start();
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

            // Limpar o tempo de execução e reiniciar o cronômetro
            lblTempoExecucao.Text = "Tempo de execução:";
            if (stopwatch != null) stopwatch.Reset();
        }

        private void btn_quick_Click(object sender, EventArgs e)
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

            // Reiniciar o cronômetro antes de iniciar a ordenação
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

            // Quando o timer parar, calcular o tempo de execução
            timer.Tick += (s, args) =>
            {
                if (!ordenando)
                {
                    stopwatch.Stop();
                    double tempoMs = stopwatch.Elapsed.TotalMilliseconds;
                    lblTempoExecucao.Text = $"Tempo de execução: {tempoMs:F2} ms";
                }
            };
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

            grf_ordenacao.Series[0].Points.Clear();
            foreach (var num in listaAleatoria)
            {
                grf_ordenacao.Series[0].Points.AddY(num);
            }

            timer.Start();
        }

        private void AtualizarGrafico()
        {
            grf_ordenacao.Series[0].Points.Clear();

            foreach (var num in listaAleatoria)
            {
                grf_ordenacao.Series[0].Points.AddY(num);
            }
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