using System;
using MonopolyTask.Models;
using Xunit;

namespace MonopolyTask.Tests;

public class BoxTests
{
    [Fact]
    public void Box_ShouldHaveCorrectVolume()
    {
        // Arrange
        var box = new Box
        {
            Width = 1.0,
            Height = 2.0,
            Depth = 3.0,
        };

        // Act
        var volume = box.Volume;

        // Assert
        Assert.Equal(6.0, volume); // 1.0 * 2.0 * 3.0 = 6.0
    }

    [Fact]
    public void Box_ShouldComputeExpiryDate_WhenExpiryDateIsNull()
    {
        // Arrange
        var box = new Box { ProductionDate = new DateTime(2023, 1, 1) };

        // Act
        var expiryDate = box.ExpiryDateComputed;

        // Assert
        Assert.Equal(new DateTime(2023, 4, 11), expiryDate); // 100 дней после 1 января 2023 года
    }

    [Fact]
    public void Box_ShouldUseGivenExpiryDate_WhenNotNull()
    {
        // Arrange
        var box = new Box
        {
            ProductionDate = new DateTime(2023, 1, 1),
            ExpiryDate = new DateTime(2023, 3, 1),
        };

        // Act
        var expiryDate = box.ExpiryDateComputed;

        // Assert
        Assert.Equal(new DateTime(2023, 3, 1), expiryDate); // Дата срока годности должна быть 1 марта 2023
    }
}
