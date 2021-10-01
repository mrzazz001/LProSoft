using Check_Data.Forms;
using ProShared.GeneralM;using ProShared;
using System;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class MDIParent1 : Form
    { void avs(int arln)

{ 
 menuStrip.Text=   (arln == 0 ? "  MenuStrip  " : "  MenuStrip") ; fileMenu.Text=   (arln == 0 ? "  &File  " : "  &File") ; newToolStripMenuItem.Text=   (arln == 0 ? "  &New  " : "  &New") ; openToolStripMenuItem.Text=   (arln == 0 ? "  &Open  " : "  &Open") ; saveToolStripMenuItem.Text=   (arln == 0 ? "  &Save  " : "  &Save") ; saveAsToolStripMenuItem.Text=   (arln == 0 ? "  Save &As  " : "  Save &As") ; printToolStripMenuItem.Text=   (arln == 0 ? "  &Print  " : "  &Print") ; printPreviewToolStripMenuItem.Text=   (arln == 0 ? "  Print Pre&view  " : "  Print Pre&view") ; printSetupToolStripMenuItem.Text=   (arln == 0 ? "  Print Setup  " : "  Print Setup") ; exitToolStripMenuItem.Text=   (arln == 0 ? "  E&xit  " : "  E&xit") ; editMenu.Text=   (arln == 0 ? "  &Edit  " : "  &Edit") ; undoToolStripMenuItem.Text=   (arln == 0 ? "  &Undo  " : "  &Undo") ; redoToolStripMenuItem.Text=   (arln == 0 ? "  &Redo  " : "  &Redo") ; cutToolStripMenuItem.Text=   (arln == 0 ? "  Cu&t  " : "  Cu&t") ; copyToolStripMenuItem.Text=   (arln == 0 ? "  &Copy  " : "  &Copy") ; pasteToolStripMenuItem.Text=   (arln == 0 ? "  &Paste  " : "  &Paste") ; selectAllToolStripMenuItem.Text=   (arln == 0 ? "  Select &All  " : "  Select &All") ; viewMenu.Text=   (arln == 0 ? "  &View  " : "  &View") ; toolBarToolStripMenuItem.Text=   (arln == 0 ? "  &Toolbar  " : "  &Toolbar") ; statusBarToolStripMenuItem.Text=   (arln == 0 ? "  &Status Bar  " : "  &Status Bar") ; toolsMenu.Text=   (arln == 0 ? "  &Tools  " : "  &Tools") ; optionsToolStripMenuItem.Text=   (arln == 0 ? "  &Options  " : "  &Options") ; windowsMenu.Text=   (arln == 0 ? "  &Windows  " : "  &Windows") ; newWindowToolStripMenuItem.Text=   (arln == 0 ? "  &New Window  " : "  &New Window") ; cascadeToolStripMenuItem.Text=   (arln == 0 ? "  &Cascade  " : "  &Cascade") ; tileVerticalToolStripMenuItem.Text=   (arln == 0 ? "  Tile &Vertical  " : "  Tile & Vertical") ; tileHorizontalToolStripMenuItem.Text=   (arln == 0 ? "  Tile &Horizontal  " : "  Tile &Horizontal") ; closeAllToolStripMenuItem.Text=   (arln == 0 ? "  C&lose All  " : "  C&Lose All") ; arrangeIconsToolStripMenuItem.Text=   (arln == 0 ? "  &Arrange Icons  " : "  &Arrange Icons") ; helpMenu.Text=   (arln == 0 ? "  &Help  " : "  &Help") ; contentsToolStripMenuItem.Text=   (arln == 0 ? "  &Contents  " : "  &Contents") ; indexToolStripMenuItem.Text=   (arln == 0 ? "  &Index  " : "  &Index") ; searchToolStripMenuItem.Text=   (arln == 0 ? "  &Search  " : "  &Search") ; aboutToolStripMenuItem.Text=   (arln == 0 ? "  &About ... ...  " : "  &About ... ...") ; toolStrip.Text=   (arln == 0 ? "  ToolStrip  " : "  ToolStrip") ; newToolStripButton.Text=   (arln == 0 ? "  New  " : "  New") ; openToolStripButton.Text=   (arln == 0 ? "  Open  " : "  Open") ; saveToolStripButton.Text=   (arln == 0 ? "  Save  " : "  Save") ; printToolStripButton.Text=   (arln == 0 ? "  Print  " : "  Print") ; printPreviewToolStripButton.Text=   (arln == 0 ? "  Print Preview  " : "  Print Preview") ; helpToolStripButton.Text=   (arln == 0 ? "  Help  " : "  Help") ; statusStrip.Text=   (arln == 0 ? "  StatusStrip  " : "  StatusStrip") ; toolStripStatusLabel.Text=   (arln == 0 ? "  Status  " : "  Status") ; mainToolStripMenuItem.Text=   (arln == 0 ? "  main  " : "  main") ; invToolStripMenuItem.Text=   (arln == 0 ? "  inv  " : "  inv") ; Text = "MDIParent1";this.Text=   (arln == 0 ? "  MDIParent1  " : "  MDIParent1") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        private int childFormNumber = 0;
        public MDIParent1()
        {
            new FrmMain(null, null, VarGeneral.BranchNumber, 0);
            InitializeComponent();this.Load += langloads;
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
        private void OpenFile(object sender, EventArgs e)
        {
       System.Windows.Forms. OpenFileDialog  openFileDialog = new System.Windows.Forms. OpenFileDialog (); 
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }
        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void MDIParent1_Load(object sender, EventArgs e)
        {
        }
        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Main childForm = new Frm_Main();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
        private void invToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInvSale childForm = new FrmInvSale();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
    }
}
