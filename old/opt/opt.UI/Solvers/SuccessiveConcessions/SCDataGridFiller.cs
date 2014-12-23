using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.Solvers.SuccessiveConcessions
{
    public abstract class ScDataGridFiller
    {
        public static void FillMidDataGrid(
            Model model, 
            DataGridView grid, 
            ScMethodResult result, 
            CriterialConcessions concessions,
            TId sortingCritId, 
            bool showConstraints, 
            bool showParams)
        {
            grid.SuspendLayout();

            // Очистка
            grid.Columns.Clear();
            grid.Rows.Clear();

            // Колонка для номера эксперимента
            var numberCol = new DataGridViewColumn();
            numberCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            numberCol.HeaderText = "Номер эксперимента";
            numberCol.Name = "num";
            numberCol.CellTemplate = new DataGridViewTextBoxCell();
            numberCol.CellTemplate.Style.BackColor = Color.LightGray;
            grid.Columns.Add(numberCol);
            // Колонки для значений критериев
            foreach (CriterialConcession concession in concessions)
            {
                Criterion crit = model.Criteria[concession.CriterionId];
                // вспомогательная строка для заголовка колонки критерия
                string sortString = SortDirectionManager.GetSortDirectionName(crit.SortDirection);

                // Колонка для значений критерия
                var critCol = new DataGridViewColumn();
                critCol.CellTemplate = new DataGridViewTextBoxCell();
                critCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                critCol.HeaderText = crit.Name + "\n" + sortString;
                critCol.Name = "crit_" + crit.Id;
                critCol.HeaderCell.ToolTipText = crit.GetDescription();
                // Отметим цветом колонку того критерия, по которому сделана сортировка
                if (crit.Id == sortingCritId)
                {
                    critCol.CellTemplate.Style.BackColor = Color.Aqua;
                }
                grid.Columns.Add(critCol);
            }
            // Если надо - колонки для функциональных ограничения
            if (showConstraints)
            {
                foreach (KeyValuePair<TId, Constraint> kvp in model.FunctionalConstraints)
                {
                    var constrCol = new DataGridViewColumn();
                    constrCol.CellTemplate = new DataGridViewTextBoxCell();
                    constrCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                    constrCol.HeaderText = kvp.Value.Name;
                    constrCol.Name = "constr_" + kvp.Key;
                    constrCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                    grid.Columns.Add(constrCol);
                }
            }
            // Если надо - колонки для параметров
            if (showParams)
            {
                foreach (KeyValuePair<TId, Parameter> kvp in model.Parameters)
                {
                    var paramCol = new DataGridViewColumn();
                    paramCol.CellTemplate = new DataGridViewTextBoxCell();
                    paramCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                    paramCol.HeaderText = kvp.Value.Name;
                    paramCol.Name = "param_" + kvp.Key;
                    paramCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                    grid.Columns.Add(paramCol);
                }
            }







            // Создадим рядки и заполним их инфой
                      
            // Будем выводить эксперименты согласно порядку, указанному в 
            // полученном результате вычислений (result)
            foreach (TId expId in result.SortedPoints)
            {
                int rowId = grid.Rows.Add();
                string colName = string.Empty;
                int colId = -1;
                // Сначала номер эксперимента
                grid[0, rowId].Value =
                    model.Experiments[expId].Number.ToString();
                // Потом - значения критериев
                foreach (CriterialConcession concession in concessions)
                {
                    Criterion crit = model.Criteria[concession.CriterionId];
                    colName = "crit_" + crit.Id;
                    colId = grid.Columns[colName].Index;
                    grid[colId, rowId].Value = model.Experiments[expId].CriterionValues[crit.Id].ToString(SettingsManager.Instance.DoubleStringFormat);
                }
                // Потом - если надо - ФО
                if (showConstraints)
                {
                    foreach (Constraint constr in model.FunctionalConstraints.Values)
                    {
                        colName = "constr_" + constr.Id;
                        colId = grid.Columns[colName].Index;
                        grid[colId, rowId].Value = model.Experiments[expId].ConstraintValues[constr.Id].ToString(SettingsManager.Instance.DoubleStringFormat);
                    }
                }
                // И наконец - если нужно - оптимизируемые параметры
                if (showParams)
                {
                    foreach (Parameter param in model.Parameters.Values)
                    {
                        colName = "param_" + param.Id;
                        colId = grid.Columns[colName].Index;
                        grid[colId, rowId].Value = model.Experiments[expId].ParameterValues[param.Id].ToString(SettingsManager.Instance.DoubleStringFormat);
                    }
                }
            }

            grid.ResumeLayout();
            // Конец метода
        }

        public static void FillDataGrid(
            Model model,
            ScMethodResult result,
            DataGridView table)
        {
            table.SuspendLayout();

            table.Rows.Clear();
            table.Columns.Clear();

            // Колонки для параметров
            foreach (KeyValuePair<TId, Parameter> kvp in model.Parameters)
            {
                var paramCol = new DataGridViewColumn();
                paramCol.CellTemplate = new DataGridViewTextBoxCell();
                paramCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                paramCol.HeaderText = kvp.Value.Name;
                paramCol.Name = "param_" + kvp.Key;
                paramCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                table.Columns.Add(paramCol);
            }
            // Колонки для критериев
            foreach (KeyValuePair<TId, Criterion> kvp in model.Criteria)
            {
                var critCol = new DataGridViewColumn();
                critCol.CellTemplate = new DataGridViewTextBoxCell();
                critCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                critCol.HeaderText = kvp.Value.Name;
                critCol.Name = "crit_" + kvp.Key;
                critCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                table.Columns.Add(critCol);
            }
            // Колонки для функциональных ограничения
            foreach (KeyValuePair<TId, Constraint> kvp in model.FunctionalConstraints)
            {
                var constrCol = new DataGridViewColumn();
                constrCol.CellTemplate = new DataGridViewTextBoxCell();
                constrCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                constrCol.HeaderText = kvp.Value.Name;
                constrCol.Name = "constr_" + kvp.Key;
                constrCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                table.Columns.Add(constrCol);
            }

            foreach (TId expId in result.SortedPoints)
            {
                if (model.Experiments[expId].IsActive)
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
                            colInd = table.Columns["param_" + pvs.Key].Index;
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
                            colInd = table.Columns["crit_" + pvs.Key].Index;
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
                        if (table.Columns["constr_" + pvs.Key] != null)
                        {
                            colInd = table.Columns["constr_" + pvs.Key].Index;
                            table[colInd, rowInd].Value = pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                        }
                    }
                }
            }

            table.ResumeLayout();
        }
    }
}