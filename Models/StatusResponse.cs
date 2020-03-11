using Newtonsoft.Json;

namespace Arex388.Kraken {
    public sealed class StatusResponse :
        ResponseBase {
        /// <summary>
        /// The account's status.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// The account's plan.
        /// </summary>
        [JsonProperty("plan_name")]
        public string PlanName { get; set; }

        /// <summary>
        /// The total bytes allowed for this cycle's quota.
        /// </summary>
        [JsonProperty("quota_total")]
        public long QuotaTotalBytes { get; set; }

        /// <summary>
        /// The total bytes used from this cycle's quota.
        /// </summary>
        [JsonProperty("quota_used")]
        public long QuotaUsedBytes { get; set; }

        /// <summary>
        /// The total bytes remaining in this cycle's quota.
        /// </summary>
        [JsonProperty("quota_remaining")]
        public long QuotaRemainingBytes { get; set; }
    }
}