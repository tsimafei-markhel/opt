using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using System.Drawing;
using opt.UI.Helpers.DataModel;
using opt.UI.Helpers;

namespace opt.Solvers.Genetics.Nsga
{
    public abstract class NsgaDataGridFiller
    {
        /// <summary>
        /// Метод для подготовки таблицы к выводу процесса 
        /// поиска решения с помощтю генетического алгоритма 
        /// (будут выводиться популяции)
        /// </summary>
        /// <param name="table">Таблица, в которую будет происходить 
        /// вывод данных</param>
        public static void PrepareProcessDataGrid(DataGridView table)
        {
            table.SuspendLayout();

            // Установим некоторые параметры
            table.EditMode = DataGridViewEditMode.EditProgrammatically;
            table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            table.RowHeadersVisible = false;
            table.AllowUserToAddRows = false;
            table.AllowUserToDeleteRows = false;
            table.AllowUserToOrderColumns = false;
            table.AllowUserToResizeRows = false;
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Очистим
            table.Columns.Clear();
            table.Rows.Clear();

            // Создадим колонки
            // Номер особи
            DataGridViewColumn unitNumCol = new DataGridViewColumn();
            unitNumCol.CellTemplate = new DataGridViewTextBoxCell();
            unitNumCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            unitNumCol.HeaderText = "Особь";
            unitNumCol.Name = "unit_id";
            unitNumCol.HeaderCell.ToolTipText = "Уникальный номер особи";
            table.Columns.Add(unitNumCol);
            // Поколение
            DataGridViewColumn unitGenCol = new DataGridViewColumn();
            unitGenCol.CellTemplate = new DataGridViewTextBoxCell();
            unitGenCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            unitGenCol.HeaderText = "Поколение";
            unitGenCol.Name = "unit_gen";
            unitGenCol.HeaderCell.ToolTipText = "Поколение, в котором появилась особь";
            table.Columns.Add(unitGenCol);
            // Ранг
            DataGridViewColumn unitRankCol = new DataGridViewColumn();
            unitRankCol.CellTemplate = new DataGridViewTextBoxCell();
            unitRankCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            unitRankCol.HeaderText = "Ранг";
            unitRankCol.Name = "unit_rank";
            unitRankCol.HeaderCell.ToolTipText = "Ранг особи";
            table.Columns.Add(unitRankCol);
            // Хромосома
            DataGridViewColumn unitChromoCol = new DataGridViewColumn();
            unitChromoCol.CellTemplate = new DataGridViewTextBoxCell();
            unitChromoCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            unitChromoCol.HeaderText = "Код хромосомы";
            unitChromoCol.Name = "unit_chromo";
            unitChromoCol.HeaderCell.ToolTipText = "Закодированные значения признаков особи";
            table.Columns.Add(unitChromoCol);

            table.ResumeLayout();
        }

        /// <summary>
        /// Метод для вывода информации о популяции в таблицу
        /// </summary>
        /// <param name="table">ПОДГОТОВЛЕННАЯ (PrepareProcessDataGrid) таблица</param>
        /// <param name="population">Популяция, информацию о которой нужно 
        /// вывести в таблицу</param>
        public static void AddPopulationToDataGrid(
            DataGridView table,
            Population<NsgaIndividual> population,
            bool showDelimiterRow)
        {
            table.SuspendLayout();

            // Предварительно вставим рядок-разделитель, если 
            // так хочет вызывающий метод
            if (showDelimiterRow)
            {
                int delimiterRow = table.Rows.Add();
                foreach (DataGridViewCell cell in table.Rows[delimiterRow].Cells)
                {
                    cell.Value = "---";
                }
            }
            // Переберем всю популяцию, отводя на особь по рядку
            foreach (NsgaIndividual unit in population)
            {
                int unitRow = table.Rows.Add();
                table.Rows[unitRow].Cells[0].Value = unit.Number.ToString();
                table.Rows[unitRow].Cells[1].Value = unit.Generation.ToString();
                table.Rows[unitRow].Cells[2].Value = unit.Rank.ToString();
                table.Rows[unitRow].Cells[3].Value = unit.GetChromo();
            }

            table.ResumeLayout();
        }

        /// <summary>
        /// Метод для заполнения таблицы результатами поиска решения с 
        /// помощью генетического алгоритма
        /// </summary>
        /// <param name="model">Оптимизациионная модель</param>
        /// <param name="result">Результаты поиска решения</param>
        /// <param name="table">Таблица для вывода результатов</param>
        public static void FillDataGrid(
            Model model,
            NsgaMethodResult result,
            DataGridView table)
        {
            table.SuspendLayout();

            table.Rows.Clear();
            table.Columns.Clear();

            // Колонки для параметров
            foreach (KeyValuePair<TId, Parameter> kvp in model.Parameters)
            {
                DataGridViewColumn paramCol = new DataGridViewColumn();
                paramCol.CellTemplate = new DataGridViewTextBoxCell();
                paramCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                paramCol.HeaderText = kvp.Value.Name;
                paramCol.Name = "param_" + kvp.Key.ToString();
                paramCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                table.Columns.Add(paramCol);
            }
            // Колонки для критериев
            foreach (KeyValuePair<TId, Criterion> kvp in model.Criteria)
            {
                DataGridViewColumn critCol = new DataGridViewColumn();
                critCol.CellTemplate = new DataGridViewTextBoxCell();
                critCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                critCol.HeaderText = kvp.Value.Name;
                critCol.Name = "crit_" + kvp.Key.ToString();
                critCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                table.Columns.Add(critCol);
            }
            // Колонки для функциональных ограничения
            foreach (KeyValuePair<TId, Constraint> kvp in model.FunctionalConstraints)
            {
                DataGridViewColumn constrCol = new DataGridViewColumn();
                constrCol.CellTemplate = new DataGridViewTextBoxCell();
                constrCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                constrCol.HeaderText = kvp.Value.Name;
                constrCol.Name = "constr_" + kvp.Key.ToString();
                constrCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                table.Columns.Add(constrCol);
            }

            foreach (TId expId in result.SortedPoints)
            {
                // Добавим рядок
                int rowInd = table.Rows.Add();
                // Запишем в хедер номер эксперимента
                table.Rows[rowInd].HeaderCell.Value = model.Experiments[expId].Number.ToString();
                // Запишем в ячейки значения оптимизируемых параметров
                foreach (KeyValuePair<TId, double> pvs in model.Experiments[expId].ParameterValues)
                {
                    int colInd = 0;
                    try
                    {
                        colInd = table.Columns["param_" + pvs.Key.ToString()].Index;
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowError(ex.Message);
                        return;
                    }
                    table[colInd, rowInd].Value = pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                }
                // Запишем в ячейки значения критериев оптимальности
                foreach (KeyValuePair<TId, double> pvs in model.Experiments[expId].CriterionValues)
                {
                    int colInd = 0;
                    try
                    {
                        colInd = table.Columns["crit_" + pvs.Key.ToString()].Index;
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowError(ex.Message);
                        return;
                    }
                    table[colInd, rowInd].Value = pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                }
                // Запишем в ячейки значения ФО
                foreach (KeyValuePair<TId, double> pvs in model.Experiments[expId].ConstraintValues)
                {
                    int colInd = 0;
                    if (table.Columns["constr_" + pvs.Key.ToString()] != null)
                    {
                        colInd = table.Columns["constr_" + pvs.Key.ToString()].Index;
                        table[colInd, rowInd].Value = pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                    }
                }
            }

            table.ResumeLayout();
        }
    }
}