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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.btn_binario = new System.Windows.Forms.Button();
            this.btn_sequencial = new System.Windows.Forms.Button();
            this.txt_numero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Original = new System.Windows.Forms.Button();
            this.blc_notas = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grf_ordenacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grf_ordenacao
            // 
            chartArea2.Name = "ChartArea1";
            this.grf_ordenacao.ChartAreas.Add(chartArea2);
            this.grf_ordenacao.Location = new System.Drawing.Point(12, 10);
            this.grf_ordenacao.Name = "grf_ordenacao";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.grf_ordenacao.Series.Add(series2);
            this.grf_ordenacao.Size = new System.Drawing.Size(563, 268);
            this.grf_ordenacao.TabIndex = 0;
            this.grf_ordenacao.Text = "chart1";
            // 
            // txtTamanhoLista
            // 
            this.txtTamanhoLista.Location = new System.Drawing.Point(599, 238);
            this.txtTamanhoLista.Name = "txtTamanhoLista";
            this.txtTamanhoLista.Size = new System.Drawing.Size(82, 20);
            this.txtTamanhoLista.TabIndex = 1;
            // 
            // txt_timer
            // 
            this.txt_timer.Location = new System.Drawing.Point(706, 238);
            this.txt_timer.Name = "txt_timer";
            this.txt_timer.Size = new System.Drawing.Size(82, 20);
            this.txt_timer.TabIndex = 2;
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.Location = new System.Drawing.Point(646, 264);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(100, 23);
            this.btn_iniciar.TabIndex = 3;
            this.btn_iniciar.Text = "Iniciar";
            this.btn_iniciar.UseVisualStyleBackColor = true;
            this.btn_iniciar.Click += new System.EventHandler(this.btn_iniciar_Click);
            // 
            // btn_quick
            // 
            this.btn_quick.Location = new System.Drawing.Point(11, 19);
            this.btn_quick.Name = "btn_quick";
            this.btn_quick.Size = new System.Drawing.Size(82, 23);
            this.btn_quick.TabIndex = 4;
            this.btn_quick.Text = "Quick Sort";
            this.btn_quick.UseVisualStyleBackColor = true;
            this.btn_quick.Click += new System.EventHandler(this.btn_quick_Click);
            // 
            // btn_shell
            // 
            this.btn_shell.Location = new System.Drawing.Point(107, 19);
            this.btn_shell.Name = "btn_shell";
            this.btn_shell.Size = new System.Drawing.Size(82, 23);
            this.btn_shell.TabIndex = 5;
            this.btn_shell.Text = "Shell Sort";
            this.btn_shell.UseVisualStyleBackColor = true;
            this.btn_shell.Click += new System.EventHandler(this.btn_shell_Click);
            // 
            // btn_insertion
            // 
            this.btn_insertion.Location = new System.Drawing.Point(107, 71);
            this.btn_insertion.Name = "btn_insertion";
            this.btn_insertion.Size = new System.Drawing.Size(82, 23);
            this.btn_insertion.TabIndex = 6;
            this.btn_insertion.Text = "Insertion Sort";
            this.btn_insertion.UseVisualStyleBackColor = true;
            this.btn_insertion.Click += new System.EventHandler(this.btn_insertion_Click);
            // 
            // btn_SelectionSort
            // 
            this.btn_SelectionSort.Location = new System.Drawing.Point(11, 71);
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
            this.dataGridView1.Size = new System.Drawing.Size(208, 123);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(598, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Insira os valores\r\n     no gráfico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(731, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Timer";
            // 
            // btn_limpar
            // 
            this.btn_limpar.Location = new System.Drawing.Point(372, 286);
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
            this.btn_binario.Click += new System.EventHandler(this.btn_binario_Click);
            // 
            // btn_sequencial
            // 
            this.btn_sequencial.Location = new System.Drawing.Point(695, 65);
            this.btn_sequencial.Name = "btn_sequencial";
            this.btn_sequencial.Size = new System.Drawing.Size(103, 23);
            this.btn_sequencial.TabIndex = 14;
            this.btn_sequencial.Text = "Busca sequencial";
            this.btn_sequencial.UseVisualStyleBackColor = true;
            this.btn_sequencial.Click += new System.EventHandler(this.btn_sequencial_Click);
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
            // btn_Original
            // 
            this.btn_Original.Location = new System.Drawing.Point(478, 286);
            this.btn_Original.Name = "btn_Original";
            this.btn_Original.Size = new System.Drawing.Size(97, 23);
            this.btn_Original.TabIndex = 18;
            this.btn_Original.Text = "Voltar ao original";
            this.btn_Original.UseVisualStyleBackColor = true;
            this.btn_Original.Click += new System.EventHandler(this.btn_Original_Click);
            // 
            // blc_notas
            // 
            this.blc_notas.Location = new System.Drawing.Point(246, 315);
            this.blc_notas.Name = "blc_notas";
            this.blc_notas.ReadOnly = true;
            this.blc_notas.Size = new System.Drawing.Size(542, 123);
            this.blc_notas.TabIndex = 19;
            this.blc_notas.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_insertion);
            this.groupBox1.Controls.Add(this.btn_SelectionSort);
            this.groupBox1.Controls.Add(this.btn_quick);
            this.groupBox1.Controls.Add(this.btn_shell);
            this.groupBox1.Location = new System.Drawing.Point(588, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenações";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.blc_notas);
            this.Controls.Add(this.btn_Original);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_numero);
            this.Controls.Add(this.btn_sequencial);
            this.Controls.Add(this.btn_binario);
            this.Controls.Add(this.btn_limpar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_iniciar);
            this.Controls.Add(this.txt_timer);
            this.Controls.Add(this.txtTamanhoLista);
            this.Controls.Add(this.grf_ordenacao);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grf_ordenacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_antes;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_depois;
        private System.Windows.Forms.Button btn_limpar;
        private System.Windows.Forms.Button btn_binario;
        private System.Windows.Forms.Button btn_sequencial;
        private System.Windows.Forms.TextBox txt_numero;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button btn_Original;
        private System.Windows.Forms.RichTextBox blc_notas;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

