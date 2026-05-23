using System;
using System.Data;

namespace I_Xtreme;

public delegate void AccountReportParameters(DateTime StartDate, DateTime EndDate, string navHeader, string AccountName, DataTable dt, int LedgerNo);
