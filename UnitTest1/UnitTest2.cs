using BlazorWebAssembly.Pages;
using Bunit;

namespace UnitTest1
{
    public class UnitTest2 : TestContext
    {
        [Fact]
        public void AddFossil()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change("T-Rex");
            component.Find("#species").Change("Tyrannosaurus");
            component.Find("#age").Change("64");
            component.Find("#location").Change("North America");
            component.Find("#description").Change("Large carnivorous dinosaur.");
            component.Find("button").Click();

            Assert.Contains("T-Rex", component.Instance.Fossils.Select(f => f.Name));
            Assert.Contains("Tyrannosaurus", component.Instance.Fossils.Select(f => f.Species));
            Assert.Contains(64, component.Instance.Fossils.Select(f => f.Age));
            Assert.Contains("North America", component.Instance.Fossils.Select(f => f.Location));
            Assert.Contains("Large carnivorous dinosaur.", component.Instance.Fossils.Select(f => f.Description));
        }

        [Fact]
        public void ClearInputAfterAddingFossil()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change("Triceratops");
            component.Find("#species").Change("Triceratops horridus");
            component.Find("#age").Change("66");
            component.Find("#location").Change("North America");
            component.Find("#description").Change("Herbivorous dinosaur with three horns.");
            component.Find("button").Click();

            Assert.Equal(string.Empty, component.Find("#name").GetAttribute("value"));
            Assert.Equal(string.Empty, component.Find("#species").GetAttribute("value"));
            Assert.Equal("0", component.Find("#age").GetAttribute("value"));
            Assert.Equal(string.Empty, component.Find("#location").GetAttribute("value"));
            Assert.Equal(string.Empty, component.Find("#description").TextContent);
        }

        [Fact]
        public void DoesNotAddEmptyFossil()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change(string.Empty);
            component.Find("#species").Change(string.Empty);
            component.Find("#age").Change(string.Empty);
            component.Find("#location").Change(string.Empty);
            component.Find("#description").Change(string.Empty);
            component.Find("button").Click();

            Assert.Empty(component.Instance.Fossils);
        }

        [Fact]
        public void DoesNotAddFossilWithMissingAttributes()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change("Incomplete Fossil");
            component.Find("#species").Change(string.Empty); // Missing species
            component.Find("#age").Change("64");
            component.Find("#location").Change("Unknown");
            component.Find("#description").Change("Some description");
            component.Find("button").Click();

            Assert.Empty(component.Instance.Fossils);
        }

        [Fact]
        public void DoesNotAddFossilWithNegativeAge()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change("Negative Age Fossil");
            component.Find("#species").Change("Unknown");
            component.Find("#age").Change("-5");
            component.Find("#location").Change("Unknown");
            component.Find("#description").Change("Some description");
            component.Find("button").Click();

            Assert.Empty(component.Instance.Fossils);
        }

        [Fact]
        public void AddMultipleFossils()
        {
            var component = RenderComponent<FossilForm>();

            // First fossil
            component.Find("#name").Change("Stegosaurus");
            component.Find("#species").Change("Stegosaurus armatus");
            component.Find("#age").Change("59");
            component.Find("#location").Change("North America");
            component.Find("#description").Change("Herbivorous dinosaur with plates along its back.");
            component.Find("button").Click();

            // Second fossil
            component.Find("#name").Change("Brachiosaurus");
            component.Find("#species").Change("Brachiosaurus altithorax");
            component.Find("#age").Change("61");
            component.Find("#location").Change("North America");
            component.Find("#description").Change("Large herbivorous dinosaur with long neck.");
            component.Find("button").Click();

            Assert.Equal(2, component.Instance.Fossils.Count);
        }

        [Fact]
        public void DoesNotAddFossilWithWhitespaceName()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change(" ");
            component.Find("#species").Change("SomeSpecies");
            component.Find("#age").Change("65");
            component.Find("#location").Change("Somewhere");
            component.Find("#description").Change("Some description");
            component.Find("button").Click();

            Assert.Empty(component.Instance.Fossils);
        }

        [Fact]
        public void DoesNotAddFossilWithWhitespaceSpecies()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change("Dino");
            component.Find("#species").Change(" ");
            component.Find("#age").Change("65");
            component.Find("#location").Change("Somewhere");
            component.Find("#description").Change("Some description");
            component.Find("button").Click();

            Assert.Empty(component.Instance.Fossils);
        }

        [Fact]
        public void DoesNotAddFossilWithZeroAge()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change("Zero Age Fossil");
            component.Find("#species").Change("Unknown");
            component.Find("#age").Change("0");
            component.Find("#location").Change("Unknown");
            component.Find("#description").Change("Some description");
            component.Find("button").Click();

            Assert.Empty(component.Instance.Fossils);
        }

        [Fact]
        public void DoesNotAddFossilWithWhitespaceLocation()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change("Dino");
            component.Find("#species").Change("SomeSpecies");
            component.Find("#age").Change("65");
            component.Find("#location").Change(" ");
            component.Find("#description").Change("Some description");
            component.Find("button").Click();

            Assert.Empty(component.Instance.Fossils);
        }

        [Fact]
        public void DoesNotAddFossilWithWhitespaceDescription()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change("Dino");
            component.Find("#species").Change("SomeSpecies");
            component.Find("#age").Change("65");
            component.Find("#location").Change("Somewhere");
            component.Find("#description").Change(" ");
            component.Find("button").Click();

            Assert.Empty(component.Instance.Fossils);
        }

        [Fact]
        public void DoesNotAddDuplicateFossilName()
        {
            var component = RenderComponent<FossilForm>();

            component.Find("#name").Change("Velociraptor");
            component.Find("#species").Change("Velociraptor mongoliensis");
            component.Find("#age").Change("75");
            component.Find("#location").Change("Mongolia");
            component.Find("#description").Change("Small carnivorous dinosaur.");
            component.Find("button").Click();

            component.Find("#name").Change("Velociraptor");
            component.Find("#species").Change("Velociraptor mongoliensis");
            component.Find("#age").Change("75");
            component.Find("#location").Change("Mongolia");
            component.Find("#description").Change("Small carnivorous dinosaur.");
            component.Find("button").Click();

            Assert.Single(component.Instance.Fossils);
        }
    }
}
