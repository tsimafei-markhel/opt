using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using opt.DataModel;
using opt.Extensions;
using opt.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.UI.Helpers
{
    public static class MatrixDataGridFiller
    {
        /// <summary>
        /// Метод для вывода матрицы решений в таблицу 
        /// (DataGridView)
        /// </summary>
        /// <param name="model">Операционная модель</param>
        /// <param name="table">Таблица</param>
        /// <param name="enableSorting">Сортировать ли эксперименты слогласно типу 
        /// критериев</param>
        /// <param name="repeatParams">Повторять ли значения оптимизируемых параметров 
        /// для каждого из критериев (работает, только есть enableSorting == true)</param>
        /// <param name="hideInactiveExperiments">Whether to display inactive experiments or not</param>
        public static void FillMatrixDataGrid(
            Model model,
            DataGridView table,
            bool enableSorting,
            bool repeatParams,
            bool hideInactiveExperiments)
        {
            // Подготовим некоторые значения для отображения
            // отсеянных по ФО экспериментов
            Color textCol = Color.DimGray;

            table.SuspendLayout();

            // Очистка
            table.Columns.Clear();
            table.Rows.Clear();

            // Создадим колонки
            if (enableSorting)
            {
                // Если критерии сортируются, то надо выводить их поотдельности
                foreach (KeyValuePair<TId, Criterion> critKvp in model.Criteria)
                {
                    // вспомогательная строка для заголовка колонки критерия
                    string sortString = SortDirectionManager.GetSortDirectionName(critKvp.Value.SortDirection);

                    // Колонка для номера эксперимента
                    DataGridViewColumn numberCol = CreateColumn("Номер эксперимента",
                                                                "num_for_crit_" + critKvp.Key);
                    numberCol.CellTemplate.Style.BackColor = Color.LightGray;
                    table.Columns.Add(numberCol);

                    // Колонка для значений критерия
                    DataGridViewColumn critCol = CreateColumn(critKvp.Value.Name + "\n" + sortString,
                                                              "crit_" + critKvp.Key,
                                                              critKvp.Value.GetDescription());
                    table.Columns.Add(critCol);

                    // Колонки для функциональных ограничения
                    foreach (KeyValuePair<TId, Constraint> kvp in model.FunctionalConstraints)
                    {
                        DataGridViewColumn constrCol = CreateColumn(kvp.Value.Name,
                                                                    "constr_" + kvp.Key + "_for_crit_" + critKvp.Key,
                                                                    kvp.Value.GetDescription());
                        table.Columns.Add(constrCol);
                    }

                    // Если надо - колонки для параметров
                    if (repeatParams)
                    {
                        foreach (KeyValuePair<TId, Parameter> kvp in model.Parameters)
                        {
                            DataGridViewColumn paramCol = CreateColumn(kvp.Value.Name,
                                                                       "param_" + kvp.Key + "_for_crit_" + critKvp.Key,
                                                                        kvp.Value.GetDescription());
                            table.Columns.Add(paramCol);
                        }
                    }
                }
            }
            else
            {
                // Проще всего, если не сортируются - тогда просто выведем
                // сначала номер, потом параметры, потом критерии, потом ФО
                DataGridViewColumn numberCol = CreateColumn("Номер эксперимента",
                                                            "number");
                table.Columns.Add(numberCol);

                // Колонки для параметров
                foreach (KeyValuePair<TId, Parameter> kvp in model.Parameters)
                {
                    DataGridViewColumn paramCol = CreateColumn(kvp.Value.Name,
                                                               "param_" + kvp.Key,
                                                               kvp.Value.GetDescription());
                    table.Columns.Add(paramCol);
                }

                // Колонки для критериев
                foreach (KeyValuePair<TId, Criterion> kvp in model.Criteria)
                {
                    DataGridViewColumn critCol = CreateColumn(kvp.Value.Name,
                                                              "crit_" + kvp.Key,
                                                              kvp.Value.GetDescription());
                    table.Columns.Add(critCol);
                }

                // Колонки для функциональных ограничения
                foreach (KeyValuePair<TId, Constraint> kvp in model.FunctionalConstraints)
                {
                    DataGridViewColumn constrCol = CreateColumn(kvp.Value.Name,
                                                                "constr_" + kvp.Key,
                                                                kvp.Value.GetDescription());
                    table.Columns.Add(constrCol);
                }
            }





            // Создадим рядки и заполним их инфой
            if (enableSorting)
            {
                // Добавим нужное количество рядков
                if (hideInactiveExperiments)
                {
                    table.Rows.Add(model.Experiments.CountActiveExperiments());
                }
                else
                {
                    table.Rows.Add(model.Experiments.Count);
                }

                // Идем по критериям
                foreach (TId critId in model.Criteria.Keys)
                {
                    List<SortableDouble> sortedExperiments = model.Experiments.Values.Select<Experiment, SortableDouble>(
                            e => new SortableDouble() { Direction = model.Criteria[critId].SortDirection, Id = e.Id, Value = e.CriterionValues[critId] }
                        ).ToList();
                    sortedExperiments.Sort();

                    // Теперь пойдем по отсортировнной коллекции, доставая из нее id экспериментов
                    // и выводя их в таблицу в этом порядке
                    int rowId = 0;
                    foreach (SortableDouble sortedExperiment in sortedExperiments)
                    {
                        // Цвет текста
                        if (model.Experiments[sortedExperiment.Id].IsActive)
                        {
                            textCol = Color.Black;
                        }
                        else
                        {
                            if (hideInactiveExperiments)
                            {
                                continue;
                            }

                            textCol = Color.DimGray;
                        }

                        // Сначала номер эксперимента
                        string colName = "num_for_crit_" + critId;
                        int colId = table.Columns[colName].Index;
                        table[colId, rowId].Style.ForeColor = textCol;
                        table[colId, rowId].Value = model.Experiments[sortedExperiment.Id].Number.ToString();

                        // Потом - значение критерия
                        colName = "crit_" + critId;
                        colId = table.Columns[colName].Index;
                        table[colId, rowId].Style.ForeColor = textCol;
                        table[colId, rowId].Value = model.Experiments[sortedExperiment.Id].CriterionValues[critId].ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                        
                        // Потом - ФО
                        foreach (Constraint constr in model.FunctionalConstraints.Values)
                        {
                            colName = "constr_" + constr.Id + "_for_crit_" + critId;
                            colId = table.Columns[colName].Index;
                            table[colId, rowId].Style.ForeColor = textCol;
                            table[colId, rowId].Value = model.Experiments[sortedExperiment.Id].ConstraintValues[constr.Id].ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                        }

                        // И наконец - если нужно - оптимизируемые параметры
                        if (repeatParams)
                        {
                            foreach (Parameter param in model.Parameters.Values)
                            {
                                colName = "param_" + param.Id + "_for_crit_" + critId;
                                colId = table.Columns[colName].Index;
                                table[colId, rowId].Style.ForeColor = textCol;
                                table[colId, rowId].Value = model.Experiments[sortedExperiment.Id].ParameterValues[param.Id].ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                            }
                        }

                        rowId++;
                    }
                }
            }
            else
            {
                // Проще всего - без сортировки
                foreach (KeyValuePair<TId, Experiment> kvp in model.Experiments)
                {
                    // TODO: Refactor this
                    if (!kvp.Value.IsActive && hideInactiveExperiments)
                    {
                        continue;
                    }

                    // Добавим рядок
                    int rowInd = table.Rows.Add();

                    // Если надо выделять отсеянные по ФО эксперименты, то так и сделаем
                    if (kvp.Value.IsActive)
                    {
                        table.Rows[rowInd].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        table.Rows[rowInd].DefaultCellStyle.ForeColor = textCol;
                    }

                    // Запишем в первую колонку номер эксперимента
                    table[0, rowInd].Value = kvp.Value.Number;

                    // Запишем в ячейки значения оптимизируемых параметров
                    foreach (KeyValuePair<TId, double> pvs in kvp.Value.ParameterValues)
                    {
                        int colInd = 0;
                        try
                        {
                            colInd = table.Columns["param_" + pvs.Key].Index;
                        }
                        catch (Exception ex)
                        {
                            MessageBoxHelper.ShowError(ex.Message);
                            return;
                        }
                        table[colInd, rowInd].Value = pvs.Value.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                    }

                    // Запишем в ячейки значения критериев оптимальности
                    foreach (KeyValuePair<TId, double> pvs in kvp.Value.CriterionValues)
                    {
                        int colInd = 0;
                        try
                        {
                            colInd = table.Columns["crit_" + pvs.Key].Index;
                        }
                        catch (Exception ex)
                        {
                            MessageBoxHelper.ShowError(ex.Message);
                            return;
                        }
                        table[colInd, rowInd].Value = pvs.Value.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                    }

                    // Запишем в ячейки значения ФО
                    foreach (KeyValuePair<TId, double> pvs in kvp.Value.ConstraintValues)
                    {
                        int colInd = 0;
                        if (table.Columns["constr_" + pvs.Key] != null)
                        {
                            colInd = table.Columns["constr_" + pvs.Key].Index;
                            table[colInd, rowInd].Value = pvs.Value.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                        }
                    }
                }
            }

            table.ResumeLayout();
            // Конец метода
        }

        /// <summary>
        /// Метод для заполнения DataGridView матрицей решений после 
        /// формирования допустимого множества
        /// </summary>
        /// <param name="model">Оптимизационная модель</param>
        /// <param name="grid">DataGridView для заполнения</param>
        public static void FillAdmissibleSetDataGrid(
            Model model,
            DataGridView grid,
            bool showConstraints,
            bool repeatParams)
        {
            grid.SuspendLayout();

            // Очистка
            grid.Columns.Clear();
            grid.Rows.Clear();

            // Создадим колонки
            foreach (KeyValuePair<TId, Criterion> critKvp in model.Criteria)
            {
                // вспомогательная строка для заголовка колонки критерия
                string sortString = SortDirectionManager.GetSortDirectionName(critKvp.Value.SortDirection);

                // Колонка для номера эксперимента
                DataGridViewColumn numberCol = CreateColumn("Номер эксперимента",
                                                            "num_for_crit_" + critKvp.Key);
                numberCol.CellTemplate.Style.BackColor = Color.LightGray;
                grid.Columns.Add(numberCol);

                // Колонка для значений критерия
                DataGridViewColumn critCol = CreateColumn(critKvp.Value.Name + "\n" + sortString,
                                                          "crit_" + critKvp.Key,
                                                          critKvp.Value.GetDescription());
                grid.Columns.Add(critCol);

                // Если надо - колонки для функциональных ограничения
                if (showConstraints)
                {
                    foreach (KeyValuePair<TId, Constraint> kvp in model.FunctionalConstraints)
                    {
                        DataGridViewColumn constrCol = CreateColumn(kvp.Value.Name,
                                                                    "constr_" + kvp.Key + "_for_crit_" + critKvp.Key,
                                                                    kvp.Value.GetDescription());
                        grid.Columns.Add(constrCol);
                    }
                }

                // Если надо - колонки для параметров
                if (repeatParams)
                {
                    foreach (KeyValuePair<TId, Parameter> kvp in model.Parameters)
                    {
                        DataGridViewColumn paramCol = CreateColumn(kvp.Value.Name,
                                                                   "param_" + kvp.Key + "_for_crit_" + critKvp.Key,
                                                                   kvp.Value.GetDescription());
                        grid.Columns.Add(paramCol);
                    }
                }
            }






            // Создадим рядки и заполним их инфой
            // Добавим нужное количество рядков
            int activeExperimentsCount = model.Experiments.CountActiveExperiments();
            if (activeExperimentsCount == 0)
            {
                grid.ResumeLayout();
                return;
            }
            else
            {
                grid.Rows.Add(activeExperimentsCount);
            }

            // Идем по критериям
            foreach (TId critId in model.Criteria.Keys)
            {
                List<SortableDouble> sortedExperiments = model.Experiments.Values.Where(e => e.IsActive).Select<Experiment, SortableDouble>(
                            e => new SortableDouble() { Direction = model.Criteria[critId].SortDirection, Id = e.Id, Value = e.CriterionValues[critId] }
                        ).ToList();
                sortedExperiments.Sort();

                int rowId = 0;
                foreach (SortableDouble sortedExperiment in sortedExperiments)
                {
                    // Сначала номер эксперимента
                    string colName = "num_for_crit_" + critId;
                    int colId = grid.Columns[colName].Index;
                    grid[colId, rowId].Value = model.Experiments[sortedExperiment.Id].Number.ToString();

                    // Потом - значение критерия
                    colName = "crit_" + critId;
                    colId = grid.Columns[colName].Index;
                    grid[colId, rowId].Value = model.Experiments[sortedExperiment.Id].CriterionValues[critId].ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                    
                    // Потом - если надо - ФО
                    if (showConstraints)
                    {
                        foreach (Constraint constr in model.FunctionalConstraints.Values)
                        {
                            colName = "constr_" + constr.Id + "_for_crit_" + critId;
                            colId = grid.Columns[colName].Index;
                            grid[colId, rowId].Value = model.Experiments[sortedExperiment.Id].ConstraintValues[constr.Id].ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                        }
                    }

                    // И наконец - если нужно - оптимизируемые параметры
                    if (repeatParams)
                    {
                        foreach (Parameter param in model.Parameters.Values)
                        {
                            colName = "param_" + param.Id + "_for_crit_" + critId;
                            colId = grid.Columns[colName].Index;
                            grid[colId, rowId].Value = model.Experiments[sortedExperiment.Id].ParameterValues[param.Id].ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                        }
                    }

                    rowId++;
                }
            }

            grid.ResumeLayout();
            // Конец метода
        }

        public static DataGridViewColumn CreateColumn(string headerText, string name = null, string tooltipText = null)
        {
            if (string.IsNullOrEmpty(headerText))
            {
                throw new ArgumentNullException("headerText");
            }

            DataGridViewColumn column = new DataGridViewColumn();
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.HeaderText = headerText;
            column.ReadOnly = true;
            column.CellTemplate = new DataGridViewTextBoxCell();

            if (!string.IsNullOrEmpty(name))
            {
                column.Name = name;
            }

            if (!string.IsNullOrEmpty(tooltipText))
            {
                column.HeaderCell.ToolTipText = tooltipText;
            }

            return column;
        }
    }
}