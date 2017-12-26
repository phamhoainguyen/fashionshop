using DevExpress.Xpf.Editors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.PL.QUANLYBANHANG.plUtilities
{
    class ComboxUtils
    {
        public static void InsertItem(ref ComboBoxEdit comboBoxEdit, string displayMember, string valueMember, int positionIndex, bool isSelected = false)
        {

            DataView dataview = ((DataView)comboBoxEdit.ItemsSource);
            DataTable dataTable = dataview.ToTable();
            DataRow firstRow = dataTable.NewRow();
            firstRow[0] = displayMember;
            firstRow[1] = valueMember;
            dataTable.Rows.InsertAt(firstRow, positionIndex);
            comboBoxEdit.ItemsSource = dataTable.DefaultView;
            comboBoxEdit.EditValue = 10;    // select id = 10
            
        }

        public static void SetComboBoxEdit(ref ComboBoxEdit comboBoxEdit, string displayMember, string valueMember, DataTable dataTable)
        {
            
            comboBoxEdit.DisplayMember = displayMember;
            comboBoxEdit.ValueMember = valueMember;
            comboBoxEdit.ItemsSource = dataTable.DefaultView;
        }
    }

    //DataRowView dataRowView = (DataRowView)this.cboKhoa.SelectedItem;
    //int n = (int)this.cboKhoa.EditValue;
    //int value = (int)dataRowView["id"];
    //string name = (string)dataRowView["name"];
}
