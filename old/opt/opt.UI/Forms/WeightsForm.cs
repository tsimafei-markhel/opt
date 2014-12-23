using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Solvers.IntegralCriterion;
using opt.UI.Helpers;
using opt.Xml;

namespace opt.UI.Forms
{
    public partial class WeightsForm : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        public WeightsForm()
        {
            InitializeComponent();
        }

        public WeightsForm(
            Form prevForm,
            Model model)
        {
            InitializeComponent();

            // Подстройка интерфейса
            this.Left = prevForm.Left;
            this.Top = prevForm.Top;
            if (this.FormBorderStyle != FormBorderStyle.FixedSingle)
            {
                this.WindowState = prevForm.WindowState;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Width = prevForm.Width;
                this.Height = prevForm.Height;
            }

            this._prevForm = prevForm;
            this._model = model;

            this.FillWeightsCombo();
            this.FillDataGrid();

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void FillDataGrid()
        {
            this.dgvWeights.SuspendLayout();

            this.dgvWeights.Rows.Clear();

            foreach(Criterion crit in this._model.Criteria.Values)
            {
                int rowId = this.dgvWeights.Rows.Add();
                this.dgvWeights.Rows[rowId].Cells[0].Value = crit.Id;
                this.dgvWeights.Rows[rowId].Cells[1].Value = crit.Name;
                this.dgvWeights.Rows[rowId].Cells[2].Value = crit.Weight.ToString();
            }

            this.dgvWeights.ResumeLayout();
        }

        private void FillWeightsCombo()
        {
            DataGridViewComboBoxCell combo =
                (DataGridViewComboBoxCell)this.dgvWeights.Columns[2].CellTemplate;
            string[] vals = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            combo.Items.AddRange(vals);
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void WeightsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnPrevious_Click(object sender, System.EventArgs e)
        {
            // Подстройка интерфейса
            this._prevForm.Left = this.Left;
            this._prevForm.Top = this.Top;
            if (this._prevForm.FormBorderStyle != FormBorderStyle.FixedSingle)
            {
                this._prevForm.WindowState = this.WindowState;
            }
            if (this._prevForm.WindowState == FormWindowState.Normal)
            {
                this._prevForm.Width = this.Width;
                this._prevForm.Height = this.Height;
            }

            this._prevForm.Show();
            this.Hide();
        }

        private void btnSaveMatrix_Click(object sender, System.EventArgs e)
        {
            if (this.dlgSaveModel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlModelProvider.Save(this._model, this.dlgSaveModel.FileName);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError("Невозможно выполнить сохранение по указанному пути\nОригинальное сообщение: " + ex.Message);
                    return;
                }
                this.dlgSaveModel.FileName = string.Empty;
            }
        }

        private void btnShowMatrixForm_Click(object sender, System.EventArgs e)
        {
            MatrixForm matrix = new MatrixForm(this._model);
            matrix.ShowDialog();
            matrix.Dispose();
        }

        private void dgvWeights_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            TId critId = (TId)this.dgvWeights[0, e.RowIndex].Value;
            int weight = -1;
            try
            {
                weight = Convert.ToInt32(e.FormattedValue);
            }
            catch (Exception)
            {
                // Значение не из той ячейки, что нужно,
                // оставим без внимания
                e.Cancel = false;
                return;
            }

            // Это число и все ок?
            if (weight > 0 && weight < 11)
            {
                // Сохраним введенное значение!
                this._model.Criteria[critId].Weight = weight;
            }
            else
            {
                MessageBoxHelper.ShowError(
                    "Введенное для критерия '" +
                    this._model.Criteria[critId].Name +
                    "' значение веса (" + weight.ToString() +
                    ") выходит за границы допустимого диапазона\n" +
                    "Минимально возможное значение веса: 1" +
                    "\nМаксимально возможное значение веса: 10");
                e.Cancel = true;
                return;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            IntegralCriterionMethods method = IntegralCriterionMethods.AdditiveCriterion;
            if (this.rbnAdditiveCriterion.Checked)
            {
                if (this.chbUtilityFunction.Checked)
                {
                    method = IntegralCriterionMethods.AdditiveCriterionWithUtilityFunction;
                }
                else
                {
                    method = IntegralCriterionMethods.AdditiveCriterion;
                }
            }
            if (this.rbnMultiplicativeCriterion.Checked)
            {
                if (this.chbUtilityFunction.Checked)
                {
                    //method = IntegralCriterionMethods.MultiplicativeCriterionWithUtilityFunction;
                    throw new NotImplementedException();
                }
                else
                {
                    // Проверим, все ли критерии имеют одинаковый тип
                    if (MultiplicativeCriterionSolver.CriteriaHaveSimilarType(this._model))
                    {
                        method = IntegralCriterionMethods.MultiplicativeCriterion;
                    }
                    else
                    {
                        // Критерии имеют разный тип. Скажем пользователю, 
                        // что нельзя ПОКА ЧТО использовать этот метод для 
                        // поиска окончательного решения
                        MessageBoxHelper.ShowStop("Критерии в модели имеют разный тип: некоторые максимизируются, а некоторые минимизируются\nК сожалению, выбранный метод поиска окончательного решения работает только для моделей,\nв которых все критерии имеют одинаковый тип");
                        return;
                    }
                }
            }
            if (this.rbnMiniMax.Checked)
            {
                method = IntegralCriterionMethods.MinimaxMethod;
            }

            if (this.rbnGeneticAlgorithm.Checked)
            {
                this._nextForm = new AdditiveGaParamsForm(this, this._model);
            }
            else
            {
                if (this.chbUtilityFunction.Checked)
                {
                    this._nextForm = new UtilityFunctionForm(this, this._model, method);
                }
                else if (!this.chbUtilityFunction.Checked)
                {
                    this._nextForm = new IntegralResultsForm(this, this._model, null, method);
                }
            }
            

            this._nextForm.Show();
            this.Hide();
        }

        private void rbnGeneticAlgorithm_CheckedChanged(object sender, EventArgs e)
        {
            this.chbUtilityFunction.Enabled = !(this.rbnGeneticAlgorithm.Checked);
            if (this.chbUtilityFunction.Checked)
            {
                this.chbUtilityFunction.Checked = false;
            }
        }
    }
}