using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Enum
{
    public static class BaseEnum
    {
        public enum LogSourceList
        {
            AccountRepo = 1,
            AccountMachineRepo = 2,
            AccountPriceRepo = 3,
            AccountPriceHistoryRepo = 4,
            AccountRebateRepo = 5,
            AmountFixedRepo = 6,
            AmountTableRepo = 7,
            EmployeeRepo = 8,
            InventoryRepo = 9,
            ItemRepo = 10,
            LocationGeneralRepo = 11,
            LocationSpecificRepo = 12,
            MachineRepo = 13,
            MachineReadingRepo = 14,
            ModuleRepo = 15,
            MRItemRepo = 16,
            PercentageFixedRepo = 17,
            PercentageTableRepo = 18,
            PurchaseDetailRepo = 19,
            PurchaseMainRepo = 20,
            RebateHistoryRepo = 21,
            RefillRepo = 22,
            RoleRepo = 23,
            RoleAccessRepo = 24,
            UserRepo = 25,
            UserRoleRepo = 26,
            VendorRepo = 27
        }

        public enum SuccessCode
        {
            ProcessSuccess = 1,
            ProcessFailed = 0
        }

        public enum DisplayType
        {
            ShowCustomerName = 1,
            ShowVendorName = 2,
            ShowQueueName = 3
        }


        public enum RoleType
        {
            SystemAdmin = 1,
            Counter = 2,
            Customer = 3,
            ForTVMonitor = 4,
            CompanyAdmin = 5

        }

        public enum AreaCategory
        {
            Recruitment = 1,
            CounteringAndReleasing = 2,
            SamplingAndConsultation = 4,
            FoodGroup = 7
        }

        public enum WalkInOrScheduled
        {
            WalkIn = 1,
            Scheduled = 2
        }

        public enum TypeOfTotalReport
        {
            ByTotalVisit = 1,
            ByTotalWalkIn = 2,
            ByTotalScheduled = 3,
            ByTotalNoShow = 4,
            ByTotalServedDone = 5
        }


        public enum SMGroup
        {
            SMRI = 1,
            FRG = 2,
            SMRIFRG = 3
        }

        public enum TradeType
        {
            Common = 0,
            Trade = 1,
            NonTrade = 2
        }



        public enum BusinessType
        {
            All = 1,
            SMRI = 2,
            FRG = 3
        }

        public enum InternalExternal
        {
            Internal = 0,
            External = 1,
        }

    }
}
