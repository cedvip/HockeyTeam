using HockeyTeam.Controllers;
using System;
using Xunit;

namespace TestHockeyTeam
{
    public class HockeyTeamUnitTest
    {
        [Fact]
        public void ShouldReturnTeam()
        {
            var controller = new TeamController();

            var result = controller.Team(2021);

            Assert.NotNull(result);
        }
    }
}
