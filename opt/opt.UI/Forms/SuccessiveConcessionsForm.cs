using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using opt.DataModel;
using opt.Solvers.SuccessiveConcessions;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    public partial class SuccessiveConcessionsForm : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private TId[] _criteriaPriorities;
        private CriterialConcessions _concessions;
        private Model _currentState;
        private ScMethodResult _result;

        private bool _showConstraints;
        private bool _showParams;

        public SuccessiveConcessionsForm()
        {
            InitializeComponent();
        }

        public SuccessiveConcessionsForm(
            Form prevForm,
            Model model,
            TId[] criteriaPriorities)
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
            this._showConstraints = false;
            this._showParams = false;
            this._criteriaPriorities = (TId[])criteriaPriorities.Clone();

            // Создадим набор уступок, не заполняя их значений
            this.InitConcessions();

            // Заполним таблицу критериев в том порядке, 
            // который указал пользователь на предыдыущем шаге
            this.FillCriteriaGrid();

            // Решим задачу и заполним матрицу
            this.FindDecision();

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void FindDecision()
        {
            // Применим набор уступок к матрице решений
            TId sortingCritId = ScSolver.FindSortingCriterionId(this._concessions);
            // Применять будем к копии модели
            byte[] modelCopyBytes = Model.Serialize(this._model);
            this._currentState = Model.Deserialize(modelCopyBytes);
            this._result = ScSolver.ApplyConcessions(ref this._currentState, this._concessions, sortingCritId);

            // Заполним матрицу решений
            ScDataGridFiller.FillMidDataGrid(
                this._currentState,
                this.dgvData,
                this._result,
                this._concessions,
                sortingCritId,
                this._showConstraints,
                this._showParams);
        }

        private void FillCriteriaGrid()
        {
            this.dgvConcessions.SuspendLayout();

            this.dgvConcessions.Rows.Clear();

            int row = -1;
            foreach (TId critId in this._criteriaPriorities)
            {
                row = this.dgvConcessions.Rows.Add();
                this.dgvConcessions[0, row].Value = critId;
                this.dgvConcessions[1, row].Value = this._model.Criteria[critId].Name;
                this.dgvConcessions[2, row].Value = string.Empty;
            }

            // Последний рядок нельзя редактировать
            this.dgvConcessions[2, row].ReadOnly = true;
            this.dgvConcessions[2, row].Style.BackColor = Color.LightGray;

            this.dgvConcessions.ResumeLayout();
        }

        private void InitConcessions()
        {
            this._concessions = new CriterialConcessions();

            int critCount = this._criteriaPriorities.GetLength(0);
            for (int crit = 0; crit < critCount; crit++)
            {
                TId critId = this._criteriaPriorities[crit];
                CriterialConcession concession =
                    new CriterialConcession(this._model.Criteria[critId]);
                this._concessions.Add(concession);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
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

        private void btnOptions_Click(object sender, EventArgs e)
        {
            int xPos = this.Location.X + ((Button)sender).Location.X;
            int yPos = this.Location.Y + ((Button)sender).Location.Y +
                2 * ((Button)sender).Size.Height;
            this.optionsMenu.Show(xPos, yPos);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SuccessiveConcessionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bool valuesOk = true;
            foreach (DataGridViewRow row in this.dgvConcessions.Rows)
            {
                // Идентификатор критерия, для которого будет задана уступка, 
                // считанная из этого рядка
                TId critId = (TId)row.Cells[0].Value;

                // Считаем и превратим в число значение уступки
                string concessionValueString = row.Cells[2].Value.ToString().Trim();
                if (string.IsNullOrEmpty(concessionValueString))
                {
                    break;
                }
                double concessionValue = double.NaN;
                try
                {
                    concessionValue = Convert.ToDouble(concessionValueString);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(
                        "Не удалось преобразовать в число значение уступки для критерия '" +
                        this._model.Criteria[critId].Name + "'\nОригинальное сообщение: " +
                        ex.Message);
                    valuesOk = false;
                    break;
                }

                // Проверим, положительное ли значение уступки - оно должно задаваться по
                // абсолютной величине
                if (concessionValue < 0)
                {
                    DialogResult result = MessageBox.Show("Значение уступки, введенное для критерия '" + this._model.Criteria[critId].Name + "', отрицательное, а должно быть положительным\nИзменить знак?", Program.ApplicationSettings.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        concessionValue *= -1;
                        row.Cells[2].Value = concessionValue.ToString(SettingsManager.Instance.DoubleStringFormat);
                    }
                    else
                    {
                        valuesOk = false;
                        break;
                    }
                }

                // Теперь, кажется, все в порядке, можно применять это значение
                this._concessions[critId].Concession = concessionValue;
                this._concessions[critId].IsUsable = true;
            }

            // Когда все нужные значения прочитаны, можно решить задачу 
            // методом последовательных уступок
            if (valuesOk)
            {
                this.FindDecision();
            }
        }

        private void btnResetToSelection_Click(object sender, EventArgs e)
        {
            if (this.dgvConcessions.SelectedRows.Count < 1)
            {
                MessageBoxHelper.ShowExclamation("Необходимо выбрать критерий, к которому произведется откат");
            }
            else
            {
                int selRowId = this.dgvConcessions.SelectedRows[0].Index;
                foreach (DataGridViewRow row in this.dgvConcessions.Rows)
                {
                    // Если данный рядок (row) находится в талице ниже выбранного,
                    // то очистим знчение уступки для него
                    if (row.Index >= selRowId)
                    {
                        TId critId = (TId)row.Cells[0].Value;
                        row.Cells[2].Value = string.Empty;
                        this._concessions[critId].Clear();
                    }
                }
                this.FindDecision();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this._nextForm = new SuccessiveConcessionsResultsForm(this, this._currentState, this._result);
            this._nextForm.Show();
            this.Hide();
        }

        private void mnuShowParams_Click(object sender, EventArgs e)
        {
            this._showParams = this.mnuShowParams.Checked;
            TId sortingCritId = ScSolver.FindSortingCriterionId(this._concessions);
            ScDataGridFiller.FillMidDataGrid(
                this._currentState,
                this.dgvData,
                this._result,
                this._concessions,
                sortingCritId,
                this._showConstraints,
                this._showParams);
        }

        private void mnuShowConstraints_Click(object sender, EventArgs e)
        {
            this._showConstraints = this.mnuShowConstraints.Checked;
            TId sortingCritId = ScSolver.FindSortingCriterionId(this._concessions);
            ScDataGridFiller.FillMidDataGrid(
                this._currentState,
                this.dgvData,
                this._result,
                this._concessions,
                sortingCritId,
                this._showConstraints,
                this._showParams);
        }
    }
}