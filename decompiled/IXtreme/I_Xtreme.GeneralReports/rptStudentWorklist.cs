using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using I_Xtreme.Models;

namespace I_Xtreme.GeneralReports;

public class rptStudentWorklist : XtraReport
{
    public rptStudentWorklist(List<StudentWorklistRow> data)
    {
        this.DataSource = data;
        this.PaperKind  = DXPaperKind.A4;
        this.Landscape  = true;

        ReportHelper.AddSchoolHeader(this, "Student Fees Worklist");
        AddColumnHeader();
        AddDetailBand();
        AddPageFooter();
    }

    private static (string caption, float width)[] Columns() => new[]
    {
        ("Name",         160f), ("Stud#",        90f), ("ID",       90f), ("Class",  50f), ("D/B",        35f),
        ("Payable",       90f), ("Paid",          90f), ("Balance",  90f), ("% Paid", 55f), ("Status",     75f),
        ("Priority",      90f), ("Guardian",     140f), ("Contact", 100f), ("Last Contact", 80f), ("Last Outcome", 90f),
    };

    private void AddColumnHeader()
    {
        var band = new GroupHeaderBand { HeightF = 22f };
        float x = 0;
        foreach (var (caption, width) in Columns())
        {
            band.Controls.Add(new XRLabel
            {
                Text      = caption,
                Font      = new Font("Tahoma", 8, FontStyle.Bold),
                BoundsF   = new RectangleF(x, 0, width, 20),
                BackColor = Color.LightSteelBlue,
                Borders   = BorderSide.All,
            });
            x += width;
        }
        this.Bands.Add(band);
    }

    private void AddDetailBand()
    {
        var band = new DetailBand { HeightF = 20f };
        string[] fields = { "FullName", "StudentNumber", "StudentId", "ClassId", "DayBoarder",
                            "TotalBilled", "TotalPaid", "Balance", "PaymentPercent", "PaymentStatus",
                            "Tier", "GuardianLabel", "GuardianContact", "LastContactDate", "LastOutcome" };
        var cols = Columns();
        float x = 0;
        for (int i = 0; i < fields.Length; i++)
        {
            var lbl = new XRLabel
            {
                Font    = new Font("Tahoma", 8),
                BoundsF = new RectangleF(x, 0, cols[i].width, 18),
                Borders = BorderSide.All,
            };
            lbl.DataBindings.Add("Text", null, fields[i]);
            band.Controls.Add(lbl);
            x += cols[i].width;
        }
        this.Bands.Add(band);
    }

    private void AddPageFooter()
    {
        var band = new PageFooterBand { HeightF = 20f };
        band.Controls.Add(new XRPageInfo
        {
            PageInfo = PageInfo.NumberOfTotal,
            Font     = new Font("Tahoma", 8),
            BoundsF  = new RectangleF(0, 0, 200, 18),
        });
        band.Controls.Add(new XRLabel
        {
            Text    = $"Generated: {DateTime.Now:dd-MMM-yyyy HH:mm}",
            Font    = new Font("Tahoma", 8),
            BoundsF = new RectangleF(500, 0, 250, 18),
        });
        this.Bands.Add(band);
    }
}
