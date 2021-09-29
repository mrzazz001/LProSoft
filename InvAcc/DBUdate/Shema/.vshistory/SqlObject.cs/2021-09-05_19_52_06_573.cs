using Microsoft.SqlServer.Management.Smo;
using SqlDbCloner.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SqlDbCloner.Core.Schema
{
    public class CopySchema2
    {
        SqlTransfer transfer;
        IEnumerable<SqlObject> items;
        List<SqlObject> list;
        int errorCount;
        TreeView treeView1 = new TreeView();
        public CopySchema2(string sourceserver, string destinationserver)
        {
            transfer = new SqlTransfer(sourceserver, destinationserver);
            items = transfer.SourceObjects;
            list = new List<SqlObject>();
            foreach (SqlObject i in items)
                list.Add(i);
            //                InitializeComponent();this.Load += langloads;
            //              this.list = list;
            //                this.transfer = transfer;
            //      dataGridView1.DataSource = list;
            //    label1.Text = "Click on 'Copy' button to start copying below listed SQL objects";
        }
        void next()
        {
        }
        public DataGridView dataGridView1 = new DataGridView();
        DataGridViewColumn Status, Table, SqlCommand, Error;
        List<SqlDbCloner.Core.Data.DataObject> list1;
        public void doworkdata(string s, string d)
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.Table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SqlCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status.FillWeight = 101.5228F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Table
            // 
            this.Table.FillWeight = 99.49238F;
            this.Table.HeaderText = "Table";
            this.Table.Name = "Table";
            // 
            // SqlCommand
            // 
            this.SqlCommand.FillWeight = 99.49238F;
            this.SqlCommand.HeaderText = "SqlCommand";
            this.SqlCommand.Name = "SqlCommand";
            // 
            // Error
            // 
            this.Error.FillWeight = 99.49238F;
            this.Error.HeaderText = "Error";
            this.Error.Name = "Error";
            // 
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.Table,
            this.SqlCommand,
            this.Error});
            DataTransfer transfer;
            List<SqlDbCloner.Core.Data.DataObject> items;

            transfer = new DataTransfer(s, d);
            items = new List<Core.Data.DataObject>();

            if (items.Count == 0)
                items = transfer.SourceObjects;
            list1 = items;
            foreach (var item in list1)
            {
                dataGridView1.Rows.Add(null, item.Table, item.SqlCommand, null);
            }
            double current = 0;
            double max = dataGridView1.Rows.Count;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                //  backgroundWorker1.ReportProgress((int)(((++current) / max) * 100.0));
                if (item.IsNewRow)
                    continue;

                if (item.Cells["SqlCommand"].Value == null || string.IsNullOrEmpty(item.Cells["SqlCommand"].Value.ToString()))
                {
                    item.Cells["SqlCommand"].Value = "SELECT * FROM " + item.Cells["Table"].Value.ToString() + " WITH(NOLOCK)";
                }
                transfer.TrasnferData(item.Cells["Table"].Value.ToString(), item.Cells["SqlCommand"].Value.ToString());
                //    item.Cells["Status"].Value = Properties.Resources.success;


            }
            //}
            //catch (Exception exc) {  }
        }
        public void dowork()
        {
            transfer.Refresh();
            double current = 0;
            double max = list1.Count;
            if (true)
                max += (list.Where(i => i.Type == "Table").Count() * 3.0);

            foreach (var item in list)
            {
                try
                {
                    if (true)
                    {
                        transfer.DropAndCreateObject(item.Object);
                    }
                    else
                    {
                        transfer.CreateObject(item.Object);
                    }
                    //   item.Status = Properties.Resources.success;
                }
                catch (Exception exc)
                {
                    // item.Status = Properties.Resources.failure;
                    item.Error = exc.Message;
                    if (exc.InnerException != null)
                        item.Error = exc.InnerException.Message;
                    errorCount++;
                }
                //   backgroundWorker1.ReportProgress((int)(((++current) / max) * 100.0));
            }
            if (true)
            {
                foreach (var item in list.Where(i => i.Type == "Table"))
                {
                    transfer.ApplyIndexes(item.Object);
                    //backgroundWorker1.ReportProgress((int)(((++current) / max) * 100.0));
                }
                foreach (var item in list.Where(i => i.Type == "Table"))
                {
                    transfer.ApplyForeignKeys(item.Object);
                    //backgroundWorker1.ReportProgress((int)(((++current) / max) * 100.0));
                }
                foreach (var item in list.Where(i => i.Type == "Table"))
                {
                    transfer.ApplyChecks(item.Object);
                    //backgroundWorker1.ReportProgress((int)(((++current) / max) * 100.0));
                }
            }
        }
    }
    public class SqlObject
    {
        public Bitmap Status { get; set; }
        public string Name { get; set; }
        [Browsable(false)]
        public NamedSmoObject Object { get; set; }
        public string Type { get; set; }
        public string Error { get; set; }
        public SqlObject()
        {
            //Status = Properties.Resources.unknown;
        }

    }
}
