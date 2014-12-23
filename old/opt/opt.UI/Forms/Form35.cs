using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.Text;
using opt.UI.Helpers;
using opt.Xml;

namespace opt.UI.Forms
{
    internal partial class Form35 : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private static readonly TextModelProviderSettings textProviderSettings = new TextModelProviderSettings()
        {
            InformationFilePath = Application.StartupPath + Program.ApplicationSettings.QuantitiesFileName,
            ParametersFilePath = Application.StartupPath + Program.ApplicationSettings.ParametersFileName,
            ResultFilePath = Application.StartupPath + Program.ApplicationSettings.ResultsFileName
        };

        public Form35()
        {
            InitializeComponent();
        }

        public Form35(
            Form prevForm,
            Model model)
        {
            InitializeComponent();

            SetCalcAppFromCommandLine();

#if DUMMY
            // Выключим интерфейс для умников
            this.label1.Visible = false;
            this.txtDataFileName.Visible = false;
            this.btnChooseDataFile.Visible = false;
            this.label2.Visible = false;
            this.txtExternalApplicationExecutable.Visible = false;
            this.btnChooseExternalApp.Visible = false;
            this.rbnExpressionsEvaluate.Visible = false;
            this.pbExpressionEvaluateOption.Visible = false;
            this.lblNCalc.Visible = false;
            this.lblNCalcLink.Visible = false;
            this.lblNCalcVersion.Visible = false;
            // Включим интерфейс для дурачков
            this.label3.Visible = true;
            this.txtModelExecutable.Visible = true;
            this.btnChooseModelExecutable.Visible = true;
#endif

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

#if !DUMMY
            // Если выражения заданы не для всех критериев и ограничений, 
            // то нельзя использовать последний вариант
            // НЕ РАБОТАЕТ В РЕЖИМЕ ДЛЯ ДУРАЧКОВ
            if (!this._model.CheckExpressionsExistence())
            {
                this.rbnExpressionsEvaluate.Enabled = false;
                this.ttpExpressionEvaluationOption.SetToolTip(
                    this.pbExpressionEvaluateOption,
                    "Чтобы использовать этот вариант, необходимо задать выражения \nдля всех критериев оптимальности и функциональных ограничений");
                this.pbExpressionEvaluateOption.Visible = true;
            }
#endif

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void SetCalcAppFromCommandLine()
        {
#if !DUMMY
            string calcAppFilePath = Program.ApplicationSettings.CalcAppFilePath;
            if (!string.IsNullOrEmpty(calcAppFilePath))
            {
                txtExternalApplicationExecutable.Text = calcAppFilePath;
                rbnAutomatic.Checked = true;
            }
#endif
        }

        private void Form35_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSaveMatrix_Click(object sender, EventArgs e)
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Очистим любые значения критериев и ограничений,
            // какие только там могли быть
            foreach (KeyValuePair<TId, Experiment> exp in this._model.Experiments)
            {
                exp.Value.CriterionValues.Clear();
                exp.Value.ConstraintValues.Clear();
            }

            if (this.rbnAutomatic.Checked)
            {
                // Автоматическая генерация

                // Соберем данные, проверим, все ли есть
#if DUMMY
                string externalAppPath = this.txtModelExecutable.Text.Trim();
#else
                string externalAppPath = this.txtExternalApplicationExecutable.Text.Trim();
                string dataFilePath = this.txtDataFileName.Text.Trim();
                if (string.IsNullOrEmpty(dataFilePath))
                {
                    MessageBoxHelper.ShowExclamation("Для проведения автоматического расчета необходимо выбрать файл обмена данными между этим приложением и программой, которая его осуществит");
                    return;
                }
#endif
                if (string.IsNullOrEmpty(externalAppPath))
                {
                    MessageBoxHelper.ShowExclamation("Для проведения автоматического расчета необходимо выбрать внешнее приложение, которое его осуществит");
                    return;
                }

                // Если все на месте, то отключим юзера,
                // чтоб не мешал
                this.DisableUser(true);
                // Спросим, хочет ли он запустить авторасчет?
                DialogResult result = MessageBox.Show(
                    "Сейчас будет запущено внешнее приложение, выполняющее расчет значений критериев оптимальности и функциональных ограничений\nПока оно будет работать, " +
                    Program.ApplicationSettings.ApplicationName + " будет оставаться неактивным и ожидать завершения расчета\nЗапустить расчет?",
                    Program.ApplicationSettings.ApplicationName,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
#if DUMMY
                    try
                    {
                        TextModelProvider.WriteModel(this._model, textProviderSettings);
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowError("Не удалось создать файлы с данными о модели\nОригинальное сообщение: " + ex.Message);
                        return;
                    }

                    // Запустим программу на выполнение
                    ProcessStartInfo midPrgInfo = new ProcessStartInfo();
                    midPrgInfo.FileName = externalAppPath;
                    midPrgInfo.WorkingDirectory = Path.GetDirectoryName(externalAppPath);
                    midPrgInfo.UseShellExecute = true;

                    Process extAppProc = Process.Start(midPrgInfo);
                    extAppProc.EnableRaisingEvents = true;
                    extAppProc.Exited += new EventHandler(extAppProc_Exited);
#else
                    // Запишем файл модели
                    try
                    {
                        XmlModelProvider.Save(this._model, dataFilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowError("Не удалось создать файл для обмена данными по указанному пути\nОригинальное сообщение: " + ex.Message);
                        return;
                    }
                    // Дождемся, пока будет создан файл
                    bool fileExists = false;
                    while (!fileExists)
                    {
                        if (System.IO.File.Exists(dataFilePath))
                        {
                            fileExists = true;
                        }
                        else
                        {
                            Thread.Sleep(500);
                        }
                    }
                    // Запуск внешней проги и ожидание расчета
                    ProcessStartInfo midPrgInfo = new ProcessStartInfo();
                    midPrgInfo.FileName = externalAppPath;
                    midPrgInfo.Arguments = "\"" + dataFilePath + "\"";
                    midPrgInfo.UseShellExecute = false;

                    Process extAppProc = Process.Start(midPrgInfo);
                    extAppProc.EnableRaisingEvents = true;
                    extAppProc.Exited += new EventHandler(extAppProc_Exited);
#endif
                }
                else
                {
                    // Опять включим юзера
                    this.DisableUser(false);
                }
            }
            else if (this.rbnManual.Checked)
            {
                // Если ввод ручной, покажем форму для этого
                this._nextForm = new Form40(this, this._model);
                this._nextForm.Show();
                this.Hide();
            }
            else if (this.rbnExpressionsEvaluate.Checked)
            {
                // Вычисление по введенным выражениям
                try
                {
                    ExpressionEvaluator.CalculateCriteriaValues(this._model);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                    return;
                }

                try
                {
                    if (this._model.FunctionalConstraints.Count > 0)
                    {
                        ExpressionEvaluator.CalculateConstraintsValues(this._model);
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                    return;
                }
                this._nextForm = new Form45(this, this._model);
                this._nextForm.Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Обработчик события, которое файрится, когда внешняя расчетная программа
        /// завершается
        /// </summary>
        void extAppProc_Exited(object sender, EventArgs e)
        {
            // Запустим метод формы для обработки завершения 
            // внешней расчетной программы
            try
            {
                this.Invoke(new ExternalAppFinishedDelegate(this.ExternalAppFinished));
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Произошла неожиданная ошибка!\nТекст ошибки: " + ex.Message + "\n Завершите приложение с помощью Диспетчера Задач");
                return;
            }
            // Такие танцы с бубном из-за того, что это событие
            // и вещи, которые надо обработать, когда оно происходит,
            // находятся в разных потоках
        }

        // Делегат для метода, который вызывается,
        // когда завершается внешняя программа
        delegate void ExternalAppFinishedDelegate();

        public void ExternalAppFinished()
        {
            // Вернем обратно юзера
            this.DisableUser(false);
#if DUMMY
            // Распарсим текстовик, который осилили дурачки
            this.ParseTextResults();
#else
            // Возьмем модель из файла
            if (System.IO.File.Exists(this.txtDataFileName.Text.Trim()))
            {
                this._model = XmlModelProvider.Open(this.txtDataFileName.Text.Trim());
            }
#endif
            // Проверим, что там программа насчитала
            if (this.CheckCritVals() && this.CheckConstrVals())
            {
                // Если все хорошо - покажем окно отображения/ввода значений
                // критериев оптимальности и ФО
                this._nextForm = new Form45(this, this._model);
                this._nextForm.Show();
                this.Hide();
            }
        }

#if DUMMY
        private void ParseTextResults()
        {
            try
            {
                TextModelProvider.ReadResultToModel(this._model, textProviderSettings);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Невозможно считать файл с результатами расчета\nОригинальное сообщение: " + ex.Message);
                return;
            }
        }
#endif

        private bool CheckCritVals()
        {
            foreach (KeyValuePair<TId, Criterion> crit in this._model.Criteria)
            {
                foreach (KeyValuePair<TId, Experiment> exp in this._model.Experiments)
                {
                    // Если в одном из экспериментов не задано значение данного критерия
                    if (!exp.Value.CriterionValues.ContainsKey(crit.Key))
                    {
                        // Тест провален
                        MessageBoxHelper.ShowError(
                            "Для эксперимента №" + exp.Value.Number.ToString() +
                            " не задано значение критерия '" + crit.Value.Name +
                            "'");
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckConstrVals()
        {
            foreach (KeyValuePair<TId, Constraint> constr in this._model.FunctionalConstraints)
            {
                foreach (KeyValuePair<TId, Experiment> exp in this._model.Experiments)
                {
                    // Если в одном из экспериментов не задано значение данного 
                    // функционального ограничения
                    if (!exp.Value.ConstraintValues.ContainsKey(constr.Key))
                    {
                        // Тест провален
                        MessageBoxHelper.ShowError(
                            "Для эксперимента №" + exp.Value.Number.ToString() +
                            " не задано значение функционального ограничения '" + constr.Value.Name +
                            "'");
                        return false;
                    }
                }
            }

            return true;
        }

        private void DisableUser(bool isUserDisabled)
        {
            this.ControlBox = !isUserDisabled;
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Enabled = !isUserDisabled;
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

        private void rbnAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDataFileName.Enabled = this.rbnAutomatic.Checked;
            this.txtExternalApplicationExecutable.Enabled = this.rbnAutomatic.Checked;
            this.label1.Enabled = this.rbnAutomatic.Checked;
            this.label2.Enabled = this.rbnAutomatic.Checked;
            this.btnChooseDataFile.Enabled = this.rbnAutomatic.Checked;
            this.btnChooseExternalApp.Enabled = this.rbnAutomatic.Checked;
        }

        private void btnChooseDataFile_Click(object sender, EventArgs e)
        {
            if (this.dlgDataFile.ShowDialog() == DialogResult.OK)
            {
                this.txtDataFileName.Text = this.dlgDataFile.FileName;
                this.dlgDataFile.FileName = string.Empty;
            }
        }

        private void btnChooseExternalApp_Click(object sender, EventArgs e)
        {
            if (this.dlgExternalApp.ShowDialog() == DialogResult.OK)
            {
                this.txtExternalApplicationExecutable.Text = this.dlgExternalApp.FileName;
                this.dlgExternalApp.FileName = string.Empty;
            }
        }

        private void rbnExpressionsEvaluate_CheckedChanged(object sender, EventArgs e)
        {
            this.lblNCalc.Enabled = this.rbnExpressionsEvaluate.Checked;
            this.lblNCalcLink.Enabled = this.rbnExpressionsEvaluate.Checked;
            this.lblNCalcVersion.Enabled = this.rbnExpressionsEvaluate.Checked;
        }

        private void lblNCalcLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo link1 = new System.Diagnostics.ProcessStartInfo();
            link1.FileName = "http://ncalc.codeplex.com/";
            link1.UseShellExecute = true;

            try
            {
                System.Diagnostics.Process.Start(link1);
            }
            catch {}
        }

        private void btnChooseModelExecutable_Click(object sender, EventArgs e)
        {
            this.dlgExternalApp.Filter = "Исполняемый файл (*.exe)|*.exe";
            this.dlgExternalApp.InitialDirectory = Application.StartupPath + "\\Models";
            this.dlgExternalApp.Multiselect = false;
            if (this.dlgExternalApp.ShowDialog() == DialogResult.OK)
            {
                this.txtModelExecutable.Text = this.dlgExternalApp.FileName;
                this.dlgExternalApp.FileName = string.Empty;
            }
        }
    }
}