namespace Arex388.Kraken {
    public sealed class StatusRequest :
        RequestBase {
        internal override string Endpoint => "https://api.kraken.io/user_status";
    }
}