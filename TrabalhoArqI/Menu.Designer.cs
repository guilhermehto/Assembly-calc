namespace TrabalhoArqI {
    partial class Menu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtCalculo = new System.Windows.Forms.TextBox();
            this.btnGerarAssembly = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCalculo
            // 
            this.txtCalculo.Location = new System.Drawing.Point(47, 24);
            this.txtCalculo.Name = "txtCalculo";
            this.txtCalculo.Size = new System.Drawing.Size(124, 20);
            this.txtCalculo.TabIndex = 0;
            // 
            // btnGerarAssembly
            // 
            this.btnGerarAssembly.Location = new System.Drawing.Point(47, 50);
            this.btnGerarAssembly.Name = "btnGerarAssembly";
            this.btnGerarAssembly.Size = new System.Drawing.Size(124, 23);
            this.btnGerarAssembly.TabIndex = 1;
            this.btnGerarAssembly.Text = "Gerar Assembly";
            this.btnGerarAssembly.UseVisualStyleBackColor = true;
            this.btnGerarAssembly.Click += new System.EventHandler(this.btnGerarAssembly_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Expressão";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 119);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGerarAssembly);
            this.Controls.Add(this.txtCalculo);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCalculo;
        private System.Windows.Forms.Button btnGerarAssembly;
        private System.Windows.Forms.Label label1;
    }
}