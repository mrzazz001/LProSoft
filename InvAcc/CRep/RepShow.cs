using Framework;
using Framework.Business;
using Framework.Data;
using Framework.DataPortal;
using ProShared.GeneralM;using ProShared;
using System;
using System.Data;
using System.Diagnostics;
namespace Library.RepShow
{
    [Serializable]
    public class RepShow : BusinessBase<Library.RepShow.RepShow>
    {
        private string _Brn_No;
        private string _Tables;
        private MyDataSet _RepData = new MyDataSet();
        private string _Fields;
        private string _Rule;
        public string SelectStatement
        {
            get { return "Select " + _Fields + " From " + _Tables + " " + _Rule; }
        }
        public string Brn_No
        {
            get => this._Brn_No;
            set
            {
                if (!(this._Brn_No != value))
                    return;
                this._Brn_No = value;
            }
        }
        public string Tables
        {
            get => this._Tables;
            set
            {
                if (!(this._Tables != value))
                    return;
                this._Tables = value;
                this.PropertyChanged();
            }
        }
        public MyDataSet RepData
        {
            get => this._RepData;
            set
            {
                if (this._RepData == value)
                    return;
                this._RepData = value;
                this.PropertyChanged();
            }
        }
#pragma warning disable CS0114 // 'RepShow.CompareValue' hides inherited member 'BusinessBase<RepShow>.CompareValue'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
        private MyDataSet CompareValue => this._RepData;
#pragma warning restore CS0114 // 'RepShow.CompareValue' hides inherited member 'BusinessBase<RepShow>.CompareValue'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
        public string Fields
        {
            get => this._Fields;
            set
            {
                if (!(this._Fields != value))
                    return;
                this._Fields = value;
                this.PropertyChanged();
            }
        }
        public string Rule
        {
            get => this._Rule;
            set
            {
                if (!(this._Rule != value))
                    return;
                this._Rule = value;
                this.PropertyChanged();
            }
        }
        private void RuleValidation()
        {
        }
        public override Library.RepShow.RepShow Save()
        {
            this.RuleValidation();
            return base.Save();
        }
        public RepShow() => this.MarkNew();
        public static Library.RepShow.RepShow GetNewRepShow(int? NewRepShowId) => DataPortalClient.Fetch<Library.RepShow.RepShow>((object)NewRepShowId);
        public static Library.RepShow.RepShow CreateNewRepShow() => DataPortalClient.Create<Library.RepShow.RepShow>((object)null);
        protected override Library.RepShow.RepShow DataPortal_Create()
        {
            Library.RepShow.RepShow repShow = new Library.RepShow.RepShow();
            repShow.RepData.Tables.Add();
            return repShow;
        }
        protected override void DataPortal_Insert()
        {
            IDatabase database = string.IsNullOrEmpty(VarGeneral.RepShowStock_Rat) ? Database.GetDatabase(VarGeneral.BranchCS) : Database.GetDatabase(VarGeneral.BranchRt);
            try
            {
                VarGeneral.RepShowStock_Rat = "";
                database.AddParameter("Tables", DbType.String, (object)this.Tables);
                database.AddParameter("Fields", DbType.String, (object)this.Fields);
                database.AddParameter("Rule", DbType.String, (object)this.Rule);
                this._RepData = database.ExecuteMyDataSet(true, "S_T_Report");
            }
            catch (Exception ex)
            {
                VarGeneral.RepShowStock_Rat = "";
                EventLog.WriteEntry("Test.RepShow", ex.Message, EventLogEntryType.Error);
                throw ex;
            }
        }
    }
}
