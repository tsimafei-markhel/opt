using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.Solvers.IntegralCriterion;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.UI.Forms
{
    public partial class UtilityFunctionForm : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private IntegralCriterionMethods _method;
        private Dictionary<TId, UtilityFunction> _utFuncs;
        private Criterion[] _modelCriteria;
        private TId _currentCriterionId;

        private TrackBar[] _trackBars;
        private Label[] _critValLabels;
        private Label[] _uFValLabels;

        public UtilityFunctionForm()
        {
            InitializeComponent();
        }

        public UtilityFunctionForm(
            Form prevForm,
            Model model,
            IntegralCriterionMethods method)
        {
            InitializeComponent();

            // Подстройка интерфейса
            this.Left = prevForm.Left;
            this.Top = prevForm.Top;
            if (this.FormBorderStyle != FormBorderStyle.FixedSingle)
            {
                this.WindowState = prevForm.WindowState;
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.Width = prevForm.Width;
                    this.Height = prevForm.Height;
                }
            }

            this._prevForm = prevForm;
            this._model = model;

            this._method = method;
            this.lblMethod.Text = "Выбранный метод свертки критериев:\n" + 
                IntegralCriterionMethodsManager.GetIntegralCriterionMethodName(method);

            // Инициализируем функции полезности
            this.InitCriteriaArray();
            this.InitUtilityFunctions();
            this._currentCriterionId = 0;
            this.InitUI();
            this.SetUtilityFunctionUI(this._currentCriterionId);

            // Маленькая проверочка
            if (this._model.Criteria.Count < 2)
            {
                this.btnNextCriterion.Enabled = false;
            }

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UtilityFunctionForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            this._nextForm = new IntegralResultsForm(
                this, this._model, this._utFuncs, this._method);
            this._nextForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Метод для инициализации массива с критериями
        /// </summary>
        private void InitCriteriaArray()
        {
            this._modelCriteria = new Criterion[this._model.Criteria.Count];
            this._model.Criteria.Values.CopyTo(this._modelCriteria, 0);
        }

        /// <summary>
        /// Метод для инициализации словаря с функциями полезности
        /// </summary>
        private void InitUtilityFunctions()
        {
            this._utFuncs = new Dictionary<TId, UtilityFunction>();
            foreach (Criterion crit in this._model.Criteria.Values)
            {
                // Найдем минимальное и максимальное значения критерия
                double critMinValue = double.MaxValue;
                double critMaxValue = double.MinValue;
                foreach (Experiment exp in this._model.Experiments.Values)
                {
                    if (exp.IsActive)
                    {
                        double critValue = exp.CriterionValues[crit.Id];
                        if (critValue > critMaxValue)
                        {
                            critMaxValue = critValue;
                        }
                        if (critValue < critMinValue)
                        {
                            critMinValue = critValue;
                        }
                    }
                }

                // Добавим новую функцию полезности
                // Прибавление и отнимание малого числа - это вынужденный 
                // хак, сделанный из-за проблем с точностью типа double,
                // которые приводили к тому, что некоторые значения "выскакивали" 
                // из диапазона, покрываемого ФП
                this._utFuncs.Add(
                    crit.Id, 
                    new UtilityFunction(crit.Id, critMinValue - 0.00001, critMaxValue + 0.00001, crit.Type));
            }
        }

        /// <summary>
        /// Метод для инициализации UI
        /// </summary>
        private void InitUI()
        {
            // Объединим все TrackBar'ы в массив, чтобы проще 
            // было с ними работать
            this._trackBars = new TrackBar[10];
            this._trackBars[0] = this.tb1;
            this._trackBars[1] = this.tb2;
            this._trackBars[2] = this.tb3;
            this._trackBars[3] = this.tb4;
            this._trackBars[4] = this.tb5;
            this._trackBars[5] = this.tb6;
            this._trackBars[6] = this.tb7;
            this._trackBars[7] = this.tb8;
            this._trackBars[8] = this.tb9;
            this._trackBars[9] = this.tb10;

            // То же самое проделаем с метками. 
            // Индексы во всех трех массивах будут 
            // совпадать, как нам и нужно
            this._critValLabels = new Label[10];
            this._critValLabels[0] = this.lbl1;
            this._critValLabels[1] = this.lbl2;
            this._critValLabels[2] = this.lbl3;
            this._critValLabels[3] = this.lbl4;
            this._critValLabels[4] = this.lbl5;
            this._critValLabels[5] = this.lbl6;
            this._critValLabels[6] = this.lbl7;
            this._critValLabels[7] = this.lbl8;
            this._critValLabels[8] = this.lbl9;
            this._critValLabels[9] = this.lbl10;

            this._uFValLabels = new Label[10];
            this._uFValLabels[0] = this.lblUFVal1;
            this._uFValLabels[1] = this.lblUFVal2;
            this._uFValLabels[2] = this.lblUFVal3;
            this._uFValLabels[3] = this.lblUFVal4;
            this._uFValLabels[4] = this.lblUFVal5;
            this._uFValLabels[5] = this.lblUFVal6;
            this._uFValLabels[6] = this.lblUFVal7;
            this._uFValLabels[7] = this.lblUFVal8;
            this._uFValLabels[8] = this.lblUFVal9;
            this._uFValLabels[9] = this.lblUFVal10;
        }

        /// <summary>
        /// Метод для установки UI в состояние, пригодное для 
        /// ввода/просмотра значений функции полезности
        /// </summary>
        /// <param name="critArrayId">Индекс критерия в 
        /// МАССИВЕ КРИТЕРИЕВ this._modelCriteria</param>
        private void SetUtilityFunctionUI(TId critArrayId)
        {
            Criterion crit = this._modelCriteria[critArrayId];
            UtilityFunction utFunc = this._utFuncs[crit.Id];

            // ХАРДКОД ahead !!! мне так стыдно
            if (utFunc.FixedPoints.Count != 10)
            {
                MessageBoxHelper.ShowError("Фиксированных точек больше или меньше, чем нужно!");
            }

            this.lblCriterionName.Text = crit.Name;

            int fpCounter = 0;
            foreach (KeyValuePair<double, double> ufPoint in utFunc.FixedPoints)
            {
                this._trackBars[fpCounter].Value = Convert.ToInt32(ufPoint.Value * 100);
                this._critValLabels[fpCounter].Text = ufPoint.Key.ToString(SettingsManager.Instance.DoubleStringFormat);
                this._uFValLabels[fpCounter].Text = ufPoint.Value.ToString("F2");
                // Запомним, какой из фиксированных точек соответствуют данные 
                // контролы
                this._trackBars[fpCounter].Tag = ufPoint.Key;

                fpCounter++;
            }

            // Перерисуем графичек
            UtilityFunctionDrawer.DrawUtilityFunction(
                this.pbUtilityFunction.CreateGraphics(),
                this._utFuncs[this._currentCriterionId]);
        }

        /// <summary>
        /// Метод-обработчик перемещения ползунка TrackBar'ов
        /// </summary>
        private void tb_Scroll(object sender, EventArgs e)
        {
            // Получим индекс трекбара, который сдвинулся
            int idx = Array.IndexOf(this._trackBars, (TrackBar)sender);
            // Получим ключ фиксированной точки, для которой изменилось 
            // значение функции полезности
            double ufKey = (double)this._trackBars[idx].Tag;
            // Получим новое значение функции полезности
            double newUFValue = (double)this._trackBars[idx].Value / (double)100;

            // Обновим значение функции полезности для данной фиксированной
            // точки и UI
            this._utFuncs[this._currentCriterionId].FixedPoints[ufKey] = newUFValue;
            this._uFValLabels[idx].Text = newUFValue.ToString("F2");

            // Перерисуем графичек
            UtilityFunctionDrawer.DrawUtilityFunction(
                this.pbUtilityFunction.CreateGraphics(),
                this._utFuncs[this._currentCriterionId]);
        }

        private void pbUtilityFunction_Paint(object sender, PaintEventArgs e)
        {
            // Перерисуем графичек
            UtilityFunctionDrawer.DrawUtilityFunction(
                e.Graphics,
                this._utFuncs[this._currentCriterionId]);
        }

        private void btnCriterionInfo_Click(object sender, EventArgs e)
        {
            string message = "Имя критерия: " +
                this._modelCriteria[this._currentCriterionId].Name +
                "\nИдентификатор переменной: " +
                this._modelCriteria[this._currentCriterionId].VariableIdentifier +
                "\nТип критерия: " +
                CriterionTypeManager.GetCriterionTypeName(
                    this._modelCriteria[this._currentCriterionId].Type) +
                "\nВесовой коэффициент: " +
                this._modelCriteria[this._currentCriterionId].Weight.ToString();

            MessageBoxHelper.ShowInformation(message);
        }

        private void btnNextCriterion_Click(object sender, EventArgs e)
        {
            this._currentCriterionId++;
            if (this._currentCriterionId == this._modelCriteria.GetLength(0) - 1)
            {
                this.btnNextCriterion.Enabled = false;
            }
            if (this._currentCriterionId > 0)
            {
                this.btnPreviousCriterion.Enabled = true;
            }
            this.SetUtilityFunctionUI(this._currentCriterionId);
        }

        private void btnPreviousCriterion_Click(object sender, EventArgs e)
        {
            this._currentCriterionId--;
            if (this._currentCriterionId == 0)
            {
                this.btnPreviousCriterion.Enabled = false;
            }
            if (this._currentCriterionId < this._modelCriteria.GetLength(0) - 1)
            {
                this.btnNextCriterion.Enabled = true;
            }
            this.SetUtilityFunctionUI(this._currentCriterionId);
        }
    }
}