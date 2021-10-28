using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Helper
{
    public class EnumExteniosns
    {

    }

    public enum AccountChannelStatus2 : short
    {
        InActive = 0,
        Active = 1,
        Created = 2,
        Susppened = 3,
        Deleted = 4
    }

    public enum PaymentMode : short
    {
        Fixed = 1,
        Percentage = 2,
        Other = 3,
    }

    public enum BillPaymentMode : short
    {
        OnlyOne = 1,
        MustAll = 2,
        Multiple = 3,
    }

    public enum Currency : short
    {
        EGP = 1,
        USD = 2,
        UAE = 3,
    }
}
