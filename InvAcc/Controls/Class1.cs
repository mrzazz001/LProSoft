using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvAcc.Controls
{
    public class DatenListe<T> : BindingList<T> where T : class, new()
    {
        protected ProShared.Stock_Data.Stock_DataDataContext m_DC;
        protected Table<T> m_Table;

        public DatenListe(Stock_DataDataContext dc)
        {
            m_DC = dc;
            m_Table = m_DC.GetTable<T>();
        }

        public DatenListe(Stock_DataDataContext dc, IEnumerable<T> enumerator)
        {
            m_DC = dc;
            m_Table = m_DC.GetTable<T>();
            foreach (var item in enumerator)
            {
                this.Items.Add(item);
            }
        }

        protected override void RemoveItem(int index)
        {
            T delObj = this.Items[index];
            m_Table.DeleteOnSubmit(delObj);
            base.RemoveItem(index);
        }

        protected override object AddNewCore()
        {
            T newObj = null;
            OnAddingNew(new AddingNewEventArgs(newObj));
            if (newObj == null)
                newObj = new T();
            this.Add(newObj);
            m_Table.InsertOnSubmit(newObj);
            return newObj;
        }

        /// <summary>
        /// Sichern der Daten in die Datenbank
        /// </summary>
        public void SaveData()
        {
            m_DC.SubmitChanges();
        }
    }
}
