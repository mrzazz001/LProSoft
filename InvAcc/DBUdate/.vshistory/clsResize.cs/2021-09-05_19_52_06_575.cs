using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public class clsResize
{
    List<System.Drawing.Rectangle> _arr_control_storage = new List<System.Drawing.Rectangle>();
    private bool showRowHeader = false;
    public clsResize(Form _form_)
    {
        form = _form_; //the calling form
        _formSize = _form_.ClientSize; //Save initial form size
        _fontsize = _form_.Font.Size; //Font size
    }

    private float _fontsize { get; set; }

    private System.Drawing.SizeF _formSize { get; set; }

    private Form form { get; set; }

    public void _get_initial_size() //get initial size//
    {
        var _controls = _get_all_controls(form);//call the enumerator
        foreach (Control control in _controls) //Loop through the controls
        {
            _arr_control_storage.Add(control.Bounds); //saves control bounds/dimension            
            //If you have datagridview
            if (control.GetType() == typeof(DataGridView))
                _dgv_Column_Adjust(((DataGridView)control), showRowHeader);
        }
    }

    public void _resize() //Set the resize
    {
        double _form_ratio_width = (double)form.ClientSize.Width / (double)_formSize.Width; //ratio could be greater or less than 1
        double _form_ratio_height = (double)form.ClientSize.Height / (double)_formSize.Height; // this one too
        var _controls = _get_all_controls(form); //reenumerate the control collection
        int _pos = -1;//do not change this value unless you know what you are doing
        foreach (Control control in _controls)
        {
            try
            {
                if (control.Name.ToLower().Contains("DeleveryDatePickers"))
                { }
                if (control.Name.ToLower().Contains("text") || control.Name.ToLower().Contains("txt") || control.Name.ToLower().Contains("dou") || control.Name.Contains("DeleveryDatePickers") || control.Name.ToLower().Contains("cmb") || control.GetType() == typeof(Label))
                {
                    control.Padding = new Padding(0);
                    control.Margin = new Padding(0);

                    control.Font = new System.Drawing.Font(form.Font.FontFamily,
                     (float)(((Convert.ToDouble(_fontsize) * _form_ratio_width) / 2) +
                      ((Convert.ToDouble(_fontsize) * _form_ratio_height) / 2) + (control.GetType() == typeof(Label) ? 0 : 3.5)));
                }
            }
            catch { }
        }
    }

    private void _dgv_Column_Adjust(DataGridView dgv, bool _showRowHeader) //if you have Datagridview 

    {
        int intRowHeader = 0;
        const int Hscrollbarwidth = 5;
        if (_showRowHeader)
            intRowHeader = dgv.RowHeadersWidth;
        else
            dgv.RowHeadersVisible = false;

        for (int i = 0; i < dgv.ColumnCount; i++)
        {
            if (dgv.Dock == DockStyle.Fill) //in case the datagridview is docked
                dgv.Columns[i].Width = ((dgv.Width - intRowHeader) / dgv.ColumnCount);
            else
                dgv.Columns[i].Width = ((dgv.Width - intRowHeader - Hscrollbarwidth) / dgv.ColumnCount);
        }
    }




    private static IEnumerable<Control> _get_all_controls(Control c)
    {
        return c.Controls.Cast<Control>().SelectMany(item =>
            _get_all_controls(item)).Concat(c.Controls.Cast<Control>()).Where(control =>
            control.Name != string.Empty);
    }
}
