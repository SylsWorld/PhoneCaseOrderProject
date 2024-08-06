using BlazorWebAssembly.Pages;
using Bunit;

namespace UnitTest1;


public class TestCases : TestContext
{
    [Fact]
    public void TestAddCase()
    {
        var component = RenderComponent<PhoneCaseForm>();

        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();

        Assert.Contains("Samsung", component.Instance.PhoneCases.Select(c => c.Brand));
        Assert.Contains("Z-Fold 5", component.Instance.PhoneCases.Select(c => c.Model));
        Assert.Contains("ABS", component.Instance.PhoneCases.Select(c => c.Material));
        Assert.Contains(100, component.Instance.PhoneCases.Select(c => c.Cost));
        Assert.Contains("Black", component.Instance.PhoneCases.Select(c => c.TrimColor));
        Assert.Contains("Pink", component.Instance.PhoneCases.Select(c => c.AccentColor));
    }

    [Fact]
    public void TestAddMultipleCases()
    {
        var component = RenderComponent<PhoneCaseForm>();

        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();

        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Galaxy S21");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("50");
        component.Find("#trim").Change("Purple");
        component.Find("#accent").Change("Green");
        component.Find("button").Click();

        Assert.Equal(2, component.Instance.PhoneCases.Count);
    }
    
    [Fact]
    public void TestClearsInputAfterAddingCase()
    {
        var component = RenderComponent<PhoneCaseForm>();

        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        Assert.Null(component.Find("#brand").GetAttribute("value"));
        Assert.Null(component.Find("#model").GetAttribute("value"));
        Assert.Null(component.Find("#material").GetAttribute("value"));
        Assert.Equal("0", component.Find("#cost").GetAttribute("value"));
        Assert.Null(component.Find("#trim").GetAttribute("value"));
        Assert.Null(component.Find("#accent").GetAttribute("value"));
    }

    [Fact]
    public void TestDoesNotAddEmptyPhoneCase()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change(string.Empty);
        component.Find("#model").Change(string.Empty);
        component.Find("#material").Change(string.Empty);
        component.Find("#cost").Change(0);
        component.Find("#trim").Change(string.Empty);
        component.Find("#accent").Change(string.Empty);
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    
    [Fact]
    public void TestDoesNotAddPhoneCaseWithMissingAttribute()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change(string.Empty);
        component.Find("#accent").Change(string.Empty);
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    
    [Fact]
    public void TestDoesNotAddPhoneCaseWithNegativeCost()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("-100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    
    [Fact]
    public void TestDoesNotAddPhoneCaseWithWhiteSpaceBrand()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("  ");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    
    [Fact]
    public void TestDoesNotAddPhoneCaseWithWhiteSpaceModel()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("   ");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    [Fact]
    public void TestDoesNotAddPhoneCaseWithWhiteSpaceMaterial()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("   ");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    [Fact]
    public void TestDoesNotAddPhoneCaseWithWhiteSpaceTrim()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("   ");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    [Fact]
    public void TestDoesNotAddPhoneCaseWithWhiteSpaceAccent()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("   ");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    
    [Fact]
    public void TestDoesNotAddDuplicateCases()
    {
        var component = RenderComponent<PhoneCaseForm>();

        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();

        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();

        Assert.Single(component.Instance.PhoneCases);
    }
    
    [Fact]
    public void TestDoesNotAddPhoneCaseWithExceedingLengthBrand()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("This is more than 25 characters");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    [Fact]
    public void TestDoesNotAddPhoneCaseWithExceedingLengthModel()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("This is more than 25 characters");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    [Fact]
    public void TestDoesNotAddPhoneCaseWithExceedingLengthMaterial()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("This is more than 30 characters");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    [Fact]
    public void TestDoesNotAddPhoneCaseWithExceedingLengthTrim()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("This is more than 30 characters");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    [Fact]
    public void TestDoesNotAddPhoneCaseWithExceedingLengthAccent()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("This is more than 30 characters");
        component.Find("button").Click();
        
        Assert.Empty(component.Instance.PhoneCases);
    }
    
    [Fact]
    public void TestErrorMessageForNoBrand()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("  ");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();

        var actual = component.Find(".validation-message");
        
        Assert.Equal("You must have a phone Brand", actual.TextContent);
    }
    
    [Fact]
    public void TestErrorMessageForNoModel()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("   ");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        var actual = component.Find(".validation-message");
        
        Assert.Equal("You must have a phone Model", actual.TextContent);
    }
    
    [Fact]
    public void TestErrorMessageForNoMaterial()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("   ");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        var actual = component.Find(".validation-message");
        
        Assert.Equal("You must have a Material", actual.TextContent);
    }
    
    [Fact]
    public void TestErrorMessageForNoTrim()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("   ");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        var actual = component.Find(".validation-message");
        
        Assert.Equal("You must have a Trim color", actual.TextContent);
    }
    [Fact]
    public void TestErrorMessageForNoAccent()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("   ");
        component.Find("button").Click();
        
        var actual = component.Find(".validation-message");
        
        Assert.Equal("You must have an Accent color", actual.TextContent);
    }
    
    [Fact]
    public void TestErrorMessageForBrandExceedingCharacterLength25()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("This is longer than 25 characters");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();

        var actual = component.Find(".validation-message");
        
        Assert.Equal("Brand cannot exceed 25 characters in length", actual.TextContent);
    }
    
    [Fact]
    public void TestErrorMessageForModelExceedingCharacterLength25()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("This is longer than 25 characters");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        var actual = component.Find(".validation-message");
        
        Assert.Equal("Model cannot exceed 25 characters in length", actual.TextContent);
    }
    
    [Fact]
    public void TestErrorMessageForMaterialExceedingCharacterLength30()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("This is longer than 30 characters");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        var actual = component.Find(".validation-message");
        
        Assert.Equal("Material cannot exceed 30 characters in length", actual.TextContent);
    }
    
    [Fact]
    public void TestErrorMessageForTrimExceedingCharacterLength30()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("This is longer than 30 characters");
        component.Find("#accent").Change("Pink");
        component.Find("button").Click();
        
        var actual = component.Find(".validation-message");
        
        Assert.Equal("Trim color cannot exceed 30 characters in length", actual.TextContent);
    }
    [Fact]
    public void TestErrorMessageForAccentExceedingCharacterLength30()
    {
        var component = RenderComponent<PhoneCaseForm>();
        
        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("Z-Fold 5");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("This is longer than 30 characters");
        component.Find("button").Click();
        
        var actual = component.Find(".validation-message");
        
        Assert.Equal("Accent color cannot exceed 30 characters in length", actual.TextContent);
    }

    [Fact]                                       
    public void TestErrorMessageForInvalidPhoneBrand()
    {                                            
        var component = RenderComponent<PhoneCaseForm>();                                      
                                                                                       
        component.Find("#brand").Change("Apple");                                            
        component.Find("#model").Change("Z-Fold 5");                                           
        component.Find("#material").Change("ABS");                                             
        component.Find("#cost").Change("100");                                                 
        component.Find("#trim").Change("Black");                                               
        component.Find("#accent").Change("This is longer than 30 characters");                 
        component.Find("button").Click();                                                      
                                                                                       
        var actual = component.Find(".validation-message");                                    
                                                                                       
        Assert.Equal($"The value 'Apple' is not valid. Allowed values are: Samsung, Google, Nokia, Motorola, BlackBerry, Sony, Lg, Razer.", actual.TextContent);                                           
    }

    [Fact]
    public void TestErrorMessageForInvalidPhoneModel()
    {
        var component = RenderComponent<PhoneCaseForm>();

        component.Find("#brand").Change("Samsung");
        component.Find("#model").Change("iPhone 13 Pro Max");
        component.Find("#material").Change("ABS");
        component.Find("#cost").Change("100");
        component.Find("#trim").Change("Black");
        component.Find("#accent").Change("This is longer than 30 characters");
        component.Find("button").Click();

        var actual = component.Find(".validation-message");

        Assert.Equal($"The value 'iPhone 13 Pro Max' is not valid because it contains 'iPhone'.", actual.TextContent);
    }
}      