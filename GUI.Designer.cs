using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomaton
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.epochCountLabel = new System.Windows.Forms.ToolStripLabel();
            this.epochCountTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cellTypeLabel = new System.Windows.Forms.ToolStripLabel();
            this.cellTypeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ruleComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.randomizeStatesButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cellsCountTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.cellularAutomaton = new CellularAutomaton();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(971, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem,
            this.saveFileMenuItem,
            this.closeMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.openToolStripMenuItem.Text = "File";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(154, 24);
            this.openFileMenuItem.Text = "Open file";
            // 
            // saveFileMenuItem
            // 
            this.saveFileMenuItem.Name = "saveFileMenuItem";
            this.saveFileMenuItem.Size = new System.Drawing.Size(154, 24);
            this.saveFileMenuItem.Text = "Save file";
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(154, 24);
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(71, 24);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 637);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(971, 25);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 19);
            // 
            // statusBar
            // 
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(92, 20);
            this.statusBar.Text = "Waiting";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startButton,
            this.toolStripSeparator4,
            this.epochCountLabel,
            this.epochCountTextBox,
            this.toolStripSeparator2,
            this.stopButton,
            this.toolStripSeparator1,
            this.cellTypeLabel,
            this.cellTypeComboBox,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.ruleComboBox,
            this.toolStripSeparator5,
            this.randomizeStatesButton,
            this.toolStripSeparator6,
            this.toolStripLabel2,
            this.cellsCountTextBox});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(971, 29);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip";
            // 
            // startButton
            // 
            this.startButton.CheckOnClick = true;
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(44, 26);
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // liczbaEpokLabel
            // 
            this.epochCountLabel.Name = "epochCountLabel";
            this.epochCountLabel.Size = new System.Drawing.Size(91, 26);
            this.epochCountLabel.Text = "Epoch count:";
            // 
            // epochCountTextBox
            // 
            this.epochCountTextBox.Name = "epochCountTextBox";
            this.epochCountTextBox.Size = new System.Drawing.Size(100, 29);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(44, 26);
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // cellTypeLabel
            // 
            this.cellTypeLabel.Name = "cellTypeLabel";
            this.cellTypeLabel.Size = new System.Drawing.Size(94, 26);
            this.cellTypeLabel.Text = "Cell type:";
            // 
            // cellTypeComboBox
            // 
            this.cellTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cellTypeComboBox.Name = "cellTypeComboBox";
            this.cellTypeComboBox.Size = new System.Drawing.Size(121, 29);
            this.cellTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 26);
            this.toolStripLabel1.Text = "Rule:";
            // 
            // ruleComboBox
            // 
            this.ruleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ruleComboBox.Name = "ruleComboBox";
            this.ruleComboBox.Size = new System.Drawing.Size(121, 29);
            this.ruleComboBox.SelectedIndexChanged += new System.EventHandler(this.ruleComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // randomizeStatesButton
            // 
            this.randomizeStatesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.randomizeStatesButton.Image = ((System.Drawing.Image)(resources.GetObject("randomizeStatesButton.Image")));
            this.randomizeStatesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.randomizeStatesButton.Name = "randomizeStatesButton";
            this.randomizeStatesButton.Size = new System.Drawing.Size(87, 26);
            this.randomizeStatesButton.Text = "Randomize states";
            this.randomizeStatesButton.Click += new System.EventHandler(this.randomizeStatesButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(104, 26);
            this.toolStripLabel2.Text = "Cells count:";
            // 
            // cellsCountTextBox
            // 
            this.cellsCountTextBox.Name = "cellsCountTextBox";
            this.cellsCountTextBox.Size = new System.Drawing.Size(100, 27);
            this.cellsCountTextBox.LostFocus += new System.EventHandler(this.cellsCountTextBox_LostFocus);
            // 
            // cellularAutomaton
            // 
            this.cellularAutomaton.BackColor = System.Drawing.Color.Transparent;
            this.cellularAutomaton.CellsCount = ((long)(1050));
            this.cellularAutomaton.DefaultState = 0;
            this.cellularAutomaton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cellularAutomaton.Location = new System.Drawing.Point(0, 57);
            this.cellularAutomaton.Name = "cellularAutomaton";
            this.cellularAutomaton.Rule = Rules.GameOfLife;
            this.cellularAutomaton.Size = new System.Drawing.Size(971, 580);
            this.cellularAutomaton.TabIndex = 0;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 662);
            this.Controls.Add(this.cellularAutomaton);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Gui";
            this.Text = "Cellular Automaton";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openFileMenuItem;
        private ToolStripMenuItem closeMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusBar;
        private ToolStrip toolStrip;
        private ToolStripSeparator toolStripSeparator1;
        private CellularAutomaton cellularAutomaton;
        private ToolStripButton startButton;
        private ToolStripButton stopButton;
        private ToolStripProgressBar progressBar;
        private ToolStripLabel epochCountLabel;
        private ToolStripTextBox epochCountTextBox;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem saveFileMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripComboBox cellTypeComboBox;
        private ToolStripButton randomizeStatesButton;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripLabel cellTypeLabel;
        private ToolStripSeparator toolStripSeparator3;
        Task evolutionTask;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox ruleComboBox;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox cellsCountTextBox;
    }
}

