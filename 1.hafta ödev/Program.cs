//İKİLİ ARAMA RECURSİVE OLARAK
class BinarySearch
{
    public static int ikiliArama(int[] A, int N, int sayi)
    {
        int sol = 0;
        int sağ = N - 1;
        while (sol <= sağ)
        {
            int orta = (sol + sağ) / 2;
            if (A[orta] == sağ)
            {
                return orta; }
            else if (sayi < A[orta])
            {
                sağ = orta - 1; }
            else {
                sol = orta + 1; }
        }
        return -1;
    }
    static void Main()
    {
        int[] sayilar = { 3, 8, 12, 13, 15, 20, };
        int arama_sayi = 8;
        int length = sayilar.Length;
        int product = ikiliArama(sayilar, length, arama_sayi);
        Console.WriteLine(product);
    }
}
class sayilar
{
    //DİZİLERDE TOPLAM
    public static int Array(int[] B)
    {
        int toplam = 0;
        for (int i = 0; i < B.Length; i++)
        {
            toplam += B[i];
        }
        return toplam;
    }
    //MATRİS ÇARPIMI
    public static int[,] matrixMultiplication(int[,] matrix1, int[,] matrix2)
    {
        int[,] text = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                text[i, j] = matrix1[i, j] * matrix2[i, j];
            }
        }
        return text;
    }

    public static void Main()
    {
        int[,] matrix1 = new int[3, 3];
        int[,] matrix2 = new int[3, 3];
        Random r = new Random();

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(0); j++)
            {
                matrix1[i, j] = r.Next(0, 100);
                matrix2[i, j] = r.Next(0, 100);
            }
        }
    }
}