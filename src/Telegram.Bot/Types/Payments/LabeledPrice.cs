using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegram.Bot.Types.Payments
{
    /// <summary>
    /// This object represents a portion of the price for goods or services.
    /// </summary>
    /// <see href="https://core.bale.ai/bots/api#labeledprice"/>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class LabeledPrice
    {
        /// <summary>
        /// Portion label
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Label { get; set; }

        /// <summary>
        /// Price of the product in the smallest units of the <see href="https://core.bale.ai/bots/payments#supported-currencies">currency</see>.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public int Amount { get; set; }

        /// <summary>
        /// Initializes an instance of <see cref="LabeledPrice"/>
        /// </summary>
        public LabeledPrice()
        { }

        /// <summary>
        /// Initializes an instance of <see cref="LabeledPrice"/>
        /// </summary>
        /// <param name="label">Portion label</param>
        /// <param name="amount">Price of the product</param>
        public LabeledPrice(string label, int amount)
        {
            Label = label;
            Amount = amount;
        }
    }
}
