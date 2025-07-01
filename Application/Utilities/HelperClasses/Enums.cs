using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Utilities.HelperClasses
{
    public static class Enums
    {
        public enum UserRole
        {
            ADMIN,
            USER,
            GUSET
        }
        public enum EmailStatus
        {
            Pending,
            Sent,
            Failed
        }
        public enum ConfirmationStatus
        {
            Unconfirmed,
            Confirmed,
            Expired
        }
    }
}
