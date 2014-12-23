using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.UI.Forms
{
    public partial class CriteriaPriorityForm : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        // Одномерный массив 1хN, где 
        // N - число критериев оптимальности.
        // Хранит Id криетриев в том порядке, 
        // в котором их выстроил юзер
        private TId[] _criteriaPriorities;

        public CriteriaPriorityForm()
        {
            InitializeComponent();
        }

        public CriteriaPriorityForm(
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

            // Инициализируем порядок критериев
            this.InitCriteriaPriorities();
            // В соответствии с имеющимся порядком заполним таблицу
            this.FillDataTable(-1);

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void CriteriaPriorityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnShowMatrixForm_Click(object sender, EventArgs e)
        {
            MatrixForm matrix = new MatrixForm(this._model);
            matrix.ShowDialog();
            matrix.Dispose();
        }

        /// <summary>
        /// Метод, инициализирующий массив приоритетов критериев. 
        /// Критерии идут в том порядке, в котором их ввел пользователь 
        /// при создании модели
        /// </summary>
        private void InitCriteriaPriorities()
        {
            int critCount = this._model.Criteria.Count;
            this._criteriaPriorities = new TId[critCount];
            int i = 0;
            foreach (Criterion crit in this._model.Criteria.Values)
            {
                this._criteriaPriorities[i] = crit.Id;
                i++;
            }
        }

        /// <summary>
        /// Метод, заполняющий таблицу в соответствии с имеющимся 
        /// порядком критериев
        /// </summary>
        /// <param name="rowToSelectIndex">Индекс строки, которую нужно выделить 
        /// (подсветить) в таблице. Если не надо подсвечивать, то -1</param>
        private void FillDataTable(int rowToSelectIndex)
        {
            this.dgvData.SuspendLayout();

            this.dgvData.Rows.Clear();

            int critCount = this._criteriaPriorities.GetLength(0);

            for (int row = 0; row < critCount; row++)
            {
                this.dgvData.Rows.Add();
                this.dgvData.Rows[row].Cells[0].Value = (row + 1).ToString();
                this.dgvData.Rows[row].Cells[1].Value =
                    this._model.Criteria[this._criteriaPriorities[row]].Name;
                this.dgvData.Rows[row].Cells[2].Value =
                    CriterionTypeManager.GetCriterionTypeName(
                        this._model.Criteria[this._criteriaPriorities[row]].Type
                    );
            }

            this.dgvData.ClearSelection();

            if (rowToSelectIndex != -1 && rowToSelectIndex > -1 && rowToSelectIndex < critCount)
            {
                this.dgvData.Rows[rowToSelectIndex].Selected = true;
            }

            this.dgvData.ResumeLayout();
        }

        /// <summary>
        /// Метод для смещения Id критерия в массиве приоритетов 
        /// по его текущей позиции и смещению
        /// </summary>
        /// <param name="currentPosition">Текущая позиция Id критерия в 
        /// массиве приоритетов (индекс элемента массива)</param>
        /// <param name="delta">Смещение: 1 или -1</param>
        private void MoveCriterion(int currentPosition, int delta)
        {
            if (currentPosition < 0 || currentPosition >= this._criteriaPriorities.GetLength(0))
            {
                throw new ArgumentOutOfRangeException("'currentPosition' is out of bounds");
            }
            if (delta != -1 && delta != 1)
            {
                throw new ArgumentOutOfRangeException("'delta' must be 1 or -1");
            }

            TId temp = this._criteriaPriorities[currentPosition];
            this._criteriaPriorities[currentPosition] = 
                this._criteriaPriorities[currentPosition + delta];
            this._criteriaPriorities[currentPosition + delta] =
                temp;
            
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count > 0)
            {
                int currentPosition = this.dgvData.SelectedRows[0].Index;
                if (currentPosition > 0)
                {
                    this.MoveCriterion(currentPosition, -1);
                    this.FillDataTable(currentPosition - 1);
                }
            }
            else
            {
                MessageBoxHelper.ShowExclamation("Сначала выберите строку в таблице");
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count > 0)
            {
                int currentPosition = this.dgvData.SelectedRows[0].Index;
                if (currentPosition < this.dgvData.Rows.Count - 1)
                {
                    this.MoveCriterion(currentPosition, 1);
                    this.FillDataTable(currentPosition + 1);
                }
            }
            else
            {
                MessageBoxHelper.ShowExclamation("Сначала выберите строку в таблице");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this._nextForm = new SuccessiveConcessionsForm(this, this._model, this._criteriaPriorities);
            this._nextForm.Show();
            this.Hide();
        }
    }
}