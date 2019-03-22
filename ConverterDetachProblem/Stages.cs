using System.Collections.Generic;
using System.Linq;

namespace ConverterDetachProblem
{
    public static class Stages
    {
        public static readonly Stage Received = new Stage(1) { Name = "1. Received", Label = "Received", IsComplete = false };
        public static readonly Stage PendingExchqr = new Stage(2) { Name = "2. Pending Exchequer", Label = "Pending Exchequer", IsComplete = false };
        public static readonly Stage InExchqr = new Stage(3) { Name = "3. In Exchequer", Label = "In Exchequer", IsComplete = false };
        public static readonly Stage PendingApproval = new Stage(4) { Name = "4. Pending Approval", Label = "Unapproved", IsComplete = false };
        public static readonly Stage ManagerApproved = new Stage(5) { Name = "5. Manager Approved", Label = "Manager Approved", IsComplete = false };
        public static readonly Stage PartnerApproved = new Stage(6) { Name = "6. Partner Approved", Label = "Partner Approved", IsComplete = true };
        public static readonly Stage Signoff = new Stage(7) { Name = "7. Signed Off", Label = "Signed Off", IsComplete = true };
        public static readonly Stage Paid = new Stage(8) { Name = "8. Paid", Label = "Paid", IsComplete = true };

        public static readonly List<Stage> AllStages = new[] { Received, PendingApproval, ManagerApproved, PartnerApproved, Signoff, PendingExchqr, InExchqr, Paid }.OrderBy(x => x.Name).ToList();
    }
}