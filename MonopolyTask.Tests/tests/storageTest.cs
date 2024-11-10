using MonopolyTask.Models;
using Xunit;

namespace MonopolyTask.Tests;

public class StorageTests
{
    [Fact]
    public void Storage_ShouldGroupPalletsByExpiryDate()
    {
        // Arrange
        var storage = new Storage();

        var pallet1 = new Pallet { Id = 1 };
        pallet1.AddBox(new Box { ExpiryDate = new DateTime(2023, 5, 1) });

        var pallet2 = new Pallet { Id = 2 };
        pallet2.AddBox(new Box { ExpiryDate = new DateTime(2024, 6, 1) });

        storage.AddPallet(pallet1);
        storage.AddPallet(pallet2);

        // Act
        var groupedPallets = storage.GroupByExpiryDate();

        // Assert
        var group = groupedPallets.First();
        Assert.Equal(new DateTime(2023, 5, 1), group.Key); // Группа по сроку годности 1 мая 2023
        Assert.Single(group);
    }

    [Fact]
    public void Storage_ShouldReturnTop3PalletsByExpiryDate()
    {
        // Arrange
        var storage = new Storage();

        var pallet1 = new Pallet { Id = 1 };
        pallet1.AddBox(new Box { ExpiryDate = new DateTime(2023, 5, 1) });
        storage.AddPallet(pallet1);

        var pallet2 = new Pallet { Id = 2 };
        pallet2.AddBox(new Box { ExpiryDate = new DateTime(2024, 6, 1) });
        storage.AddPallet(pallet2);

        var pallet3 = new Pallet { Id = 3 };
        pallet3.AddBox(new Box { ExpiryDate = new DateTime(2022, 7, 1) });
        storage.AddPallet(pallet3);

        var pallet4 = new Pallet { Id = 4 };
        pallet4.AddBox(new Box { ExpiryDate = new DateTime(2025, 8, 1) });
        storage.AddPallet(pallet4);

        // Act
        var topPallets = storage.GetTop3PalletsByExpiryDate();

        // Assert
        Assert.Equal(3, topPallets.Count);
        Assert.Equal(2025, topPallets[0].ExpiryDate.Year); // Наибольший срок годности
    }
}
