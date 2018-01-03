using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;
using Telegram.Bot.Types.InputMessageContents;

namespace Telegram.Bot.Types.InlineQueryResults
{
    /// <summary>
    /// Represents a link to an mp3 audio file stored on the Telegram servers. By default, this audio file will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the audio.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class InlineQueryResultAudio : InlineQueryResultBase,
                                          ICaptionInlineQueryResult,
                                          ITitleInlineQueryResult,
                                          IInputMessageContentResult
    {
        /// <summary>
        /// Initializes a new inline query result
        /// </summary>
        public InlineQueryResultAudio()
            : base(InlineQueryResultType.Audio)
        { }

        /// <summary>
        /// Initializes a new inline query result
        /// </summary>
        /// <param name="id">Unique identifier of this result</param>
        /// <param name="audioUrl">A valid URL for the audio file</param>
        /// <param name="title">Title of the result</param>
        public InlineQueryResultAudio(string id, Uri audioUrl, string title)
            : this()
        {
            Id = id;
            Url = audioUrl;
            Title = title;
        }

        /// <summary>
        /// A valid URL for the audio file
        /// </summary>
        [JsonProperty("audio_url", Required = Required.Always)]
        public Uri Url { get; set; }

        /// <summary>
        /// Optional. Performer
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Performer { get; set; }

        /// <summary>
        /// Optional. Audio duration in seconds
        /// </summary>
        [JsonProperty("audio_duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Duration { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Caption { get; set; }

        /// <inheritdoc />
        [JsonProperty(Required = Required.Always)]
        public string Title { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InputMessageContent InputMessageContent { get; set; }
    }
}
