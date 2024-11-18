namespace WindowsFormsApp7
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grf_ordenacao = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtTamanhoLista = new System.Windows.Forms.TextBox();
            this.txt_timer = new System.Windows.Forms.TextBox();
            this.btn_iniciar = new System.Windows.Forms.Button();
            this.btn_quick = new System.Windows.Forms.Button();
            this.btn_shell = new System.Windows.Forms.Button();
            this.btn_insertion = new System.Windows.Forms.Button();
            this.btn_SelectionSort = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.coluna_antes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_depois = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.btn_binario = new System.Windows.Forms.Button();
            this.btn_sequencial = new System.Windows.Forms.Button();
            this.txt_numero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTempoExecucao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grf_ordenacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // grf_ordenacao
            // 
            chartArea3.Name = "ChartArea1";
            this.grf_ordenacao.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.grf_ordenacao.Legends.Add(legend3);
            this.grf_ordenacao.Location = new System.Drawing.Point(12, 1);
            this.grf_ordenacao.Name = "grf_ordenacao";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.grf_ordenacao.Series.Add(series3);
            this.grf_ordenacao.Size = new System.Drawing.Size(563, 268);
            this.grf_ordenacao.TabIndex = 0;
            this.grf_ordenacao.Text = "chart1";
            // 
            // txtTamanhoLista
            // 
            this.txtTamanhoLista.Location = new System.Drawing.Point(252, 407);
            this.txtTamanhoLista.Name = "txtTamanhoLista";
            this.txtTamanhoLista.Size = new System.Drawing.Size(82, 20);
            this.txtTamanhoLista.TabIndex = 1;
            // 
            // txt_timer
            // 
            this.txt_timer.Location = new System.Drawing.Point(466, 407);
            this.txt_timer.Name = "txt_timer";
            this.txt_timer.Size = new System.Drawing.Size(82, 20);
            this.txt_timer.TabIndex = 2;
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.Location = new System.Drawing.Point(350, 424);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(100, 23);
            this.btn_iniciar.TabIndex = 3;
            this.btn_iniciar.Text = "Iniciar";
            this.btn_iniciar.UseVisualStyleBackColor = true;
            this.btn_iniciar.Click += new System.EventHandler(this.btn_iniciar_Click);
            // 
            // btn_quick
            // 
            this.btn_quick.Location = new System.Drawing.Point(405, 315);
            this.btn_quick.Name = "btn_quick";
            this.btn_quick.Size = new System.Drawing.Size(82, 23);
            this.btn_quick.TabIndex = 4;
            this.btn_quick.Text = "Quick Sort";
            this.btn_quick.UseVisualStyleBackColor = true;
            this.btn_quick.Click += new System.EventHandler(this.btn_quick_Click);
            // 
            // btn_shell
            // 
            this.btn_shell.Location = new System.Drawing.Point(493, 315);
            this.btn_shell.Name = "btn_shell";
            this.btn_shell.Size = new System.Drawing.Size(82, 23);
            this.btn_shell.TabIndex = 5;
            this.btn_shell.Text = "Shell Sort";
            this.btn_shell.UseVisualStyleBackColor = true;
            this.btn_shell.Click += new System.EventHandler(this.btn_shell_Click);
            // 
            // btn_insertion
            // 
            this.btn_insertion.Location = new System.Drawing.Point(317, 315);
            this.btn_insertion.Name = "btn_insertion";
            this.btn_insertion.Size = new System.Drawing.Size(82, 23);
            this.btn_insertion.TabIndex = 6;
            this.btn_insertion.Text = "Insertion Sort";
            this.btn_insertion.UseVisualStyleBackColor = true;
            this.btn_insertion.Click += new System.EventHandler(this.btn_insertion_Click);
            // 
            // btn_SelectionSort
            // 
            this.btn_SelectionSort.Location = new System.Drawing.Point(229, 315);
            this.btn_SelectionSort.Name = "btn_SelectionSort";
            this.btn_SelectionSort.Size = new System.Drawing.Size(82, 23);
            this.btn_SelectionSort.TabIndex = 7;
            this.btn_SelectionSort.Text = "Selection Sort";
            this.btn_SelectionSort.UseVisualStyleBackColor = true;
            this.btn_SelectionSort.Click += new System.EventHandler(this.btn_SelectionSort_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coluna_antes,
            this.coluna_depois});
            this.dataGridView1.Location = new System.Drawing.Point(12, 315);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(208, 132);
            this.dataGridView1.TabIndex = 8;
            // 
            // coluna_antes
            // 
            this.coluna_antes.HeaderText = "Antes da ordenação";
            this.coluna_antes.Name = "coluna_antes";
            this.coluna_antes.ReadOnly = true;
            this.coluna_antes.Width = 82;
            // 
            // coluna_depois
            // 
            this.coluna_depois.HeaderText = "Depois da ordenação";
            this.coluna_depois.Name = "coluna_depois";
            this.coluna_depois.ReadOnly = true;
            this.coluna_depois.Width = 82;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(581, 315);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(208, 132);
            this.dataGridView2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "Insira os valores\r\n         para \r\n     ordenação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Timer";
            // 
            // btn_limpar
            // 
            this.btn_limpar.Location = new System.Drawing.Point(350, 381);
            this.btn_limpar.Name = "btn_limpar";
            this.btn_limpar.Size = new System.Drawing.Size(100, 23);
            this.btn_limpar.TabIndex = 12;
            this.btn_limpar.Text = "Limpar o gráfico";
            this.btn_limpar.UseVisualStyleBackColor = true;
            this.btn_limpar.Click += new System.EventHandler(this.btn_limpar_Click);
            // 
            // btn_binario
            // 
            this.btn_binario.Location = new System.Drawing.Point(581, 65);
            this.btn_binario.Name = "btn_binario";
            this.btn_binario.Size = new System.Drawing.Size(103, 23);
            this.btn_binario.TabIndex = 13;
            this.btn_binario.Text = "Busca binária";
            this.btn_binario.UseVisualStyleBackColor = true;
            // 
            // btn_sequencial
            // 
            this.btn_sequencial.Location = new System.Drawing.Point(695, 65);
            this.btn_sequencial.Name = "btn_sequencial";
            this.btn_sequencial.Size = new System.Drawing.Size(103, 23);
            this.btn_sequencial.TabIndex = 14;
            this.btn_sequencial.Text = "Busca sequencial";
            this.btn_sequencial.UseVisualStyleBackColor = true;
            // 
            // txt_numero
            // 
            this.txt_numero.Location = new System.Drawing.Point(646, 39);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(84, 20);
            this.txt_numero.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(652, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Número a ser\r\n    buscado";
            // 
            // lblTempoExecucao
            // 
            this.lblTempoExecucao.AutoSize = true;
            this.lblTempoExecucao.Location = new System.Drawing.Point(415, 272);
            this.lblTempoExecucao.Name = "lblTempoExecucao";
            this.lblTempoExecucao.Size = new System.Drawing.Size(108, 13);
            this.lblTempoExecucao.TabIndex = 17;
            this.lblTempoExecucao.Text = "Tempo de execução:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTempoExecucao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_numero);
            this.Controls.Add(this.btn_sequencial);
            this.Controls.Add(this.btn_binario);
            this.Controls.Add(this.btn_limpar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_SelectionSort);
            this.Controls.Add(this.btn_insertion);
            this.Controls.Add(this.btn_shell);
            this.Controls.Add(this.btn_quick);
            this.Controls.Add(this.btn_iniciar);
            this.Controls.Add(this.txt_timer);
            this.Controls.Add(this.txtTamanhoLista);
            this.Controls.Add(this.grf_ordenacao);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grf_ordenacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grf_ordenacao;
        private System.Windows.Forms.TextBox txtTamanhoLista;
        private System.Windows.Forms.TextBox txt_timer;
        private System.Windows.Forms.Button btn_iniciar;
        private System.Windows.Forms.Button btn_quick;
        private System.Windows.Forms.Button btn_shell;
        private System.Windows.Forms.Button btn_insertion;
        private System.Windows.Forms.Button btn_SelectionSort;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_antes;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_depois;
        private System.Windows.Forms.Button btn_limpar;
        private System.Windows.Forms.Button btn_binario;
        private System.Windows.Forms.Button btn_sequencial;
        private System.Windows.Forms.TextBox txt_numero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTempoExecucao;
    }
}

