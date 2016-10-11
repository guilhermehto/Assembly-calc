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
            this.SuspendLayout();
            // 
            // txtCalculo
            // 
            this.txtCalculo.Location = new System.Drawing.Point(253, 43);
            this.txtCalculo.Name = "txtCalculo";
            this.txtCalculo.Size = new System.Drawing.Size(100, 20);
            this.txtCalculo.TabIndex = 0;
            // 
            // btnGerarAssembly
            // 
            this.btnGerarAssembly.Location = new System.Drawing.Point(244, 106);
            this.btnGerarAssembly.Name = "btnGerarAssembly";
            this.btnGerarAssembly.Size = new System.Drawing.Size(109, 23);
            this.btnGerarAssembly.TabIndex = 1;
            this.btnGerarAssembly.Text = "Gerar Assembly";
            this.btnGerarAssembly.UseVisualStyleBackColor = true;
            this.btnGerarAssembly.Click += new System.EventHandler(this.btnGerarAssembly_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 317);
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
    }
}