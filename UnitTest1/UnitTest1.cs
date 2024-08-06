namespace UnitTest1;
using BlazorWebAssembly.Pages;
using Bunit;

public class UnitTest1 : TestContext
{
    [Fact]
    public void TestCounter()
    {
        var component = RenderComponent<Counter>();

        var paragraph = component.Find("p");

        Assert.Equal("Current count: 0", paragraph.TextContent);
    }

    [Fact]
    public void TestAddTask()
    {
        var component = RenderComponent<Todo>();

        component.Find("input").Change("Walk the dog");
        component.Find("button").Click();

        Assert.Contains("Walk the dog", component.Instance.tasks);

        component.Find("ul").MarkupMatches("<ul><li>Walk the dog</li></ul>");
    }

    [Fact]
    public void TestClearInputAfterAddingTask()
    {
        var component = RenderComponent<Todo>();

        component.Find("input").Change("Walk the cat");
        component.Find("button").Click();

        var input = component.Find("input");
        Assert.Equal(string.Empty, input.GetAttribute("value"));
    }

    [Fact]
    public void DoesNotAddEmptyTask()
    {
        var component = RenderComponent<Todo>();

        component.Find("input").Change(string.Empty);
        component.Find("button").Click();

        Assert.Empty(component.Instance.tasks);
        component.Find("ul").MarkupMatches("<ul></ul>");
    }

    [Fact]
    public void DoesNotAddMultipleSpaces()
    {
        var component = RenderComponent<Todo>();

        component.Find("input").Change("       ");
        component.Find("button").Click();

        Assert.Empty(component.Instance.tasks);
        component.Find("ul").MarkupMatches("<ul></ul>");
    }
}