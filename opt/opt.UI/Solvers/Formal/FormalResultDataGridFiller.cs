using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.Solvers.Formal
{
    public abstract class FormalResultDataGridFiller
    {

        public static void FillDataGrid(Model model, FormalMethodResult result, DataGridView table)
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
            // Колонка для дополнительных данных
            var additionalCol = new DataGridViewColumn();
            additionalCol.CellTemplate = new DataGridViewTextBoxCell();
            additionalCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            additionalCol.HeaderText = result.AdditionalDataDescription;
            additionalCol.Name = "additional_col";
            table.Columns.Add(additionalCol);

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
                        colInd = table.Columns["param_" + pvs.Key].Index;
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowError(ex.Message);
                        return;
                    }
                    table[colInd, rowInd].Value =
                        pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
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
                    table[colInd, rowInd].Value =
                        pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                }
                // Запишем в ячейки значения ФО
                foreach (KeyValuePair<TId, double> pvs in model.Experiments[expId].ConstraintValues)
                {
                    int colInd = 0;
                    if (table.Columns["constr_" + pvs.Key] != null)
                    {
                        colInd = table.Columns["constr_" + pvs.Key].Index;
                        table[colInd, rowInd].Value =
                            pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                    }
                }
                // Запишем в ячейки дополнительные данные
                int colId = table.Columns["additional_col"].Index;
                table[colId, rowInd].Style.BackColor = Color.LightGray;
                table[colId, rowInd].Value =
                    result.AdditionalData[expId].ToString(SettingsManager.Instance.DoubleStringFormat);
            }

            table.ResumeLayout();
        }

    }
}