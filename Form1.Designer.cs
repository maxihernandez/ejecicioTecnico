namespace EvaluacionTecnica
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new System.Windows.Forms.Button();
            ResultadoSP = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)ResultadoSP).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(60, 47);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Ejecutar SP";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ResultadoSP
            // 
            ResultadoSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultadoSP.Location = new System.Drawing.Point(58, 100);
            ResultadoSP.Name = "ResultadoSP";
            ResultadoSP.RowTemplate.Height = 25;
            ResultadoSP.Size = new System.Drawing.Size(242, 301);
            ResultadoSP.TabIndex = 1;
            ResultadoSP.CellContentClick += ResultadoSP_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(402, 492);
            Controls.Add(ResultadoSP);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)ResultadoSP).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView ResultadoSP;
    }
}
