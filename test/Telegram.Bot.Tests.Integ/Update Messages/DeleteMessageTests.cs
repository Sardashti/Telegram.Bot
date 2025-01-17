using System.Threading.Tasks;
using Telegram.Bot.Tests.Integ.Framework;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Xunit;

namespace Telegram.Bot.Tests.Integ.Update_Messages
{
    [Collection(Constants.TestCollections.DeleteMessage)]
    [Trait(Constants.CategoryTraitName, Constants.InteractiveCategoryValue)]
    [TestCaseOrderer(Constants.TestCaseOrderer, Constants.AssemblyName)]
    public class DeleteMessageTests
    {
        private ITelegramBotClient BotClient => _fixture.BotClient;

        private readonly TestsFixture _fixture;

        public DeleteMessageTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [OrderedFact(DisplayName = FactTitles.ShouldDeleteMessageFromInlineQuery)]
        [Trait(Constants.MethodTraitName, Constants.TelegramBotApiMethods.AnswerInlineQuery)]
        public async Task Should_Delete_Message_From_InlineQuery()
        {
            await _fixture.SendTestCaseNotificationAsync(FactTitles.ShouldDeleteMessageFromInlineQuery,
                startInlineQuery: true);

            Update queryUpdate = await _fixture.UpdateReceiver.GetInlineQueryUpdateAsync();

            await BotClient.AnswerInlineQueryAsync(
                inlineQueryId: queryUpdate.InlineQuery.Id,
                results: new[]
                {
                    new InlineQueryResultArticle(
                        id: "article-to-delete",
                        title: "Telegram Bot API",
                        inputMessageContent: new InputTextMessageContent("https://www.bale.ai/")
                    )
                },
                cacheTime: 0
            );

            (Update messageUpdate, Update chosenResultUpdate) = await _fixture.UpdateReceiver.GetInlineQueryResultUpdates(MessageType.Text);

            await Task.Delay(1_000);

            await BotClient.DeleteMessageAsync(
                chatId: messageUpdate.Message.Chat.Id,
                messageId: messageUpdate.Message.MessageId
            );
        }

        private static class FactTitles
        {
            public const string ShouldDeleteMessageFromInlineQuery =
                "Should delete message generated from an inline query result";
        }
    }
}
