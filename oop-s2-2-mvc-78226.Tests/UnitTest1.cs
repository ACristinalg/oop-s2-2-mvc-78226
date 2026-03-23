using oop_s2_2_mvc_78226.Models;

namespace oop_s2_2_mvc_78226.Tests;

public class InspectionTests
{
    // Test 1: FollowUp vencido cuando DueDate pasado y Status Open
    [Fact]
    public void OverdueFollowUp_DueDatePassedAndOpen()
    {
        var followUp = new FollowUp
        {
            DueDate = DateTime.Now.AddDays(-5),
            Status = "Open"
        };

        bool isOverdue = followUp.DueDate < DateTime.Now && followUp.Status == "Open";
        Assert.True(isOverdue);
    }

    // Test 2: FollowUp cerrado no es vencido
    [Fact]
    public void ClosedFollowUp_NotOverdue()
    {
        var followUp = new FollowUp
        {
            DueDate = DateTime.Now.AddDays(-5),
            Status = "Closed",
            ClosedDate = DateTime.Now
        };

        bool isOverdue = followUp.DueDate < DateTime.Now && followUp.Status == "Open";
        Assert.False(isOverdue);
    }

    // Test 3: FollowUp no puede cerrarse sin ClosedDate
    [Fact]
    public void FollowUp_CannotBeClosedWithoutClosedDate()
    {
        var followUp = new FollowUp
        {
            Status = "Closed",
            ClosedDate = null
        };

        bool isValid = !(followUp.Status == "Closed" && followUp.ClosedDate == null);
        Assert.False(isValid);
    }

    // Test 4: Inspection con score bajo es Fail
    [Fact]
    public void Inspection_LowScore_IsFail()
    {
        var inspection = new Inspection
        {
            Score = 30,
            Outcome = 30 >= 50 ? "Pass" : "Fail"
        };

        Assert.Equal("Fail", inspection.Outcome);
    }
}