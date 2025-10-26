using System;
using System.Collections.Generic;
using System.Text;

namespace TowerOfHanoi
{
    class Program
    {
        private static List<Stack<int>> towers = new List<Stack<int>>();
        private static int moveCount = 0;
        private static StringBuilder solutionLog = new StringBuilder();

        static void Main(string[] args)
        {
            Console.WriteLine("=== Kuleler Problemi (Tower of Hanoi) Çözümü ===");
            Console.WriteLine("Verilen: Üç iğne ve farklı büyüklükte diskler");
            Console.WriteLine("Amaç: Diskleri en soldan en sağa taşımak\n");

            // Disk sayısını kullanıcıdan al
            Console.Write("Disk sayısını girin (3-8 önerilir): ");
            int diskCount;

            while (!int.TryParse(Console.ReadLine(), out diskCount) || diskCount < 1)
            {
                Console.Write("Geçersiz giriş! Pozitif bir sayı girin: ");
            }

            // Kuleleri başlat
            InitializeTowers(diskCount);

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("BAŞLANGIÇ DURUMU");
            Console.WriteLine(new string('=', 50));
            PrintTowers();

            // Problemi çöz
            SolveHanoi(diskCount, 0, 2, 1);

            // Sonuçları göster
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("ÇÖZÜM TAMAMLANDI");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Toplam taşıma sayısı: {moveCount}");
            Console.WriteLine($"Teorik minimum taşıma sayısı: {Math.Pow(2, diskCount) - 1}");
        }

        static void InitializeTowers(int diskCount)
        {
            towers.Clear();

            // Üç kule oluştur
            for (int i = 0; i < 3; i++)
            {
                towers.Add(new Stack<int>());
            }

            // İlk kuleye diskleri yerleştir (en küçük disk en üstte)
            for (int i = 1; i <= diskCount; i++)
            {
                towers[0].Push(i);
            }
        }

        static void SolveHanoi(int n, int source, int destination, int auxiliary)
        {
            if (n > 0)
            {
                // 1. n-1 diski kaynaktan yardımcı kuleye taşı
                SolveHanoi(n - 1, source, auxiliary, destination);

                // 2. En büyük diski kaynaktan hedefe taşı
                MoveDisk(source, destination);

                // 3. n-1 diski yardımcı kuleden hedefe taşı
                SolveHanoi(n - 1, auxiliary, destination, source);
            }
        }

        static void MoveDisk(int from, int to)
        {
            if (towers[from].Count == 0)
                return;

            int disk = towers[from].Pop();
            towers[to].Push(disk);
            moveCount++;

            // Adım bilgisini oluştur
            string moveInfo = $"{moveCount}. Adım: Disk {disk} → {GetTowerName(from)}'den {GetTowerName(to)}'ye";
            solutionLog.AppendLine(moveInfo);

            Console.WriteLine($"\n{moveInfo}");
            PrintTowers();
        }

        static string GetTowerName(int towerIndex)
        {
            return towerIndex switch
            {
                0 => "Sol",
                1 => "Orta",
                2 => "Sağ",
                _ => $"Kule {towerIndex + 1}"
            };
        }

        static void PrintTowers()
        {
            int maxHeight = GetMaxTowerHeight();
            int diskWidth = GetMaxDiskSize() * 2 + 3;

            Console.WriteLine();

            // Üstten alta doğru yazdır
            for (int level = maxHeight - 1; level >= 0; level--)
            {
                for (int towerIndex = 0; towerIndex < 3; towerIndex++)
                {
                    PrintDiskAtLevel(towerIndex, level, diskWidth);
                }
                Console.WriteLine();
            }

            // Kule tabanlarını yazdır
            Console.WriteLine(new string('-', diskWidth * 3 + 2));
            Console.WriteLine($"{"Sol".PadCenter(diskWidth)} {"Orta".PadCenter(diskWidth)} {"Sağ".PadCenter(diskWidth)}");
            Console.WriteLine();
        }

        static void PrintDiskAtLevel(int towerIndex, int level, int maxWidth)
        {
            var towerList = new List<int>(towers[towerIndex]);
            towerList.Reverse(); // Üstten alta doğru sırala

            if (level < towerList.Count)
            {
                int diskSize = towerList[level];
                string disk = CreateDiskVisual(diskSize, maxWidth);
                Console.Write(disk);
            }
            else
            {
                // Boş kule çubuğu
                string emptyTower = "|".PadCenter(maxWidth);
                Console.Write(emptyTower);
            }
        }

        static string CreateDiskVisual(int size, int maxWidth)
        {
            int visualWidth = size * 2 + 1;
            string disk = new string('□', visualWidth);
            return $"({size})".PadCenter(maxWidth);
        }

        static int GetMaxTowerHeight()
        {
            int max = 0;
            foreach (var tower in towers)
            {
                if (tower.Count > max)
                    max = tower.Count;
            }
            return max;
        }

        static int GetMaxDiskSize()
        {
            int max = 0;
            foreach (var tower in towers)
            {
                foreach (var disk in tower)
                {
                    if (disk > max)
                        max = disk;
                }
            }
            return max;
        }
    }

    // String extension for center padding
    public static class StringExtensions
    {
        public static string PadCenter(this string str, int totalWidth, char paddingChar = ' ')
        {
            int padding = totalWidth - str.Length;
            if (padding <= 0)
                return str;

            int leftPadding = padding / 2;
            int rightPadding = padding - leftPadding;

            return new string(paddingChar, leftPadding) + str + new string(paddingChar, rightPadding);
        }
    }
}
