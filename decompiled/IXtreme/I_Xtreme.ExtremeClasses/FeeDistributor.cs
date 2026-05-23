using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Xtreme.ExtremeClasses;

public class FeeDistributor
{
	public static List<PaymentResult> DistributeFees(List<StudentItems> items, decimal incomingPayment, string studentNo)
	{
		List<PaymentResult> list = new List<PaymentResult>();
		IOrderedEnumerable<StudentItems> orderedEnumerable = items.OrderBy((StudentItems i) => i.PriorityIndex);
		foreach (StudentItems item in orderedEnumerable)
		{
			decimal num = item.RequiredAmount - item.PaidAmount;
			if (!(num <= 0m))
			{
				decimal num2 = Math.Min(incomingPayment, num);
				if (num2 > 0m)
				{
					list.Add(new PaymentResult
					{
						Name = item.Name,
						AmountAllocated = num2,
						AccNo = item.AccNo
					});
					item.PaidAmount += num2;
					incomingPayment -= num2;
				}
				if (incomingPayment <= 0m)
				{
					break;
				}
			}
		}
		if (incomingPayment > 0m)
		{
			list.Add(new PaymentResult
			{
				Name = "Fees Paid In Advance",
				AmountAllocated = incomingPayment,
				AccNo = "1001-0001"
			});
		}
		return list;
	}
}
