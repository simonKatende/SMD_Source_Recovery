using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace I_Xtreme.NavigationForms;

public class usrFeesFollowUp : UserControl
{
    private IContainer components = null;
    private SplitContainerControl splitContainer;

    public usrFeesFollowUp()
    {
        InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
        ((System.ComponentModel.ISupportInitialize)this.splitContainer).BeginInit();
        this.splitContainer.SuspendLayout();
        this.SuspendLayout();

        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Horizontal = false;       // vertical split
        this.splitContainer.SplitterPosition = 700;   // tuned later
        this.splitContainer.Name = "splitContainer";

        this.Controls.Add(this.splitContainer);
        this.Name = "usrFeesFollowUp";
        this.Size = new System.Drawing.Size(1280, 720);

        ((System.ComponentModel.ISupportInitialize)this.splitContainer).EndInit();
        this.splitContainer.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
