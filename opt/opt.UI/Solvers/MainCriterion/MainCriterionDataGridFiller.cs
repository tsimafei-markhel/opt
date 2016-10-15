using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.Solvers.MainCriterion
{
    public abstract class MainCriterionDataGridFiller
    {

        public static void FillDataGrid(
            Model model,
            MainCriterionMethodResult result,
            DataGridView table,
            bool showInactiveExperiments)
        {
            table.SuspendLayout();

            table.Rows.Clear();
            table.Columns.Clear();

            // Подготовим некоторые значения для отображения
            Color activeTextColor = Color.Black;
            Color inactiveTextColor = Color.DimGray;
            Color mainCriterionColumnColor = Color.PowderBlue;

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
                if (kvp.Key == result.MainCriterionId)
                {
                    critCol.CellTemplate.Style.BackColor = mainCriterionColumnColor;
                }
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
                // Использовал ИЛИ потому что:
                // isActive|  0  |  1  |
                // show... |_____|_____|
                //       0 |  0  |  1  |
                //       1 |  1  |  1  |
                if (model.Experiments[expId].IsActive || showInactiveExperiments)
                {
                    // Добавим рядок
                    int rowInd = table.Rows.Add();
                    // Запишем в хедер номер эксперимента
                    table.Rows[rowInd].HeaderCell.Value = model.Experiments[expId].Number.ToString();
                    // Выберем цвет
                    Color textColor = activeTextColor;
                    if (!model.Experiments[expId].IsActive)
                    {
                        textColor = inactiveTextColor;
                    }
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
                        table[colInd, rowInd].Style.ForeColor = textColor;
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
                        table[colInd, rowInd].Style.ForeColor = textColor;
                    }
                    // Запишем в ячейки значения ФО
                    foreach (KeyValuePair<TId, double> pvs in model.Experiments[expId].ConstraintValues)
                    {
                        int colInd = 0;
                        if (table.Columns["constr_" + pvs.Key] != null)
                        {
                            colInd = table.Columns["constr_" + pvs.Key].Index;
                            table[colInd, rowInd].Value = pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                            table[colInd, rowInd].Style.ForeColor = textColor;
                        }
                    }
                }
            }

            table.ResumeLayout();
        }

    }
}