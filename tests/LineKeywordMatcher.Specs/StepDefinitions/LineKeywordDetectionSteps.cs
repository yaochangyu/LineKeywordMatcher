using LineKeywordMatcher;
using TechTalk.SpecFlow;
using Xunit;

namespace LineKeywordMatcher.Specs.StepDefinitions;

[Binding]
public class LineKeywordDetectionSteps
{
    private string _input = string.Empty;
    private bool _result;

    [Given(@"輸入文字為 ""(.*)""")]
    public void 輸入文字為(string input)
    {
        _input = input;
    }

    [When(@"檢查是否包含 LINE 關鍵字")]
    public void 檢查是否包含LINE關鍵字()
    {
        _result = LineContactKeywordMatcher.ContainsLineKeyword(_input);
    }

    [Then(@"結果應為 (.*)")]
    public void 結果應為(bool expected)
    {
        Assert.Equal(expected, _result);
    }
}
