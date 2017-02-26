using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomaton
{
    public partial class Gui : Form
    {
        public Gui()
        {
            InitializeComponent();
            cellTypeComboBox.ComboBox.DataSource = cellularAutomaton.GetStates();
            ruleComboBox.ComboBox.DataSource = cellularAutomaton.GetRules();
            ruleComboBox.ComboBox.SelectedIndex = 0;
            cellTypeComboBox.ComboBox.SelectedIndex = 1;
            cellsCountTextBox.Text = cellularAutomaton.CellsCount.ToString();
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cellularAutomaton.DefaultState = cellTypeComboBox.ComboBox.SelectedIndex;
        }

        private void randomizeStatesButton_Click(object sender, EventArgs e)
        {
            cellularAutomaton.RandomizeStates();
            cellularAutomaton.Refresh();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            statusBar.Text = " Evolution";
            if (epochCountTextBox.Text == "")
            {
                cellularAutomaton.Evolution(); //MessageBox.Show("Musisz wpisać liczbę epok");
                //statusBar.Text = "Błąd";
            }
            else
            {
                progressBar.Maximum = int.Parse(epochCountTextBox.Text);
                startButton.Checked = true;

                evolutionTask = new Task(EvolutionLoop);
                evolutionTask.RunSynchronously();
            }
            startButton.Checked = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            evolutionTask.Wait();
            statusBar.Text = "Stopped";
        }


        private void EvolutionLoop()
        {
            statusBar.Text = "Evolution";
            statusBar.Invalidate();
            for (var i = 0; i < int.Parse(epochCountTextBox.Text); i++)
            {
                cellularAutomaton.Evolution();
                progressBar.Value = i + 1;
                Thread.Sleep(0);
                Thread.Sleep(100);
            }
            statusBar.Text = "Ready";
        }

        private void ruleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cellularAutomaton.Rule = (Rules) ruleComboBox.SelectedIndex;
            cellularAutomaton.Refresh();

            /* switch ((Rules)ruleComboBox.SelectedIndex)
             {
                 case Rules.TrokaAutomaton:
                     ruleComboBox.ComboBox.DataSource = cellularAutomaton.getRules();
                     typKomorkiComboBox.ComboBox.SelectedIndex=0;
                     
                     break;
 
                 case Rules.GameOfLife:
                     //ruleComboBox.MaxDropDownItems = 2;
                     List<Rules> tab = cellularAutomaton.getRules();
                     for (int i = 2; i < tab.Count; i++)
                         tab.RemoveAt(i);
                     ruleComboBox.ComboBox.DataSource = tab;
                     ruleComboBox.ComboBox.SelectedIndex = 1;
                     typKomorkiComboBox.ComboBox.SelectedIndex = 0;
                         break;
 
                 case Rules.Darwinia:
                     ruleComboBox.ComboBox.DataSource = cellularAutomaton.getRules();
                     typKomorkiComboBox.ComboBox.SelectedIndex=0;
                     break;
 
                 case Rules.PrzeplywCiepla:
                     ruleComboBox.ComboBox.DataSource = cellularAutomaton.getRules();
                     typKomorkiComboBox.ComboBox.SelectedIndex=0;
                     break;
             }*/
        }

        private void cellsCountTextBox_LostFocus(object sender, EventArgs e)
        {
            long a;
            if (long.TryParse(cellsCountTextBox.Text, out a))
                if (a != cellularAutomaton.CellsCount)
                    cellularAutomaton.CellsCount = a;

            cellsCountTextBox.Text = cellularAutomaton.CellsCount.ToString();
        }
    }
}