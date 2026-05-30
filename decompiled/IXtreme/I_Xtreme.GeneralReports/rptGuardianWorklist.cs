using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using I_Xtreme.Models;

namespace I_Xtreme.GeneralReports;

public class rptGuardianWorklist : XtraReport
{
    public rptGuardianWorklist(List<GuardianWorklistRow> data)
    {
        this.DataSource = data;
        this.PaperKind  = DXPaperKind.A4;
        this.Landscape  = true;
        this.Margins    = new DXMargins(25f, 25f, 25f, 25f);

        ReportHelper.AddSchoolHeader(this, "Guardian Worklist");
        AddColumnHeader();
        AddDetailBand();
        AddPageFooter();
    }

    private static (string caption, float width)[] Columns() => new[]
    {
        ("Guardian",      180f), ("Contact",   110f), ("Alt Contact", 110f), ("Students", 180f),
        ("Balance",       110f), ("% Paid",     60f), ("Status",       90f), ("Priority",  100f),
        ("Last Contact",   90f), ("Last Outcome",  89f),
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
        string[] fields = { "GuardianLabel", "GuardianContact", "Contact2", "StudentNames",
                            "TotalBalance", "PaymentPercent", "PaymentStatus", "Tier",
                            "LastContactDate", "LastOutcome" };
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
