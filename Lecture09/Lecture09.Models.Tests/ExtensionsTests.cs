using Xunit;

namespace Lecture09.Models.Tests
{
    public class ExtensionsTests
    {
        [Theory]
        [InlineData(Entities.Gender.Female, Shared.Gender.Female)]
        [InlineData(Entities.Gender.Male, Shared.Gender.Male)]
        [InlineData(Entities.Gender.Other, Shared.Gender.Other)]
        public void ToGender_converts_to_entities_gender_to_shared_gender(Entities.Gender input, Shared.Gender expected)
        {
            var actual = input.ToGender();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Shared.Gender.Female, Entities.Gender.Female)]
        [InlineData(Shared.Gender.Male, Entities.Gender.Male)]
        [InlineData(Shared.Gender.Other, Entities.Gender.Other)]
        public void ToGender_converts_shared_genter_to_entities_gender(Shared.Gender input, Entities.Gender expected)
        {
            var actual = input.ToGender();

            Assert.Equal(expected, actual);
        }
    }
}
