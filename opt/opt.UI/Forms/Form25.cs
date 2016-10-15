using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.Generators;
using opt.Provider;
using opt.Provider.Xml;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    internal partial class Form25 : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        // TODO: Dependency injection.
        private readonly IModelProvider modelProvider = new XmlModelProvider();

        public Form25()
        {
            InitializeComponent();
        }

        public Form25(
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

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void Form25_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSaveMatrix_Click(object sender, EventArgs e)
        {
            if (this.dlgSaveModel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    modelProvider.Save(this._model, this.dlgSaveModel.FileName);
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
            // Очистим коллекцию экспериментов
            this._model.Experiments.Clear();

            // Добавим экспериментов сколько надо
            int expCount = Convert.ToInt32(this.nudExperimentsCount.Value);
            for(int i = 0; i < expCount; i++)
            {
                this._model.Experiments.Add(new Experiment(i, i + 1));
            }

            if (this.rbnAutomatic.Checked)
            {
                // Автоматическая генерация
                // Переберем все параметры
                int paramNum = 1;
                foreach (KeyValuePair<TId, Parameter> kvp in this._model.Parameters)
                {
                    // Переберем все эксперименты
                    for (int expNum = 1; expNum <= expCount; expNum++)
                    {
                        // В данном эксперименте создадим в списке значений
                        // оптимизируемых параметров новую запись для данного
                        // оптимизируемого параметра
                        this._model.Experiments[expNum - 1].ParameterValues.Add(
                            kvp.Value.Id,
                            kvp.Value.MinValue + 
                            LpTauGenerator.GetParameterValue(expNum, paramNum) * 
                            (kvp.Value.MaxValue - kvp.Value.MinValue));
                    }
                    paramNum++;
                }
            }

            // Покажем окно отображения/ввода значений
            // оптимизируемых параметров
            this._nextForm = new Form30(this, this._model);
            this._nextForm.Show();
            this.Hide();
        }
    }
}