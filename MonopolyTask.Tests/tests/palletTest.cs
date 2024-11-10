using System;
using System.Collections.Generic;
using MonopolyTask.Models;
using Xunit;

namespace MonopolyTask.Tests
{
    public class PalletTests
    {
        [Fact]
        public void AddBox_ShouldAddBoxToPallet_WhenBoxFits()
        {
            // Arrange
            var pallet = new Pallet
            {
                Id = 1,
                Width = 2.0,
                Height = 2.0,
                Depth = 2.0,
            };
            var box = new Box
            {
                Id = 1,
                Width = 1.5,
                Height = 1.5,
                Depth = 1.5,
                Weight = 5.0,
                ProductionDate = new DateTime(2023, 1, 1),
            };

            // Act
            bool result = pallet.AddBox(box);

            // Assert
            Assert.True(result);
            Assert.Contains(box, pallet.Boxes); // Проверяем, что коробка была добавлена
        }

        [Fact]
        public void AddBox_ShouldNotAddBoxToPallet_WhenBoxDoesNotFit()
        {
            // Arrange
            var pallet = new Pallet
            {
                Id = 1,
                Width = 2.0,
                Height = 2.0,
                Depth = 2.0,
            };
            var oversizedBox = new Box
            {
                Id = 2,
                Width = 3.0,
                Height = 1.5,
                Depth = 1.5,
                Weight = 6.0,
                ProductionDate = new DateTime(2023, 1, 1),
            };

            // Act
            bool result = pallet.AddBox(oversizedBox);

            // Assert
            Assert.False(result);
            Assert.DoesNotContain(oversizedBox, pallet.Boxes); // Проверяем, что коробка не была добавлена
        }

        [Fact]
        public void Pallet_ShouldCalculateWeight_Correctly()
        {
            // Arrange
            var pallet = new Pallet
            {
                Id = 1,
                Width = 2.0,
                Height = 2.0,
                Depth = 2.0,
            };
            pallet.AddBox(
                new Box
                {
                    Id = 1,
                    Width = 1.0,
                    Height = 1.0,
                    Depth = 1.0,
                    Weight = 10.0,
                    ProductionDate = new DateTime(2023, 1, 1),
                }
            );
            pallet.AddBox(
                new Box
                {
                    Id = 2,
                    Width = 1.0,
                    Height = 1.0,
                    Depth = 1.0,
                    Weight = 12.0,
                    ProductionDate = new DateTime(2023, 1, 5),
                }
            );

            // Act
            double actualWeight = pallet.TotalWeight;

            // Assert
            double expectedWeight = 30 + 10 + 12; // 30 кг для паллеты + вес коробок
            Assert.Equal(expectedWeight, actualWeight); // Проверяем точное соответствие
        }

        [Fact]
        public void Pallet_ShouldCalculateVolume_Correctly()
        {
            // Arrange
            var pallet = new Pallet
            {
                Id = 1,
                Width = 2.0,
                Height = 2.0,
                Depth = 2.0,
            };
            pallet.AddBox(
                new Box
                {
                    Id = 1,
                    Width = 1.0,
                    Height = 1.0,
                    Depth = 1.0,
                    Weight = 10.0,
                    ProductionDate = new DateTime(2023, 1, 1),
                }
            );
            pallet.AddBox(
                new Box
                {
                    Id = 2,
                    Width = 1.0,
                    Height = 1.0,
                    Depth = 1.0,
                    Weight = 12.0,
                    ProductionDate = new DateTime(2023, 1, 5),
                }
            );

            // Act
            double actualVolume = pallet.Volume;

            // Assert
            double expectedVolume = (2.0 * 2.0 * 2.0) + (1.0 * 1.0 * 1.0) * 2; // Паллет + две коробки
            Assert.Equal(Math.Round(expectedVolume, 2), Math.Round(actualVolume, 2)); // Ожидаемый результат округляем до 2 знаков
        }
    }
}
