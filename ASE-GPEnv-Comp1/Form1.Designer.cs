namespace ASE_GPEnv_Comp1
{
    partial class MainUI_AseGPL1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.codeBlockContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.executeProgramButton = new System.Windows.Forms.Button();
            this.programSyntaxCheckButton = new System.Windows.Forms.Button();
            this.programTextBox = new System.Windows.Forms.RichTextBox();
            this.saveProgramButton = new System.Windows.Forms.Button();
            this.loadProgramButton = new System.Windows.Forms.Button();
            this.convasContainer = new System.Windows.Forms.Panel();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.commandAndHistoryContainer = new System.Windows.Forms.Panel();
            this.runCommandButton = new System.Windows.Forms.Button();
            this.commandTextBox = new System.Windows.Forms.TextBox();
            this.commandsHistoryTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolboxAndSnippetsContainer = new System.Windows.Forms.Panel();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.outputAndSnippetsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clearCanvasButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.codeBlockContainer.SuspendLayout();
            this.convasContainer.SuspendLayout();
            this.commandAndHistoryContainer.SuspendLayout();
            this.toolboxAndSnippetsContainer.SuspendLayout();
            this.outputAndSnippetsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.codeBlockContainer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.convasContainer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.commandAndHistoryContainer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolboxAndSnippetsContainer, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 426);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // codeBlockContainer
            // 
            this.codeBlockContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeBlockContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.codeBlockContainer.Controls.Add(this.label1);
            this.codeBlockContainer.Controls.Add(this.executeProgramButton);
            this.codeBlockContainer.Controls.Add(this.programSyntaxCheckButton);
            this.codeBlockContainer.Controls.Add(this.programTextBox);
            this.codeBlockContainer.Controls.Add(this.saveProgramButton);
            this.codeBlockContainer.Controls.Add(this.loadProgramButton);
            this.codeBlockContainer.Location = new System.Drawing.Point(3, 3);
            this.codeBlockContainer.Name = "codeBlockContainer";
            this.codeBlockContainer.Size = new System.Drawing.Size(382, 207);
            this.codeBlockContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type your program here.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // executeProgramButton
            // 
            this.executeProgramButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.executeProgramButton.Location = new System.Drawing.Point(208, 180);
            this.executeProgramButton.Name = "executeProgramButton";
            this.executeProgramButton.Size = new System.Drawing.Size(75, 23);
            this.executeProgramButton.TabIndex = 4;
            this.executeProgramButton.Text = "Execute";
            this.executeProgramButton.UseVisualStyleBackColor = true;
            // 
            // programSyntaxCheckButton
            // 
            this.programSyntaxCheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.programSyntaxCheckButton.Location = new System.Drawing.Point(289, 181);
            this.programSyntaxCheckButton.Name = "programSyntaxCheckButton";
            this.programSyntaxCheckButton.Size = new System.Drawing.Size(89, 23);
            this.programSyntaxCheckButton.TabIndex = 3;
            this.programSyntaxCheckButton.Text = "Syntax Check";
            this.programSyntaxCheckButton.UseVisualStyleBackColor = true;
            // 
            // programTextBox
            // 
            this.programTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.programTextBox.Location = new System.Drawing.Point(4, 20);
            this.programTextBox.Name = "programTextBox";
            this.programTextBox.Size = new System.Drawing.Size(375, 158);
            this.programTextBox.TabIndex = 2;
            this.programTextBox.Text = "";
            // 
            // saveProgramButton
            // 
            this.saveProgramButton.Location = new System.Drawing.Point(84, 184);
            this.saveProgramButton.Name = "saveProgramButton";
            this.saveProgramButton.Size = new System.Drawing.Size(75, 23);
            this.saveProgramButton.TabIndex = 1;
            this.saveProgramButton.Text = "Save";
            this.saveProgramButton.UseVisualStyleBackColor = true;
            // 
            // loadProgramButton
            // 
            this.loadProgramButton.Location = new System.Drawing.Point(3, 184);
            this.loadProgramButton.Name = "loadProgramButton";
            this.loadProgramButton.Size = new System.Drawing.Size(75, 23);
            this.loadProgramButton.TabIndex = 0;
            this.loadProgramButton.Text = "Load Program";
            this.loadProgramButton.UseVisualStyleBackColor = true;
            this.loadProgramButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // convasContainer
            // 
            this.convasContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convasContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.convasContainer.Controls.Add(this.clearCanvasButton);
            this.convasContainer.Controls.Add(this.canvasPanel);
            this.convasContainer.Controls.Add(this.label4);
            this.convasContainer.Location = new System.Drawing.Point(391, 3);
            this.convasContainer.Name = "convasContainer";
            this.convasContainer.Size = new System.Drawing.Size(382, 207);
            this.convasContainer.TabIndex = 1;
            // 
            // canvasPanel
            // 
            this.canvasPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvasPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.canvasPanel.Location = new System.Drawing.Point(7, 20);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(370, 158);
            this.canvasPanel.TabIndex = 1;
            this.canvasPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.canvasPanel_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Graphical Output";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // commandAndHistoryContainer
            // 
            this.commandAndHistoryContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandAndHistoryContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.commandAndHistoryContainer.Controls.Add(this.runCommandButton);
            this.commandAndHistoryContainer.Controls.Add(this.commandTextBox);
            this.commandAndHistoryContainer.Controls.Add(this.commandsHistoryTextBox);
            this.commandAndHistoryContainer.Controls.Add(this.label2);
            this.commandAndHistoryContainer.Location = new System.Drawing.Point(3, 216);
            this.commandAndHistoryContainer.Name = "commandAndHistoryContainer";
            this.commandAndHistoryContainer.Size = new System.Drawing.Size(382, 207);
            this.commandAndHistoryContainer.TabIndex = 2;
            // 
            // runCommandButton
            // 
            this.runCommandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runCommandButton.Location = new System.Drawing.Point(303, 181);
            this.runCommandButton.Name = "runCommandButton";
            this.runCommandButton.Size = new System.Drawing.Size(75, 23);
            this.runCommandButton.TabIndex = 4;
            this.runCommandButton.Text = "Run";
            this.runCommandButton.UseVisualStyleBackColor = true;
            // 
            // commandTextBox
            // 
            this.commandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandTextBox.Location = new System.Drawing.Point(7, 155);
            this.commandTextBox.Name = "commandTextBox";
            this.commandTextBox.Size = new System.Drawing.Size(371, 20);
            this.commandTextBox.TabIndex = 3;
            // 
            // commandsHistoryTextBox
            // 
            this.commandsHistoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandsHistoryTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.commandsHistoryTextBox.Enabled = false;
            this.commandsHistoryTextBox.Location = new System.Drawing.Point(4, 20);
            this.commandsHistoryTextBox.Name = "commandsHistoryTextBox";
            this.commandsHistoryTextBox.Size = new System.Drawing.Size(374, 129);
            this.commandsHistoryTextBox.TabIndex = 2;
            this.commandsHistoryTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Commands History";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // toolboxAndSnippetsContainer
            // 
            this.toolboxAndSnippetsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolboxAndSnippetsContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolboxAndSnippetsContainer.Controls.Add(this.outputAndSnippetsTabControl);
            this.toolboxAndSnippetsContainer.Controls.Add(this.label3);
            this.toolboxAndSnippetsContainer.Location = new System.Drawing.Point(391, 216);
            this.toolboxAndSnippetsContainer.Name = "toolboxAndSnippetsContainer";
            this.toolboxAndSnippetsContainer.Size = new System.Drawing.Size(382, 207);
            this.toolboxAndSnippetsContainer.TabIndex = 3;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.outputTextBox.Enabled = false;
            this.outputTextBox.Location = new System.Drawing.Point(3, 3);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(356, 168);
            this.outputTextBox.TabIndex = 5;
            this.outputTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 0;
            // 
            // outputAndSnippetsTabControl
            // 
            this.outputAndSnippetsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputAndSnippetsTabControl.Controls.Add(this.tabPage1);
            this.outputAndSnippetsTabControl.Controls.Add(this.tabPage2);
            this.outputAndSnippetsTabControl.Location = new System.Drawing.Point(7, 4);
            this.outputAndSnippetsTabControl.Name = "outputAndSnippetsTabControl";
            this.outputAndSnippetsTabControl.SelectedIndex = 0;
            this.outputAndSnippetsTabControl.Size = new System.Drawing.Size(370, 200);
            this.outputAndSnippetsTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.outputTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(362, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Output";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(362, 174);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Toolbox";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // clearCanvasButton
            // 
            this.clearCanvasButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearCanvasButton.Location = new System.Drawing.Point(301, 180);
            this.clearCanvasButton.Name = "clearCanvasButton";
            this.clearCanvasButton.Size = new System.Drawing.Size(75, 23);
            this.clearCanvasButton.TabIndex = 2;
            this.clearCanvasButton.Text = "Clear";
            this.clearCanvasButton.UseVisualStyleBackColor = true;
            // 
            // MainUI_AseGPL1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainUI_AseGPL1";
            this.Text = "ASE-GPL-1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.codeBlockContainer.ResumeLayout(false);
            this.codeBlockContainer.PerformLayout();
            this.convasContainer.ResumeLayout(false);
            this.convasContainer.PerformLayout();
            this.commandAndHistoryContainer.ResumeLayout(false);
            this.commandAndHistoryContainer.PerformLayout();
            this.toolboxAndSnippetsContainer.ResumeLayout(false);
            this.toolboxAndSnippetsContainer.PerformLayout();
            this.outputAndSnippetsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel codeBlockContainer;
        private System.Windows.Forms.Panel convasContainer;
        private System.Windows.Forms.Panel commandAndHistoryContainer;
        private System.Windows.Forms.Panel toolboxAndSnippetsContainer;
        private System.Windows.Forms.Button loadProgramButton;
        private System.Windows.Forms.Button executeProgramButton;
        private System.Windows.Forms.Button programSyntaxCheckButton;
        private System.Windows.Forms.RichTextBox programTextBox;
        private System.Windows.Forms.Button saveProgramButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button runCommandButton;
        private System.Windows.Forms.TextBox commandTextBox;
        private System.Windows.Forms.RichTextBox commandsHistoryTextBox;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.TabControl outputAndSnippetsTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button clearCanvasButton;
    }
}

