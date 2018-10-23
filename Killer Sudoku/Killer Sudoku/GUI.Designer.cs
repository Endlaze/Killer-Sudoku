using System;
using System.Windows.Forms;

namespace Killer_Sudoku
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.killer_sudoku_label = new System.Windows.Forms.Label();
            this.options_panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.save_killer = new System.Windows.Forms.Button();
            this.load_killer = new System.Windows.Forms.Button();
            this.generate_button = new System.Windows.Forms.Button();
            this.size_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.thread_label = new System.Windows.Forms.Label();
            this.thread_input = new System.Windows.Forms.TextBox();
            this.options_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // killer_sudoku_label
            // 
            this.killer_sudoku_label.AutoSize = true;
            this.killer_sudoku_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.killer_sudoku_label.Location = new System.Drawing.Point(424, 8);
            this.killer_sudoku_label.Name = "killer_sudoku_label";
            this.killer_sudoku_label.Size = new System.Drawing.Size(152, 25);
            this.killer_sudoku_label.TabIndex = 0;
            this.killer_sudoku_label.Text = "Killer Sudoku";
            this.killer_sudoku_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // options_panel
            // 
            this.options_panel.Controls.Add(this.button1);
            this.options_panel.Controls.Add(this.save_killer);
            this.options_panel.Controls.Add(this.load_killer);
            this.options_panel.Controls.Add(this.generate_button);
            this.options_panel.Controls.Add(this.size_input);
            this.options_panel.Controls.Add(this.label1);
            this.options_panel.Controls.Add(this.thread_label);
            this.options_panel.Controls.Add(this.thread_input);
            this.options_panel.Location = new System.Drawing.Point(1063, 54);
            this.options_panel.Name = "options_panel";
            this.options_panel.Size = new System.Drawing.Size(235, 383);
            this.options_panel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(40, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Solve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // save_killer
            // 
            this.save_killer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_killer.Location = new System.Drawing.Point(40, 208);
            this.save_killer.Name = "save_killer";
            this.save_killer.Size = new System.Drawing.Size(155, 23);
            this.save_killer.TabIndex = 8;
            this.save_killer.Text = "Save Killer Sudoku";
            this.save_killer.UseVisualStyleBackColor = true;
            this.save_killer.Click += new System.EventHandler(this.save_killer_Click);
            // 
            // load_killer
            // 
            this.load_killer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load_killer.Location = new System.Drawing.Point(40, 163);
            this.load_killer.Name = "load_killer";
            this.load_killer.Size = new System.Drawing.Size(155, 23);
            this.load_killer.TabIndex = 7;
            this.load_killer.Text = "Load Killer Sudoku";
            this.load_killer.UseVisualStyleBackColor = true;
            this.load_killer.Click += new System.EventHandler(this.load_killer_Click);
            // 
            // generate_button
            // 
            this.generate_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generate_button.Location = new System.Drawing.Point(40, 248);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(155, 23);
            this.generate_button.TabIndex = 6;
            this.generate_button.Text = "Generate";
            this.generate_button.UseVisualStyleBackColor = true;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
            // 
            // size_input
            // 
            this.size_input.Location = new System.Drawing.Point(126, 83);
            this.size_input.Name = "size_input";
            this.size_input.Size = new System.Drawing.Size(100, 20);
            this.size_input.TabIndex = 3;
            this.size_input.TextChanged += new System.EventHandler(this.size_input_TextChanged);
            this.size_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.size_input_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Killer Sudoku Size";
            // 
            // thread_label
            // 
            this.thread_label.AutoSize = true;
            this.thread_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thread_label.Location = new System.Drawing.Point(10, 42);
            this.thread_label.Name = "thread_label";
            this.thread_label.Size = new System.Drawing.Size(111, 13);
            this.thread_label.TabIndex = 1;
            this.thread_label.Text = "Number of threads";
            // 
            // thread_input
            // 
            this.thread_input.Location = new System.Drawing.Point(125, 39);
            this.thread_input.Name = "thread_input";
            this.thread_input.Size = new System.Drawing.Size(100, 20);
            this.thread_input.TabIndex = 0;
            this.thread_input.TextChanged += new System.EventHandler(this.thread_input_TextChanged);
            this.thread_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.thread_input_KeyPress);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 561);
            this.Controls.Add(this.options_panel);
            this.Controls.Add(this.killer_sudoku_label);
            this.Name = "GUI";
            this.Text = "Killer Sudoku";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.options_panel.ResumeLayout(false);
            this.options_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void thread_input_KeyPress(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label killer_sudoku_label;
        private System.Windows.Forms.Panel options_panel;
        private System.Windows.Forms.TextBox thread_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label thread_label;
        private System.Windows.Forms.TextBox size_input;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.Button save_killer;
        private System.Windows.Forms.Button load_killer;
        private Button button1;
    }
}

