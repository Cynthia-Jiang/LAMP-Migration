
namespace ARMClient.Authentication.Contracts
{
    public class TenantCacheInfo
    {
        public string tenantId { get; set; }
        public string displayName { get; set; }
        public string domain { get; set; }
        public SubscriptionCacheInfo[] subscriptions { get; set; }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            TenantCacheInfo p = obj as TenantCacheInfo;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return tenantId == p.tenantId;
        }
    }
}
