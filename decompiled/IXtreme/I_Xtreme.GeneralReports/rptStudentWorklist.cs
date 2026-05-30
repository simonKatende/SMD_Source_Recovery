using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.Drawing;
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
        this.Margins    = new DXMargins(25f, 25f, 25f, 25f);

        ReportHelper.AddSchoolHeader(this, "Student Fees Worklist");
        AddColumnHeader();
        AddDetailBand();
        AddPageFooter();
    }

    private static (string caption, float width)[] Columns() => new[]
    {
        ("Name",         135f), ("Stud#",        76f), ("ID",       76f), ("Class",  42f), ("D/B",        30f),
        ("Payable",       76f), ("Paid",          76f), ("Balance",  76f), ("% Paid", 46f), ("Status",     63f),
        ("Priority",      76f), ("Guardian",     118f), ("Contact",  84f), ("Last Contact", 68f), ("Last Outcome", 76f),
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
            if (fields[i] == "LastContactDate")
                lbl.DataBindings.Add(new XRBinding("Text", null, "LastContactDate", "{0:dd-MMM-yyyy}"));
            else
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
