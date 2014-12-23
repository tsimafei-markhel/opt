using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using opt.Drafter.DataModel;

namespace opt.Drafter.UI
{
    public sealed class ModelDraftController
    {
        public ModelDraft Draft { get; private set; }

        public bool IsChanged { get; private set; }

        public event EventHandler<EventArgs> Changed;

        public event EventHandler<EventArgs> Created;

        public event EventHandler<EventArgs> Opened;

        public event EventHandler<EventArgs> Saved;

        public ModelDraftController()
        {
            Draft = new ModelDraft();
            IsChanged = false;
        }

        public void NewDraft()
        {
            Draft = new ModelDraft();
            IsChanged = false;
        }

        public void OpenDraft(string draftFilePath)
        {
            // Opening logic goes here
            IsChanged = false;
        }

        public void SaveDraft(string filePath)
        {
            // Saving logic goes here...
            IsChanged = false;
        }

        public void SaveModel(string modelFilePath, string constantsFilePath)
        {
            // Does not affect IsChanged
        }

        public void SaveConstants(string constantsFilePath)
        {
            // Does not affect IsChanged
        }

        public void RunOpt(string modelFilePath, string optExecutablePath)
        {
            // Does not affect IsChanged
        }

        public void Promote(PromotableConstant constant)
        {
            constant.IsPromoted = true;
            IsChanged = true;
        }

        public void Promote(PromotableCriterion criterion)
        {
            criterion.IsPromoted = true;
            IsChanged = true;
        }

        public void Downgrade(PromotableConstant constant)
        {
            constant.IsPromoted = false;
            IsChanged = true;
        }

        public void Downgrade(PromotableCriterion criterion)
        {
            criterion.IsPromoted = false;
            IsChanged = true;
        }
    }
}